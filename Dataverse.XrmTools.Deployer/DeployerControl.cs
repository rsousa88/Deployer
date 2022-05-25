// System
using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Xml.Linq;
using System.Windows.Forms;
using System.IO.Compression;
using System.Collections.Generic;

// Microsoft
using Microsoft.Xrm.Sdk;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Tooling.Connector;

// 3rd Party
using McTools.Xrm.Connection;
using XrmToolBox.Extensibility;

// Deployer
using Dataverse.XrmTools.Deployer.Models;
using Dataverse.XrmTools.Deployer.Helpers;
using Dataverse.XrmTools.Deployer.AppSettings;
using Dataverse.XrmTools.Deployer.Repositories;
using Dataverse.XrmTools.Deployer.Enums;

namespace Dataverse.XrmTools.Deployer
{
    public partial class DeployerControl : PluginControlBase
    {
        #region Variables
        // settings
        private Settings _settings;

        // service
        private CrmServiceClient _client;

        // models
        private Instance _instance;
        private readonly List<Solution> _solutions = new List<Solution>();

        // flags
        private bool _working;

        // handlers
        private Logger _logger;
        #endregion Variables

        public DeployerControl()
        {
            LogInfo("----- Starting Deployer -----");

            LogInfo("Loading Settings...");
            SettingsHelper.GetSettings(out _settings);

            LogInfo("Initializing components...");
            InitializeComponent();

            _logger = new Logger();
            _logger.OnLog += Log;
        }

        public void DataMigrationControl_Load(object sender, EventArgs e)
        {
            ExecuteMethod(WhoAmI);
        }

        #region Interface Methods
        /// <summary>
        /// This event occurs when the connection has been updated in XrmToolBox
        /// </summary>
        public override void UpdateConnection(IOrganizationService newService, ConnectionDetail detail, string actionName, object parameter)
        {
            try
            {
                _logger.Log(LogLevel.DEBUG, $"Updating connection...");
                base.UpdateConnection(newService, detail, actionName, parameter);
                _logger.Log(LogLevel.DEBUG, $"Connection successfully updated...");

                _client = detail.ServiceClient;

                if (!actionName.Equals("AdditionalOrganization"))
                {
                    _logger.Log(LogLevel.DEBUG, $"Checking settings for known instances...");
                    _instance = _settings.Instances.FirstOrDefault(inst => inst.UniqueName.Equals(_client.ConnectedOrgUniqueName));
                    if (_instance is null)
                    {
                        _logger.Log(LogLevel.DEBUG, $"New instance '{_client.ConnectedOrgUniqueName}': Adding to settings...");
                        _instance = new Instance
                        {
                            Id = _client.ConnectedOrgId,
                            UniqueName = _client.ConnectedOrgUniqueName,
                            FriendlyName = _client.ConnectedOrgFriendlyName
                        };

                        _settings.Instances.Add(_instance);
                    }
                    else
                    {
                        _logger.Log(LogLevel.DEBUG, $"Found known instance '{_instance.UniqueName}'");
                    }

                    // save settings file
                    SettingsHelper.SetSettings(_settings);

                    // render UI components
                    _logger.Log(LogLevel.DEBUG, $"Rendering UI components...");
                    RenderInitialComponents(_instance.FriendlyName);
                }
            }
            catch (Exception ex)
            {
                ManageWorkingState(false);
                _logger.Log(LogLevel.ERROR, ex.Message);
                MessageBox.Show(this, $"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion Interface Methods

        #region Private Main Methods
        private void WhoAmI()
        {
            Service.Execute(new WhoAmIRequest());
        }

        private void QueueSolution()
        {
            var solution = GetSolutionData();
            if (solution is null)
            {
                throw new Exception("Invalid solution file");
            }

            if (_solutions.Any(sol => sol.LogicalName.Equals(solution.LogicalName)))
            {
                throw new Exception($"Solution '{solution.DisplayName}' already exists");
            }

            _solutions.Add(solution);

            var lvItem = solution.ToListViewItem();
            lvSolutions.Items.Add(lvItem);

            tsbDeploy.Enabled = true;
        }

        private void DeployQueue()
        {
            var count = _solutions.Count;
            if (DialogResult.No == MessageBox.Show(this, $@"Are you sure you want to deploy {count} solutions?", @"Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) { return; }

            _logger.Log(LogLevel.DEBUG, $"Deploying queued solutions...");
            if (_working) { return; }
            ManageWorkingState(true);

            WorkAsync(new WorkAsyncInfo
            {
                Message = $"Deploying queued solutions...",
                IsCancelable = true,
                Work = (worker, args) =>
                {
                    var repo = new CrmRepo(Service, _client, _logger);

                    var index = 1;
                    foreach (var solution in _solutions)
                    {
                        if (worker.CancellationPending) { return; }

                        var progress = 100 * index / count;

                        worker.ReportProgress(progress, $"Importing '{solution.DisplayName}' solution ({index}/{count})");
                        //_logger.Log(LogLevel.DEBUG, $"Importing '{solution.DisplayName}' solution...");
                        repo.ImportSolution(solution);

                        worker.ReportProgress(progress, $"Upgrading '{solution.DisplayName}' solution ({index}/{count})");
                        //_logger.Log(LogLevel.DEBUG, $"Upgrading '{solution.DisplayName}' solution...");
                        repo.UpgradeSolution(solution);

                        index++;
                    }
                },
                PostWorkCallBack = args =>
                {
                    ManageWorkingState(false);

                    if(args.Cancelled)
                    {
                        MessageBox.Show(this, "Operation canceled", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (args.Error != null)
                    {
                        _logger.Log(LogLevel.ERROR, args.Error.Message);
                        MessageBox.Show(this, args.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show(this, "Deploy complete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                },
                ProgressChanged = args =>
                {
                    SetWorkingMessage(args.UserState.ToString());
                }
            });
        }
        #endregion Private Main Methods

        #region Private Helper Methods
        private void Log(object sender, LoggerEventArgs args)
        {
            switch (args.Level)
            {
                case LogLevel.DEBUG:
                    LogInfo(args.Message);
                    break;
                case LogLevel.INFO:
                    LogInfo(args.Message);
                    break;
                case LogLevel.WARN:
                    LogWarning(args.Message);
                    break;
                case LogLevel.ERROR:
                    LogError(args.Message);
                    break;
                default:
                    break;
            }

            if (/*!args.Level.Equals(LogLevel.DEBUG) && */txtLogs != null)
            {
                txtLogs.AppendText($"{args.Level} | {DateTime.Now} | {args.Message}");
                txtLogs.AppendText(Environment.NewLine);
            }
        }

        private void ManageWorkingState(bool working)
        {
            pnlMain.Enabled = !working;

            _working = working;
            Cursor = working ? Cursors.WaitCursor : Cursors.Default;

            tsbAbort.Text = "Abort";
            tsbAbort.Visible = working;
        }

        private void RenderInitialComponents(string connectionName)
        {
            lblTargetValue.Text = connectionName;
            lblTargetValue.ForeColor = Color.MediumSeaGreen;

            tsbDeploy.Enabled = false;
            gbLogs.Enabled = false;
        }

        private Solution GetSolutionData()
        {
            _logger.Log(LogLevel.DEBUG, $"Loading solution file...");

            var dialog = new OpenFileDialog
            {
                Title = "Select solution file...",
                Filter = "Zip files (*.zip)|*.zip",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            var path = GetFileDialogPath(dialog);
            if (string.IsNullOrEmpty(path)) { return null; }

            // read solution data
            XDocument doc;
            using (var zip = ZipFile.Open(path, ZipArchiveMode.Read))
            {
                var file = zip.Entries.FirstOrDefault(ent => ent.Name.Equals("solution.xml"));
                if (file is null) { throw new Exception("Invalid solution file"); }

                using (var stream = file.Open())
                {
                    doc = XDocument.Load(stream);
                }
            }

            if (doc is null) { throw new Exception("Invalid solution file"); }

            var solManifestNodes = doc.Descendants("SolutionManifest");
            var solDisplayNames = solManifestNodes.Select(node => node.Element("LocalizedNames")).FirstOrDefault().Descendants();
            var publisherNodes = solManifestNodes.Select(node => node.Element("Publisher")).FirstOrDefault().Descendants();
            var pubDisplayNames = publisherNodes.FirstOrDefault(node => node.Name.LocalName.Equals("LocalizedNames")).Descendants();

            return new Solution
            {
                LogicalName = solManifestNodes.Select(node => node.Element("UniqueName")).FirstOrDefault().Value,
                DisplayName = solDisplayNames.FirstOrDefault(node => node.Attribute("languagecode").Value.Equals("1033")).Attribute("description").Value,
                Version = solManifestNodes.Select(node => node.Element("Version")).FirstOrDefault().Value,
                IsManaged = solManifestNodes.Select(node => node.Element("Managed")).FirstOrDefault().Value.Equals("1") ? true : false,
                Publisher = new Publisher
                {
                    LogicalName = publisherNodes.FirstOrDefault(node => node.Name.LocalName.Equals("UniqueName")).Value,
                    DisplayName = pubDisplayNames.FirstOrDefault(node => node.Attribute("languagecode").Value.Equals("1033")).Attribute("description").Value
                },
                SolutionBytes = File.ReadAllBytes(path)
            };
        }

        private string GetFileDialogPath(FileDialog dialog)
        {
            var path = string.Empty;

            using (var ofd = dialog as OpenFileDialog)
            {
                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    path = ofd.FileName;
                }
            }

            return path;
        }
        #endregion Private Helper Methods

        #region Form Events
        private void lvSolutions_Resize(object sender, EventArgs e)
        {
            var maxWidth = lvSolutions.Width >= 713 ? lvSolutions.Width : 713;
            chSolDisplayName.Width = (int)Math.Floor(maxWidth * 0.34);
            chSolVersion.Width = (int)Math.Floor(maxWidth * 0.15);
            chSolManaged.Width = (int)Math.Floor(maxWidth * 0.15);
            chSolPublisher.Width = (int)Math.Floor(maxWidth * 0.34);
            chSolPublisherLogicalNameHidden.Width = 0;
        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            try
            {
                (sender as ListView).Sort(_settings, e.Column);
            }
            catch (Exception ex)
            {
                ManageWorkingState(false);
                _logger.Log(LogLevel.ERROR, ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddSolution_Click(object sender, EventArgs e)
        {
            try
            {
                QueueSolution();
            }
            catch (Exception ex)
            {
                ManageWorkingState(false);
                _logger.Log(LogLevel.ERROR, ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbDeploy_Click(object sender, EventArgs e)
        {
            try
            {
                DeployQueue();
            }
            catch (Exception ex)
            {
                ManageWorkingState(false);
                _logger.Log(LogLevel.ERROR, ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbAbort_Click(object sender, EventArgs e)
        {
            try
            {
                CancelWorker();
                tsbAbort.Text = "Aborting...";
            }
            catch (Exception ex)
            {
                ManageWorkingState(false);
                _logger.Log(LogLevel.ERROR, ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmsiRemove_Click(object sender, EventArgs e)
        {
            if (lvSolutions.FocusedItem != null && lvSolutions.SelectedItems.Count > 0)
            {
                var selected = lvSolutions.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
                lvSolutions.Items.RemoveAt(selected.Index);

                var solution = selected.ToObject(new Solution()) as Solution;
                var item = _solutions.FirstOrDefault(sol => sol.LogicalName.Equals(solution.LogicalName));
                if (item != null)
                {
                    _solutions.Remove(item);
                }
            }
        }
        #endregion Form Events
    }
}
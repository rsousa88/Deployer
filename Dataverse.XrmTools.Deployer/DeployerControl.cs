// System
using System;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.Specialized;

// Microsoft
using Microsoft.Xrm.Sdk;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Tooling.Connector;

// 3rd Party
using McTools.Xrm.Connection;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Args;
using XrmToolBox.Extensibility.Interfaces;

// ActiveLayerExplorer
using Dataverse.XrmTools.Deployer.Models;
using Dataverse.XrmTools.Deployer.Helpers;
using Dataverse.XrmTools.Deployer.AppSettings;
using Dataverse.XrmTools.Deployer.Repositories;
using Dataverse.XrmTools.Deployer.Forms;
using System.IO;
using System.IO.Compression;
using System.Xml.Linq;

namespace Dataverse.XrmTools.Deployer
{
    public partial class DeployerControl : MultipleConnectionsPluginControlBase, IStatusBarMessenger
    {
        #region Variables
        // settings
        private Settings _settings;

        // service
        private CrmServiceClient _client;

        // models
        private Instance _instance;
        private List<Solution> _solutions;
        private List<ComponentType> _componentsList;
        private List<ComponentType> _solutionComponentTypes;
        private List<SolutionComponent> _solutionComponents;
        private IEnumerable<ActiveLayer> _activeLayers;

        // flags
        private bool _working;

        // other
        private int _batchSize = 0;
        #endregion Variables

        #region Handlers
        public event EventHandler<StatusBarMessageEventArgs> SendMessageToStatusBar;
        #endregion Variables

        public DeployerControl()
        {
            LogInfo("----- Starting Active Layer Explorer -----");

            LogInfo("Loading Settings...");
            SettingsHelper.GetSettings(out _settings);

            LogInfo("Initializing components...");
            InitializeComponent();
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
                LogInfo($"Updating connection...");
                base.UpdateConnection(newService, detail, actionName, parameter);
                LogInfo($"Connection successfully updated...");

                _client = detail.ServiceClient;

                if (!actionName.Equals("AdditionalOrganization"))
                {
                    LogInfo($"Checking settings for known instances...");
                    _instance = _settings.Instances.FirstOrDefault(inst => inst.UniqueName.Equals(_client.ConnectedOrgUniqueName));
                    if (_instance is null)
                    {
                        LogInfo($"New instance '{_client.ConnectedOrgUniqueName}': Adding to settings...");
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
                        LogInfo($"Found known instance '{_instance.UniqueName}'");
                    }

                    // save settings file
                    SettingsHelper.SetSettings(_settings);

                    // render UI components
                    LogInfo($"Rendering UI components...");
                    RenderInitialComponents(_instance.FriendlyName);

                    // load component types and solutions when source connection changes
                    LoadInitialData();
                }
            }
            catch (Exception ex)
            {
                ManageWorkingState(false);
                LogError(ex.Message);
                MessageBox.Show(this, $"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        protected override void ConnectionDetailsUpdated(NotifyCollectionChangedEventArgs args)
        {
            try
            {
                if (args.Action.Equals(NotifyCollectionChangedAction.Add))
                {
                    var detail = (ConnectionDetail)args.NewItems[0];
                    var client = detail.ServiceClient;

                    if (_client == null) { throw new Exception("Source connection is invalid"); }
                    LogInfo($"Source OrgId: {_client.ConnectedOrgId}");
                    LogInfo($"Source OrgUniqueName: {_client.ConnectedOrgUniqueName}");
                    LogInfo($"Source OrgFriendlyName: {_client.ConnectedOrgFriendlyName}");
                    LogInfo($"Source EnvId: {_client.EnvironmentId}");

                    if (client == null) { throw new Exception("Target connection is invalid"); }
                    LogInfo($"Target OrgId: {client.ConnectedOrgId}");
                    LogInfo($"Target OrgUniqueName: {client.ConnectedOrgUniqueName}");
                    LogInfo($"Target OrgFriendlyName: {client.ConnectedOrgFriendlyName}");
                    LogInfo($"Target EnvId: {client.EnvironmentId}");

                    if (_client.ConnectedOrgUniqueName.Equals(client.ConnectedOrgUniqueName))
                    {
                        throw new Exception("Source and Target connections must refer to different Dataverse instances");
                    }

                    _instance = _settings.Instances.FirstOrDefault(inst => !string.IsNullOrEmpty(inst.UniqueName) && inst.UniqueName.Equals(client.ConnectedOrgUniqueName));
                    if (_instance == null)
                    {
                        _instance = new Instance
                        {
                            Id = client.ConnectedOrgId,
                            UniqueName = client.ConnectedOrgUniqueName,
                            FriendlyName = client.ConnectedOrgFriendlyName
                        };

                        _settings.Instances.Add(_instance);
                    }

                    SettingsHelper.SetSettings(_settings);

                    RenderInitialComponents(_instance.FriendlyName);
                    SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs("Connection ready"));
                }
            }
            catch (Exception ex)
            {
                ManageWorkingState(false);
                LogError(ex.Message);
                MessageBox.Show(this, $"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion Interface Methods

        #region Private Main Methods
        private void WhoAmI()
        {
            Service.Execute(new WhoAmIRequest());
        }

        private void LoadInitialData()
        {
            LogInfo($"Loading initial data...");

            if (Service == null)
            {
                ExecuteMethod(WhoAmI);
                return;
            }

            if (_working) { return; }
            ManageWorkingState(true);

            if (string.IsNullOrEmpty(_settings.Filter))
            {
                _settings.Filter = string.Empty;
                SettingsHelper.SetSettings(_settings);
            }

            if (_settings.BatchSize.Equals(0))
            {
                _settings.BatchSize = 1000;
                SettingsHelper.SetSettings(_settings);
            }

            _batchSize = _settings.BatchSize;
            txtBatchSize.Text = _batchSize.ToString();

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading initial data...",
                Work = (worker, args) =>
                {
                    var repo = new CrmRepo(Service, _batchSize, worker);
                    var metadata = repo.GetOptionSetMetadata("solutioncomponent", "componenttype");

                    args.Result = metadata.OptionSet.Options.Select(ct => new ComponentType
                    {
                        Value = ct.Value.Value,
                        LogicalName = ct.Label.UserLocalizedLabel.Label.RemoveSpaces(),
                        DisplayName = ct.Label.UserLocalizedLabel.Label
                    }).ToList();
                },
                PostWorkCallBack = args =>
                {
                    ManageWorkingState(false);

                    if (args.Error != null)
                    {
                        LogError(args.Error.Message);
                        MessageBox.Show(this, args.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        _componentsList = args.Result as List<ComponentType>;
                        SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs("Initial data load complete"));

                        LoadSolutions();
                    }
                }
            });
        }

        private void LoadSolutions()
        {
            LogInfo($"Loading solutions...");

            gbComponents.Enabled = false;
            gbLayers.Enabled = false;

            if (_working) { return; }
            ManageWorkingState(true);

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading solutions...",
                Work = (worker, args) =>
                {
                    var repo = new CrmRepo(Service, _batchSize, worker);
                    var solutions = repo.GetManagedSolutions(new string[] { "uniquename", "friendlyname" });

                    args.Result = solutions.Select(sol => new Solution
                    {
                        SolutionId = sol.GetAttributeValue<Guid>("solutionid"),
                        LogicalName = sol.GetAttributeValue<string>("uniquename"),
                        DisplayName = sol.GetAttributeValue<string>("friendlyname")
                    }).OrderBy(sol => sol.DisplayName).ToList();
                },
                PostWorkCallBack = args =>
                {
                    ManageWorkingState(false);

                    if (args.Error != null)
                    {
                        LogError(args.Error.Message);
                        MessageBox.Show(this, args.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        // load solutions list
                        _solutions = args.Result as List<Solution>;
                        LoadSolutionsList();
                    }
                }
            });
        }

        private void LoadSolutionsList()
        {
            LogInfo($"Rendering solutions list view...");

            if (_working) { return; }
            ManageWorkingState(true);

            lvSolutions.Items.Clear();

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Rendering solutions...",
                Work = (worker, args) =>
                {
                    var filtered = _solutions.Where(sol => string.IsNullOrWhiteSpace(string.Empty) || sol.MatchFilter(string.Empty));

                    args.Result = filtered.Select(sol => sol.ToListViewItem()).ToArray();
                },
                PostWorkCallBack = args =>
                {
                    ManageWorkingState(false);

                    if (args.Error != null)
                    {
                        LogError(args.Error.Message);
                        MessageBox.Show(this, args.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var items = args.Result as ListViewItem[];
                        lvSolutions.Items.AddRange(items);

                        gbSolutions.Enabled = true;
                        SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs("Solutions load complete"));
                    }
                }
            });
        }
        #endregion Private Main Methods

        #region Private Helper Methods
        private void ManageWorkingState(bool working)
        {
            pnlMain.Enabled = !working;

            _working = working;
            Cursor = working ? Cursors.WaitCursor : Cursors.Default;
        }

        private void RenderInitialComponents(string connectionName)
        {
            lblSourceValue.Text = connectionName;
            lblSourceValue.ForeColor = Color.MediumSeaGreen;

            gbSolutions.Enabled = false;
            gbComponents.Enabled = false;
            gbLayers.Enabled = false;
        }
        #endregion Private Helper Methods

        #region Form events
        private void lvSolutions_Resize(object sender, EventArgs e)
        {
            var maxWidth = lvSolutions.Width >= 300 ? lvSolutions.Width : 300;
            chSolDisplayName.Width = (int)Math.Floor(maxWidth * 0.99);
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
                LogError(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void txtBatchSize_TextChanged(object sender, EventArgs e)
        {
            async Task<bool> UserKeepsTyping()
            {
                var txt = txtBatchSize.Text;
                await Task.Delay(500);

                return txt != txtBatchSize.Text;
            }

            if (await UserKeepsTyping()) return;

            // user is done typing -> execute logic
            try
            {
                var batch = txtBatchSize.Text.ToInt();
                if(!batch.HasValue)
                {
                    throw new Exception($"Enter a valid batch size");
                }
                if(batch.Value > 1000)
                {
                    var msg = $"WARNING: Setting batch size above 1000 is not recommended!\n\nContinue?";
                    var result = MessageBox.Show(msg, "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                    if (result.Equals(DialogResult.No))
                    {
                        batch = 1000;
                        txtBatchSize.Text = batch.ToString();
                        return;
                    }
                }

                _settings.BatchSize = batch.Value;
                _batchSize = _settings.BatchSize;
                SettingsHelper.SetSettings(_settings);
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ManageWorkingState(false);
                txtBatchSize.Focus();
            }
        }
        #endregion Form events





        #region Private Main Methods
        private Solution GetSolutionData()
        {
            LogInfo($"Loading solution file...");

            //gbComponents.Enabled = false;
            //gbLayers.Enabled = false;

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

        private void ImportAndUpgradeSolution(Solution solution)
        {
            LogInfo($"Importing solution...");
            if (_working) { return; }
            ManageWorkingState(true);

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Importing solution...",
                AsyncArgument = solution,
                Work = (worker, args) =>
                {
                    var repo = new CrmRepo(Service, _client);
                    args.Result = repo.ImportSolution(solution);
                },
                PostWorkCallBack = args =>
                {
                    ManageWorkingState(false);

                    if (args.Error != null)
                    {
                        LogError(args.Error.Message);
                        MessageBox.Show(this, args.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        UpgradeSolution(solution);
                    }
                }
            });
        }

        private void UpgradeSolution(Solution solution)
        {
            LogInfo($"Upgrading solution...");
            if (_working) { return; }
            ManageWorkingState(true);

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Upgrading solution...",
                AsyncArgument = solution,
                Work = (worker, args) =>
                {
                    var repo = new CrmRepo(Service, _client);
                    args.Result = repo.UpgradeSolution(solution);
                },
                PostWorkCallBack = args =>
                {
                    ManageWorkingState(false);

                    if (args.Error != null)
                    {
                        LogError(args.Error.Message);
                        MessageBox.Show(this, args.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var result = args.Result as ImportAndUpgradeResponse;
                        MessageBox.Show(this, result.Message, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            });
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
        #endregion Private Main Methods

        #region Form Events
        private void btnAddSolutionToQueue_Click(object sender, EventArgs e)
        {
            try
            {
                var solution = GetSolutionData();
                if (solution != null)
                {
                    ImportAndUpgradeSolution(solution);
                }
            }
            catch (Exception ex)
            {
                ManageWorkingState(false);
                LogError(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion Form Events
    }
}
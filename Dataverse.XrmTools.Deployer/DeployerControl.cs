﻿// System
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
using Dataverse.XrmTools.Deployer.Forms;
using Dataverse.XrmTools.Deployer.HandlerArgs;

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
        private readonly List<Operation> _operations = new List<Operation>();

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
            _logger.Log(LogLevel.INFO, "Deployer tool initialized");
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

        private void DeployQueue()
        {
            var count = _operations.Count;
            if (DialogResult.No == MessageBox.Show(this, $@"{count} operations will be executed sequentially in the presented order. Are you sure you want to continue?", @"Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) { return; }

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
                    foreach (var operation in _operations)
                    {
                        if (worker.CancellationPending) { return; }

                        var progress = 100 * index / count;

                        worker.ReportProgress(progress, $"Importing '{operation.Solution.DisplayName}' solution ({index}/{count})");
                        repo.ImportSolution(operation.Solution);

                        worker.ReportProgress(progress, $"Upgrading '{operation.Solution.DisplayName}' solution ({index}/{count})");
                        repo.UpgradeSolution(operation.Solution);

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

            if (/*!args.Level.Equals(LogLevel.DEBUG) && */IsHandleCreated)
            {
                txtLogs.Invoke(new MethodInvoker(delegate {
                    txtLogs.AppendText($"{args.Level} | {DateTime.Now} | {args.Message}");
                    txtLogs.AppendText(Environment.NewLine);
                }));
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

            tsbExecute.Enabled = false;
        }
        #endregion Private Helper Methods

        #region Form Events
        private void lvSolutions_Resize(object sender, EventArgs e)
        {
            var maxWidth = lvOperations.Width >= 713 ? lvOperations.Width : 713;
            chOpType.Width = (int)Math.Floor(maxWidth * 0.10);
            chOpDisplayName.Width = (int)Math.Floor(maxWidth * 0.34);
            chOpVersion.Width = (int)Math.Floor(maxWidth * 0.10);
            chOpManaged.Width = (int)Math.Floor(maxWidth * 0.15);
            chOpPublisher.Width = (int)Math.Floor(maxWidth * 0.29);
            chOpPublisherLogicalNameHidden.Width = 0;
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
            using (var form = new AddOperation(_logger))
            {
                form.OnExport += HandleExportOperationEvent;
                form.OnImport += HandleImportOperationEvent;
                form.OnDelete += HandleDeleteOperationEvent;

                form.ShowDialog();
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
            if (lvOperations.FocusedItem != null && lvOperations.SelectedItems.Count > 0)
            {
                var selected = lvOperations.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
                lvOperations.Items.RemoveAt(selected.Index);

                var operation = selected.ToObject(new Operation()) as Operation;
                var item = _operations.FirstOrDefault(op => op.Solution.LogicalName.Equals(operation.Solution.LogicalName));
                if (item != null)
                {
                    _operations.Remove(item);

                    _logger.Log(LogLevel.INFO, $"Removed '{operation.Type}' operation from queue ({operation.Solution.DisplayName})");
                }
            }
        }
        #endregion Form Events

        #region Custom Handler Events
        private void HandleExportOperationEvent(object sender, ExportEventArgs args)
        {
            var operation = new Operation { Type = OperationType.EXPORT, Solution = args.Solution };
            if (_operations.Any(op => op.Type.Equals(OperationType.EXPORT) && op.Solution.LogicalName.Equals(args.Solution.LogicalName)))
            {
                throw new Exception($"{args.Solution.DisplayName} export operation is already added to queue");
            }

            _operations.Add(operation);
            var lvItem = operation.ToListViewItem();
            lvOperations.Items.Add(lvItem);

            _logger.Log(LogLevel.INFO, $"Added 'Export' operation to queue ({args.Solution.DisplayName})");

            tsbExecute.Enabled = true;
        }

        private void HandleImportOperationEvent(object sender, ImportEventArgs args)
        {
            var operation = new Operation { Type = OperationType.IMPORT, Solution = args.Solution };
            if(_operations.Any(op => op.Type.Equals(OperationType.IMPORT) && op.Solution.LogicalName.Equals(args.Solution.LogicalName)))
            {
                throw new Exception($"{args.Solution.DisplayName} import operation is already added to queue");
            }

            _operations.Add(operation);
            var lvItem = operation.ToListViewItem();
            lvOperations.Items.Add(lvItem);

            _logger.Log(LogLevel.INFO, $"Added 'Import' operation to queue ({args.Solution.DisplayName})");

            tsbExecute.Enabled = true;
        }

        private void HandleDeleteOperationEvent(object sender, DeleteEventArgs args)
        {
            var operation = new Operation { Type = OperationType.DELETE, Solution = args.Solution };
            if (_operations.Any(op => op.Type.Equals(OperationType.DELETE) && op.Solution.LogicalName.Equals(args.Solution.LogicalName)))
            {
                throw new Exception($"{args.Solution.DisplayName} delete operation is already added to queue");
            }

            _operations.Add(operation);
            var lvItem = operation.ToListViewItem();
            lvOperations.Items.Add(lvItem);

            _logger.Log(LogLevel.INFO, $"Added 'Delete' operation to queue ({args.Solution.DisplayName})");

            tsbExecute.Enabled = true;
        }
        #endregion Custom Handler Events
    }
}
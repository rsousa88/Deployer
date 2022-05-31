// System
using System;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections.Specialized;

// Microsoft
using Microsoft.Xrm.Sdk;
using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Tooling.Connector;

// 3rd Party
using McTools.Xrm.Connection;
using XrmToolBox.Extensibility;

// Deployer
using Dataverse.XrmTools.Deployer.Enums;
using Dataverse.XrmTools.Deployer.Forms;
using Dataverse.XrmTools.Deployer.Models;
using Dataverse.XrmTools.Deployer.Helpers;
using Dataverse.XrmTools.Deployer.AppSettings;
using Dataverse.XrmTools.Deployer.Repositories;

namespace Dataverse.XrmTools.Deployer
{
    public partial class DeployerControl : MultipleConnectionsPluginControlBase
    {
        #region Variables
        // settings
        private Settings _settings;

        // service
        private CrmServiceClient _primary;
        private CrmServiceClient _secondary;

        // models
        private Instance _targetInstance;
        private Instance _sourceInstance;
        private List<Operation> _operations = new List<Operation>();

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
            _logger.OnOutput += Output;
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
                _logger.Log(LogLevel.DEBUG, $"Updating connections...");
                base.UpdateConnection(newService, detail, actionName, parameter);

                

                var connType = actionName.Equals("AdditionalOrganization") ? "Secondary" : "Primary";
                _logger.Log(LogLevel.DEBUG, $"Connection type: {connType}");

                if (!actionName.Equals("AdditionalOrganization"))
                {
                    _primary = detail.ServiceClient;

                    _logger.Log(LogLevel.DEBUG, $"Checking settings for known instances...");
                    _targetInstance = _settings.Instances.FirstOrDefault(inst => inst.UniqueName.Equals(_primary.ConnectedOrgUniqueName));
                    if (_targetInstance is null)
                    {
                        _logger.Log(LogLevel.DEBUG, $"New instance '{_primary.ConnectedOrgUniqueName}': Adding to settings...");
                        _targetInstance = new Instance
                        {
                            Id = _primary.ConnectedOrgId,
                            UniqueName = _primary.ConnectedOrgUniqueName,
                            FriendlyName = _primary.ConnectedOrgFriendlyName
                        };

                        _settings.Instances.Add(_targetInstance);
                    }
                    else
                    {
                        _logger.Log(LogLevel.DEBUG, $"Found known instance '{_targetInstance.UniqueName}'");
                    }

                    // save settings file
                    _settings.SaveSettings();

                    // render UI components
                    _logger.Log(LogLevel.DEBUG, $"Rendering UI components...");
                    RenderInitialComponents(_targetInstance.FriendlyName);
                    RenderConnectionLabel(ConnectionType.TARGET, _targetInstance.FriendlyName);
                }
            }
            catch (Exception ex)
            {
                ManageWorkingState(false);
                _logger.Log(LogLevel.ERROR, ex.Message);
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
                    _secondary = detail.ServiceClient;

                    if (_primary == null) { throw new Exception("Primary connection is invalid"); }
                    LogInfo($"Target OrgId: {_primary.ConnectedOrgId}");
                    LogInfo($"Target OrgUniqueName: {_primary.ConnectedOrgUniqueName}");
                    LogInfo($"Target OrgFriendlyName: {_primary.ConnectedOrgFriendlyName}");
                    LogInfo($"Target EnvId: {_primary.EnvironmentId}");

                    if (_secondary == null) { throw new Exception("Secondary connection is invalid"); }
                    LogInfo($"Source OrgId: {_secondary.ConnectedOrgId}");
                    LogInfo($"Source OrgUniqueName: {_secondary.ConnectedOrgUniqueName}");
                    LogInfo($"Source OrgFriendlyName: {_secondary.ConnectedOrgFriendlyName}");
                    LogInfo($"Source EnvId: {_secondary.EnvironmentId}");

                    if (_primary.ConnectedOrgUniqueName.Equals(_secondary.ConnectedOrgUniqueName))
                    {
                        throw new Exception("Source and Target connections must refer to different Dataverse instances");
                    }

                    var instance = _settings.Instances.FirstOrDefault(inst => !string.IsNullOrEmpty(inst.UniqueName) && inst.UniqueName.Equals(_secondary.ConnectedOrgUniqueName));
                    if (instance == null)
                    {
                        instance = new Instance
                        {
                            Id = _secondary.ConnectedOrgId,
                            UniqueName = _secondary.ConnectedOrgUniqueName,
                            FriendlyName = _secondary.ConnectedOrgFriendlyName
                        };

                        _settings.Instances.Add(instance);
                    }

                    _sourceInstance = instance;

                    _settings.SaveSettings();

                    RenderConnectionLabel(ConnectionType.SOURCE, _sourceInstance.FriendlyName);
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

        private IEnumerable<Solution> RetrieveSolutions(PackageType queryType, ConnectionType connType)
        {
            if(connType.Equals(ConnectionType.SOURCE) && _secondary is null)
            {
                throw new Exception("Source connection is required for export operation");
            }

            LogInfo($"Loading solutions...");

            var repo = new CrmRepo(_primary, _logger, _secondary);
            var solutions = repo.GetSolutions(new string[] { "uniquename", "friendlyname", "version", "ismanaged", "description" }, queryType, connType);


            return solutions.Select(sol =>
            {
                var solution = new Solution
                {
                    SolutionId = sol.GetAttributeValue<Guid>("solutionid"),
                    LogicalName = sol.GetAttributeValue<string>("uniquename"),
                    DisplayName = sol.GetAttributeValue<string>("friendlyname"),
                    Version = sol.GetAttributeValue<string>("version"),
                    Description = sol.GetAttributeValue<string>("description"),
                    IsManaged = sol.GetAttributeValue<bool>("ismanaged"),
                    Publisher = new Publisher
                    {
                        LogicalName = sol.GetAttributeValue<AliasedValue>("publisher.uniquename").Value.ToString(),
                        DisplayName = sol.GetAttributeValue<AliasedValue>("publisher.friendlyname").Value.ToString()
                    }
                };

                var updated = _operations.FirstOrDefault(op => op.OperationType.Equals(OperationType.UPDATE) && op.Solution.LogicalName.Equals(solution.LogicalName));
                if (updated != null)
                {
                    // found an update operation -> also update queued operations
                    solution.DisplayName = updated.Solution.DisplayName;
                    solution.Version = updated.Solution.Version;
                    solution.Description = updated.Solution.Description;
                }

                return solution;
            }).OrderBy(sol => sol.DisplayName);
        }

        private Solution RetrieveSolutionByLogicalName(string logicalName, ConnectionType connType)
        {
            if (connType.Equals(ConnectionType.SOURCE) && _secondary is null)
            {
                throw new Exception("Source connection is required for export operation");
            }

            LogInfo($"Loading solutions...");

            var repo = new CrmRepo(_primary, _logger, _secondary);
            var record = repo.GetSolution(logicalName);

            return record is null ? null : new Solution { SolutionId = record.GetAttributeValue<Guid>("solutionid") };
        }

        private void DeployQueue()
        {
            var count = _operations.Count;
            if (DialogResult.No == MessageBox.Show(this, $@"{count} operations will be executed sequentially in the presented order. Are you sure you want to continue?", @"Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) { return; }

            _logger.Log(LogLevel.INFO, $"Executing queued operations...");
            if (_working) { return; }
            ManageWorkingState(true);

            WorkAsync(new WorkAsyncInfo
            {
                Message = $"Executing queued operations...",
                IsCancelable = true,
                Work = (worker, args) =>
                {
                    var startTotalTime = DateTime.UtcNow;

                    var repo = new CrmRepo(_primary, _logger, _secondary, worker);

                    var index = 1;
                    foreach (var operation in _operations)
                    {
                        if (worker.CancellationPending) { return; }

                        var startPartialTime = DateTime.UtcNow;

                        var progress = 100 * (index -1) / count;

                        switch (operation.OperationType)
                        {
                            case OperationType.UPDATE:
                                worker.ReportProgress(progress, $"Queue execution: {index}/{count} ({progress}%)\nUpdating '{operation.Solution.DisplayName}'");
                                repo.UpdateSolution(operation);

                                var updateTime = (DateTime.UtcNow - startPartialTime).ToString(@"hh\:mm\:ss");
                                _logger.Log(LogLevel.INFO, $"Solution {operation.Solution.DisplayName} successfully updated in {updateTime}");
                                break;
                            case OperationType.EXPORT:
                                var export = operation as ExportOperation;
                                worker.ReportProgress(progress, $"Queue execution: {index}/{count} ({progress}%)\nExporting '{export.Solution.DisplayName}'");
                                repo.ExportSolution(export);

                                var exportTime = (DateTime.UtcNow - startPartialTime).ToString(@"hh\:mm\:ss");
                                _logger.Log(LogLevel.INFO, $"Solution {export.Solution.DisplayName} successfully exported in {exportTime}");
                                break;
                            case OperationType.IMPORT:
                                var import = operation as ImportOperation;
                                var message = $"Queue execution: {index}/{count} ({progress}%)\nImporting '{import.Solution.DisplayName}'";
                                worker.ReportProgress(progress, message);
                                repo.ImportSolution(import, message);

                                var importTime = (DateTime.UtcNow - startPartialTime).ToString(@"hh\:mm\:ss");
                                _logger.Log(LogLevel.INFO, $"Solution {operation.Solution.DisplayName} successfully imported in {importTime}");

                                if (import.HoldingSolution)
                                {
                                    startPartialTime = DateTime.UtcNow;

                                    worker.ReportProgress(progress, $"Queue execution: {index}/{count} ({progress}%)\nUpgrading '{import.Solution.DisplayName}'");
                                    repo.UpgradeSolution(import.Solution);

                                    var upgradeTime = (DateTime.UtcNow - startPartialTime).ToString(@"hh\:mm\:ss");
                                    _logger.Log(LogLevel.INFO, $"Solution {operation.Solution.DisplayName} successfully upgraded in {upgradeTime}");
                                }
                                break;
                            case OperationType.DELETE:
                                worker.ReportProgress(progress, $"Queue execution: {index}/{count} ({progress}%)\nDeleting '{operation.Solution.DisplayName}'");
                                repo.DeleteSolution(operation.Solution);

                                var deleteTime = (DateTime.UtcNow - startPartialTime).ToString(@"hh\:mm\:ss");
                                _logger.Log(LogLevel.INFO, $"Solution {operation.Solution.DisplayName} successfully deleted in {deleteTime}");
                                break;
                            case OperationType.UNPACK:
                                var unpack = operation as UnpackOperation;
                                worker.ReportProgress(progress, $"Queue execution: {index}/{count} ({progress}%)\nUnpacking '{unpack.Solution.DisplayName}'");
                                repo.UnpackSolution(unpack);

                                var unpackTime = (DateTime.UtcNow - startPartialTime).ToString(@"hh\:mm\:ss");
                                _logger.Log(LogLevel.INFO, $"Solution {unpack.Solution.DisplayName} successfully unpacked in {unpackTime}");
                                break;
                            case OperationType.PACK:
                                //var pack = operation as PackOperation;
                                //worker.ReportProgress(progress, $"Queue execution: {index}/{count} ({progress}%)\nPacking '{pack.Solution.DisplayName}'");
                                //repo.UnpackSolution(pack);

                                //var packTime = (DateTime.UtcNow - startPartialTime).ToString(@"hh\:mm\:ss");
                                //_logger.Log(LogLevel.INFO, $"Solution {pack.Solution.DisplayName} successfully packed in {packTime}");
                                break;
                            case OperationType.PUBLISH:
                                worker.ReportProgress(progress, $"Queue execution: {index}/{count} ({progress}%)\nPublishing all customizations");
                                repo.PublishCustomizations();

                                var publishTime = (DateTime.UtcNow - startPartialTime).ToString(@"hh\:mm\:ss");
                                _logger.Log(LogLevel.INFO, $"All customizations were successfully published in {publishTime}");
                                break;
                            default:
                                break;
                        }

                        index++;
                    }

                    var totalTime = (DateTime.UtcNow - startTotalTime).ToString(@"hh\:mm\:ss");
                    _logger.Log(LogLevel.INFO, $"Total execution time: {totalTime}");
                },
                PostWorkCallBack = args =>
                {
                    ManageWorkingState(false);

                    if(args.Cancelled)
                    {
                        _logger.Log(LogLevel.INFO, $"Operation canceled by user");
                        MessageBox.Show(this, "Operation canceled by user", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (args.Error != null)
                    {
                        _logger.Log(LogLevel.ERROR, args.Error.Message);
                        MessageBox.Show(this, args.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        _logger.Log(LogLevel.INFO, $"All operations were successfully executed");
                        MessageBox.Show(this, "All operations were successfully executed", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // clear queue
                        lvOperations.Items.Clear();
                        _operations.Clear();

                        tsbExecute.Enabled = false;

                        btnUp.Enabled = false;
                        btnUp.BackgroundImage = Properties.Resources.arrow_up_disabled_35px;

                        btnDown.Enabled = false;
                        btnDown.BackgroundImage = Properties.Resources.arrow_down_disabled_35px;
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
        private void RenderConnectionLabel(ConnectionType serviceType, string name)
        {
            var label = serviceType.Equals(ConnectionType.SOURCE) ? lblSourceValue : lblTargetValue;
            label.Text = name;
            label.ForeColor = Color.MediumSeaGreen;
        }

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
                case LogLevel.PACKAGER:
                    LogInfo(args.Message);
                    break;
                default:
                    break;
            }

            if (!args.Level.Equals(LogLevel.PACKAGER) && !args.Level.Equals(LogLevel.DEBUG) && IsHandleCreated)
            {
                txtLogs.Invoke(new MethodInvoker(delegate {
                    txtLogs.AppendText($"{args.Level} | {DateTime.Now} | {args.Message}");
                    txtLogs.AppendText(Environment.NewLine);
                }));
            }

            if (args.Level.Equals(LogLevel.PACKAGER) && IsHandleCreated)
            {
                txtOutput.Invoke(new MethodInvoker(delegate {
                    txtOutput.AppendText($"{args.Level} | {DateTime.Now} | {args.Message}");
                    txtOutput.AppendText(Environment.NewLine);
                }));
            }
        }

        private void Output(object sender, LoggerEventArgs args)
        {
            if (/*!args.Level.Equals(LogLevel.DEBUG) && */IsHandleCreated)
            {
                txtOutput.Invoke(new MethodInvoker(delegate {
                    txtOutput.AppendText($"{args.Level} | {DateTime.Now} | {args.Message}");
                    txtOutput.AppendText(Environment.NewLine);
                }));
            }
        }

        private void ManageWorkingState(bool working)
        {
            pnlMain.Enabled = !working;

            _working = working;
            Cursor = working ? Cursors.WaitCursor : Cursors.Default;

            tsbCancel.Text = "Cancel";
            tsbCancel.Visible = working;
        }

        private void RenderInitialComponents(string connectionName)
        {
            lblTargetValue.Text = connectionName;
            lblTargetValue.ForeColor = Color.MediumSeaGreen;

            tsbExecute.Enabled = false;
        }

        private void RenderOperationsList(int selectedIndex)
        {
            _operations = _operations.OrderBy(op => op.Index).ToList();

            lvOperations.Items.Clear();
            lvOperations.Items.AddRange(_operations.Select(op => op.ToListViewItem()).ToArray());

            lvOperations.Items.Cast<ListViewItem>().SingleOrDefault(lvi => (lvi.Tag as Operation).Index.Equals(selectedIndex)).Selected = true;
        }
        #endregion Private Helper Methods

        #region Custom Handler Events
        private void HandleOperationEvent(object sender, Operation operation)
        {
            if(!operation.OperationType.Equals(OperationType.PUBLISH))
            {
                if (_operations.Any(op => op.OperationType.Equals(operation.OperationType) && op.Solution.LogicalName.Equals(operation.Solution.LogicalName)))
                {
                    throw new Exception($"An operation of the same type on solution {operation.Solution.DisplayName} is already added to queue");
                }

                var updated = _operations.FirstOrDefault(op => op.OperationType.Equals(OperationType.UPDATE) && op.Solution.LogicalName.Equals(operation.Solution.LogicalName));
                if (updated != null)
                {
                    // found an update operation -> also update queued operations
                    operation.Solution.DisplayName = updated.Solution.DisplayName;
                    operation.Solution.Version = updated.Solution.Version;
                    operation.Solution.Description = updated.Solution.Description;
                }
            }

            operation.Index = lvOperations.Items.Count + 1;

            _operations.Add(operation);
            var lvItem = operation.ToListViewItem();
            lvOperations.Items.Add(lvItem);

            var message = $"Added '{operation.OperationType}' operation to queue";
            if(!operation.OperationType.Equals(OperationType.PUBLISH)) { message += $" ({operation.Solution.DisplayName})"; }
            _logger.Log(LogLevel.INFO, message);

            tsbExecute.Enabled = true;
        }

        private IEnumerable<Solution> HandleRetrieveSolutionsEvent(PackageType queryType, ConnectionType connType)
        {
            return RetrieveSolutions(queryType, connType);
        }

        private Solution HandleRetrieveSingleSolutionEvent(string logicalName, ConnectionType connType)
        {
            return RetrieveSolutionByLogicalName(logicalName, connType);
        }

        private IEnumerable<Operation> HandleRetrieveOperationsEvent(OperationType opType)
        {
            return _operations.Where(op => op.OperationType.Equals(opType));
        }
        #endregion Custom Handler Events

        #region Form Events
        private void btnConnectSource_Click(object sender, EventArgs e)
        {
            try
            {
                AddAdditionalOrganization();
            }
            catch (Exception ex)
            {
                ManageWorkingState(false);
                LogError(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvSolutions_Resize(object sender, EventArgs e)
        {
            var maxWidth = lvOperations.Width >= 713 ? lvOperations.Width : 713;
            chOpIndex.Width = (int)Math.Floor(maxWidth * 0.03);
            chOpType.Width = (int)Math.Floor(maxWidth * 0.10);
            chOpDisplayName.Width = (int)Math.Floor(maxWidth * 0.34);
            chOpVersion.Width = (int)Math.Floor(maxWidth * 0.10);
            chOpManaged.Width = (int)Math.Floor(maxWidth * 0.12);
            chOpPublisher.Width = (int)Math.Floor(maxWidth * 0.24);
        }

        private void btnAddOperation_Click(object sender, EventArgs e)
        {
            try
            {
                using (var form = new AddOperation(_logger, _settings))
                {
                    form.OnOperation += HandleOperationEvent;
                    form.OnSolutionsRetrieve += HandleRetrieveSolutionsEvent;
                    form.OnSingleSolutionRetrieve += HandleRetrieveSingleSolutionEvent;
                    form.OnOperationsRetrieve += HandleRetrieveOperationsEvent;

                    form.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                ManageWorkingState(false);
                LogError(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClearQueue_Click(object sender, EventArgs e)
        {
            lvOperations.Items.Clear();
            _operations.Clear();

            tsbExecute.Enabled = false;

            btnUp.Enabled = false;
            btnUp.BackgroundImage = Properties.Resources.arrow_up_disabled_35px;

            btnDown.Enabled = false;
            btnDown.BackgroundImage = Properties.Resources.arrow_down_disabled_35px;
        }

        private void tsbDeploy_Click(object sender, EventArgs e)
        {
            try
            {
                txtLogs.Clear();
                txtOutput.Clear();

                DeployQueue();
            }
            catch (Exception ex)
            {
                ManageWorkingState(false);
                _logger.Log(LogLevel.ERROR, ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbCancel_Click(object sender, EventArgs e)
        {
            try
            {
                CancelWorker();
                tsbCancel.Text = "Canceling...";
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
                var item = _operations.SingleOrDefault(op => op.OperationType.Equals(operation.OperationType) && (op.OperationType.Equals(OperationType.PUBLISH) || op.Solution.LogicalName.Equals(operation.Solution.LogicalName)));
                if (item != null)
                {
                    _operations.Remove(item);

                    if(_operations.Count.Equals(0))
                    {
                        tsbExecute.Enabled = false;

                        btnUp.Enabled = false;
                        btnUp.BackgroundImage = Properties.Resources.arrow_up_disabled_35px;

                        btnDown.Enabled = false;
                        btnDown.BackgroundImage = Properties.Resources.arrow_down_disabled_35px;
                    }

                    var message = $"Removed '{operation.OperationType}' operation from queue";
                    if (!operation.OperationType.Equals(OperationType.PUBLISH)) { message += $" ({operation.Solution.DisplayName})"; }
                    _logger.Log(LogLevel.INFO, message);
                }
            }
        }

        private void btnClearLogs_Click(object sender, EventArgs e)
        {
            txtLogs.Clear();
            txtOutput.Clear();
        }

        private void lvOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            var selected = lvOperations.SelectedItems.Count;
            if (selected > 0)
            {
                btnUp.Enabled = true;
                btnUp.BackgroundImage = Properties.Resources.arrow_up_35px;

                btnDown.Enabled = true;
                btnDown.BackgroundImage = Properties.Resources.arrow_down_35px;
            }
            else
            {
                btnUp.Enabled = false;
                btnUp.BackgroundImage = Properties.Resources.arrow_up_disabled_35px;

                btnDown.Enabled = false;
                btnDown.BackgroundImage = Properties.Resources.arrow_down_disabled_35px;
            }
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            var selected = lvOperations.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
            if (selected != null)
            {
                var oldIndex = (selected.Tag as Operation).Index;
                if (oldIndex > 1)
                {
                    var oldOperation = _operations.SingleOrDefault(op => op.Index.Equals(_operations.FindIndex(op2 => op2.Index.Equals(oldIndex))));
                    var newOperation = _operations.SingleOrDefault(op => op.OperationId.Equals((selected.Tag as Operation).OperationId));

                    oldOperation.Index++;
                    newOperation.Index--;

                    RenderOperationsList(oldIndex -1);
                }
            }
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            var selected = lvOperations.SelectedItems.Cast<ListViewItem>().FirstOrDefault();
            if (selected != null)
            {
                var oldIndex = (selected.Tag as Operation).Index;
                if (oldIndex < _operations.Count)
                {
                    var oldOperation = _operations.SingleOrDefault(op => op.Index.Equals(oldIndex +1));
                    var newOperation = _operations.SingleOrDefault(op => op.OperationId.Equals((selected.Tag as Operation).OperationId));

                    oldOperation.Index--;
                    newOperation.Index++;

                    RenderOperationsList(oldIndex + 1);
                }
            }
        }

        private void txtLogs_TextChanged(object sender, EventArgs e)
        {
            txtOutput.ScrollToCaret();
        }

        private void txtOutput_TextChanged(object sender, EventArgs e)
        {
            txtOutput.ScrollToCaret();
        }
        #endregion Form Events
    }
}
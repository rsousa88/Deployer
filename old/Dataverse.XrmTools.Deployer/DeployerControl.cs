// System
using System;
using System.IO;
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

// Deployer
using Dataverse.XrmTools.Deployer.Enums;
using Dataverse.XrmTools.Deployer.Forms;
using Dataverse.XrmTools.Deployer.Models;
using Dataverse.XrmTools.Deployer.Helpers;
using Dataverse.XrmTools.Deployer.AppSettings;
using Dataverse.XrmTools.Deployer.Repositories;

// 3rd Party
using McTools.Xrm.Connection;
using XrmToolBox.Extensibility;
using Dataverse.XrmTools.Deployer.Controls;

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
        private Workspace _workspace;
        private IList<Operation> _operations = new List<Operation>();

        // flags
        private bool _working;
        private bool _workspaceLoaded = false;

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
                    _sourceInstance = _settings.Instances.FirstOrDefault(inst => inst.UniqueName.Equals(_primary.ConnectedOrgUniqueName));
                    if (_sourceInstance is null)
                    {
                        _logger.Log(LogLevel.DEBUG, $"New instance '{_primary.ConnectedOrgUniqueName}': Adding to settings...");
                        _sourceInstance = new Instance
                        {
                            Id = _primary.ConnectedOrgId,
                            UniqueName = _primary.ConnectedOrgUniqueName,
                            FriendlyName = _primary.ConnectedOrgFriendlyName
                        };

                        _settings.Instances.Add(_sourceInstance);
                    }
                    else
                    {
                        _logger.Log(LogLevel.DEBUG, $"Found known instance '{_sourceInstance.UniqueName}'");
                    }

                    // save settings file
                    _settings.SaveSettings();

                    // render UI components
                    _logger.Log(LogLevel.DEBUG, $"Rendering UI components...");
                    RenderInitialComponents(_sourceInstance.FriendlyName);
                    RenderConnectionStatus(ConnectionType.SOURCE, _sourceInstance.FriendlyName);
                    RenderSolutionPackagerStatus();
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
                    LogInfo($"Source OrgId: {_primary.ConnectedOrgId}");
                    LogInfo($"Source OrgUniqueName: {_primary.ConnectedOrgUniqueName}");
                    LogInfo($"Source OrgFriendlyName: {_primary.ConnectedOrgFriendlyName}");
                    LogInfo($"Source EnvId: {_primary.EnvironmentId}");

                    if (_secondary == null) { throw new Exception("Secondary connection is invalid"); }
                    LogInfo($"Target OrgId: {_secondary.ConnectedOrgId}");
                    LogInfo($"Target OrgUniqueName: {_secondary.ConnectedOrgUniqueName}");
                    LogInfo($"Target OrgFriendlyName: {_secondary.ConnectedOrgFriendlyName}");
                    LogInfo($"Target EnvId: {_secondary.EnvironmentId}");

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

                    _targetInstance = instance;

                    _settings.SaveSettings();

                    RenderConnectionStatus(ConnectionType.TARGET, _targetInstance.FriendlyName);
                    pnlAddOperation.Controls.Clear();
                    tsmiImport.Enabled = true;
                    tsmiDelete.Enabled = true;
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
            if(connType.Equals(ConnectionType.TARGET) && _secondary is null)
            {
                throw new Exception("Target connection is required for this operation");
            }

            LogInfo($"Loading solutions...");

            var repo = new CrmRepo(_primary, _logger, _secondary);
            var results = queryType.Equals(PackageType.BOTH) ? repo.GetAllSolutions(connType) : repo.GetSolutionsByType(queryType, connType);

            return results.Select(res =>
            {
                var solution = new Solution
                {
                    SolutionId = res.Record.GetAttributeValue<Guid>("solutionid"),
                    LogicalName = res.Record.GetAttributeValue<string>("uniquename"),
                    DisplayName = res.Record.GetAttributeValue<string>("friendlyname"),
                    Version = res.Record.GetAttributeValue<string>("version"),
                    Description = res.Record.GetAttributeValue<string>("description"),
                    IsManaged = res.Record.GetAttributeValue<bool>("ismanaged"),
                    Publisher = new Publisher
                    {
                        LogicalName = res.Related.GetAttributeValue<string>("uniquename"),
                        DisplayName = res.Related.GetAttributeValue<string>("friendlyname")
                    }
                };

                return solution;
            }).OrderBy(sol => sol.DisplayName);
        }

        private Solution RetrieveSolutionByLogicalName(string logicalName, ConnectionType connType)
        {
            if (connType.Equals(ConnectionType.TARGET) && _secondary is null)
            {
                throw new Exception("A target connection is required for this operation");
            }

            LogInfo($"Loading solutions...");

            var repo = new CrmRepo(_primary, _logger, _secondary);
            var record = repo.GetSolution(logicalName, new string[] { "solutionid", "uniquename", "ismanaged" }, connType);

            return record is null ? null : new Solution { SolutionId = record.GetAttributeValue<Guid>("solutionid"), IsManaged = record.GetAttributeValue<bool>("ismanaged") };
        }

        private async Task CheckRequirements()
        {
            _logger.Log(LogLevel.INFO, $"Checking requirements...");
            var targetRequired = _operations.Any(op => op.OperationType.Equals(OperationType.IMPORT));
            if(targetRequired && _secondary is null)
            {
                throw new Exception($"A target connect is required to execute queued operations");
            }

            var packagerRequired = _operations.Any(op => op.OperationType.Equals(OperationType.UNPACK) || op.OperationType.Equals(OperationType.PACK));
            if (packagerRequired && (!File.Exists(_settings.PackagerPath) || string.IsNullOrEmpty(_settings.PackagerVersion)))
            {
                var packager = await InstallSolutionPackager();

                _settings.WorkingDirectory = packager["tools"];
                _settings.PackagerPath = packager["path"];
                _settings.PackagerVersion = packager["version"];

                _settings.SaveSettings();

                RenderSolutionPackagerStatus();
            }
        }

        private void ExecuteQueue()
        {
            var count = _operations.Count;
            if (DialogResult.No == MessageBox.Show(this, $@"{count} operations will be executed sequentially in the presented order. Are you sure you want to continue?", @"Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) { return; }

            if (_working) { return; }
            _logger.Log(LogLevel.INFO, $"Executing queued operations...");

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

                        var progress = 100 * (index - 1) / count;

                        switch (operation.OperationType)
                        {
                            case OperationType.UPDATE:
                                var update = operation as UpdateOperation;
                                worker.ReportProgress(progress, $"Queue execution: {index}/{count} ({progress}%)\nUpdating '{update.Solution.DisplayName}'");
                                repo.UpdateSolution(update);

                                var updateTime = (DateTime.UtcNow - startPartialTime).ToString(@"hh\:mm\:ss");
                                _logger.Log(LogLevel.INFO, $"Solution {update.Solution.DisplayName} successfully updated in {updateTime}");
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
                                var pack = operation as PackOperation;
                                worker.ReportProgress(progress, $"Queue execution: {index}/{count} ({progress}%)\nPacking '{pack.Solution.DisplayName}'");
                                repo.PackSolution(pack);

                                var packTime = (DateTime.UtcNow - startPartialTime).ToString(@"hh\:mm\:ss");
                                _logger.Log(LogLevel.INFO, $"Solution {pack.Solution.DisplayName} successfully packed in {packTime}");
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

                    if (args.Cancelled)
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
                        if (DialogResult.Yes == MessageBox.Show(this, "All operations were successfully executed.\n\nDo you want to save current queue?", @"Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question)) { SaveQueue(); }

                        // clear queue
                        lvQueue.Items.Clear();
                        _operations.Clear();

                        tsbQueueExecute.Enabled = false;
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
        private void RenderConnectionStatus(ConnectionType serviceType, string name)
        {
            var label = serviceType.Equals(ConnectionType.SOURCE) ? lblSourceValue: lblTargetValue;
            label.Text = name;
            label.ForeColor = Color.MediumSeaGreen;
        }

        private void RenderSolutionPackagerStatus()
        {
            if (File.Exists(_settings.PackagerPath) && !string.IsNullOrEmpty(_settings.PackagerVersion))
            {
                lblPackagerVersionValue.Text = _settings.PackagerVersion;
                lblPackagerVersionValue.ForeColor = Color.MediumSeaGreen;
            }
            else
            {
                lblPackagerVersionValue.Text = "Not installed";
                lblPackagerVersionValue.ForeColor = Color.DarkRed;
            }
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
            mainContainer.Enabled = !working && _workspaceLoaded;

            _working = working;
            Cursor = working ? Cursors.WaitCursor : Cursors.Default;

            tsbQueueCancel.Text = "Cancel";
            tsbQueueCancel.Visible = working;
        }

        private void RenderInitialComponents(string connectionName)
        {
            mainContainer.Enabled = false;

            lblSourceValue.Text = connectionName;
            lblSourceValue.ForeColor = Color.MediumSeaGreen;

            tsbQueueExecute.Enabled = false;
        }

        private void ReRenderOperationsList()
        {
            lvQueue.Items.Clear();

            var index = 1;

            var operations = _operations.OrderBy(op => op.Index).ToList();
            foreach (var op in operations)
            {
                op.Index = index++;
            }

            lvQueue.Items.AddRange(operations.Select(op => op.ToListViewItem()).ToArray());

            tsbQueueExecute.Enabled = lvQueue.Items.Count > 0;
            tsmiSaveQueue.Enabled = lvQueue.Items.Count > 0;
            tsmiClearQueue.Enabled = lvQueue.Items.Count > 0;

            pnlAddOperation.Controls.Clear();
        }

        private string GetOperationDescription(Operation operation)
        {
            switch (operation.OperationType)
            {
                case OperationType.UPDATE:
                    var update = operation as UpdateOperation;
                    return $"Update solution '{update.Solution.DisplayName}' version to '{update.Version}'";
                case OperationType.EXPORT:
                    var export = operation as ExportOperation;
                    return $"Export '{export.PackageType}' package for solution '{export.Solution.DisplayName}'";
                case OperationType.IMPORT:
                    var import = operation as ImportOperation;
                    return $"Import '{import.Package.Type}' package for solution '{import.Solution.DisplayName}'";
                case OperationType.DELETE:
                    return $"Delete solution '{operation.Solution.DisplayName}'";
                case OperationType.UNPACK:
                    var unpack = operation as UnpackOperation;
                    return $"Unpack '{unpack.PackageType.ToUpper()}' package to '{unpack.Folder}'";
                case OperationType.PACK:
                    var pack = operation as PackOperation;
                    return $"Pack '{pack.PackageType.ToUpper()}' package to '{pack.ZipFile}'";
                default:
                    return string.Empty;
            }
        }

        private void SaveQueue()
        {
            _logger.Log(LogLevel.INFO, $"Saving queue...");

            var defaultFilename = $"{_workspace.Version}.queue.json";
            var filename = this.SaveFile("Json files (*.json)|*.queue.json", defaultFilename);

            var dirPath = Path.GetDirectoryName(filename);
            if (string.IsNullOrEmpty(dirPath)) { return; }

            var project = new Project
            {
                Workspace = _workspace,
                Operations = _operations
            };

            var json = project.SerializeObject();
            File.WriteAllText(filename, json);

            _logger.Log(LogLevel.INFO, $"Queue saved to {filename}");
            MessageBox.Show(this, "Queue saved", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async Task<Dictionary<string, string>> InstallSolutionPackager()
        {
            _logger.Log(LogLevel.INFO, $"Downloading latest version of Core Tools...");

            var package = "Microsoft.CrmSdk.CoreTools";
            var feed = "https://packages.nuget.org/api/v2";

            var toolsDir = Path.GetDirectoryName(typeof(DeployerControl).Assembly.Location);
            toolsDir = Path.Combine(toolsDir, package);
            Directory.CreateDirectory(toolsDir);

            ManageWorkingState(true);

            var repo = new NuGetRepo();
            var packager = await repo.DownloadCoreToolsAsync(toolsDir, feed, package);

            ManageWorkingState(false);

            return packager;
        }

        private UpdateOperation ParseUpdate(ExportOperation export)
        {
            return new UpdateOperation
            {
                OperationType = OperationType.UPDATE,
                Version = export.Version,
                Solution = new Solution
                {
                    SolutionId = export.Solution.SolutionId,
                    DisplayName = export.Solution.DisplayName,
                    LogicalName = export.Solution.LogicalName,
                    Publisher = export.Solution.Publisher
                }
            };
        }

        private UnpackOperation ParseUnpack(ExportOperation export)
        {
            var projectDir = Path.Combine(_workspace.RootPath, _workspace.ProjectDisplayName);
            var solutionDir = Path.Combine(projectDir, export.Solution.DisplayName);

            return new UnpackOperation
            {
                OperationType = OperationType.UNPACK,
                Solution = new Solution
                {
                    SolutionId = export.Solution.SolutionId,
                    DisplayName = export.Solution.DisplayName,
                    LogicalName = export.Solution.LogicalName,
                    Publisher = export.Solution.Publisher
                },
                Action = "Extract",
                WorkingDir = _settings.WorkingDirectory,
                Packager = _settings.PackagerPath,
                Folder = Path.Combine(solutionDir, "source"),
                PackageType = export.PackageType.Equals(PackageType.MANAGED) ? "Managed" : "Unmanaged",
                ZipFile = $"{Path.Combine(solutionDir, "backup")}\\{export.PackageName}",
                Map = string.Empty
            };
        }

        private PackOperation ParsePack(ExportOperation export)
        {
            var projectDir = Path.Combine(_workspace.RootPath, _workspace.ProjectDisplayName);
            var solutionDir = Path.Combine(projectDir, export.Solution.DisplayName);

            return new PackOperation
            {
                OperationType = OperationType.PACK,
                Solution = new Solution
                {
                    SolutionId = export.Solution.SolutionId,
                    DisplayName = export.Solution.DisplayName,
                    LogicalName = export.Solution.LogicalName,
                    Publisher = export.Solution.Publisher
                },
                Action = "Pack",
                WorkingDir = _settings.WorkingDirectory,
                Packager = _settings.PackagerPath,
                PackageType = export.PackageType.Equals(PackageType.MANAGED) ? "Managed" : "Unmanaged",
                ZipFile = $"{Path.Combine(solutionDir, "dist")}\\{export.PackageName}",
                Folder = Path.Combine(solutionDir, "source"),
                Map = string.Empty
            };
        }

        private void AddToQueue(Operation operation)
        {
            if (_operations.Any(op => op.OperationType.Equals(operation.OperationType) && op.Solution.LogicalName.Equals(operation.Solution.LogicalName)))
            {
                throw new Exception($"An operation of type '{operation.OperationType}' on solution '{operation.Solution.DisplayName}' is already added to queue");
            }

            operation.Index = lvQueue.Items.Count + 1;
            operation.Description = GetOperationDescription(operation);

            _operations.Add(operation);

            var exportLvi = operation.ToListViewItem();
            lvQueue.Items.Add(exportLvi);

            _logger.Log(LogLevel.INFO, $"Added '{operation.OperationType}' operation on solution '{operation.Solution.DisplayName}' to queue");
        }

        private void CreateWorkspace(Workspace workspace)
        {
            // create workspace structure
            var projectDir = Path.Combine(workspace.RootPath, workspace.ProjectDisplayName);

            foreach (var solution in workspace.Solutions)
            {
                var solutionDir = Path.Combine(projectDir, solution.DisplayName);

                Directory.CreateDirectory(Path.Combine(solutionDir, "backup")); // exported solutions dir
                Directory.CreateDirectory(Path.Combine(solutionDir, "source")); // unpacked solutions dir
                Directory.CreateDirectory(Path.Combine(solutionDir, "dist")); // packed solutions dir
            }

            _workspace = workspace;
            _workspaceLoaded = true;
            tsbEditProject.Enabled = true;
            mainContainer.Enabled = true;
        }

        private void SaveWorkspaceFile()
        {
            _logger.Log(LogLevel.INFO, $"Saving project workspace file...");

            var filename = Path.Combine(_workspace.RootPath, $"{_workspace.ProjectLogicalName}.workspace");

            var json = _workspace.SerializeObject();
            File.WriteAllText(filename, json);

            _logger.Log(LogLevel.INFO, $"Project workspace saved to {filename}");
        }
        #endregion Private Helper Methods

        #region Custom Handler Events
        private void HandleAddExportsToQueueEvent(object sender, IEnumerable<ExportOperation> exports)
        {
            try
            {
                foreach (var export in exports)
                {
                    if (export.UpdateVersion)
                    {
                        var update = ParseUpdate(export);
                        AddToQueue(update);
                    }

                    AddToQueue(export);

                    if (export.Unpack)
                    {
                        var unpack = ParseUnpack(export);
                        AddToQueue(unpack);
                    }

                    if (export.Pack)
                    {
                        var pack = ParsePack(export);
                        AddToQueue(pack);
                    }

                    tsbQueueExecute.Enabled = true;
                    tsmiSaveQueue.Enabled = true;
                    tsmiClearQueue.Enabled = true;
                }

                // update workspace version if there is at least one update operation
                var anyUpdate = _operations.FirstOrDefault(op => op.OperationType.Equals(OperationType.UPDATE));
                if (anyUpdate != null)
                {
                    _workspace.Version = (anyUpdate as UpdateOperation).Version;
                    SaveWorkspaceFile();
                }

                pnlAddOperation.Controls.Clear();
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ManageWorkingState(false);
            }
        }

        private void HandleAddImportsToQueueEvent(object sender, IEnumerable<ImportOperation> imports)
        {
            try
            {
                foreach (var import in imports)
                {
                    AddToQueue(import);

                    tsbQueueExecute.Enabled = true;
                    tsmiSaveQueue.Enabled = true;
                    tsmiClearQueue.Enabled = true;
                }

                pnlAddOperation.Controls.Clear();
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ManageWorkingState(false);
            }
        }

        private void HandleAddDeletesToQueueEvent(object sender, IEnumerable<DeleteOperation> deletes)
        {
            try
            {
                foreach (var delete in deletes)
                {
                    AddToQueue(delete);

                    tsbQueueExecute.Enabled = true;
                    tsmiSaveQueue.Enabled = true;
                    tsmiClearQueue.Enabled = true;
                }

                pnlAddOperation.Controls.Clear();
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ManageWorkingState(false);
            }
        }
        #endregion Custom Handler Events

        #region Form Events
        private void btnClearLogs_Click(object sender, EventArgs e)
        {
            txtLogs.Clear();
            txtOutput.Clear();
        }

        private void txtLogs_TextChanged(object sender, EventArgs e)
        {
            txtOutput.ScrollToCaret();
        }

        private void txtOutput_TextChanged(object sender, EventArgs e)
        {
            txtOutput.ScrollToCaret();
        }        

        private void tsbOperationCancel_Click(object sender, EventArgs e)
        {
            try
            {
                pnlAddOperation.Controls.Clear();
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ManageWorkingState(false);
            }
        }

        private void tsmiExport_Click(object sender, EventArgs e)
        {
            try
            {
                ManageWorkingState(true);
                pnlAddOperation.Controls.Clear();

                var allSolutions = RetrieveSolutions(PackageType.UNMANAGED, ConnectionType.SOURCE);

                // filter workspace solutions
                var solutionIds = _workspace.Solutions.Select(ws => ws.SolutionId);
                var solutions = allSolutions.Where(sol => solutionIds.Contains(sol.SolutionId));

                var export = new ExportControl(_logger, solutions, _workspace, _secondary != null);
                export.OnAddToQueue_Export += HandleAddExportsToQueueEvent;

                pnlAddOperation.Controls.Add(export);
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ManageWorkingState(false);
            }
        }

        private void btnConnectTarget_Click(object sender, EventArgs e)
        {
            try
            {
                AddAdditionalOrganization();
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ManageWorkingState(false);
            }
        }

        private void cmsiRemove_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvQueue.FocusedItem is null || lvQueue.SelectedItems.Count.Equals(0)) { return; }

                foreach (var itemObj in lvQueue.SelectedItems)
                {
                    var selected = itemObj as ListViewItem;
                    lvQueue.Items.RemoveAt(selected.Index);

                    var operation = selected.ToObject(new Operation()) as Operation;
                    var item = _operations.SingleOrDefault(op => op.OperationType.Equals(operation.OperationType) && op.Solution.LogicalName.Equals(operation.Solution.LogicalName));
                    if (item != null)
                    {
                        _operations.Remove(item);
                        _logger.Log(LogLevel.INFO, $"Removed '{operation.OperationType}' operation regarding solution '{operation.Solution.DisplayName}'");
                    }
                }

                ReRenderOperationsList(); // reset operation indexes and rerender list view
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ManageWorkingState(false);
            }
        }

        private void lvQueue_Resize(object sender, EventArgs e)
        {
            var maxWidth = lvQueue.Width >= 1300 ? lvQueue.Width : 1300;
            chOpIndex.Width = (int)Math.Floor(maxWidth * 0.03);
            chOpType.Width = (int)Math.Floor(maxWidth * 0.07);
            chOpDisplayName.Width = (int)Math.Floor(maxWidth * 0.20);
            chOpPublisher.Width = (int)Math.Floor(maxWidth * 0.15);
            chOpDescription.Width = (int)Math.Floor(maxWidth * 0.45);
        }

        private void tsmiClearQueue_Click(object sender, EventArgs e)
        {
            try
            {
                lvQueue.Items.Clear();
                _operations.Clear();

                ReRenderOperationsList();
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ManageWorkingState(false);
            }
        }

        private void tsmiSaveQueue_Click(object sender, EventArgs e)
        {
            try
            {
                SaveQueue();
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ManageWorkingState(false);
            }
        }

        private void tsmiLoadQueue_Click(object sender, EventArgs e)
        {
            try
            {
                _logger.Log(LogLevel.INFO, $"Loading queue...");
                var path = this.SelectFile("Json files (*.json)|*.queue.json");
                if (string.IsNullOrEmpty(path)) { return; }

                var json = File.ReadAllText(path);
                var project = json.DeserializeObject<Project>();
                if(project is null || project.Workspace is null)
                {
                    throw new Exception($"Invalid queue file");
                }
                if (!project.Workspace.Source.Id.Equals(_workspace.Source.Id))
                {
                    throw new Exception($"This queue file is related with another workspace");
                }

                _operations = project.Operations;

                ReRenderOperationsList();
                _logger.Log(LogLevel.INFO, $"Queue loaded from file {path}");
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ManageWorkingState(false);
            }
        }

        private void tsbNewProject_Click(object sender, EventArgs e)
        {
            try
            {
                ManageWorkingState(true);

                var solutions = RetrieveSolutions(PackageType.UNMANAGED, ConnectionType.SOURCE);

                using (var form = new ProjectForm(_logger, solutions, _sourceInstance))
                {
                    var workspace = form.ShowDialog(this) == DialogResult.OK ? form.Workspace : null;
                    if (workspace != null)
                    {
                        CreateWorkspace(workspace);
                        SaveWorkspaceFile();
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ManageWorkingState(false);
            }
        }

        private void tsbLoadProject_Click(object sender, EventArgs e)
        {
            try
            {
                _logger.Log(LogLevel.INFO, $"Loading workspace from file...");
                var path = this.SelectFile("Workspace files (*.workspace)|*.workspace");
                if (string.IsNullOrEmpty(path)) { return; }

                var json = File.ReadAllText(path);
                var workspace = json.DeserializeObject<Workspace>();

                // compare workspace instances with connected environments
                if(!workspace.Source.Id.Equals(_primary.ConnectedOrgId))
                {
                    throw new Exception($"Project workspace is associated with a different instance. Please update plugin connection or create a new project.\n\nWorkspace: '{workspace.Source.FriendlyName}'\nYour connection: '{_primary.ConnectedOrgFriendlyName}'");
                }

                CreateWorkspace(workspace);

                _logger.Log(LogLevel.INFO, $"Project workspace successfully loaded from {path}");
                //MessageBox.Show(this, "Project workspace loaded", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ManageWorkingState(false);
            }
        }

        private void tsbEditProject_Click(object sender, EventArgs e)
        {
            try
            {
                ManageWorkingState(true);

                var project = new Project
                {
                    Workspace = _workspace,
                    Operations = _operations
                };

                var solutions = RetrieveSolutions(PackageType.UNMANAGED, ConnectionType.SOURCE);

                using (var form = new ProjectForm(_logger, solutions, project, _sourceInstance))
                {
                    var workspace = form.ShowDialog(this) == DialogResult.OK ? form.Workspace : null;
                    if (workspace != null)
                    {
                        CreateWorkspace(workspace);
                        SaveWorkspaceFile();
                    }
                }
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ManageWorkingState(false);
            }
        }

        private void tsmiImport_Click(object sender, EventArgs e)
        {
            try
            {
                ManageWorkingState(true);
                pnlAddOperation.Controls.Clear();

                var exports = _operations.Where(op => op.OperationType.Equals(OperationType.EXPORT)).Select(op => op as ExportOperation);

                var import = new ImportControl(_logger, exports, _secondary);
                import.OnAddToQueue_Import += HandleAddImportsToQueueEvent;
                import.OnTargetSolutionRetrieveRequested += RetrieveSolutionByLogicalName;

                pnlAddOperation.Controls.Add(import);
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ManageWorkingState(false);
            }
        }

        private async void tsbQueueExecute_Click(object sender, EventArgs e)
        {
            try
            {
                txtLogs.Clear();
                txtOutput.Clear();

                await CheckRequirements();
                ExecuteQueue();
            }
            catch (Exception ex)
            {
                ManageWorkingState(false);
                _logger.Log(LogLevel.ERROR, ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsmiDelete_Click(object sender, EventArgs e)
        {
            try
            {
                ManageWorkingState(true);
                pnlAddOperation.Controls.Clear();

                var managedTargetSolutions = RetrieveSolutions(PackageType.MANAGED, ConnectionType.TARGET);

                var delete = new DeleteControl(_logger, managedTargetSolutions);
                delete.OnAddToQueue_Delete += HandleAddDeletesToQueueEvent;

                pnlAddOperation.Controls.Add(delete);
            }
            catch (Exception ex)
            {
                LogError(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ManageWorkingState(false);
            }
        }
        #endregion Form Events
    }
}
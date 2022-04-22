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
using Dataverse.XrmTools.ActiveLayerExplorer.Models;
using Dataverse.XrmTools.ActiveLayerExplorer.Helpers;
using Dataverse.XrmTools.ActiveLayerExplorer.AppSettings;
using Dataverse.XrmTools.ActiveLayerExplorer.Repositories;

namespace Dataverse.XrmTools.ActiveLayerExplorer
{
    public partial class ActiveLayerExplorerControl : MultipleConnectionsPluginControlBase, IStatusBarMessenger
    {
        #region Variables
        // settings
        private Settings _settings;

        // service
        private CrmServiceClient _sourceClient;
        private CrmServiceClient _targetClient;

        // main objects
        private Instance _sourceInstance;
        private Instance _targetInstance;

        // models
        private IEnumerable<Solution> _solutions;
        private IEnumerable<ComponentType> _componentTypes;
        private IEnumerable<ComponentType> _solutionComponentTypes;
        private IEnumerable<SolutionComponent> _solutionComponents;

        // flags
        private bool _ready = false;
        private bool _working;
        #endregion Variables

        #region Handlers
        public event EventHandler<StatusBarMessageEventArgs> SendMessageToStatusBar;
        #endregion Variables

        public ActiveLayerExplorerControl()
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

                var client = detail.ServiceClient;

                if (!actionName.Equals("AdditionalOrganization"))
                {
                    LogInfo($"Checking settings for known instances...");
                    var instance = _settings.Instances.FirstOrDefault(inst => inst.UniqueName.Equals(client.ConnectedOrgUniqueName));
                    if (instance is null)
                    {
                        LogInfo($"New instance '{client.ConnectedOrgUniqueName}': Adding to settings...");
                        instance = new Instance
                        {
                            Id = client.ConnectedOrgId,
                            UniqueName = client.ConnectedOrgUniqueName,
                            FriendlyName = client.ConnectedOrgFriendlyName
                        };

                        _settings.Instances.Add(instance);
                    }
                    else
                    {
                        LogInfo($"Found known instance '{instance.UniqueName}'");
                    }

                    _sourceClient = client;
                    _sourceInstance = instance;

                    // save settings file
                    SettingsHelper.SetSettings(_settings);

                    // render UI components
                    LogInfo($"Rendering UI components...");
                    RenderConnectionLabel(instance.FriendlyName);
                    //ReRenderComponents(true);

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

                    if (_sourceClient == null) { throw new Exception("Source connection is invalid"); }
                    LogInfo($"Source OrgId: {_sourceClient.ConnectedOrgId}");
                    LogInfo($"Source OrgUniqueName: {_sourceClient.ConnectedOrgUniqueName}");
                    LogInfo($"Source OrgFriendlyName: {_sourceClient.ConnectedOrgFriendlyName}");
                    LogInfo($"Source EnvId: {_sourceClient.EnvironmentId}");

                    if (client == null) { throw new Exception("Target connection is invalid"); }
                    LogInfo($"Target OrgId: {client.ConnectedOrgId}");
                    LogInfo($"Target OrgUniqueName: {client.ConnectedOrgUniqueName}");
                    LogInfo($"Target OrgFriendlyName: {client.ConnectedOrgFriendlyName}");
                    LogInfo($"Target EnvId: {client.EnvironmentId}");

                    if (_sourceClient.ConnectedOrgUniqueName.Equals(client.ConnectedOrgUniqueName))
                    {
                        throw new Exception("Source and Target connections must refer to different Dataverse instances");
                    }

                    var instance = _settings.Instances.FirstOrDefault(inst => !string.IsNullOrEmpty(inst.UniqueName) && inst.UniqueName.Equals(client.ConnectedOrgUniqueName));
                    if (instance == null)
                    {
                        instance = new Instance
                        {
                            Id = client.ConnectedOrgId,
                            UniqueName = client.ConnectedOrgUniqueName,
                            FriendlyName = client.ConnectedOrgFriendlyName
                    };

                        _settings.Instances.Add(instance);
                    }

                    _targetClient = client;
                    _targetInstance = instance;

                    SettingsHelper.SetSettings(_settings);

                    //ReRenderComponents(true);
                    RenderConnectionLabel(instance.FriendlyName);

                    _ready = true;
                    SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs("Target Connection ready"));
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
        // OK
        private void WhoAmI()
        {
            Service.Execute(new WhoAmIRequest());
        }

        private void LoadInitialData()
        {
            LogInfo($"Loading component types...");

            gbSolutions.Enabled = false;
            gbComponentTypes.Enabled = false;
            gbComponents.Enabled = false;
            gbChanges.Enabled = false;

            if (Service == null)
            {
                ExecuteMethod(WhoAmI);
                return;
            }

            if (_working) { return; }

            ManageWorkingState(true);

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading component types...",
                Work = (worker, args) =>
                {
                    var repo = new CrmRepo(Service, worker);
                    var metadata = repo.GetOptionSetMetadata("solutioncomponent", "componenttype");

                    args.Result = metadata.OptionSet.Options.Select(ct => new ComponentType
                    {
                        Label = ct.Label.UserLocalizedLabel.Label,
                        Value = ct.Value.Value
                    });
                },
                PostWorkCallBack = args =>
                {
                    if (args.Error != null)
                    {
                        throw new Exception(args.Error.Message);
                    }
                    else
                    {
                        _componentTypes = args.Result as IEnumerable<ComponentType>;
                        SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs("Component types load complete"));
                        ManageWorkingState(false);

                        LoadSolutions();
                    }
                }
            });
        }

        // OK
        private void LoadSolutions()
        {
            LogInfo($"Loading solutions...");

            gbComponentTypes.Enabled = false;
            gbComponents.Enabled = false;
            gbChanges.Enabled = false;

            if (_working) { return; }

            lvSolutions.Items.Clear();
            lvComponentTypes.Items.Clear();

            ManageWorkingState(true);

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading solutions...",
                Work = (worker, args) =>
                {
                    var repo = new CrmRepo(Service, worker);
                    var solutions = repo.GetManagedSolutions(new string[] { "uniquename", "friendlyname" });

                    args.Result = solutions.Select(sol => new Solution
                    {
                        SolutionId = sol.GetAttributeValue<Guid>("solutionid"),
                        LogicalName = sol.GetAttributeValue<string>("uniquename"),
                        DisplayName = sol.GetAttributeValue<string>("friendlyname")
                    }).OrderBy(sol => sol.DisplayName);
                },
                PostWorkCallBack = args =>
                {
                    if (args.Error != null)
                    {
                        throw new Exception(args.Error.Message);
                    }
                    else
                    {
                        // load solutions list
                        _solutions = args.Result as IEnumerable<Solution>;
                        LoadSolutionsList();

                        SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs("Solutions load complete"));
                    }
                }
            });
        }

        // OK
        private void LoadSolutionsList()
        {
            LogInfo($"Rendering solutions list view...");

            var textFilter = txtSolutionFilter.Text;
            var filtered = _solutions.Where(sol => string.IsNullOrWhiteSpace(textFilter) || sol.MatchFilter(textFilter));

            foreach (var sol in filtered)
            {
                var item = sol.ToListViewItem();
                lvSolutions.Items.Add(item);
            }

            gbSolutions.Enabled = true;
            ManageWorkingState(false);
        }

        private void LoadSolutionComponentTypes(Solution solution)
        {
            LogInfo($"Loading solution component types...");

            if (_working) { return; }

            lvComponentTypes.Items.Clear();
            cbCmpTypSelectAll.Checked = false;

            ManageWorkingState(true);

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading solution component types...",
                Work = (worker, args) =>
                {
                    var repo = new CrmRepo(Service, worker);

                    // get component types present in selected solution
                    var solutionId = solution.SolutionId;
                    var components = repo.GetSolutionComponents(new string[] { "solutionid", "objectid", "componenttype" }, solutionId);

                    args.Result = components.Select(sct => new SolutionComponent
                    {
                        Id = sct.GetAttributeValue<Guid>("solutioncomponentid"),
                        SolutionId = sct.GetAttributeValue<EntityReference>("solutionid").Id,
                        ObjectId = sct.GetAttributeValue<Guid>("objectid"),
                        Type = sct.GetAttributeValue<OptionSetValue>("componenttype").Value,
                        TypeName = _componentTypes.FirstOrDefault(ct => ct.Value.Equals(sct.GetAttributeValue<OptionSetValue>("componenttype").Value)).Label,
                        ActiveLayers = 0
                    }).OrderBy(sc => sc.TypeName);
                },
                PostWorkCallBack = args =>
                {
                    if (args.Error != null)
                    {
                        throw new Exception(args.Error.Message);
                    }
                    else
                    {
                        // load component types list (also load solution components for later use)
                        _solutionComponents = args.Result as IEnumerable<SolutionComponent>;

                        var groupByType = _solutionComponents.GroupBy(sc => sc.Type);

                        _solutionComponentTypes = groupByType.Select(sc => sc.First()).Select(sc => new ComponentType
                        {
                            Label = sc.TypeName,
                            Value = sc.Type,
                            ComponentCount = groupByType.Where(grp => grp.Key.Equals(sc.Type)).Select(grp => grp.Count()).First()
                        }).OrderBy(ct => ct.Label);

                        LoadSolutionComponentTypesList();

                        SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs("Solution component types load complete"));
                    }
                }
            });
        }

        // OK
        private void LoadSolutionComponentTypesList()
        {
            LogInfo($"Rendering solution component types list view...");

            foreach (var sct in _solutionComponentTypes)
            {
                var item = sct.ToListViewItem();
                lvComponentTypes.Items.Add(item);
            }

            gbComponentTypes.Enabled = true;
            ManageWorkingState(false);
        }
        #endregion Private Main Methods

        #region Private Helper Methods
        private void ManageWorkingState(bool working)
        {
            pnlMain.Enabled = !working;

            _working = working;
            Cursor = working ? Cursors.WaitCursor : Cursors.Default;
            tsbAbort.Text = "Abort";
            tsbAbort.Visible = working;
        }

        private void RenderConnectionLabel(string name)
        {
            lblSourceValue.Text = name;
            lblSourceValue.ForeColor = Color.MediumSeaGreen;
        }

        private void ReRenderComponents(bool enable)
        {
            var sourceReady = _sourceClient != null && _sourceClient.IsReady;
            var solutionSelected = lvSolutions.SelectedItems.Count > 0;

            if (sourceReady) // source connection is available
            {
                gbSolutions.Enabled = enable;

                if(solutionSelected) // source connection is available and table is selected
                {
                    gbComponentTypes.Enabled = true;
                }
            }
        }

        //private TableData GetSelectedSolutionItemData(bool targetRequired = true, bool attributeRequired = false)
        //{
        //    LogInfo($"Parsing solution data...");

        //    if (Service == null || (targetRequired && _targetClient == null))
        //    {
        //        throw new Exception("You must select both a source and a target organization");
        //    }
        //    if (targetRequired && !(cbCreate.Checked || cbUpdate.Checked || cbDelete.Checked))
        //    {
        //        throw new Exception("You must select at least one setting for transporting the data");
        //    }
        //    if (lvSolutions.SelectedItems.Count == 0)
        //    {
        //        throw new Exception("You must select a table first");
        //    }
        //    if (attributeRequired && lvAttributes.CheckedItems.Count == 0)
        //    {
        //        throw new Exception("At least one attribute must be selected");
        //    }

        //    var tableItem = lvTables.SelectedItems[0].ToObject(new Table()) as Table;
        //    if (tableItem == null || string.IsNullOrEmpty(tableItem.DisplayName) || string.IsNullOrEmpty(tableItem.LogicalName) || !_tables.Any(tbl => tbl.LogicalName.Equals(tableItem.LogicalName)))
        //    {
        //        throw new Exception("Invalid Table: Please reload tables and try again");
        //    }

        //    var table = _tables.FirstOrDefault(tbl => tbl.LogicalName.Equals(tableItem.LogicalName));

        //    var repo = new CrmRepo(Service);
        //    var metadata = repo.GetTableMetadata(table.LogicalName);

        //    var tableSettings = _settings.GetTableSettings(_tables, table.LogicalName);
        //    if (tableSettings == null)
        //    {
        //        throw new Exception("Invalid Table: Please reload tables and try again");
        //    }

        //    return new TableData { };
        //}
        #endregion Private Helper Methods

        #region Form events
        private void DataMigrationControl_Resize(object sender, EventArgs e)
        {
            //// re-render main panel
            //var firstColumn = pnlMain.ColumnStyles[0];
            //firstColumn.SizeType = SizeType.Absolute;
            //firstColumn.Width = 200;

            //// re-render settings panel
            //var settingsRows = pnlSettings.RowStyles;
            //settingsRows[0].SizeType = SizeType.Absolute;
            //settingsRows[0].Height = 115;
            //settingsRows[1].SizeType = SizeType.Absolute;
            //settingsRows[1].Height = 185;
            //settingsRows[2].SizeType = SizeType.Absolute;
            //settingsRows[2].Height = 129;
        }

        private void lvSolutions_Resize(object sender, EventArgs e)
        {
            // re-render list view columns
            var maxWidth = lvSolutions.Width >= 300 ? lvSolutions.Width : 300;
            chSolDisplayName.Width = (int)Math.Floor(maxWidth * 0.99);
        }

        private void lvComponentTypes_Resize(object sender, EventArgs e)
        {
            // re-render list view columns
            var maxWidth = lvComponentTypes.Width >= 500 ? lvComponentTypes.Width : 500;
            chCmpTypComponentName.Width = (int)Math.Floor(maxWidth * 0.49);
            chCmpTypActiveLayerCount.Width = (int)Math.Floor(maxWidth * 0.49);
        }

        private async void txtSolutionFilter_TextChanged(object sender, EventArgs e)
        {
            async Task<bool> UserKeepsTyping()
            {
                var txt = txtSolutionFilter.Text;
                await Task.Delay(500);

                return txt != txtSolutionFilter.Text;
            }

            if (await UserKeepsTyping()) return;

            // user is done typing -> execute logic
            try
            {
                lvSolutions.Items.Clear();
                ManageWorkingState(true);

                LoadSolutionsList();
            }
            catch (Exception ex)
            {
                ManageWorkingState(false);
                LogError(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                ManageWorkingState(false);
                txtSolutionFilter.Focus();
            }
        }

        private void lvSolutions_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (lvSolutions.SelectedItems.Count > 0)
                {
                    // get selected solution
                    var solutionItem = lvSolutions.SelectedItems[0].ToObject(new Solution()) as Solution;

                    // load component types
                    LoadSolutionComponentTypes(solutionItem);
                }
            }
            catch (Exception ex)
            {
                ManageWorkingState(false);
                LogError(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvSolutions_ColumnClick(object sender, ColumnClickEventArgs e)
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

        private void tsbRefreshSolutions_Click(object sender, EventArgs e)
        {
            try
            {
                LoadSolutions();
            }
            catch (Exception ex)
            {
                ManageWorkingState(false);
                LogError(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbAbort_Click(object sender, EventArgs e)
        {
            try
            {
                CancelWorker();
                tsbAbort.Text = "Aborting operation...";
            }
            catch (Exception ex)
            {
                ManageWorkingState(false);
                LogError(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbCmpTypSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                //if (lvComponentTypes.Items.Count == 0) { return; }

                //var allAttributes = (sender as CheckBox).Checked;

                //var tableData = GetSelectedSolutionItemData(false);
                //if (tableData == null)
                //{
                //    SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs("Error saving selected attributes"));
                //    return;
                //}

                //// check/uncheck all attributes
                //lvComponentTypes.Items.Cast<ListViewItem>().ToList().ForEach(item => item.Checked = allAttributes);

                //// save settings
                //if (allAttributes) { tableData.Settings.DeselectedAttributes.Clear(); }
                //else { tableData.Settings.DeselectedAttributes = tableData.Table.AllAttributes.Select(attr => attr.LogicalName).ToList(); }
            }
            catch (Exception ex)
            {
                ManageWorkingState(false);
                LogError(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void lvComponentTypes_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            try
            {
                //var listView = sender as ListView;
                //if (listView.FocusedItem != null && lvSolutions.SelectedItems.Count > 0)
                //{
                //    var tableData = GetSelectedSolutionItemData(false);
                //    if (tableData == null)
                //    {
                //        SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs("Error saving selected attributes"));
                //        return;
                //    }

                //    // save deselected attributes to settings
                //    var deselected = lvComponentTypes.Items.Cast<ListViewItem>().ToList().Where(lvi => !lvi.Checked).Select(lvi => lvi.SubItems[1].Text);

                //    tableData.Settings.DeselectedAttributes.Clear();
                //    tableData.Settings.DeselectedAttributes.AddRange(deselected);
                //}
            }
            catch (Exception ex)
            {
                ManageWorkingState(false);
                LogError(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion Form events
    }
}
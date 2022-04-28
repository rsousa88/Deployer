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
using Dataverse.XrmTools.ActiveLayerExplorer.Forms;

namespace Dataverse.XrmTools.ActiveLayerExplorer
{
    public partial class ActiveLayerExplorerControl : MultipleConnectionsPluginControlBase, IStatusBarMessenger
    {
        #region Variables
        // settings
        private Settings _settings;

        // service
        private CrmServiceClient _client;
        private CrmServiceClient _targetClient;

        // main objects
        private Instance _instance;

        // models
        private IEnumerable<Solution> _solutions;
        private IEnumerable<ComponentType> _componentTypes;
        private IEnumerable<ComponentType> _solutionComponentTypes;
        private IEnumerable<SolutionComponent> _solutionComponents;
        private IEnumerable<ActiveLayer> _activeLayers;

        // flags
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
            LogInfo($"Loading component types...");

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
                        Value = ct.Value.Value,
                        LogicalName = ct.Label.UserLocalizedLabel.Label.RemoveSpaces(),
                        DisplayName = ct.Label.UserLocalizedLabel.Label
                    });
                },
                PostWorkCallBack = args =>
                {
                    ManageWorkingState(false);

                    if (args.Error != null)
                    {
                        throw new Exception(args.Error.Message);
                    }
                    else
                    {
                        _componentTypes = args.Result as IEnumerable<ComponentType>;
                        SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs("Component types load complete"));

                        LoadSolutions();
                    }
                }
            });
        }

        private void LoadSolutions()
        {
            LogInfo($"Loading solutions...");

            gbComponentTypes.Enabled = false;
            gbLayers.Enabled = false;

            if (_working) { return; }
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
                    ManageWorkingState(false);

                    if (args.Error != null)
                    {
                        throw new Exception(args.Error.Message);
                    }
                    else
                    {
                        // load solutions list
                        _solutions = args.Result as IEnumerable<Solution>;
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
            lvComponentTypes.Items.Clear();

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Rendering solutions...",
                Work = (worker, args) =>
                {
                    var textFilter = txtSolutionFilter.Text;
                    var filtered = _solutions.Where(sol => string.IsNullOrWhiteSpace(textFilter) || sol.MatchFilter(textFilter));

                    args.Result = filtered.Select(sol => sol.ToListViewItem());
                },
                PostWorkCallBack = args =>
                {
                    ManageWorkingState(false);

                    if (args.Error != null)
                    {
                        throw new Exception(args.Error.Message);
                    }
                    else
                    {
                        var items = args.Result as IEnumerable<ListViewItem>;
                        lvSolutions.Items.AddRange(items.ToArray());

                        gbSolutions.Enabled = true;
                        SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs("Solutions load complete"));
                    }
                }
            });
        }

        private void LoadSolutionComponentTypes(Solution solution)
        {
            LogInfo($"Loading solution component types...");

            if (_working) { return; }
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

                    if (components != null)
                    {
                        args.Result = components
                            .Where(sct => _componentTypes.Any(ct => ct.Value.Equals(sct.GetAttributeValue<OptionSetValue>("componenttype").Value)))
                            .Select(sct => new SolutionComponent
                            {
                                Id = sct.GetAttributeValue<Guid>("solutioncomponentid"),
                                SolutionId = sct.GetAttributeValue<EntityReference>("solutionid").Id,
                                ObjectId = sct.GetAttributeValue<Guid>("objectid"),
                                Type = new ComponentType {
                                    Value = sct.GetAttributeValue<OptionSetValue>("componenttype").Value,
                                    LogicalName = _componentTypes.FirstOrDefault(ct => ct.Value.Equals(sct.GetAttributeValue<OptionSetValue>("componenttype").Value)).LogicalName,
                                    DisplayName = _componentTypes.FirstOrDefault(ct => ct.Value.Equals(sct.GetAttributeValue<OptionSetValue>("componenttype").Value)).DisplayName
                                },
                            })
                            .OrderBy(sc => sc.Type.DisplayName);
                    }
                },
                PostWorkCallBack = args =>
                {
                    ManageWorkingState(false);

                    if (args.Error != null)
                    {
                        throw new Exception(args.Error.Message);
                    }
                    else
                    {
                        // load component types list (also load solution components for later use)
                        _solutionComponents = args.Result as IEnumerable<SolutionComponent>;

                        var groupByType = _solutionComponents.GroupBy(sc => sc.Type.DisplayName);

                        _solutionComponentTypes = groupByType.Select(sc => sc.First()).Select(sc => new ComponentType
                        {
                            Value = sc.Type.Value,
                            LogicalName = sc.Type.LogicalName,
                            DisplayName = sc.Type.DisplayName,
                            ComponentCount = groupByType.Where(grp => grp.Key.Equals(sc.Type.DisplayName)).Select(grp => grp.Count()).First()
                        }).OrderBy(ct => ct.DisplayName);

                        LoadSolutionComponentTypesList(false);
                    }
                }
            });
        }

        private void LoadSolutionComponentTypesList(bool remember)
        {
            LogInfo($"Rendering solution component types list view...");

            if (_working) { return; }
            ManageWorkingState(true);

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Rendering solution component types...",
                Work = (worker, args) =>
                {
                    var @checked = lvComponentTypes.Items.Cast<ListViewItem>().ToList().Where(lvi => lvi.Checked);

                    lvComponentTypes.Items.Clear();

                    args.Result = _solutionComponentTypes.Select(sct =>
                    {
                        var item = sct.ToListViewItem();

                        if (remember) { item.Checked = @checked.Select(lvi => lvi.Tag).Contains(item.Tag); }

                        return item;
                    });
                },
                PostWorkCallBack = args =>
                {
                    ManageWorkingState(false);

                    if (args.Error != null)
                    {
                        throw new Exception(args.Error.Message);
                    }
                    else
                    {
                        var items = args.Result as IEnumerable<ListViewItem>;
                        lvComponentTypes.Items.AddRange(items.ToArray());


                        gbComponentTypes.Enabled = true;
                        SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs("Solution component types load complete"));
                    }
                }
            });
        }

        private void LoadActiveLayers(IEnumerable<Solution> solution, IEnumerable<ComponentType> types)
        {
            LogInfo($"Loading active layers...");

            if (_working) { return; }

            lvLayers.Items.Clear();

            ManageWorkingState(true);

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading active layers...",
                Work = (worker, args) =>
                {
                    var components = _solutionComponents.Where(sc => types.Select(typ => typ.Value).Contains(sc.Type.Value));

                    var repo = new CrmRepo(Service, worker);
                    _activeLayers = repo.GetActiveLayers(new string[] { "msdyn_name" }, components);

                    args.Result = _activeLayers.GroupBy(al => al.SolutionComponent.Type.Value);
                },
                PostWorkCallBack = args =>
                {
                    if (args.Error != null)
                    {
                        throw new Exception(args.Error.Message);
                    }
                    else
                    {
                        // group layers by solution component type
                        var groups = args.Result as IEnumerable<IGrouping<int, ActiveLayer>>;

                        _solutionComponentTypes = _solutionComponentTypes
                            .Select(sct =>
                            {
                                var typeGrp = groups.FirstOrDefault(grp => grp.Key.Equals(sct.Value));
                                if (typeGrp != null) { sct.LayersCount = typeGrp.Count(); }
                                else { sct.LayersCount = null; }

                                return sct;
                            });

                        // re-render component types list (with active layer count)
                        LoadSolutionComponentTypesList(true);
                        LoadActiveLayersList();

                        SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs("Active layers load complete"));
                        ManageWorkingState(false);
                    }
                }
            });
        }

        private void LoadActiveLayersList()
        {
            LogInfo($"Rendering solution component types list view...");

            foreach (var al in _activeLayers)
            {
                var item = al.ToListViewItem();
                lvLayers.Items.Add(item);
            }

            gbLayers.Enabled = true;
            ManageWorkingState(false);
        }

        private void RemoveActiveLayers(IEnumerable<ActiveLayer> layers)
        {
            LogInfo($"Removing active layers...");

            if (_working) { return; }

            ManageWorkingState(true);

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Removing active layers...",
                Work = (worker, args) =>
                {
                    var repo = new CrmRepo(Service, worker);
                    var responses = repo.DeleteLayers(layers);

                    args.Result = responses.Select(resp => new OperationResult
                    {
                        ComponentId = (Guid)resp.Request.Parameters["ComponentId"],
                        ComponentName = resp.Request.Parameters["SolutionComponentName"].ToString(),
                        Description = resp.Success ? "Ok" : resp.Message
                    }.ToListViewItem());
                },
                PostWorkCallBack = args =>
                {
                    if (args.Error != null)
                    {
                        throw new Exception(args.Error.Message);
                    }
                    else
                    {
                        // show preview form
                        var items = args.Result as IEnumerable<ListViewItem>;

                        var resDialog = new Results(items, _settings);
                        resDialog.ShowDialog(ParentForm);

                        SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs("Active layers removal operation complete"));
                        ManageWorkingState(false);
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
            tsbAbort.Text = "Abort";
            tsbAbort.Visible = working;
        }

        private void RenderInitialComponents(string connectionName)
        {
            lblSourceValue.Text = connectionName;
            lblSourceValue.ForeColor = Color.MediumSeaGreen;

            cbCmpTypSelectAll.Checked = false;
            cbLayersSelectAll.Checked = false;

            gbSolutions.Enabled = false;
            gbComponentTypes.Enabled = false;
            gbLayers.Enabled = false;
        }
        #endregion Private Helper Methods

        #region Form events
        private void lvSolutions_Resize(object sender, EventArgs e)
        {
            var maxWidth = lvSolutions.Width >= 300 ? lvSolutions.Width : 300;
            chSolDisplayName.Width = (int)Math.Floor(maxWidth * 0.99);
        }

        private void lvComponentTypes_Resize(object sender, EventArgs e)
        {
            var maxWidth = lvComponentTypes.Width >= 500 ? lvComponentTypes.Width : 500;
            chCmpTypComponentName.Width = (int)Math.Floor(maxWidth * 0.49);
            chCmpTypComponentCount.Width = (int)Math.Floor(maxWidth * 0.2);
            chCmpTypActiveLayerCount.Width = (int)Math.Floor(maxWidth * 0.3);
        }

        private void lvLayers_Resize(object sender, EventArgs e)
        {
            var maxWidth = lvLayers.Width >= 750 ? lvLayers.Width : 750;
            chLayDisplayName.Width = (int)Math.Floor(maxWidth * 0.39);
            chLayObjectId.Width = (int)Math.Floor(maxWidth * 0.4);
            chLayType.Width = (int)Math.Floor(maxWidth * 0.2);
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
                LoadSolutionsList();
            }
            catch (Exception ex)
            {
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

        private void tsbLoadSolutions_Click(object sender, EventArgs e)
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
                if (lvComponentTypes.Items.Count == 0) { return; }

                var allTypes = (sender as CheckBox).Checked;

                // check/uncheck all component types
                lvComponentTypes.Items.Cast<ListViewItem>().ToList().ForEach(item => item.Checked = allTypes);
            }
            catch (Exception ex)
            {
                ManageWorkingState(false);
                LogError(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbLayersSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (lvLayers.Items.Count == 0) { return; }

                var allLayers = (sender as CheckBox).Checked;

                // check/uncheck all layers
                lvLayers.Items.Cast<ListViewItem>().ToList().ForEach(item => item.Checked = allLayers);
            }
            catch (Exception ex)
            {
                ManageWorkingState(false);
                LogError(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbLoadLayers_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvSolutions.SelectedItems.Count.Equals(1) && lvComponentTypes.CheckedItems.Count > 0)
                {
                    var selectedSolution = lvSolutions.Items.Cast<ListViewItem>().ToList().Where(lvi => lvi.Selected)
                        .Select(lvi => _solutions.FirstOrDefault(sol => sol.SolutionId.Equals((Guid)lvi.Tag))).ToList();

                    var selectedTypes = lvComponentTypes.Items.Cast<ListViewItem>().ToList().Where(lvi => lvi.Checked)
                        .Select(lvi => _componentTypes.FirstOrDefault(ct => ct.Value.Equals((int)lvi.Tag))).ToList();

                    LoadActiveLayers(selectedSolution, selectedTypes);
                }
            }
            catch (Exception ex)
            {
                ManageWorkingState(false);
                LogError(ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void tsbRemoveLayers_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvLayers.CheckedItems.Count > 0)
                {
                    var selectedLayers = lvLayers.Items.Cast<ListViewItem>().ToList().Where(lvi => lvi.Checked)
                        .Select(lvi => _activeLayers.FirstOrDefault(al => al.Id.Equals((Guid)lvi.Tag))).ToList();

                    RemoveActiveLayers(selectedLayers);
                }
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
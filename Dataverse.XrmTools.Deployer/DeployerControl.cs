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

            txtSolutionFilter.Text = _settings.Filter;
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
            lvComponents.Items.Clear();

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Rendering solutions...",
                Work = (worker, args) =>
                {
                    var textFilter = txtSolutionFilter.Text;
                    var filtered = _solutions.Where(sol => string.IsNullOrWhiteSpace(textFilter) || sol.MatchFilter(textFilter));

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

        private void LoadSolutionComponents(Solution solution)
        {
            LogInfo($"Loading solution components...");

            if (_working) { return; }
            ManageWorkingState(true);

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading solution components...",
                Work = (worker, args) =>
                {
                    var repo = new CrmRepo(Service, _batchSize, worker);

                    // get solution components from selected solution
                    _solutionComponents = new List<SolutionComponent>();
                    var solutionId = solution.SolutionId;
                    var components = repo.GetSolutionComponents(new string[] { "solutionid", "objectid", "componenttype" }, solutionId);
                    foreach (var component in components)
                    {
                        var type = component.GetAttributeValue<OptionSetValue>("componenttype").Value;
                        var typeFromList = _componentsList.FirstOrDefault(ct => ct.Value.Equals(type));
                        if (typeFromList != null)
                        {
                            var solutionComponent = new SolutionComponent
                            {
                                Id = component.GetAttributeValue<Guid>("solutioncomponentid"),
                                SolutionId = component.GetAttributeValue<EntityReference>("solutionid").Id,
                                ObjectId = component.GetAttributeValue<Guid>("objectid"),
                                Type = new ComponentType
                                {
                                    Value = type,
                                    LogicalName = typeFromList.LogicalName,
                                    DisplayName = typeFromList.DisplayName
                                },
                            };

                            _solutionComponents.Add(solutionComponent);
                        }
                    }

                    _solutionComponents.OrderBy(sc => sc.Type.DisplayName).Select(sct => sct.ToListViewItem());

                    // get solution component types with component count
                    _solutionComponentTypes = new List<ComponentType>();
                    var groups = _solutionComponents.GroupBy(sc => sc.Type.DisplayName);
                    foreach (var group in groups)
                    {
                        var first = group.First(); // get first item from group

                        var component = new ComponentType
                        {
                            Value = first.Type.Value,
                            LogicalName = first.Type.LogicalName,
                            DisplayName = first.Type.DisplayName,
                            ComponentCount = group.Count()
                        };

                        _solutionComponentTypes.Add(component);
                    }

                    args.Result = _solutionComponentTypes.OrderBy(ct => ct.DisplayName).Select(sct => sct.ToListViewItem());
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
                        var items = args.Result as IEnumerable<ListViewItem>;
                        LoadSolutionComponentsList(new Tuple<IEnumerable<ListViewItem>, IEnumerable<ListViewItem>>(items, null), false);
                    }
                }
            });
        }

        private void LoadSolutionComponentsList(Tuple<IEnumerable<ListViewItem>, IEnumerable<ListViewItem>> items, bool remember)
        {
            LogInfo($"Rendering solution component types list view...");

            if (_working) { return; }
            ManageWorkingState(true);

            var @checked = lvComponents.Items.Cast<ListViewItem>().ToList().Where(lvi => lvi.Checked);
            lvComponents.Items.Clear();

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Rendering solution component types...",
                Work = (worker, args) =>
                {
                    var types = items.Item1.Select(lvi =>
                    {
                        if (remember) { lvi.Checked = @checked.Select(ini => ini.Tag).Contains(lvi.Tag); }
                        return lvi;
                    });

                    args.Result = types.ToArray();
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
                        var updated = args.Result as ListViewItem[];
                        lvComponents.Items.AddRange(updated);

                        gbComponents.Enabled = true;
                        SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs("Solution component types load complete"));

                        if(items.Item2 != null)
                        {
                            LoadActiveLayersList(items.Item2);
                            LoadTypesFilter(items.Item2);
                        }
                    }
                }
            });
        }

        private void LoadTypesFilter(IEnumerable<ListViewItem> items)
        {
            var cbItems = new List<ComboboxItem>
            {
                new ComboboxItem { Text = "All", Value = 0 }
            };

            cbItems.AddRange(_activeLayers.Select(lay => new ComboboxItem { Text = lay.SolutionComponent.Type.DisplayName, Value = lay.SolutionComponent.Type.Value }));

            var boxOptions = cbItems.GroupBy(bo => bo.Value).Select(grp => grp.First()).ToArray();
            cbFilterLayers.Items.AddRange(boxOptions);
            cbFilterLayers.SelectedIndex = 0;
        }

        private void LoadActiveLayers(IEnumerable<ComponentType> types)
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

                    var repo = new CrmRepo(Service, _batchSize, worker);
                    _activeLayers = repo.GetActiveLayers(new string[] { "msdyn_name" }, components);

                    var groups = _activeLayers.GroupBy(al => al.SolutionComponent.Type.Value);

                    foreach (var sct in _solutionComponentTypes)
                    {
                        var typeGrp = groups.FirstOrDefault(grp => grp.Key.Equals(sct.Value));
                        if (typeGrp != null) { sct.LayersCount = typeGrp.Count(); }
                        else { sct.LayersCount = 0; }
                    }

                    // re-render component types list (with active layer count)
                    var componentItems = _solutionComponentTypes.OrderBy(ct => ct.DisplayName).Select(sct => sct.ToListViewItem());
                    var layerItems = _activeLayers.Select(sct => sct.ToListViewItem());
                    args.Result = new Tuple<IEnumerable<ListViewItem>, IEnumerable<ListViewItem>>(componentItems, layerItems);
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
                        var items = args.Result as Tuple<IEnumerable<ListViewItem>, IEnumerable<ListViewItem>>;
                        LoadSolutionComponentsList(items, true);
                    }
                }
            });
        }

        private void LoadActiveLayersList(IEnumerable<ListViewItem> layers)
        {
            LogInfo($"Rendering active layers list view...");

            if (_working) { return; }
            ManageWorkingState(true);

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Rendering active layers...",
                Work = (worker, args) =>
                {
                    args.Result = layers.ToArray();
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
                        lvLayers.Items.AddRange(items);

                        gbLayers.Enabled = true;
                        SendMessageToStatusBar?.Invoke(this, new StatusBarMessageEventArgs("Active layers load complete"));
                    }
                }
            });
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
                    var repo = new CrmRepo(Service, _batchSize, worker);
                    var responses = repo.DeleteLayers(layers);

                    args.Result = responses.Select(resp => new OperationResult
                    {
                        ComponentId = (Guid)resp.Request.Parameters["ComponentId"],
                        ComponentName = resp.Request.Parameters["SolutionComponentName"].ToString(),
                        Description = resp.Success ? "Ok" : resp.Message
                    }.ToListViewItem()).ToArray();
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
                        // show preview form
                        var items = args.Result as ListViewItem[];

                        var resDialog = new Results(items, _settings);
                        resDialog.FormClosed += new FormClosedEventHandler(Results_FormClosed);
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
        }

        private void RenderInitialComponents(string connectionName)
        {
            lblSourceValue.Text = connectionName;
            lblSourceValue.ForeColor = Color.MediumSeaGreen;

            cbCmpSelectAll.Checked = false;
            cbLayersSelectAll.Checked = false;

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

        private void lvComponentTypes_Resize(object sender, EventArgs e)
        {
            var maxWidth = lvComponents.Width >= 500 ? lvComponents.Width : 500;
            chCmpComponentName.Width = (int)Math.Floor(maxWidth * 0.49);
            chCmpComponentCount.Width = (int)Math.Floor(maxWidth * 0.2);
            chCmpActiveLayerCount.Width = (int)Math.Floor(maxWidth * 0.3);
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
                _settings.Filter = txtSolutionFilter.Text;
                SettingsHelper.SetSettings(_settings);

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

                    lvComponents.Items.Clear();
                    cbCmpSelectAll.Checked = false;
                    lvLayers.Items.Clear();

                    // load component types
                    LoadSolutionComponents(solutionItem);
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

        private void cbCmpTypSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (lvComponents.Items.Count == 0) { return; }

                var allTypes = (sender as CheckBox).Checked;

                // check/uncheck all component types
                lvComponents.Items.Cast<ListViewItem>().ToList().ForEach(item => item.Checked = allTypes);
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
                if (lvSolutions.SelectedItems.Count.Equals(1) && lvComponents.CheckedItems.Count > 0)
                {
                    var selectedTypes = lvComponents.Items.Cast<ListViewItem>().ToList().Where(lvi => lvi.Checked)
                        .Select(lvi => _componentsList.FirstOrDefault(ct => ct.Value.Equals((int)lvi.Tag))).ToList();

                    LoadActiveLayers(selectedTypes);
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

        private void Results_FormClosed(object sender, FormClosedEventArgs e)
        {
            cbFilterLayers.SelectedItem = null;
            cbFilterLayers.Items.Clear();

            cbLayersSelectAll.Checked = false;
            lvLayers.Items.Clear();
            gbLayers.Enabled = false;

            cbCmpSelectAll.Checked = false;
            lvComponents.Items.Clear();
            gbComponents.Enabled = false;

            // get selected solution
            var solutionItem = lvSolutions.SelectedItems[0].ToObject(new Solution()) as Solution;

            // load component types
            LoadSolutionComponents(solutionItem);
        }

        private void cbFilterLayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            lvLayers.Items.Clear();

            var filter = (sender as ComboBox).SelectedItem as ComboboxItem;
            if(filter != null)
            {
                var layers = filter.Value.Equals(0) ? _activeLayers : _activeLayers.Where(lay => lay.SolutionComponent.Type.Value.Equals(filter.Value));
                var layerItems = layers.Select(sct => sct.ToListViewItem());

                LoadActiveLayersList(layerItems);
            }
        }
        #endregion Form events
    }
}
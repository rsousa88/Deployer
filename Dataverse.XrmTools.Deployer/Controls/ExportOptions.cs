// System
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

// Dataverse
using Dataverse.XrmTools.Deployer.Enums;
using Dataverse.XrmTools.Deployer.Models;
using Dataverse.XrmTools.Deployer.Helpers;
using Dataverse.XrmTools.Deployer.AppSettings;

namespace Dataverse.XrmTools.Deployer.Controls
{
    public partial class ExportOptions : UserControl
    {
        private readonly Logger _logger;
        public event SolutionsRetrieve OnSolutionsRetrieveRequested;
        public event EventHandler<Operation> OnOperationSelected;
        public event EventHandler<Operation> OnOperationRemoved;

        private IEnumerable<Solution> _solutions;
        private Settings _settings;
        private ExportOperation _export;
        private UpdateOperation _update;
        private UnpackOperation _unpack;
        private PackOperation _pack;

        public ExportOptions(Logger logger, Settings settings)
        {
            _logger = logger;
            _settings = settings;

            InitializeComponent();

            gbSolutions.Enabled = false;
            gbExportSettings.Enabled = false;
            gbQuickActions.Enabled = false;
            gbSolutionInfo.Enabled = false;

            if(!string.IsNullOrEmpty(_settings.Defaults.ExportPath))
            {
                txtSolutionPathValue.Text = _settings.Defaults.ExportPath;
                txtSolutionPathValue.Select(txtSolutionPathValue.Text.Length, 0);
            }
        }

        private void LoadSolutionsList()
        {
            lvSolutions.Items.Clear();

            var textFilter = txtSolutionFilter.Text;
            var filtered = _solutions.Where(sol => string.IsNullOrWhiteSpace(textFilter) || sol.MatchFilter(textFilter));

            var items = filtered.Select(sol => sol.ToListViewItem()).ToArray();

            lvSolutions.Items.AddRange(items);

            gbSolutions.Enabled = true;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _solutions = OnSolutionsRetrieveRequested?.Invoke(PackageType.UNMANAGED, ConnectionType.SOURCE);
            LoadSolutionsList();
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
                _logger.Log(LogLevel.ERROR, ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                txtSolutionFilter.Focus();
            }
        }

        private void lvSolutions_Resize(object sender, EventArgs e)
        {
            var maxWidth = lvSolutions.Width >= 548 ? lvSolutions.Width : 548;
            chSolDisplayName.Width = (int)Math.Floor(maxWidth * 0.39);
            chSolVersion.Width = (int)Math.Floor(maxWidth * 0.19);
            chSolManaged.Width = (int)Math.Floor(maxWidth * 0.19);
            chSolPublisher.Width = (int)Math.Floor(maxWidth * 0.19);
        }

        private void lvSolutions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSolutions.SelectedItems.Count > 0)
            {
                var solution = lvSolutions.SelectedItems[0].ToObject(new Solution()) as Solution;
                var type = rbManaged.Checked ? PackageType.MANAGED : PackageType.UNMANAGED;

                var suffix = type.Equals(PackageType.MANAGED) ? "_managed.zip" : ".zip";
                var name = $"{solution.LogicalName}_{solution.Version}{suffix}";

                solution.Package = new Package
                {
                    Type = type,
                    Name = name,
                    Path = $"{txtSolutionPathValue.Text}\\{name}"
                };

                lblSolutionIdValue.Text = solution.SolutionId.ToString();
                lblLogicalNameValue.Text = solution.LogicalName;
                lblDisplayNameValue.Text = solution.DisplayName;
                lblVersionValue.Text = solution.Version;
                lblManagedValue.Text = solution.IsManaged ? "Yes" : "No";
                lblPublisherValue.Text = solution.Publisher.DisplayName;

                _export = new ExportOperation
                {
                    OperationType = OperationType.EXPORT,
                    Solution = solution
                };

                OnOperationSelected?.Invoke(this, _export);

                gbExportSettings.Enabled = true;
                gbQuickActions.Enabled = true;
                gbSolutionInfo.Enabled = true;
            }
        }

        private void btnSetSolutionLocation_Click(object sender, EventArgs e)
        {
            try
            {
                var dirPath = Handle.SelectDirectory(_settings.Defaults.ExportPath);
                if (string.IsNullOrEmpty(dirPath)){ return; }

                txtSolutionPathValue.Text = dirPath;
                txtSolutionPathValue.Select(txtSolutionPathValue.Text.Length, 0);

                _settings.Defaults.ExportPath = dirPath;
                _settings.SaveSettings();

                var suffix = _export.Solution.Package.Type.Equals(PackageType.MANAGED) ? "_managed.zip" : ".zip";
                var name = $"{_export.Solution.LogicalName}_{_export.Solution.Version}{suffix}";

                _export.Solution.Package.Name = name;
                _export.Solution.Package.Path = $"{dirPath}\\{name}";
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.ERROR, ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbPackageType_CheckedChanged(object sender, EventArgs e)
        {
            var type = rbManaged.Checked ? PackageType.MANAGED : PackageType.UNMANAGED;
            var suffix = type.Equals(PackageType.MANAGED) ? "_managed.zip" : ".zip";

            _export.Solution.Package.Type = type;
            _export.Solution.Package.Name = $"{_export.Solution.LogicalName}_{_export.Solution.Version}{suffix}";

            if(_unpack != null) { _unpack.PackageType = type.Equals(PackageType.MANAGED) ? "Managed" : "Unmanaged"; }
            if(_pack != null) { _pack.PackageType = type.Equals(PackageType.MANAGED) ? "Managed" : "Unmanaged"; }
        }

        private void chbUpdateVersion_CheckedChanged(object sender, EventArgs e)
        {
            txtQuickUpdateVersion.Enabled = chbUpdateVersion.Checked;

            if (chbUpdateVersion.Checked)
            {
                var version = !string.IsNullOrEmpty(_settings.Defaults.Version) ? new Version(_settings.Defaults.Version) : new Version(_export.Solution.Version).IncrementRevision();

                txtQuickUpdateVersion.Text = version.ToString();
                _export.Solution.Version = version.ToString();

                _settings.Defaults.Version = version.ToString();
                _settings.SaveSettings();

                var solution = lvSolutions.SelectedItems[0].ToObject(new Solution()) as Solution;

                _update = new UpdateOperation
                {
                    OperationType = OperationType.UPDATE,
                    Solution = solution
                };

                _export.QuickUpdateId = _update.OperationId;

                OnOperationSelected?.Invoke(this, _update);
            }
            else
            {
                if (_update != null) { OnOperationRemoved?.Invoke(this, _update); }
                _export.QuickUpdateId = Guid.Empty;
            }
        }

        private async void txtQuickUpdateVersion_TextChanged(object sender, EventArgs e)
        {
            var box = sender as TextBox;
            async Task<bool> UserKeepsTyping()
            {
                var txt = box.Text;
                await Task.Delay(250);

                return txt != box.Text;
            }

            if (await UserKeepsTyping()) return;

            try
            {
                var isValid = Version.TryParse(txtQuickUpdateVersion.Text, out Version version);
                if (isValid)
                {
                    _export.Solution.Version = version.ToString();

                    _settings.Defaults.Version = version.ToString();
                    _settings.SaveSettings();

                    _update.Solution.Version = version.ToString();
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.ERROR, ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                box.Focus();
            }
        }

        private void chbUnpack_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if(chbUnpack.Checked)
                {
                    var dirPath = string.IsNullOrEmpty(_settings.Defaults.UnpackPath) ? Handle.SelectDirectory(_settings.Defaults.UnpackPath) : _settings.Defaults.UnpackPath;
                    if (string.IsNullOrEmpty(dirPath))
                    {
                        chbUnpack.Checked = false;
                        return;
                    }

                    txtUnpackPathValue.Text = dirPath;
                    txtUnpackPathValue.Select(txtUnpackPathValue.Text.Length, 0);

                    if (_export is null) { throw new Exception($"An Export operation is required for the Unpack quick action"); }

                    _settings.Defaults.UnpackPath = dirPath;
                    _settings.SaveSettings();

                    _unpack = new UnpackOperation
                    {
                        OperationType = OperationType.UNPACK,
                        Solution = _export.Solution,
                        Action = "Extract",
                        WorkingDir = _settings.WorkingDirectory,
                        Packager = _settings.PackagerPath,
                        Folder = dirPath,
                        PackageType = _export.Solution.Package.Type.Equals(PackageType.MANAGED) ? "Managed" : "Unmanaged",
                        ZipFile = _export.Solution.Package.Path,
                        Map = string.Empty
                    };

                    OnOperationSelected?.Invoke(this, _unpack);

                    _export.QuickUnpackId = _unpack.OperationId;
                    chbPack.Enabled = true;
                }
                else
                {
                    if (_unpack != null) { OnOperationRemoved?.Invoke(this, _unpack); }

                    _export.QuickUnpackId = Guid.Empty;

                    chbPack.Checked = false;
                    chbPack.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.ERROR, ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void chbPack_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (chbPack.Checked)
                {
                    var dirPath = string.IsNullOrEmpty(_settings.Defaults.PackPath) ? Handle.SelectDirectory(_settings.Defaults.PackPath) : _settings.Defaults.PackPath;
                    if (string.IsNullOrEmpty(dirPath))
                    {
                        chbPack.Checked = false;
                        return;
                    }

                    txtPackPathValue.Text = dirPath;
                    txtPackPathValue.Select(txtPackPathValue.Text.Length, 0);

                    if (_export is null) { throw new Exception($"An Unpack operation is required for the Pack quick action"); }

                    _settings.Defaults.PackPath = dirPath;
                    _settings.SaveSettings();

                    _pack = new PackOperation
                    {
                        OperationType = OperationType.PACK,
                        Solution = _unpack.Solution,
                        Action = "Pack",
                        WorkingDir = _unpack.WorkingDir,
                        Packager = _settings.PackagerPath,
                        PackageType = _unpack.PackageType,
                        ZipFile = $"{dirPath}\\{_unpack.Solution.Package.Name}",
                        Folder = _unpack.Folder,
                        Map = string.Empty
                    };

                    OnOperationSelected?.Invoke(this, _pack);

                    _export.QuickPackId = _pack.OperationId;
                }
                else
                {
                    if (_pack != null) { OnOperationRemoved?.Invoke(this, _pack); }
                    _export.QuickPackId = Guid.Empty;
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.ERROR, ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

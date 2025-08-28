using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dataverse.XrmTools.Deployer.Enums;
using Dataverse.XrmTools.Deployer.Helpers;
using Dataverse.XrmTools.Deployer.Models;
using Newtonsoft.Json.Linq;

namespace Dataverse.XrmTools.Deployer.Controls
{
    public partial class ExportControl : UserControl
    {
        private readonly Logger _logger;
        private IEnumerable<Solution> _solutions;
        private Workspace _workspace;
        private bool _targetConnected;

        private string _version;
        private IList<ExportOperation> _exports;

        // events
        public event EventHandler<IEnumerable<ExportOperation>> OnAddToQueue_Export;

        public ExportControl(Logger logger, IEnumerable<Solution> solutions, Workspace workspace, bool targetConnected)
        {
            _logger = logger;
            _solutions = solutions;
            _workspace = workspace;
            _targetConnected = targetConnected;

            Dock = DockStyle.Fill;
            InitializeComponent();

            LoadSolutionsList();

            txtUpdateVersion.Text = _workspace.Version;

            gbExportOptions.Enabled = false;
            gbUpdateOptions.Enabled = false;
            gbPackagerOptions.Enabled = false;
            btnAddToQueue.Enabled = false;
        }

        private void LoadSolutionsList()
        {
            lvSolutions.Items.Clear();

            var textFilter = txtSolutionFilter.Text;
            var filtered = _solutions.Where(sol => string.IsNullOrWhiteSpace(textFilter) || sol.MatchFilter(textFilter));

            var items = filtered.Select(sol => sol.ToListViewItem()).ToArray();

            lvSolutions.Items.AddRange(items);
        }

        // Event Handlers
        private void lvSolutions_Resize(object sender, EventArgs e)
        {
            var maxWidth = lvSolutions.Width >= 625 ? lvSolutions.Width : 625;
            chSolDisplayName.Width = (int)Math.Floor(maxWidth * 0.40);
            chSolVersion.Width = (int)Math.Floor(maxWidth * 0.15);
            chSolManaged.Width = (int)Math.Floor(maxWidth * 0.15);
            chSolPublisher.Width = (int)Math.Floor(maxWidth * 0.25);
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

        private void lvSolutions_SelectedIndexChanged(object sender, EventArgs e)
        {
            _exports = new List<ExportOperation>();

            if (lvSolutions.SelectedItems.Count.Equals(0)) { return; }

            foreach (var item in lvSolutions.SelectedItems)
            {
                var solution = (item as ListViewItem).ToObject(new Solution()) as Solution;

                var type = rbManaged.Checked ? PackageType.MANAGED : PackageType.UNMANAGED;
                var suffix = type.Equals(PackageType.MANAGED) ? "_managed.zip" : ".zip";
                var packageName = $"{solution.LogicalName}_{_version}{suffix}";

                var projectDir = Path.Combine(_workspace.RootPath, _workspace.ProjectDisplayName);
                var solutionDir = Path.Combine(projectDir, solution.DisplayName);
                var exportDir = Path.Combine(solutionDir, "backup");

                var export = new ExportOperation
                {
                    OperationType = OperationType.EXPORT,
                    PackageType = type,
                    PackageName = packageName,
                    PackagePath = Path.Combine(exportDir, packageName),
                    UpdateVersion = cbUpdate.Checked,
                    Version = _version,
                    Unpack = cbUnpack.Checked,
                    Pack = cbPack.Checked,
                    Solution = new Solution
                    {
                        SolutionId = solution.SolutionId,
                        DisplayName = solution.DisplayName,
                        LogicalName = solution.LogicalName,
                        Publisher = solution.Publisher
                    }
                };

                _exports.Add(export);
            }

            gbExportOptions.Enabled = true;
            gbUpdateOptions.Enabled = true;
            gbPackagerOptions.Enabled = true;
            btnAddToQueue.Enabled = true;
        }

        private void rbPackageType_CheckedChanged(object sender, EventArgs e)
        {
            if (_exports != null && _exports.Count > 0)
            {
                var type = rbManaged.Checked ? PackageType.MANAGED : PackageType.UNMANAGED;
                var suffix = type.Equals(PackageType.MANAGED) ? "_managed.zip" : ".zip";

                foreach (var export in _exports)
                {
                    export.PackageType = type;
                    export.PackageName = $"{export.Solution.LogicalName}_{_version}{suffix}";

                    var pathArr = export.PackagePath.Split('\\');
                    pathArr[pathArr.Length -1] = export.PackageName;
                    export.PackagePath = string.Join("\\", pathArr);
                }
            }
        }

        private void cbUpdate_CheckedChanged(object sender, EventArgs e)
        {
            txtUpdateVersion.Enabled = cbUpdate.Checked;

            if (_exports != null && _exports.Count > 0)
            {
                foreach (var export in _exports)
                {
                    export.UpdateVersion = cbUpdate.Checked;
                }
            }
        }

        private async void txtUpdateVersion_TextChanged(object sender, EventArgs e)
        {
            var box = sender as TextBox;
            async Task<bool> UserKeepsTyping()
            {
                var txt = box.Text;
                await Task.Delay(250);

                return txt != box.Text;
            }

            if (await UserKeepsTyping()) return;

            var isValid = Version.TryParse(box.Text, out Version version);
            if (isValid)
            {
                _version = version.ToString();

                if(_exports != null && _exports.Count > 0)
                {
                    var type = rbManaged.Checked ? PackageType.MANAGED : PackageType.UNMANAGED;
                    var suffix = type.Equals(PackageType.MANAGED) ? "_managed.zip" : ".zip";

                    var projectDir = Path.Combine(_workspace.RootPath, _workspace.ProjectDisplayName);

                    foreach (var export in _exports)
                    {
                        export.Version = _version;
                        export.PackageName = $"{export.Solution.LogicalName}_{_version}{suffix}";

                        var solutionDir = Path.Combine(projectDir, export.Solution.DisplayName);
                        var exportDir = Path.Combine(solutionDir, "backup");
                        export.PackagePath = Path.Combine(exportDir, export.PackageName);
                    }
                }
            }

            box.Focus();
        }

        private void cbUnpack_CheckedChanged(object sender, EventArgs e)
        {
            cbPack.Enabled = cbUnpack.Checked;
            cbPack.Checked = !cbPack.Enabled ? false : cbPack.Checked;

            if (_exports != null && _exports.Count > 0)
            {
                foreach (var export in _exports)
                {
                    export.Unpack = cbUnpack.Checked;
                }
            }
        }

        private void cbPack_CheckedChanged(object sender, EventArgs e)
        {
            if (_exports != null && _exports.Count > 0)
            {
                foreach (var export in _exports)
                {
                    export.Pack = cbPack.Checked;
                }
            }
        }

        private void btnAddToQueue_Click(object sender, EventArgs e)
        {
            OnAddToQueue_Export?.Invoke(this, _exports);
        }
    }
}

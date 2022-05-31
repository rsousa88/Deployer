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
        public event EventHandler<Operation> OnOperationUpdated;

        private IEnumerable<Solution> _solutions;
        private Settings _settings;
        private ExportOperation _export;

        public ExportOptions(Logger logger, Settings settings)
        {
            _logger = logger;
            _settings = settings;

            InitializeComponent();

            gbSolutions.Enabled = false;
            gbExportSettings.Enabled = false;
            gbSolutionInfo.Enabled = false;

            if(!string.IsNullOrEmpty(_settings.ExportPath)) { txtSolutionPathValue.Text = _settings.ExportPath; }
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

                solution.Package = new Package
                {
                    Type = type,
                    Name = $"{solution.LogicalName}_{solution.Version}{suffix}",
                    ExportPath = txtSolutionPathValue.Text
                };

                lblSolutionIdValue.Text = solution.SolutionId.ToString();
                lblLogicalNameValue.Text = solution.LogicalName;
                lblDisplayNameValue.Text = solution.DisplayName;
                lblVersionValue.Text = solution.Version;
                lblManagedValue.Text = solution.IsManaged.ToString();
                lblPublisherValue.Text = solution.Publisher.DisplayName;

                _export = new ExportOperation
                {
                    OperationType = OperationType.EXPORT,
                    Solution = solution,
                    UnpackSolution = true
                };

                OnOperationSelected?.Invoke(this, _export);

                gbExportSettings.Enabled = true;
                gbSolutionInfo.Enabled = true;
            }
        }

        private void SetExportLocations_Click(object sender, EventArgs e)
        {
            try
            {
                var tag = (sender as Button).Tag as string;

                var dirPath = string.Empty;
                using (var fbd = new FolderBrowserDialog())
                {
                    fbd.Description = "Select export directory";

                    if (fbd.ShowDialog(this) == DialogResult.OK)
                    {
                        dirPath = fbd.SelectedPath;
                    }
                }

                if (string.IsNullOrEmpty(dirPath))
                {
                    throw new Exception("Invalid directory path");
                }

                txtSolutionPathValue.Text = dirPath;
                _export.Solution.Package.ExportPath = dirPath;
                _settings.ExportPath = dirPath;

                _settings.SaveSettings();
                
                OnOperationUpdated?.Invoke(this, _export);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.ERROR, ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void rbPackageType_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;

            var type = rbManaged.Checked ? PackageType.MANAGED : PackageType.UNMANAGED;
            var suffix = type.Equals(PackageType.MANAGED) ? "_managed.zip" : ".zip";

            _export.Solution.Package.Type = type;
            _export.Solution.Package.Name = $"{_export.Solution.LogicalName}_{_export.Solution.Version}{suffix}";

            OnOperationUpdated?.Invoke(this, _export);
        }
    }
}

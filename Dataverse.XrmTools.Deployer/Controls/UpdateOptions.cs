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
    public partial class UpdateOptions : UserControl
    {
        private readonly Logger _logger;
        private readonly Settings _settings;

        public event SolutionsRetrieve OnSolutionsRetrieveRequested;
        public event EventHandler<Operation> OnOperationSelected;
        public event EventHandler<Operation> OnOperationRemoved;

        private IEnumerable<Solution> _solutions;
        private UpdateOperation _update;

        public UpdateOptions(Logger logger, Settings settings)
        {
            _logger = logger;
            _settings = settings;

            InitializeComponent();

            gbSolutions.Enabled = false;
            gbSolutionInfo.Enabled = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _solutions = OnSolutionsRetrieveRequested?.Invoke(PackageType.UNMANAGED, ConnectionType.SOURCE);
            LoadSolutionsList();
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

                lblSolutionIdValue.Text = solution.SolutionId.ToString();
                lblLogicalNameValue.Text = solution.LogicalName;
                txtUpdateName.Text = solution.DisplayName;
                txtUpdateVersion.Text = solution.Version;
                lblManagedValue.Text = solution.IsManaged.ToString();
                lblPublisherValue.Text = solution.Publisher.DisplayName;
                txtUpdateDescription.Text = solution.Description;

                if (_update != null) { OnOperationRemoved?.Invoke(this, _update); }

                _update = new UpdateOperation
                {
                    OperationType = OperationType.UPDATE,
                    Solution = solution
                };

                OnOperationSelected?.Invoke(this, _update);

                gbSolutionInfo.Enabled = true;
            }
        }

        private async void SolutionDetails_TextChanged(object sender, EventArgs e)
        {
            var box = sender as TextBox;
            async Task<bool> UserKeepsTyping()
            {
                var txt = box.Text;
                await Task.Delay(250);

                return txt != box.Text;
            }

            if (await UserKeepsTyping()) return;

            if(box.Tag.Equals("name"))
            {
                _update.OldDisplayName = _update.Solution.DisplayName;
                _update.Solution.DisplayName = txtUpdateName.Text;
            }

            if (box.Tag.Equals("version"))
            {
                var isValid = Version.TryParse(txtUpdateVersion.Text, out Version version);
                if (isValid)
                {
                    Version.TryParse(_update.Solution.Version, out Version oldVersion);
                    if (version != oldVersion)
                    {
                        _settings.Defaults.Version = version.ToString();
                        _settings.SaveSettings();

                        _update.NewVersion = version.ToString();
                        _update.OldVersion = oldVersion.ToString();
                    }
                }
            }

            if (box.Tag.Equals("description"))
            {
                _update.OldDescription = _update.Solution.Description;
                _update.Solution.Description = txtUpdateDescription.Text;
            }

            box.Focus();
        }
    }
}

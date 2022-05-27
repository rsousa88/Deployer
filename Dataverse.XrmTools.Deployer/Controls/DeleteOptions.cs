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
using Dataverse.XrmTools.Deployer.HandlerArgs;

namespace Dataverse.XrmTools.Deployer.Controls
{
    public partial class DeleteOptions : UserControl
    {
        private readonly Logger _logger;
        public event SolutionsRetrieve OnSolutionsRetrieveRequested;
        public event EventHandler<OperationEventArgs> OnOperationSelected;

        private IEnumerable<Solution> _solutions;

        public DeleteOptions(Logger logger)
        {
            _logger = logger;

            InitializeComponent();

            gbDeleteSettings.Enabled = false;
            gbSolutionInfo.Enabled = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            _solutions = OnSolutionsRetrieveRequested?.Invoke(PackageType.ALL, ConnectionType.TARGET);
            LoadSolutionsList();
        }

        private void LoadSolutionsList()
        {
            lvSolutions.Items.Clear();

            var textFilter = txtSolutionFilter.Text;
            var filtered = _solutions.Where(sol => string.IsNullOrWhiteSpace(textFilter) || sol.MatchFilter(textFilter));

            var items = filtered.Select(sol => sol.ToListViewItem()).ToArray();

            lvSolutions.Items.AddRange(items);

            gbDeleteSettings.Enabled = true;
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
            chSolLogicalName.Width = 0;
            chSolDisplayName.Width = (int)Math.Floor(maxWidth * 0.39);
            chSolVersion.Width = (int)Math.Floor(maxWidth * 0.19);
            chSolManaged.Width = (int)Math.Floor(maxWidth * 0.19);
            chSolPublisher.Width = (int)Math.Floor(maxWidth * 0.19);
            chSolPublisherLogicalNameHidden.Width = 0;
        }

        private void lvSolutions_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvSolutions.SelectedItems.Count > 0)
            {
                var solution = lvSolutions.SelectedItems[0].ToObject(new Solution()) as Solution;

                lblSolutionIdValue.Text = solution.SolutionId.ToString();
                lblLogicalNameValue.Text = solution.LogicalName;
                lblDisplayNameValue.Text = solution.DisplayName;
                lblVersionValue.Text = solution.Version;
                lblManagedValue.Text = solution.IsManaged.ToString();
                lblPublisherValue.Text = solution.Publisher.DisplayName;

                var args = new DeleteEventArgs
                {
                    Type = OperationType.DELETE,
                    Solution = solution
                };

                OnOperationSelected?.Invoke(this, args);

                gbSolutionInfo.Enabled = true;
            }
        }
    }
}

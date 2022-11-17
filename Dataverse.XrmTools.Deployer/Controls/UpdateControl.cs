using Dataverse.XrmTools.Deployer.Enums;
using Dataverse.XrmTools.Deployer.Helpers;
using Dataverse.XrmTools.Deployer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dataverse.XrmTools.Deployer.Controls
{
    public partial class UpdateControl : UserControl
    {
        private readonly Logger _logger;
        private IEnumerable<Solution> _solutions;

        private string _version;
        private IList<UpdateOperation> _updates;

        // events
        public event EventHandler<IEnumerable<Operation>> OnAddToQueue;

        public UpdateControl(Logger logger, IEnumerable<Solution> solutions)
        {
            _logger = logger;
            _solutions = solutions;

            Dock = DockStyle.Fill;
            InitializeComponent();

            LoadSolutionsList();
        }

        private void LoadSolutionsList()
        {
            lvSolutions.Items.Clear();

            var textFilter = txtSolutionFilter.Text;
            var filtered = _solutions.Where(sol => string.IsNullOrWhiteSpace(textFilter) || sol.MatchFilter(textFilter));

            var items = filtered.Select(sol => sol.ToListViewItem()).ToArray();

            lvSolutions.Items.AddRange(items);
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
                _version = box.Text;

                if(_updates != null && _updates.Count > 0)
                {
                    foreach (var upd in _updates)
                    {
                        upd.Version = _version;
                    }
                }
            }

            box.Focus();
        }

        private void lvSolutions_SelectedIndexChanged(object sender, EventArgs e)
        {
            _updates = new List<UpdateOperation>();

            var first = lvSolutions.SelectedItems[0].ToObject(new Solution()) as Solution;
            txtUpdateVersion.Text = string.IsNullOrEmpty(txtUpdateVersion.Text) ? first.Version : txtUpdateVersion.Text;

            foreach (var item in lvSolutions.SelectedItems)
            {
                var solution = (item as ListViewItem).ToObject(new Solution()) as Solution;

                var update = new UpdateOperation
                {
                    OperationType = OperationType.UPDATE,
                    Version = _version != null ? _version : solution.Version,
                    Solution = new Solution
                    {
                        SolutionId = solution.SolutionId,
                        DisplayName = solution.DisplayName
                    }
                };

                _updates.Add(update);
            }
        }

        private void btnAddToQueue_Click(object sender, EventArgs e)
        {
            OnAddToQueue?.Invoke(this, _updates);
        }
    }
}

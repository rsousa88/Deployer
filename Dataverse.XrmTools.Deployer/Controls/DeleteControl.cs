using Dataverse.XrmTools.Deployer.Enums;
using Dataverse.XrmTools.Deployer.Helpers;
using Dataverse.XrmTools.Deployer.Models;
using Dataverse.XrmTools.Deployer.Repositories;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Dataverse.XrmTools.Deployer.Controls
{
    public partial class DeleteControl : UserControl
    {
        private readonly Logger _logger;
        private IEnumerable<Solution> _solutions;
        private IList<DeleteOperation> _deletes;

        // events
        public event EventHandler<IEnumerable<DeleteOperation>> OnAddToQueue_Delete;

        public DeleteControl(Logger logger, IEnumerable<Solution> solutions)
        {
            _logger = logger;
            _solutions = solutions;

            Dock = DockStyle.Fill;
            InitializeComponent();

            LoadSolutionsList();

            lvDeleteQueue.Enabled = false;
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

        private void lvDeleteQueue_Resize(object sender, EventArgs e)
        {
            var maxWidth = lvDeleteQueue.Width >= 350 ? lvDeleteQueue.Width : 350;
            chImpQueIndex.Width = (int)Math.Floor(maxWidth * 0.15);
            chImpQueDisplayName.Width = (int)Math.Floor(maxWidth * 0.80);
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

        private void lvSolutions_DoubleClick(object sender, EventArgs e)
        {
            if (_deletes is null) { _deletes = new List<DeleteOperation>(); }

            if (lvSolutions.SelectedItems.Count.Equals(0)) { return; }

            var solution = lvSolutions.SelectedItems[0].ToObject(new Solution()) as Solution;

            var delete = new DeleteOperation
            {
                OperationType = OperationType.DELETE,
                Solution = new Solution
                {
                    SolutionId = solution.SolutionId,
                    LogicalName = solution.LogicalName,
                    DisplayName = solution.DisplayName,
                    Publisher = solution.Publisher
                }
            };

            if (_deletes.Any(imp => imp.Solution.LogicalName.Equals(delete.Solution.LogicalName)))
            {
                throw new Exception($"An operation of type '{delete.OperationType}' on solution '{delete.Solution.DisplayName}' is already added to delete queue");
            }

            delete.Index = lvDeleteQueue.Items.Count + 1;

            _deletes.Add(delete);

            var deleteLvi = new ListViewItem(new string[] {
                delete.Index.ToString(),
                delete.Solution != null ? delete.Solution.DisplayName : "-"
            });

            deleteLvi.Tag = delete;

            lvDeleteQueue.Items.Add(deleteLvi);

            _logger.Log(LogLevel.INFO, $"Added '{delete.OperationType}' operation on solution '{delete.Solution.DisplayName}' to delete queue");

            lvDeleteQueue.Enabled = true;
            btnAddToQueue.Enabled = true;
        }

        private void btnAddToQueue_Click(object sender, EventArgs e)
        {
            OnAddToQueue_Delete?.Invoke(this, _deletes);
        }
    }
}

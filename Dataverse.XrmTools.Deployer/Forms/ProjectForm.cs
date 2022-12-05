using Dataverse.XrmTools.Deployer.AppSettings;
using Dataverse.XrmTools.Deployer.Enums;
using Dataverse.XrmTools.Deployer.Helpers;
using Dataverse.XrmTools.Deployer.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dataverse.XrmTools.Deployer.Forms
{
    public partial class ProjectForm : Form
    {
        private readonly Logger _logger;
        private IEnumerable<Solution> _solutions;
        private Instance _instance;

        public Workspace Workspace;

        public ProjectForm(Logger logger, IEnumerable<Solution> solutions, Instance instance)
        {
            _logger = logger;
            _solutions = solutions;
            _instance = instance;

            InitializeComponent();

            LoadSolutionsList();
        }

        public ProjectForm(Logger logger, IEnumerable<Solution> solutions, Project project, Instance instance)
        {
            _logger = logger;
            _solutions = solutions;
            _instance = instance;

            InitializeComponent();

            LoadSolutionsList(project.Workspace.Solutions);

            Text = "Edit Project";
            txtProjectDirPathValue.Text = project.Workspace.RootPath;
            txtProjectName.Text = project.Workspace.ProjectDisplayName;
            txtVersion.Text = project.Workspace.Version;
        }

        private void LoadSolutionsList(IEnumerable<Solution> selected = null)
        {
            lvSolutions.Items.Clear();

            var textFilter = txtSolutionFilter.Text;
            var filtered = _solutions.Where(sol => string.IsNullOrWhiteSpace(textFilter) || sol.MatchFilter(textFilter));

            if(selected is null) { selected = new List<Solution>().AsEnumerable(); }
            var selectedIds = selected.Select(sel => sel.SolutionId);
            var items = filtered.Select(sol => {
                var item = sol.ToListViewItem();
                item.Selected = selectedIds.Contains(sol.SolutionId);

                return item;
            }).ToArray();

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

        private void btnOk_Click(object sender, EventArgs e)
        {
            try
            {
                var isValid = CheckProjectData();
                if (isValid)
                {
                    var selected = lvSolutions.SelectedItems.Cast<ListViewItem>().Select(lvi => new Solution
                    {
                        SolutionId = (lvi.ToObject(new Solution()) as Solution).SolutionId,
                        DisplayName = (lvi.ToObject(new Solution()) as Solution).DisplayName
                    });

                    Workspace = new Workspace
                    {
                        Source = _instance,
                        Solutions = selected,
                        RootPath = txtProjectDirPathValue.Text,
                        ProjectDisplayName = txtProjectName.Text,
                        ProjectLogicalName = txtProjectName.Text.RemoveSpecialCharacters(),
                        Version = txtVersion.Text
                    };
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.ERROR, ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool CheckProjectData()
        {
            try
            {
                if (lvSolutions.SelectedItems.Count.Equals(0))
                {
                    throw new Exception($"At least one solution must be selected");
                }
                if (string.IsNullOrEmpty(txtProjectDirPathValue.Text))
                {
                    throw new Exception($"A valid project directory is required");
                }
                if (string.IsNullOrEmpty(txtProjectName.Text))
                {
                    throw new Exception($"A project name is required");
                }
                if (string.IsNullOrEmpty(txtVersion.Text))
                {
                    throw new Exception($"A project version is required");
                }

                var isValid = Version.TryParse(txtVersion.Text, out Version version);
                if (!isValid)
                {
                    throw new Exception($"Project version is invalid");
                }

                return true;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.ERROR, ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult = DialogResult.None; // prevent form from closing

                return false;
            }
        }

        private void btnAddSourceDir_Click(object sender, EventArgs e)
        {
            try
            {
                _logger.Log(LogLevel.DEBUG, $"Selecting root directory...");
                var dirPath = Handle.SelectDirectory(string.Empty);

                if (string.IsNullOrEmpty(dirPath) || !Directory.Exists(dirPath)) { return; }

                txtProjectDirPathValue.Text = dirPath;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.ERROR, ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

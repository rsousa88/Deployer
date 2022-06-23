// System
using System.Windows.Forms;

// Dataverse
using Dataverse.XrmTools.Deployer.Enums;
using Dataverse.XrmTools.Deployer.Models;
using Dataverse.XrmTools.Deployer.Helpers;

namespace Dataverse.XrmTools.Deployer.Controls
{
    public partial class DeleteDetails : UserControl
    {
        private readonly Logger _logger;
        private readonly Operation _delete;

        public DeleteDetails(Logger logger, Operation delete)
        {
            _logger = logger;
            _delete = delete;

            InitializeComponent();

            RenderData();
        }

        private void RenderData()
        {
            _logger.Log(LogLevel.DEBUG, $"Rendering data...");

            // operation details
            lblOperationType.Text = _delete.OperationType.ToString();
            lblOperationDescription.Text = _delete.Description;

            // solution details
            lblSolutionId.Text = _delete.Solution.SolutionId.ToString();
            lblSolutionLogicalName.Text = _delete.Solution.LogicalName;
            lblSolutionDisplayName.Text = _delete.Solution.DisplayName;
            lblSolutionVersion.Text = _delete.Solution.Version;
            lblSolutionManaged.Text = _delete.Solution.IsManaged ? "Yes" : "No";
            lblSolutionPublisher.Text = _delete.Solution.Publisher.DisplayName;
            txtSolutionDescription.Text = _delete.Solution.Description;
            txtSolutionDescription.Select(txtSolutionDescription.Text.Length, 0);
        }
    }
}

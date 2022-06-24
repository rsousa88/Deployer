// System
using System;
using System.Windows.Forms;

// Dataverse
using Dataverse.XrmTools.Deployer.Enums;
using Dataverse.XrmTools.Deployer.Models;
using Dataverse.XrmTools.Deployer.Helpers;

namespace Dataverse.XrmTools.Deployer.Controls
{
    public partial class ImportDetails : UserControl
    {
        private readonly Logger _logger;
        private readonly ImportOperation _import;

        public ImportDetails(Logger logger, ImportOperation import) {
            _logger = logger;
            _import = import;

            InitializeComponent();

            RenderData();
        }

        private void RenderData()
        {
            _logger.Log(LogLevel.DEBUG, $"Rendering data...");

            // operation details
            lblOperationType.Text = _import.OperationType.ToString();
            lblOperationDescription.Text = _import.Description;
            lblOperationImportMode.Text = _import.Mode.ToString();
            lblOperationImportFrom.Text = _import.ZipFile;
            lblOperationHoldingSolution.Text = _import.HoldingSolution ? "Yes" : "No";
            lblOperationOverwriteUnmanaged.Text = _import.OverwriteUnmanaged ? "Yes" : "No";
            lblOperationPublishWorkflows.Text = _import.PublishWorkflows ? "Yes" : "No";

            // solution details
            lblSolutionId.Text = _import.Solution.SolutionId.ToString();
            lblSolutionLogicalName.Text = _import.Solution.LogicalName;
            lblSolutionDisplayName.Text = _import.Solution.DisplayName;
            lblSolutionVersion.Text = _import.Solution.Version;
            lblSolutionManaged.Text = _import.Solution.Package.Type.Equals(PackageType.MANAGED) ? "Yes" : "No";
            lblSolutionPublisher.Text = _import.Solution.Publisher.DisplayName;
        }
    }
}

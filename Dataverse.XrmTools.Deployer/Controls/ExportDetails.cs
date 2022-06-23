// System
using System;
using System.Windows.Forms;

// Dataverse
using Dataverse.XrmTools.Deployer.Enums;
using Dataverse.XrmTools.Deployer.Models;
using Dataverse.XrmTools.Deployer.Helpers;

namespace Dataverse.XrmTools.Deployer.Controls
{
    public partial class ExportDetails : UserControl
    {
        private readonly Logger _logger;
        private readonly ExportOperation _export;

        public ExportDetails(Logger logger, ExportOperation export)
        {
            _logger = logger;
            _export = export;

            InitializeComponent();

            RenderData();
        }

        private void RenderData()
        {
            _logger.Log(LogLevel.DEBUG, $"Rendering data...");

            // operation details
            lblOperationType.Text = _export.OperationType.ToString();
            lblOperationDescription.Text = _export.Description;
            lblOperationExportAs.Text = _export.Solution.Package.Type.ToString();
            lblOperationExportTo.Text = _export.Solution.Package.Path;
            lblOperationQuickUpdateVersion.Text = _export.QuickUpdateId.Equals(Guid.Empty) ? "No" : "Yes";
            lblOperationQuickUnpack.Text = _export.QuickUnpackId.Equals(Guid.Empty) ? "No" : "Yes";
            lblOperationQuickPack.Text = _export.QuickPackId.Equals(Guid.Empty) ? "No" : "Yes";

            // solution details
            lblSolutionId.Text = _export.Solution.SolutionId.ToString();
            lblSolutionLogicalName.Text = _export.Solution.LogicalName;
            lblSolutionDisplayName.Text = _export.Solution.DisplayName;
            lblSolutionVersion.Text = _export.Solution.Version;
            lblSolutionManaged.Text = _export.Solution.IsManaged ? "Yes" : "No";
            lblSolutionPublisher.Text = _export.Solution.Publisher.DisplayName;
        }
    }
}

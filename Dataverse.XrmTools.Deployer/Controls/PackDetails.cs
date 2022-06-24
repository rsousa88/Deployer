// System
using System;
using System.Windows.Forms;

// Dataverse
using Dataverse.XrmTools.Deployer.Enums;
using Dataverse.XrmTools.Deployer.Models;
using Dataverse.XrmTools.Deployer.Helpers;

namespace Dataverse.XrmTools.Deployer.Controls
{
    public partial class PackDetails : UserControl
    {
        private readonly Logger _logger;
        private readonly PackOperation _pack;

        public PackDetails(Logger logger, PackOperation pack) {
            _logger = logger;
            _pack = pack;

            InitializeComponent();

            RenderData();
        }

        private void RenderData()
        {
            _logger.Log(LogLevel.DEBUG, $"Rendering data...");

            // operation details
            lblOperationType.Text = _pack.OperationType.ToString();
            lblOperationDescription.Text = _pack.Description;
            lblOperationPackMode.Text = _pack.Mode.ToString();
            lblOperationPackFrom.Text = _pack.Folder;
            lblOperationPackTo.Text = _pack.Solution.Package.Path;

            // solution details
            lblSolutionId.Text = _pack.Solution.SolutionId.ToString();
            lblSolutionLogicalName.Text = _pack.Solution.LogicalName;
            lblSolutionDisplayName.Text = _pack.Solution.DisplayName;
            lblSolutionVersion.Text = _pack.Solution.Version;
            lblSolutionManaged.Text = _pack.Solution.Package.Type.Equals(PackageType.MANAGED) ? "Yes" : "No";
            lblSolutionPublisher.Text = _pack.Solution.Publisher.DisplayName;
        }
    }
}

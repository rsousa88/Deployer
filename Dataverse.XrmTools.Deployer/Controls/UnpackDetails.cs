// System
using System;
using System.Windows.Forms;

// Dataverse
using Dataverse.XrmTools.Deployer.Enums;
using Dataverse.XrmTools.Deployer.Models;
using Dataverse.XrmTools.Deployer.Helpers;

namespace Dataverse.XrmTools.Deployer.Controls
{
    public partial class UnpackDetails : UserControl
    {
        private readonly Logger _logger;
        private readonly UnpackOperation _unpack;

        public UnpackDetails(Logger logger, UnpackOperation unpack)
        {
            _logger = logger;
            _unpack = unpack;

            InitializeComponent();

            RenderData();
        }

        private void RenderData()
        {
            _logger.Log(LogLevel.DEBUG, $"Rendering data...");

            // operation details
            lblOperationType.Text = _unpack.OperationType.ToString();
            lblOperationDescription.Text = _unpack.Description;
            lblOperationUnpackMode.Text = _unpack.Mode.ToString();
            lblOperationUnpackFrom.Text = _unpack.ZipFile;
            lblOperationUnpackTo.Text = _unpack.Folder;

            // solution details
            lblSolutionId.Text = _unpack.Solution.SolutionId.ToString();
            lblSolutionLogicalName.Text = _unpack.Solution.LogicalName;
            lblSolutionDisplayName.Text = _unpack.Solution.DisplayName;
            lblSolutionVersion.Text = _unpack.Solution.Version;
            lblSolutionManaged.Text = _unpack.Solution.Package.Type.Equals(PackageType.MANAGED) ? "Yes" : "No";
            lblSolutionPublisher.Text = _unpack.Solution.Publisher.DisplayName;
        }
    }
}

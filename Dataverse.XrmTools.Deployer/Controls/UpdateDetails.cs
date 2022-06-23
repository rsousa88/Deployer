// System
using System;
using System.Drawing;
using System.Windows.Forms;

// Dataverse
using Dataverse.XrmTools.Deployer.Enums;
using Dataverse.XrmTools.Deployer.Models;
using Dataverse.XrmTools.Deployer.Helpers;

namespace Dataverse.XrmTools.Deployer.Controls
{
    public partial class UpdateDetails : UserControl
    {
        private readonly Logger _logger;
        private readonly UpdateOperation _update;

        public UpdateDetails(Logger logger, UpdateOperation update)
        {
            _logger = logger;
            _update = update;

            InitializeComponent();

            RenderData();
        }

        private void RenderData()
        {
            _logger.Log(LogLevel.DEBUG, $"Rendering data...");

            lblOperationType.Text = _update.OperationType.ToString();
            lblOperationDescription.Text = _update.Description;

            lblSolutionId.Text = _update.Solution.SolutionId.ToString();
            lblSolutionLogicalName.Text = _update.Solution.LogicalName;
            lblSolutionManaged.Text = _update.Solution.IsManaged ? "Yes" : "No";
            lblSolutionPublisher.Text = _update.Solution.Publisher.DisplayName;
            txtSolutionDescription.Text = _update.Solution.Description;

            if (string.IsNullOrEmpty(_update.OldDisplayName) || _update.Solution.DisplayName.Equals(_update.OldDisplayName))
            {
                lblSolutionDisplayName.Text = _update.Solution.DisplayName;
                lblSolutionDisplayName.ForeColor = SystemColors.ControlText;
            }
            else
            {
                lblSolutionDisplayName.Text = $"{_update.OldDisplayName} -> {_update.Solution.DisplayName}";
                lblSolutionDisplayName.ForeColor = Color.MediumSeaGreen;
            }

            Version.TryParse(_update.OldVersion, out Version oldVersion);
            Version.TryParse(_update.Solution.Version, out Version version);
            if (oldVersion is null || version == oldVersion)
            {
                lblSolutionVersion.Text = _update.Solution.Version;
                lblSolutionVersion.ForeColor = SystemColors.ControlText;
            }
            else
            {
                lblSolutionVersion.Text = $"{oldVersion} -> {version}";
                lblSolutionVersion.ForeColor = Color.MediumSeaGreen;
            }

            txtSolutionDescription.BackColor = string.IsNullOrEmpty(_update.OldDescription) || _update.Solution.Description.Equals(_update.OldDescription) ? SystemColors.Control : Color.MediumSeaGreen;
            txtSolutionDescription.Select(txtSolutionDescription.Text.Length, 0);
        }
    }
}

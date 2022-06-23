// System
using System.Windows.Forms;

// Dataverse
using Dataverse.XrmTools.Deployer.Models;
using Dataverse.XrmTools.Deployer.Helpers;
using System;
using System.Drawing;

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
            lblOperationTypeValue.Text = _update.OperationType.ToString();
            lblOperationDescriptionValue.Text = _update.Description;

            lblSolutionIdValue.Text = _update.Solution.SolutionId.ToString();
            lblSolutionLogicalNameValue.Text = _update.Solution.LogicalName;
            lblSolutionManagedValue.Text = _update.Solution.IsManaged ? "Yes" : "No";
            lblSolutionPublisherValue.Text = _update.Solution.Publisher.DisplayName;
            txtSolutionDescriptionValue.Text = _update.Solution.Description;

            if (string.IsNullOrEmpty(_update.OldDisplayName) || _update.Solution.DisplayName.Equals(_update.OldDisplayName))
            {
                lblSolutionDisplayNameValue.Text = _update.Solution.DisplayName;
                lblSolutionDisplayNameValue.ForeColor = SystemColors.ControlText;
            }
            else
            {
                lblSolutionDisplayNameValue.Text = $"{_update.OldDisplayName} -> {_update.Solution.DisplayName}";
                lblSolutionDisplayNameValue.ForeColor = Color.MediumSeaGreen;
            }

            Version.TryParse(_update.OldVersion, out Version oldVersion);
            Version.TryParse(_update.Solution.Version, out Version version);
            if (oldVersion is null || version == oldVersion)
            {
                lblSolutionVersionValue.Text = _update.Solution.Version;
                lblSolutionVersionValue.ForeColor = SystemColors.ControlText;
            }
            else
            {
                lblSolutionVersionValue.Text = $"{oldVersion} -> {version}";
                lblSolutionVersionValue.ForeColor = Color.MediumSeaGreen;
            }

            txtSolutionDescriptionValue.BackColor = string.IsNullOrEmpty(_update.OldDescription) || _update.Solution.Description.Equals(_update.OldDescription) ? SystemColors.Control : Color.MediumSeaGreen;
            txtSolutionDescriptionValue.Select(txtSolutionDescriptionValue.Text.Length, 0);
        }
    }
}

// System
using System;
using System.Windows.Forms;
using System.Collections.Generic;

// Dataverse
using Dataverse.XrmTools.Deployer.Enums;
using Dataverse.XrmTools.Deployer.Models;
using Dataverse.XrmTools.Deployer.Helpers;
using Dataverse.XrmTools.Deployer.Controls;
using Dataverse.XrmTools.Deployer.HandlerArgs;
using Dataverse.XrmTools.Deployer.AppSettings;

namespace Dataverse.XrmTools.Deployer.Forms
{
    public partial class AddOperation : Form
    {
        private readonly Logger _logger;
        private OperationEventArgs _opArgs;

        public event EventHandler<ExportEventArgs> OnExport;
        public event EventHandler<ImportEventArgs> OnImport;
        public event EventHandler<DeleteEventArgs> OnDelete;

        public event SolutionsRetrieve OnSolutionsRetrieve;

        private Settings _settings;

        public AddOperation(Logger logger, Settings settings)
        {
            _logger = logger;
            _settings = settings;

            InitializeComponent();

            btnClose.Enabled = false;
            rbExport.Checked = true;
        }

        private void rbExport_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if(radio.Checked)
            {
                pnlOperationDetails.Controls.Clear();
                var export = new ExportOptions(_logger, _settings);
                pnlOperationDetails.Controls.Add(export);

                export.OnSolutionsRetrieveRequested += HandleRetrieveSolutionsEvent;
                export.OnOperationSelected += HandleSelectedOperationEvent;
                export.OnOperationUpdated += HandleUpdateOperationEvent;
            }
        }

        private void rbImport_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if (radio.Checked)
            {
                pnlOperationDetails.Controls.Clear();
                var import = new ImportOptions(_logger);
                pnlOperationDetails.Controls.Add(import);

                import.OnOperationSelected += HandleSelectedOperationEvent;
            }
        }

        private void rbDelete_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if (radio.Checked)
            {
                pnlOperationDetails.Controls.Clear();
                var delete = new DeleteOptions(_logger);
                pnlOperationDetails.Controls.Add(delete);

                delete.OnSolutionsRetrieveRequested += HandleRetrieveSolutionsEvent;
                delete.OnOperationSelected += HandleSelectedOperationEvent;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                switch (_opArgs.Type)
                {
                    case OperationType.EXPORT:
                        OnExport?.Invoke(this, _opArgs as ExportEventArgs);
                        break;
                    case OperationType.IMPORT:
                        OnImport?.Invoke(this, _opArgs as ImportEventArgs);
                        break;
                    case OperationType.DELETE:
                        OnDelete?.Invoke(this, _opArgs as DeleteEventArgs);
                        break;
                    default:
                        break;
                }

                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void HandleSelectedOperationEvent(object sender, OperationEventArgs opArgs)
        {
            _opArgs = opArgs;
            btnClose.Enabled = true;
        }

        private void HandleUpdateOperationEvent(object sender, OperationEventArgs opArgs)
        {
            _opArgs = opArgs;
        }

        private IEnumerable<Solution> HandleRetrieveSolutionsEvent(PackageType queryType, ConnectionType connType)
        {
            return OnSolutionsRetrieve?.Invoke(queryType, connType);
        }
    }
}

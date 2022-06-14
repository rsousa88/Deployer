// System
using System;
using System.Windows.Forms;
using System.Collections.Generic;

// Dataverse
using Dataverse.XrmTools.Deployer.Enums;
using Dataverse.XrmTools.Deployer.Models;
using Dataverse.XrmTools.Deployer.Helpers;
using Dataverse.XrmTools.Deployer.Controls;
using Dataverse.XrmTools.Deployer.AppSettings;

namespace Dataverse.XrmTools.Deployer.Forms
{
    public partial class AddOperation : Form
    {
        private readonly Logger _logger;
        private Operation _operation;

        public event EventHandler<Operation> OnOperation;

        public event SolutionsRetrieve OnSolutionsRetrieve;
        public event SingleSolutionRetrieve OnSingleSolutionRetrieve;
        public event OperationsRetrieve OnOperationsRetrieve;

        private Settings _settings;

        public AddOperation(Logger logger, Settings settings)
        {
            _logger = logger;
            _settings = settings;

            InitializeComponent();

            btnClose.Enabled = false;
            rbUpdate.Checked = true;
        }

        private void rbUpdate_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if (radio.Checked)
            {
                pnlOperationDetails.Controls.Clear();
                var update = new UpdateOptions(_logger);
                pnlOperationDetails.Controls.Add(update);

                update.OnSolutionsRetrieveRequested += HandleRetrieveSolutionsEvent;
                update.OnOperationSelected += HandleSelectedOperationEvent;
                update.OnOperationUpdated += HandleUpdateOperationEvent;
            }
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

                import.OnSingleSolutionRetrieveRequested += HandleRetrieveSingleSolutionEvent;
                import.OnOperationsRetrieveRequested += HandleRetrieveOperationsEvent;
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

        private void rbUnpack_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if (radio.Checked)
            {
                pnlOperationDetails.Controls.Clear();
                var unpack = new UnpackOptions(_logger, _settings);
                pnlOperationDetails.Controls.Add(unpack);

                unpack.OnOperationsRetrieveRequested += HandleRetrieveOperationsEvent;
                unpack.OnOperationSelected += HandleSelectedOperationEvent;
                unpack.OnOperationUpdated += HandleUpdateOperationEvent;
                unpack.OnWorkingStateSetRequested += HandleSetWorkingStateEvent;
            }
        }

        private void rbPack_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if (radio.Checked)
            {
                pnlOperationDetails.Controls.Clear();
                var pack = new PackOptions(_logger, _settings);
                pnlOperationDetails.Controls.Add(pack);

                pack.OnOperationsRetrieveRequested += HandleRetrieveOperationsEvent;
                pack.OnOperationSelected += HandleSelectedOperationEvent;
                pack.OnOperationUpdated += HandleUpdateOperationEvent;
                pack.OnWorkingStateSetRequested += HandleSetWorkingStateEvent;
            }
        }

        private void rbPublish_CheckedChanged(object sender, EventArgs e)
        {
            pnlOperationDetails.Controls.Clear();

            var operation = new Operation
            {
                OperationType = OperationType.PUBLISH
            };

            HandleSelectedOperationEvent(null, operation);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                OnOperation?.Invoke(this, _operation);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void HandleSelectedOperationEvent(object sender, Operation operation)
        {
            operation.OperationId = Guid.NewGuid();

            _operation = operation;
            btnClose.Enabled = true;
        }

        private void HandleUpdateOperationEvent(object sender, Operation operation)
        {
            _operation = operation;
        }

        private void HandleSetWorkingStateEvent(bool working)
        {
            pnlBody.Enabled = !working;
            Cursor = working ? Cursors.WaitCursor : Cursors.Default;
        }

        private IEnumerable<Solution> HandleRetrieveSolutionsEvent(PackageType queryType, ConnectionType connType)
        {
            return OnSolutionsRetrieve?.Invoke(queryType, connType);
        }

        private Solution HandleRetrieveSingleSolutionEvent(string logicalName, ConnectionType connType)
        {
            return OnSingleSolutionRetrieve?.Invoke(logicalName, connType);
        }

        private IEnumerable<Operation> HandleRetrieveOperationsEvent(OperationType opType)
        {
            return OnOperationsRetrieve?.Invoke(opType);
        }
    }
}

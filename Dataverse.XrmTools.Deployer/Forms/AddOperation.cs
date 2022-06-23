// System
using System;
using System.Linq;
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
        private List<Operation> _operations = new List<Operation>();

        public event EventHandler<List<Operation>> OnOperations;

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
            rbExport.Checked = true;
        }

        private void rbExport_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if(radio.Checked)
            {
                _operations.Clear();

                pnlOperationDetails.Controls.Clear();
                var export = new ExportOptions(_logger, _settings);
                pnlOperationDetails.Controls.Add(export);

                export.OnSolutionsRetrieveRequested += HandleRetrieveSolutionsEvent;
                export.OnOperationSelected += HandleSelectedOperationEvent;
                export.OnOperationRemoved += HandleRemoveOperationEvent;
            }
        }

        private void rbUpdate_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if (radio.Checked)
            {
                _operations.Clear();

                pnlOperationDetails.Controls.Clear();
                var update = new UpdateOptions(_logger, _settings);
                pnlOperationDetails.Controls.Add(update);

                update.OnSolutionsRetrieveRequested += HandleRetrieveSolutionsEvent;
                update.OnOperationSelected += HandleSelectedOperationEvent;
                update.OnOperationRemoved += HandleRemoveOperationEvent;
            }
        }

        private void rbImport_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if (radio.Checked)
            {
                _operations.Clear();

                pnlOperationDetails.Controls.Clear();
                var import = new ImportOptions(_logger);
                pnlOperationDetails.Controls.Add(import);

                import.OnSingleSolutionRetrieveRequested += HandleRetrieveSingleSolutionEvent;
                import.OnOperationsRetrieveRequested += HandleRetrieveOperationsEvent;
                import.OnOperationSelected += HandleSelectedOperationEvent;
                import.OnOperationRemoved += HandleRemoveOperationEvent;
            }
        }

        private void rbDelete_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if (radio.Checked)
            {
                _operations.Clear();

                pnlOperationDetails.Controls.Clear();
                var delete = new DeleteOptions(_logger);
                pnlOperationDetails.Controls.Add(delete);

                delete.OnSolutionsRetrieveRequested += HandleRetrieveSolutionsEvent;
                delete.OnOperationSelected += HandleSelectedOperationEvent;
                delete.OnOperationRemoved += HandleRemoveOperationEvent;
            }
        }

        private void rbUnpack_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if (radio.Checked)
            {
                _operations.Clear();

                pnlOperationDetails.Controls.Clear();
                var unpack = new UnpackOptions(_logger, _settings);
                pnlOperationDetails.Controls.Add(unpack);

                unpack.OnOperationsRetrieveRequested += HandleRetrieveOperationsEvent;
                unpack.OnOperationSelected += HandleSelectedOperationEvent;
                unpack.OnOperationRemoved += HandleRemoveOperationEvent;
            }
        }

        private void rbPack_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if (radio.Checked)
            {
                _operations.Clear();

                pnlOperationDetails.Controls.Clear();
                var pack = new PackOptions(_logger, _settings);
                pnlOperationDetails.Controls.Add(pack);

                pack.OnOperationsRetrieveRequested += HandleRetrieveOperationsEvent;
                pack.OnOperationSelected += HandleSelectedOperationEvent;
                pack.OnOperationRemoved += HandleRemoveOperationEvent;
            }
        }

        private void rbPublish_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if (radio.Checked)
            {
                _operations.Clear();

                pnlOperationDetails.Controls.Clear();
                var publish = new PublishOptions(_logger);
                pnlOperationDetails.Controls.Add(publish);

                publish.OnOperationSelected += HandleSelectedOperationEvent;
                publish.OnOperationRemoved += HandleRemoveOperationEvent;
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
                var operation = _operations.FirstOrDefault(op => op.OperationType.Equals(OperationType.EXPORT));
                if(operation != null)
                {
                    var export = operation as ExportOperation;
                    var update = !export.QuickUpdateId.Equals(Guid.Empty) ? _operations.FirstOrDefault(op => op.OperationId.Equals(export.QuickUpdateId)) : null;
                    var unpack = !export.QuickUnpackId.Equals(Guid.Empty) ? _operations.FirstOrDefault(op => op.OperationId.Equals(export.QuickUnpackId)) : null;
                    var pack = !export.QuickPackId.Equals(Guid.Empty) ? _operations.FirstOrDefault(op => op.OperationId.Equals(export.QuickPackId)) : null;

                    // reorder quick actions
                    var temp = new List<Operation>();
                    if(update != null) { temp.Add(update); }
                    temp.Add(export);
                    if (unpack != null) { temp.Add(unpack); }
                    if (pack != null) { temp.Add(pack); }

                    _operations = temp;
                }

                OnOperations?.Invoke(this, _operations);
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void HandleSelectedOperationEvent(object sender, Operation operation)
        {
            _operations.Add(operation);
            btnClose.Enabled = true;

            if(operation.OperationType.Equals(OperationType.PUBLISH))
            {
                btnClose.PerformClick();
            }
        }

        private void HandleRemoveOperationEvent(object sender, Operation operation)
        {
            var remove = _operations.FirstOrDefault(op => op.OperationId.Equals(operation.OperationId));
            if (remove != null)
            {
                _operations.Remove(remove);
            }
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

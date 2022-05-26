using System;
using System.Windows.Forms;

using Dataverse.XrmTools.Deployer.Helpers;
using Dataverse.XrmTools.Deployer.Controls;
using Dataverse.XrmTools.Deployer.HandlerArgs;
using System.Collections.Generic;
using Dataverse.XrmTools.Deployer.Models;

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

        public AddOperation(Logger logger)
        {
            _logger = logger;

            InitializeComponent();

            btnClose.Enabled = false;
        }

        private void rbExport_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if(radio.Checked)
            {
                pnlOperationDetails.Controls.Clear();
                var export = new ExportOptions(_logger);
                pnlOperationDetails.Controls.Add(export);
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
                    case Enums.OperationType.EXPORT:
                        var exportArgs = new ExportEventArgs
                        {
                            Solution = _opArgs.Solution
                        };

                        OnExport?.Invoke(this, exportArgs);
                        break;
                    case Enums.OperationType.IMPORT:
                        var importArgs = new ImportEventArgs
                        {
                            Solution = _opArgs.Solution
                        };

                        OnImport?.Invoke(this, importArgs);
                        break;
                    case Enums.OperationType.DELETE:
                        var deleteArgs = new DeleteEventArgs
                        {
                            Solution = _opArgs.Solution
                        };

                        OnDelete?.Invoke(this, deleteArgs);
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

        private IEnumerable<Solution> HandleRetrieveSolutionsEvent()
        {
            return OnSolutionsRetrieve?.Invoke();
        }
    }
}

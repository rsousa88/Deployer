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
    public partial class OperationDetails : Form
    {
        private readonly Logger _logger;
        private readonly Operation _operation;

        public OperationDetails(Logger logger, Operation operation)
        {
            _logger = logger;
            _operation = operation;

            InitializeComponent();

            LoadOperationControl();
        }

        private void LoadOperationControl()
        {
            pnlBody.Controls.Clear();

            var control = new UserControl();
            switch (_operation.OperationType)
            {
                case OperationType.UPDATE:
                    var update = _operation as UpdateOperation;
                    control = new UpdateDetails(_logger, update);
                    break;
                case OperationType.EXPORT:
                    var export = _operation as ExportOperation;
                    control = new ExportDetails(_logger, export);
                    break;
                //case OperationType.IMPORT:
                //    var import = operation as ImportOperation;
                //    break;
                case OperationType.DELETE:
                    control = new DeleteDetails(_logger, _operation);
                    break;
                //case OperationType.UNPACK:
                //    var unpack = operation as UnpackOperation;
                //    break;
                //case OperationType.PACK:
                //    var pack = operation as PackOperation;
                //    break;
                //case OperationType.PUBLISH:
                //    break;
                default:
                    break;
            }

            pnlBody.Controls.Add(control);
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}

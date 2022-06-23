// System
using System;
using System.Windows.Forms;

// Dataverse
using Dataverse.XrmTools.Deployer.Enums;
using Dataverse.XrmTools.Deployer.Models;
using Dataverse.XrmTools.Deployer.Helpers;

namespace Dataverse.XrmTools.Deployer.Controls
{
    public partial class PublishOptions : UserControl
    {
        private readonly Logger _logger;

        public event EventHandler<Operation> OnOperationSelected;
        public event EventHandler<Operation> OnOperationRemoved;

        private Operation _publish;

        public PublishOptions(Logger logger)
        {
            _logger = logger;

            InitializeComponent();
        }

        private void btnPublish_Click(object sender, EventArgs e)
        {
            if (_publish != null) { OnOperationRemoved?.Invoke(this, _publish); }

            _publish = new Operation
            {
                OperationType = OperationType.PUBLISH
            };

            OnOperationSelected?.Invoke(this, _publish);
        }
    }
}

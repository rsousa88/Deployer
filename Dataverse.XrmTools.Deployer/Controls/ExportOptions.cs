// System
using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using System.Windows.Forms;
using System.IO.Compression;

// Dataverse
using Dataverse.XrmTools.Deployer.Enums;
using Dataverse.XrmTools.Deployer.Models;
using Dataverse.XrmTools.Deployer.Helpers;
using Dataverse.XrmTools.Deployer.HandlerArgs;

namespace Dataverse.XrmTools.Deployer.Controls
{
    public partial class ExportOptions : UserControl
    {
        private readonly Logger _logger;
        public event EventHandler<OperationEventArgs> OnOperationSelected;

        public ExportOptions(Logger logger)
        {
            _logger = logger;

            InitializeComponent();

            //gbSolutionInfo.Enabled = false;
            gbExportSettings.Enabled = false;
        }

        private void btnAddSolution_Click(object sender, EventArgs e)
        {
            try
            {
                
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.ERROR, ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

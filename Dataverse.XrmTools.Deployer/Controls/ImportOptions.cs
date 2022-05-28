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
using System.Collections.Generic;

namespace Dataverse.XrmTools.Deployer.Controls
{
    public partial class ImportOptions : UserControl
    {
        private readonly Logger _logger;
        public event OperationsRetrieve OnOperationsRetrieveRequested;
        public event EventHandler<Operation> OnOperationSelected;

        private IEnumerable<Operation> _operations;

        public ImportOptions(Logger logger)
        {
            _logger = logger;

            InitializeComponent();

            gbImportFromQueue.Enabled = false;
        }

        private void btnAddSolution_Click(object sender, EventArgs e)
        {
            try
            {
                var solution = GetSolutionData();
                if (solution != null)
                {
                    lblSolutionIdValue.Text = solution.SolutionId.ToString();
                    lblLogicalNameValue.Text = solution.LogicalName;
                    lblDisplayNameValue.Text = solution.DisplayName;
                    lblVersionValue.Text = solution.Version;
                    lblManagedValue.Text = solution.IsManaged.ToString();
                    lblPublisherValue.Text = solution.Publisher.DisplayName;

                    var import = new Operation
                    {
                        OperationType = OperationType.IMPORT,
                        Solution = solution
                    };

                    OnOperationSelected?.Invoke(this, import);
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.ERROR, ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private Solution GetSolutionData()
        {
            _logger.Log(LogLevel.DEBUG, $"Loading solution file...");

            var dialog = new OpenFileDialog
            {
                Title = "Select solution file...",
                Filter = "Zip files (*.zip)|*.zip",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            var path = GetFileDialogPath(dialog);
            if (string.IsNullOrEmpty(path)) { return null; }

            txtImportPathValue.Text = path;

            // read solution data
            XDocument doc;
            using (var zip = ZipFile.Open(path, ZipArchiveMode.Read))
            {
                var file = zip.Entries.FirstOrDefault(ent => ent.Name.Equals("solution.xml"));
                if (file is null) { throw new Exception("Invalid solution file"); }

                using (var stream = file.Open())
                {
                    doc = XDocument.Load(stream);
                }
            }

            if (doc is null) { throw new Exception("Invalid solution file"); }

            var solManifestNodes = doc.Descendants("SolutionManifest");
            var solDisplayNames = solManifestNodes.Select(node => node.Element("LocalizedNames")).FirstOrDefault().Descendants();
            var publisherNodes = solManifestNodes.Select(node => node.Element("Publisher")).FirstOrDefault().Descendants();
            var pubDisplayNames = publisherNodes.FirstOrDefault(node => node.Name.LocalName.Equals("LocalizedNames")).Descendants();

            var package = new Package
            {
                PackageType = solManifestNodes.Select(node => node.Element("Managed")).FirstOrDefault().Value.Equals("1") ? PackageType.MANAGED : PackageType.UNMANAGED,
                SolutionBytes = File.ReadAllBytes(path),
                ExportPath = path
            };

            return new Solution
            {
                LogicalName = solManifestNodes.Select(node => node.Element("UniqueName")).FirstOrDefault().Value,
                DisplayName = solDisplayNames.FirstOrDefault(node => node.Attribute("languagecode").Value.Equals("1033")).Attribute("description").Value,
                Version = solManifestNodes.Select(node => node.Element("Version")).FirstOrDefault().Value,
                IsManaged = package.PackageType.Equals(PackageType.MANAGED) ? true : false,
                Publisher = new Publisher
                {
                    LogicalName = publisherNodes.FirstOrDefault(node => node.Name.LocalName.Equals("UniqueName")).Value,
                    DisplayName = pubDisplayNames.FirstOrDefault(node => node.Attribute("languagecode").Value.Equals("1033")).Attribute("description").Value
                },
                Package = package
            };
        }

        private string GetFileDialogPath(FileDialog dialog)
        {
            var path = string.Empty;

            using (var ofd = dialog as OpenFileDialog)
            {
                if (ofd.ShowDialog(this) == DialogResult.OK)
                {
                    path = ofd.FileName;
                }
            }

            return path;
        }

        private void rbImportFromFile_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if (radio.Checked)
            {
                gbImportFromFile.Enabled = true;
                gbImportFromQueue.Enabled = false;
            }
        }

        private void rbImportFromQueue_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if (radio.Checked)
            {
                gbImportFromFile.Enabled = false;
                gbImportFromQueue.Enabled = true;

                _operations = OnOperationsRetrieveRequested?.Invoke(OperationType.EXPORT);
                LoadOperationsList();
            }
        }

        private void LoadOperationsList()
        {
            lvOperations.Items.Clear();

            var items = _operations
                .Select(op => op.ToListViewItem())
                .ToArray();

            lvOperations.Items.AddRange(items);
        }

        private void lvOperations_Resize(object sender, EventArgs e)
        {
            var maxWidth = lvOperations.Width >= 433 ? lvOperations.Width : 433;
            chOpDisplayName.Width = (int)Math.Floor(maxWidth * 0.59);
            chOpLogicalName.Width = (int)Math.Floor(maxWidth * 0.39);
        }

        private void lvOperations_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvOperations.SelectedItems.Count > 0)
            {
                var operation = lvOperations.SelectedItems[0].ToObject(new Operation()) as Operation;

                var import = new Operation
                {
                    OperationType = OperationType.IMPORT,
                    Solution = operation.Solution
                };

                OnOperationSelected?.Invoke(this, import);
            }
        }
    }
}

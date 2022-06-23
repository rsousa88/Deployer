// System
using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using System.Windows.Forms;
using System.IO.Compression;
using System.Collections.Generic;

// Dataverse
using Dataverse.XrmTools.Deployer.Enums;
using Dataverse.XrmTools.Deployer.Models;
using Dataverse.XrmTools.Deployer.Helpers;

namespace Dataverse.XrmTools.Deployer.Controls
{
    public partial class ImportOptions : UserControl
    {
        private readonly Logger _logger;
        public event SingleSolutionRetrieve OnSingleSolutionRetrieveRequested;
        public event OperationsRetrieve OnOperationsRetrieveRequested;
        public event EventHandler<Operation> OnOperationSelected;
        public event EventHandler<Operation> OnOperationUpdated;
        public event EventHandler<Operation> OnOperationRemoved;

        private IEnumerable<Operation> _operations;
        private ImportOperation _import;

        public ImportOptions(Logger logger)
        {
            _logger = logger;

            InitializeComponent();

            gbImportFromQueue.Enabled = false;
            gbSolutionInfo.Enabled = false;
            gbImportSettings.Enabled = false;
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

                    var existing = OnSingleSolutionRetrieveRequested?.Invoke(solution.LogicalName, ConnectionType.TARGET);

                    if (_import != null) { OnOperationRemoved?.Invoke(this, _import); }

                    _import = new ImportOperation
                    {
                        OperationType = OperationType.IMPORT,
                        Solution = solution,
                        HoldingSolution = existing != null ? true : false,
                        OverwriteUnmanaged = true,
                        PublishWorkflows = true
                    };

                    if (existing != null)
                    {
                        lblExistingValue.Text = "Yes";
                        chbHoldingSolution.Checked = true;
                        chbHoldingSolution.Enabled = true;
                    }
                    else
                    {
                        lblExistingValue.Text = "No";
                        chbHoldingSolution.Checked = false;
                        chbHoldingSolution.Enabled = false;
                    }

                    gbSolutionInfo.Enabled = true;
                    gbImportSettings.Enabled = true;

                    OnOperationSelected?.Invoke(this, _import);
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
            var path = this.SelectFile("Zip files (*.zip)|*.zip");
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
            var displayNameNode = solDisplayNames.FirstOrDefault(node => node.Attribute("languagecode").Value.Equals("1033"));
            var publisherNodes = solManifestNodes.Select(node => node.Element("Publisher")).FirstOrDefault().Descendants();
            var pubDisplayNames = publisherNodes.FirstOrDefault(node => node.Name.LocalName.Equals("LocalizedNames")).Descendants();

            var package = new Package
            {
                Type = solManifestNodes.Select(node => node.Element("Managed")).FirstOrDefault().Value.Equals("1") ? PackageType.MANAGED : PackageType.UNMANAGED,
                Bytes = File.ReadAllBytes(path),
                //ExportPath = path
            };

            return new Solution
            {
                LogicalName = solManifestNodes.Select(node => node.Element("UniqueName")).FirstOrDefault().Value,
                DisplayName = displayNameNode is null ? "N/A" : displayNameNode.Attribute("description").Value,
                Version = solManifestNodes.Select(node => node.Element("Version")).FirstOrDefault().Value,
                IsManaged = package.Type.Equals(PackageType.MANAGED) ? true : false,
                Publisher = new Publisher
                {
                    LogicalName = publisherNodes.FirstOrDefault(node => node.Name.LocalName.Equals("UniqueName")).Value,
                    DisplayName = pubDisplayNames.FirstOrDefault(node => node.Attribute("languagecode").Value.Equals("1033")).Attribute("description").Value
                },
                Package = package
            };
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

            var items = _operations.Select(op => {
                var item = new ListViewItem(new string[] {
                    op.Solution.DisplayName,
                    op.Solution.LogicalName
                });

                item.Tag = op;

                return item;
            }).ToArray();

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

                lblSolutionIdValue.Text = operation.Solution.SolutionId.ToString();
                lblLogicalNameValue.Text = operation.Solution.LogicalName;
                lblDisplayNameValue.Text = operation.Solution.DisplayName;
                lblVersionValue.Text = operation.Solution.Version;
                lblManagedValue.Text = operation.Solution.IsManaged.ToString();
                lblPublisherValue.Text = operation.Solution.Publisher.DisplayName;

                var existing = OnSingleSolutionRetrieveRequested?.Invoke(operation.Solution.LogicalName, ConnectionType.TARGET);

                if (_import != null) { OnOperationRemoved?.Invoke(this, _import); }

                _import = new ImportOperation
                {
                    OperationType = OperationType.IMPORT,
                    Solution = operation.Solution,
                    HoldingSolution = existing != null ? true : false,
                    OverwriteUnmanaged = true,
                    PublishWorkflows = true
                };

                if (existing != null)
                {
                    lblExistingValue.Text = "Yes";
                    chbHoldingSolution.Checked = true;
                    chbHoldingSolution.Enabled = true;
                }
                else
                {
                    lblExistingValue.Text = "No";
                    chbHoldingSolution.Checked = false;
                    chbHoldingSolution.Enabled = false;
                }

                gbSolutionInfo.Enabled = true;
                gbImportSettings.Enabled = true;

                OnOperationSelected?.Invoke(this, _import);
            }
        }

        private void OptionsUpdated_CheckedChanged(object sender, EventArgs e)
        {
            var checkbox = sender as CheckBox;

            _import.HoldingSolution = chbHoldingSolution.Checked;
            _import.OverwriteUnmanaged = chbOverwriteUnmanaged.Checked;
            _import.PublishWorkflows = chbPublishWorkflows.Checked;

            OnOperationUpdated?.Invoke(this, _import);
        }
    }
}

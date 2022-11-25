using Dataverse.XrmTools.Deployer.Enums;
using Dataverse.XrmTools.Deployer.Helpers;
using Dataverse.XrmTools.Deployer.Models;
using Dataverse.XrmTools.Deployer.Repositories;
using Microsoft.Xrm.Tooling.Connector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Dataverse.XrmTools.Deployer.Controls
{
    public partial class ImportControl : UserControl
    {
        private readonly Logger _logger;
        private IEnumerable<ExportOperation> _exports;
        private IList<ImportOperation> _imports;
        private CrmServiceClient _target;

        // events
        public event EventHandler<IEnumerable<ImportOperation>> OnAddToQueue_Import;

        public delegate Solution SingleSolutionRetrieve(string logicalName, ConnectionType connType);
        public event SingleSolutionRetrieve OnTargetSolutionRetrieveRequested;

        public ImportControl(Logger logger, IEnumerable<ExportOperation> exports, CrmServiceClient target)
        {
            _logger = logger;
            _exports = exports;
            _target = target;

            Dock = DockStyle.Fill;
            InitializeComponent();

            gbImportFromFile.Enabled = true;
            lvOperations.Enabled = false;

            gbImportSettings.Enabled = false;
            lvImportQueue.Enabled = false;
            btnAddToQueue.Enabled = false;
        }

        // Event Handlers
        private void lvOperations_Resize(object sender, EventArgs e)
        {
            var maxWidth = lvOperations.Width >= 400 ? lvOperations.Width : 400;
            chOpDisplayName.Width = (int)Math.Floor(maxWidth * 0.50);
            chOpLogicalName.Width = (int)Math.Floor(maxWidth * 0.40);
        }

        private void lvImportQueue_Resize(object sender, EventArgs e)
        {
            var maxWidth = lvOperations.Width >= 800 ? lvOperations.Width : 800;
            chImpQueIndex.Width = (int)Math.Floor(maxWidth * 0.10);
            chImpQueDisplayName.Width = (int)Math.Floor(maxWidth * 0.80);
        }

        private void rbImportFromFile_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if (radio.Checked)
            {
                gbImportFromFile.Enabled = true;
                lvOperations.Enabled = false;
            }
        }

        private void btnAddSolutionFile_Click(object sender, EventArgs e)
        {
            try
            {
                if(_imports is null) { _imports = new List<ImportOperation>(); }

                var path = GetSolutionFilePath();
                var solution = GetSolutionData(path);
                if (solution != null)
                {
                    var package = new Package
                    {
                        Type = solution.IsManaged ? PackageType.MANAGED : PackageType.UNMANAGED,
                        Name = solution.LogicalName,
                        Path = path
                    };

                    var existing = OnTargetSolutionRetrieveRequested?.Invoke(solution.LogicalName, ConnectionType.TARGET);

                    var import = new ImportOperation
                    {
                        OperationType = OperationType.IMPORT,
                        Solution = solution,
                        Package = package,
                        HoldingSolution = existing != null ? true : false,
                        OverwriteUnmanaged = true,
                        PublishWorkflows = true
                    };

                    if (_imports.Any(imp => imp.Solution.LogicalName.Equals(import.Solution.LogicalName)))
                    {
                        throw new Exception($"An operation of type '{import.OperationType}' on solution '{import.Solution.DisplayName}' is already added to import queue");
                    }

                    import.Index = lvImportQueue.Items.Count + 1;

                    _imports.Add(import);

                    var importLvi = new ListViewItem(new string[] {
                        import.Index.ToString(),
                        import.Solution != null ? import.Solution.DisplayName : "-"
                    });

                    importLvi.Tag = import;

                    lvImportQueue.Items.Add(importLvi);

                    _logger.Log(LogLevel.INFO, $"Added '{import.OperationType}' operation on solution '{import.Solution.DisplayName}' to import queue");

                    gbImportSettings.Enabled = true;
                    lvImportQueue.Enabled = true;
                    btnAddToQueue.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.ERROR, ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetSolutionFilePath()
        {
            _logger.Log(LogLevel.DEBUG, $"Loading solution file...");
            var path = this.SelectFile("Zip files (*.zip)|*.zip");
            if (string.IsNullOrEmpty(path)) { return null; }

            return path;
        }

        private Solution GetSolutionData(string path)
        {
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

            return new Solution
            {
                LogicalName = solManifestNodes.Select(node => node.Element("UniqueName")).FirstOrDefault().Value,
                DisplayName = displayNameNode is null ? "N/A" : displayNameNode.Attribute("description").Value,
                Version = solManifestNodes.Select(node => node.Element("Version")).FirstOrDefault().Value,
                IsManaged = solManifestNodes.Select(node => node.Element("Managed")).FirstOrDefault().Value.Equals("1") ? true : false,
                Publisher = new Publisher
                {
                    LogicalName = publisherNodes.FirstOrDefault(node => node.Name.LocalName.Equals("UniqueName")).Value,
                    DisplayName = pubDisplayNames.FirstOrDefault(node => node.Attribute("languagecode").Value.Equals("1033")).Attribute("description").Value
                }
            };
        }

        private void rbImportFromQueue_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if (radio.Checked)
            {
                lvOperations.Items.Clear();

                var items = _exports.Select(exp => {
                    var item = new ListViewItem(new string[] {
                        exp.Solution.DisplayName,
                        exp.Solution.LogicalName
                    });

                    item.Tag = exp;

                    return item;
                }).ToArray();

                lvOperations.Items.AddRange(items);

                gbImportFromFile.Enabled = false;
                lvOperations.Enabled = true;
            }
        }

        private void lvOperations_DoubleClick(object sender, EventArgs e)
        {
            if (_imports is null) { _imports = new List<ImportOperation>(); }

            if (lvOperations.SelectedItems.Count.Equals(0)) { return; }

            var export = lvOperations.SelectedItems[0].ToObject(new Operation()) as ExportOperation;

            var existing = OnTargetSolutionRetrieveRequested?.Invoke(export.Solution.LogicalName, ConnectionType.TARGET);

            var import = new ImportOperation
            {
                OperationType = OperationType.IMPORT,
                Solution = export.Solution,
                Package = new Package
                {
                    Type = export.PackageType,
                    Name = export.Solution.LogicalName,
                    Path = export.PackagePath
                },
                HoldingSolution = existing != null ? true : false,
                OverwriteUnmanaged = chbOverwriteUnmanaged.Checked,
                PublishWorkflows = chbPublishWorkflows.Checked
            };

            if (_imports.Any(imp => imp.Solution.LogicalName.Equals(import.Solution.LogicalName)))
            {
                throw new Exception($"An operation of type '{import.OperationType}' on solution '{import.Solution.DisplayName}' is already added to import queue");
            }

            import.Index = lvImportQueue.Items.Count + 1;

            _imports.Add(import);

            var importLvi = new ListViewItem(new string[] {
                import.Index.ToString(),
                import.Solution != null ? import.Solution.DisplayName : "-"
            });

            importLvi.Tag = import;

            lvImportQueue.Items.Add(importLvi);

            _logger.Log(LogLevel.INFO, $"Added '{import.OperationType}' operation on solution '{import.Solution.DisplayName}' to import queue");

            gbImportSettings.Enabled = true;
            lvImportQueue.Enabled = true;
            btnAddToQueue.Enabled = true;
        }

        private void chbOverwriteUnmanaged_CheckedChanged(object sender, EventArgs e)
        {
            if (_imports != null && _imports.Count > 0)
            {
                foreach (var export in _imports)
                {
                    export.OverwriteUnmanaged = chbOverwriteUnmanaged.Checked;
                }
            }
        }

        private void chbPublishWorkflows_CheckedChanged(object sender, EventArgs e)
        {
            if (_imports != null && _imports.Count > 0)
            {
                foreach (var export in _imports)
                {
                    export.PublishWorkflows = chbPublishWorkflows.Checked;
                }
            }
        }

        private void btnAddToQueue_Click(object sender, EventArgs e)
        {
            OnAddToQueue_Import?.Invoke(this, _imports);
        }
    }
}

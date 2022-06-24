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
using Dataverse.XrmTools.Deployer.AppSettings;

namespace Dataverse.XrmTools.Deployer.Controls
{
    public partial class UnpackOptions : UserControl
    {
        private readonly Logger _logger;
        public event OperationsRetrieve OnOperationsRetrieveRequested;
        public event EventHandler<Operation> OnOperationSelected;
        public event EventHandler<Operation> OnOperationRemoved;

        private IEnumerable<Operation> _operations;
        private Settings _settings;
        private UnpackOperation _unpack;

        public UnpackOptions(Logger logger, Settings settings)
        {
            _logger = logger;
            _settings = settings;

            InitializeComponent();

            gbUnpackFromQueue.Enabled = false;
            gbSolutionInfo.Enabled = false;
            gbUnpackSettings.Enabled = false;

            if (!string.IsNullOrEmpty(_settings.Defaults.UnpackPath)) { txtOutputDirPathValue.Text = _settings.Defaults.UnpackPath; }
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

                    if (_unpack != null) { OnOperationRemoved?.Invoke(this, _unpack); }

                    _unpack = new UnpackOperation
                    {
                        OperationType = OperationType.UNPACK,
                        Solution = solution,
                        Mode = OperationMode.EXPLORER,
                        Action = "Extract",
                        WorkingDir = _settings.WorkingDirectory,
                        Packager = _settings.PackagerPath,
                        Folder = txtOutputDirPathValue.Text,
                        PackageType = solution.IsManaged ? "Managed" : "Unmanaged",
                        ZipFile = txtSolutionFilePathValue.Text,
                        Map = string.Empty
                    };

                    gbSolutionInfo.Enabled = true;
                    gbUnpackSettings.Enabled = true;

                    OnOperationSelected?.Invoke(this, _unpack);
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

            txtSolutionFilePathValue.Text = path;

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
                Bytes = File.ReadAllBytes(path)
            };

            var logicalName = solManifestNodes.Select(node => node.Element("UniqueName")).FirstOrDefault().Value;

            return new Solution
            {
                LogicalName = logicalName,
                DisplayName = displayNameNode is null ? logicalName : displayNameNode.Attribute("description").Value,
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

        private void rbUnpackFromFile_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if (radio.Checked)
            {
                gbUnpackFromFile.Enabled = true;
                gbUnpackFromQueue.Enabled = false;
            }
        }

        private void rbUnpackFromQueue_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if (radio.Checked)
            {
                gbUnpackFromFile.Enabled = false;
                gbUnpackFromQueue.Enabled = true;

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
                var export = lvOperations.SelectedItems[0].ToObject(new Operation()) as ExportOperation;

                lblSolutionIdValue.Text = export.Solution.SolutionId.ToString();
                lblLogicalNameValue.Text = export.Solution.LogicalName;
                lblDisplayNameValue.Text = export.Solution.DisplayName;
                lblVersionValue.Text = export.Solution.Version;
                lblManagedValue.Text = export.Solution.Package.Type.Equals(PackageType.MANAGED) ? "Yes" : "No";
                lblPublisherValue.Text = export.Solution.Publisher.DisplayName;

                if (_unpack != null) { OnOperationRemoved?.Invoke(this, _unpack); }

                _unpack = new UnpackOperation
                {
                    OperationType = OperationType.UNPACK,
                    Solution = export.Solution,
                    Mode = OperationMode.QUEUE,
                    Action = "Extract",
                    WorkingDir = _settings.WorkingDirectory,
                    Packager = _settings.PackagerPath,
                    Folder = txtOutputDirPathValue.Text,
                    PackageType = export.Solution.Package.Type.Equals(PackageType.MANAGED) ? "Managed" : "Unmanaged",
                    ZipFile = export.Solution.Package.Path,
                    Map = string.Empty
                };

                gbSolutionInfo.Enabled = true;
                gbUnpackSettings.Enabled = true;

                OnOperationSelected?.Invoke(this, _unpack);
            }
        }

        private void btnSetOutputPath_Click(object sender, EventArgs e)
        {
            try
            {
                var dirPath = Handle.SelectDirectory(_settings.Defaults.UnpackPath);
                if (string.IsNullOrEmpty(dirPath)) { return; }

                txtOutputDirPathValue.Text = dirPath;

                _settings.Defaults.UnpackPath = dirPath;
                _settings.SaveSettings();

                _unpack.Folder = dirPath;
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.ERROR, ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

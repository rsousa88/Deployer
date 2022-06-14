// System
using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Xml.Linq;
using System.Windows.Forms;
using System.Collections.Generic;

// Dataverse
using Dataverse.XrmTools.Deployer.Enums;
using Dataverse.XrmTools.Deployer.Models;
using Dataverse.XrmTools.Deployer.Helpers;
using Dataverse.XrmTools.Deployer.AppSettings;

namespace Dataverse.XrmTools.Deployer.Controls
{
    public partial class PackOptions : UserControl
    {
        private readonly Logger _logger;
        public event OperationsRetrieve OnOperationsRetrieveRequested;
        public event EventHandler<Operation> OnOperationSelected;
        public event EventHandler<Operation> OnOperationUpdated;
        public event WorkingStateSet OnWorkingStateSetRequested;

        private IEnumerable<Operation> _operations;
        private Settings _settings;
        private PackOperation _pack;

        public PackOptions(Logger logger, Settings settings)
        {
            _logger = logger;
            _settings = settings;

            InitializeComponent();

            gbPackFromQueue.Enabled = false;
            gbSolutionInfo.Enabled = false;
            gbPackSettings.Enabled = false;

            if (!string.IsNullOrEmpty(_settings.DefaultPackPath)) { txtOutputSolutionFilePathValue.Text = _settings.DefaultPackPath; }
        }

        private void btnAddSourceDir_Click(object sender, EventArgs e)
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

                    _pack = new PackOperation
                    {
                        OperationType = OperationType.PACK,
                        Solution = solution,
                        Action = "Pack",
                        WorkingDir = _settings.WorkingDirectory,
                        Packager = _settings.PackagerPath,
                        PackageType = solution.IsManaged ? "Managed" : "Unmanaged",
                        ZipFile = $"{txtOutputSolutionFilePathValue.Text}\\{solution.Package.Name}",
                        Folder = txtOutputDirPathValue.Text,
                        Map = string.Empty
                    };

                    gbSolutionInfo.Enabled = true;
                    gbPackSettings.Enabled = true;

                    OnOperationSelected?.Invoke(this, _pack);
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
            _logger.Log(LogLevel.DEBUG, $"Loading source directory...");

            var dirPath = string.Empty;
            using (var fbd = new FolderBrowserDialog())
            {
                fbd.Description = "Select source directory";
                if (fbd.ShowDialog(this) == DialogResult.OK)
                {
                    dirPath = fbd.SelectedPath;
                }
            }

            if (string.IsNullOrEmpty(dirPath)) { return null; }
            txtOutputDirPathValue.Text = dirPath;

            // read solution data
            var filePath = $"{dirPath}\\Other\\Solution.xml";

            if (!Directory.Exists($"{dirPath}\\Other") || !File.Exists(filePath))
            {
                throw new Exception("Invalid source directory");
            }

            XDocument doc;
            using (var stream = new FileStream(filePath, FileMode.Open))
            {
                doc = XDocument.Load(stream);
            }

            if (doc is null) { throw new Exception("Invalid solution file"); }

            var solManifestNodes = doc.Descendants("SolutionManifest");
            var solDisplayNames = solManifestNodes.Select(node => node.Element("LocalizedNames")).FirstOrDefault().Descendants();
            var displayNameNode = solDisplayNames.FirstOrDefault(node => node.Attribute("languagecode").Value.Equals("1033"));
            var publisherNodes = solManifestNodes.Select(node => node.Element("Publisher")).FirstOrDefault().Descendants();
            var pubDisplayNames = publisherNodes.FirstOrDefault(node => node.Name.LocalName.Equals("LocalizedNames")).Descendants();

            var logicalName = solManifestNodes.Select(node => node.Element("UniqueName")).FirstOrDefault().Value;
            var solution = new Solution
            {
                LogicalName = logicalName,
                DisplayName = displayNameNode is null ? logicalName : displayNameNode.Attribute("description").Value,
                Version = solManifestNodes.Select(node => node.Element("Version")).FirstOrDefault().Value,
                Publisher = new Publisher
                {
                    LogicalName = publisherNodes.FirstOrDefault(node => node.Name.LocalName.Equals("UniqueName")).Value,
                    DisplayName = pubDisplayNames.FirstOrDefault(node => node.Attribute("languagecode").Value.Equals("1033")).Attribute("description").Value
                },
                Package = new Package
                {
                    Type = solManifestNodes.Select(node => node.Element("Managed")).FirstOrDefault().Value.Equals("1") ? PackageType.MANAGED : PackageType.UNMANAGED,
                    //ExportPath = dirPath
                }
            };

            solution.IsManaged = solution.Package.Type.Equals(PackageType.MANAGED) ? true : false;

            var suffix = solution.Package.Type.Equals(PackageType.MANAGED) ? "_managed.zip" : ".zip";
            solution.Package.Name = $"{solution.LogicalName}_{solution.Version}{suffix}";

            return solution;
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

        private void rbPackFromDir_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if (radio.Checked)
            {
                gbPackFromDir.Enabled = true;
                gbPackFromQueue.Enabled = false;
            }
        }

        private void rbPackFromQueue_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if (radio.Checked)
            {
                gbPackFromDir.Enabled = false;
                gbPackFromQueue.Enabled = true;

                _operations = OnOperationsRetrieveRequested?.Invoke(OperationType.UNPACK);
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
                var unpack = lvOperations.SelectedItems[0].ToObject(new Operation()) as UnpackOperation;

                lblSolutionIdValue.Text = unpack.Solution.SolutionId.ToString();
                lblLogicalNameValue.Text = unpack.Solution.LogicalName;
                lblDisplayNameValue.Text = unpack.Solution.DisplayName;
                lblVersionValue.Text = unpack.Solution.Version;
                lblManagedValue.Text = unpack.Solution.Package.Type.Equals(PackageType.MANAGED) ? "Yes" : "No";
                lblPublisherValue.Text = unpack.Solution.Publisher.DisplayName;

                _pack = new PackOperation
                {
                    OperationType = OperationType.PACK,
                    Solution = unpack.Solution,
                    Action = "Pack",
                    WorkingDir = unpack.WorkingDir,
                    Packager = _settings.PackagerPath,
                    PackageType = unpack.PackageType,
                    ZipFile = $"{txtOutputSolutionFilePathValue.Text}\\{unpack.Solution.Package.Name}",
                    Folder = unpack.Folder,
                    Map = string.Empty
                };

                gbSolutionInfo.Enabled = true;
                gbPackSettings.Enabled = true;

                OnOperationSelected?.Invoke(this, _pack);
            }
        }

        private void btnSetPackagerPath_Click(object sender, EventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Title = "Select solution packager executable...",
                Filter = "Exe files (*.exe)|*.exe",
                FilterIndex = 2,
                RestoreDirectory = true
            };

            var packager = GetFileDialogPath(dialog);
            if (string.IsNullOrEmpty(packager))
            {
                throw new Exception("Invalid file path");
            }

            var toolsDir = Path.GetDirectoryName(packager);
            _pack.WorkingDir = toolsDir;
            _pack.Packager = packager;

            _settings.WorkingDirectory = toolsDir;
            _settings.PackagerPath = packager;

            _settings.SaveSettings();

            OnOperationUpdated?.Invoke(this, _pack);
        }

        private void btnSetOutputPath_Click(object sender, EventArgs e)
        {
            try
            {
                var tag = (sender as Button).Tag as string;

                var dirPath = string.Empty;
                using (var fbd = new FolderBrowserDialog())
                {
                    fbd.Description = "Select export directory";

                    if (fbd.ShowDialog(this) == DialogResult.OK)
                    {
                        dirPath = fbd.SelectedPath;
                    }
                }

                if (string.IsNullOrEmpty(dirPath))
                {
                    throw new Exception("Invalid directory path");
                }

                txtOutputSolutionFilePathValue.Text = dirPath;

                _settings.DefaultPackPath = dirPath;
                _settings.SaveSettings();

                var suffix = _pack.Solution.Package.Type.Equals(PackageType.MANAGED) ? "_managed.zip" : ".zip";
                var name = $"{_pack.Solution.LogicalName}_{_pack.Solution.Version}{suffix}";

                _pack.Solution.Package.Name = name;
                _pack.Solution.Package.Path = $"{dirPath}\\{name}";

                OnOperationUpdated?.Invoke(this, _pack);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.ERROR, ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

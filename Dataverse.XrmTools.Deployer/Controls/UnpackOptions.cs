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
using Dataverse.XrmTools.Deployer.Repositories;

namespace Dataverse.XrmTools.Deployer.Controls
{
    public partial class UnpackOptions : UserControl
    {
        private readonly Logger _logger;
        public event OperationsRetrieve OnOperationsRetrieveRequested;
        public event EventHandler<Operation> OnOperationSelected;
        public event EventHandler<Operation> OnOperationUpdated;
        public event WorkingStateSet OnWorkingStateSetRequested;

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

            if (!string.IsNullOrEmpty(_settings.UnpackPath)) { txtOutputPathValue.Text = _settings.UnpackPath; }
            if (!string.IsNullOrEmpty(_settings.PackagerPath)) { txtPackagerPathValue.Text = _settings.PackagerPath; }
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

                    _unpack = new UnpackOperation
                    {
                        OperationType = OperationType.UNPACK,
                        Solution = solution,
                        Action = "Extract",
                        WorkingDir = _settings.WorkingDirectory,
                        Packager = txtPackagerPathValue.Text,
                        Folder = txtOutputPathValue.Text,
                        PackageType = solution.IsManaged ? "Managed" : "Unmanaged",
                        ZipFile = $"{solution.Package.ExportPath}\\{solution.Package.Name}",
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
            var displayNameNode = solDisplayNames.FirstOrDefault(node => node.Attribute("languagecode").Value.Equals("1033"));
            var publisherNodes = solManifestNodes.Select(node => node.Element("Publisher")).FirstOrDefault().Descendants();
            var pubDisplayNames = publisherNodes.FirstOrDefault(node => node.Name.LocalName.Equals("LocalizedNames")).Descendants();

            var package = new Package
            {
                Type = solManifestNodes.Select(node => node.Element("Managed")).FirstOrDefault().Value.Equals("1") ? PackageType.MANAGED : PackageType.UNMANAGED,
                Bytes = File.ReadAllBytes(path),
                ExportPath = path
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

        private void rbImportFromFile_CheckedChanged(object sender, EventArgs e)
        {
            var radio = sender as RadioButton;
            if (radio.Checked)
            {
                gbUnpackFromFile.Enabled = true;
                gbUnpackFromQueue.Enabled = false;
            }
        }

        private void rbImportFromQueue_CheckedChanged(object sender, EventArgs e)
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
                var operation = lvOperations.SelectedItems[0].ToObject(new Operation()) as Operation;

                lblSolutionIdValue.Text = operation.Solution.SolutionId.ToString();
                lblLogicalNameValue.Text = operation.Solution.LogicalName;
                lblDisplayNameValue.Text = operation.Solution.DisplayName;
                lblVersionValue.Text = operation.Solution.Version;
                lblManagedValue.Text = operation.Solution.IsManaged.ToString();
                lblPublisherValue.Text = operation.Solution.Publisher.DisplayName;

                _unpack = new UnpackOperation
                {
                    OperationType = OperationType.UNPACK,
                    Solution = operation.Solution,
                    Action = "Extract",
                    WorkingDir = _settings.WorkingDirectory,
                    Packager = txtPackagerPathValue.Text,
                    Folder = txtOutputPathValue.Text,
                    PackageType = operation.Solution.Package.Type.Equals(PackageType.MANAGED) ? "Managed" : "Unmanaged",
                    ZipFile = $"{operation.Solution.Package.ExportPath}\\{operation.Solution.Package.Name}",
                    Map = string.Empty
                };

                gbSolutionInfo.Enabled = true;
                gbUnpackSettings.Enabled = true;

                OnOperationSelected?.Invoke(this, _unpack);
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
            _unpack.WorkingDir = toolsDir;
            _unpack.Packager = packager;

            txtPackagerPathValue.Text = packager;

            _settings.WorkingDirectory = toolsDir;
            _settings.PackagerPath = packager;

            _settings.SaveSettings();

            OnOperationUpdated?.Invoke(this, _unpack);
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

                txtOutputPathValue.Text = dirPath;
                _unpack.Solution.Package.UnpackPath = dirPath;
                _settings.UnpackPath = dirPath;

                _settings.SaveSettings();

                OnOperationUpdated?.Invoke(this, _unpack);
            }
            catch (Exception ex)
            {
                _logger.Log(LogLevel.ERROR, ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void btnDownloadPackager_Click(object sender, EventArgs args)
        {
            _logger.Log(LogLevel.INFO, $"Downloading latest version of Core Tools...");

            var package = "Microsoft.CrmSdk.CoreTools";
            var feed = "https://packages.nuget.org/api/v2";

            var toolsDir = Path.GetDirectoryName(typeof(DeployerControl).Assembly.Location);
            toolsDir = Path.Combine(toolsDir, package);
            Directory.CreateDirectory(toolsDir);

            OnWorkingStateSetRequested?.Invoke(true);

            var repo = new NuGetRepo();
            var packager = await repo.DownloadCoreToolsAsync(toolsDir, feed, package);

            OnWorkingStateSetRequested?.Invoke(false);

            _unpack.WorkingDir = toolsDir;
            _unpack.Packager = packager;

            txtPackagerPathValue.Text = packager;

            _settings.WorkingDirectory = toolsDir;
            _settings.PackagerPath = packager;

            _settings.SaveSettings();

            OnOperationUpdated?.Invoke(this, _unpack);
        }
    }
}

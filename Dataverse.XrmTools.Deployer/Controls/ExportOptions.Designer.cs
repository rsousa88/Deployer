
using Dataverse.XrmTools.Deployer.Helpers;

namespace Dataverse.XrmTools.Deployer.Controls
{
    partial class ExportOptions
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbSolutionInfo = new System.Windows.Forms.GroupBox();
            this.lblSolutionIdValue = new System.Windows.Forms.Label();
            this.lblSolutionId = new System.Windows.Forms.Label();
            this.lblPublisherValue = new System.Windows.Forms.Label();
            this.lblPublisher = new System.Windows.Forms.Label();
            this.lblManagedValue = new System.Windows.Forms.Label();
            this.lblManaged = new System.Windows.Forms.Label();
            this.lblVersionValue = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblDisplayNameValue = new System.Windows.Forms.Label();
            this.lblLogicalNameValue = new System.Windows.Forms.Label();
            this.lblLogicalName = new System.Windows.Forms.Label();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbSolutions = new System.Windows.Forms.GroupBox();
            this.lblSolutionFilter = new System.Windows.Forms.Label();
            this.txtSolutionFilter = new System.Windows.Forms.TextBox();
            this.lvSolutions = new System.Windows.Forms.ListView();
            this.chSolDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolManaged = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolPublisher = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnLoadSolutions = new System.Windows.Forms.Button();
            this.gbExport = new System.Windows.Forms.GroupBox();
            this.gbQuickActions = new System.Windows.Forms.GroupBox();
            this.txtQuickUpdateVersion = new System.Windows.Forms.TextBox();
            this.chbPack = new System.Windows.Forms.CheckBox();
            this.chbUnpack = new System.Windows.Forms.CheckBox();
            this.chbUpdateVersion = new System.Windows.Forms.CheckBox();
            this.gbExportSettings = new System.Windows.Forms.GroupBox();
            this.btnSetSolutionLocation = new System.Windows.Forms.Button();
            this.lblSolutionPath = new System.Windows.Forms.Label();
            this.txtSolutionPathValue = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbManaged = new System.Windows.Forms.RadioButton();
            this.rbUnmanaged = new System.Windows.Forms.RadioButton();
            this.lblType = new System.Windows.Forms.Label();
            this.btnSetUnpackLocation = new System.Windows.Forms.Button();
            this.txtUnpackPathValue = new System.Windows.Forms.TextBox();
            this.txtPackPathValue = new System.Windows.Forms.TextBox();
            this.btnSetPackLocation = new System.Windows.Forms.Button();
            this.gbSolutionInfo.SuspendLayout();
            this.gbSolutions.SuspendLayout();
            this.gbExport.SuspendLayout();
            this.gbQuickActions.SuspendLayout();
            this.gbExportSettings.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbSolutionInfo
            // 
            this.gbSolutionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSolutionInfo.Controls.Add(this.lblSolutionIdValue);
            this.gbSolutionInfo.Controls.Add(this.lblSolutionId);
            this.gbSolutionInfo.Controls.Add(this.lblPublisherValue);
            this.gbSolutionInfo.Controls.Add(this.lblPublisher);
            this.gbSolutionInfo.Controls.Add(this.lblManagedValue);
            this.gbSolutionInfo.Controls.Add(this.lblManaged);
            this.gbSolutionInfo.Controls.Add(this.lblVersionValue);
            this.gbSolutionInfo.Controls.Add(this.lblVersion);
            this.gbSolutionInfo.Controls.Add(this.lblDisplayNameValue);
            this.gbSolutionInfo.Controls.Add(this.lblLogicalNameValue);
            this.gbSolutionInfo.Controls.Add(this.lblLogicalName);
            this.gbSolutionInfo.Controls.Add(this.lblDisplayName);
            this.gbSolutionInfo.Location = new System.Drawing.Point(757, 262);
            this.gbSolutionInfo.Name = "gbSolutionInfo";
            this.gbSolutionInfo.Size = new System.Drawing.Size(611, 197);
            this.gbSolutionInfo.TabIndex = 9;
            this.gbSolutionInfo.TabStop = false;
            this.gbSolutionInfo.Text = "Solution Details";
            // 
            // lblSolutionIdValue
            // 
            this.lblSolutionIdValue.AutoSize = true;
            this.lblSolutionIdValue.Location = new System.Drawing.Point(111, 28);
            this.lblSolutionIdValue.Name = "lblSolutionIdValue";
            this.lblSolutionIdValue.Size = new System.Drawing.Size(13, 17);
            this.lblSolutionIdValue.TabIndex = 11;
            this.lblSolutionIdValue.Text = "-";
            // 
            // lblSolutionId
            // 
            this.lblSolutionId.AutoSize = true;
            this.lblSolutionId.Location = new System.Drawing.Point(6, 18);
            this.lblSolutionId.Name = "lblSolutionId";
            this.lblSolutionId.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblSolutionId.Size = new System.Drawing.Size(80, 27);
            this.lblSolutionId.TabIndex = 10;
            this.lblSolutionId.Text = "Solution ID:";
            // 
            // lblPublisherValue
            // 
            this.lblPublisherValue.AutoSize = true;
            this.lblPublisherValue.Location = new System.Drawing.Point(111, 173);
            this.lblPublisherValue.Name = "lblPublisherValue";
            this.lblPublisherValue.Size = new System.Drawing.Size(13, 17);
            this.lblPublisherValue.TabIndex = 9;
            this.lblPublisherValue.Text = "-";
            // 
            // lblPublisher
            // 
            this.lblPublisher.AutoSize = true;
            this.lblPublisher.Location = new System.Drawing.Point(6, 163);
            this.lblPublisher.Name = "lblPublisher";
            this.lblPublisher.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblPublisher.Size = new System.Drawing.Size(71, 27);
            this.lblPublisher.TabIndex = 8;
            this.lblPublisher.Text = "Publisher:";
            // 
            // lblManagedValue
            // 
            this.lblManagedValue.AutoSize = true;
            this.lblManagedValue.Location = new System.Drawing.Point(111, 144);
            this.lblManagedValue.Name = "lblManagedValue";
            this.lblManagedValue.Size = new System.Drawing.Size(13, 17);
            this.lblManagedValue.TabIndex = 7;
            this.lblManagedValue.Text = "-";
            // 
            // lblManaged
            // 
            this.lblManaged.AutoSize = true;
            this.lblManaged.Location = new System.Drawing.Point(6, 134);
            this.lblManaged.Name = "lblManaged";
            this.lblManaged.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblManaged.Size = new System.Drawing.Size(85, 27);
            this.lblManaged.TabIndex = 6;
            this.lblManaged.Text = "Is Managed:";
            // 
            // lblVersionValue
            // 
            this.lblVersionValue.AutoSize = true;
            this.lblVersionValue.Location = new System.Drawing.Point(111, 115);
            this.lblVersionValue.Name = "lblVersionValue";
            this.lblVersionValue.Size = new System.Drawing.Size(13, 17);
            this.lblVersionValue.TabIndex = 5;
            this.lblVersionValue.Text = "-";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(6, 105);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblVersion.Size = new System.Drawing.Size(60, 27);
            this.lblVersion.TabIndex = 4;
            this.lblVersion.Text = "Version:";
            // 
            // lblDisplayNameValue
            // 
            this.lblDisplayNameValue.AutoSize = true;
            this.lblDisplayNameValue.Location = new System.Drawing.Point(111, 86);
            this.lblDisplayNameValue.Name = "lblDisplayNameValue";
            this.lblDisplayNameValue.Size = new System.Drawing.Size(13, 17);
            this.lblDisplayNameValue.TabIndex = 3;
            this.lblDisplayNameValue.Text = "-";
            // 
            // lblLogicalNameValue
            // 
            this.lblLogicalNameValue.AutoSize = true;
            this.lblLogicalNameValue.Location = new System.Drawing.Point(111, 57);
            this.lblLogicalNameValue.Name = "lblLogicalNameValue";
            this.lblLogicalNameValue.Size = new System.Drawing.Size(13, 17);
            this.lblLogicalNameValue.TabIndex = 2;
            this.lblLogicalNameValue.Text = "-";
            // 
            // lblLogicalName
            // 
            this.lblLogicalName.AutoSize = true;
            this.lblLogicalName.Location = new System.Drawing.Point(6, 47);
            this.lblLogicalName.Name = "lblLogicalName";
            this.lblLogicalName.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblLogicalName.Size = new System.Drawing.Size(98, 27);
            this.lblLogicalName.TabIndex = 1;
            this.lblLogicalName.Text = "Logical Name:";
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Location = new System.Drawing.Point(6, 76);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblDisplayName.Size = new System.Drawing.Size(99, 27);
            this.lblDisplayName.TabIndex = 0;
            this.lblDisplayName.Text = "Display Name:";
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(0, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            // 
            // gbSolutions
            // 
            this.gbSolutions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbSolutions.Controls.Add(this.lblSolutionFilter);
            this.gbSolutions.Controls.Add(this.txtSolutionFilter);
            this.gbSolutions.Controls.Add(this.lvSolutions);
            this.gbSolutions.Location = new System.Drawing.Point(7, 58);
            this.gbSolutions.Name = "gbSolutions";
            this.gbSolutions.Size = new System.Drawing.Size(744, 401);
            this.gbSolutions.TabIndex = 10;
            this.gbSolutions.TabStop = false;
            this.gbSolutions.Text = "Solutions";
            // 
            // lblSolutionFilter
            // 
            this.lblSolutionFilter.AutoSize = true;
            this.lblSolutionFilter.Location = new System.Drawing.Point(7, 26);
            this.lblSolutionFilter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSolutionFilter.Name = "lblSolutionFilter";
            this.lblSolutionFilter.Size = new System.Drawing.Size(43, 17);
            this.lblSolutionFilter.TabIndex = 4;
            this.lblSolutionFilter.Text = "Filter:";
            // 
            // txtSolutionFilter
            // 
            this.txtSolutionFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSolutionFilter.Location = new System.Drawing.Point(72, 23);
            this.txtSolutionFilter.Margin = new System.Windows.Forms.Padding(4);
            this.txtSolutionFilter.Name = "txtSolutionFilter";
            this.txtSolutionFilter.Size = new System.Drawing.Size(665, 22);
            this.txtSolutionFilter.TabIndex = 5;
            this.txtSolutionFilter.TextChanged += new System.EventHandler(this.txtSolutionFilter_TextChanged);
            // 
            // lvSolutions
            // 
            this.lvSolutions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSolutions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSolDisplayName,
            this.chSolVersion,
            this.chSolManaged,
            this.chSolPublisher});
            this.lvSolutions.FullRowSelect = true;
            this.lvSolutions.HideSelection = false;
            this.lvSolutions.Location = new System.Drawing.Point(7, 53);
            this.lvSolutions.Margin = new System.Windows.Forms.Padding(4);
            this.lvSolutions.MultiSelect = false;
            this.lvSolutions.Name = "lvSolutions";
            this.lvSolutions.Size = new System.Drawing.Size(730, 341);
            this.lvSolutions.TabIndex = 3;
            this.lvSolutions.UseCompatibleStateImageBehavior = false;
            this.lvSolutions.View = System.Windows.Forms.View.Details;
            this.lvSolutions.SelectedIndexChanged += new System.EventHandler(this.lvSolutions_SelectedIndexChanged);
            this.lvSolutions.Resize += new System.EventHandler(this.lvSolutions_Resize);
            // 
            // chSolDisplayName
            // 
            this.chSolDisplayName.Text = "Display Name";
            this.chSolDisplayName.Width = 350;
            // 
            // chSolVersion
            // 
            this.chSolVersion.Text = "Version";
            this.chSolVersion.Width = 100;
            // 
            // chSolManaged
            // 
            this.chSolManaged.Text = "Is Managed";
            this.chSolManaged.Width = 100;
            // 
            // chSolPublisher
            // 
            this.chSolPublisher.Text = "Publisher";
            this.chSolPublisher.Width = 150;
            // 
            // btnLoadSolutions
            // 
            this.btnLoadSolutions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadSolutions.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnLoadSolutions.Location = new System.Drawing.Point(7, 22);
            this.btnLoadSolutions.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadSolutions.Name = "btnLoadSolutions";
            this.btnLoadSolutions.Size = new System.Drawing.Size(1361, 29);
            this.btnLoadSolutions.TabIndex = 9;
            this.btnLoadSolutions.Text = "Load Unmanaged Solutions from Source instance";
            this.btnLoadSolutions.UseVisualStyleBackColor = true;
            this.btnLoadSolutions.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gbExport
            // 
            this.gbExport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbExport.Controls.Add(this.gbQuickActions);
            this.gbExport.Controls.Add(this.gbExportSettings);
            this.gbExport.Controls.Add(this.btnLoadSolutions);
            this.gbExport.Controls.Add(this.gbSolutions);
            this.gbExport.Controls.Add(this.gbSolutionInfo);
            this.gbExport.Location = new System.Drawing.Point(0, 0);
            this.gbExport.Name = "gbExport";
            this.gbExport.Size = new System.Drawing.Size(1375, 465);
            this.gbExport.TabIndex = 11;
            this.gbExport.TabStop = false;
            this.gbExport.Text = "Export Options";
            // 
            // gbQuickActions
            // 
            this.gbQuickActions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbQuickActions.Controls.Add(this.btnSetPackLocation);
            this.gbQuickActions.Controls.Add(this.txtPackPathValue);
            this.gbQuickActions.Controls.Add(this.btnSetUnpackLocation);
            this.gbQuickActions.Controls.Add(this.txtQuickUpdateVersion);
            this.gbQuickActions.Controls.Add(this.txtUnpackPathValue);
            this.gbQuickActions.Controls.Add(this.chbPack);
            this.gbQuickActions.Controls.Add(this.chbUnpack);
            this.gbQuickActions.Controls.Add(this.chbUpdateVersion);
            this.gbQuickActions.Location = new System.Drawing.Point(757, 157);
            this.gbQuickActions.Name = "gbQuickActions";
            this.gbQuickActions.Size = new System.Drawing.Size(611, 99);
            this.gbQuickActions.TabIndex = 17;
            this.gbQuickActions.TabStop = false;
            this.gbQuickActions.Text = "Quick Actions";
            // 
            // txtQuickUpdateVersion
            // 
            this.txtQuickUpdateVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtQuickUpdateVersion.Enabled = false;
            this.txtQuickUpdateVersion.Location = new System.Drawing.Point(141, 19);
            this.txtQuickUpdateVersion.Margin = new System.Windows.Forms.Padding(4);
            this.txtQuickUpdateVersion.Name = "txtQuickUpdateVersion";
            this.txtQuickUpdateVersion.Size = new System.Drawing.Size(161, 22);
            this.txtQuickUpdateVersion.TabIndex = 5;
            this.txtQuickUpdateVersion.TextChanged += new System.EventHandler(this.txtQuickUpdateVersion_TextChanged);
            // 
            // chbPack
            // 
            this.chbPack.AutoSize = true;
            this.chbPack.Enabled = false;
            this.chbPack.Location = new System.Drawing.Point(6, 75);
            this.chbPack.Name = "chbPack";
            this.chbPack.Size = new System.Drawing.Size(61, 21);
            this.chbPack.TabIndex = 2;
            this.chbPack.Tag = "";
            this.chbPack.Text = "Pack";
            this.chbPack.UseVisualStyleBackColor = true;
            this.chbPack.CheckedChanged += new System.EventHandler(this.chbPack_CheckedChanged);
            // 
            // chbUnpack
            // 
            this.chbUnpack.AutoSize = true;
            this.chbUnpack.Location = new System.Drawing.Point(6, 48);
            this.chbUnpack.Name = "chbUnpack";
            this.chbUnpack.Size = new System.Drawing.Size(78, 21);
            this.chbUnpack.TabIndex = 1;
            this.chbUnpack.Tag = "";
            this.chbUnpack.Text = "Unpack";
            this.chbUnpack.UseVisualStyleBackColor = true;
            this.chbUnpack.CheckedChanged += new System.EventHandler(this.chbUnpack_CheckedChanged);
            // 
            // chbUpdateVersion
            // 
            this.chbUpdateVersion.AutoSize = true;
            this.chbUpdateVersion.Location = new System.Drawing.Point(6, 21);
            this.chbUpdateVersion.Name = "chbUpdateVersion";
            this.chbUpdateVersion.Size = new System.Drawing.Size(128, 21);
            this.chbUpdateVersion.TabIndex = 0;
            this.chbUpdateVersion.Text = "Update Version";
            this.chbUpdateVersion.UseVisualStyleBackColor = true;
            this.chbUpdateVersion.CheckedChanged += new System.EventHandler(this.chbUpdateVersion_CheckedChanged);
            // 
            // gbExportSettings
            // 
            this.gbExportSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbExportSettings.Controls.Add(this.btnSetSolutionLocation);
            this.gbExportSettings.Controls.Add(this.lblSolutionPath);
            this.gbExportSettings.Controls.Add(this.txtSolutionPathValue);
            this.gbExportSettings.Controls.Add(this.panel1);
            this.gbExportSettings.Controls.Add(this.lblType);
            this.gbExportSettings.Location = new System.Drawing.Point(757, 58);
            this.gbExportSettings.Name = "gbExportSettings";
            this.gbExportSettings.Size = new System.Drawing.Size(611, 93);
            this.gbExportSettings.TabIndex = 12;
            this.gbExportSettings.TabStop = false;
            this.gbExportSettings.Text = "Export Settings";
            // 
            // btnSetSolutionLocation
            // 
            this.btnSetSolutionLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetSolutionLocation.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnSetSolutionLocation.Location = new System.Drawing.Point(568, 55);
            this.btnSetSolutionLocation.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetSolutionLocation.Name = "btnSetSolutionLocation";
            this.btnSetSolutionLocation.Size = new System.Drawing.Size(36, 29);
            this.btnSetSolutionLocation.TabIndex = 13;
            this.btnSetSolutionLocation.Tag = "solution";
            this.btnSetSolutionLocation.Text = "...";
            this.btnSetSolutionLocation.UseVisualStyleBackColor = true;
            this.btnSetSolutionLocation.Click += new System.EventHandler(this.btnSetSolutionLocation_Click);
            // 
            // lblSolutionPath
            // 
            this.lblSolutionPath.AutoSize = true;
            this.lblSolutionPath.Location = new System.Drawing.Point(6, 55);
            this.lblSolutionPath.Name = "lblSolutionPath";
            this.lblSolutionPath.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblSolutionPath.Size = new System.Drawing.Size(121, 27);
            this.lblSolutionPath.TabIndex = 15;
            this.lblSolutionPath.Text = "Solution Location:";
            // 
            // txtSolutionPathValue
            // 
            this.txtSolutionPathValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSolutionPathValue.Location = new System.Drawing.Point(134, 59);
            this.txtSolutionPathValue.Margin = new System.Windows.Forms.Padding(4);
            this.txtSolutionPathValue.Name = "txtSolutionPathValue";
            this.txtSolutionPathValue.ReadOnly = true;
            this.txtSolutionPathValue.Size = new System.Drawing.Size(426, 22);
            this.txtSolutionPathValue.TabIndex = 6;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.rbManaged);
            this.panel1.Controls.Add(this.rbUnmanaged);
            this.panel1.Location = new System.Drawing.Point(83, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(521, 26);
            this.panel1.TabIndex = 16;
            // 
            // rbManaged
            // 
            this.rbManaged.AutoSize = true;
            this.rbManaged.Checked = true;
            this.rbManaged.Location = new System.Drawing.Point(3, 3);
            this.rbManaged.Name = "rbManaged";
            this.rbManaged.Size = new System.Drawing.Size(88, 21);
            this.rbManaged.TabIndex = 11;
            this.rbManaged.TabStop = true;
            this.rbManaged.Text = "Managed";
            this.rbManaged.UseVisualStyleBackColor = true;
            this.rbManaged.CheckedChanged += new System.EventHandler(this.rbPackageType_CheckedChanged);
            // 
            // rbUnmanaged
            // 
            this.rbUnmanaged.AutoSize = true;
            this.rbUnmanaged.Location = new System.Drawing.Point(113, 3);
            this.rbUnmanaged.Name = "rbUnmanaged";
            this.rbUnmanaged.Size = new System.Drawing.Size(106, 21);
            this.rbUnmanaged.TabIndex = 12;
            this.rbUnmanaged.Text = "Unmanaged";
            this.rbUnmanaged.UseVisualStyleBackColor = true;
            this.rbUnmanaged.CheckedChanged += new System.EventHandler(this.rbPackageType_CheckedChanged);
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(6, 17);
            this.lblType.Name = "lblType";
            this.lblType.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblType.Size = new System.Drawing.Size(71, 27);
            this.lblType.TabIndex = 10;
            this.lblType.Text = "Export as:";
            // 
            // btnSetUnpackLocation
            // 
            this.btnSetUnpackLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetUnpackLocation.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnSetUnpackLocation.Location = new System.Drawing.Point(568, 42);
            this.btnSetUnpackLocation.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetUnpackLocation.Name = "btnSetUnpackLocation";
            this.btnSetUnpackLocation.Size = new System.Drawing.Size(36, 29);
            this.btnSetUnpackLocation.TabIndex = 18;
            this.btnSetUnpackLocation.Tag = "solution";
            this.btnSetUnpackLocation.Text = "...";
            this.btnSetUnpackLocation.UseVisualStyleBackColor = true;
            // 
            // txtUnpackPathValue
            // 
            this.txtUnpackPathValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUnpackPathValue.Location = new System.Drawing.Point(141, 46);
            this.txtUnpackPathValue.Margin = new System.Windows.Forms.Padding(4);
            this.txtUnpackPathValue.Name = "txtUnpackPathValue";
            this.txtUnpackPathValue.ReadOnly = true;
            this.txtUnpackPathValue.Size = new System.Drawing.Size(419, 22);
            this.txtUnpackPathValue.TabIndex = 17;
            // 
            // txtPackPathValue
            // 
            this.txtPackPathValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPackPathValue.Location = new System.Drawing.Point(141, 73);
            this.txtPackPathValue.Margin = new System.Windows.Forms.Padding(4);
            this.txtPackPathValue.Name = "txtPackPathValue";
            this.txtPackPathValue.ReadOnly = true;
            this.txtPackPathValue.Size = new System.Drawing.Size(419, 22);
            this.txtPackPathValue.TabIndex = 19;
            // 
            // btnSetPackLocation
            // 
            this.btnSetPackLocation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetPackLocation.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnSetPackLocation.Location = new System.Drawing.Point(568, 70);
            this.btnSetPackLocation.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetPackLocation.Name = "btnSetPackLocation";
            this.btnSetPackLocation.Size = new System.Drawing.Size(36, 29);
            this.btnSetPackLocation.TabIndex = 20;
            this.btnSetPackLocation.Tag = "solution";
            this.btnSetPackLocation.Text = "...";
            this.btnSetPackLocation.UseVisualStyleBackColor = true;
            // 
            // ExportOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbExport);
            this.Name = "ExportOptions";
            this.Size = new System.Drawing.Size(1375, 465);
            this.gbSolutionInfo.ResumeLayout(false);
            this.gbSolutionInfo.PerformLayout();
            this.gbSolutions.ResumeLayout(false);
            this.gbSolutions.PerformLayout();
            this.gbExport.ResumeLayout(false);
            this.gbQuickActions.ResumeLayout(false);
            this.gbQuickActions.PerformLayout();
            this.gbExportSettings.ResumeLayout(false);
            this.gbExportSettings.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.GroupBox gbSolutionInfo;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.Label lblLogicalName;
        private System.Windows.Forms.Label lblLogicalNameValue;
        private System.Windows.Forms.Label lblDisplayNameValue;
        private System.Windows.Forms.Label lblVersionValue;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblPublisherValue;
        private System.Windows.Forms.Label lblPublisher;
        private System.Windows.Forms.Label lblManagedValue;
        private System.Windows.Forms.Label lblManaged;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox gbSolutions;
        private System.Windows.Forms.ListView lvSolutions;
        private System.Windows.Forms.ColumnHeader chSolDisplayName;
        private System.Windows.Forms.ColumnHeader chSolVersion;
        private System.Windows.Forms.ColumnHeader chSolManaged;
        private System.Windows.Forms.ColumnHeader chSolPublisher;
        private System.Windows.Forms.Label lblSolutionFilter;
        private System.Windows.Forms.TextBox txtSolutionFilter;
        private System.Windows.Forms.Button btnLoadSolutions;
        private System.Windows.Forms.GroupBox gbExport;
        private System.Windows.Forms.Label lblSolutionIdValue;
        private System.Windows.Forms.Label lblSolutionId;
        private System.Windows.Forms.GroupBox gbExportSettings;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.RadioButton rbUnmanaged;
        private System.Windows.Forms.RadioButton rbManaged;
        private System.Windows.Forms.Button btnSetSolutionLocation;
        private System.Windows.Forms.Label lblSolutionPath;
        private System.Windows.Forms.TextBox txtSolutionPathValue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox gbQuickActions;
        private System.Windows.Forms.CheckBox chbUpdateVersion;
        private System.Windows.Forms.CheckBox chbPack;
        private System.Windows.Forms.CheckBox chbUnpack;
        private System.Windows.Forms.TextBox txtQuickUpdateVersion;
        private System.Windows.Forms.Button btnSetPackLocation;
        private System.Windows.Forms.TextBox txtPackPathValue;
        private System.Windows.Forms.Button btnSetUnpackLocation;
        private System.Windows.Forms.TextBox txtUnpackPathValue;
    }
}

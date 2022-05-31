
namespace Dataverse.XrmTools.Deployer.Controls
{
    partial class UnpackOptions
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
            this.gbUnpack = new System.Windows.Forms.GroupBox();
            this.gbUnpackSettings = new System.Windows.Forms.GroupBox();
            this.btnDownloadPackager = new System.Windows.Forms.Button();
            this.btnSetOutputPath = new System.Windows.Forms.Button();
            this.lblOutputPath = new System.Windows.Forms.Label();
            this.txtOutputPathValue = new System.Windows.Forms.TextBox();
            this.btnSetPackagerPath = new System.Windows.Forms.Button();
            this.lblPackagerPath = new System.Windows.Forms.Label();
            this.txtPackagerPathValue = new System.Windows.Forms.TextBox();
            this.gbSolutionInfo = new System.Windows.Forms.GroupBox();
            this.lblSolutionId = new System.Windows.Forms.Label();
            this.lblDisplayNameValue = new System.Windows.Forms.Label();
            this.lblSolutionIdValue = new System.Windows.Forms.Label();
            this.lblLogicalNameValue = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblPublisherValue = new System.Windows.Forms.Label();
            this.lblDisplayName = new System.Windows.Forms.Label();
            this.lblPublisher = new System.Windows.Forms.Label();
            this.lblVersionValue = new System.Windows.Forms.Label();
            this.lblManagedValue = new System.Windows.Forms.Label();
            this.lblLogicalName = new System.Windows.Forms.Label();
            this.lblManaged = new System.Windows.Forms.Label();
            this.gbUnpackFromQueue = new System.Windows.Forms.GroupBox();
            this.lvOperations = new System.Windows.Forms.ListView();
            this.chOpDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOpLogicalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlImportFrom = new System.Windows.Forms.Panel();
            this.rbUnpackFromQueue = new System.Windows.Forms.RadioButton();
            this.rbUnpackFromFile = new System.Windows.Forms.RadioButton();
            this.lblUnpackFrom = new System.Windows.Forms.Label();
            this.gbUnpackFromFile = new System.Windows.Forms.GroupBox();
            this.btnAddSolutionFile = new System.Windows.Forms.Button();
            this.lblImportPath = new System.Windows.Forms.Label();
            this.txtImportPathValue = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbUnpack.SuspendLayout();
            this.gbUnpackSettings.SuspendLayout();
            this.gbSolutionInfo.SuspendLayout();
            this.gbUnpackFromQueue.SuspendLayout();
            this.pnlImportFrom.SuspendLayout();
            this.gbUnpackFromFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbUnpack
            // 
            this.gbUnpack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbUnpack.Controls.Add(this.gbUnpackSettings);
            this.gbUnpack.Controls.Add(this.gbSolutionInfo);
            this.gbUnpack.Controls.Add(this.gbUnpackFromQueue);
            this.gbUnpack.Controls.Add(this.pnlImportFrom);
            this.gbUnpack.Controls.Add(this.gbUnpackFromFile);
            this.gbUnpack.Location = new System.Drawing.Point(0, 0);
            this.gbUnpack.Name = "gbUnpack";
            this.gbUnpack.Size = new System.Drawing.Size(1375, 465);
            this.gbUnpack.TabIndex = 1;
            this.gbUnpack.TabStop = false;
            this.gbUnpack.Text = "Unpack Options";
            // 
            // gbUnpackSettings
            // 
            this.gbUnpackSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbUnpackSettings.Controls.Add(this.btnDownloadPackager);
            this.gbUnpackSettings.Controls.Add(this.btnSetOutputPath);
            this.gbUnpackSettings.Controls.Add(this.lblOutputPath);
            this.gbUnpackSettings.Controls.Add(this.txtOutputPathValue);
            this.gbUnpackSettings.Controls.Add(this.btnSetPackagerPath);
            this.gbUnpackSettings.Controls.Add(this.lblPackagerPath);
            this.gbUnpackSettings.Controls.Add(this.txtPackagerPathValue);
            this.gbUnpackSettings.Location = new System.Drawing.Point(757, 53);
            this.gbUnpackSettings.Name = "gbUnpackSettings";
            this.gbUnpackSettings.Size = new System.Drawing.Size(612, 210);
            this.gbUnpackSettings.TabIndex = 18;
            this.gbUnpackSettings.TabStop = false;
            this.gbUnpackSettings.Text = "Unpack Settings";
            // 
            // btnDownloadPackager
            // 
            this.btnDownloadPackager.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDownloadPackager.BackgroundImage = global::Dataverse.XrmTools.Deployer.Properties.Resources.download_arrow;
            this.btnDownloadPackager.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnDownloadPackager.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnDownloadPackager.Location = new System.Drawing.Point(563, 22);
            this.btnDownloadPackager.Margin = new System.Windows.Forms.Padding(4);
            this.btnDownloadPackager.Name = "btnDownloadPackager";
            this.btnDownloadPackager.Size = new System.Drawing.Size(42, 29);
            this.btnDownloadPackager.TabIndex = 27;
            this.btnDownloadPackager.Tag = "";
            this.btnDownloadPackager.UseVisualStyleBackColor = true;
            this.btnDownloadPackager.Click += new System.EventHandler(this.btnDownloadPackager_Click);
            // 
            // btnSetOutputPath
            // 
            this.btnSetOutputPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetOutputPath.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnSetOutputPath.Location = new System.Drawing.Point(513, 59);
            this.btnSetOutputPath.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetOutputPath.Name = "btnSetOutputPath";
            this.btnSetOutputPath.Size = new System.Drawing.Size(92, 29);
            this.btnSetOutputPath.TabIndex = 25;
            this.btnSetOutputPath.Tag = "output";
            this.btnSetOutputPath.Text = "...";
            this.btnSetOutputPath.UseVisualStyleBackColor = true;
            this.btnSetOutputPath.Click += new System.EventHandler(this.btnSetOutputPath_Click);
            // 
            // lblOutputPath
            // 
            this.lblOutputPath.AutoSize = true;
            this.lblOutputPath.Location = new System.Drawing.Point(6, 58);
            this.lblOutputPath.Name = "lblOutputPath";
            this.lblOutputPath.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblOutputPath.Size = new System.Drawing.Size(55, 27);
            this.lblOutputPath.TabIndex = 26;
            this.lblOutputPath.Text = "Output:";
            // 
            // txtOutputPathValue
            // 
            this.txtOutputPathValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputPathValue.Location = new System.Drawing.Point(85, 63);
            this.txtOutputPathValue.Margin = new System.Windows.Forms.Padding(4);
            this.txtOutputPathValue.Name = "txtOutputPathValue";
            this.txtOutputPathValue.ReadOnly = true;
            this.txtOutputPathValue.Size = new System.Drawing.Size(420, 22);
            this.txtOutputPathValue.TabIndex = 24;
            // 
            // btnSetPackagerPath
            // 
            this.btnSetPackagerPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetPackagerPath.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnSetPackagerPath.Location = new System.Drawing.Point(513, 22);
            this.btnSetPackagerPath.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetPackagerPath.Name = "btnSetPackagerPath";
            this.btnSetPackagerPath.Size = new System.Drawing.Size(42, 29);
            this.btnSetPackagerPath.TabIndex = 22;
            this.btnSetPackagerPath.Tag = "packager";
            this.btnSetPackagerPath.Text = "...";
            this.btnSetPackagerPath.UseVisualStyleBackColor = true;
            this.btnSetPackagerPath.Click += new System.EventHandler(this.btnSetPackagerPath_Click);
            // 
            // lblPackagerPath
            // 
            this.lblPackagerPath.AutoSize = true;
            this.lblPackagerPath.Location = new System.Drawing.Point(6, 21);
            this.lblPackagerPath.Name = "lblPackagerPath";
            this.lblPackagerPath.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblPackagerPath.Size = new System.Drawing.Size(72, 27);
            this.lblPackagerPath.TabIndex = 23;
            this.lblPackagerPath.Text = "Packager:";
            // 
            // txtPackagerPathValue
            // 
            this.txtPackagerPathValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPackagerPathValue.Location = new System.Drawing.Point(85, 26);
            this.txtPackagerPathValue.Margin = new System.Windows.Forms.Padding(4);
            this.txtPackagerPathValue.Name = "txtPackagerPathValue";
            this.txtPackagerPathValue.ReadOnly = true;
            this.txtPackagerPathValue.Size = new System.Drawing.Size(420, 22);
            this.txtPackagerPathValue.TabIndex = 21;
            // 
            // gbSolutionInfo
            // 
            this.gbSolutionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSolutionInfo.Controls.Add(this.lblSolutionId);
            this.gbSolutionInfo.Controls.Add(this.lblDisplayNameValue);
            this.gbSolutionInfo.Controls.Add(this.lblSolutionIdValue);
            this.gbSolutionInfo.Controls.Add(this.lblLogicalNameValue);
            this.gbSolutionInfo.Controls.Add(this.lblVersion);
            this.gbSolutionInfo.Controls.Add(this.lblPublisherValue);
            this.gbSolutionInfo.Controls.Add(this.lblDisplayName);
            this.gbSolutionInfo.Controls.Add(this.lblPublisher);
            this.gbSolutionInfo.Controls.Add(this.lblVersionValue);
            this.gbSolutionInfo.Controls.Add(this.lblManagedValue);
            this.gbSolutionInfo.Controls.Add(this.lblLogicalName);
            this.gbSolutionInfo.Controls.Add(this.lblManaged);
            this.gbSolutionInfo.Location = new System.Drawing.Point(757, 269);
            this.gbSolutionInfo.Name = "gbSolutionInfo";
            this.gbSolutionInfo.Size = new System.Drawing.Size(612, 193);
            this.gbSolutionInfo.TabIndex = 35;
            this.gbSolutionInfo.TabStop = false;
            this.gbSolutionInfo.Text = "Solution Details";
            // 
            // lblSolutionId
            // 
            this.lblSolutionId.AutoSize = true;
            this.lblSolutionId.Location = new System.Drawing.Point(6, 18);
            this.lblSolutionId.Name = "lblSolutionId";
            this.lblSolutionId.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblSolutionId.Size = new System.Drawing.Size(80, 27);
            this.lblSolutionId.TabIndex = 30;
            this.lblSolutionId.Text = "Solution ID:";
            // 
            // lblDisplayNameValue
            // 
            this.lblDisplayNameValue.AutoSize = true;
            this.lblDisplayNameValue.Location = new System.Drawing.Point(111, 82);
            this.lblDisplayNameValue.Name = "lblDisplayNameValue";
            this.lblDisplayNameValue.Size = new System.Drawing.Size(13, 17);
            this.lblDisplayNameValue.TabIndex = 23;
            this.lblDisplayNameValue.Text = "-";
            // 
            // lblSolutionIdValue
            // 
            this.lblSolutionIdValue.AutoSize = true;
            this.lblSolutionIdValue.Location = new System.Drawing.Point(111, 28);
            this.lblSolutionIdValue.Name = "lblSolutionIdValue";
            this.lblSolutionIdValue.Size = new System.Drawing.Size(13, 17);
            this.lblSolutionIdValue.TabIndex = 31;
            this.lblSolutionIdValue.Text = "-";
            // 
            // lblLogicalNameValue
            // 
            this.lblLogicalNameValue.AutoSize = true;
            this.lblLogicalNameValue.Location = new System.Drawing.Point(111, 55);
            this.lblLogicalNameValue.Name = "lblLogicalNameValue";
            this.lblLogicalNameValue.Size = new System.Drawing.Size(13, 17);
            this.lblLogicalNameValue.TabIndex = 22;
            this.lblLogicalNameValue.Text = "-";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(6, 99);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblVersion.Size = new System.Drawing.Size(60, 27);
            this.lblVersion.TabIndex = 24;
            this.lblVersion.Text = "Version:";
            // 
            // lblPublisherValue
            // 
            this.lblPublisherValue.AutoSize = true;
            this.lblPublisherValue.Location = new System.Drawing.Point(111, 163);
            this.lblPublisherValue.Name = "lblPublisherValue";
            this.lblPublisherValue.Size = new System.Drawing.Size(13, 17);
            this.lblPublisherValue.TabIndex = 29;
            this.lblPublisherValue.Text = "-";
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Location = new System.Drawing.Point(6, 72);
            this.lblDisplayName.Name = "lblDisplayName";
            this.lblDisplayName.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblDisplayName.Size = new System.Drawing.Size(99, 27);
            this.lblDisplayName.TabIndex = 20;
            this.lblDisplayName.Text = "Display Name:";
            // 
            // lblPublisher
            // 
            this.lblPublisher.AutoSize = true;
            this.lblPublisher.Location = new System.Drawing.Point(6, 153);
            this.lblPublisher.Name = "lblPublisher";
            this.lblPublisher.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblPublisher.Size = new System.Drawing.Size(71, 27);
            this.lblPublisher.TabIndex = 28;
            this.lblPublisher.Text = "Publisher:";
            // 
            // lblVersionValue
            // 
            this.lblVersionValue.AutoSize = true;
            this.lblVersionValue.Location = new System.Drawing.Point(111, 109);
            this.lblVersionValue.Name = "lblVersionValue";
            this.lblVersionValue.Size = new System.Drawing.Size(13, 17);
            this.lblVersionValue.TabIndex = 25;
            this.lblVersionValue.Text = "-";
            // 
            // lblManagedValue
            // 
            this.lblManagedValue.AutoSize = true;
            this.lblManagedValue.Location = new System.Drawing.Point(111, 136);
            this.lblManagedValue.Name = "lblManagedValue";
            this.lblManagedValue.Size = new System.Drawing.Size(13, 17);
            this.lblManagedValue.TabIndex = 27;
            this.lblManagedValue.Text = "-";
            // 
            // lblLogicalName
            // 
            this.lblLogicalName.AutoSize = true;
            this.lblLogicalName.Location = new System.Drawing.Point(6, 45);
            this.lblLogicalName.Name = "lblLogicalName";
            this.lblLogicalName.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblLogicalName.Size = new System.Drawing.Size(98, 27);
            this.lblLogicalName.TabIndex = 21;
            this.lblLogicalName.Text = "Logical Name:";
            // 
            // lblManaged
            // 
            this.lblManaged.AutoSize = true;
            this.lblManaged.Location = new System.Drawing.Point(6, 126);
            this.lblManaged.Name = "lblManaged";
            this.lblManaged.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblManaged.Size = new System.Drawing.Size(85, 27);
            this.lblManaged.TabIndex = 26;
            this.lblManaged.Text = "Is Managed:";
            // 
            // gbUnpackFromQueue
            // 
            this.gbUnpackFromQueue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbUnpackFromQueue.Controls.Add(this.lvOperations);
            this.gbUnpackFromQueue.Location = new System.Drawing.Point(6, 159);
            this.gbUnpackFromQueue.Name = "gbUnpackFromQueue";
            this.gbUnpackFromQueue.Size = new System.Drawing.Size(744, 303);
            this.gbUnpackFromQueue.TabIndex = 12;
            this.gbUnpackFromQueue.TabStop = false;
            this.gbUnpackFromQueue.Text = "Unpack From Queue";
            // 
            // lvOperations
            // 
            this.lvOperations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvOperations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chOpDisplayName,
            this.chOpLogicalName});
            this.lvOperations.FullRowSelect = true;
            this.lvOperations.HideSelection = false;
            this.lvOperations.Location = new System.Drawing.Point(7, 22);
            this.lvOperations.Margin = new System.Windows.Forms.Padding(4);
            this.lvOperations.MultiSelect = false;
            this.lvOperations.Name = "lvOperations";
            this.lvOperations.Size = new System.Drawing.Size(730, 274);
            this.lvOperations.TabIndex = 3;
            this.lvOperations.UseCompatibleStateImageBehavior = false;
            this.lvOperations.View = System.Windows.Forms.View.Details;
            this.lvOperations.SelectedIndexChanged += new System.EventHandler(this.lvOperations_SelectedIndexChanged);
            this.lvOperations.Resize += new System.EventHandler(this.lvOperations_Resize);
            // 
            // chOpDisplayName
            // 
            this.chOpDisplayName.Text = "Display Name";
            this.chOpDisplayName.Width = 275;
            // 
            // chOpLogicalName
            // 
            this.chOpLogicalName.Text = "Logical Name";
            this.chOpLogicalName.Width = 275;
            // 
            // pnlImportFrom
            // 
            this.pnlImportFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlImportFrom.Controls.Add(this.rbUnpackFromQueue);
            this.pnlImportFrom.Controls.Add(this.rbUnpackFromFile);
            this.pnlImportFrom.Controls.Add(this.lblUnpackFrom);
            this.pnlImportFrom.Location = new System.Drawing.Point(7, 21);
            this.pnlImportFrom.Name = "pnlImportFrom";
            this.pnlImportFrom.Size = new System.Drawing.Size(1361, 26);
            this.pnlImportFrom.TabIndex = 11;
            // 
            // rbUnpackFromQueue
            // 
            this.rbUnpackFromQueue.AutoSize = true;
            this.rbUnpackFromQueue.Location = new System.Drawing.Point(186, 3);
            this.rbUnpackFromQueue.Name = "rbUnpackFromQueue";
            this.rbUnpackFromQueue.Size = new System.Drawing.Size(72, 21);
            this.rbUnpackFromQueue.TabIndex = 14;
            this.rbUnpackFromQueue.Text = "Queue";
            this.rbUnpackFromQueue.UseVisualStyleBackColor = true;
            this.rbUnpackFromQueue.CheckedChanged += new System.EventHandler(this.rbImportFromQueue_CheckedChanged);
            // 
            // rbUnpackFromFile
            // 
            this.rbUnpackFromFile.AutoSize = true;
            this.rbUnpackFromFile.Checked = true;
            this.rbUnpackFromFile.Location = new System.Drawing.Point(112, 3);
            this.rbUnpackFromFile.Name = "rbUnpackFromFile";
            this.rbUnpackFromFile.Size = new System.Drawing.Size(51, 21);
            this.rbUnpackFromFile.TabIndex = 13;
            this.rbUnpackFromFile.TabStop = true;
            this.rbUnpackFromFile.Text = "File";
            this.rbUnpackFromFile.UseVisualStyleBackColor = true;
            this.rbUnpackFromFile.CheckedChanged += new System.EventHandler(this.rbImportFromFile_CheckedChanged);
            // 
            // lblUnpackFrom
            // 
            this.lblUnpackFrom.AutoSize = true;
            this.lblUnpackFrom.Location = new System.Drawing.Point(3, 5);
            this.lblUnpackFrom.Name = "lblUnpackFrom";
            this.lblUnpackFrom.Size = new System.Drawing.Size(96, 17);
            this.lblUnpackFrom.TabIndex = 16;
            this.lblUnpackFrom.Text = "Unpack From:";
            // 
            // gbUnpackFromFile
            // 
            this.gbUnpackFromFile.Controls.Add(this.btnAddSolutionFile);
            this.gbUnpackFromFile.Controls.Add(this.lblImportPath);
            this.gbUnpackFromFile.Controls.Add(this.txtImportPathValue);
            this.gbUnpackFromFile.Location = new System.Drawing.Point(7, 53);
            this.gbUnpackFromFile.Name = "gbUnpackFromFile";
            this.gbUnpackFromFile.Size = new System.Drawing.Size(744, 100);
            this.gbUnpackFromFile.TabIndex = 10;
            this.gbUnpackFromFile.TabStop = false;
            this.gbUnpackFromFile.Text = "Unpack From File";
            // 
            // btnAddSolutionFile
            // 
            this.btnAddSolutionFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSolutionFile.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnAddSolutionFile.Location = new System.Drawing.Point(7, 22);
            this.btnAddSolutionFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddSolutionFile.Name = "btnAddSolutionFile";
            this.btnAddSolutionFile.Size = new System.Drawing.Size(731, 29);
            this.btnAddSolutionFile.TabIndex = 8;
            this.btnAddSolutionFile.Text = "Add Solution File...";
            this.btnAddSolutionFile.UseVisualStyleBackColor = true;
            this.btnAddSolutionFile.Click += new System.EventHandler(this.btnAddSolution_Click);
            // 
            // lblImportPath
            // 
            this.lblImportPath.AutoSize = true;
            this.lblImportPath.Location = new System.Drawing.Point(6, 55);
            this.lblImportPath.Name = "lblImportPath";
            this.lblImportPath.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblImportPath.Size = new System.Drawing.Size(41, 27);
            this.lblImportPath.TabIndex = 17;
            this.lblImportPath.Text = "Path:";
            // 
            // txtImportPathValue
            // 
            this.txtImportPathValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtImportPathValue.Location = new System.Drawing.Point(54, 63);
            this.txtImportPathValue.Margin = new System.Windows.Forms.Padding(4);
            this.txtImportPathValue.Name = "txtImportPathValue";
            this.txtImportPathValue.ReadOnly = true;
            this.txtImportPathValue.Size = new System.Drawing.Size(684, 22);
            this.txtImportPathValue.TabIndex = 16;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(0, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            // 
            // UnpackOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbUnpack);
            this.Name = "UnpackOptions";
            this.Size = new System.Drawing.Size(1375, 465);
            this.gbUnpack.ResumeLayout(false);
            this.gbUnpackSettings.ResumeLayout(false);
            this.gbUnpackSettings.PerformLayout();
            this.gbSolutionInfo.ResumeLayout(false);
            this.gbSolutionInfo.PerformLayout();
            this.gbUnpackFromQueue.ResumeLayout(false);
            this.pnlImportFrom.ResumeLayout(false);
            this.pnlImportFrom.PerformLayout();
            this.gbUnpackFromFile.ResumeLayout(false);
            this.gbUnpackFromFile.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.GroupBox gbUnpack;
        private System.Windows.Forms.GroupBox gbUnpackSettings;
        private System.Windows.Forms.GroupBox gbSolutionInfo;
        private System.Windows.Forms.Label lblSolutionId;
        private System.Windows.Forms.Label lblDisplayNameValue;
        private System.Windows.Forms.Label lblSolutionIdValue;
        private System.Windows.Forms.Label lblLogicalNameValue;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Label lblPublisherValue;
        private System.Windows.Forms.Label lblDisplayName;
        private System.Windows.Forms.Label lblPublisher;
        private System.Windows.Forms.Label lblVersionValue;
        private System.Windows.Forms.Label lblManagedValue;
        private System.Windows.Forms.Label lblLogicalName;
        private System.Windows.Forms.Label lblManaged;
        private System.Windows.Forms.GroupBox gbUnpackFromQueue;
        private System.Windows.Forms.ListView lvOperations;
        private System.Windows.Forms.ColumnHeader chOpDisplayName;
        private System.Windows.Forms.ColumnHeader chOpLogicalName;
        private System.Windows.Forms.Panel pnlImportFrom;
        private System.Windows.Forms.RadioButton rbUnpackFromQueue;
        private System.Windows.Forms.RadioButton rbUnpackFromFile;
        private System.Windows.Forms.Label lblUnpackFrom;
        private System.Windows.Forms.GroupBox gbUnpackFromFile;
        private System.Windows.Forms.Button btnAddSolutionFile;
        private System.Windows.Forms.Label lblImportPath;
        private System.Windows.Forms.TextBox txtImportPathValue;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSetPackagerPath;
        private System.Windows.Forms.Label lblPackagerPath;
        private System.Windows.Forms.TextBox txtPackagerPathValue;
        private System.Windows.Forms.Button btnSetOutputPath;
        private System.Windows.Forms.Label lblOutputPath;
        private System.Windows.Forms.TextBox txtOutputPathValue;
        private System.Windows.Forms.Button btnDownloadPackager;
    }
}

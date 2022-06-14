
namespace Dataverse.XrmTools.Deployer.Controls
{
    partial class PackOptions
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
            this.gbPack = new System.Windows.Forms.GroupBox();
            this.gbPackSettings = new System.Windows.Forms.GroupBox();
            this.btnSetOutputSolutionFilePath = new System.Windows.Forms.Button();
            this.lblOutputSolutionFilePath = new System.Windows.Forms.Label();
            this.txtOutputSolutionFilePathValue = new System.Windows.Forms.TextBox();
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
            this.gbPackFromQueue = new System.Windows.Forms.GroupBox();
            this.lvOperations = new System.Windows.Forms.ListView();
            this.chOpDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOpLogicalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlImportFrom = new System.Windows.Forms.Panel();
            this.rbPackFromQueue = new System.Windows.Forms.RadioButton();
            this.rbPackFromDir = new System.Windows.Forms.RadioButton();
            this.lblPackFrom = new System.Windows.Forms.Label();
            this.gbPackFromDir = new System.Windows.Forms.GroupBox();
            this.btnAddSourceDir = new System.Windows.Forms.Button();
            this.lblOutputDirPath = new System.Windows.Forms.Label();
            this.txtOutputDirPathValue = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbPack.SuspendLayout();
            this.gbPackSettings.SuspendLayout();
            this.gbSolutionInfo.SuspendLayout();
            this.gbPackFromQueue.SuspendLayout();
            this.pnlImportFrom.SuspendLayout();
            this.gbPackFromDir.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPack
            // 
            this.gbPack.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPack.Controls.Add(this.gbPackSettings);
            this.gbPack.Controls.Add(this.gbSolutionInfo);
            this.gbPack.Controls.Add(this.gbPackFromQueue);
            this.gbPack.Controls.Add(this.pnlImportFrom);
            this.gbPack.Controls.Add(this.gbPackFromDir);
            this.gbPack.Location = new System.Drawing.Point(0, 0);
            this.gbPack.Name = "gbPack";
            this.gbPack.Size = new System.Drawing.Size(1375, 465);
            this.gbPack.TabIndex = 1;
            this.gbPack.TabStop = false;
            this.gbPack.Text = "Pack Options";
            // 
            // gbPackSettings
            // 
            this.gbPackSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPackSettings.Controls.Add(this.btnSetOutputSolutionFilePath);
            this.gbPackSettings.Controls.Add(this.lblOutputSolutionFilePath);
            this.gbPackSettings.Controls.Add(this.txtOutputSolutionFilePathValue);
            this.gbPackSettings.Location = new System.Drawing.Point(757, 53);
            this.gbPackSettings.Name = "gbPackSettings";
            this.gbPackSettings.Size = new System.Drawing.Size(612, 100);
            this.gbPackSettings.TabIndex = 18;
            this.gbPackSettings.TabStop = false;
            this.gbPackSettings.Text = "Pack Settings";
            // 
            // btnSetOutputSolutionFilePath
            // 
            this.btnSetOutputSolutionFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSetOutputSolutionFilePath.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnSetOutputSolutionFilePath.Location = new System.Drawing.Point(513, 22);
            this.btnSetOutputSolutionFilePath.Margin = new System.Windows.Forms.Padding(4);
            this.btnSetOutputSolutionFilePath.Name = "btnSetOutputSolutionFilePath";
            this.btnSetOutputSolutionFilePath.Size = new System.Drawing.Size(92, 29);
            this.btnSetOutputSolutionFilePath.TabIndex = 25;
            this.btnSetOutputSolutionFilePath.Tag = "output";
            this.btnSetOutputSolutionFilePath.Text = "...";
            this.btnSetOutputSolutionFilePath.UseVisualStyleBackColor = true;
            this.btnSetOutputSolutionFilePath.Click += new System.EventHandler(this.btnSetOutputPath_Click);
            // 
            // lblOutputSolutionFilePath
            // 
            this.lblOutputSolutionFilePath.AutoSize = true;
            this.lblOutputSolutionFilePath.Location = new System.Drawing.Point(6, 23);
            this.lblOutputSolutionFilePath.Name = "lblOutputSolutionFilePath";
            this.lblOutputSolutionFilePath.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblOutputSolutionFilePath.Size = new System.Drawing.Size(55, 27);
            this.lblOutputSolutionFilePath.TabIndex = 26;
            this.lblOutputSolutionFilePath.Text = "Output:";
            // 
            // txtOutputSolutionFilePathValue
            // 
            this.txtOutputSolutionFilePathValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputSolutionFilePathValue.Location = new System.Drawing.Point(85, 28);
            this.txtOutputSolutionFilePathValue.Margin = new System.Windows.Forms.Padding(4);
            this.txtOutputSolutionFilePathValue.Name = "txtOutputSolutionFilePathValue";
            this.txtOutputSolutionFilePathValue.ReadOnly = true;
            this.txtOutputSolutionFilePathValue.Size = new System.Drawing.Size(420, 22);
            this.txtOutputSolutionFilePathValue.TabIndex = 24;
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
            this.gbSolutionInfo.Location = new System.Drawing.Point(757, 159);
            this.gbSolutionInfo.Name = "gbSolutionInfo";
            this.gbSolutionInfo.Size = new System.Drawing.Size(612, 303);
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
            // gbPackFromQueue
            // 
            this.gbPackFromQueue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbPackFromQueue.Controls.Add(this.lvOperations);
            this.gbPackFromQueue.Location = new System.Drawing.Point(6, 159);
            this.gbPackFromQueue.Name = "gbPackFromQueue";
            this.gbPackFromQueue.Size = new System.Drawing.Size(744, 303);
            this.gbPackFromQueue.TabIndex = 12;
            this.gbPackFromQueue.TabStop = false;
            this.gbPackFromQueue.Text = "Pack From Queue";
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
            this.pnlImportFrom.Controls.Add(this.rbPackFromQueue);
            this.pnlImportFrom.Controls.Add(this.rbPackFromDir);
            this.pnlImportFrom.Controls.Add(this.lblPackFrom);
            this.pnlImportFrom.Location = new System.Drawing.Point(7, 21);
            this.pnlImportFrom.Name = "pnlImportFrom";
            this.pnlImportFrom.Size = new System.Drawing.Size(1361, 26);
            this.pnlImportFrom.TabIndex = 11;
            // 
            // rbPackFromQueue
            // 
            this.rbPackFromQueue.AutoSize = true;
            this.rbPackFromQueue.Location = new System.Drawing.Point(204, 3);
            this.rbPackFromQueue.Name = "rbPackFromQueue";
            this.rbPackFromQueue.Size = new System.Drawing.Size(72, 21);
            this.rbPackFromQueue.TabIndex = 14;
            this.rbPackFromQueue.Text = "Queue";
            this.rbPackFromQueue.UseVisualStyleBackColor = true;
            this.rbPackFromQueue.CheckedChanged += new System.EventHandler(this.rbPackFromQueue_CheckedChanged);
            // 
            // rbPackFromDir
            // 
            this.rbPackFromDir.AutoSize = true;
            this.rbPackFromDir.Checked = true;
            this.rbPackFromDir.Location = new System.Drawing.Point(112, 3);
            this.rbPackFromDir.Name = "rbPackFromDir";
            this.rbPackFromDir.Size = new System.Drawing.Size(86, 21);
            this.rbPackFromDir.TabIndex = 13;
            this.rbPackFromDir.TabStop = true;
            this.rbPackFromDir.Text = "Directory";
            this.rbPackFromDir.UseVisualStyleBackColor = true;
            this.rbPackFromDir.CheckedChanged += new System.EventHandler(this.rbPackFromDir_CheckedChanged);
            // 
            // lblPackFrom
            // 
            this.lblPackFrom.AutoSize = true;
            this.lblPackFrom.Location = new System.Drawing.Point(3, 5);
            this.lblPackFrom.Name = "lblPackFrom";
            this.lblPackFrom.Size = new System.Drawing.Size(79, 17);
            this.lblPackFrom.TabIndex = 16;
            this.lblPackFrom.Text = "Pack From:";
            // 
            // gbPackFromDir
            // 
            this.gbPackFromDir.Controls.Add(this.btnAddSourceDir);
            this.gbPackFromDir.Controls.Add(this.lblOutputDirPath);
            this.gbPackFromDir.Controls.Add(this.txtOutputDirPathValue);
            this.gbPackFromDir.Location = new System.Drawing.Point(7, 53);
            this.gbPackFromDir.Name = "gbPackFromDir";
            this.gbPackFromDir.Size = new System.Drawing.Size(744, 100);
            this.gbPackFromDir.TabIndex = 10;
            this.gbPackFromDir.TabStop = false;
            this.gbPackFromDir.Text = "Pack From Directory";
            // 
            // btnAddSourceDir
            // 
            this.btnAddSourceDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSourceDir.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnAddSourceDir.Location = new System.Drawing.Point(7, 22);
            this.btnAddSourceDir.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddSourceDir.Name = "btnAddSourceDir";
            this.btnAddSourceDir.Size = new System.Drawing.Size(731, 29);
            this.btnAddSourceDir.TabIndex = 8;
            this.btnAddSourceDir.Text = "Select Source Directory...";
            this.btnAddSourceDir.UseVisualStyleBackColor = true;
            this.btnAddSourceDir.Click += new System.EventHandler(this.btnAddSourceDir_Click);
            // 
            // lblOutputDirPath
            // 
            this.lblOutputDirPath.AutoSize = true;
            this.lblOutputDirPath.Location = new System.Drawing.Point(6, 55);
            this.lblOutputDirPath.Name = "lblOutputDirPath";
            this.lblOutputDirPath.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblOutputDirPath.Size = new System.Drawing.Size(41, 27);
            this.lblOutputDirPath.TabIndex = 17;
            this.lblOutputDirPath.Text = "Path:";
            // 
            // txtOutputDirPathValue
            // 
            this.txtOutputDirPathValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutputDirPathValue.Location = new System.Drawing.Point(54, 63);
            this.txtOutputDirPathValue.Margin = new System.Windows.Forms.Padding(4);
            this.txtOutputDirPathValue.Name = "txtOutputDirPathValue";
            this.txtOutputDirPathValue.ReadOnly = true;
            this.txtOutputDirPathValue.Size = new System.Drawing.Size(684, 22);
            this.txtOutputDirPathValue.TabIndex = 16;
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
            // PackOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbPack);
            this.Name = "PackOptions";
            this.Size = new System.Drawing.Size(1375, 465);
            this.gbPack.ResumeLayout(false);
            this.gbPackSettings.ResumeLayout(false);
            this.gbPackSettings.PerformLayout();
            this.gbSolutionInfo.ResumeLayout(false);
            this.gbSolutionInfo.PerformLayout();
            this.gbPackFromQueue.ResumeLayout(false);
            this.pnlImportFrom.ResumeLayout(false);
            this.pnlImportFrom.PerformLayout();
            this.gbPackFromDir.ResumeLayout(false);
            this.gbPackFromDir.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.GroupBox gbPack;
        private System.Windows.Forms.GroupBox gbPackSettings;
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
        private System.Windows.Forms.GroupBox gbPackFromQueue;
        private System.Windows.Forms.ListView lvOperations;
        private System.Windows.Forms.ColumnHeader chOpDisplayName;
        private System.Windows.Forms.ColumnHeader chOpLogicalName;
        private System.Windows.Forms.Panel pnlImportFrom;
        private System.Windows.Forms.RadioButton rbPackFromQueue;
        private System.Windows.Forms.RadioButton rbPackFromDir;
        private System.Windows.Forms.Label lblPackFrom;
        private System.Windows.Forms.GroupBox gbPackFromDir;
        private System.Windows.Forms.Button btnAddSourceDir;
        private System.Windows.Forms.Label lblOutputDirPath;
        private System.Windows.Forms.TextBox txtOutputDirPathValue;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnSetOutputSolutionFilePath;
        private System.Windows.Forms.Label lblOutputSolutionFilePath;
        private System.Windows.Forms.TextBox txtOutputSolutionFilePathValue;
    }
}

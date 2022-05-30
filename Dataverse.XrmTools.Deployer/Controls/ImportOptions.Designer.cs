
namespace Dataverse.XrmTools.Deployer.Controls
{
    partial class ImportOptions
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
            this.gbImport = new System.Windows.Forms.GroupBox();
            this.gbImportSettings = new System.Windows.Forms.GroupBox();
            this.chbPublishWorkflows = new System.Windows.Forms.CheckBox();
            this.chbHoldingSolution = new System.Windows.Forms.CheckBox();
            this.chbOverwriteUnmanaged = new System.Windows.Forms.CheckBox();
            this.gbSolutionInfo = new System.Windows.Forms.GroupBox();
            this.lblExistingValue = new System.Windows.Forms.Label();
            this.lblSolutionId = new System.Windows.Forms.Label();
            this.lblExisting = new System.Windows.Forms.Label();
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
            this.gbImportFromQueue = new System.Windows.Forms.GroupBox();
            this.lvOperations = new System.Windows.Forms.ListView();
            this.chOpDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOpLogicalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlImportFrom = new System.Windows.Forms.Panel();
            this.rbImportFromQueue = new System.Windows.Forms.RadioButton();
            this.rbImportFromFile = new System.Windows.Forms.RadioButton();
            this.lblImportFrom = new System.Windows.Forms.Label();
            this.gbImportFromFile = new System.Windows.Forms.GroupBox();
            this.btnAddSolutionFile = new System.Windows.Forms.Button();
            this.lblImportPath = new System.Windows.Forms.Label();
            this.txtImportPathValue = new System.Windows.Forms.TextBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.gbImport.SuspendLayout();
            this.gbImportSettings.SuspendLayout();
            this.gbSolutionInfo.SuspendLayout();
            this.gbImportFromQueue.SuspendLayout();
            this.pnlImportFrom.SuspendLayout();
            this.gbImportFromFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbImport
            // 
            this.gbImport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbImport.Controls.Add(this.gbImportSettings);
            this.gbImport.Controls.Add(this.gbSolutionInfo);
            this.gbImport.Controls.Add(this.gbImportFromQueue);
            this.gbImport.Controls.Add(this.pnlImportFrom);
            this.gbImport.Controls.Add(this.gbImportFromFile);
            this.gbImport.Location = new System.Drawing.Point(0, 0);
            this.gbImport.Name = "gbImport";
            this.gbImport.Size = new System.Drawing.Size(1200, 400);
            this.gbImport.TabIndex = 1;
            this.gbImport.TabStop = false;
            this.gbImport.Text = "Import Options";
            // 
            // gbImportSettings
            // 
            this.gbImportSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbImportSettings.Controls.Add(this.chbPublishWorkflows);
            this.gbImportSettings.Controls.Add(this.chbHoldingSolution);
            this.gbImportSettings.Controls.Add(this.chbOverwriteUnmanaged);
            this.gbImportSettings.Location = new System.Drawing.Point(603, 293);
            this.gbImportSettings.Name = "gbImportSettings";
            this.gbImportSettings.Size = new System.Drawing.Size(591, 104);
            this.gbImportSettings.TabIndex = 18;
            this.gbImportSettings.TabStop = false;
            this.gbImportSettings.Text = "Import Settings";
            // 
            // chbPublishWorkflows
            // 
            this.chbPublishWorkflows.AutoSize = true;
            this.chbPublishWorkflows.Checked = true;
            this.chbPublishWorkflows.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbPublishWorkflows.Location = new System.Drawing.Point(10, 75);
            this.chbPublishWorkflows.Name = "chbPublishWorkflows";
            this.chbPublishWorkflows.Size = new System.Drawing.Size(144, 21);
            this.chbPublishWorkflows.TabIndex = 6;
            this.chbPublishWorkflows.Text = "Publish Workflows";
            this.chbPublishWorkflows.UseVisualStyleBackColor = true;
            this.chbPublishWorkflows.CheckedChanged += new System.EventHandler(this.OptionsUpdated_CheckedChanged);
            // 
            // chbHoldingSolution
            // 
            this.chbHoldingSolution.AutoSize = true;
            this.chbHoldingSolution.Location = new System.Drawing.Point(10, 21);
            this.chbHoldingSolution.Name = "chbHoldingSolution";
            this.chbHoldingSolution.Size = new System.Drawing.Size(133, 21);
            this.chbHoldingSolution.TabIndex = 4;
            this.chbHoldingSolution.Text = "Holding Solution";
            this.chbHoldingSolution.UseVisualStyleBackColor = true;
            this.chbHoldingSolution.CheckedChanged += new System.EventHandler(this.OptionsUpdated_CheckedChanged);
            // 
            // chbOverwriteUnmanaged
            // 
            this.chbOverwriteUnmanaged.AutoSize = true;
            this.chbOverwriteUnmanaged.Checked = true;
            this.chbOverwriteUnmanaged.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbOverwriteUnmanaged.Location = new System.Drawing.Point(10, 48);
            this.chbOverwriteUnmanaged.Name = "chbOverwriteUnmanaged";
            this.chbOverwriteUnmanaged.Size = new System.Drawing.Size(171, 21);
            this.chbOverwriteUnmanaged.TabIndex = 5;
            this.chbOverwriteUnmanaged.Text = "Overwrite Unmanaged";
            this.chbOverwriteUnmanaged.UseVisualStyleBackColor = true;
            this.chbOverwriteUnmanaged.CheckedChanged += new System.EventHandler(this.OptionsUpdated_CheckedChanged);
            // 
            // gbSolutionInfo
            // 
            this.gbSolutionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSolutionInfo.Controls.Add(this.lblExistingValue);
            this.gbSolutionInfo.Controls.Add(this.lblSolutionId);
            this.gbSolutionInfo.Controls.Add(this.lblExisting);
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
            this.gbSolutionInfo.Location = new System.Drawing.Point(603, 53);
            this.gbSolutionInfo.Name = "gbSolutionInfo";
            this.gbSolutionInfo.Size = new System.Drawing.Size(591, 234);
            this.gbSolutionInfo.TabIndex = 35;
            this.gbSolutionInfo.TabStop = false;
            this.gbSolutionInfo.Text = "Solution Details";
            // 
            // lblExistingValue
            // 
            this.lblExistingValue.AutoSize = true;
            this.lblExistingValue.Location = new System.Drawing.Point(111, 190);
            this.lblExistingValue.Name = "lblExistingValue";
            this.lblExistingValue.Size = new System.Drawing.Size(13, 17);
            this.lblExistingValue.TabIndex = 33;
            this.lblExistingValue.Text = "-";
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
            // lblExisting
            // 
            this.lblExisting.AutoSize = true;
            this.lblExisting.Location = new System.Drawing.Point(6, 180);
            this.lblExisting.Name = "lblExisting";
            this.lblExisting.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblExisting.Size = new System.Drawing.Size(60, 27);
            this.lblExisting.TabIndex = 32;
            this.lblExisting.Text = "Existing:";
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
            // gbImportFromQueue
            // 
            this.gbImportFromQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbImportFromQueue.Controls.Add(this.lvOperations);
            this.gbImportFromQueue.Location = new System.Drawing.Point(6, 159);
            this.gbImportFromQueue.Name = "gbImportFromQueue";
            this.gbImportFromQueue.Size = new System.Drawing.Size(591, 238);
            this.gbImportFromQueue.TabIndex = 12;
            this.gbImportFromQueue.TabStop = false;
            this.gbImportFromQueue.Text = "Import From Queue";
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
            this.lvOperations.Size = new System.Drawing.Size(577, 209);
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
            this.pnlImportFrom.Controls.Add(this.rbImportFromQueue);
            this.pnlImportFrom.Controls.Add(this.rbImportFromFile);
            this.pnlImportFrom.Controls.Add(this.lblImportFrom);
            this.pnlImportFrom.Location = new System.Drawing.Point(7, 21);
            this.pnlImportFrom.Name = "pnlImportFrom";
            this.pnlImportFrom.Size = new System.Drawing.Size(1186, 26);
            this.pnlImportFrom.TabIndex = 11;
            // 
            // rbImportFromQueue
            // 
            this.rbImportFromQueue.AutoSize = true;
            this.rbImportFromQueue.Location = new System.Drawing.Point(186, 3);
            this.rbImportFromQueue.Name = "rbImportFromQueue";
            this.rbImportFromQueue.Size = new System.Drawing.Size(72, 21);
            this.rbImportFromQueue.TabIndex = 14;
            this.rbImportFromQueue.Text = "Queue";
            this.rbImportFromQueue.UseVisualStyleBackColor = true;
            this.rbImportFromQueue.CheckedChanged += new System.EventHandler(this.rbImportFromQueue_CheckedChanged);
            // 
            // rbImportFromFile
            // 
            this.rbImportFromFile.AutoSize = true;
            this.rbImportFromFile.Checked = true;
            this.rbImportFromFile.Location = new System.Drawing.Point(112, 3);
            this.rbImportFromFile.Name = "rbImportFromFile";
            this.rbImportFromFile.Size = new System.Drawing.Size(51, 21);
            this.rbImportFromFile.TabIndex = 13;
            this.rbImportFromFile.TabStop = true;
            this.rbImportFromFile.Text = "File";
            this.rbImportFromFile.UseVisualStyleBackColor = true;
            this.rbImportFromFile.CheckedChanged += new System.EventHandler(this.rbImportFromFile_CheckedChanged);
            // 
            // lblImportFrom
            // 
            this.lblImportFrom.AutoSize = true;
            this.lblImportFrom.Location = new System.Drawing.Point(3, 5);
            this.lblImportFrom.Name = "lblImportFrom";
            this.lblImportFrom.Size = new System.Drawing.Size(87, 17);
            this.lblImportFrom.TabIndex = 16;
            this.lblImportFrom.Text = "Import From:";
            // 
            // gbImportFromFile
            // 
            this.gbImportFromFile.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbImportFromFile.Controls.Add(this.btnAddSolutionFile);
            this.gbImportFromFile.Controls.Add(this.lblImportPath);
            this.gbImportFromFile.Controls.Add(this.txtImportPathValue);
            this.gbImportFromFile.Location = new System.Drawing.Point(7, 53);
            this.gbImportFromFile.Name = "gbImportFromFile";
            this.gbImportFromFile.Size = new System.Drawing.Size(590, 100);
            this.gbImportFromFile.TabIndex = 10;
            this.gbImportFromFile.TabStop = false;
            this.gbImportFromFile.Text = "Import From File";
            // 
            // btnAddSolutionFile
            // 
            this.btnAddSolutionFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSolutionFile.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnAddSolutionFile.Location = new System.Drawing.Point(7, 22);
            this.btnAddSolutionFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddSolutionFile.Name = "btnAddSolutionFile";
            this.btnAddSolutionFile.Size = new System.Drawing.Size(577, 29);
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
            this.txtImportPathValue.Size = new System.Drawing.Size(530, 22);
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
            // ImportOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbImport);
            this.Name = "ImportOptions";
            this.Size = new System.Drawing.Size(1200, 400);
            this.gbImport.ResumeLayout(false);
            this.gbImportSettings.ResumeLayout(false);
            this.gbImportSettings.PerformLayout();
            this.gbSolutionInfo.ResumeLayout(false);
            this.gbSolutionInfo.PerformLayout();
            this.gbImportFromQueue.ResumeLayout(false);
            this.pnlImportFrom.ResumeLayout(false);
            this.pnlImportFrom.PerformLayout();
            this.gbImportFromFile.ResumeLayout(false);
            this.gbImportFromFile.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.GroupBox gbImport;
        private System.Windows.Forms.GroupBox gbImportSettings;
        private System.Windows.Forms.CheckBox chbPublishWorkflows;
        private System.Windows.Forms.CheckBox chbHoldingSolution;
        private System.Windows.Forms.CheckBox chbOverwriteUnmanaged;
        private System.Windows.Forms.GroupBox gbSolutionInfo;
        private System.Windows.Forms.Label lblExistingValue;
        private System.Windows.Forms.Label lblSolutionId;
        private System.Windows.Forms.Label lblExisting;
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
        private System.Windows.Forms.GroupBox gbImportFromQueue;
        private System.Windows.Forms.ListView lvOperations;
        private System.Windows.Forms.ColumnHeader chOpDisplayName;
        private System.Windows.Forms.ColumnHeader chOpLogicalName;
        private System.Windows.Forms.Panel pnlImportFrom;
        private System.Windows.Forms.RadioButton rbImportFromQueue;
        private System.Windows.Forms.RadioButton rbImportFromFile;
        private System.Windows.Forms.Label lblImportFrom;
        private System.Windows.Forms.GroupBox gbImportFromFile;
        private System.Windows.Forms.Button btnAddSolutionFile;
        private System.Windows.Forms.Label lblImportPath;
        private System.Windows.Forms.TextBox txtImportPathValue;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnCancel;
    }
}

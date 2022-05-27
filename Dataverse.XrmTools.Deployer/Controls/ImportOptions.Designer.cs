
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
            this.gbImportFromQueue = new System.Windows.Forms.GroupBox();
            this.lvOperations = new System.Windows.Forms.ListView();
            this.chOpDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOpLogicalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlImportFrom = new System.Windows.Forms.Panel();
            this.rbImportFromQueue = new System.Windows.Forms.RadioButton();
            this.rbImportFromFile = new System.Windows.Forms.RadioButton();
            this.lblImportFrom = new System.Windows.Forms.Label();
            this.gbImportFromFile = new System.Windows.Forms.GroupBox();
            this.lblImportPath = new System.Windows.Forms.Label();
            this.txtImportPathValue = new System.Windows.Forms.TextBox();
            this.btnAddSolutionFile = new System.Windows.Forms.Button();
            this.gbSolutionInfo = new System.Windows.Forms.GroupBox();
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
            this.gbImport.SuspendLayout();
            this.gbImportFromQueue.SuspendLayout();
            this.pnlImportFrom.SuspendLayout();
            this.gbImportFromFile.SuspendLayout();
            this.gbSolutionInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbImport
            // 
            this.gbImport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbImport.Controls.Add(this.gbImportFromQueue);
            this.gbImport.Controls.Add(this.pnlImportFrom);
            this.gbImport.Controls.Add(this.gbImportFromFile);
            this.gbImport.Controls.Add(this.gbSolutionInfo);
            this.gbImport.Location = new System.Drawing.Point(0, 0);
            this.gbImport.Name = "gbImport";
            this.gbImport.Size = new System.Drawing.Size(1200, 400);
            this.gbImport.TabIndex = 1;
            this.gbImport.TabStop = false;
            this.gbImport.Text = "Import Options";
            // 
            // gbImportFromQueue
            // 
            this.gbImportFromQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbImportFromQueue.Controls.Add(this.lvOperations);
            this.gbImportFromQueue.Location = new System.Drawing.Point(7, 145);
            this.gbImportFromQueue.Name = "gbImportFromQueue";
            this.gbImportFromQueue.Size = new System.Drawing.Size(744, 249);
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
            this.lvOperations.Size = new System.Drawing.Size(730, 220);
            this.lvOperations.TabIndex = 3;
            this.lvOperations.UseCompatibleStateImageBehavior = false;
            this.lvOperations.View = System.Windows.Forms.View.Details;
            // 
            // chOpDisplayName
            // 
            this.chOpDisplayName.Text = "Display Name";
            this.chOpDisplayName.Width = 350;
            // 
            // chOpLogicalName
            // 
            this.chOpLogicalName.Text = "Logical Name";
            this.chOpLogicalName.Width = 350;
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
            this.gbImportFromFile.Controls.Add(this.lblImportPath);
            this.gbImportFromFile.Controls.Add(this.txtImportPathValue);
            this.gbImportFromFile.Controls.Add(this.btnAddSolutionFile);
            this.gbImportFromFile.Location = new System.Drawing.Point(7, 53);
            this.gbImportFromFile.Name = "gbImportFromFile";
            this.gbImportFromFile.Size = new System.Drawing.Size(744, 86);
            this.gbImportFromFile.TabIndex = 10;
            this.gbImportFromFile.TabStop = false;
            this.gbImportFromFile.Text = "Import From File";
            // 
            // lblImportPath
            // 
            this.lblImportPath.AutoSize = true;
            this.lblImportPath.Location = new System.Drawing.Point(6, 18);
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
            this.txtImportPathValue.Location = new System.Drawing.Point(54, 25);
            this.txtImportPathValue.Margin = new System.Windows.Forms.Padding(4);
            this.txtImportPathValue.Name = "txtImportPathValue";
            this.txtImportPathValue.ReadOnly = true;
            this.txtImportPathValue.Size = new System.Drawing.Size(683, 22);
            this.txtImportPathValue.TabIndex = 16;
            // 
            // btnAddSolutionFile
            // 
            this.btnAddSolutionFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSolutionFile.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnAddSolutionFile.Location = new System.Drawing.Point(7, 50);
            this.btnAddSolutionFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddSolutionFile.Name = "btnAddSolutionFile";
            this.btnAddSolutionFile.Size = new System.Drawing.Size(730, 29);
            this.btnAddSolutionFile.TabIndex = 8;
            this.btnAddSolutionFile.Text = "Add Solution File...";
            this.btnAddSolutionFile.UseVisualStyleBackColor = true;
            this.btnAddSolutionFile.Click += new System.EventHandler(this.btnAddSolution_Click);
            // 
            // gbSolutionInfo
            // 
            this.gbSolutionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
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
            this.gbSolutionInfo.Location = new System.Drawing.Point(757, 53);
            this.gbSolutionInfo.Name = "gbSolutionInfo";
            this.gbSolutionInfo.Size = new System.Drawing.Size(436, 341);
            this.gbSolutionInfo.TabIndex = 9;
            this.gbSolutionInfo.TabStop = false;
            this.gbSolutionInfo.Text = "Solution Details";
            // 
            // lblPublisherValue
            // 
            this.lblPublisherValue.AutoSize = true;
            this.lblPublisherValue.Location = new System.Drawing.Point(111, 131);
            this.lblPublisherValue.Name = "lblPublisherValue";
            this.lblPublisherValue.Size = new System.Drawing.Size(13, 17);
            this.lblPublisherValue.TabIndex = 9;
            this.lblPublisherValue.Text = "-";
            // 
            // lblPublisher
            // 
            this.lblPublisher.AutoSize = true;
            this.lblPublisher.Location = new System.Drawing.Point(6, 121);
            this.lblPublisher.Name = "lblPublisher";
            this.lblPublisher.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblPublisher.Size = new System.Drawing.Size(71, 27);
            this.lblPublisher.TabIndex = 8;
            this.lblPublisher.Text = "Publisher:";
            // 
            // lblManagedValue
            // 
            this.lblManagedValue.AutoSize = true;
            this.lblManagedValue.Location = new System.Drawing.Point(111, 104);
            this.lblManagedValue.Name = "lblManagedValue";
            this.lblManagedValue.Size = new System.Drawing.Size(13, 17);
            this.lblManagedValue.TabIndex = 7;
            this.lblManagedValue.Text = "-";
            // 
            // lblManaged
            // 
            this.lblManaged.AutoSize = true;
            this.lblManaged.Location = new System.Drawing.Point(6, 94);
            this.lblManaged.Name = "lblManaged";
            this.lblManaged.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblManaged.Size = new System.Drawing.Size(85, 27);
            this.lblManaged.TabIndex = 6;
            this.lblManaged.Text = "Is Managed:";
            // 
            // lblVersionValue
            // 
            this.lblVersionValue.AutoSize = true;
            this.lblVersionValue.Location = new System.Drawing.Point(111, 77);
            this.lblVersionValue.Name = "lblVersionValue";
            this.lblVersionValue.Size = new System.Drawing.Size(13, 17);
            this.lblVersionValue.TabIndex = 5;
            this.lblVersionValue.Text = "-";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(6, 67);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblVersion.Size = new System.Drawing.Size(60, 27);
            this.lblVersion.TabIndex = 4;
            this.lblVersion.Text = "Version:";
            // 
            // lblDisplayNameValue
            // 
            this.lblDisplayNameValue.AutoSize = true;
            this.lblDisplayNameValue.Location = new System.Drawing.Point(111, 50);
            this.lblDisplayNameValue.Name = "lblDisplayNameValue";
            this.lblDisplayNameValue.Size = new System.Drawing.Size(13, 17);
            this.lblDisplayNameValue.TabIndex = 3;
            this.lblDisplayNameValue.Text = "-";
            // 
            // lblLogicalNameValue
            // 
            this.lblLogicalNameValue.AutoSize = true;
            this.lblLogicalNameValue.Location = new System.Drawing.Point(111, 23);
            this.lblLogicalNameValue.Name = "lblLogicalNameValue";
            this.lblLogicalNameValue.Size = new System.Drawing.Size(13, 17);
            this.lblLogicalNameValue.TabIndex = 2;
            this.lblLogicalNameValue.Text = "-";
            // 
            // lblLogicalName
            // 
            this.lblLogicalName.AutoSize = true;
            this.lblLogicalName.Location = new System.Drawing.Point(6, 18);
            this.lblLogicalName.Name = "lblLogicalName";
            this.lblLogicalName.Padding = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.lblLogicalName.Size = new System.Drawing.Size(98, 22);
            this.lblLogicalName.TabIndex = 1;
            this.lblLogicalName.Text = "Logical Name:";
            // 
            // lblDisplayName
            // 
            this.lblDisplayName.AutoSize = true;
            this.lblDisplayName.Location = new System.Drawing.Point(6, 40);
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
            // ImportOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbImport);
            this.Name = "ImportOptions";
            this.Size = new System.Drawing.Size(1200, 400);
            this.gbImport.ResumeLayout(false);
            this.gbImportFromQueue.ResumeLayout(false);
            this.pnlImportFrom.ResumeLayout(false);
            this.pnlImportFrom.PerformLayout();
            this.gbImportFromFile.ResumeLayout(false);
            this.gbImportFromFile.PerformLayout();
            this.gbSolutionInfo.ResumeLayout(false);
            this.gbSolutionInfo.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.GroupBox gbImport;
        private System.Windows.Forms.Button btnAddSolutionFile;
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
        private System.Windows.Forms.GroupBox gbImportFromFile;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RadioButton rbImportFromFile;
        private System.Windows.Forms.RadioButton rbImportFromQueue;
        private System.Windows.Forms.Label lblImportFrom;
        private System.Windows.Forms.Panel pnlImportFrom;
        private System.Windows.Forms.Label lblImportPath;
        private System.Windows.Forms.TextBox txtImportPathValue;
        private System.Windows.Forms.GroupBox gbImportFromQueue;
        private System.Windows.Forms.ListView lvOperations;
        private System.Windows.Forms.ColumnHeader chOpDisplayName;
        private System.Windows.Forms.ColumnHeader chOpLogicalName;
    }
}

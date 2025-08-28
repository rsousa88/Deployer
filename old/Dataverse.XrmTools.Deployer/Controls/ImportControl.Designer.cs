namespace Dataverse.XrmTools.Deployer.Controls
{
    partial class ImportControl
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
            this.gbImportOperation = new System.Windows.Forms.GroupBox();
            this.lvOperations = new System.Windows.Forms.ListView();
            this.chOpDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOpLogicalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbImportQueue = new System.Windows.Forms.GroupBox();
            this.lvImportQueue = new System.Windows.Forms.ListView();
            this.chImpQueIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chImpQueDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbImportSettings = new System.Windows.Forms.GroupBox();
            this.chbPublishWorkflows = new System.Windows.Forms.CheckBox();
            this.chbOverwriteUnmanaged = new System.Windows.Forms.CheckBox();
            this.gbImportOptions = new System.Windows.Forms.GroupBox();
            this.pnlImportFrom = new System.Windows.Forms.Panel();
            this.rbImportFromQueue = new System.Windows.Forms.RadioButton();
            this.rbImportFromFile = new System.Windows.Forms.RadioButton();
            this.lblImportFrom = new System.Windows.Forms.Label();
            this.btnAddToQueue = new System.Windows.Forms.Button();
            this.gbImportFromFile = new System.Windows.Forms.GroupBox();
            this.btnAddSolutionFile = new System.Windows.Forms.Button();
            this.gbImportOperation.SuspendLayout();
            this.gbImportQueue.SuspendLayout();
            this.gbImportSettings.SuspendLayout();
            this.gbImportOptions.SuspendLayout();
            this.pnlImportFrom.SuspendLayout();
            this.gbImportFromFile.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbImportOperation
            // 
            this.gbImportOperation.Controls.Add(this.lvOperations);
            this.gbImportOperation.Controls.Add(this.gbImportQueue);
            this.gbImportOperation.Controls.Add(this.gbImportSettings);
            this.gbImportOperation.Controls.Add(this.gbImportOptions);
            this.gbImportOperation.Controls.Add(this.btnAddToQueue);
            this.gbImportOperation.Controls.Add(this.gbImportFromFile);
            this.gbImportOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbImportOperation.Location = new System.Drawing.Point(0, 0);
            this.gbImportOperation.Name = "gbImportOperation";
            this.gbImportOperation.Size = new System.Drawing.Size(1000, 500);
            this.gbImportOperation.TabIndex = 3;
            this.gbImportOperation.TabStop = false;
            this.gbImportOperation.Text = "Import Operation";
            // 
            // lvOperations
            // 
            this.lvOperations.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvOperations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chOpDisplayName,
            this.chOpLogicalName});
            this.lvOperations.FullRowSelect = true;
            this.lvOperations.HideSelection = false;
            this.lvOperations.Location = new System.Drawing.Point(7, 96);
            this.lvOperations.Margin = new System.Windows.Forms.Padding(4);
            this.lvOperations.MultiSelect = false;
            this.lvOperations.Name = "lvOperations";
            this.lvOperations.Size = new System.Drawing.Size(504, 402);
            this.lvOperations.TabIndex = 26;
            this.lvOperations.UseCompatibleStateImageBehavior = false;
            this.lvOperations.View = System.Windows.Forms.View.Details;
            this.lvOperations.DoubleClick += new System.EventHandler(this.lvOperations_DoubleClick);
            this.lvOperations.Resize += new System.EventHandler(this.lvOperations_Resize);
            // 
            // chOpDisplayName
            // 
            this.chOpDisplayName.Text = "Display Name";
            this.chOpDisplayName.Width = 276;
            // 
            // chOpLogicalName
            // 
            this.chOpLogicalName.Text = "Logical Name";
            this.chOpLogicalName.Width = 209;
            // 
            // gbImportQueue
            // 
            this.gbImportQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbImportQueue.Controls.Add(this.lvImportQueue);
            this.gbImportQueue.Location = new System.Drawing.Point(518, 170);
            this.gbImportQueue.Name = "gbImportQueue";
            this.gbImportQueue.Size = new System.Drawing.Size(476, 258);
            this.gbImportQueue.TabIndex = 28;
            this.gbImportQueue.TabStop = false;
            this.gbImportQueue.Text = "Import Queue";
            // 
            // lvImportQueue
            // 
            this.lvImportQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvImportQueue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chImpQueIndex,
            this.chImpQueDisplayName});
            this.lvImportQueue.FullRowSelect = true;
            this.lvImportQueue.HideSelection = false;
            this.lvImportQueue.Location = new System.Drawing.Point(7, 22);
            this.lvImportQueue.Margin = new System.Windows.Forms.Padding(4);
            this.lvImportQueue.Name = "lvImportQueue";
            this.lvImportQueue.Size = new System.Drawing.Size(462, 229);
            this.lvImportQueue.TabIndex = 27;
            this.lvImportQueue.UseCompatibleStateImageBehavior = false;
            this.lvImportQueue.View = System.Windows.Forms.View.Details;
            this.lvImportQueue.Resize += new System.EventHandler(this.lvImportQueue_Resize);
            // 
            // chImpQueIndex
            // 
            this.chImpQueIndex.Text = "Index";
            this.chImpQueIndex.Width = 58;
            // 
            // chImpQueDisplayName
            // 
            this.chImpQueDisplayName.Text = "Display Name";
            this.chImpQueDisplayName.Width = 394;
            // 
            // gbImportSettings
            // 
            this.gbImportSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbImportSettings.Controls.Add(this.chbPublishWorkflows);
            this.gbImportSettings.Controls.Add(this.chbOverwriteUnmanaged);
            this.gbImportSettings.Location = new System.Drawing.Point(518, 85);
            this.gbImportSettings.Name = "gbImportSettings";
            this.gbImportSettings.Size = new System.Drawing.Size(476, 79);
            this.gbImportSettings.TabIndex = 27;
            this.gbImportSettings.TabStop = false;
            this.gbImportSettings.Text = "Import Settings";
            // 
            // chbPublishWorkflows
            // 
            this.chbPublishWorkflows.AutoSize = true;
            this.chbPublishWorkflows.Checked = true;
            this.chbPublishWorkflows.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbPublishWorkflows.Location = new System.Drawing.Point(6, 47);
            this.chbPublishWorkflows.Name = "chbPublishWorkflows";
            this.chbPublishWorkflows.Size = new System.Drawing.Size(138, 20);
            this.chbPublishWorkflows.TabIndex = 6;
            this.chbPublishWorkflows.Text = "Publish Workflows";
            this.chbPublishWorkflows.UseVisualStyleBackColor = true;
            this.chbPublishWorkflows.CheckedChanged += new System.EventHandler(this.chbPublishWorkflows_CheckedChanged);
            // 
            // chbOverwriteUnmanaged
            // 
            this.chbOverwriteUnmanaged.AutoSize = true;
            this.chbOverwriteUnmanaged.Checked = true;
            this.chbOverwriteUnmanaged.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbOverwriteUnmanaged.Location = new System.Drawing.Point(6, 21);
            this.chbOverwriteUnmanaged.Name = "chbOverwriteUnmanaged";
            this.chbOverwriteUnmanaged.Size = new System.Drawing.Size(163, 20);
            this.chbOverwriteUnmanaged.TabIndex = 5;
            this.chbOverwriteUnmanaged.Text = "Overwrite Unmanaged";
            this.chbOverwriteUnmanaged.UseVisualStyleBackColor = true;
            this.chbOverwriteUnmanaged.CheckedChanged += new System.EventHandler(this.chbOverwriteUnmanaged_CheckedChanged);
            // 
            // gbImportOptions
            // 
            this.gbImportOptions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbImportOptions.Controls.Add(this.pnlImportFrom);
            this.gbImportOptions.Location = new System.Drawing.Point(518, 21);
            this.gbImportOptions.Name = "gbImportOptions";
            this.gbImportOptions.Size = new System.Drawing.Size(476, 58);
            this.gbImportOptions.TabIndex = 25;
            this.gbImportOptions.TabStop = false;
            this.gbImportOptions.Text = "Import Options";
            // 
            // pnlImportFrom
            // 
            this.pnlImportFrom.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlImportFrom.Controls.Add(this.rbImportFromQueue);
            this.pnlImportFrom.Controls.Add(this.rbImportFromFile);
            this.pnlImportFrom.Controls.Add(this.lblImportFrom);
            this.pnlImportFrom.Location = new System.Drawing.Point(6, 21);
            this.pnlImportFrom.Name = "pnlImportFrom";
            this.pnlImportFrom.Size = new System.Drawing.Size(464, 26);
            this.pnlImportFrom.TabIndex = 24;
            // 
            // rbImportFromQueue
            // 
            this.rbImportFromQueue.AutoSize = true;
            this.rbImportFromQueue.Location = new System.Drawing.Point(186, 3);
            this.rbImportFromQueue.Name = "rbImportFromQueue";
            this.rbImportFromQueue.Size = new System.Drawing.Size(68, 20);
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
            this.rbImportFromFile.Size = new System.Drawing.Size(50, 20);
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
            this.lblImportFrom.Size = new System.Drawing.Size(81, 16);
            this.lblImportFrom.TabIndex = 16;
            this.lblImportFrom.Text = "Import From:";
            // 
            // btnAddToQueue
            // 
            this.btnAddToQueue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddToQueue.Location = new System.Drawing.Point(518, 434);
            this.btnAddToQueue.Name = "btnAddToQueue";
            this.btnAddToQueue.Size = new System.Drawing.Size(475, 60);
            this.btnAddToQueue.TabIndex = 10;
            this.btnAddToQueue.Text = "Add to main queue";
            this.btnAddToQueue.UseVisualStyleBackColor = true;
            this.btnAddToQueue.Click += new System.EventHandler(this.btnAddToQueue_Click);
            // 
            // gbImportFromFile
            // 
            this.gbImportFromFile.Controls.Add(this.btnAddSolutionFile);
            this.gbImportFromFile.Location = new System.Drawing.Point(7, 27);
            this.gbImportFromFile.Name = "gbImportFromFile";
            this.gbImportFromFile.Size = new System.Drawing.Size(504, 62);
            this.gbImportFromFile.TabIndex = 28;
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
            this.btnAddSolutionFile.Size = new System.Drawing.Size(491, 29);
            this.btnAddSolutionFile.TabIndex = 8;
            this.btnAddSolutionFile.Text = "Add Solution File...";
            this.btnAddSolutionFile.UseVisualStyleBackColor = true;
            this.btnAddSolutionFile.Click += new System.EventHandler(this.btnAddSolutionFile_Click);
            // 
            // ImportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.gbImportOperation);
            this.Name = "ImportControl";
            this.Size = new System.Drawing.Size(1000, 500);
            this.gbImportOperation.ResumeLayout(false);
            this.gbImportQueue.ResumeLayout(false);
            this.gbImportSettings.ResumeLayout(false);
            this.gbImportSettings.PerformLayout();
            this.gbImportOptions.ResumeLayout(false);
            this.pnlImportFrom.ResumeLayout(false);
            this.pnlImportFrom.PerformLayout();
            this.gbImportFromFile.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbImportOperation;
        private System.Windows.Forms.Button btnAddToQueue;
        private System.Windows.Forms.GroupBox gbImportOptions;
        private System.Windows.Forms.ListView lvOperations;
        private System.Windows.Forms.ColumnHeader chOpDisplayName;
        private System.Windows.Forms.ColumnHeader chOpLogicalName;
        private System.Windows.Forms.Panel pnlImportFrom;
        private System.Windows.Forms.RadioButton rbImportFromQueue;
        private System.Windows.Forms.RadioButton rbImportFromFile;
        private System.Windows.Forms.Label lblImportFrom;
        private System.Windows.Forms.GroupBox gbImportSettings;
        private System.Windows.Forms.CheckBox chbPublishWorkflows;
        private System.Windows.Forms.CheckBox chbOverwriteUnmanaged;
        private System.Windows.Forms.GroupBox gbImportFromFile;
        private System.Windows.Forms.Button btnAddSolutionFile;
        private System.Windows.Forms.GroupBox gbImportQueue;
        private System.Windows.Forms.ListView lvImportQueue;
        private System.Windows.Forms.ColumnHeader chImpQueDisplayName;
        private System.Windows.Forms.ColumnHeader chImpQueIndex;
    }
}

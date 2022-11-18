namespace Dataverse.XrmTools.Deployer.Controls
{
    partial class ExportControl
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
            this.gbExportOperation = new System.Windows.Forms.GroupBox();
            this.gbUpdateOptions = new System.Windows.Forms.GroupBox();
            this.cbUpdate = new System.Windows.Forms.CheckBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.txtUpdateVersion = new System.Windows.Forms.TextBox();
            this.gbExportOptions = new System.Windows.Forms.GroupBox();
            this.lblType = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbManaged = new System.Windows.Forms.RadioButton();
            this.rbUnmanaged = new System.Windows.Forms.RadioButton();
            this.btnAddToQueue = new System.Windows.Forms.Button();
            this.lvSolutions = new System.Windows.Forms.ListView();
            this.chSolDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolManaged = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolPublisher = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblSolutionFilter = new System.Windows.Forms.Label();
            this.txtSolutionFilter = new System.Windows.Forms.TextBox();
            this.gbPackagerOptions = new System.Windows.Forms.GroupBox();
            this.cbUnpack = new System.Windows.Forms.CheckBox();
            this.cbPack = new System.Windows.Forms.CheckBox();
            this.gbExportOperation.SuspendLayout();
            this.gbUpdateOptions.SuspendLayout();
            this.gbExportOptions.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbPackagerOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbExportOperation
            // 
            this.gbExportOperation.Controls.Add(this.gbPackagerOptions);
            this.gbExportOperation.Controls.Add(this.gbUpdateOptions);
            this.gbExportOperation.Controls.Add(this.gbExportOptions);
            this.gbExportOperation.Controls.Add(this.btnAddToQueue);
            this.gbExportOperation.Controls.Add(this.lvSolutions);
            this.gbExportOperation.Controls.Add(this.lblSolutionFilter);
            this.gbExportOperation.Controls.Add(this.txtSolutionFilter);
            this.gbExportOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbExportOperation.Location = new System.Drawing.Point(0, 0);
            this.gbExportOperation.Name = "gbExportOperation";
            this.gbExportOperation.Size = new System.Drawing.Size(1000, 500);
            this.gbExportOperation.TabIndex = 3;
            this.gbExportOperation.TabStop = false;
            this.gbExportOperation.Text = "Export Operation";
            // 
            // gbUpdateOptions
            // 
            this.gbUpdateOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbUpdateOptions.Controls.Add(this.cbUpdate);
            this.gbUpdateOptions.Controls.Add(this.lblVersion);
            this.gbUpdateOptions.Controls.Add(this.txtUpdateVersion);
            this.gbUpdateOptions.Location = new System.Drawing.Point(643, 87);
            this.gbUpdateOptions.Name = "gbUpdateOptions";
            this.gbUpdateOptions.Size = new System.Drawing.Size(351, 57);
            this.gbUpdateOptions.TabIndex = 23;
            this.gbUpdateOptions.TabStop = false;
            this.gbUpdateOptions.Text = "Update Options";
            // 
            // cbUpdate
            // 
            this.cbUpdate.AutoSize = true;
            this.cbUpdate.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbUpdate.Checked = true;
            this.cbUpdate.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUpdate.Location = new System.Drawing.Point(6, 24);
            this.cbUpdate.Name = "cbUpdate";
            this.cbUpdate.Size = new System.Drawing.Size(121, 20);
            this.cbUpdate.TabIndex = 21;
            this.cbUpdate.Text = "Update version";
            this.cbUpdate.UseVisualStyleBackColor = true;
            this.cbUpdate.CheckedChanged += new System.EventHandler(this.cbUpdate_CheckedChanged);
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(165, 16);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblVersion.Size = new System.Drawing.Size(56, 26);
            this.lblVersion.TabIndex = 18;
            this.lblVersion.Text = "Version:";
            // 
            // txtUpdateVersion
            // 
            this.txtUpdateVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUpdateVersion.Location = new System.Drawing.Point(228, 20);
            this.txtUpdateVersion.Margin = new System.Windows.Forms.Padding(4);
            this.txtUpdateVersion.Name = "txtUpdateVersion";
            this.txtUpdateVersion.Size = new System.Drawing.Size(116, 22);
            this.txtUpdateVersion.TabIndex = 19;
            this.txtUpdateVersion.Tag = "";
            this.txtUpdateVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUpdateVersion.TextChanged += new System.EventHandler(this.txtUpdateVersion_TextChanged);
            // 
            // gbExportOptions
            // 
            this.gbExportOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbExportOptions.Controls.Add(this.lblType);
            this.gbExportOptions.Controls.Add(this.panel1);
            this.gbExportOptions.Location = new System.Drawing.Point(646, 21);
            this.gbExportOptions.Name = "gbExportOptions";
            this.gbExportOptions.Size = new System.Drawing.Size(351, 60);
            this.gbExportOptions.TabIndex = 22;
            this.gbExportOptions.TabStop = false;
            this.gbExportOptions.Text = "Export Options";
            // 
            // lblType
            // 
            this.lblType.AutoSize = true;
            this.lblType.Location = new System.Drawing.Point(6, 18);
            this.lblType.Name = "lblType";
            this.lblType.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblType.Size = new System.Drawing.Size(66, 26);
            this.lblType.TabIndex = 11;
            this.lblType.Text = "Export as:";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.rbManaged);
            this.panel1.Controls.Add(this.rbUnmanaged);
            this.panel1.Location = new System.Drawing.Point(78, 21);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(267, 26);
            this.panel1.TabIndex = 17;
            // 
            // rbManaged
            // 
            this.rbManaged.AutoSize = true;
            this.rbManaged.Checked = true;
            this.rbManaged.Location = new System.Drawing.Point(3, 3);
            this.rbManaged.Name = "rbManaged";
            this.rbManaged.Size = new System.Drawing.Size(86, 20);
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
            this.rbUnmanaged.Size = new System.Drawing.Size(103, 20);
            this.rbUnmanaged.TabIndex = 12;
            this.rbUnmanaged.Text = "Unmanaged";
            this.rbUnmanaged.UseVisualStyleBackColor = true;
            this.rbUnmanaged.CheckedChanged += new System.EventHandler(this.rbPackageType_CheckedChanged);
            // 
            // btnAddToQueue
            // 
            this.btnAddToQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddToQueue.Location = new System.Drawing.Point(854, 434);
            this.btnAddToQueue.Name = "btnAddToQueue";
            this.btnAddToQueue.Size = new System.Drawing.Size(139, 60);
            this.btnAddToQueue.TabIndex = 10;
            this.btnAddToQueue.Text = "Add to queue";
            this.btnAddToQueue.UseVisualStyleBackColor = true;
            this.btnAddToQueue.Click += new System.EventHandler(this.btnAddToQueue_Click);
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
            this.lvSolutions.Location = new System.Drawing.Point(10, 57);
            this.lvSolutions.Margin = new System.Windows.Forms.Padding(4);
            this.lvSolutions.Name = "lvSolutions";
            this.lvSolutions.Size = new System.Drawing.Size(625, 436);
            this.lvSolutions.TabIndex = 9;
            this.lvSolutions.UseCompatibleStateImageBehavior = false;
            this.lvSolutions.View = System.Windows.Forms.View.Details;
            this.lvSolutions.SelectedIndexChanged += new System.EventHandler(this.lvSolutions_SelectedIndexChanged);
            this.lvSolutions.Resize += new System.EventHandler(this.lvSolutions_Resize);
            // 
            // chSolDisplayName
            // 
            this.chSolDisplayName.Text = "Display Name";
            this.chSolDisplayName.Width = 250;
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
            // lblSolutionFilter
            // 
            this.lblSolutionFilter.AutoSize = true;
            this.lblSolutionFilter.Location = new System.Drawing.Point(7, 33);
            this.lblSolutionFilter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSolutionFilter.Name = "lblSolutionFilter";
            this.lblSolutionFilter.Size = new System.Drawing.Size(39, 16);
            this.lblSolutionFilter.TabIndex = 7;
            this.lblSolutionFilter.Text = "Filter:";
            // 
            // txtSolutionFilter
            // 
            this.txtSolutionFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSolutionFilter.Location = new System.Drawing.Point(54, 27);
            this.txtSolutionFilter.Margin = new System.Windows.Forms.Padding(4);
            this.txtSolutionFilter.Name = "txtSolutionFilter";
            this.txtSolutionFilter.Size = new System.Drawing.Size(581, 22);
            this.txtSolutionFilter.TabIndex = 8;
            this.txtSolutionFilter.TextChanged += new System.EventHandler(this.txtSolutionFilter_TextChanged);
            // 
            // gbPackagerOptions
            // 
            this.gbPackagerOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPackagerOptions.Controls.Add(this.cbPack);
            this.gbPackagerOptions.Controls.Add(this.cbUnpack);
            this.gbPackagerOptions.Location = new System.Drawing.Point(646, 150);
            this.gbPackagerOptions.Name = "gbPackagerOptions";
            this.gbPackagerOptions.Size = new System.Drawing.Size(351, 57);
            this.gbPackagerOptions.TabIndex = 24;
            this.gbPackagerOptions.TabStop = false;
            this.gbPackagerOptions.Text = "Solution Packager Options";
            // 
            // cbUnpack
            // 
            this.cbUnpack.AutoSize = true;
            this.cbUnpack.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbUnpack.Checked = true;
            this.cbUnpack.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbUnpack.Location = new System.Drawing.Point(6, 24);
            this.cbUnpack.Name = "cbUnpack";
            this.cbUnpack.Size = new System.Drawing.Size(76, 20);
            this.cbUnpack.TabIndex = 21;
            this.cbUnpack.Text = "Unpack";
            this.cbUnpack.UseVisualStyleBackColor = true;
            this.cbUnpack.CheckedChanged += new System.EventHandler(this.cbUnpack_CheckedChanged);
            // 
            // cbPack
            // 
            this.cbPack.AutoSize = true;
            this.cbPack.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbPack.Checked = true;
            this.cbPack.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPack.Location = new System.Drawing.Point(97, 24);
            this.cbPack.Name = "cbPack";
            this.cbPack.Size = new System.Drawing.Size(60, 20);
            this.cbPack.TabIndex = 22;
            this.cbPack.Text = "Pack";
            this.cbPack.UseVisualStyleBackColor = true;
            this.cbPack.CheckedChanged += new System.EventHandler(this.cbPack_CheckedChanged);
            // 
            // ExportControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.gbExportOperation);
            this.Name = "ExportControl";
            this.Size = new System.Drawing.Size(1000, 500);
            this.gbExportOperation.ResumeLayout(false);
            this.gbExportOperation.PerformLayout();
            this.gbUpdateOptions.ResumeLayout(false);
            this.gbUpdateOptions.PerformLayout();
            this.gbExportOptions.ResumeLayout(false);
            this.gbExportOptions.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbPackagerOptions.ResumeLayout(false);
            this.gbPackagerOptions.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbExportOperation;
        private System.Windows.Forms.Label lblSolutionFilter;
        private System.Windows.Forms.TextBox txtSolutionFilter;
        private System.Windows.Forms.ListView lvSolutions;
        private System.Windows.Forms.ColumnHeader chSolDisplayName;
        private System.Windows.Forms.ColumnHeader chSolVersion;
        private System.Windows.Forms.ColumnHeader chSolManaged;
        private System.Windows.Forms.ColumnHeader chSolPublisher;
        private System.Windows.Forms.Button btnAddToQueue;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbManaged;
        private System.Windows.Forms.RadioButton rbUnmanaged;
        private System.Windows.Forms.Label lblType;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.TextBox txtUpdateVersion;
        private System.Windows.Forms.GroupBox gbUpdateOptions;
        private System.Windows.Forms.CheckBox cbUpdate;
        private System.Windows.Forms.GroupBox gbExportOptions;
        private System.Windows.Forms.GroupBox gbPackagerOptions;
        private System.Windows.Forms.CheckBox cbUnpack;
        private System.Windows.Forms.CheckBox cbPack;
    }
}


using Dataverse.XrmTools.Deployer.Helpers;

namespace Dataverse.XrmTools.Deployer.Controls
{
    partial class DeleteOptions
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
            this.gbDeleteSettings = new System.Windows.Forms.GroupBox();
            this.lblSolutionFilter = new System.Windows.Forms.Label();
            this.txtSolutionFilter = new System.Windows.Forms.TextBox();
            this.lvSolutions = new System.Windows.Forms.ListView();
            this.chSolDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolManaged = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolPublisher = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnLoadSolutions = new System.Windows.Forms.Button();
            this.gbDelete = new System.Windows.Forms.GroupBox();
            this.gbSolutionInfo.SuspendLayout();
            this.gbDeleteSettings.SuspendLayout();
            this.gbDelete.SuspendLayout();
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
            this.gbSolutionInfo.Location = new System.Drawing.Point(757, 58);
            this.gbSolutionInfo.Name = "gbSolutionInfo";
            this.gbSolutionInfo.Size = new System.Drawing.Size(611, 401);
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
            // gbDeleteSettings
            // 
            this.gbDeleteSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbDeleteSettings.Controls.Add(this.lblSolutionFilter);
            this.gbDeleteSettings.Controls.Add(this.txtSolutionFilter);
            this.gbDeleteSettings.Controls.Add(this.lvSolutions);
            this.gbDeleteSettings.Location = new System.Drawing.Point(7, 58);
            this.gbDeleteSettings.Name = "gbDeleteSettings";
            this.gbDeleteSettings.Size = new System.Drawing.Size(744, 401);
            this.gbDeleteSettings.TabIndex = 10;
            this.gbDeleteSettings.TabStop = false;
            this.gbDeleteSettings.Text = "Delete Settings";
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
            this.btnLoadSolutions.Text = "Load all Solutions from Target instance";
            this.btnLoadSolutions.UseVisualStyleBackColor = true;
            this.btnLoadSolutions.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gbDelete
            // 
            this.gbDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDelete.Controls.Add(this.btnLoadSolutions);
            this.gbDelete.Controls.Add(this.gbDeleteSettings);
            this.gbDelete.Controls.Add(this.gbSolutionInfo);
            this.gbDelete.Location = new System.Drawing.Point(0, 0);
            this.gbDelete.Name = "gbDelete";
            this.gbDelete.Size = new System.Drawing.Size(1375, 465);
            this.gbDelete.TabIndex = 11;
            this.gbDelete.TabStop = false;
            this.gbDelete.Text = "Delete Options";
            // 
            // DeleteOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbDelete);
            this.Name = "DeleteOptions";
            this.Size = new System.Drawing.Size(1375, 465);
            this.gbSolutionInfo.ResumeLayout(false);
            this.gbSolutionInfo.PerformLayout();
            this.gbDeleteSettings.ResumeLayout(false);
            this.gbDeleteSettings.PerformLayout();
            this.gbDelete.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox gbDeleteSettings;
        private System.Windows.Forms.ListView lvSolutions;
        private System.Windows.Forms.ColumnHeader chSolDisplayName;
        private System.Windows.Forms.ColumnHeader chSolVersion;
        private System.Windows.Forms.ColumnHeader chSolManaged;
        private System.Windows.Forms.ColumnHeader chSolPublisher;
        private System.Windows.Forms.Label lblSolutionFilter;
        private System.Windows.Forms.TextBox txtSolutionFilter;
        private System.Windows.Forms.Button btnLoadSolutions;
        private System.Windows.Forms.GroupBox gbDelete;
        private System.Windows.Forms.Label lblSolutionIdValue;
        private System.Windows.Forms.Label lblSolutionId;
    }
}

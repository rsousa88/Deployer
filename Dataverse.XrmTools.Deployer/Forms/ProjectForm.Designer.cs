namespace Dataverse.XrmTools.Deployer.Forms
{
    partial class ProjectForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblProjectName = new System.Windows.Forms.Label();
            this.txtProjectName = new System.Windows.Forms.TextBox();
            this.gbSolutions = new System.Windows.Forms.GroupBox();
            this.lvSolutions = new System.Windows.Forms.ListView();
            this.chSolDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolManaged = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolPublisher = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblSolutionFilter = new System.Windows.Forms.Label();
            this.txtSolutionFilter = new System.Windows.Forms.TextBox();
            this.gbProjectDetails = new System.Windows.Forms.GroupBox();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnAddSourceDir = new System.Windows.Forms.Button();
            this.lblOutputDirPath = new System.Windows.Forms.Label();
            this.txtProjectDirPathValue = new System.Windows.Forms.TextBox();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.gbSolutions.SuspendLayout();
            this.gbProjectDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblProjectName
            // 
            this.lblProjectName.AutoSize = true;
            this.lblProjectName.Location = new System.Drawing.Point(6, 75);
            this.lblProjectName.Name = "lblProjectName";
            this.lblProjectName.Size = new System.Drawing.Size(92, 16);
            this.lblProjectName.TabIndex = 0;
            this.lblProjectName.Text = "Project Name:";
            // 
            // txtProjectName
            // 
            this.txtProjectName.Location = new System.Drawing.Point(104, 72);
            this.txtProjectName.Name = "txtProjectName";
            this.txtProjectName.Size = new System.Drawing.Size(623, 22);
            this.txtProjectName.TabIndex = 1;
            // 
            // gbSolutions
            // 
            this.gbSolutions.Controls.Add(this.lvSolutions);
            this.gbSolutions.Controls.Add(this.lblSolutionFilter);
            this.gbSolutions.Controls.Add(this.txtSolutionFilter);
            this.gbSolutions.Location = new System.Drawing.Point(12, 12);
            this.gbSolutions.Name = "gbSolutions";
            this.gbSolutions.Size = new System.Drawing.Size(1239, 345);
            this.gbSolutions.TabIndex = 4;
            this.gbSolutions.TabStop = false;
            this.gbSolutions.Text = "Select project solutions";
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
            this.lvSolutions.Location = new System.Drawing.Point(10, 54);
            this.lvSolutions.Margin = new System.Windows.Forms.Padding(4);
            this.lvSolutions.Name = "lvSolutions";
            this.lvSolutions.Size = new System.Drawing.Size(1222, 284);
            this.lvSolutions.TabIndex = 9;
            this.lvSolutions.UseCompatibleStateImageBehavior = false;
            this.lvSolutions.View = System.Windows.Forms.View.Details;
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
            // lblSolutionFilter
            // 
            this.lblSolutionFilter.AutoSize = true;
            this.lblSolutionFilter.Location = new System.Drawing.Point(7, 27);
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
            this.txtSolutionFilter.Location = new System.Drawing.Point(54, 24);
            this.txtSolutionFilter.Margin = new System.Windows.Forms.Padding(4);
            this.txtSolutionFilter.Name = "txtSolutionFilter";
            this.txtSolutionFilter.Size = new System.Drawing.Size(1178, 22);
            this.txtSolutionFilter.TabIndex = 8;
            this.txtSolutionFilter.TextChanged += new System.EventHandler(this.txtSolutionFilter_TextChanged);
            // 
            // gbProjectDetails
            // 
            this.gbProjectDetails.Controls.Add(this.btnOk);
            this.gbProjectDetails.Controls.Add(this.btnAddSourceDir);
            this.gbProjectDetails.Controls.Add(this.lblOutputDirPath);
            this.gbProjectDetails.Controls.Add(this.txtProjectDirPathValue);
            this.gbProjectDetails.Controls.Add(this.txtVersion);
            this.gbProjectDetails.Controls.Add(this.lblVersion);
            this.gbProjectDetails.Controls.Add(this.lblProjectName);
            this.gbProjectDetails.Controls.Add(this.txtProjectName);
            this.gbProjectDetails.Location = new System.Drawing.Point(12, 363);
            this.gbProjectDetails.Name = "gbProjectDetails";
            this.gbProjectDetails.Size = new System.Drawing.Size(1239, 114);
            this.gbProjectDetails.TabIndex = 5;
            this.gbProjectDetails.TabStop = false;
            this.gbProjectDetails.Text = "Project Details";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnOk.Location = new System.Drawing.Point(1050, 68);
            this.btnOk.Margin = new System.Windows.Forms.Padding(4);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(182, 29);
            this.btnOk.TabIndex = 21;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnAddSourceDir
            // 
            this.btnAddSourceDir.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSourceDir.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnAddSourceDir.Location = new System.Drawing.Point(1050, 29);
            this.btnAddSourceDir.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddSourceDir.Name = "btnAddSourceDir";
            this.btnAddSourceDir.Size = new System.Drawing.Size(182, 29);
            this.btnAddSourceDir.TabIndex = 20;
            this.btnAddSourceDir.Text = "Select Directory...";
            this.btnAddSourceDir.UseVisualStyleBackColor = true;
            this.btnAddSourceDir.Click += new System.EventHandler(this.btnAddSourceDir_Click);
            // 
            // lblOutputDirPath
            // 
            this.lblOutputDirPath.AutoSize = true;
            this.lblOutputDirPath.Location = new System.Drawing.Point(6, 29);
            this.lblOutputDirPath.Name = "lblOutputDirPath";
            this.lblOutputDirPath.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblOutputDirPath.Size = new System.Drawing.Size(37, 26);
            this.lblOutputDirPath.TabIndex = 19;
            this.lblOutputDirPath.Text = "Path:";
            // 
            // txtProjectDirPathValue
            // 
            this.txtProjectDirPathValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtProjectDirPathValue.Enabled = false;
            this.txtProjectDirPathValue.Location = new System.Drawing.Point(50, 33);
            this.txtProjectDirPathValue.Margin = new System.Windows.Forms.Padding(4);
            this.txtProjectDirPathValue.Name = "txtProjectDirPathValue";
            this.txtProjectDirPathValue.Size = new System.Drawing.Size(992, 22);
            this.txtProjectDirPathValue.TabIndex = 18;
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(828, 72);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(214, 22);
            this.txtVersion.TabIndex = 3;
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(733, 75);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(70, 20);
            this.lblVersion.TabIndex = 2;
            this.lblVersion.Text = "Version:";
            // 
            // ProjectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1263, 489);
            this.Controls.Add(this.gbProjectDetails);
            this.Controls.Add(this.gbSolutions);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ProjectForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New Project";
            this.gbSolutions.ResumeLayout(false);
            this.gbSolutions.PerformLayout();
            this.gbProjectDetails.ResumeLayout(false);
            this.gbProjectDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblProjectName;
        private System.Windows.Forms.GroupBox gbSolutions;
        private System.Windows.Forms.ListView lvSolutions;
        private System.Windows.Forms.ColumnHeader chSolDisplayName;
        private System.Windows.Forms.ColumnHeader chSolVersion;
        private System.Windows.Forms.ColumnHeader chSolManaged;
        private System.Windows.Forms.ColumnHeader chSolPublisher;
        private System.Windows.Forms.Label lblSolutionFilter;
        private System.Windows.Forms.TextBox txtSolutionFilter;
        private System.Windows.Forms.GroupBox gbProjectDetails;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.TextBox txtProjectName;
        private System.Windows.Forms.Button btnAddSourceDir;
        private System.Windows.Forms.Label lblOutputDirPath;
        private System.Windows.Forms.TextBox txtProjectDirPathValue;
        private System.Windows.Forms.Button btnOk;
    }
}
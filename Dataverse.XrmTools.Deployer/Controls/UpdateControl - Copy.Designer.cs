namespace Dataverse.XrmTools.Deployer.Controls
{
    partial class UpdateControlCopy
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
            this.btnLoadSolutions = new System.Windows.Forms.Button();
            this.gbUpdate = new System.Windows.Forms.GroupBox();
            this.gbSolutions = new System.Windows.Forms.GroupBox();
            this.lblSolutionFilter = new System.Windows.Forms.Label();
            this.txtSolutionFilter = new System.Windows.Forms.TextBox();
            this.lvSolutions = new System.Windows.Forms.ListView();
            this.chSolDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolManaged = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolPublisher = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbSolutionInfo = new System.Windows.Forms.GroupBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.txtUpdateVersion = new System.Windows.Forms.TextBox();
            this.gbUpdate.SuspendLayout();
            this.gbSolutions.SuspendLayout();
            this.gbSolutionInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLoadSolutions
            // 
            this.btnLoadSolutions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadSolutions.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnLoadSolutions.Location = new System.Drawing.Point(7, 22);
            this.btnLoadSolutions.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadSolutions.Name = "btnLoadSolutions";
            this.btnLoadSolutions.Size = new System.Drawing.Size(1428, 29);
            this.btnLoadSolutions.TabIndex = 1;
            this.btnLoadSolutions.Text = "Load Unmanaged Solutions from Source instance";
            this.btnLoadSolutions.UseVisualStyleBackColor = true;
            this.btnLoadSolutions.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // gbUpdate
            // 
            this.gbUpdate.Controls.Add(this.btnLoadSolutions);
            this.gbUpdate.Controls.Add(this.gbSolutions);
            this.gbUpdate.Controls.Add(this.gbSolutionInfo);
            this.gbUpdate.Location = new System.Drawing.Point(4, 4);
            this.gbUpdate.Name = "gbUpdate";
            this.gbUpdate.Size = new System.Drawing.Size(1442, 493);
            this.gbUpdate.TabIndex = 0;
            this.gbUpdate.TabStop = false;
            this.gbUpdate.Text = "Update Options";
            // 
            // gbSolutions
            // 
            this.gbSolutions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSolutions.Controls.Add(this.lblSolutionFilter);
            this.gbSolutions.Controls.Add(this.txtSolutionFilter);
            this.gbSolutions.Controls.Add(this.lvSolutions);
            this.gbSolutions.Location = new System.Drawing.Point(6, 58);
            this.gbSolutions.Name = "gbSolutions";
            this.gbSolutions.Size = new System.Drawing.Size(1159, 429);
            this.gbSolutions.TabIndex = 0;
            this.gbSolutions.TabStop = false;
            this.gbSolutions.Text = "Solutions";
            // 
            // lblSolutionFilter
            // 
            this.lblSolutionFilter.AutoSize = true;
            this.lblSolutionFilter.Location = new System.Drawing.Point(7, 26);
            this.lblSolutionFilter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSolutionFilter.Name = "lblSolutionFilter";
            this.lblSolutionFilter.Size = new System.Drawing.Size(39, 16);
            this.lblSolutionFilter.TabIndex = 0;
            this.lblSolutionFilter.Text = "Filter:";
            // 
            // txtSolutionFilter
            // 
            this.txtSolutionFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSolutionFilter.Location = new System.Drawing.Point(72, 23);
            this.txtSolutionFilter.Margin = new System.Windows.Forms.Padding(4);
            this.txtSolutionFilter.Name = "txtSolutionFilter";
            this.txtSolutionFilter.Size = new System.Drawing.Size(1080, 22);
            this.txtSolutionFilter.TabIndex = 2;
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
            this.lvSolutions.Size = new System.Drawing.Size(1145, 369);
            this.lvSolutions.TabIndex = 0;
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
            // gbSolutionInfo
            // 
            this.gbSolutionInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbSolutionInfo.Controls.Add(this.lblVersion);
            this.gbSolutionInfo.Controls.Add(this.txtUpdateVersion);
            this.gbSolutionInfo.Location = new System.Drawing.Point(1171, 58);
            this.gbSolutionInfo.Name = "gbSolutionInfo";
            this.gbSolutionInfo.Size = new System.Drawing.Size(265, 429);
            this.gbSolutionInfo.TabIndex = 0;
            this.gbSolutionInfo.TabStop = false;
            this.gbSolutionInfo.Text = "Solution Details";
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(6, 18);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblVersion.Size = new System.Drawing.Size(56, 26);
            this.lblVersion.TabIndex = 0;
            this.lblVersion.Text = "Version:";
            // 
            // txtUpdateVersion
            // 
            this.txtUpdateVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUpdateVersion.Location = new System.Drawing.Point(72, 22);
            this.txtUpdateVersion.Margin = new System.Windows.Forms.Padding(4);
            this.txtUpdateVersion.Name = "txtUpdateVersion";
            this.txtUpdateVersion.Size = new System.Drawing.Size(186, 22);
            this.txtUpdateVersion.TabIndex = 4;
            this.txtUpdateVersion.Tag = "";
            this.txtUpdateVersion.TextChanged += new System.EventHandler(this.txtUpdateVersion_TextChanged);
            // 
            // UpdateControlCopy
            // 
            this.Controls.Add(this.gbUpdate);
            this.Name = "UpdateControlCopy";
            this.Size = new System.Drawing.Size(2317, 1102);
            this.gbUpdate.ResumeLayout(false);
            this.gbSolutions.ResumeLayout(false);
            this.gbSolutions.PerformLayout();
            this.gbSolutionInfo.ResumeLayout(false);
            this.gbSolutionInfo.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion
        private System.Windows.Forms.Button btnLoadSolutions;
        private System.Windows.Forms.GroupBox gbUpdate;
        private System.Windows.Forms.GroupBox gbSolutions;
        private System.Windows.Forms.Label lblSolutionFilter;
        private System.Windows.Forms.TextBox txtSolutionFilter;
        private System.Windows.Forms.ListView lvSolutions;
        private System.Windows.Forms.ColumnHeader chSolDisplayName;
        private System.Windows.Forms.ColumnHeader chSolVersion;
        private System.Windows.Forms.ColumnHeader chSolManaged;
        private System.Windows.Forms.ColumnHeader chSolPublisher;
        private System.Windows.Forms.GroupBox gbSolutionInfo;
        private System.Windows.Forms.TextBox txtUpdateVersion;
        private System.Windows.Forms.Label lblVersion;
    }
}

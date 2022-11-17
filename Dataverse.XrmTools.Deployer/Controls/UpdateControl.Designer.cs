namespace Dataverse.XrmTools.Deployer.Controls
{
    partial class UpdateControl
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
            this.gbUpdateOperation = new System.Windows.Forms.GroupBox();
            this.lvSolutions = new System.Windows.Forms.ListView();
            this.chSolDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolManaged = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolPublisher = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblSolutionFilter = new System.Windows.Forms.Label();
            this.txtSolutionFilter = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.txtUpdateVersion = new System.Windows.Forms.TextBox();
            this.btnAddToQueue = new System.Windows.Forms.Button();
            this.gbUpdateOperation.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbUpdateOperation
            // 
            this.gbUpdateOperation.Controls.Add(this.btnAddToQueue);
            this.gbUpdateOperation.Controls.Add(this.lvSolutions);
            this.gbUpdateOperation.Controls.Add(this.lblSolutionFilter);
            this.gbUpdateOperation.Controls.Add(this.txtSolutionFilter);
            this.gbUpdateOperation.Controls.Add(this.lblVersion);
            this.gbUpdateOperation.Controls.Add(this.txtUpdateVersion);
            this.gbUpdateOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbUpdateOperation.Location = new System.Drawing.Point(0, 0);
            this.gbUpdateOperation.Name = "gbUpdateOperation";
            this.gbUpdateOperation.Size = new System.Drawing.Size(1000, 500);
            this.gbUpdateOperation.TabIndex = 3;
            this.gbUpdateOperation.TabStop = false;
            this.gbUpdateOperation.Text = "Update Operation";
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
            this.lvSolutions.Size = new System.Drawing.Size(983, 395);
            this.lvSolutions.TabIndex = 9;
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
            this.txtSolutionFilter.Size = new System.Drawing.Size(939, 22);
            this.txtSolutionFilter.TabIndex = 8;
            this.txtSolutionFilter.TextChanged += new System.EventHandler(this.txtSolutionFilter_TextChanged);
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(6, 453);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Padding = new System.Windows.Forms.Padding(0, 10, 0, 0);
            this.lblVersion.Size = new System.Drawing.Size(238, 26);
            this.lblVersion.TabIndex = 5;
            this.lblVersion.Text = "Update selected solutions with version:";
            // 
            // txtUpdateVersion
            // 
            this.txtUpdateVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtUpdateVersion.Location = new System.Drawing.Point(261, 457);
            this.txtUpdateVersion.Margin = new System.Windows.Forms.Padding(4);
            this.txtUpdateVersion.Name = "txtUpdateVersion";
            this.txtUpdateVersion.Size = new System.Drawing.Size(169, 22);
            this.txtUpdateVersion.TabIndex = 6;
            this.txtUpdateVersion.Tag = "";
            this.txtUpdateVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txtUpdateVersion.TextChanged += new System.EventHandler(this.txtUpdateVersion_TextChanged);
            // 
            // btnAddToQueue
            // 
            this.btnAddToQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddToQueue.Location = new System.Drawing.Point(813, 461);
            this.btnAddToQueue.Name = "btnAddToQueue";
            this.btnAddToQueue.Size = new System.Drawing.Size(181, 23);
            this.btnAddToQueue.TabIndex = 10;
            this.btnAddToQueue.Text = "Add to queue";
            this.btnAddToQueue.UseVisualStyleBackColor = true;
            this.btnAddToQueue.Click += new System.EventHandler(this.btnAddToQueue_Click);
            // 
            // UpdateControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.gbUpdateOperation);
            this.Name = "UpdateControl";
            this.Size = new System.Drawing.Size(1000, 500);
            this.gbUpdateOperation.ResumeLayout(false);
            this.gbUpdateOperation.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbUpdateOperation;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.TextBox txtUpdateVersion;
        private System.Windows.Forms.Label lblSolutionFilter;
        private System.Windows.Forms.TextBox txtSolutionFilter;
        private System.Windows.Forms.ListView lvSolutions;
        private System.Windows.Forms.ColumnHeader chSolDisplayName;
        private System.Windows.Forms.ColumnHeader chSolVersion;
        private System.Windows.Forms.ColumnHeader chSolManaged;
        private System.Windows.Forms.ColumnHeader chSolPublisher;
        private System.Windows.Forms.Button btnAddToQueue;
    }
}

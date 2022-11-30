namespace Dataverse.XrmTools.Deployer.Controls
{
    partial class DeleteControl
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
            this.gbDeleteOperation = new System.Windows.Forms.GroupBox();
            this.lblSolutionFilter = new System.Windows.Forms.Label();
            this.txtSolutionFilter = new System.Windows.Forms.TextBox();
            this.lvSolutions = new System.Windows.Forms.ListView();
            this.chSolDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolManaged = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolPublisher = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbDeleteQueue = new System.Windows.Forms.GroupBox();
            this.lvDeleteQueue = new System.Windows.Forms.ListView();
            this.chImpQueIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chImpQueDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnAddToQueue = new System.Windows.Forms.Button();
            this.gbDeleteOperation.SuspendLayout();
            this.gbDeleteQueue.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbDeleteOperation
            // 
            this.gbDeleteOperation.Controls.Add(this.lblSolutionFilter);
            this.gbDeleteOperation.Controls.Add(this.txtSolutionFilter);
            this.gbDeleteOperation.Controls.Add(this.lvSolutions);
            this.gbDeleteOperation.Controls.Add(this.gbDeleteQueue);
            this.gbDeleteOperation.Controls.Add(this.btnAddToQueue);
            this.gbDeleteOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDeleteOperation.Location = new System.Drawing.Point(0, 0);
            this.gbDeleteOperation.Name = "gbDeleteOperation";
            this.gbDeleteOperation.Size = new System.Drawing.Size(1000, 500);
            this.gbDeleteOperation.TabIndex = 3;
            this.gbDeleteOperation.TabStop = false;
            this.gbDeleteOperation.Text = "Delete Operation";
            // 
            // lblSolutionFilter
            // 
            this.lblSolutionFilter.AutoSize = true;
            this.lblSolutionFilter.Location = new System.Drawing.Point(7, 28);
            this.lblSolutionFilter.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSolutionFilter.Name = "lblSolutionFilter";
            this.lblSolutionFilter.Size = new System.Drawing.Size(39, 16);
            this.lblSolutionFilter.TabIndex = 30;
            this.lblSolutionFilter.Text = "Filter:";
            // 
            // txtSolutionFilter
            // 
            this.txtSolutionFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSolutionFilter.Location = new System.Drawing.Point(54, 22);
            this.txtSolutionFilter.Margin = new System.Windows.Forms.Padding(4);
            this.txtSolutionFilter.Name = "txtSolutionFilter";
            this.txtSolutionFilter.Size = new System.Drawing.Size(457, 22);
            this.txtSolutionFilter.TabIndex = 31;
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
            this.lvSolutions.Location = new System.Drawing.Point(7, 52);
            this.lvSolutions.Margin = new System.Windows.Forms.Padding(4);
            this.lvSolutions.Name = "lvSolutions";
            this.lvSolutions.Size = new System.Drawing.Size(504, 441);
            this.lvSolutions.TabIndex = 29;
            this.lvSolutions.UseCompatibleStateImageBehavior = false;
            this.lvSolutions.View = System.Windows.Forms.View.Details;
            this.lvSolutions.DoubleClick += new System.EventHandler(this.lvSolutions_DoubleClick);
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
            // gbDeleteQueue
            // 
            this.gbDeleteQueue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDeleteQueue.Controls.Add(this.lvDeleteQueue);
            this.gbDeleteQueue.Location = new System.Drawing.Point(518, 21);
            this.gbDeleteQueue.Name = "gbDeleteQueue";
            this.gbDeleteQueue.Size = new System.Drawing.Size(476, 407);
            this.gbDeleteQueue.TabIndex = 28;
            this.gbDeleteQueue.TabStop = false;
            this.gbDeleteQueue.Text = "Delete Queue";
            // 
            // lvDeleteQueue
            // 
            this.lvDeleteQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvDeleteQueue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chImpQueIndex,
            this.chImpQueDisplayName});
            this.lvDeleteQueue.FullRowSelect = true;
            this.lvDeleteQueue.HideSelection = false;
            this.lvDeleteQueue.Location = new System.Drawing.Point(7, 22);
            this.lvDeleteQueue.Margin = new System.Windows.Forms.Padding(4);
            this.lvDeleteQueue.Name = "lvDeleteQueue";
            this.lvDeleteQueue.Size = new System.Drawing.Size(462, 378);
            this.lvDeleteQueue.TabIndex = 27;
            this.lvDeleteQueue.UseCompatibleStateImageBehavior = false;
            this.lvDeleteQueue.View = System.Windows.Forms.View.Details;
            this.lvDeleteQueue.Resize += new System.EventHandler(this.lvDeleteQueue_Resize);
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
            // btnAddToQueue
            // 
            this.btnAddToQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddToQueue.Location = new System.Drawing.Point(518, 434);
            this.btnAddToQueue.Name = "btnAddToQueue";
            this.btnAddToQueue.Size = new System.Drawing.Size(475, 60);
            this.btnAddToQueue.TabIndex = 10;
            this.btnAddToQueue.Text = "Add to main queue";
            this.btnAddToQueue.UseVisualStyleBackColor = true;
            this.btnAddToQueue.Click += new System.EventHandler(this.btnAddToQueue_Click);
            // 
            // DeleteControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.gbDeleteOperation);
            this.Name = "DeleteControl";
            this.Size = new System.Drawing.Size(1000, 500);
            this.gbDeleteOperation.ResumeLayout(false);
            this.gbDeleteOperation.PerformLayout();
            this.gbDeleteQueue.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.GroupBox gbDeleteOperation;
        private System.Windows.Forms.Button btnAddToQueue;
        private System.Windows.Forms.GroupBox gbDeleteQueue;
        private System.Windows.Forms.ListView lvDeleteQueue;
        private System.Windows.Forms.ColumnHeader chImpQueDisplayName;
        private System.Windows.Forms.ColumnHeader chImpQueIndex;
        private System.Windows.Forms.ListView lvSolutions;
        private System.Windows.Forms.ColumnHeader chSolDisplayName;
        private System.Windows.Forms.ColumnHeader chSolVersion;
        private System.Windows.Forms.ColumnHeader chSolManaged;
        private System.Windows.Forms.ColumnHeader chSolPublisher;
        private System.Windows.Forms.Label lblSolutionFilter;
        private System.Windows.Forms.TextBox txtSolutionFilter;
    }
}

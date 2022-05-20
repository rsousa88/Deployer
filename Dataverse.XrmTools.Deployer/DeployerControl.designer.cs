namespace Dataverse.XrmTools.Deployer
{
    partial class DeployerControl
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbDeploy = new System.Windows.Forms.ToolStripButton();
            this.tsbAbort = new System.Windows.Forms.ToolStripButton();
            this.pnlMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSettings = new System.Windows.Forms.TableLayoutPanel();
            this.gbEnvironments = new System.Windows.Forms.GroupBox();
            this.lblTarget = new System.Windows.Forms.Label();
            this.lblTargetValue = new System.Windows.Forms.Label();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.pnlBody = new System.Windows.Forms.TableLayoutPanel();
            this.gbQueue = new System.Windows.Forms.GroupBox();
            this.btnAddSolution = new System.Windows.Forms.Button();
            this.lvSolutions = new System.Windows.Forms.ListView();
            this.chSolDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolManaged = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolPublisher = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolPublisherLogicalNameHidden = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.gbLayers = new System.Windows.Forms.GroupBox();
            this.tsMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.gbEnvironments.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.gbQueue.SuspendLayout();
            this.cmsContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.AutoSize = false;
            this.tsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbDeploy,
            this.tsbAbort});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(2147, 30);
            this.tsMain.TabIndex = 9;
            this.tsMain.Text = "Queue Toolstrip";
            // 
            // tsbDeploy
            // 
            this.tsbDeploy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbDeploy.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tsbDeploy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeploy.Name = "tsbDeploy";
            this.tsbDeploy.Size = new System.Drawing.Size(89, 27);
            this.tsbDeploy.Text = "Start Deploy";
            this.tsbDeploy.Click += new System.EventHandler(this.tsbDeploy_Click);
            // 
            // tsbAbort
            // 
            this.tsbAbort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAbort.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tsbAbort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbort.Name = "tsbAbort";
            this.tsbAbort.Size = new System.Drawing.Size(48, 27);
            this.tsbAbort.Text = "Abort";
            this.tsbAbort.Visible = false;
            this.tsbAbort.Click += new System.EventHandler(this.tsbAbort_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.ColumnCount = 2;
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.pnlMain.Controls.Add(this.pnlSettings, 0, 0);
            this.pnlMain.Controls.Add(this.pnlBody, 1, 0);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 30);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.RowCount = 1;
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlMain.Size = new System.Drawing.Size(2147, 940);
            this.pnlMain.TabIndex = 91;
            // 
            // pnlSettings
            // 
            this.pnlSettings.ColumnCount = 1;
            this.pnlSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlSettings.Controls.Add(this.gbEnvironments, 0, 0);
            this.pnlSettings.Controls.Add(this.gbSettings, 0, 1);
            this.pnlSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSettings.Location = new System.Drawing.Point(3, 2);
            this.pnlSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.RowCount = 2;
            this.pnlSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnlSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.pnlSettings.Size = new System.Drawing.Size(423, 936);
            this.pnlSettings.TabIndex = 0;
            // 
            // gbEnvironments
            // 
            this.gbEnvironments.Controls.Add(this.lblTarget);
            this.gbEnvironments.Controls.Add(this.lblTargetValue);
            this.gbEnvironments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbEnvironments.Location = new System.Drawing.Point(3, 2);
            this.gbEnvironments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbEnvironments.Name = "gbEnvironments";
            this.gbEnvironments.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbEnvironments.Size = new System.Drawing.Size(417, 89);
            this.gbEnvironments.TabIndex = 0;
            this.gbEnvironments.TabStop = false;
            this.gbEnvironments.Text = "Environments";
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Location = new System.Drawing.Point(5, 30);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(50, 17);
            this.lblTarget.TabIndex = 0;
            this.lblTarget.Text = "Target";
            // 
            // lblTargetValue
            // 
            this.lblTargetValue.AutoSize = true;
            this.lblTargetValue.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblTargetValue.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTargetValue.Location = new System.Drawing.Point(65, 31);
            this.lblTargetValue.Name = "lblTargetValue";
            this.lblTargetValue.Size = new System.Drawing.Size(91, 19);
            this.lblTargetValue.TabIndex = 1;
            this.lblTargetValue.Text = "Disconnected";
            // 
            // gbSettings
            // 
            this.gbSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSettings.Location = new System.Drawing.Point(3, 95);
            this.gbSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbSettings.Size = new System.Drawing.Size(417, 839);
            this.gbSettings.TabIndex = 0;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // pnlBody
            // 
            this.pnlBody.ColumnCount = 10;
            this.pnlBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnlBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnlBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnlBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnlBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnlBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnlBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnlBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnlBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnlBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnlBody.Controls.Add(this.gbQueue, 0, 0);
            this.pnlBody.Controls.Add(this.gbLayers, 4, 0);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(432, 2);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.RowCount = 2;
            this.pnlBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.pnlBody.Size = new System.Drawing.Size(1712, 936);
            this.pnlBody.TabIndex = 1;
            // 
            // gbQueue
            // 
            this.pnlBody.SetColumnSpan(this.gbQueue, 6);
            this.gbQueue.Controls.Add(this.btnAddSolution);
            this.gbQueue.Controls.Add(this.lvSolutions);
            this.gbQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbQueue.Location = new System.Drawing.Point(3, 2);
            this.gbQueue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbQueue.Name = "gbQueue";
            this.gbQueue.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlBody.SetRowSpan(this.gbQueue, 2);
            this.gbQueue.Size = new System.Drawing.Size(1020, 932);
            this.gbQueue.TabIndex = 1;
            this.gbQueue.TabStop = false;
            this.gbQueue.Text = "Queue";
            // 
            // btnAddSolution
            // 
            this.btnAddSolution.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSolution.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnAddSolution.Location = new System.Drawing.Point(7, 21);
            this.btnAddSolution.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddSolution.Name = "btnAddSolution";
            this.btnAddSolution.Size = new System.Drawing.Size(1006, 29);
            this.btnAddSolution.TabIndex = 7;
            this.btnAddSolution.Text = "Add Solution to Queue";
            this.btnAddSolution.UseVisualStyleBackColor = true;
            this.btnAddSolution.Click += new System.EventHandler(this.btnAddSolution_Click);
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
            this.chSolPublisher,
            this.chSolPublisherLogicalNameHidden});
            this.lvSolutions.ContextMenuStrip = this.cmsContextMenu;
            this.lvSolutions.FullRowSelect = true;
            this.lvSolutions.HideSelection = false;
            this.lvSolutions.Location = new System.Drawing.Point(7, 58);
            this.lvSolutions.Margin = new System.Windows.Forms.Padding(4);
            this.lvSolutions.MultiSelect = false;
            this.lvSolutions.Name = "lvSolutions";
            this.lvSolutions.Size = new System.Drawing.Size(1006, 868);
            this.lvSolutions.TabIndex = 2;
            this.lvSolutions.UseCompatibleStateImageBehavior = false;
            this.lvSolutions.View = System.Windows.Forms.View.Details;
            this.lvSolutions.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
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
            this.chSolVersion.Width = 150;
            // 
            // chSolManaged
            // 
            this.chSolManaged.Text = "Is Managed";
            this.chSolManaged.Width = 150;
            // 
            // chSolPublisher
            // 
            this.chSolPublisher.Text = "Publisher";
            this.chSolPublisher.Width = 350;
            // 
            // chSolPublisherLogicalNameHidden
            // 
            this.chSolPublisherLogicalNameHidden.Text = "[Hidden] Publisher Logical Name";
            this.chSolPublisherLogicalNameHidden.Width = 0;
            // 
            // cmsContextMenu
            // 
            this.cmsContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiRemove});
            this.cmsContextMenu.Name = "cms_ContextMenu";
            this.cmsContextMenu.Size = new System.Drawing.Size(133, 28);
            // 
            // cmsiRemove
            // 
            this.cmsiRemove.Name = "cmsiRemove";
            this.cmsiRemove.Size = new System.Drawing.Size(132, 24);
            this.cmsiRemove.Text = "Remove";
            this.cmsiRemove.Click += new System.EventHandler(this.cmsiRemove_Click);
            // 
            // gbLayers
            // 
            this.pnlBody.SetColumnSpan(this.gbLayers, 4);
            this.gbLayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbLayers.Location = new System.Drawing.Point(1029, 2);
            this.gbLayers.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbLayers.Name = "gbLayers";
            this.gbLayers.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlBody.SetRowSpan(this.gbLayers, 2);
            this.gbLayers.Size = new System.Drawing.Size(680, 932);
            this.gbLayers.TabIndex = 2;
            this.gbLayers.TabStop = false;
            this.gbLayers.Text = "Active Layers";
            // 
            // DeployerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tsMain);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "DeployerControl";
            this.Size = new System.Drawing.Size(2147, 970);
            this.Load += new System.EventHandler(this.DataMigrationControl_Load);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlSettings.ResumeLayout(false);
            this.gbEnvironments.ResumeLayout(false);
            this.gbEnvironments.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.gbQueue.ResumeLayout(false);
            this.cmsContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        // Main components
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.TableLayoutPanel pnlMain;

        // Environments group
        private System.Windows.Forms.GroupBox gbEnvironments;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.Label lblTargetValue;

        // Settings
        private System.Windows.Forms.TableLayoutPanel pnlSettings;
        private System.Windows.Forms.GroupBox gbSettings;

        // Body
        private System.Windows.Forms.TableLayoutPanel pnlBody;

        // Queue Group
        private System.Windows.Forms.GroupBox gbQueue;
        private System.Windows.Forms.ToolStripButton tsbDeploy;
        private System.Windows.Forms.ToolStripButton tsbAbort;
        private System.Windows.Forms.Button btnAddSolution;
        private System.Windows.Forms.ListView lvSolutions;
        private System.Windows.Forms.ColumnHeader chSolDisplayName;
        private System.Windows.Forms.ColumnHeader chSolVersion;
        private System.Windows.Forms.ColumnHeader chSolManaged;
        private System.Windows.Forms.ColumnHeader chSolPublisher;
        private System.Windows.Forms.ColumnHeader chSolPublisherLogicalNameHidden;
        private System.Windows.Forms.ContextMenuStrip cmsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem cmsiRemove;

        // Layers Group
        private System.Windows.Forms.GroupBox gbLayers;
    }
}

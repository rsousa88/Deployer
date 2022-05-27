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
            this.tsbExecute = new System.Windows.Forms.ToolStripButton();
            this.tsbAbort = new System.Windows.Forms.ToolStripButton();
            this.pnlMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSettings = new System.Windows.Forms.TableLayoutPanel();
            this.gbEnvironments = new System.Windows.Forms.GroupBox();
            this.btnConnectSource = new System.Windows.Forms.Button();
            this.lblSource = new System.Windows.Forms.Label();
            this.lblSourceValue = new System.Windows.Forms.Label();
            this.lblTarget = new System.Windows.Forms.Label();
            this.lblTargetValue = new System.Windows.Forms.Label();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.pnlBody = new System.Windows.Forms.TableLayoutPanel();
            this.gbQueue = new System.Windows.Forms.GroupBox();
            this.btnClearQueue = new System.Windows.Forms.Button();
            this.btnAddOperation = new System.Windows.Forms.Button();
            this.lvOperations = new System.Windows.Forms.ListView();
            this.chOpType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOpLogicalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOpDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOpVersion = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOpManaged = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOpPublisher = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOpPublisherLogicalNameHidden = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.gbLogs = new System.Windows.Forms.GroupBox();
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.tsMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.gbEnvironments.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.gbQueue.SuspendLayout();
            this.cmsContextMenu.SuspendLayout();
            this.gbLogs.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.AutoSize = false;
            this.tsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExecute,
            this.tsbAbort});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(2147, 30);
            this.tsMain.TabIndex = 9;
            this.tsMain.Text = "Queue Toolstrip";
            // 
            // tsbExecute
            // 
            this.tsbExecute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbExecute.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tsbExecute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExecute.Name = "tsbExecute";
            this.tsbExecute.Size = new System.Drawing.Size(59, 27);
            this.tsbExecute.Text = "Execute";
            this.tsbExecute.Click += new System.EventHandler(this.tsbDeploy_Click);
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
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 85F));
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
            this.pnlSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18F));
            this.pnlSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 82F));
            this.pnlSettings.Size = new System.Drawing.Size(316, 936);
            this.pnlSettings.TabIndex = 0;
            // 
            // gbEnvironments
            // 
            this.gbEnvironments.Controls.Add(this.btnConnectSource);
            this.gbEnvironments.Controls.Add(this.lblSource);
            this.gbEnvironments.Controls.Add(this.lblSourceValue);
            this.gbEnvironments.Controls.Add(this.lblTarget);
            this.gbEnvironments.Controls.Add(this.lblTargetValue);
            this.gbEnvironments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbEnvironments.Location = new System.Drawing.Point(3, 2);
            this.gbEnvironments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbEnvironments.Name = "gbEnvironments";
            this.gbEnvironments.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbEnvironments.Size = new System.Drawing.Size(310, 136);
            this.gbEnvironments.TabIndex = 0;
            this.gbEnvironments.TabStop = false;
            this.gbEnvironments.Text = "Environments";
            // 
            // btnConnectSource
            // 
            this.btnConnectSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnectSource.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnConnectSource.Location = new System.Drawing.Point(7, 101);
            this.btnConnectSource.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnectSource.Name = "btnConnectSource";
            this.btnConnectSource.Size = new System.Drawing.Size(296, 29);
            this.btnConnectSource.TabIndex = 9;
            this.btnConnectSource.Text = "Add Source";
            this.btnConnectSource.UseVisualStyleBackColor = true;
            this.btnConnectSource.Click += new System.EventHandler(this.btnConnectSource_Click);
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(6, 61);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(53, 17);
            this.lblSource.TabIndex = 2;
            this.lblSource.Text = "Source";
            // 
            // lblSourceValue
            // 
            this.lblSourceValue.AutoSize = true;
            this.lblSourceValue.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblSourceValue.ForeColor = System.Drawing.Color.DarkRed;
            this.lblSourceValue.Location = new System.Drawing.Point(65, 61);
            this.lblSourceValue.Name = "lblSourceValue";
            this.lblSourceValue.Size = new System.Drawing.Size(91, 19);
            this.lblSourceValue.TabIndex = 3;
            this.lblSourceValue.Text = "Disconnected";
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
            this.lblTargetValue.Location = new System.Drawing.Point(65, 30);
            this.lblTargetValue.Name = "lblTargetValue";
            this.lblTargetValue.Size = new System.Drawing.Size(91, 19);
            this.lblTargetValue.TabIndex = 1;
            this.lblTargetValue.Text = "Disconnected";
            // 
            // gbSettings
            // 
            this.gbSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSettings.Location = new System.Drawing.Point(3, 142);
            this.gbSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbSettings.Size = new System.Drawing.Size(310, 792);
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
            this.pnlBody.Controls.Add(this.gbLogs, 4, 0);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(325, 2);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.RowCount = 2;
            this.pnlBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.pnlBody.Size = new System.Drawing.Size(1819, 936);
            this.pnlBody.TabIndex = 1;
            // 
            // gbQueue
            // 
            this.pnlBody.SetColumnSpan(this.gbQueue, 6);
            this.gbQueue.Controls.Add(this.btnClearQueue);
            this.gbQueue.Controls.Add(this.btnAddOperation);
            this.gbQueue.Controls.Add(this.lvOperations);
            this.gbQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbQueue.Location = new System.Drawing.Point(3, 2);
            this.gbQueue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbQueue.Name = "gbQueue";
            this.gbQueue.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlBody.SetRowSpan(this.gbQueue, 2);
            this.gbQueue.Size = new System.Drawing.Size(1080, 932);
            this.gbQueue.TabIndex = 1;
            this.gbQueue.TabStop = false;
            this.gbQueue.Text = "Queue";
            // 
            // btnClearQueue
            // 
            this.btnClearQueue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearQueue.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnClearQueue.Location = new System.Drawing.Point(808, 21);
            this.btnClearQueue.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearQueue.Name = "btnClearQueue";
            this.btnClearQueue.Size = new System.Drawing.Size(265, 29);
            this.btnClearQueue.TabIndex = 8;
            this.btnClearQueue.Text = "Clear Queue";
            this.btnClearQueue.UseVisualStyleBackColor = true;
            this.btnClearQueue.Click += new System.EventHandler(this.btnClearQueue_Click);
            // 
            // btnAddOperation
            // 
            this.btnAddOperation.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnAddOperation.Location = new System.Drawing.Point(7, 21);
            this.btnAddOperation.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddOperation.Name = "btnAddOperation";
            this.btnAddOperation.Size = new System.Drawing.Size(793, 29);
            this.btnAddOperation.TabIndex = 7;
            this.btnAddOperation.Text = "Add Operation to Queue";
            this.btnAddOperation.UseVisualStyleBackColor = true;
            this.btnAddOperation.Click += new System.EventHandler(this.btnAddOperation_Click);
            // 
            // lvOperations
            // 
            this.lvOperations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvOperations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chOpType,
            this.chOpLogicalName,
            this.chOpDisplayName,
            this.chOpVersion,
            this.chOpManaged,
            this.chOpPublisher,
            this.chOpPublisherLogicalNameHidden});
            this.lvOperations.ContextMenuStrip = this.cmsContextMenu;
            this.lvOperations.FullRowSelect = true;
            this.lvOperations.HideSelection = false;
            this.lvOperations.Location = new System.Drawing.Point(7, 58);
            this.lvOperations.Margin = new System.Windows.Forms.Padding(4);
            this.lvOperations.MultiSelect = false;
            this.lvOperations.Name = "lvOperations";
            this.lvOperations.Size = new System.Drawing.Size(1066, 868);
            this.lvOperations.TabIndex = 2;
            this.lvOperations.UseCompatibleStateImageBehavior = false;
            this.lvOperations.View = System.Windows.Forms.View.Details;
            this.lvOperations.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.lvOperations.Resize += new System.EventHandler(this.lvSolutions_Resize);
            // 
            // chOpType
            // 
            this.chOpType.Text = "Type";
            this.chOpType.Width = 100;
            // 
            // chOpLogicalName
            // 
            this.chOpLogicalName.Text = "[Hidden] Logical Name";
            this.chOpLogicalName.Width = 0;
            // 
            // chOpDisplayName
            // 
            this.chOpDisplayName.Text = "Display Name";
            this.chOpDisplayName.Width = 350;
            // 
            // chOpVersion
            // 
            this.chOpVersion.Text = "Version";
            this.chOpVersion.Width = 100;
            // 
            // chOpManaged
            // 
            this.chOpManaged.Text = "Is Managed";
            this.chOpManaged.Width = 150;
            // 
            // chOpPublisher
            // 
            this.chOpPublisher.Text = "Publisher";
            this.chOpPublisher.Width = 300;
            // 
            // chOpPublisherLogicalNameHidden
            // 
            this.chOpPublisherLogicalNameHidden.Text = "[Hidden] Publisher Logical Name";
            this.chOpPublisherLogicalNameHidden.Width = 0;
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
            // gbLogs
            // 
            this.pnlBody.SetColumnSpan(this.gbLogs, 4);
            this.gbLogs.Controls.Add(this.txtLogs);
            this.gbLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbLogs.Location = new System.Drawing.Point(1089, 2);
            this.gbLogs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbLogs.Name = "gbLogs";
            this.gbLogs.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlBody.SetRowSpan(this.gbLogs, 2);
            this.gbLogs.Size = new System.Drawing.Size(727, 932);
            this.gbLogs.TabIndex = 2;
            this.gbLogs.TabStop = false;
            this.gbLogs.Text = "Logs";
            // 
            // txtLogs
            // 
            this.txtLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogs.Location = new System.Drawing.Point(6, 20);
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.ReadOnly = true;
            this.txtLogs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogs.Size = new System.Drawing.Size(715, 907);
            this.txtLogs.TabIndex = 2;
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
            this.gbLogs.ResumeLayout(false);
            this.gbLogs.PerformLayout();
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
        private System.Windows.Forms.ToolStripButton tsbExecute;
        private System.Windows.Forms.ToolStripButton tsbAbort;
        private System.Windows.Forms.Button btnAddOperation;
        private System.Windows.Forms.ListView lvOperations;
        private System.Windows.Forms.ColumnHeader chOpType;
        private System.Windows.Forms.ColumnHeader chOpLogicalName;
        private System.Windows.Forms.ColumnHeader chOpDisplayName;
        private System.Windows.Forms.ColumnHeader chOpVersion;
        private System.Windows.Forms.ColumnHeader chOpManaged;
        private System.Windows.Forms.ColumnHeader chOpPublisher;
        private System.Windows.Forms.ColumnHeader chOpPublisherLogicalNameHidden;
        private System.Windows.Forms.ContextMenuStrip cmsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem cmsiRemove;

        // Layers Group
        private System.Windows.Forms.GroupBox gbLogs;
        private System.Windows.Forms.TextBox txtLogs;
        private System.Windows.Forms.Button btnClearQueue;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblSourceValue;
        private System.Windows.Forms.Button btnConnectSource;
    }
}

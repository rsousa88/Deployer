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
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.pnlMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSettings = new System.Windows.Forms.TableLayoutPanel();
            this.gbSolutionHistory = new System.Windows.Forms.GroupBox();
            this.lvSolutionHistory = new System.Windows.Forms.ListView();
            this.chSolHistName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolHistOperation = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolHistStatus = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnRefreshHistory = new System.Windows.Forms.Button();
            this.gbEnvironments = new System.Windows.Forms.GroupBox();
            this.btnConnectSource = new System.Windows.Forms.Button();
            this.lblSource = new System.Windows.Forms.Label();
            this.lblSourceValue = new System.Windows.Forms.Label();
            this.lblTarget = new System.Windows.Forms.Label();
            this.lblTargetValue = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.TableLayoutPanel();
            this.gbSolutionPackager = new System.Windows.Forms.GroupBox();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.gbQueue = new System.Windows.Forms.GroupBox();
            this.btnSaveQueue = new System.Windows.Forms.Button();
            this.btnLoadQueue = new System.Windows.Forms.Button();
            this.pnlOperationButtons = new System.Windows.Forms.Panel();
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.btnClearQueue = new System.Windows.Forms.Button();
            this.btnAddOperation = new System.Windows.Forms.Button();
            this.lvOperations = new System.Windows.Forms.ListView();
            this.chOpIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOpType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOpDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOpPublisher = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOpDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmsContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.cmsiRemove = new System.Windows.Forms.ToolStripMenuItem();
            this.gbLogs = new System.Windows.Forms.GroupBox();
            this.btnClearLogs = new System.Windows.Forms.Button();
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.lblPackagerVersion = new System.Windows.Forms.Label();
            this.lblPackagerVersionValue = new System.Windows.Forms.Label();
            this.tsMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.gbSolutionHistory.SuspendLayout();
            this.gbEnvironments.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.gbSolutionPackager.SuspendLayout();
            this.gbQueue.SuspendLayout();
            this.pnlOperationButtons.SuspendLayout();
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
            this.tsbCancel});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1900, 30);
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
            // tsbCancel
            // 
            this.tsbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancel.Name = "tsbCancel";
            this.tsbCancel.Size = new System.Drawing.Size(53, 27);
            this.tsbCancel.Text = "Cancel";
            this.tsbCancel.Visible = false;
            this.tsbCancel.Click += new System.EventHandler(this.tsbCancel_Click);
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
            this.pnlMain.Size = new System.Drawing.Size(1900, 920);
            this.pnlMain.TabIndex = 91;
            // 
            // pnlSettings
            // 
            this.pnlSettings.ColumnCount = 1;
            this.pnlSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlSettings.Controls.Add(this.gbSolutionHistory, 0, 1);
            this.pnlSettings.Controls.Add(this.gbEnvironments, 0, 0);
            this.pnlSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSettings.Location = new System.Drawing.Point(3, 2);
            this.pnlSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.RowCount = 2;
            this.pnlSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.pnlSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.pnlSettings.Size = new System.Drawing.Size(374, 916);
            this.pnlSettings.TabIndex = 0;
            // 
            // gbSolutionHistory
            // 
            this.gbSolutionHistory.Controls.Add(this.lvSolutionHistory);
            this.gbSolutionHistory.Controls.Add(this.btnRefreshHistory);
            this.gbSolutionHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSolutionHistory.Location = new System.Drawing.Point(3, 154);
            this.gbSolutionHistory.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbSolutionHistory.Name = "gbSolutionHistory";
            this.gbSolutionHistory.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbSolutionHistory.Size = new System.Drawing.Size(368, 760);
            this.gbSolutionHistory.TabIndex = 1;
            this.gbSolutionHistory.TabStop = false;
            this.gbSolutionHistory.Text = "Solution History";
            // 
            // lvSolutionHistory
            // 
            this.lvSolutionHistory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSolutionHistory.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSolHistName,
            this.chSolHistOperation,
            this.chSolHistStatus});
            this.lvSolutionHistory.Enabled = false;
            this.lvSolutionHistory.FullRowSelect = true;
            this.lvSolutionHistory.HideSelection = false;
            this.lvSolutionHistory.Location = new System.Drawing.Point(6, 57);
            this.lvSolutionHistory.Name = "lvSolutionHistory";
            this.lvSolutionHistory.Size = new System.Drawing.Size(356, 697);
            this.lvSolutionHistory.TabIndex = 0;
            this.lvSolutionHistory.UseCompatibleStateImageBehavior = false;
            this.lvSolutionHistory.View = System.Windows.Forms.View.Details;
            this.lvSolutionHistory.DoubleClick += new System.EventHandler(this.lvSolutionHistory_DoubleClick);
            this.lvSolutionHistory.Resize += new System.EventHandler(this.lvSolutionHistory_Resize);
            // 
            // chSolHistName
            // 
            this.chSolHistName.Text = "Name";
            this.chSolHistName.Width = 150;
            // 
            // chSolHistOperation
            // 
            this.chSolHistOperation.Text = "Operation";
            this.chSolHistOperation.Width = 100;
            // 
            // chSolHistStatus
            // 
            this.chSolHistStatus.Text = "Status";
            this.chSolHistStatus.Width = 100;
            // 
            // btnRefreshHistory
            // 
            this.btnRefreshHistory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefreshHistory.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnRefreshHistory.Location = new System.Drawing.Point(7, 21);
            this.btnRefreshHistory.Margin = new System.Windows.Forms.Padding(4);
            this.btnRefreshHistory.Name = "btnRefreshHistory";
            this.btnRefreshHistory.Size = new System.Drawing.Size(354, 29);
            this.btnRefreshHistory.TabIndex = 10;
            this.btnRefreshHistory.Text = "Refresh";
            this.btnRefreshHistory.UseVisualStyleBackColor = true;
            this.btnRefreshHistory.Click += new System.EventHandler(this.btnRefreshHistory_Click);
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
            this.gbEnvironments.Size = new System.Drawing.Size(368, 148);
            this.gbEnvironments.TabIndex = 0;
            this.gbEnvironments.TabStop = false;
            this.gbEnvironments.Text = "Environments";
            // 
            // btnConnectSource
            // 
            this.btnConnectSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnectSource.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnConnectSource.Location = new System.Drawing.Point(7, 92);
            this.btnConnectSource.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnectSource.Name = "btnConnectSource";
            this.btnConnectSource.Size = new System.Drawing.Size(354, 29);
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
            // pnlBody
            // 
            this.pnlBody.ColumnCount = 2;
            this.pnlBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.pnlBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.pnlBody.Controls.Add(this.gbSolutionPackager, 0, 1);
            this.pnlBody.Controls.Add(this.gbQueue, 0, 0);
            this.pnlBody.Controls.Add(this.gbLogs, 7, 0);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(383, 2);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.RowCount = 2;
            this.pnlBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlBody.Size = new System.Drawing.Size(1514, 916);
            this.pnlBody.TabIndex = 1;
            // 
            // gbSolutionPackager
            // 
            this.gbSolutionPackager.Controls.Add(this.lblPackagerVersion);
            this.gbSolutionPackager.Controls.Add(this.lblPackagerVersionValue);
            this.gbSolutionPackager.Controls.Add(this.txtOutput);
            this.gbSolutionPackager.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSolutionPackager.Location = new System.Drawing.Point(1062, 460);
            this.gbSolutionPackager.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbSolutionPackager.Name = "gbSolutionPackager";
            this.gbSolutionPackager.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbSolutionPackager.Size = new System.Drawing.Size(449, 454);
            this.gbSolutionPackager.TabIndex = 3;
            this.gbSolutionPackager.TabStop = false;
            this.gbSolutionPackager.Text = "Solution Packager";
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.BackColor = System.Drawing.Color.Black;
            this.txtOutput.ForeColor = System.Drawing.Color.White;
            this.txtOutput.Location = new System.Drawing.Point(3, 57);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(443, 395);
            this.txtOutput.TabIndex = 1;
            this.txtOutput.Text = "";
            this.txtOutput.TextChanged += new System.EventHandler(this.txtOutput_TextChanged);
            // 
            // gbQueue
            // 
            this.gbQueue.Controls.Add(this.btnSaveQueue);
            this.gbQueue.Controls.Add(this.btnLoadQueue);
            this.gbQueue.Controls.Add(this.pnlOperationButtons);
            this.gbQueue.Controls.Add(this.btnClearQueue);
            this.gbQueue.Controls.Add(this.btnAddOperation);
            this.gbQueue.Controls.Add(this.lvOperations);
            this.gbQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbQueue.Location = new System.Drawing.Point(3, 2);
            this.gbQueue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbQueue.Name = "gbQueue";
            this.gbQueue.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlBody.SetRowSpan(this.gbQueue, 2);
            this.gbQueue.Size = new System.Drawing.Size(1053, 912);
            this.gbQueue.TabIndex = 1;
            this.gbQueue.TabStop = false;
            this.gbQueue.Text = "Queue";
            // 
            // btnSaveQueue
            // 
            this.btnSaveQueue.Enabled = false;
            this.btnSaveQueue.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnSaveQueue.Location = new System.Drawing.Point(165, 21);
            this.btnSaveQueue.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveQueue.Name = "btnSaveQueue";
            this.btnSaveQueue.Size = new System.Drawing.Size(150, 29);
            this.btnSaveQueue.TabIndex = 11;
            this.btnSaveQueue.Text = "Save Queue";
            this.btnSaveQueue.UseVisualStyleBackColor = true;
            this.btnSaveQueue.Click += new System.EventHandler(this.btnSaveQueue_Click);
            // 
            // btnLoadQueue
            // 
            this.btnLoadQueue.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnLoadQueue.Location = new System.Drawing.Point(7, 21);
            this.btnLoadQueue.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadQueue.Name = "btnLoadQueue";
            this.btnLoadQueue.Size = new System.Drawing.Size(150, 29);
            this.btnLoadQueue.TabIndex = 10;
            this.btnLoadQueue.Text = "Load Queue";
            this.btnLoadQueue.UseVisualStyleBackColor = true;
            this.btnLoadQueue.Click += new System.EventHandler(this.btnLoadQueue_Click);
            // 
            // pnlOperationButtons
            // 
            this.pnlOperationButtons.BackColor = System.Drawing.SystemColors.Window;
            this.pnlOperationButtons.Controls.Add(this.btnDown);
            this.pnlOperationButtons.Controls.Add(this.btnUp);
            this.pnlOperationButtons.Location = new System.Drawing.Point(6, 58);
            this.pnlOperationButtons.Name = "pnlOperationButtons";
            this.pnlOperationButtons.Size = new System.Drawing.Size(45, 1086);
            this.pnlOperationButtons.TabIndex = 9;
            // 
            // btnDown
            // 
            this.btnDown.BackgroundImage = global::Dataverse.XrmTools.Deployer.Properties.Resources.arrow_down_disabled_35px;
            this.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDown.Enabled = false;
            this.btnDown.FlatAppearance.BorderSize = 0;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.Location = new System.Drawing.Point(3, 49);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(38, 38);
            this.btnDown.TabIndex = 1;
            this.btnDown.UseVisualStyleBackColor = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnUp
            // 
            this.btnUp.BackgroundImage = global::Dataverse.XrmTools.Deployer.Properties.Resources.arrow_up_disabled_35px;
            this.btnUp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUp.Enabled = false;
            this.btnUp.FlatAppearance.BorderSize = 0;
            this.btnUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUp.Location = new System.Drawing.Point(3, 3);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(38, 38);
            this.btnUp.TabIndex = 0;
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnClearQueue
            // 
            this.btnClearQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearQueue.Enabled = false;
            this.btnClearQueue.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnClearQueue.Location = new System.Drawing.Point(896, 21);
            this.btnClearQueue.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearQueue.Name = "btnClearQueue";
            this.btnClearQueue.Size = new System.Drawing.Size(150, 29);
            this.btnClearQueue.TabIndex = 8;
            this.btnClearQueue.Text = "Clear Queue";
            this.btnClearQueue.UseVisualStyleBackColor = true;
            this.btnClearQueue.Click += new System.EventHandler(this.btnClearQueue_Click);
            // 
            // btnAddOperation
            // 
            this.btnAddOperation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddOperation.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnAddOperation.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnAddOperation.Location = new System.Drawing.Point(323, 21);
            this.btnAddOperation.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddOperation.Name = "btnAddOperation";
            this.btnAddOperation.Size = new System.Drawing.Size(565, 29);
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
            this.chOpIndex,
            this.chOpType,
            this.chOpDisplayName,
            this.chOpPublisher,
            this.chOpDescription});
            this.lvOperations.ContextMenuStrip = this.cmsContextMenu;
            this.lvOperations.FullRowSelect = true;
            this.lvOperations.HideSelection = false;
            this.lvOperations.Location = new System.Drawing.Point(59, 58);
            this.lvOperations.Margin = new System.Windows.Forms.Padding(4);
            this.lvOperations.MultiSelect = false;
            this.lvOperations.Name = "lvOperations";
            this.lvOperations.Size = new System.Drawing.Size(987, 848);
            this.lvOperations.TabIndex = 2;
            this.lvOperations.UseCompatibleStateImageBehavior = false;
            this.lvOperations.View = System.Windows.Forms.View.Details;
            this.lvOperations.SelectedIndexChanged += new System.EventHandler(this.lvOperations_SelectedIndexChanged);
            this.lvOperations.Resize += new System.EventHandler(this.lvOperations_Resize);
            // 
            // chOpIndex
            // 
            this.chOpIndex.Text = "#";
            this.chOpIndex.Width = 30;
            // 
            // chOpType
            // 
            this.chOpType.Text = "Type";
            this.chOpType.Width = 100;
            // 
            // chOpDisplayName
            // 
            this.chOpDisplayName.Text = "Display Name";
            this.chOpDisplayName.Width = 300;
            // 
            // chOpPublisher
            // 
            this.chOpPublisher.Text = "Publisher";
            this.chOpPublisher.Width = 200;
            // 
            // chOpDescription
            // 
            this.chOpDescription.Text = "Description";
            this.chOpDescription.Width = 350;
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
            this.gbLogs.Controls.Add(this.btnClearLogs);
            this.gbLogs.Controls.Add(this.txtLogs);
            this.gbLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbLogs.Location = new System.Drawing.Point(1062, 2);
            this.gbLogs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbLogs.Name = "gbLogs";
            this.gbLogs.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbLogs.Size = new System.Drawing.Size(449, 454);
            this.gbLogs.TabIndex = 2;
            this.gbLogs.TabStop = false;
            this.gbLogs.Text = "Logs";
            // 
            // btnClearLogs
            // 
            this.btnClearLogs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLogs.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnClearLogs.Location = new System.Drawing.Point(7, 21);
            this.btnClearLogs.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(436, 29);
            this.btnClearLogs.TabIndex = 9;
            this.btnClearLogs.Text = "Clear Logs";
            this.btnClearLogs.UseVisualStyleBackColor = true;
            this.btnClearLogs.Click += new System.EventHandler(this.btnClearLogs_Click);
            // 
            // txtLogs
            // 
            this.txtLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogs.Location = new System.Drawing.Point(6, 58);
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.ReadOnly = true;
            this.txtLogs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogs.Size = new System.Drawing.Size(437, 391);
            this.txtLogs.TabIndex = 2;
            this.txtLogs.TextChanged += new System.EventHandler(this.txtLogs_TextChanged);
            // 
            // lblPackagerVersion
            // 
            this.lblPackagerVersion.AutoSize = true;
            this.lblPackagerVersion.Location = new System.Drawing.Point(6, 28);
            this.lblPackagerVersion.Name = "lblPackagerVersion";
            this.lblPackagerVersion.Size = new System.Drawing.Size(60, 17);
            this.lblPackagerVersion.TabIndex = 4;
            this.lblPackagerVersion.Text = "Version:";
            // 
            // lblPackagerVersionValue
            // 
            this.lblPackagerVersionValue.AutoSize = true;
            this.lblPackagerVersionValue.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblPackagerVersionValue.ForeColor = System.Drawing.Color.DarkRed;
            this.lblPackagerVersionValue.Location = new System.Drawing.Point(72, 27);
            this.lblPackagerVersionValue.Name = "lblPackagerVersionValue";
            this.lblPackagerVersionValue.Size = new System.Drawing.Size(86, 19);
            this.lblPackagerVersionValue.TabIndex = 5;
            this.lblPackagerVersionValue.Text = "Not installed";
            // 
            // DeployerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tsMain);
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "DeployerControl";
            this.Size = new System.Drawing.Size(1900, 950);
            this.Load += new System.EventHandler(this.DataMigrationControl_Load);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlSettings.ResumeLayout(false);
            this.gbSolutionHistory.ResumeLayout(false);
            this.gbEnvironments.ResumeLayout(false);
            this.gbEnvironments.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.gbSolutionPackager.ResumeLayout(false);
            this.gbSolutionPackager.PerformLayout();
            this.gbQueue.ResumeLayout(false);
            this.pnlOperationButtons.ResumeLayout(false);
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

        // Body
        private System.Windows.Forms.TableLayoutPanel pnlBody;

        // Queue Group
        private System.Windows.Forms.GroupBox gbQueue;
        private System.Windows.Forms.ToolStripButton tsbExecute;
        private System.Windows.Forms.ToolStripButton tsbCancel;
        private System.Windows.Forms.Button btnAddOperation;
        private System.Windows.Forms.ListView lvOperations;
        private System.Windows.Forms.ColumnHeader chOpIndex;
        private System.Windows.Forms.ColumnHeader chOpType;
        private System.Windows.Forms.ColumnHeader chOpDisplayName;
        private System.Windows.Forms.ColumnHeader chOpPublisher;
        private System.Windows.Forms.ColumnHeader chOpDescription;
        private System.Windows.Forms.ContextMenuStrip cmsContextMenu;
        private System.Windows.Forms.ToolStripMenuItem cmsiRemove;

        // Layers Group
        private System.Windows.Forms.GroupBox gbLogs;
        private System.Windows.Forms.TextBox txtLogs;
        private System.Windows.Forms.Button btnClearQueue;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblSourceValue;
        private System.Windows.Forms.Button btnConnectSource;
        private System.Windows.Forms.Button btnClearLogs;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Panel pnlOperationButtons;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.GroupBox gbSolutionPackager;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.Button btnSaveQueue;
        private System.Windows.Forms.Button btnLoadQueue;
        private System.Windows.Forms.GroupBox gbSolutionHistory;
        private System.Windows.Forms.Button btnRefreshHistory;
        private System.Windows.Forms.ListView lvSolutionHistory;
        private System.Windows.Forms.ColumnHeader chSolHistName;
        private System.Windows.Forms.ColumnHeader chSolHistOperation;
        private System.Windows.Forms.ColumnHeader chSolHistStatus;
        private System.Windows.Forms.Label lblPackagerVersion;
        private System.Windows.Forms.Label lblPackagerVersionValue;
    }
}

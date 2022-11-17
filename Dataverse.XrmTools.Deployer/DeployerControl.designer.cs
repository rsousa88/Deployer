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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DeployerControl));
            this.mainContainer = new System.Windows.Forms.SplitContainer();
            this.pnlSettings = new System.Windows.Forms.TableLayoutPanel();
            this.gbSolutionPackagerLogs = new System.Windows.Forms.GroupBox();
            this.lblPackagerVersion = new System.Windows.Forms.Label();
            this.lblPackagerVersionValue = new System.Windows.Forms.Label();
            this.txtOutput = new System.Windows.Forms.RichTextBox();
            this.gbEnvironments = new System.Windows.Forms.GroupBox();
            this.btnConnectTarget = new System.Windows.Forms.Button();
            this.lblTarget = new System.Windows.Forms.Label();
            this.lblTargetValue = new System.Windows.Forms.Label();
            this.lblSource = new System.Windows.Forms.Label();
            this.lblSourceValue = new System.Windows.Forms.Label();
            this.gbDeployerLogs = new System.Windows.Forms.GroupBox();
            this.txtLogs = new System.Windows.Forms.TextBox();
            this.btnClearLogs = new System.Windows.Forms.Button();
            this.bodyContainer = new System.Windows.Forms.SplitContainer();
            this.pnlAddOperation = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.tsAddOperation = new System.Windows.Forms.ToolStrip();
            this.tsbAddOperation = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiUpdate = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiExport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiImport = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPublish = new System.Windows.Forms.ToolStripMenuItem();
            this.tssOperation1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbOperationCancel = new System.Windows.Forms.ToolStripButton();
            this.pnlQueue = new WeifenLuo.WinFormsUI.Docking.DockPanel();
            this.lvQueue = new System.Windows.Forms.ListView();
            this.chOpIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOpType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOpDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOpPublisher = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOpDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tsQueue = new System.Windows.Forms.ToolStrip();
            this.tsbManageQueue = new System.Windows.Forms.ToolStripDropDownButton();
            this.tsmiLoadQueue = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiSaveQueue = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClearQueue = new System.Windows.Forms.ToolStripMenuItem();
            this.tssQueue1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbQueueExecute = new System.Windows.Forms.ToolStripButton();
            this.tsbQueueCancel = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).BeginInit();
            this.mainContainer.Panel1.SuspendLayout();
            this.mainContainer.Panel2.SuspendLayout();
            this.mainContainer.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.gbSolutionPackagerLogs.SuspendLayout();
            this.gbEnvironments.SuspendLayout();
            this.gbDeployerLogs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bodyContainer)).BeginInit();
            this.bodyContainer.Panel1.SuspendLayout();
            this.bodyContainer.Panel2.SuspendLayout();
            this.bodyContainer.SuspendLayout();
            this.tsAddOperation.SuspendLayout();
            this.pnlQueue.SuspendLayout();
            this.tsQueue.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainContainer
            // 
            this.mainContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainContainer.Location = new System.Drawing.Point(0, 0);
            this.mainContainer.Name = "mainContainer";
            // 
            // mainContainer.Panel1
            // 
            this.mainContainer.Panel1.Controls.Add(this.pnlSettings);
            // 
            // mainContainer.Panel2
            // 
            this.mainContainer.Panel2.Controls.Add(this.bodyContainer);
            this.mainContainer.Size = new System.Drawing.Size(2196, 933);
            this.mainContainer.SplitterDistance = 471;
            this.mainContainer.TabIndex = 0;
            // 
            // pnlSettings
            // 
            this.pnlSettings.ColumnCount = 1;
            this.pnlSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlSettings.Controls.Add(this.gbSolutionPackagerLogs, 0, 2);
            this.pnlSettings.Controls.Add(this.gbEnvironments, 0, 0);
            this.pnlSettings.Controls.Add(this.gbDeployerLogs, 0, 1);
            this.pnlSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSettings.Location = new System.Drawing.Point(0, 0);
            this.pnlSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.RowCount = 3;
            this.pnlSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.pnlSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.pnlSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.pnlSettings.Size = new System.Drawing.Size(471, 933);
            this.pnlSettings.TabIndex = 1;
            // 
            // gbSolutionPackagerLogs
            // 
            this.gbSolutionPackagerLogs.Controls.Add(this.lblPackagerVersion);
            this.gbSolutionPackagerLogs.Controls.Add(this.lblPackagerVersionValue);
            this.gbSolutionPackagerLogs.Controls.Add(this.txtOutput);
            this.gbSolutionPackagerLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSolutionPackagerLogs.Location = new System.Drawing.Point(3, 545);
            this.gbSolutionPackagerLogs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbSolutionPackagerLogs.Name = "gbSolutionPackagerLogs";
            this.gbSolutionPackagerLogs.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbSolutionPackagerLogs.Size = new System.Drawing.Size(465, 386);
            this.gbSolutionPackagerLogs.TabIndex = 4;
            this.gbSolutionPackagerLogs.TabStop = false;
            this.gbSolutionPackagerLogs.Text = "Solution Packager Logs";
            // 
            // lblPackagerVersion
            // 
            this.lblPackagerVersion.AutoSize = true;
            this.lblPackagerVersion.Location = new System.Drawing.Point(5, 28);
            this.lblPackagerVersion.Name = "lblPackagerVersion";
            this.lblPackagerVersion.Size = new System.Drawing.Size(56, 16);
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
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.BackColor = System.Drawing.Color.Black;
            this.txtOutput.ForeColor = System.Drawing.Color.White;
            this.txtOutput.Location = new System.Drawing.Point(3, 57);
            this.txtOutput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.Size = new System.Drawing.Size(458, 328);
            this.txtOutput.TabIndex = 1;
            this.txtOutput.Text = "";
            // 
            // gbEnvironments
            // 
            this.gbEnvironments.Controls.Add(this.btnConnectTarget);
            this.gbEnvironments.Controls.Add(this.lblTarget);
            this.gbEnvironments.Controls.Add(this.lblTargetValue);
            this.gbEnvironments.Controls.Add(this.lblSource);
            this.gbEnvironments.Controls.Add(this.lblSourceValue);
            this.gbEnvironments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbEnvironments.Location = new System.Drawing.Point(3, 2);
            this.gbEnvironments.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbEnvironments.Name = "gbEnvironments";
            this.gbEnvironments.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbEnvironments.Size = new System.Drawing.Size(465, 151);
            this.gbEnvironments.TabIndex = 0;
            this.gbEnvironments.TabStop = false;
            this.gbEnvironments.Text = "Environments";
            // 
            // btnConnectTarget
            // 
            this.btnConnectTarget.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConnectTarget.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnConnectTarget.Location = new System.Drawing.Point(7, 92);
            this.btnConnectTarget.Margin = new System.Windows.Forms.Padding(4);
            this.btnConnectTarget.Name = "btnConnectTarget";
            this.btnConnectTarget.Size = new System.Drawing.Size(452, 30);
            this.btnConnectTarget.TabIndex = 9;
            this.btnConnectTarget.Text = "Add Target";
            this.btnConnectTarget.UseVisualStyleBackColor = true;
            this.btnConnectTarget.Click += new System.EventHandler(this.btnConnectTarget_Click);
            // 
            // lblTarget
            // 
            this.lblTarget.AutoSize = true;
            this.lblTarget.Location = new System.Drawing.Point(5, 62);
            this.lblTarget.Name = "lblTarget";
            this.lblTarget.Size = new System.Drawing.Size(47, 16);
            this.lblTarget.TabIndex = 2;
            this.lblTarget.Text = "Target";
            // 
            // lblTargetValue
            // 
            this.lblTargetValue.AutoSize = true;
            this.lblTargetValue.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblTargetValue.ForeColor = System.Drawing.Color.DarkRed;
            this.lblTargetValue.Location = new System.Drawing.Point(65, 62);
            this.lblTargetValue.Name = "lblTargetValue";
            this.lblTargetValue.Size = new System.Drawing.Size(91, 19);
            this.lblTargetValue.TabIndex = 3;
            this.lblTargetValue.Text = "Disconnected";
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(5, 30);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(50, 16);
            this.lblSource.TabIndex = 0;
            this.lblSource.Text = "Source";
            // 
            // lblSourceValue
            // 
            this.lblSourceValue.AutoSize = true;
            this.lblSourceValue.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblSourceValue.ForeColor = System.Drawing.Color.DarkRed;
            this.lblSourceValue.Location = new System.Drawing.Point(65, 30);
            this.lblSourceValue.Name = "lblSourceValue";
            this.lblSourceValue.Size = new System.Drawing.Size(91, 19);
            this.lblSourceValue.TabIndex = 1;
            this.lblSourceValue.Text = "Disconnected";
            // 
            // gbDeployerLogs
            // 
            this.gbDeployerLogs.Controls.Add(this.txtLogs);
            this.gbDeployerLogs.Controls.Add(this.btnClearLogs);
            this.gbDeployerLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDeployerLogs.Location = new System.Drawing.Point(3, 157);
            this.gbDeployerLogs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbDeployerLogs.Name = "gbDeployerLogs";
            this.gbDeployerLogs.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbDeployerLogs.Size = new System.Drawing.Size(465, 384);
            this.gbDeployerLogs.TabIndex = 1;
            this.gbDeployerLogs.TabStop = false;
            this.gbDeployerLogs.Text = "Deployer Logs";
            // 
            // txtLogs
            // 
            this.txtLogs.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogs.Location = new System.Drawing.Point(6, 57);
            this.txtLogs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txtLogs.Multiline = true;
            this.txtLogs.Name = "txtLogs";
            this.txtLogs.ReadOnly = true;
            this.txtLogs.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtLogs.Size = new System.Drawing.Size(453, 323);
            this.txtLogs.TabIndex = 2;
            // 
            // btnClearLogs
            // 
            this.btnClearLogs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLogs.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnClearLogs.Location = new System.Drawing.Point(7, 21);
            this.btnClearLogs.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(451, 30);
            this.btnClearLogs.TabIndex = 9;
            this.btnClearLogs.Text = "Clear Logs";
            this.btnClearLogs.UseVisualStyleBackColor = true;
            // 
            // bodyContainer
            // 
            this.bodyContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bodyContainer.Location = new System.Drawing.Point(0, 0);
            this.bodyContainer.Name = "bodyContainer";
            this.bodyContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // bodyContainer.Panel1
            // 
            this.bodyContainer.Panel1.Controls.Add(this.pnlAddOperation);
            this.bodyContainer.Panel1.Controls.Add(this.tsAddOperation);
            // 
            // bodyContainer.Panel2
            // 
            this.bodyContainer.Panel2.Controls.Add(this.pnlQueue);
            this.bodyContainer.Panel2.Controls.Add(this.tsQueue);
            this.bodyContainer.Size = new System.Drawing.Size(1721, 933);
            this.bodyContainer.SplitterDistance = 422;
            this.bodyContainer.TabIndex = 0;
            // 
            // pnlAddOperation
            // 
            this.pnlAddOperation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlAddOperation.Location = new System.Drawing.Point(0, 26);
            this.pnlAddOperation.Name = "pnlAddOperation";
            this.pnlAddOperation.Size = new System.Drawing.Size(1721, 396);
            this.pnlAddOperation.TabIndex = 14;
            // 
            // tsAddOperation
            // 
            this.tsAddOperation.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tsAddOperation.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsAddOperation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddOperation,
            this.tssOperation1,
            this.tsbOperationCancel});
            this.tsAddOperation.Location = new System.Drawing.Point(0, 0);
            this.tsAddOperation.Name = "tsAddOperation";
            this.tsAddOperation.Size = new System.Drawing.Size(1721, 26);
            this.tsAddOperation.TabIndex = 13;
            this.tsAddOperation.Text = "Add Operation Toolstrip";
            // 
            // tsbAddOperation
            // 
            this.tsbAddOperation.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAddOperation.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiUpdate,
            this.tsmiExport,
            this.tsmiImport,
            this.tsmiDelete,
            this.tsmiPublish});
            this.tsbAddOperation.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddOperation.Image")));
            this.tsbAddOperation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAddOperation.Name = "tsbAddOperation";
            this.tsbAddOperation.Size = new System.Drawing.Size(114, 23);
            this.tsbAddOperation.Text = "Add Operation";
            // 
            // tsmiUpdate
            // 
            this.tsmiUpdate.Name = "tsmiUpdate";
            this.tsmiUpdate.Size = new System.Drawing.Size(234, 26);
            this.tsmiUpdate.Text = "Update versions";
            this.tsmiUpdate.Click += new System.EventHandler(this.tsmiUpdate_Click);
            // 
            // tsmiExport
            // 
            this.tsmiExport.Name = "tsmiExport";
            this.tsmiExport.Size = new System.Drawing.Size(234, 26);
            this.tsmiExport.Text = "Export solutions";
            // 
            // tsmiImport
            // 
            this.tsmiImport.Name = "tsmiImport";
            this.tsmiImport.Size = new System.Drawing.Size(234, 26);
            this.tsmiImport.Text = "Import solutions";
            // 
            // tsmiDelete
            // 
            this.tsmiDelete.Name = "tsmiDelete";
            this.tsmiDelete.Size = new System.Drawing.Size(234, 26);
            this.tsmiDelete.Text = "Delete solutions";
            // 
            // tsmiPublish
            // 
            this.tsmiPublish.Name = "tsmiPublish";
            this.tsmiPublish.Size = new System.Drawing.Size(234, 26);
            this.tsmiPublish.Text = "Publish Customizations";
            // 
            // tssOperation1
            // 
            this.tssOperation1.Name = "tssOperation1";
            this.tssOperation1.Size = new System.Drawing.Size(6, 26);
            // 
            // tsbOperationCancel
            // 
            this.tsbOperationCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbOperationCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tsbOperationCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbOperationCancel.Name = "tsbOperationCancel";
            this.tsbOperationCancel.Size = new System.Drawing.Size(53, 23);
            this.tsbOperationCancel.Text = "Cancel";
            this.tsbOperationCancel.Visible = false;
            // 
            // pnlQueue
            // 
            this.pnlQueue.Controls.Add(this.lvQueue);
            this.pnlQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlQueue.Location = new System.Drawing.Point(0, 26);
            this.pnlQueue.Name = "pnlQueue";
            this.pnlQueue.Size = new System.Drawing.Size(1721, 481);
            this.pnlQueue.TabIndex = 13;
            // 
            // lvQueue
            // 
            this.lvQueue.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chOpIndex,
            this.chOpType,
            this.chOpDisplayName,
            this.chOpPublisher,
            this.chOpDescription});
            this.lvQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvQueue.FullRowSelect = true;
            this.lvQueue.HideSelection = false;
            this.lvQueue.Location = new System.Drawing.Point(0, 0);
            this.lvQueue.Margin = new System.Windows.Forms.Padding(4);
            this.lvQueue.MultiSelect = false;
            this.lvQueue.Name = "lvQueue";
            this.lvQueue.Size = new System.Drawing.Size(1721, 481);
            this.lvQueue.TabIndex = 2;
            this.lvQueue.UseCompatibleStateImageBehavior = false;
            this.lvQueue.View = System.Windows.Forms.View.Details;
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
            this.chOpPublisher.Width = 250;
            // 
            // chOpDescription
            // 
            this.chOpDescription.Text = "Description";
            this.chOpDescription.Width = 270;
            // 
            // tsQueue
            // 
            this.tsQueue.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tsQueue.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsQueue.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbManageQueue,
            this.tssQueue1,
            this.tsbQueueExecute,
            this.tsbQueueCancel});
            this.tsQueue.Location = new System.Drawing.Point(0, 0);
            this.tsQueue.Name = "tsQueue";
            this.tsQueue.Size = new System.Drawing.Size(1721, 26);
            this.tsQueue.TabIndex = 12;
            this.tsQueue.Text = "Queue Toolstrip";
            // 
            // tsbManageQueue
            // 
            this.tsbManageQueue.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbManageQueue.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiLoadQueue,
            this.tsmiSaveQueue,
            this.tsmiClearQueue});
            this.tsbManageQueue.Image = ((System.Drawing.Image)(resources.GetObject("tsbManageQueue.Image")));
            this.tsbManageQueue.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbManageQueue.Name = "tsbManageQueue";
            this.tsbManageQueue.Size = new System.Drawing.Size(118, 23);
            this.tsbManageQueue.Text = "Manage Queue";
            // 
            // tsmiLoadQueue
            // 
            this.tsmiLoadQueue.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tsmiLoadQueue.Name = "tsmiLoadQueue";
            this.tsmiLoadQueue.Size = new System.Drawing.Size(168, 26);
            this.tsmiLoadQueue.Text = "Load Queue";
            // 
            // tsmiSaveQueue
            // 
            this.tsmiSaveQueue.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tsmiSaveQueue.Name = "tsmiSaveQueue";
            this.tsmiSaveQueue.Size = new System.Drawing.Size(168, 26);
            this.tsmiSaveQueue.Text = "Save Queue";
            // 
            // tsmiClearQueue
            // 
            this.tsmiClearQueue.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tsmiClearQueue.Name = "tsmiClearQueue";
            this.tsmiClearQueue.Size = new System.Drawing.Size(168, 26);
            this.tsmiClearQueue.Text = "Clear Queue";
            // 
            // tssQueue1
            // 
            this.tssQueue1.Name = "tssQueue1";
            this.tssQueue1.Size = new System.Drawing.Size(6, 26);
            // 
            // tsbQueueExecute
            // 
            this.tsbQueueExecute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbQueueExecute.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tsbQueueExecute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQueueExecute.Name = "tsbQueueExecute";
            this.tsbQueueExecute.Size = new System.Drawing.Size(59, 23);
            this.tsbQueueExecute.Text = "Execute";
            // 
            // tsbQueueCancel
            // 
            this.tsbQueueCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbQueueCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tsbQueueCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbQueueCancel.Name = "tsbQueueCancel";
            this.tsbQueueCancel.Size = new System.Drawing.Size(53, 23);
            this.tsbQueueCancel.Text = "Cancel";
            this.tsbQueueCancel.Visible = false;
            // 
            // DeployerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.mainContainer);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "DeployerControl";
            this.Size = new System.Drawing.Size(1757, 746);
            this.Load += new System.EventHandler(this.DataMigrationControl_Load);
            this.mainContainer.Panel1.ResumeLayout(false);
            this.mainContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.mainContainer)).EndInit();
            this.mainContainer.ResumeLayout(false);
            this.pnlSettings.ResumeLayout(false);
            this.gbSolutionPackagerLogs.ResumeLayout(false);
            this.gbSolutionPackagerLogs.PerformLayout();
            this.gbEnvironments.ResumeLayout(false);
            this.gbEnvironments.PerformLayout();
            this.gbDeployerLogs.ResumeLayout(false);
            this.gbDeployerLogs.PerformLayout();
            this.bodyContainer.Panel1.ResumeLayout(false);
            this.bodyContainer.Panel1.PerformLayout();
            this.bodyContainer.Panel2.ResumeLayout(false);
            this.bodyContainer.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bodyContainer)).EndInit();
            this.bodyContainer.ResumeLayout(false);
            this.tsAddOperation.ResumeLayout(false);
            this.tsAddOperation.PerformLayout();
            this.pnlQueue.ResumeLayout(false);
            this.tsQueue.ResumeLayout(false);
            this.tsQueue.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        // Main components
        private System.Windows.Forms.SplitContainer mainContainer;

        // Settings components
        private System.Windows.Forms.TableLayoutPanel pnlSettings;

        // Environments group
        private System.Windows.Forms.GroupBox gbEnvironments;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblSourceValue;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.Label lblTargetValue;
        private System.Windows.Forms.Button btnConnectTarget;

        // Logs group
        private System.Windows.Forms.Button btnClearLogs;
        private System.Windows.Forms.GroupBox gbDeployerLogs;
        private System.Windows.Forms.TextBox txtLogs;
        private System.Windows.Forms.GroupBox gbSolutionPackagerLogs;
        private System.Windows.Forms.Label lblPackagerVersion;
        private System.Windows.Forms.Label lblPackagerVersionValue;
        private System.Windows.Forms.RichTextBox txtOutput;

        // Body components
        private System.Windows.Forms.SplitContainer bodyContainer;

        // Add Operation group
        private System.Windows.Forms.ToolStrip tsAddOperation;
        private System.Windows.Forms.ToolStripDropDownButton tsbAddOperation;
        private System.Windows.Forms.ToolStripMenuItem tsmiUpdate;
        private System.Windows.Forms.ToolStripMenuItem tsmiExport;
        private System.Windows.Forms.ToolStripMenuItem tsmiImport;
        private System.Windows.Forms.ToolStripMenuItem tsmiDelete;
        private System.Windows.Forms.ToolStripMenuItem tsmiPublish;
        private System.Windows.Forms.ToolStripSeparator tssOperation1;
        private System.Windows.Forms.ToolStripButton tsbOperationCancel;
        private WeifenLuo.WinFormsUI.Docking.DockPanel pnlAddOperation;

        // Queue group
        private System.Windows.Forms.ToolStrip tsQueue;
        private System.Windows.Forms.ToolStripDropDownButton tsbManageQueue;
        private System.Windows.Forms.ToolStripMenuItem tsmiLoadQueue;
        private System.Windows.Forms.ToolStripMenuItem tsmiSaveQueue;
        private System.Windows.Forms.ToolStripMenuItem tsmiClearQueue;
        private System.Windows.Forms.ToolStripSeparator tssQueue1;
        private System.Windows.Forms.ToolStripButton tsbQueueExecute;
        private System.Windows.Forms.ToolStripButton tsbQueueCancel;
        private WeifenLuo.WinFormsUI.Docking.DockPanel pnlQueue;
        private System.Windows.Forms.ListView lvQueue;
        private System.Windows.Forms.ColumnHeader chOpIndex;
        private System.Windows.Forms.ColumnHeader chOpType;
        private System.Windows.Forms.ColumnHeader chOpDisplayName;
        private System.Windows.Forms.ColumnHeader chOpPublisher;
        private System.Windows.Forms.ColumnHeader chOpDescription;
    }
}

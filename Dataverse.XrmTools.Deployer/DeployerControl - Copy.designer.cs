namespace Dataverse.XrmTools.Deployer
{
    partial class DeployerControlCopy
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
            this.pnlMain = new System.Windows.Forms.TableLayoutPanel();
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
            this.pnlBody = new System.Windows.Forms.TableLayoutPanel();
            this.gbAddOperation = new System.Windows.Forms.GroupBox();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.tsAddOperation = new System.Windows.Forms.ToolStrip();
            this.tsbUpdate = new System.Windows.Forms.ToolStripButton();
            this.tssOperation1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbImport = new System.Windows.Forms.ToolStripButton();
            this.tssOperation2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbExport = new System.Windows.Forms.ToolStripButton();
            this.tssOperation3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tssOperation4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbPublish = new System.Windows.Forms.ToolStripButton();
            this.gbQueue = new System.Windows.Forms.GroupBox();
            this.tsQueue = new System.Windows.Forms.ToolStrip();
            this.tsbExecute = new System.Windows.Forms.ToolStripButton();
            this.tsbCancel = new System.Windows.Forms.ToolStripButton();
            this.btnSaveQueue = new System.Windows.Forms.Button();
            this.btnLoadQueue = new System.Windows.Forms.Button();
            this.pnlOperationButtons = new System.Windows.Forms.Panel();
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
            this.btnDown = new System.Windows.Forms.Button();
            this.btnUp = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.gbSolutionPackagerLogs.SuspendLayout();
            this.gbEnvironments.SuspendLayout();
            this.gbDeployerLogs.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.gbAddOperation.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.tsAddOperation.SuspendLayout();
            this.gbQueue.SuspendLayout();
            this.tsQueue.SuspendLayout();
            this.pnlOperationButtons.SuspendLayout();
            this.cmsContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.ColumnCount = 2;
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.pnlMain.Controls.Add(this.pnlSettings, 0, 0);
            this.pnlMain.Controls.Add(this.pnlBody, 1, 0);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.RowCount = 1;
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlMain.Size = new System.Drawing.Size(2197, 933);
            this.pnlMain.TabIndex = 91;
            // 
            // pnlSettings
            // 
            this.pnlSettings.ColumnCount = 1;
            this.pnlSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlSettings.Controls.Add(this.gbSolutionPackagerLogs, 0, 2);
            this.pnlSettings.Controls.Add(this.gbEnvironments, 0, 0);
            this.pnlSettings.Controls.Add(this.gbDeployerLogs, 0, 1);
            this.pnlSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSettings.Location = new System.Drawing.Point(3, 2);
            this.pnlSettings.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.RowCount = 3;
            this.pnlSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.pnlSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.pnlSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 37.5F));
            this.pnlSettings.Size = new System.Drawing.Size(433, 929);
            this.pnlSettings.TabIndex = 0;
            // 
            // gbSolutionPackagerLogs
            // 
            this.gbSolutionPackagerLogs.Controls.Add(this.lblPackagerVersion);
            this.gbSolutionPackagerLogs.Controls.Add(this.lblPackagerVersionValue);
            this.gbSolutionPackagerLogs.Controls.Add(this.txtOutput);
            this.gbSolutionPackagerLogs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSolutionPackagerLogs.Location = new System.Drawing.Point(3, 543);
            this.gbSolutionPackagerLogs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbSolutionPackagerLogs.Name = "gbSolutionPackagerLogs";
            this.gbSolutionPackagerLogs.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbSolutionPackagerLogs.Size = new System.Drawing.Size(427, 384);
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
            this.txtOutput.Size = new System.Drawing.Size(420, 326);
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
            this.gbEnvironments.Size = new System.Drawing.Size(427, 150);
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
            this.btnConnectTarget.Size = new System.Drawing.Size(414, 30);
            this.btnConnectTarget.TabIndex = 9;
            this.btnConnectTarget.Text = "Add Target";
            this.btnConnectTarget.UseVisualStyleBackColor = true;
            this.btnConnectTarget.Click += new System.EventHandler(this.btnConnectSource_Click);
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
            this.gbDeployerLogs.Location = new System.Drawing.Point(3, 156);
            this.gbDeployerLogs.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbDeployerLogs.Name = "gbDeployerLogs";
            this.gbDeployerLogs.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbDeployerLogs.Size = new System.Drawing.Size(427, 383);
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
            this.txtLogs.Size = new System.Drawing.Size(415, 322);
            this.txtLogs.TabIndex = 2;
            this.txtLogs.TextChanged += new System.EventHandler(this.txtLogs_TextChanged);
            // 
            // btnClearLogs
            // 
            this.btnClearLogs.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearLogs.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnClearLogs.Location = new System.Drawing.Point(7, 21);
            this.btnClearLogs.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearLogs.Name = "btnClearLogs";
            this.btnClearLogs.Size = new System.Drawing.Size(413, 30);
            this.btnClearLogs.TabIndex = 9;
            this.btnClearLogs.Text = "Clear Logs";
            this.btnClearLogs.UseVisualStyleBackColor = true;
            this.btnClearLogs.Click += new System.EventHandler(this.btnClearLogs_Click);
            // 
            // pnlBody
            // 
            this.pnlBody.ColumnCount = 1;
            this.pnlBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlBody.Controls.Add(this.gbAddOperation, 0, 0);
            this.pnlBody.Controls.Add(this.gbQueue, 0, 1);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(442, 2);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.RowCount = 2;
            this.pnlBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlBody.Size = new System.Drawing.Size(1752, 929);
            this.pnlBody.TabIndex = 1;
            // 
            // gbAddOperation
            // 
            this.gbAddOperation.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAddOperation.Controls.Add(this.toolStrip1);
            this.gbAddOperation.Controls.Add(this.tsAddOperation);
            this.gbAddOperation.Location = new System.Drawing.Point(3, 2);
            this.gbAddOperation.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbAddOperation.Name = "gbAddOperation";
            this.gbAddOperation.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbAddOperation.Size = new System.Drawing.Size(1746, 460);
            this.gbAddOperation.TabIndex = 1;
            this.gbAddOperation.TabStop = false;
            this.gbAddOperation.Text = "Add Operation";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.toolStripButton2,
            this.toolStripSeparator2,
            this.toolStripButton3,
            this.toolStripSeparator3,
            this.toolStripButton4,
            this.toolStripSeparator4,
            this.toolStripButton5});
            this.toolStrip1.Location = new System.Drawing.Point(3, 432);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1740, 26);
            this.toolStrip1.TabIndex = 11;
            this.toolStrip1.Text = "Add Operation Toolstrip";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(58, 23);
            this.toolStripButton1.Text = "Update";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(55, 23);
            this.toolStripButton2.Text = "Import";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 26);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(52, 23);
            this.toolStripButton3.Text = "Export";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 26);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(52, 23);
            this.toolStripButton4.Text = "Delete";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 26);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(57, 23);
            this.toolStripButton5.Text = "Publish";
            // 
            // tsAddOperation
            // 
            this.tsAddOperation.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tsAddOperation.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsAddOperation.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbUpdate,
            this.tssOperation1,
            this.tsbImport,
            this.tssOperation2,
            this.tsbExport,
            this.tssOperation3,
            this.tsbDelete,
            this.tssOperation4,
            this.tsbPublish});
            this.tsAddOperation.Location = new System.Drawing.Point(3, 17);
            this.tsAddOperation.Name = "tsAddOperation";
            this.tsAddOperation.Size = new System.Drawing.Size(1740, 26);
            this.tsAddOperation.TabIndex = 10;
            this.tsAddOperation.Text = "Add Operation Toolstrip";
            // 
            // tsbUpdate
            // 
            this.tsbUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbUpdate.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tsbUpdate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbUpdate.Name = "tsbUpdate";
            this.tsbUpdate.Size = new System.Drawing.Size(58, 23);
            this.tsbUpdate.Text = "Update";
            this.tsbUpdate.Click += new System.EventHandler(this.tsbUpdate_Click);
            // 
            // tssOperation1
            // 
            this.tssOperation1.Name = "tssOperation1";
            this.tssOperation1.Size = new System.Drawing.Size(6, 26);
            // 
            // tsbImport
            // 
            this.tsbImport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbImport.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tsbImport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbImport.Name = "tsbImport";
            this.tsbImport.Size = new System.Drawing.Size(55, 23);
            this.tsbImport.Text = "Import";
            // 
            // tssOperation2
            // 
            this.tssOperation2.Name = "tssOperation2";
            this.tssOperation2.Size = new System.Drawing.Size(6, 26);
            // 
            // tsbExport
            // 
            this.tsbExport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbExport.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tsbExport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExport.Name = "tsbExport";
            this.tsbExport.Size = new System.Drawing.Size(52, 23);
            this.tsbExport.Text = "Export";
            // 
            // tssOperation3
            // 
            this.tssOperation3.Name = "tssOperation3";
            this.tssOperation3.Size = new System.Drawing.Size(6, 26);
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(52, 23);
            this.tsbDelete.Text = "Delete";
            // 
            // tssOperation4
            // 
            this.tssOperation4.Name = "tssOperation4";
            this.tssOperation4.Size = new System.Drawing.Size(6, 26);
            // 
            // tsbPublish
            // 
            this.tsbPublish.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbPublish.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tsbPublish.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPublish.Name = "tsbPublish";
            this.tsbPublish.Size = new System.Drawing.Size(57, 23);
            this.tsbPublish.Text = "Publish";
            // 
            // gbQueue
            // 
            this.gbQueue.Controls.Add(this.tsQueue);
            this.gbQueue.Controls.Add(this.btnSaveQueue);
            this.gbQueue.Controls.Add(this.btnLoadQueue);
            this.gbQueue.Controls.Add(this.pnlOperationButtons);
            this.gbQueue.Controls.Add(this.btnClearQueue);
            this.gbQueue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbQueue.Location = new System.Drawing.Point(3, 466);
            this.gbQueue.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbQueue.Name = "gbQueue";
            this.gbQueue.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gbQueue.Size = new System.Drawing.Size(1746, 461);
            this.gbQueue.TabIndex = 1;
            this.gbQueue.TabStop = false;
            this.gbQueue.Text = "Queue";
            // 
            // tsQueue
            // 
            this.tsQueue.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsQueue.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbExecute,
            this.tsbCancel});
            this.tsQueue.Location = new System.Drawing.Point(3, 17);
            this.tsQueue.Name = "tsQueue";
            this.tsQueue.Size = new System.Drawing.Size(1740, 26);
            this.tsQueue.TabIndex = 10;
            this.tsQueue.Text = "Queue Toolstrip";
            // 
            // tsbExecute
            // 
            this.tsbExecute.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbExecute.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tsbExecute.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbExecute.Name = "tsbExecute";
            this.tsbExecute.Size = new System.Drawing.Size(59, 23);
            this.tsbExecute.Text = "Execute";
            this.tsbExecute.Click += new System.EventHandler(this.tsbDeploy_Click);
            // 
            // tsbCancel
            // 
            this.tsbCancel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tsbCancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCancel.Name = "tsbCancel";
            this.tsbCancel.Size = new System.Drawing.Size(53, 23);
            this.tsbCancel.Text = "Cancel";
            this.tsbCancel.Visible = false;
            this.tsbCancel.Click += new System.EventHandler(this.tsbCancel_Click);
            // 
            // btnSaveQueue
            // 
            this.btnSaveQueue.Enabled = false;
            this.btnSaveQueue.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnSaveQueue.Location = new System.Drawing.Point(1016, 221);
            this.btnSaveQueue.Margin = new System.Windows.Forms.Padding(4);
            this.btnSaveQueue.Name = "btnSaveQueue";
            this.btnSaveQueue.Size = new System.Drawing.Size(149, 30);
            this.btnSaveQueue.TabIndex = 11;
            this.btnSaveQueue.Text = "Save Queue";
            this.btnSaveQueue.UseVisualStyleBackColor = true;
            this.btnSaveQueue.Click += new System.EventHandler(this.btnSaveQueue_Click);
            // 
            // btnLoadQueue
            // 
            this.btnLoadQueue.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnLoadQueue.Location = new System.Drawing.Point(1016, 183);
            this.btnLoadQueue.Margin = new System.Windows.Forms.Padding(4);
            this.btnLoadQueue.Name = "btnLoadQueue";
            this.btnLoadQueue.Size = new System.Drawing.Size(149, 30);
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
            this.pnlOperationButtons.Location = new System.Drawing.Point(6, 45);
            this.pnlOperationButtons.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlOperationButtons.Name = "pnlOperationButtons";
            this.pnlOperationButtons.Size = new System.Drawing.Size(43, 412);
            this.pnlOperationButtons.TabIndex = 9;
            // 
            // btnClearQueue
            // 
            this.btnClearQueue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearQueue.Enabled = false;
            this.btnClearQueue.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnClearQueue.Location = new System.Drawing.Point(1016, 259);
            this.btnClearQueue.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearQueue.Name = "btnClearQueue";
            this.btnClearQueue.Size = new System.Drawing.Size(149, 30);
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
            this.btnAddOperation.Size = new System.Drawing.Size(1258, 30);
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
            this.lvOperations.Size = new System.Drawing.Size(1679, 382);
            this.lvOperations.TabIndex = 2;
            this.lvOperations.UseCompatibleStateImageBehavior = false;
            this.lvOperations.View = System.Windows.Forms.View.Details;
            this.lvOperations.SelectedIndexChanged += new System.EventHandler(this.lvOperations_SelectedIndexChanged);
            this.lvOperations.DoubleClick += new System.EventHandler(this.lvOperations_DoubleClick);
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
            this.chOpPublisher.Width = 250;
            // 
            // chOpDescription
            // 
            this.chOpDescription.Text = "Description";
            this.chOpDescription.Width = 270;
            // 
            // cmsContextMenu
            // 
            this.cmsContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmsContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cmsiRemove});
            this.cmsContextMenu.Name = "cms_ContextMenu";
            this.cmsContextMenu.Size = new System.Drawing.Size(138, 30);
            // 
            // cmsiRemove
            // 
            this.cmsiRemove.Name = "cmsiRemove";
            this.cmsiRemove.Size = new System.Drawing.Size(137, 26);
            this.cmsiRemove.Text = "Remove";
            // 
            // btnDown
            // 
            this.btnDown.BackgroundImage = global::Dataverse.XrmTools.Deployer.Properties.Resources.arrow_down_disabled_35px;
            this.btnDown.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnDown.Enabled = false;
            this.btnDown.FlatAppearance.BorderSize = 0;
            this.btnDown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDown.Location = new System.Drawing.Point(3, 49);
            this.btnDown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(37, 38);
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
            this.btnUp.Location = new System.Drawing.Point(3, 2);
            this.btnUp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnUp.Name = "btnUp";
            this.btnUp.Size = new System.Drawing.Size(37, 38);
            this.btnUp.TabIndex = 0;
            this.btnUp.UseVisualStyleBackColor = false;
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // DeployerControlCopy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.pnlMain);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MinimumSize = new System.Drawing.Size(800, 400);
            this.Name = "DeployerControlCopy";
            this.Size = new System.Drawing.Size(2197, 933);
            this.Load += new System.EventHandler(this.DataMigrationControl_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlSettings.ResumeLayout(false);
            this.gbSolutionPackagerLogs.ResumeLayout(false);
            this.gbSolutionPackagerLogs.PerformLayout();
            this.gbEnvironments.ResumeLayout(false);
            this.gbEnvironments.PerformLayout();
            this.gbDeployerLogs.ResumeLayout(false);
            this.gbDeployerLogs.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.gbAddOperation.ResumeLayout(false);
            this.gbAddOperation.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tsAddOperation.ResumeLayout(false);
            this.tsAddOperation.PerformLayout();
            this.gbQueue.ResumeLayout(false);
            this.gbQueue.PerformLayout();
            this.tsQueue.ResumeLayout(false);
            this.tsQueue.PerformLayout();
            this.pnlOperationButtons.ResumeLayout(false);
            this.cmsContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        // Main components
        private System.Windows.Forms.TableLayoutPanel pnlMain;

        // Environments group
        private System.Windows.Forms.GroupBox gbEnvironments;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblSourceValue;

        // Settings
        private System.Windows.Forms.TableLayoutPanel pnlSettings;

        // Body
        private System.Windows.Forms.TableLayoutPanel pnlBody;

        // Add Operation Group
        private System.Windows.Forms.GroupBox gbAddOperation;
        private System.Windows.Forms.ToolStrip tsAddOperation;
        private System.Windows.Forms.ToolStripButton tsbUpdate;
        private System.Windows.Forms.ToolStripSeparator tssOperation1;
        private System.Windows.Forms.ToolStripButton tsbExport;
        private System.Windows.Forms.ToolStripSeparator tssOperation2;
        private System.Windows.Forms.ToolStripButton tsbImport;
        private System.Windows.Forms.ToolStripSeparator tssOperation3;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripSeparator tssOperation4;
        private System.Windows.Forms.ToolStripButton tsbPublish;

        // Queue Group
        private System.Windows.Forms.GroupBox gbQueue;
        private System.Windows.Forms.ToolStrip tsQueue;
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
        private System.Windows.Forms.TextBox txtLogs;
        private System.Windows.Forms.Button btnClearQueue;
        private System.Windows.Forms.Label lblTarget;
        private System.Windows.Forms.Label lblTargetValue;
        private System.Windows.Forms.Button btnConnectTarget;
        private System.Windows.Forms.Button btnClearLogs;
        private System.Windows.Forms.Button btnUp;
        private System.Windows.Forms.Panel pnlOperationButtons;
        private System.Windows.Forms.Button btnDown;
        private System.Windows.Forms.Button btnSaveQueue;
        private System.Windows.Forms.Button btnLoadQueue;
        private System.Windows.Forms.GroupBox gbDeployerLogs;
        private WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender visualStudioToolStripExtender1;
        private WeifenLuo.WinFormsUI.Docking.VisualStudioToolStripExtender visualStudioToolStripExtender2;
        private System.Windows.Forms.GroupBox gbSolutionPackagerLogs;
        private System.Windows.Forms.Label lblPackagerVersion;
        private System.Windows.Forms.Label lblPackagerVersionValue;
        private System.Windows.Forms.RichTextBox txtOutput;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
    }
}

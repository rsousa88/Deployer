namespace Dataverse.XrmTools.ActiveLayerExplorer
{
    partial class ActiveLayerExplorerControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ActiveLayerExplorerControl));
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbLoadSolutions = new System.Windows.Forms.ToolStripButton();
            this.tsSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLoadLayers = new System.Windows.Forms.ToolStripButton();
            this.tsbRemoveLayers = new System.Windows.Forms.ToolStripButton();
            this.tsbAbort = new System.Windows.Forms.ToolStripButton();
            this.pnlMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSettings = new System.Windows.Forms.TableLayoutPanel();
            this.gbEnvironments = new System.Windows.Forms.GroupBox();
            this.lblSource = new System.Windows.Forms.Label();
            this.lblSourceValue = new System.Windows.Forms.Label();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.txtBatchSize = new System.Windows.Forms.TextBox();
            this.lblBatchSize = new System.Windows.Forms.Label();
            this.gbSolutions = new System.Windows.Forms.GroupBox();
            this.lblSolutionFilter = new System.Windows.Forms.Label();
            this.txtSolutionFilter = new System.Windows.Forms.TextBox();
            this.lvSolutions = new System.Windows.Forms.ListView();
            this.chSolDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlBody = new System.Windows.Forms.TableLayoutPanel();
            this.gbComponentTypes = new System.Windows.Forms.GroupBox();
            this.cbCmpTypSelectAll = new System.Windows.Forms.CheckBox();
            this.lvComponentTypes = new System.Windows.Forms.ListView();
            this.chCmpTypComponentName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCmpTypComponentCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCmpTypActiveLayerCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbLayers = new System.Windows.Forms.GroupBox();
            this.cbLayersSelectAll = new System.Windows.Forms.CheckBox();
            this.lvLayers = new System.Windows.Forms.ListView();
            this.chLayDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLayObjectId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLayType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tsMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.gbEnvironments.SuspendLayout();
            this.gbSettings.SuspendLayout();
            this.gbSolutions.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.gbComponentTypes.SuspendLayout();
            this.gbLayers.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.AutoSize = false;
            this.tsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbLoadSolutions,
            this.tsSeparator1,
            this.tsbLoadLayers,
            this.tsbRemoveLayers,
            this.tsbAbort});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1610, 25);
            this.tsMain.TabIndex = 90;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbLoadSolutions
            // 
            this.tsbLoadSolutions.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tsbLoadSolutions.Image = global::Dataverse.XrmTools.ActiveLayerExplorer.Properties.Resources.solutions;
            this.tsbLoadSolutions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoadSolutions.Name = "tsbLoadSolutions";
            this.tsbLoadSolutions.Size = new System.Drawing.Size(108, 22);
            this.tsbLoadSolutions.Text = "Load Solutions";
            this.tsbLoadSolutions.Click += new System.EventHandler(this.tsbLoadSolutions_Click);
            // 
            // tsSeparator1
            // 
            this.tsSeparator1.Name = "tsSeparator1";
            this.tsSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbLoadLayers
            // 
            this.tsbLoadLayers.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tsbLoadLayers.Image = global::Dataverse.XrmTools.ActiveLayerExplorer.Properties.Resources.solutions;
            this.tsbLoadLayers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoadLayers.Name = "tsbLoadLayers";
            this.tsbLoadLayers.Size = new System.Drawing.Size(123, 22);
            this.tsbLoadLayers.Text = "Load Active Layers";
            this.tsbLoadLayers.Click += new System.EventHandler(this.tsbLoadLayers_Click);
            // 
            // tsbRemoveLayers
            // 
            this.tsbRemoveLayers.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tsbRemoveLayers.Image = global::Dataverse.XrmTools.ActiveLayerExplorer.Properties.Resources.solutions;
            this.tsbRemoveLayers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRemoveLayers.Name = "tsbRemoveLayers";
            this.tsbRemoveLayers.Size = new System.Drawing.Size(105, 22);
            this.tsbRemoveLayers.Text = "Remove Layers";
            this.tsbRemoveLayers.Click += new System.EventHandler(this.tsbRemoveLayers_Click);
            // 
            // tsbAbort
            // 
            this.tsbAbort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAbort.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tsbAbort.Image = ((System.Drawing.Image)(resources.GetObject("tsbAbort.Image")));
            this.tsbAbort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbort.Name = "tsbAbort";
            this.tsbAbort.Size = new System.Drawing.Size(40, 22);
            this.tsbAbort.Text = "Abort";
            this.tsbAbort.Visible = false;
            // 
            // pnlMain
            // 
            this.pnlMain.ColumnCount = 2;
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.pnlMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.pnlMain.Controls.Add(this.pnlSettings, 0, 0);
            this.pnlMain.Controls.Add(this.pnlBody, 1, 0);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 25);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.RowCount = 1;
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlMain.Size = new System.Drawing.Size(1610, 763);
            this.pnlMain.TabIndex = 91;
            // 
            // pnlSettings
            // 
            this.pnlSettings.ColumnCount = 1;
            this.pnlSettings.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.pnlSettings.Controls.Add(this.gbEnvironments, 0, 0);
            this.pnlSettings.Controls.Add(this.gbSettings, 0, 1);
            this.pnlSettings.Controls.Add(this.gbSolutions, 0, 2);
            this.pnlSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSettings.Location = new System.Drawing.Point(2, 2);
            this.pnlSettings.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.RowCount = 3;
            this.pnlSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.5F));
            this.pnlSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.5F));
            this.pnlSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 87F));
            this.pnlSettings.Size = new System.Drawing.Size(318, 759);
            this.pnlSettings.TabIndex = 0;
            // 
            // gbEnvironments
            // 
            this.gbEnvironments.Controls.Add(this.lblSource);
            this.gbEnvironments.Controls.Add(this.lblSourceValue);
            this.gbEnvironments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbEnvironments.Location = new System.Drawing.Point(2, 2);
            this.gbEnvironments.Margin = new System.Windows.Forms.Padding(2);
            this.gbEnvironments.Name = "gbEnvironments";
            this.gbEnvironments.Padding = new System.Windows.Forms.Padding(2);
            this.gbEnvironments.Size = new System.Drawing.Size(314, 45);
            this.gbEnvironments.TabIndex = 0;
            this.gbEnvironments.TabStop = false;
            this.gbEnvironments.Text = "Environments";
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(4, 24);
            this.lblSource.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(41, 13);
            this.lblSource.TabIndex = 0;
            this.lblSource.Text = "Source";
            // 
            // lblSourceValue
            // 
            this.lblSourceValue.AutoSize = true;
            this.lblSourceValue.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.lblSourceValue.ForeColor = System.Drawing.Color.DarkRed;
            this.lblSourceValue.Location = new System.Drawing.Point(49, 25);
            this.lblSourceValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSourceValue.Name = "lblSourceValue";
            this.lblSourceValue.Size = new System.Drawing.Size(77, 13);
            this.lblSourceValue.TabIndex = 1;
            this.lblSourceValue.Text = "Disconnected";
            // 
            // gbSettings
            // 
            this.gbSettings.Controls.Add(this.txtBatchSize);
            this.gbSettings.Controls.Add(this.lblBatchSize);
            this.gbSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSettings.Location = new System.Drawing.Point(2, 51);
            this.gbSettings.Margin = new System.Windows.Forms.Padding(2);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Padding = new System.Windows.Forms.Padding(2);
            this.gbSettings.Size = new System.Drawing.Size(314, 45);
            this.gbSettings.TabIndex = 0;
            this.gbSettings.TabStop = false;
            this.gbSettings.Text = "Settings";
            // 
            // txtBatchSize
            // 
            this.txtBatchSize.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBatchSize.Location = new System.Drawing.Point(67, 21);
            this.txtBatchSize.Name = "txtBatchSize";
            this.txtBatchSize.Size = new System.Drawing.Size(59, 20);
            this.txtBatchSize.TabIndex = 2;
            this.txtBatchSize.Text = "1000";
            this.txtBatchSize.TextChanged += new System.EventHandler(this.txtBatchSize_TextChanged);
            // 
            // lblBatchSize
            // 
            this.lblBatchSize.AutoSize = true;
            this.lblBatchSize.Location = new System.Drawing.Point(4, 24);
            this.lblBatchSize.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblBatchSize.Name = "lblBatchSize";
            this.lblBatchSize.Size = new System.Drawing.Size(58, 13);
            this.lblBatchSize.TabIndex = 0;
            this.lblBatchSize.Text = "Batch Size";
            // 
            // gbSolutions
            // 
            this.pnlSettings.SetColumnSpan(this.gbSolutions, 2);
            this.gbSolutions.Controls.Add(this.lblSolutionFilter);
            this.gbSolutions.Controls.Add(this.txtSolutionFilter);
            this.gbSolutions.Controls.Add(this.lvSolutions);
            this.gbSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSolutions.Enabled = false;
            this.gbSolutions.Location = new System.Drawing.Point(2, 100);
            this.gbSolutions.Margin = new System.Windows.Forms.Padding(2);
            this.gbSolutions.Name = "gbSolutions";
            this.gbSolutions.Padding = new System.Windows.Forms.Padding(2);
            this.gbSolutions.Size = new System.Drawing.Size(314, 657);
            this.gbSolutions.TabIndex = 0;
            this.gbSolutions.TabStop = false;
            this.gbSolutions.Text = "Managed Solutions";
            // 
            // lblSolutionFilter
            // 
            this.lblSolutionFilter.AutoSize = true;
            this.lblSolutionFilter.Location = new System.Drawing.Point(5, 20);
            this.lblSolutionFilter.Name = "lblSolutionFilter";
            this.lblSolutionFilter.Size = new System.Drawing.Size(32, 13);
            this.lblSolutionFilter.TabIndex = 0;
            this.lblSolutionFilter.Text = "Filter:";
            // 
            // txtSolutionFilter
            // 
            this.txtSolutionFilter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSolutionFilter.Location = new System.Drawing.Point(48, 17);
            this.txtSolutionFilter.Name = "txtSolutionFilter";
            this.txtSolutionFilter.Size = new System.Drawing.Size(262, 20);
            this.txtSolutionFilter.TabIndex = 1;
            this.txtSolutionFilter.TextChanged += new System.EventHandler(this.txtSolutionFilter_TextChanged);
            // 
            // lvSolutions
            // 
            this.lvSolutions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSolutions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSolDisplayName});
            this.lvSolutions.FullRowSelect = true;
            this.lvSolutions.HideSelection = false;
            this.lvSolutions.Location = new System.Drawing.Point(7, 44);
            this.lvSolutions.MultiSelect = false;
            this.lvSolutions.Name = "lvSolutions";
            this.lvSolutions.Size = new System.Drawing.Size(300, 608);
            this.lvSolutions.TabIndex = 2;
            this.lvSolutions.UseCompatibleStateImageBehavior = false;
            this.lvSolutions.View = System.Windows.Forms.View.Details;
            this.lvSolutions.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.lvSolutions.SelectedIndexChanged += new System.EventHandler(this.lvSolutions_SelectedIndexChanged);
            this.lvSolutions.Resize += new System.EventHandler(this.lvSolutions_Resize);
            // 
            // chSolDisplayName
            // 
            this.chSolDisplayName.Text = "Display Name";
            this.chSolDisplayName.Width = 250;
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
            this.pnlBody.Controls.Add(this.gbComponentTypes, 0, 0);
            this.pnlBody.Controls.Add(this.gbLayers, 4, 0);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(324, 2);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(2);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.RowCount = 2;
            this.pnlBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlBody.Size = new System.Drawing.Size(1284, 759);
            this.pnlBody.TabIndex = 1;
            // 
            // gbComponentTypes
            // 
            this.pnlBody.SetColumnSpan(this.gbComponentTypes, 4);
            this.gbComponentTypes.Controls.Add(this.cbCmpTypSelectAll);
            this.gbComponentTypes.Controls.Add(this.lvComponentTypes);
            this.gbComponentTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbComponentTypes.Location = new System.Drawing.Point(2, 2);
            this.gbComponentTypes.Margin = new System.Windows.Forms.Padding(2);
            this.gbComponentTypes.Name = "gbComponentTypes";
            this.gbComponentTypes.Padding = new System.Windows.Forms.Padding(2);
            this.pnlBody.SetRowSpan(this.gbComponentTypes, 2);
            this.gbComponentTypes.Size = new System.Drawing.Size(508, 755);
            this.gbComponentTypes.TabIndex = 1;
            this.gbComponentTypes.TabStop = false;
            this.gbComponentTypes.Text = "Component Types";
            // 
            // cbCmpTypSelectAll
            // 
            this.cbCmpTypSelectAll.AutoSize = true;
            this.cbCmpTypSelectAll.Checked = true;
            this.cbCmpTypSelectAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCmpTypSelectAll.Location = new System.Drawing.Point(6, 21);
            this.cbCmpTypSelectAll.Name = "cbCmpTypSelectAll";
            this.cbCmpTypSelectAll.Size = new System.Drawing.Size(117, 17);
            this.cbCmpTypSelectAll.TabIndex = 0;
            this.cbCmpTypSelectAll.Text = "Select/Unselect All";
            this.cbCmpTypSelectAll.UseVisualStyleBackColor = true;
            this.cbCmpTypSelectAll.CheckedChanged += new System.EventHandler(this.cbCmpTypSelectAll_CheckedChanged);
            // 
            // lvComponentTypes
            // 
            this.lvComponentTypes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvComponentTypes.CheckBoxes = true;
            this.lvComponentTypes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCmpTypComponentName,
            this.chCmpTypComponentCount,
            this.chCmpTypActiveLayerCount});
            this.lvComponentTypes.FullRowSelect = true;
            this.lvComponentTypes.HideSelection = false;
            this.lvComponentTypes.Location = new System.Drawing.Point(6, 44);
            this.lvComponentTypes.Name = "lvComponentTypes";
            this.lvComponentTypes.Size = new System.Drawing.Size(500, 706);
            this.lvComponentTypes.TabIndex = 3;
            this.lvComponentTypes.UseCompatibleStateImageBehavior = false;
            this.lvComponentTypes.View = System.Windows.Forms.View.Details;
            this.lvComponentTypes.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.lvComponentTypes.Resize += new System.EventHandler(this.lvComponentTypes_Resize);
            // 
            // chCmpTypComponentName
            // 
            this.chCmpTypComponentName.Text = "Component Type";
            this.chCmpTypComponentName.Width = 200;
            // 
            // chCmpTypComponentCount
            // 
            this.chCmpTypComponentCount.Text = "Count";
            this.chCmpTypComponentCount.Width = 75;
            // 
            // chCmpTypActiveLayerCount
            // 
            this.chCmpTypActiveLayerCount.Text = "Active Layers";
            this.chCmpTypActiveLayerCount.Width = 100;
            // 
            // gbLayers
            // 
            this.pnlBody.SetColumnSpan(this.gbLayers, 6);
            this.gbLayers.Controls.Add(this.cbLayersSelectAll);
            this.gbLayers.Controls.Add(this.lvLayers);
            this.gbLayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbLayers.Location = new System.Drawing.Point(514, 2);
            this.gbLayers.Margin = new System.Windows.Forms.Padding(2);
            this.gbLayers.Name = "gbLayers";
            this.gbLayers.Padding = new System.Windows.Forms.Padding(2);
            this.pnlBody.SetRowSpan(this.gbLayers, 2);
            this.gbLayers.Size = new System.Drawing.Size(768, 755);
            this.gbLayers.TabIndex = 2;
            this.gbLayers.TabStop = false;
            this.gbLayers.Text = "Active Layers";
            // 
            // cbLayersSelectAll
            // 
            this.cbLayersSelectAll.AutoSize = true;
            this.cbLayersSelectAll.Checked = true;
            this.cbLayersSelectAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLayersSelectAll.Location = new System.Drawing.Point(6, 21);
            this.cbLayersSelectAll.Name = "cbLayersSelectAll";
            this.cbLayersSelectAll.Size = new System.Drawing.Size(117, 17);
            this.cbLayersSelectAll.TabIndex = 0;
            this.cbLayersSelectAll.Text = "Select/Unselect All";
            this.cbLayersSelectAll.UseVisualStyleBackColor = true;
            this.cbLayersSelectAll.CheckedChanged += new System.EventHandler(this.cbLayersSelectAll_CheckedChanged);
            // 
            // lvLayers
            // 
            this.lvLayers.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLayers.CheckBoxes = true;
            this.lvLayers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chLayDisplayName,
            this.chLayObjectId,
            this.chLayType});
            this.lvLayers.FullRowSelect = true;
            this.lvLayers.HideSelection = false;
            this.lvLayers.Location = new System.Drawing.Point(6, 44);
            this.lvLayers.Name = "lvLayers";
            this.lvLayers.Size = new System.Drawing.Size(750, 706);
            this.lvLayers.TabIndex = 3;
            this.lvLayers.UseCompatibleStateImageBehavior = false;
            this.lvLayers.View = System.Windows.Forms.View.Details;
            this.lvLayers.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.lvLayers.Resize += new System.EventHandler(this.lvLayers_Resize);
            // 
            // chLayDisplayName
            // 
            this.chLayDisplayName.Text = "Display Name";
            this.chLayDisplayName.Width = 300;
            // 
            // chLayObjectId
            // 
            this.chLayObjectId.Text = "Object Id";
            this.chLayObjectId.Width = 300;
            // 
            // chLayType
            // 
            this.chLayType.Text = "Type";
            this.chLayType.Width = 150;
            // 
            // ActiveLayerExplorerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.tsMain);
            this.MinimumSize = new System.Drawing.Size(450, 325);
            this.Name = "ActiveLayerExplorerControl";
            this.Size = new System.Drawing.Size(1610, 788);
            this.Load += new System.EventHandler(this.DataMigrationControl_Load);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlSettings.ResumeLayout(false);
            this.gbEnvironments.ResumeLayout(false);
            this.gbEnvironments.PerformLayout();
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.gbSolutions.ResumeLayout(false);
            this.gbSolutions.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.gbComponentTypes.ResumeLayout(false);
            this.gbComponentTypes.PerformLayout();
            this.gbLayers.ResumeLayout(false);
            this.gbLayers.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        // Main Tool Strip
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbLoadSolutions;
        private System.Windows.Forms.ToolStripSeparator tsSeparator1;

        // Main panel
        private System.Windows.Forms.TableLayoutPanel pnlMain;

        // Settings
        private System.Windows.Forms.TableLayoutPanel pnlSettings;

        // Environment settings group
        private System.Windows.Forms.GroupBox gbEnvironments;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblSourceValue;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.Label lblBatchSize;

        // Solutions Group
        private System.Windows.Forms.GroupBox gbSolutions;
        private System.Windows.Forms.Label lblSolutionFilter;
        private System.Windows.Forms.TextBox txtSolutionFilter;
        private System.Windows.Forms.ListView lvSolutions;
        private System.Windows.Forms.ColumnHeader chSolDisplayName;

        // Body
        private System.Windows.Forms.TableLayoutPanel pnlBody;

        // Component Types Group
        private System.Windows.Forms.GroupBox gbComponentTypes;
        private System.Windows.Forms.CheckBox cbCmpTypSelectAll;
        private System.Windows.Forms.ListView lvComponentTypes;
        private System.Windows.Forms.ColumnHeader chCmpTypComponentName;
        private System.Windows.Forms.ColumnHeader chCmpTypComponentCount;
        private System.Windows.Forms.ColumnHeader chCmpTypActiveLayerCount;
        private System.Windows.Forms.GroupBox gbLayers;
        private System.Windows.Forms.CheckBox cbLayersSelectAll;
        private System.Windows.Forms.ListView lvLayers;
        private System.Windows.Forms.ColumnHeader chLayDisplayName;
        private System.Windows.Forms.ColumnHeader chLayObjectId;
        private System.Windows.Forms.ColumnHeader chLayType;
        private System.Windows.Forms.ToolStripButton tsbAbort;
        private System.Windows.Forms.ToolStripButton tsbLoadLayers;
        private System.Windows.Forms.ToolStripButton tsbRemoveLayers;
        private System.Windows.Forms.TextBox txtBatchSize;
    }
}

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
            this.pnlMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSettings = new System.Windows.Forms.TableLayoutPanel();
            this.gbEnvironments = new System.Windows.Forms.GroupBox();
            this.lblSource = new System.Windows.Forms.Label();
            this.lblSourceValue = new System.Windows.Forms.Label();
            this.gbSettings = new System.Windows.Forms.GroupBox();
            this.txtBatchSize = new System.Windows.Forms.TextBox();
            this.lblBatchSize = new System.Windows.Forms.Label();
            this.btnLoadSolutions = new System.Windows.Forms.Button();
            this.gbSolutions = new System.Windows.Forms.GroupBox();
            this.lblSolutionFilter = new System.Windows.Forms.Label();
            this.txtSolutionFilter = new System.Windows.Forms.TextBox();
            this.lvSolutions = new System.Windows.Forms.ListView();
            this.chSolDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlBody = new System.Windows.Forms.TableLayoutPanel();
            this.gbComponents = new System.Windows.Forms.GroupBox();
            this.btnLoadLayers = new System.Windows.Forms.Button();
            this.cbCmpSelectAll = new System.Windows.Forms.CheckBox();
            this.lvComponents = new System.Windows.Forms.ListView();
            this.chCmpComponentName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCmpComponentCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCmpActiveLayerCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbLayers = new System.Windows.Forms.GroupBox();
            this.btnRemoveLayers = new System.Windows.Forms.Button();
            this.cbLayersSelectAll = new System.Windows.Forms.CheckBox();
            this.lvLayers = new System.Windows.Forms.ListView();
            this.chLayDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLayObjectId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chLayType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cbFilterLayers = new System.Windows.Forms.ComboBox();
            this.lblFilterLayers = new System.Windows.Forms.Label();
            this.pnlMain.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.gbEnvironments.SuspendLayout();
            this.gbSettings.SuspendLayout();
            this.gbSolutions.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.gbComponents.SuspendLayout();
            this.gbLayers.SuspendLayout();
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
            this.pnlMain.Margin = new System.Windows.Forms.Padding(2);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.RowCount = 1;
            this.pnlMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlMain.Size = new System.Drawing.Size(1610, 788);
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
            this.pnlSettings.Size = new System.Drawing.Size(318, 784);
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
            this.gbEnvironments.Size = new System.Drawing.Size(314, 46);
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
            this.gbSettings.Controls.Add(this.btnLoadSolutions);
            this.gbSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSettings.Location = new System.Drawing.Point(2, 52);
            this.gbSettings.Margin = new System.Windows.Forms.Padding(2);
            this.gbSettings.Name = "gbSettings";
            this.gbSettings.Padding = new System.Windows.Forms.Padding(2);
            this.gbSettings.Size = new System.Drawing.Size(314, 46);
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
            // btnLoadSolutions
            // 
            this.btnLoadSolutions.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadSolutions.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnLoadSolutions.Location = new System.Drawing.Point(180, 19);
            this.btnLoadSolutions.Name = "btnLoadSolutions";
            this.btnLoadSolutions.Size = new System.Drawing.Size(127, 23);
            this.btnLoadSolutions.TabIndex = 5;
            this.btnLoadSolutions.Text = "Reload Solutions";
            this.btnLoadSolutions.UseVisualStyleBackColor = true;
            this.btnLoadSolutions.Click += new System.EventHandler(this.tsbLoadSolutions_Click);
            // 
            // gbSolutions
            // 
            this.pnlSettings.SetColumnSpan(this.gbSolutions, 2);
            this.gbSolutions.Controls.Add(this.lblSolutionFilter);
            this.gbSolutions.Controls.Add(this.txtSolutionFilter);
            this.gbSolutions.Controls.Add(this.lvSolutions);
            this.gbSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSolutions.Enabled = false;
            this.gbSolutions.Location = new System.Drawing.Point(2, 102);
            this.gbSolutions.Margin = new System.Windows.Forms.Padding(2);
            this.gbSolutions.Name = "gbSolutions";
            this.gbSolutions.Padding = new System.Windows.Forms.Padding(2);
            this.gbSolutions.Size = new System.Drawing.Size(314, 680);
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
            this.lvSolutions.Size = new System.Drawing.Size(300, 631);
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
            this.pnlBody.Controls.Add(this.gbComponents, 0, 0);
            this.pnlBody.Controls.Add(this.gbLayers, 4, 0);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(324, 2);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(2);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.RowCount = 2;
            this.pnlBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlBody.Size = new System.Drawing.Size(1284, 784);
            this.pnlBody.TabIndex = 1;
            // 
            // gbComponents
            // 
            this.pnlBody.SetColumnSpan(this.gbComponents, 4);
            this.gbComponents.Controls.Add(this.btnLoadLayers);
            this.gbComponents.Controls.Add(this.cbCmpSelectAll);
            this.gbComponents.Controls.Add(this.lvComponents);
            this.gbComponents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbComponents.Location = new System.Drawing.Point(2, 2);
            this.gbComponents.Margin = new System.Windows.Forms.Padding(2);
            this.gbComponents.Name = "gbComponents";
            this.gbComponents.Padding = new System.Windows.Forms.Padding(2);
            this.pnlBody.SetRowSpan(this.gbComponents, 2);
            this.gbComponents.Size = new System.Drawing.Size(508, 780);
            this.gbComponents.TabIndex = 1;
            this.gbComponents.TabStop = false;
            this.gbComponents.Text = "Component Types";
            // 
            // btnLoadLayers
            // 
            this.btnLoadLayers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLoadLayers.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnLoadLayers.Location = new System.Drawing.Point(376, 14);
            this.btnLoadLayers.Name = "btnLoadLayers";
            this.btnLoadLayers.Size = new System.Drawing.Size(127, 23);
            this.btnLoadLayers.TabIndex = 4;
            this.btnLoadLayers.Text = "Load Active Layers";
            this.btnLoadLayers.UseVisualStyleBackColor = true;
            this.btnLoadLayers.Click += new System.EventHandler(this.tsbLoadLayers_Click);
            // 
            // cbCmpSelectAll
            // 
            this.cbCmpSelectAll.AutoSize = true;
            this.cbCmpSelectAll.Checked = true;
            this.cbCmpSelectAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbCmpSelectAll.Location = new System.Drawing.Point(6, 21);
            this.cbCmpSelectAll.Name = "cbCmpSelectAll";
            this.cbCmpSelectAll.Size = new System.Drawing.Size(117, 17);
            this.cbCmpSelectAll.TabIndex = 0;
            this.cbCmpSelectAll.Text = "Select/Unselect All";
            this.cbCmpSelectAll.UseVisualStyleBackColor = true;
            this.cbCmpSelectAll.CheckedChanged += new System.EventHandler(this.cbCmpTypSelectAll_CheckedChanged);
            // 
            // lvComponents
            // 
            this.lvComponents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvComponents.CheckBoxes = true;
            this.lvComponents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCmpComponentName,
            this.chCmpComponentCount,
            this.chCmpActiveLayerCount});
            this.lvComponents.FullRowSelect = true;
            this.lvComponents.HideSelection = false;
            this.lvComponents.Location = new System.Drawing.Point(6, 44);
            this.lvComponents.Name = "lvComponents";
            this.lvComponents.Size = new System.Drawing.Size(500, 731);
            this.lvComponents.TabIndex = 3;
            this.lvComponents.UseCompatibleStateImageBehavior = false;
            this.lvComponents.View = System.Windows.Forms.View.Details;
            this.lvComponents.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.lvComponents.Resize += new System.EventHandler(this.lvComponentTypes_Resize);
            // 
            // chCmpComponentName
            // 
            this.chCmpComponentName.Text = "Component Type";
            this.chCmpComponentName.Width = 200;
            // 
            // chCmpComponentCount
            // 
            this.chCmpComponentCount.Text = "Count";
            this.chCmpComponentCount.Width = 75;
            // 
            // chCmpActiveLayerCount
            // 
            this.chCmpActiveLayerCount.Text = "Active Layers";
            this.chCmpActiveLayerCount.Width = 100;
            // 
            // gbLayers
            // 
            this.pnlBody.SetColumnSpan(this.gbLayers, 6);
            this.gbLayers.Controls.Add(this.lblFilterLayers);
            this.gbLayers.Controls.Add(this.cbFilterLayers);
            this.gbLayers.Controls.Add(this.btnRemoveLayers);
            this.gbLayers.Controls.Add(this.cbLayersSelectAll);
            this.gbLayers.Controls.Add(this.lvLayers);
            this.gbLayers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbLayers.Location = new System.Drawing.Point(514, 2);
            this.gbLayers.Margin = new System.Windows.Forms.Padding(2);
            this.gbLayers.Name = "gbLayers";
            this.gbLayers.Padding = new System.Windows.Forms.Padding(2);
            this.pnlBody.SetRowSpan(this.gbLayers, 2);
            this.gbLayers.Size = new System.Drawing.Size(768, 780);
            this.gbLayers.TabIndex = 2;
            this.gbLayers.TabStop = false;
            this.gbLayers.Text = "Active Layers";
            // 
            // btnRemoveLayers
            // 
            this.btnRemoveLayers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveLayers.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnRemoveLayers.Location = new System.Drawing.Point(629, 14);
            this.btnRemoveLayers.Name = "btnRemoveLayers";
            this.btnRemoveLayers.Size = new System.Drawing.Size(127, 23);
            this.btnRemoveLayers.TabIndex = 5;
            this.btnRemoveLayers.Text = "Remove Layers";
            this.btnRemoveLayers.UseVisualStyleBackColor = true;
            this.btnRemoveLayers.Click += new System.EventHandler(this.tsbRemoveLayers_Click);
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
            this.lvLayers.Size = new System.Drawing.Size(750, 731);
            this.lvLayers.TabIndex = 3;
            this.lvLayers.UseCompatibleStateImageBehavior = false;
            this.lvLayers.View = System.Windows.Forms.View.Details;
            this.lvLayers.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.lvLayers.Resize += new System.EventHandler(this.lvLayers_Resize);
            // 
            // chLayDisplayName
            // 
            this.chLayDisplayName.Text = "Display Name";
            this.chLayDisplayName.Width = 294;
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
            // cbFilterLayers
            // 
            this.cbFilterLayers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFilterLayers.FormattingEnabled = true;
            this.cbFilterLayers.Location = new System.Drawing.Point(411, 16);
            this.cbFilterLayers.Name = "cbFilterLayers";
            this.cbFilterLayers.Size = new System.Drawing.Size(212, 21);
            this.cbFilterLayers.TabIndex = 6;
            this.cbFilterLayers.SelectedIndexChanged += new System.EventHandler(this.cbFilterLayers_SelectedIndexChanged);
            // 
            // lblFilterLayers
            // 
            this.lblFilterLayers.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFilterLayers.AutoSize = true;
            this.lblFilterLayers.Location = new System.Drawing.Point(333, 19);
            this.lblFilterLayers.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFilterLayers.Name = "lblFilterLayers";
            this.lblFilterLayers.Size = new System.Drawing.Size(73, 13);
            this.lblFilterLayers.TabIndex = 7;
            this.lblFilterLayers.Text = "Filter by Type:";
            // 
            // ActiveLayerExplorerControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.pnlMain);
            this.MinimumSize = new System.Drawing.Size(450, 325);
            this.Name = "ActiveLayerExplorerControl";
            this.Size = new System.Drawing.Size(1610, 788);
            this.Load += new System.EventHandler(this.DataMigrationControl_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlSettings.ResumeLayout(false);
            this.gbEnvironments.ResumeLayout(false);
            this.gbEnvironments.PerformLayout();
            this.gbSettings.ResumeLayout(false);
            this.gbSettings.PerformLayout();
            this.gbSolutions.ResumeLayout(false);
            this.gbSolutions.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.gbComponents.ResumeLayout(false);
            this.gbComponents.PerformLayout();
            this.gbLayers.ResumeLayout(false);
            this.gbLayers.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        // Main panel
        private System.Windows.Forms.TableLayoutPanel pnlMain;

        // Environments group
        private System.Windows.Forms.GroupBox gbEnvironments;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblSourceValue;

        // Settings
        private System.Windows.Forms.TableLayoutPanel pnlSettings;
        private System.Windows.Forms.GroupBox gbSettings;
        private System.Windows.Forms.Label lblBatchSize;
        private System.Windows.Forms.TextBox txtBatchSize;
        private System.Windows.Forms.Button btnLoadSolutions;

        // Solutions Group
        private System.Windows.Forms.GroupBox gbSolutions;
        private System.Windows.Forms.Label lblSolutionFilter;
        private System.Windows.Forms.TextBox txtSolutionFilter;
        private System.Windows.Forms.ListView lvSolutions;
        private System.Windows.Forms.ColumnHeader chSolDisplayName;

        // Body
        private System.Windows.Forms.TableLayoutPanel pnlBody;

        // Components Group
        private System.Windows.Forms.GroupBox gbComponents;
        private System.Windows.Forms.CheckBox cbCmpSelectAll;
        private System.Windows.Forms.ListView lvComponents;
        private System.Windows.Forms.ColumnHeader chCmpComponentName;
        private System.Windows.Forms.ColumnHeader chCmpComponentCount;
        private System.Windows.Forms.ColumnHeader chCmpActiveLayerCount;
        private System.Windows.Forms.Button btnLoadLayers;

        // Layers Group
        private System.Windows.Forms.GroupBox gbLayers;
        private System.Windows.Forms.CheckBox cbLayersSelectAll;
        private System.Windows.Forms.ListView lvLayers;
        private System.Windows.Forms.ColumnHeader chLayDisplayName;
        private System.Windows.Forms.ColumnHeader chLayObjectId;
        private System.Windows.Forms.ColumnHeader chLayType;
        private System.Windows.Forms.Button btnRemoveLayers;
        private System.Windows.Forms.ComboBox cbFilterLayers;
        private System.Windows.Forms.Label lblFilterLayers;
    }
}

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
            this.tsbRefreshSolutions = new System.Windows.Forms.ToolStripButton();
            this.tsSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAbort = new System.Windows.Forms.ToolStripButton();
            this.pnlMain = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSettings = new System.Windows.Forms.TableLayoutPanel();
            this.gbEnvironments = new System.Windows.Forms.GroupBox();
            this.lblSource = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.TableLayoutPanel();
            this.gbSolutions = new System.Windows.Forms.GroupBox();
            this.lblSolutionFilter = new System.Windows.Forms.Label();
            this.txtSolutionFilter = new System.Windows.Forms.TextBox();
            this.lvSolutions = new System.Windows.Forms.ListView();
            this.chSolId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolLogicalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chSolDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbComponentTypes = new System.Windows.Forms.GroupBox();
            this.cbCmpTypSelectAll = new System.Windows.Forms.CheckBox();
            this.lvComponentTypes = new System.Windows.Forms.ListView();
            this.chCmpTypComponentName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCmpTypComponentCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCmpTypActiveLayerCount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbComponents = new System.Windows.Forms.GroupBox();
            this.cbCmpSelectAll = new System.Windows.Forms.CheckBox();
            this.lvComponents = new System.Windows.Forms.ListView();
            this.chCmpDisplayName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCmpLogicalName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCmpType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chCmpTable = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbChanges = new System.Windows.Forms.GroupBox();
            this.cbChangesSelectAll = new System.Windows.Forms.CheckBox();
            this.lvChanges = new System.Windows.Forms.ListView();
            this.chChangesId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chChangesAttributeName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chChangesAttributeValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lblSourceValue = new System.Windows.Forms.Label();
            this.tsMain.SuspendLayout();
            this.pnlMain.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.gbEnvironments.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.gbSolutions.SuspendLayout();
            this.gbComponentTypes.SuspendLayout();
            this.gbComponents.SuspendLayout();
            this.gbChanges.SuspendLayout();
            this.SuspendLayout();
            // 
            // tsMain
            // 
            this.tsMain.AutoSize = false;
            this.tsMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbRefreshSolutions,
            this.tsSeparator1,
            this.tsbAbort});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Size = new System.Drawing.Size(1610, 25);
            this.tsMain.TabIndex = 90;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbRefreshSolutions
            // 
            this.tsbRefreshSolutions.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.tsbRefreshSolutions.Image = global::Dataverse.XrmTools.ActiveLayerExplorer.Properties.Resources.solutions;
            this.tsbRefreshSolutions.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbRefreshSolutions.Name = "tsbRefreshSolutions";
            this.tsbRefreshSolutions.Size = new System.Drawing.Size(108, 22);
            this.tsbRefreshSolutions.Text = "Load Solutions";
            this.tsbRefreshSolutions.Click += new System.EventHandler(this.tsbRefreshSolutions_Click);
            // 
            // tsSeparator1
            // 
            this.tsSeparator1.Name = "tsSeparator1";
            this.tsSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbAbort
            // 
            this.tsbAbort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tsbAbort.Image = ((System.Drawing.Image)(resources.GetObject("tsbAbort.Image")));
            this.tsbAbort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbAbort.Name = "tsbAbort";
            this.tsbAbort.Size = new System.Drawing.Size(45, 22);
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
            this.pnlSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlSettings.Location = new System.Drawing.Point(2, 2);
            this.pnlSettings.Margin = new System.Windows.Forms.Padding(2);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.RowCount = 2;
            this.pnlSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
            this.pnlSettings.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 92.5F));
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
            this.gbEnvironments.Size = new System.Drawing.Size(314, 52);
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
            // pnlBody
            // 
            this.pnlBody.ColumnCount = 9;
            this.pnlBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.pnlBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.pnlBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.pnlBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.pnlBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.pnlBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.pnlBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.pnlBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.pnlBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.11111F));
            this.pnlBody.Controls.Add(this.gbSolutions, 0, 0);
            this.pnlBody.Controls.Add(this.gbComponentTypes, 2, 0);
            this.pnlBody.Controls.Add(this.gbComponents, 5, 0);
            this.pnlBody.Controls.Add(this.gbChanges, 0, 1);
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
            // gbSolutions
            // 
            this.pnlBody.SetColumnSpan(this.gbSolutions, 2);
            this.gbSolutions.Controls.Add(this.lblSolutionFilter);
            this.gbSolutions.Controls.Add(this.txtSolutionFilter);
            this.gbSolutions.Controls.Add(this.lvSolutions);
            this.gbSolutions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSolutions.Enabled = false;
            this.gbSolutions.Location = new System.Drawing.Point(2, 2);
            this.gbSolutions.Margin = new System.Windows.Forms.Padding(2);
            this.gbSolutions.Name = "gbSolutions";
            this.gbSolutions.Padding = new System.Windows.Forms.Padding(2);
            this.gbSolutions.Size = new System.Drawing.Size(280, 375);
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
            this.txtSolutionFilter.Size = new System.Drawing.Size(228, 20);
            this.txtSolutionFilter.TabIndex = 1;
            this.txtSolutionFilter.TextChanged += new System.EventHandler(this.txtSolutionFilter_TextChanged);
            // 
            // lvSolutions
            // 
            this.lvSolutions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvSolutions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chSolId,
            this.chSolLogicalName,
            this.chSolDisplayName});
            this.lvSolutions.FullRowSelect = true;
            this.lvSolutions.HideSelection = false;
            this.lvSolutions.Location = new System.Drawing.Point(7, 44);
            this.lvSolutions.MultiSelect = false;
            this.lvSolutions.Name = "lvSolutions";
            this.lvSolutions.Size = new System.Drawing.Size(269, 326);
            this.lvSolutions.TabIndex = 2;
            this.lvSolutions.UseCompatibleStateImageBehavior = false;
            this.lvSolutions.View = System.Windows.Forms.View.Details;
            this.lvSolutions.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvSolutions_ColumnClick);
            this.lvSolutions.SelectedIndexChanged += new System.EventHandler(this.lvSolutions_SelectedIndexChanged);
            this.lvSolutions.Resize += new System.EventHandler(this.lvSolutions_Resize);
            // 
            // chSolId
            // 
            this.chSolId.Text = "Solution Id";
            this.chSolId.Width = 0;
            // 
            // chSolLogicalName
            // 
            this.chSolLogicalName.Text = "Logical Name";
            this.chSolLogicalName.Width = 0;
            // 
            // chSolDisplayName
            // 
            this.chSolDisplayName.Text = "Display Name";
            this.chSolDisplayName.Width = 250;
            // 
            // gbComponentTypes
            // 
            this.pnlBody.SetColumnSpan(this.gbComponentTypes, 3);
            this.gbComponentTypes.Controls.Add(this.cbCmpTypSelectAll);
            this.gbComponentTypes.Controls.Add(this.lvComponentTypes);
            this.gbComponentTypes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbComponentTypes.Location = new System.Drawing.Point(286, 2);
            this.gbComponentTypes.Margin = new System.Windows.Forms.Padding(2);
            this.gbComponentTypes.Name = "gbComponentTypes";
            this.gbComponentTypes.Padding = new System.Windows.Forms.Padding(2);
            this.gbComponentTypes.Size = new System.Drawing.Size(422, 375);
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
            this.lvComponentTypes.Size = new System.Drawing.Size(412, 326);
            this.lvComponentTypes.TabIndex = 3;
            this.lvComponentTypes.UseCompatibleStateImageBehavior = false;
            this.lvComponentTypes.View = System.Windows.Forms.View.Details;
            this.lvComponentTypes.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvSolutions_ColumnClick);
            this.lvComponentTypes.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.lvComponentTypes_ItemChecked);
            this.lvComponentTypes.Resize += new System.EventHandler(this.lvComponentTypes_Resize);
            // 
            // chCmpTypComponentName
            // 
            this.chCmpTypComponentName.Text = "Component";
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
            // gbComponents
            // 
            this.pnlBody.SetColumnSpan(this.gbComponents, 4);
            this.gbComponents.Controls.Add(this.cbCmpSelectAll);
            this.gbComponents.Controls.Add(this.lvComponents);
            this.gbComponents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbComponents.Location = new System.Drawing.Point(712, 2);
            this.gbComponents.Margin = new System.Windows.Forms.Padding(2);
            this.gbComponents.Name = "gbComponents";
            this.gbComponents.Padding = new System.Windows.Forms.Padding(2);
            this.gbComponents.Size = new System.Drawing.Size(570, 375);
            this.gbComponents.TabIndex = 2;
            this.gbComponents.TabStop = false;
            this.gbComponents.Text = "Components with Active Layer";
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
            // 
            // lvComponents
            // 
            this.lvComponents.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvComponents.CheckBoxes = true;
            this.lvComponents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chCmpDisplayName,
            this.chCmpLogicalName,
            this.chCmpType,
            this.chCmpTable});
            this.lvComponents.FullRowSelect = true;
            this.lvComponents.HideSelection = false;
            this.lvComponents.Location = new System.Drawing.Point(6, 44);
            this.lvComponents.Name = "lvComponents";
            this.lvComponents.Size = new System.Drawing.Size(560, 326);
            this.lvComponents.TabIndex = 3;
            this.lvComponents.UseCompatibleStateImageBehavior = false;
            this.lvComponents.View = System.Windows.Forms.View.Details;
            // 
            // chCmpDisplayName
            // 
            this.chCmpDisplayName.Text = "Display Name";
            this.chCmpDisplayName.Width = 200;
            // 
            // chCmpLogicalName
            // 
            this.chCmpLogicalName.Text = "Logical Name";
            this.chCmpLogicalName.Width = 200;
            // 
            // chCmpType
            // 
            this.chCmpType.Text = "Type";
            this.chCmpType.Width = 175;
            // 
            // chCmpTable
            // 
            this.chCmpTable.Text = "Table";
            this.chCmpTable.Width = 200;
            // 
            // gbChanges
            // 
            this.pnlBody.SetColumnSpan(this.gbChanges, 9);
            this.gbChanges.Controls.Add(this.cbChangesSelectAll);
            this.gbChanges.Controls.Add(this.lvChanges);
            this.gbChanges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbChanges.Location = new System.Drawing.Point(2, 381);
            this.gbChanges.Margin = new System.Windows.Forms.Padding(2);
            this.gbChanges.Name = "gbChanges";
            this.gbChanges.Padding = new System.Windows.Forms.Padding(2);
            this.gbChanges.Size = new System.Drawing.Size(1280, 376);
            this.gbChanges.TabIndex = 3;
            this.gbChanges.TabStop = false;
            this.gbChanges.Text = "Changes";
            // 
            // cbChangesSelectAll
            // 
            this.cbChangesSelectAll.AutoSize = true;
            this.cbChangesSelectAll.Checked = true;
            this.cbChangesSelectAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbChangesSelectAll.Location = new System.Drawing.Point(6, 21);
            this.cbChangesSelectAll.Name = "cbChangesSelectAll";
            this.cbChangesSelectAll.Size = new System.Drawing.Size(117, 17);
            this.cbChangesSelectAll.TabIndex = 0;
            this.cbChangesSelectAll.Text = "Select/Unselect All";
            this.cbChangesSelectAll.UseVisualStyleBackColor = true;
            // 
            // lvChanges
            // 
            this.lvChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvChanges.CheckBoxes = true;
            this.lvChanges.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chChangesId,
            this.chChangesAttributeName,
            this.chChangesAttributeValue});
            this.lvChanges.FullRowSelect = true;
            this.lvChanges.HideSelection = false;
            this.lvChanges.Location = new System.Drawing.Point(6, 44);
            this.lvChanges.Name = "lvChanges";
            this.lvChanges.Size = new System.Drawing.Size(1270, 359);
            this.lvChanges.TabIndex = 3;
            this.lvChanges.UseCompatibleStateImageBehavior = false;
            this.lvChanges.View = System.Windows.Forms.View.Details;
            // 
            // chChangesId
            // 
            this.chChangesId.Text = "Id";
            this.chChangesId.Width = 300;
            // 
            // chChangesAttributeName
            // 
            this.chChangesAttributeName.Text = "Attribute Name";
            this.chChangesAttributeName.Width = 200;
            // 
            // chChangesAttributeValue
            // 
            this.chChangesAttributeValue.Text = "Attribute Value";
            this.chChangesAttributeValue.Width = 900;
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
            this.Resize += new System.EventHandler(this.DataMigrationControl_Resize);
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.pnlMain.ResumeLayout(false);
            this.pnlSettings.ResumeLayout(false);
            this.gbEnvironments.ResumeLayout(false);
            this.gbEnvironments.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.gbSolutions.ResumeLayout(false);
            this.gbSolutions.PerformLayout();
            this.gbComponentTypes.ResumeLayout(false);
            this.gbComponentTypes.PerformLayout();
            this.gbComponents.ResumeLayout(false);
            this.gbComponents.PerformLayout();
            this.gbChanges.ResumeLayout(false);
            this.gbChanges.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        // Main Tool Strip
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbRefreshSolutions;
        private System.Windows.Forms.ToolStripSeparator tsSeparator1;

        // Main panel
        private System.Windows.Forms.TableLayoutPanel pnlMain;

        // Settings
        private System.Windows.Forms.TableLayoutPanel pnlSettings;

        // Environment settings group
        private System.Windows.Forms.GroupBox gbEnvironments;
        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblSourceValue;

        // Body
        private System.Windows.Forms.TableLayoutPanel pnlBody;

        // Solutions Group
        private System.Windows.Forms.GroupBox gbSolutions;
        private System.Windows.Forms.Label lblSolutionFilter;
        private System.Windows.Forms.TextBox txtSolutionFilter;
        private System.Windows.Forms.ListView lvSolutions;
        private System.Windows.Forms.ColumnHeader chSolId;
        private System.Windows.Forms.ColumnHeader chSolLogicalName;
        private System.Windows.Forms.ColumnHeader chSolDisplayName;

        // Component Types Group
        private System.Windows.Forms.GroupBox gbComponentTypes;
        private System.Windows.Forms.CheckBox cbCmpTypSelectAll;
        private System.Windows.Forms.ListView lvComponentTypes;
        private System.Windows.Forms.ColumnHeader chCmpTypComponentCount;
        private System.Windows.Forms.ColumnHeader chCmpTypActiveLayerCount;
        private System.Windows.Forms.ColumnHeader chCmpTypComponentName;
        private System.Windows.Forms.GroupBox gbComponents;
        private System.Windows.Forms.CheckBox cbCmpSelectAll;
        private System.Windows.Forms.ListView lvComponents;
        private System.Windows.Forms.ColumnHeader chCmpDisplayName;
        private System.Windows.Forms.ColumnHeader chCmpLogicalName;
        private System.Windows.Forms.ColumnHeader chCmpType;
        private System.Windows.Forms.ColumnHeader chCmpTable;
        private System.Windows.Forms.GroupBox gbChanges;
        private System.Windows.Forms.CheckBox cbChangesSelectAll;
        private System.Windows.Forms.ListView lvChanges;
        private System.Windows.Forms.ColumnHeader chChangesId;
        private System.Windows.Forms.ColumnHeader chChangesAttributeName;
        private System.Windows.Forms.ColumnHeader chChangesAttributeValue;
        private System.Windows.Forms.ToolStripButton tsbAbort;
    }
}

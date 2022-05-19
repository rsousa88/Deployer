
namespace Dataverse.XrmTools.Deployer.Forms
{
    partial class Results
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lvItems = new System.Windows.Forms.ListView();
            this.chResComponentName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chResDescription = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnClose = new System.Windows.Forms.Button();
            this.pnlBody = new System.Windows.Forms.TableLayoutPanel();
            this.gbSummary = new System.Windows.Forms.GroupBox();
            this.lblSumSuccess = new System.Windows.Forms.Label();
            this.lblSumError = new System.Windows.Forms.Label();
            this.lblSumSuccessValue = new System.Windows.Forms.Label();
            this.lblSumErrorValue = new System.Windows.Forms.Label();
            this.gbResults = new System.Windows.Forms.GroupBox();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.gbSummary.SuspendLayout();
            this.gbResults.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblDescription);
            this.pnlHeader.Controls.Add(this.lblTitle);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1131, 58);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescription.Location = new System.Drawing.Point(5, 34);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(192, 13);
            this.lblDescription.TabIndex = 2;
            this.lblDescription.Text = "Managed active layers delete results";
            // 
            // lblTitle
            // 
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(70, 25);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Results";
            // 
            // lvItems
            // 
            this.lvItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chResComponentName,
            this.chResDescription});
            this.lvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvItems.FullRowSelect = true;
            this.lvItems.HideSelection = false;
            this.lvItems.LabelEdit = true;
            this.lvItems.Location = new System.Drawing.Point(3, 16);
            this.lvItems.Name = "lvItems";
            this.lvItems.Size = new System.Drawing.Size(1005, 575);
            this.lvItems.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvItems.TabIndex = 4;
            this.lvItems.UseCompatibleStateImageBehavior = false;
            this.lvItems.View = System.Windows.Forms.View.Details;
            this.lvItems.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.lvItems.KeyUp += new System.Windows.Forms.KeyEventHandler(this.lvItems_KeyUp);
            // 
            // chResComponentName
            // 
            this.chResComponentName.Text = "Component Name";
            this.chResComponentName.Width = 300;
            // 
            // chResDescription
            // 
            this.chResDescription.Text = "Description";
            this.chResDescription.Width = 700;
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnClose);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 658);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1131, 52);
            this.pnlFooter.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(1044, 17);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.SystemColors.Window;
            this.pnlBody.ColumnCount = 2;
            this.pnlBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.pnlBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnlBody.Controls.Add(this.gbSummary, 1, 0);
            this.pnlBody.Controls.Add(this.gbResults, 0, 0);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 58);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.RowCount = 1;
            this.pnlBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.pnlBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.pnlBody.Size = new System.Drawing.Size(1131, 600);
            this.pnlBody.TabIndex = 105;
            // 
            // gbSummary
            // 
            this.gbSummary.BackColor = System.Drawing.SystemColors.Window;
            this.gbSummary.Controls.Add(this.lblSumSuccess);
            this.gbSummary.Controls.Add(this.lblSumError);
            this.gbSummary.Controls.Add(this.lblSumSuccessValue);
            this.gbSummary.Controls.Add(this.lblSumErrorValue);
            this.gbSummary.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbSummary.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.gbSummary.Location = new System.Drawing.Point(1020, 3);
            this.gbSummary.Name = "gbSummary";
            this.gbSummary.Size = new System.Drawing.Size(108, 594);
            this.gbSummary.TabIndex = 92;
            this.gbSummary.TabStop = false;
            this.gbSummary.Text = "Summary";
            // 
            // lblSumSuccess
            // 
            this.lblSumSuccess.AutoSize = true;
            this.lblSumSuccess.Location = new System.Drawing.Point(5, 19);
            this.lblSumSuccess.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSumSuccess.Name = "lblSumSuccess";
            this.lblSumSuccess.Size = new System.Drawing.Size(49, 13);
            this.lblSumSuccess.TabIndex = 3;
            this.lblSumSuccess.Text = "Success:";
            // 
            // lblSumError
            // 
            this.lblSumError.AutoSize = true;
            this.lblSumError.Location = new System.Drawing.Point(5, 34);
            this.lblSumError.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSumError.Name = "lblSumError";
            this.lblSumError.Size = new System.Drawing.Size(35, 13);
            this.lblSumError.TabIndex = 4;
            this.lblSumError.Text = "Error:";
            // 
            // lblSumSuccessValue
            // 
            this.lblSumSuccessValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSumSuccessValue.Location = new System.Drawing.Point(63, 19);
            this.lblSumSuccessValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSumSuccessValue.Name = "lblSumSuccessValue";
            this.lblSumSuccessValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSumSuccessValue.Size = new System.Drawing.Size(40, 15);
            this.lblSumSuccessValue.TabIndex = 7;
            this.lblSumSuccessValue.Text = "0";
            // 
            // lblSumErrorValue
            // 
            this.lblSumErrorValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSumErrorValue.Location = new System.Drawing.Point(63, 34);
            this.lblSumErrorValue.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblSumErrorValue.Name = "lblSumErrorValue";
            this.lblSumErrorValue.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblSumErrorValue.Size = new System.Drawing.Size(40, 15);
            this.lblSumErrorValue.TabIndex = 8;
            this.lblSumErrorValue.Text = "0";
            // 
            // gbResults
            // 
            this.gbResults.BackColor = System.Drawing.SystemColors.Window;
            this.gbResults.Controls.Add(this.lvItems);
            this.gbResults.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbResults.Location = new System.Drawing.Point(3, 3);
            this.gbResults.Name = "gbResults";
            this.gbResults.Size = new System.Drawing.Size(1011, 594);
            this.gbResults.TabIndex = 93;
            this.gbResults.TabStop = false;
            this.gbResults.Text = "Results";
            // 
            // Results
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1131, 710);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlFooter);
            this.Controls.Add(this.pnlHeader);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Results";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Results";
            this.Load += new System.EventHandler(this.LoadRecords);
            this.Resize += new System.EventHandler(this.Results_Resize);
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.gbSummary.ResumeLayout(false);
            this.gbSummary.PerformLayout();
            this.gbResults.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.ListView lvItems;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.ColumnHeader chResComponentName;
        private System.Windows.Forms.ColumnHeader chResDescription;
        private System.Windows.Forms.TableLayoutPanel pnlBody;
        private System.Windows.Forms.GroupBox gbResults;
        private System.Windows.Forms.GroupBox gbSummary;
        private System.Windows.Forms.Label lblSumSuccess;
        private System.Windows.Forms.Label lblSumError;
        private System.Windows.Forms.Label lblSumSuccessValue;
        private System.Windows.Forms.Label lblSumErrorValue;
    }
}

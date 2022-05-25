
namespace Dataverse.XrmTools.Deployer.Forms
{
    partial class AddOperation
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
            this.lblATitle = new System.Windows.Forms.Label();
            this.lblADescription = new System.Windows.Forms.Label();
            this.pnlBody = new System.Windows.Forms.TableLayoutPanel();
            this.gbOperationType = new System.Windows.Forms.GroupBox();
            this.rbExport = new System.Windows.Forms.RadioButton();
            this.rbImport = new System.Windows.Forms.RadioButton();
            this.rbDelete = new System.Windows.Forms.RadioButton();
            this.pnlOperationDetails = new System.Windows.Forms.TableLayoutPanel();
            this.gbExport = new System.Windows.Forms.GroupBox();
            this.gbImport = new System.Windows.Forms.GroupBox();
            this.gbDelete = new System.Windows.Forms.GroupBox();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.pnlOperationDetails.SuspendLayout();
            this.gbOperationType.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblATitle);
            this.pnlHeader.Controls.Add(this.lblADescription);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1245, 71);
            this.pnlHeader.TabIndex = 1;
            // 
            // lblATitle
            // 
            this.lblATitle.AutoSize = true;
            this.lblATitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblATitle.Location = new System.Drawing.Point(4, 9);
            this.lblATitle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblATitle.Name = "lblATitle";
            this.lblATitle.Size = new System.Drawing.Size(162, 32);
            this.lblATitle.TabIndex = 2;
            this.lblATitle.Text = "Add to queue";
            // 
            // lblADescription
            // 
            this.lblADescription.AutoSize = true;
            this.lblADescription.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblADescription.Location = new System.Drawing.Point(7, 42);
            this.lblADescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblADescription.Name = "lblADescription";
            this.lblADescription.Size = new System.Drawing.Size(393, 19);
            this.lblADescription.TabIndex = 3;
            this.lblADescription.Text = "Add an import, export or delete operation to the deploy queue";
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.SystemColors.Window;
            this.pnlBody.ColumnCount = 1;
            this.pnlBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlBody.Controls.Add(this.pnlOperationDetails, 0, 1);
            this.pnlBody.Controls.Add(this.gbOperationType, 0, 0);
            this.pnlBody.Location = new System.Drawing.Point(10, 78);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.RowCount = 2;
            this.pnlBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.pnlBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.pnlBody.Size = new System.Drawing.Size(1223, 495);
            this.pnlBody.TabIndex = 4;
            // 
            // gbOperationType
            // 
            this.gbOperationType.Controls.Add(this.rbExport);
            this.gbOperationType.Controls.Add(this.rbImport);
            this.gbOperationType.Controls.Add(this.rbDelete);
            this.gbOperationType.Location = new System.Drawing.Point(3, 3);
            this.gbOperationType.Name = "gbOperationType";
            this.gbOperationType.Size = new System.Drawing.Size(1217, 68);
            this.gbOperationType.TabIndex = 5;
            this.gbOperationType.TabStop = false;
            this.gbOperationType.Text = "Operation Type";
            // 
            // rbExport
            // 
            this.rbExport.AutoSize = true;
            this.rbExport.Location = new System.Drawing.Point(168, 24);
            this.rbExport.Name = "rbExport";
            this.rbExport.Size = new System.Drawing.Size(69, 21);
            this.rbExport.TabIndex = 6;
            this.rbExport.TabStop = true;
            this.rbExport.Text = "Export";
            this.rbExport.UseVisualStyleBackColor = true;
            // 
            // rbImport
            // 
            this.rbImport.AutoSize = true;
            this.rbImport.Location = new System.Drawing.Point(573, 24);
            this.rbImport.Name = "rbImport";
            this.rbImport.Size = new System.Drawing.Size(68, 21);
            this.rbImport.TabIndex = 7;
            this.rbImport.TabStop = true;
            this.rbImport.Text = "Import";
            this.rbImport.UseVisualStyleBackColor = true;
            // 
            // rbDelete
            // 
            this.rbDelete.AutoSize = true;
            this.rbDelete.Location = new System.Drawing.Point(978, 24);
            this.rbDelete.Name = "rbDelete";
            this.rbDelete.Size = new System.Drawing.Size(70, 21);
            this.rbDelete.TabIndex = 8;
            this.rbDelete.TabStop = true;
            this.rbDelete.Text = "Delete";
            this.rbDelete.UseVisualStyleBackColor = true;
            // 
            // pnlOperationDetails
            // 
            this.pnlOperationDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlOperationDetails.BackColor = System.Drawing.SystemColors.Window;
            this.pnlOperationDetails.ColumnCount = 3;
            this.pnlOperationDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.pnlOperationDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.pnlOperationDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33F));
            this.pnlOperationDetails.Controls.Add(this.gbDelete, 2, 0);
            this.pnlOperationDetails.Controls.Add(this.gbImport, 1, 0);
            this.pnlOperationDetails.Controls.Add(this.gbExport, 0, 0);
            this.pnlOperationDetails.Location = new System.Drawing.Point(3, 77);
            this.pnlOperationDetails.Name = "pnlOperationDetails";
            this.pnlOperationDetails.RowCount = 1;
            this.pnlOperationDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 440F));
            this.pnlOperationDetails.Size = new System.Drawing.Size(1217, 415);
            this.pnlOperationDetails.TabIndex = 5;
            // 
            // gbExport
            // 
            this.gbExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbExport.Location = new System.Drawing.Point(3, 3);
            this.gbExport.Name = "gbExport";
            this.gbExport.Size = new System.Drawing.Size(399, 434);
            this.gbExport.TabIndex = 0;
            this.gbExport.TabStop = false;
            this.gbExport.Text = "Export Options";
            // 
            // gbImport
            // 
            this.gbImport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbImport.Location = new System.Drawing.Point(408, 3);
            this.gbImport.Name = "gbImport";
            this.gbImport.Size = new System.Drawing.Size(399, 434);
            this.gbImport.TabIndex = 2;
            this.gbImport.TabStop = false;
            this.gbImport.Text = "Import Options";
            // 
            // gbDelete
            // 
            this.gbDelete.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbDelete.Location = new System.Drawing.Point(813, 3);
            this.gbDelete.Name = "gbDelete";
            this.gbDelete.Size = new System.Drawing.Size(401, 434);
            this.gbDelete.TabIndex = 3;
            this.gbDelete.TabStop = false;
            this.gbDelete.Text = "Delete Options";
            // 
            // AddOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1245, 585);
            this.Controls.Add(this.pnlBody);
            this.Controls.Add(this.pnlHeader);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AddOperation";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddOperation";
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlBody.ResumeLayout(false);
            this.pnlOperationDetails.ResumeLayout(false);
            this.gbOperationType.ResumeLayout(false);
            this.gbOperationType.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        // Header
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblATitle;
        private System.Windows.Forms.Label lblADescription;

        // Body
        private System.Windows.Forms.TableLayoutPanel pnlBody;
        private System.Windows.Forms.GroupBox gbOperationType;
        private System.Windows.Forms.RadioButton rbExport;
        private System.Windows.Forms.RadioButton rbImport;
        private System.Windows.Forms.RadioButton rbDelete;
        private System.Windows.Forms.TableLayoutPanel pnlOperationDetails;

        // Export
        private System.Windows.Forms.GroupBox gbExport;

        // Import
        private System.Windows.Forms.GroupBox gbImport;

        // Delete
        private System.Windows.Forms.GroupBox gbDelete;
    }
}
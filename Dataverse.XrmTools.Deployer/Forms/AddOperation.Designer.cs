
using Dataverse.XrmTools.Deployer.Controls;

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
            this.pnlOperationDetails = new System.Windows.Forms.TableLayoutPanel();
            this.gbOperationType = new System.Windows.Forms.GroupBox();
            this.rbExport = new System.Windows.Forms.RadioButton();
            this.rbImport = new System.Windows.Forms.RadioButton();
            this.rbDelete = new System.Windows.Forms.RadioButton();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.rbUpdate = new System.Windows.Forms.RadioButton();
            this.pnlHeader.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.gbOperationType.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlHeader
            // 
            this.pnlHeader.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlHeader.BackColor = System.Drawing.Color.White;
            this.pnlHeader.Controls.Add(this.lblATitle);
            this.pnlHeader.Controls.Add(this.lblADescription);
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1203, 74);
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
            this.pnlBody.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlBody.BackColor = System.Drawing.SystemColors.Window;
            this.pnlBody.ColumnCount = 1;
            this.pnlBody.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1206F));
            this.pnlBody.Controls.Add(this.pnlOperationDetails, 0, 1);
            this.pnlBody.Controls.Add(this.gbOperationType, 0, 0);
            this.pnlBody.Location = new System.Drawing.Point(0, 78);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(0);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.RowCount = 2;
            this.pnlBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.pnlBody.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 85F));
            this.pnlBody.Size = new System.Drawing.Size(1206, 476);
            this.pnlBody.TabIndex = 4;
            // 
            // pnlOperationDetails
            // 
            this.pnlOperationDetails.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlOperationDetails.BackColor = System.Drawing.SystemColors.Window;
            this.pnlOperationDetails.ColumnCount = 1;
            this.pnlOperationDetails.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1217F));
            this.pnlOperationDetails.Location = new System.Drawing.Point(3, 74);
            this.pnlOperationDetails.Name = "pnlOperationDetails";
            this.pnlOperationDetails.RowCount = 1;
            this.pnlOperationDetails.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 440F));
            this.pnlOperationDetails.Size = new System.Drawing.Size(1200, 399);
            this.pnlOperationDetails.TabIndex = 5;
            // 
            // gbOperationType
            // 
            this.gbOperationType.Controls.Add(this.rbUpdate);
            this.gbOperationType.Controls.Add(this.rbExport);
            this.gbOperationType.Controls.Add(this.rbImport);
            this.gbOperationType.Controls.Add(this.rbDelete);
            this.gbOperationType.Location = new System.Drawing.Point(3, 3);
            this.gbOperationType.Name = "gbOperationType";
            this.gbOperationType.Size = new System.Drawing.Size(1200, 60);
            this.gbOperationType.TabIndex = 5;
            this.gbOperationType.TabStop = false;
            this.gbOperationType.Text = "Operation Type";
            // 
            // rbExport
            // 
            this.rbExport.AutoSize = true;
            this.rbExport.Location = new System.Drawing.Point(396, 24);
            this.rbExport.Name = "rbExport";
            this.rbExport.Size = new System.Drawing.Size(124, 21);
            this.rbExport.TabIndex = 6;
            this.rbExport.Text = "Export Solution";
            this.rbExport.UseVisualStyleBackColor = true;
            this.rbExport.CheckedChanged += new System.EventHandler(this.rbExport_CheckedChanged);
            // 
            // rbImport
            // 
            this.rbImport.AutoSize = true;
            this.rbImport.Location = new System.Drawing.Point(730, 24);
            this.rbImport.Name = "rbImport";
            this.rbImport.Size = new System.Drawing.Size(123, 21);
            this.rbImport.TabIndex = 7;
            this.rbImport.Text = "Import Solution";
            this.rbImport.UseVisualStyleBackColor = true;
            this.rbImport.CheckedChanged += new System.EventHandler(this.rbImport_CheckedChanged);
            // 
            // rbDelete
            // 
            this.rbDelete.AutoSize = true;
            this.rbDelete.Location = new System.Drawing.Point(1063, 24);
            this.rbDelete.Name = "rbDelete";
            this.rbDelete.Size = new System.Drawing.Size(125, 21);
            this.rbDelete.TabIndex = 8;
            this.rbDelete.Text = "Delete Solution";
            this.rbDelete.UseVisualStyleBackColor = true;
            this.rbDelete.CheckedChanged += new System.EventHandler(this.rbDelete_CheckedChanged);
            // 
            // pnlFooter
            // 
            this.pnlFooter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFooter.BackColor = System.Drawing.Color.White;
            this.pnlFooter.Controls.Add(this.btnCancel);
            this.pnlFooter.Controls.Add(this.btnClose);
            this.pnlFooter.Location = new System.Drawing.Point(0, 558);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(4);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1203, 64);
            this.pnlFooter.TabIndex = 12;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(13, 18);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(133, 34);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(1087, 22);
            this.btnClose.Margin = new System.Windows.Forms.Padding(4);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(100, 28);
            this.btnClose.TabIndex = 5;
            this.btnClose.Text = "OK";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // rbUpdate
            // 
            this.rbUpdate.AutoSize = true;
            this.rbUpdate.Location = new System.Drawing.Point(9, 24);
            this.rbUpdate.Name = "rbUpdate";
            this.rbUpdate.Size = new System.Drawing.Size(177, 21);
            this.rbUpdate.TabIndex = 9;
            this.rbUpdate.Text = "Update Solution Details";
            this.rbUpdate.UseVisualStyleBackColor = true;
            this.rbUpdate.CheckedChanged += new System.EventHandler(this.rbUpdate_CheckedChanged);
            // 
            // AddOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1203, 621);
            this.Controls.Add(this.pnlFooter);
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
            this.gbOperationType.ResumeLayout(false);
            this.gbOperationType.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
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
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.RadioButton rbUpdate;
    }
}
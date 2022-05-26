
namespace Dataverse.XrmTools.Deployer.Controls
{
    partial class ExportOptions
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbExport = new System.Windows.Forms.GroupBox();
            this.gbExportSettings = new System.Windows.Forms.GroupBox();
            this.btnAddSolutionFile = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.gbExport.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbExport
            // 
            this.gbExport.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbExport.Controls.Add(this.gbExportSettings);
            this.gbExport.Controls.Add(this.btnAddSolutionFile);
            this.gbExport.Location = new System.Drawing.Point(0, 0);
            this.gbExport.Name = "gbExport";
            this.gbExport.Size = new System.Drawing.Size(1200, 300);
            this.gbExport.TabIndex = 1;
            this.gbExport.TabStop = false;
            this.gbExport.Text = "Export Options";
            // 
            // gbExportSettings
            // 
            this.gbExportSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbExportSettings.Location = new System.Drawing.Point(7, 58);
            this.gbExportSettings.Name = "gbExportSettings";
            this.gbExportSettings.Size = new System.Drawing.Size(590, 236);
            this.gbExportSettings.TabIndex = 10;
            this.gbExportSettings.TabStop = false;
            this.gbExportSettings.Text = "Export Settings";
            // 
            // btnAddSolutionFile
            // 
            this.btnAddSolutionFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddSolutionFile.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnAddSolutionFile.Location = new System.Drawing.Point(7, 22);
            this.btnAddSolutionFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddSolutionFile.Name = "btnAddSolutionFile";
            this.btnAddSolutionFile.Size = new System.Drawing.Size(1186, 29);
            this.btnAddSolutionFile.TabIndex = 8;
            this.btnAddSolutionFile.Text = "Add Solution File...";
            this.btnAddSolutionFile.UseVisualStyleBackColor = true;
            this.btnAddSolutionFile.Click += new System.EventHandler(this.btnAddSolution_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(0, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 0;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(0, 0);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 0;
            // 
            // ExportOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbExport);
            this.Name = "ExportOptions";
            this.Size = new System.Drawing.Size(1200, 300);
            this.gbExport.ResumeLayout(false);
            this.ResumeLayout(false);

        }
        #endregion

        private System.Windows.Forms.GroupBox gbExport;
        private System.Windows.Forms.Button btnAddSolutionFile;
        private System.Windows.Forms.GroupBox gbExportSettings;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnClose;
    }
}

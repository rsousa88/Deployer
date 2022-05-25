
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
            this.SuspendLayout();
            // 
            // gbExport
            // 
            this.gbExport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbExport.Location = new System.Drawing.Point(0, 0);
            this.gbExport.Name = "gbExport";
            this.gbExport.Size = new System.Drawing.Size(1257, 464);
            this.gbExport.TabIndex = 1;
            this.gbExport.TabStop = false;
            this.gbExport.Text = "Export Options";
            // 
            // ExportOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbExport);
            this.Name = "ExportOptions";
            this.Size = new System.Drawing.Size(1257, 464);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbExport;
    }
}

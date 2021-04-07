
namespace Tucil3_13519202
{
    partial class FileUploaderViewer
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonFileUpload = new System.Windows.Forms.Button();
            this.labelUploadFile = new System.Windows.Forms.Label();
            this.openFileDialogUpload = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // buttonFileUpload
            // 
            this.buttonFileUpload.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonFileUpload.ForeColor = System.Drawing.Color.Black;
            this.buttonFileUpload.Location = new System.Drawing.Point(319, 224);
            this.buttonFileUpload.Name = "buttonFileUpload";
            this.buttonFileUpload.Size = new System.Drawing.Size(154, 43);
            this.buttonFileUpload.TabIndex = 0;
            this.buttonFileUpload.Text = "Upload";
            this.buttonFileUpload.UseVisualStyleBackColor = true;
            this.buttonFileUpload.Click += new System.EventHandler(this.buttonFileUpload_Click);
            // 
            // labelUploadFile
            // 
            this.labelUploadFile.AutoSize = true;
            this.labelUploadFile.Font = new System.Drawing.Font("Segoe UI Light", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.labelUploadFile.Location = new System.Drawing.Point(270, 109);
            this.labelUploadFile.Name = "labelUploadFile";
            this.labelUploadFile.Size = new System.Drawing.Size(253, 65);
            this.labelUploadFile.TabIndex = 1;
            this.labelUploadFile.Text = "File Upload";
            // 
            // openFileDialogUpload
            // 
            this.openFileDialogUpload.FileName = "openFileDialogUpload";
            // 
            // FileUploaderViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labelUploadFile);
            this.Controls.Add(this.buttonFileUpload);
            this.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.Name = "FileUploaderViewer";
            this.Text = "File Upload";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonFileUpload;
        private System.Windows.Forms.Label labelUploadFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialogUpload;
    }
}



namespace Tucil3_13519202
{
    partial class MapViewer
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
            this.buatmsagl = new System.Windows.Forms.GroupBox();
            this.buttonMapViewer = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buatmsagl
            // 
            this.buatmsagl.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buatmsagl.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.buatmsagl.Location = new System.Drawing.Point(57, 44);
            this.buatmsagl.Name = "buatmsagl";
            this.buatmsagl.Size = new System.Drawing.Size(686, 354);
            this.buatmsagl.TabIndex = 0;
            this.buatmsagl.TabStop = false;
            this.buatmsagl.Text = "Map";
            // 
            // buttonMapViewer
            // 
            this.buttonMapViewer.Location = new System.Drawing.Point(346, 415);
            this.buttonMapViewer.Name = "buttonMapViewer";
            this.buttonMapViewer.Size = new System.Drawing.Size(114, 23);
            this.buttonMapViewer.TabIndex = 1;
            this.buttonMapViewer.Text = "Shortest Path";
            this.buttonMapViewer.UseVisualStyleBackColor = true;
            this.buttonMapViewer.Click += new System.EventHandler(this.buttonMapViewer_Click);
            // 
            // MapViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonMapViewer);
            this.Controls.Add(this.buatmsagl);
            this.Name = "MapViewer";
            this.Text = "Map";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox buatmsagl;
        private System.Windows.Forms.Button buttonMapViewer;
    }
}
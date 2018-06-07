namespace Prowadzacy_App
{
    partial class ScreenViewer
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
            this.ScreenViewer_image = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.ScreenViewer_image)).BeginInit();
            this.SuspendLayout();
            // 
            // ScreenViewer_image
            // 
            this.ScreenViewer_image.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ScreenViewer_image.Location = new System.Drawing.Point(0, 0);
            this.ScreenViewer_image.Name = "ScreenViewer_image";
            this.ScreenViewer_image.Size = new System.Drawing.Size(800, 450);
            this.ScreenViewer_image.TabIndex = 0;
            this.ScreenViewer_image.TabStop = false;
            // 
            // ScreenViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ScreenViewer_image);
            this.Name = "ScreenViewer";
            this.Text = "ScreenViewer";
            ((System.ComponentModel.ISupportInitialize)(this.ScreenViewer_image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ScreenViewer_image;
    }
}
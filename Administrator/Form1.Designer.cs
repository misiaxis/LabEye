using System.ComponentModel;
using System.Windows.Forms;

namespace Administrator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            this.MainTabControl = new System.Windows.Forms.TabControl();
            this.AppDnsManagment = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.BlackListAppListBox = new System.Windows.Forms.ListBox();
            this.appkeywordtoadd = new System.Windows.Forms.TextBox();
            this.AddAppKeyword = new System.Windows.Forms.Button();
            this.MainTabControl.SuspendLayout();
            this.AppDnsManagment.SuspendLayout();
            this.SuspendLayout();
            // 
            // MainTabControl
            // 
            this.MainTabControl.Controls.Add(this.AppDnsManagment);
            this.MainTabControl.Location = new System.Drawing.Point(0, 0);
            this.MainTabControl.Margin = new System.Windows.Forms.Padding(0);
            this.MainTabControl.Name = "MainTabControl";
            this.MainTabControl.Padding = new System.Drawing.Point(0, 0);
            this.MainTabControl.SelectedIndex = 0;
            this.MainTabControl.Size = new System.Drawing.Size(825, 376);
            this.MainTabControl.TabIndex = 0;
            // 
            // AppDnsManagment
            // 
            this.AppDnsManagment.Controls.Add(this.AddAppKeyword);
            this.AppDnsManagment.Controls.Add(this.appkeywordtoadd);
            this.AppDnsManagment.Controls.Add(this.label1);
            this.AppDnsManagment.Controls.Add(this.BlackListAppListBox);
            this.AppDnsManagment.Location = new System.Drawing.Point(4, 22);
            this.AppDnsManagment.Name = "AppDnsManagment";
            this.AppDnsManagment.Padding = new System.Windows.Forms.Padding(3);
            this.AppDnsManagment.Size = new System.Drawing.Size(817, 350);
            this.AppDnsManagment.TabIndex = 0;
            this.AppDnsManagment.Text = "Zarządzanie czarnymi listami";
            this.AppDnsManagment.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Słowa kluczowe dla aplikacji";
            // 
            // BlackListAppListBox
            // 
            this.BlackListAppListBox.FormattingEnabled = true;
            this.BlackListAppListBox.Location = new System.Drawing.Point(3, 19);
            this.BlackListAppListBox.Name = "BlackListAppListBox";
            this.BlackListAppListBox.Size = new System.Drawing.Size(305, 238);
            this.BlackListAppListBox.TabIndex = 0;
            // 
            // appkeywordtoadd
            // 
            this.appkeywordtoadd.Location = new System.Drawing.Point(0, 276);
            this.appkeywordtoadd.Name = "appkeywordtoadd";
            this.appkeywordtoadd.Size = new System.Drawing.Size(206, 20);
            this.appkeywordtoadd.TabIndex = 2;
            // 
            // AddAppKeyword
            // 
            this.AddAppKeyword.Location = new System.Drawing.Point(233, 273);
            this.AddAppKeyword.Name = "AddAppKeyword";
            this.AddAppKeyword.Size = new System.Drawing.Size(75, 23);
            this.AddAppKeyword.TabIndex = 3;
            this.AddAppKeyword.Text = "Dodaj";
            this.AddAppKeyword.UseVisualStyleBackColor = true;
            this.AddAppKeyword.Click += new System.EventHandler(this.AddNewKeywordToBlacklist);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(826, 626);
            this.Controls.Add(this.MainTabControl);
            this.Name = "Form1";
            this.Text = "Aplikacja administratora";
            this.MainTabControl.ResumeLayout(false);
            this.AppDnsManagment.ResumeLayout(false);
            this.AppDnsManagment.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private TabControl MainTabControl;
        private TabPage AppDnsManagment;
        private Label label1;
        private ListBox BlackListAppListBox;
        private Button AddAppKeyword;
        private TextBox appkeywordtoadd;
    }
}


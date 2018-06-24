namespace Prowadzacy_App
{
    partial class StartupSettings
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
            this.label_title = new System.Windows.Forms.Label();
            this.labelMongiString = new System.Windows.Forms.Label();
            this.labelDbName = new System.Windows.Forms.Label();
            this.textBox_MongoPath = new System.Windows.Forms.TextBox();
            this.textBox_MongoDbName = new System.Windows.Forms.TextBox();
            this.button_SaveConfig = new System.Windows.Forms.Button();
            this.button_SaveConfigToFile = new System.Windows.Forms.Button();
            this.button_LoadConfigFromFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.AutoSize = true;
            this.label_title.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label_title.Location = new System.Drawing.Point(106, 9);
            this.label_title.Name = "label_title";
            this.label_title.Size = new System.Drawing.Size(288, 16);
            this.label_title.TabIndex = 0;
            this.label_title.Text = "Nie znaleziono pliku konfiguracyjnego";
            // 
            // labelMongiString
            // 
            this.labelMongiString.AutoSize = true;
            this.labelMongiString.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelMongiString.Location = new System.Drawing.Point(12, 41);
            this.labelMongiString.Name = "labelMongiString";
            this.labelMongiString.Size = new System.Drawing.Size(113, 16);
            this.labelMongiString.TabIndex = 1;
            this.labelMongiString.Text = "Ścieżka MongoDB:";
            // 
            // labelDbName
            // 
            this.labelDbName.AutoSize = true;
            this.labelDbName.Font = new System.Drawing.Font("Lucida Sans Unicode", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelDbName.Location = new System.Drawing.Point(12, 76);
            this.labelDbName.Name = "labelDbName";
            this.labelDbName.Size = new System.Drawing.Size(128, 16);
            this.labelDbName.TabIndex = 2;
            this.labelDbName.Text = "Nazwa bazy danych:";
            // 
            // textBox_MongoPath
            // 
            this.textBox_MongoPath.Location = new System.Drawing.Point(138, 40);
            this.textBox_MongoPath.Name = "textBox_MongoPath";
            this.textBox_MongoPath.Size = new System.Drawing.Size(313, 20);
            this.textBox_MongoPath.TabIndex = 3;
            // 
            // textBox_MongoDbName
            // 
            this.textBox_MongoDbName.Location = new System.Drawing.Point(138, 75);
            this.textBox_MongoDbName.Name = "textBox_MongoDbName";
            this.textBox_MongoDbName.Size = new System.Drawing.Size(313, 20);
            this.textBox_MongoDbName.TabIndex = 4;
            // 
            // button_SaveConfig
            // 
            this.button_SaveConfig.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_SaveConfig.Location = new System.Drawing.Point(12, 109);
            this.button_SaveConfig.Name = "button_SaveConfig";
            this.button_SaveConfig.Size = new System.Drawing.Size(75, 23);
            this.button_SaveConfig.TabIndex = 5;
            this.button_SaveConfig.Text = "Zapisz";
            this.button_SaveConfig.UseVisualStyleBackColor = true;
            this.button_SaveConfig.Click += new System.EventHandler(this.SaveConfiguration);
            // 
            // button_SaveConfigToFile
            // 
            this.button_SaveConfigToFile.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_SaveConfigToFile.Location = new System.Drawing.Point(178, 109);
            this.button_SaveConfigToFile.Name = "button_SaveConfigToFile";
            this.button_SaveConfigToFile.Size = new System.Drawing.Size(114, 23);
            this.button_SaveConfigToFile.TabIndex = 6;
            this.button_SaveConfigToFile.Text = "Zapisz do pliku";
            this.button_SaveConfigToFile.UseVisualStyleBackColor = true;
            this.button_SaveConfigToFile.Click += new System.EventHandler(this.button_SaveConfigToFile_Click);
            // 
            // button_LoadConfigFromFile
            // 
            this.button_LoadConfigFromFile.Font = new System.Drawing.Font("Lucida Sans Unicode", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button_LoadConfigFromFile.Location = new System.Drawing.Point(376, 109);
            this.button_LoadConfigFromFile.Name = "button_LoadConfigFromFile";
            this.button_LoadConfigFromFile.Size = new System.Drawing.Size(75, 23);
            this.button_LoadConfigFromFile.TabIndex = 7;
            this.button_LoadConfigFromFile.Text = "Wczytaj";
            this.button_LoadConfigFromFile.UseVisualStyleBackColor = true;
            this.button_LoadConfigFromFile.Click += new System.EventHandler(this.button_LoadConfigFromFile_Click);
            // 
            // StartupSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 437);
            this.Controls.Add(this.button_LoadConfigFromFile);
            this.Controls.Add(this.button_SaveConfigToFile);
            this.Controls.Add(this.button_SaveConfig);
            this.Controls.Add(this.textBox_MongoDbName);
            this.Controls.Add(this.textBox_MongoPath);
            this.Controls.Add(this.labelDbName);
            this.Controls.Add(this.labelMongiString);
            this.Controls.Add(this.label_title);
            this.Name = "StartupSettings";
            this.Text = "StartupSettings";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label labelMongiString;
        private System.Windows.Forms.Label labelDbName;
        private System.Windows.Forms.TextBox textBox_MongoPath;
        private System.Windows.Forms.TextBox textBox_MongoDbName;
        private System.Windows.Forms.Button button_SaveConfig;
        private System.Windows.Forms.Button button_SaveConfigToFile;
        private System.Windows.Forms.Button button_LoadConfigFromFile;
    }
}
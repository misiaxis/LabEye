namespace Prowadzacy_App
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.Database = new System.Windows.Forms.TabPage();
            this.BoxAlerts = new System.Windows.Forms.GroupBox();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.linkLabel2 = new System.Windows.Forms.LinkLabel();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.labelAlertTime = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.BlAlertsDG = new System.Windows.Forms.DataGridView();
            this.BoxDetails = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelIpAdress = new System.Windows.Forms.Label();
            this.labelHostName = new System.Windows.Forms.Label();
            this.labelWorkstationName = new System.Windows.Forms.Label();
            this.AppAlertsDG = new System.Windows.Forms.DataGridView();
            this.Delete = new System.Windows.Forms.Button();
            this.Refresh1 = new System.Windows.Forms.Button();
            this.MainDG = new System.Windows.Forms.DataGridView();
            this.BlackListManagement = new System.Windows.Forms.TabPage();
            this.getBlackList = new System.Windows.Forms.Button();
            this.updateButton = new System.Windows.Forms.Button();
            this.blPageManagmentLabel = new System.Windows.Forms.Label();
            this.blAppManagmentLabel = new System.Windows.Forms.Label();
            this.blPagesManagmentGrid = new System.Windows.Forms.DataGridView();
            this.blAppsManagmentGrid = new System.Windows.Forms.DataGridView();
            this.Tabs.SuspendLayout();
            this.Database.SuspendLayout();
            this.BoxAlerts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlAlertsDG)).BeginInit();
            this.BoxDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppAlertsDG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainDG)).BeginInit();
            this.BlackListManagement.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blPagesManagmentGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blAppsManagmentGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // Tabs
            // 
            this.Tabs.Controls.Add(this.Database);
            this.Tabs.Controls.Add(this.BlackListManagement);
            this.Tabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Tabs.Location = new System.Drawing.Point(0, 0);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(1350, 729);
            this.Tabs.TabIndex = 8;
            this.Tabs.EnabledChanged += new System.EventHandler(this.getBlackList_Click);
            // 
            // Database
            // 
            this.Database.Controls.Add(this.BoxAlerts);
            this.Database.Controls.Add(this.BoxDetails);
            this.Database.Controls.Add(this.Delete);
            this.Database.Controls.Add(this.Refresh1);
            this.Database.Controls.Add(this.MainDG);
            this.Database.Location = new System.Drawing.Point(4, 22);
            this.Database.Name = "Database";
            this.Database.Padding = new System.Windows.Forms.Padding(3);
            this.Database.Size = new System.Drawing.Size(1342, 703);
            this.Database.TabIndex = 0;
            this.Database.Text = "Database";
            this.Database.UseVisualStyleBackColor = true;
            // 
            // BoxAlerts
            // 
            this.BoxAlerts.Controls.Add(this.linkLabel3);
            this.BoxAlerts.Controls.Add(this.linkLabel2);
            this.BoxAlerts.Controls.Add(this.label8);
            this.BoxAlerts.Controls.Add(this.label7);
            this.BoxAlerts.Controls.Add(this.label6);
            this.BoxAlerts.Controls.Add(this.label5);
            this.BoxAlerts.Controls.Add(this.labelAlertTime);
            this.BoxAlerts.Controls.Add(this.linkLabel1);
            this.BoxAlerts.Controls.Add(this.BlAlertsDG);
            this.BoxAlerts.Font = new System.Drawing.Font("Lucida Sans Unicode", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BoxAlerts.Location = new System.Drawing.Point(807, 3);
            this.BoxAlerts.Name = "BoxAlerts";
            this.BoxAlerts.Size = new System.Drawing.Size(527, 633);
            this.BoxAlerts.TabIndex = 17;
            this.BoxAlerts.TabStop = false;
            this.BoxAlerts.Text = "Alarmy";
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(95, 387);
            this.linkLabel3.Margin = new System.Windows.Forms.Padding(5);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(121, 27);
            this.linkLabel3.TabIndex = 24;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "linkLabel3";
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(95, 350);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(5);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(121, 27);
            this.linkLabel2.TabIndex = 23;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "linkLabel2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(8, 387);
            this.label8.Margin = new System.Windows.Forms.Padding(5);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(92, 27);
            this.label8.TabIndex = 22;
            this.label8.Text = "Link 3 :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 350);
            this.label7.Margin = new System.Windows.Forms.Padding(5);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(92, 27);
            this.label7.TabIndex = 21;
            this.label7.Text = "Link 2 :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 313);
            this.label6.Margin = new System.Windows.Forms.Padding(5);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 27);
            this.label6.TabIndex = 20;
            this.label6.Text = "Link 1 :";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(8, 276);
            this.label5.Margin = new System.Windows.Forms.Padding(5);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(208, 27);
            this.label5.TabIndex = 19;
            this.label5.Text = "Czas wystąpienia :";
            // 
            // labelAlertTime
            // 
            this.labelAlertTime.AutoSize = true;
            this.labelAlertTime.Location = new System.Drawing.Point(226, 276);
            this.labelAlertTime.Margin = new System.Windows.Forms.Padding(5);
            this.labelAlertTime.Name = "labelAlertTime";
            this.labelAlertTime.Size = new System.Drawing.Size(0, 27);
            this.labelAlertTime.TabIndex = 16;
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(95, 313);
            this.linkLabel1.Margin = new System.Windows.Forms.Padding(5);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(121, 27);
            this.linkLabel1.TabIndex = 15;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            // 
            // BlAlertsDG
            // 
            this.BlAlertsDG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BlAlertsDG.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.BlAlertsDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BlAlertsDG.Location = new System.Drawing.Point(8, 41);
            this.BlAlertsDG.Margin = new System.Windows.Forms.Padding(5);
            this.BlAlertsDG.Name = "BlAlertsDG";
            this.BlAlertsDG.ReadOnly = true;
            this.BlAlertsDG.Size = new System.Drawing.Size(511, 225);
            this.BlAlertsDG.TabIndex = 10;
            this.BlAlertsDG.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BlAlertsDG_CellClick);
            // 
            // BoxDetails
            // 
            this.BoxDetails.Controls.Add(this.label4);
            this.BoxDetails.Controls.Add(this.label3);
            this.BoxDetails.Controls.Add(this.label2);
            this.BoxDetails.Controls.Add(this.label1);
            this.BoxDetails.Controls.Add(this.labelUsername);
            this.BoxDetails.Controls.Add(this.labelIpAdress);
            this.BoxDetails.Controls.Add(this.labelHostName);
            this.BoxDetails.Controls.Add(this.labelWorkstationName);
            this.BoxDetails.Controls.Add(this.AppAlertsDG);
            this.BoxDetails.Font = new System.Drawing.Font("Lucida Sans Unicode", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BoxDetails.Location = new System.Drawing.Point(300, 3);
            this.BoxDetails.Name = "BoxDetails";
            this.BoxDetails.Size = new System.Drawing.Size(501, 633);
            this.BoxDetails.TabIndex = 16;
            this.BoxDetails.TabStop = false;
            this.BoxDetails.Text = "Szczegóły";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Lucida Sans Unicode", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label4.Location = new System.Drawing.Point(8, 587);
            this.label4.Margin = new System.Windows.Forms.Padding(5);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(189, 22);
            this.label4.TabIndex = 21;
            this.label4.Text = "Nazwa użytkownika:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Lucida Sans Unicode", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(8, 550);
            this.label3.Margin = new System.Windows.Forms.Padding(5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 22);
            this.label3.TabIndex = 20;
            this.label3.Text = "Adres IP:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Lucida Sans Unicode", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(8, 513);
            this.label2.Margin = new System.Windows.Forms.Padding(5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 22);
            this.label2.TabIndex = 19;
            this.label2.Text = "Nazwa hosta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Sans Unicode", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(8, 476);
            this.label1.Margin = new System.Windows.Forms.Padding(5);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 22);
            this.label1.TabIndex = 18;
            this.label1.Text = "Nazwa stacji roboczej:";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Font = new System.Drawing.Font("Lucida Sans Unicode", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelUsername.Location = new System.Drawing.Point(207, 587);
            this.labelUsername.Margin = new System.Windows.Forms.Padding(5);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(0, 22);
            this.labelUsername.TabIndex = 17;
            // 
            // labelIpAdress
            // 
            this.labelIpAdress.AutoSize = true;
            this.labelIpAdress.Font = new System.Drawing.Font("Lucida Sans Unicode", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelIpAdress.Location = new System.Drawing.Point(104, 550);
            this.labelIpAdress.Margin = new System.Windows.Forms.Padding(5);
            this.labelIpAdress.Name = "labelIpAdress";
            this.labelIpAdress.Size = new System.Drawing.Size(0, 22);
            this.labelIpAdress.TabIndex = 16;
            // 
            // labelHostName
            // 
            this.labelHostName.AutoSize = true;
            this.labelHostName.Font = new System.Drawing.Font("Lucida Sans Unicode", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelHostName.Location = new System.Drawing.Point(145, 513);
            this.labelHostName.Margin = new System.Windows.Forms.Padding(5);
            this.labelHostName.Name = "labelHostName";
            this.labelHostName.Size = new System.Drawing.Size(0, 22);
            this.labelHostName.TabIndex = 15;
            // 
            // labelWorkstationName
            // 
            this.labelWorkstationName.AutoSize = true;
            this.labelWorkstationName.Font = new System.Drawing.Font("Lucida Sans Unicode", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelWorkstationName.Location = new System.Drawing.Point(222, 476);
            this.labelWorkstationName.Margin = new System.Windows.Forms.Padding(5);
            this.labelWorkstationName.Name = "labelWorkstationName";
            this.labelWorkstationName.Size = new System.Drawing.Size(0, 22);
            this.labelWorkstationName.TabIndex = 14;
            // 
            // AppAlertsDG
            // 
            this.AppAlertsDG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AppAlertsDG.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.AppAlertsDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AppAlertsDG.Location = new System.Drawing.Point(8, 41);
            this.AppAlertsDG.Margin = new System.Windows.Forms.Padding(5);
            this.AppAlertsDG.Name = "AppAlertsDG";
            this.AppAlertsDG.ReadOnly = true;
            this.AppAlertsDG.Size = new System.Drawing.Size(485, 425);
            this.AppAlertsDG.TabIndex = 9;
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(8, 642);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(140, 53);
            this.Delete.TabIndex = 15;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // Refresh1
            // 
            this.Refresh1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Refresh1.Location = new System.Drawing.Point(154, 642);
            this.Refresh1.Name = "Refresh1";
            this.Refresh1.Size = new System.Drawing.Size(140, 53);
            this.Refresh1.TabIndex = 11;
            this.Refresh1.Text = "Refresh";
            this.Refresh1.UseVisualStyleBackColor = true;
            this.Refresh1.Click += new System.EventHandler(this.Refresh1_Click);
            // 
            // MainDG
            // 
            this.MainDG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MainDG.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Lucida Sans Unicode", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MainDG.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.MainDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.MainDG.DefaultCellStyle = dataGridViewCellStyle5;
            this.MainDG.Location = new System.Drawing.Point(8, 44);
            this.MainDG.Name = "MainDG";
            this.MainDG.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.MainDG.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.MainDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MainDG.Size = new System.Drawing.Size(286, 592);
            this.MainDG.TabIndex = 8;
            this.MainDG.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainDG_CellClick);
            // 
            // BlackListManagement
            // 
            this.BlackListManagement.Controls.Add(this.getBlackList);
            this.BlackListManagement.Controls.Add(this.updateButton);
            this.BlackListManagement.Controls.Add(this.blPageManagmentLabel);
            this.BlackListManagement.Controls.Add(this.blAppManagmentLabel);
            this.BlackListManagement.Controls.Add(this.blPagesManagmentGrid);
            this.BlackListManagement.Controls.Add(this.blAppsManagmentGrid);
            this.BlackListManagement.Location = new System.Drawing.Point(4, 22);
            this.BlackListManagement.Name = "BlackListManagement";
            this.BlackListManagement.Padding = new System.Windows.Forms.Padding(3);
            this.BlackListManagement.Size = new System.Drawing.Size(1342, 703);
            this.BlackListManagement.TabIndex = 1;
            this.BlackListManagement.Text = "Black lists";
            this.BlackListManagement.UseVisualStyleBackColor = true;
            // 
            // getBlackList
            // 
            this.getBlackList.Location = new System.Drawing.Point(473, 54);
            this.getBlackList.Name = "getBlackList";
            this.getBlackList.Size = new System.Drawing.Size(190, 46);
            this.getBlackList.TabIndex = 22;
            this.getBlackList.Text = "Get Data";
            this.getBlackList.UseVisualStyleBackColor = true;
            this.getBlackList.Click += new System.EventHandler(this.getBlackList_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(473, 106);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(190, 46);
            this.updateButton.TabIndex = 20;
            this.updateButton.Text = "Update";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // blPageManagmentLabel
            // 
            this.blPageManagmentLabel.AutoSize = true;
            this.blPageManagmentLabel.Location = new System.Drawing.Point(39, 331);
            this.blPageManagmentLabel.Name = "blPageManagmentLabel";
            this.blPageManagmentLabel.Size = new System.Drawing.Size(98, 13);
            this.blPageManagmentLabel.TabIndex = 18;
            this.blPageManagmentLabel.Text = "Websites black list:";
            // 
            // blAppManagmentLabel
            // 
            this.blAppManagmentLabel.AutoSize = true;
            this.blAppManagmentLabel.Location = new System.Drawing.Point(39, 38);
            this.blAppManagmentLabel.Name = "blAppManagmentLabel";
            this.blAppManagmentLabel.Size = new System.Drawing.Size(78, 13);
            this.blAppManagmentLabel.TabIndex = 17;
            this.blAppManagmentLabel.Text = "Apps black list:";
            // 
            // blPagesManagmentGrid
            // 
            this.blPagesManagmentGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.blPagesManagmentGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.blPagesManagmentGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.blPagesManagmentGrid.Location = new System.Drawing.Point(42, 347);
            this.blPagesManagmentGrid.Name = "blPagesManagmentGrid";
            this.blPagesManagmentGrid.Size = new System.Drawing.Size(425, 225);
            this.blPagesManagmentGrid.TabIndex = 16;
            // 
            // blAppsManagmentGrid
            // 
            this.blAppsManagmentGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.blAppsManagmentGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.blAppsManagmentGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.blAppsManagmentGrid.Location = new System.Drawing.Point(42, 54);
            this.blAppsManagmentGrid.Name = "blAppsManagmentGrid";
            this.blAppsManagmentGrid.Size = new System.Drawing.Size(425, 225);
            this.blAppsManagmentGrid.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1350, 729);
            this.Controls.Add(this.Tabs);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1366, 768);
            this.MinimumSize = new System.Drawing.Size(1366, 768);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "Aplikacja prowadzącego";
            this.Load += new System.EventHandler(this.DbFirstInit_Load);
            this.Tabs.ResumeLayout(false);
            this.Database.ResumeLayout(false);
            this.BoxAlerts.ResumeLayout(false);
            this.BoxAlerts.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlAlertsDG)).EndInit();
            this.BoxDetails.ResumeLayout(false);
            this.BoxDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AppAlertsDG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MainDG)).EndInit();
            this.BlackListManagement.ResumeLayout(false);
            this.BlackListManagement.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.blPagesManagmentGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blAppsManagmentGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl Tabs;
        private System.Windows.Forms.TabPage Database;
        private System.Windows.Forms.Button Delete;
        private System.Windows.Forms.Button Refresh1;
        private System.Windows.Forms.DataGridView BlAlertsDG;
        private System.Windows.Forms.DataGridView AppAlertsDG;
        private System.Windows.Forms.DataGridView MainDG;
        private System.Windows.Forms.TabPage BlackListManagement;
        private System.Windows.Forms.Label blPageManagmentLabel;
        private System.Windows.Forms.Label blAppManagmentLabel;
        private System.Windows.Forms.DataGridView blPagesManagmentGrid;
        private System.Windows.Forms.DataGridView blAppsManagmentGrid;
        private System.Windows.Forms.Button getBlackList;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.GroupBox BoxDetails;
        private System.Windows.Forms.GroupBox BoxAlerts;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelIpAdress;
        private System.Windows.Forms.Label labelHostName;
        private System.Windows.Forms.Label labelWorkstationName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelAlertTime;
        private System.Windows.Forms.LinkLabel linkLabel3;
        private System.Windows.Forms.LinkLabel linkLabel2;
    }
}


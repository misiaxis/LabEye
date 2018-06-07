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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            this.Tabs = new System.Windows.Forms.TabControl();
            this.Database = new System.Windows.Forms.TabPage();
            this.viewDesktopButton = new System.Windows.Forms.Button();
            this.BoxAlerts = new System.Windows.Forms.GroupBox();
            this.openFolderButton = new System.Windows.Forms.Button();
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
            this.Tabs.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Tabs.Location = new System.Drawing.Point(0, 0);
            this.Tabs.Name = "Tabs";
            this.Tabs.SelectedIndex = 0;
            this.Tabs.Size = new System.Drawing.Size(1350, 729);
            this.Tabs.TabIndex = 8;
            this.Tabs.EnabledChanged += new System.EventHandler(this.getBlackList_Click);
            // 
            // Database
            // 
            this.Database.Controls.Add(this.viewDesktopButton);
            this.Database.Controls.Add(this.BoxAlerts);
            this.Database.Controls.Add(this.BoxDetails);
            this.Database.Controls.Add(this.Delete);
            this.Database.Controls.Add(this.Refresh1);
            this.Database.Controls.Add(this.MainDG);
            this.Database.Location = new System.Drawing.Point(4, 29);
            this.Database.Name = "Database";
            this.Database.Padding = new System.Windows.Forms.Padding(3);
            this.Database.Size = new System.Drawing.Size(1342, 696);
            this.Database.TabIndex = 0;
            this.Database.Text = "Baza danych i powiadomienia";
            this.Database.UseVisualStyleBackColor = true;
            // 
            // viewDesktopButton
            // 
            this.viewDesktopButton.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.viewDesktopButton.Enabled = false;
            this.viewDesktopButton.Location = new System.Drawing.Point(300, 642);
            this.viewDesktopButton.Name = "viewDesktopButton";
            this.viewDesktopButton.Size = new System.Drawing.Size(140, 53);
            this.viewDesktopButton.TabIndex = 18;
            this.viewDesktopButton.Text = "Przechwytuj ekran";
            this.viewDesktopButton.UseVisualStyleBackColor = true;
            this.viewDesktopButton.Click += new System.EventHandler(this.viewDesktopButton_Click);
            // 
            // BoxAlerts
            // 
            this.BoxAlerts.Controls.Add(this.openFolderButton);
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
            // openFolderButton
            // 
            this.openFolderButton.Enabled = false;
            this.openFolderButton.Location = new System.Drawing.Point(13, 442);
            this.openFolderButton.Name = "openFolderButton";
            this.openFolderButton.Size = new System.Drawing.Size(213, 56);
            this.openFolderButton.TabIndex = 25;
            this.openFolderButton.Text = "Otwórz folder";
            this.openFolderButton.UseVisualStyleBackColor = true;
            this.openFolderButton.Click += new System.EventHandler(this.openFolderButton_Click);
            // 
            // linkLabel3
            // 
            this.linkLabel3.AutoSize = true;
            this.linkLabel3.Location = new System.Drawing.Point(95, 387);
            this.linkLabel3.Margin = new System.Windows.Forms.Padding(5);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(138, 27);
            this.linkLabel3.TabIndex = 24;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Zdjęcie nr 3";
            this.linkLabel3.Click += new System.EventHandler(this.Link3Clicked);
            // 
            // linkLabel2
            // 
            this.linkLabel2.AutoSize = true;
            this.linkLabel2.Location = new System.Drawing.Point(95, 350);
            this.linkLabel2.Margin = new System.Windows.Forms.Padding(5);
            this.linkLabel2.Name = "linkLabel2";
            this.linkLabel2.Size = new System.Drawing.Size(138, 27);
            this.linkLabel2.TabIndex = 23;
            this.linkLabel2.TabStop = true;
            this.linkLabel2.Text = "Zdjęcie nr 2";
            this.linkLabel2.Click += new System.EventHandler(this.Link2Clicked);
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
            this.linkLabel1.Size = new System.Drawing.Size(138, 27);
            this.linkLabel1.TabIndex = 15;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Zdjęcie nr 1";
            this.linkLabel1.Click += new System.EventHandler(this.Link1Clicked);
            // 
            // BlAlertsDG
            // 
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BlAlertsDG.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle21;
            this.BlAlertsDG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BlAlertsDG.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.BlAlertsDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BlAlertsDG.Location = new System.Drawing.Point(8, 41);
            this.BlAlertsDG.Margin = new System.Windows.Forms.Padding(5);
            this.BlAlertsDG.Name = "BlAlertsDG";
            this.BlAlertsDG.ReadOnly = true;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BlAlertsDG.RowsDefaultCellStyle = dataGridViewCellStyle22;
            this.BlAlertsDG.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BlAlertsDG.Size = new System.Drawing.Size(511, 225);
            this.BlAlertsDG.TabIndex = 10;
            this.BlAlertsDG.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BlAlertsDG_CellClick);
            this.BlAlertsDG.SelectionChanged += new System.EventHandler(this.BlAlertsDG_SelectionChanged);
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
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AppAlertsDG.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle25;
            this.AppAlertsDG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AppAlertsDG.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.AppAlertsDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AppAlertsDG.Location = new System.Drawing.Point(8, 41);
            this.AppAlertsDG.Margin = new System.Windows.Forms.Padding(5);
            this.AppAlertsDG.Name = "AppAlertsDG";
            this.AppAlertsDG.ReadOnly = true;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AppAlertsDG.RowsDefaultCellStyle = dataGridViewCellStyle26;
            this.AppAlertsDG.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AppAlertsDG.Size = new System.Drawing.Size(485, 425);
            this.AppAlertsDG.TabIndex = 9;
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(8, 642);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(140, 53);
            this.Delete.TabIndex = 15;
            this.Delete.Text = "Usuń";
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
            this.Refresh1.Text = "Odśwież";
            this.Refresh1.UseVisualStyleBackColor = true;
            this.Refresh1.Click += new System.EventHandler(this.Refresh1_Click);
            // 
            // MainDG
            // 
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MainDG.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle23;
            this.MainDG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MainDG.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.MainDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainDG.Location = new System.Drawing.Point(8, 44);
            this.MainDG.Name = "MainDG";
            this.MainDG.ReadOnly = true;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MainDG.RowsDefaultCellStyle = dataGridViewCellStyle24;
            this.MainDG.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MainDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MainDG.Size = new System.Drawing.Size(286, 592);
            this.MainDG.TabIndex = 8;
            this.MainDG.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.MainDG_CellClick);
            this.MainDG.SelectionChanged += new System.EventHandler(this.MainDG_SelectionChanged);
            // 
            // BlackListManagement
            // 
            this.BlackListManagement.Controls.Add(this.getBlackList);
            this.BlackListManagement.Controls.Add(this.updateButton);
            this.BlackListManagement.Controls.Add(this.blPageManagmentLabel);
            this.BlackListManagement.Controls.Add(this.blAppManagmentLabel);
            this.BlackListManagement.Controls.Add(this.blPagesManagmentGrid);
            this.BlackListManagement.Controls.Add(this.blAppsManagmentGrid);
            this.BlackListManagement.Location = new System.Drawing.Point(4, 29);
            this.BlackListManagement.Name = "BlackListManagement";
            this.BlackListManagement.Padding = new System.Windows.Forms.Padding(3);
            this.BlackListManagement.Size = new System.Drawing.Size(1342, 696);
            this.BlackListManagement.TabIndex = 1;
            this.BlackListManagement.Text = "Czarne listy";
            this.BlackListManagement.UseVisualStyleBackColor = true;
            // 
            // getBlackList
            // 
            this.getBlackList.Location = new System.Drawing.Point(5, 647);
            this.getBlackList.Margin = new System.Windows.Forms.Padding(5);
            this.getBlackList.Name = "getBlackList";
            this.getBlackList.Size = new System.Drawing.Size(190, 46);
            this.getBlackList.TabIndex = 22;
            this.getBlackList.Text = "Get Data";
            this.getBlackList.UseVisualStyleBackColor = true;
            this.getBlackList.Click += new System.EventHandler(this.getBlackList_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(205, 647);
            this.updateButton.Margin = new System.Windows.Forms.Padding(5);
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
            this.blPageManagmentLabel.Location = new System.Drawing.Point(653, 8);
            this.blPageManagmentLabel.Margin = new System.Windows.Forms.Padding(5);
            this.blPageManagmentLabel.Name = "blPageManagmentLabel";
            this.blPageManagmentLabel.Size = new System.Drawing.Size(271, 20);
            this.blPageManagmentLabel.TabIndex = 18;
            this.blPageManagmentLabel.Text = "Czarna lista stron internetowych:";
            // 
            // blAppManagmentLabel
            // 
            this.blAppManagmentLabel.AutoSize = true;
            this.blAppManagmentLabel.Location = new System.Drawing.Point(10, 8);
            this.blAppManagmentLabel.Margin = new System.Windows.Forms.Padding(5);
            this.blAppManagmentLabel.Name = "blAppManagmentLabel";
            this.blAppManagmentLabel.Size = new System.Drawing.Size(177, 20);
            this.blAppManagmentLabel.TabIndex = 17;
            this.blAppManagmentLabel.Text = "Czarna lista aplikacji:";
            // 
            // blPagesManagmentGrid
            // 
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.blPagesManagmentGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle27;
            this.blPagesManagmentGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.blPagesManagmentGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.blPagesManagmentGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.blPagesManagmentGrid.Location = new System.Drawing.Point(656, 31);
            this.blPagesManagmentGrid.Margin = new System.Windows.Forms.Padding(5);
            this.blPagesManagmentGrid.Name = "blPagesManagmentGrid";
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.blPagesManagmentGrid.RowsDefaultCellStyle = dataGridViewCellStyle28;
            this.blPagesManagmentGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.blPagesManagmentGrid.Size = new System.Drawing.Size(676, 606);
            this.blPagesManagmentGrid.TabIndex = 16;
            // 
            // blAppsManagmentGrid
            // 
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.blAppsManagmentGrid.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle29;
            this.blAppsManagmentGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.blAppsManagmentGrid.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.blAppsManagmentGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.blAppsManagmentGrid.Location = new System.Drawing.Point(10, 31);
            this.blAppsManagmentGrid.Margin = new System.Windows.Forms.Padding(5);
            this.blAppsManagmentGrid.Name = "blAppsManagmentGrid";
            dataGridViewCellStyle30.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.blAppsManagmentGrid.RowsDefaultCellStyle = dataGridViewCellStyle30;
            this.blAppsManagmentGrid.RowTemplate.DefaultCellStyle.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.blAppsManagmentGrid.Size = new System.Drawing.Size(627, 606);
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
        private System.Windows.Forms.Button openFolderButton;
        private System.Windows.Forms.Button viewDesktopButton;
    }
}


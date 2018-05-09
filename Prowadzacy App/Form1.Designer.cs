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
            this.Tabs = new System.Windows.Forms.TabControl();
            this.Database = new System.Windows.Forms.TabPage();
            this.Delete = new System.Windows.Forms.Button();
            this.blAlertsLabel = new System.Windows.Forms.Label();
            this.applAlertsLabel = new System.Windows.Forms.Label();
            this.mainDBLabel = new System.Windows.Forms.Label();
            this.Refresh1 = new System.Windows.Forms.Button();
            this.BlAlertsDG = new System.Windows.Forms.DataGridView();
            this.AppAlertsDG = new System.Windows.Forms.DataGridView();
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
            ((System.ComponentModel.ISupportInitialize)(this.BlAlertsDG)).BeginInit();
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
            this.Tabs.Size = new System.Drawing.Size(1032, 612);
            this.Tabs.TabIndex = 8;
            this.Tabs.EnabledChanged += new System.EventHandler(this.getBlackList_Click);
            // 
            // Database
            // 
            this.Database.Controls.Add(this.Delete);
            this.Database.Controls.Add(this.blAlertsLabel);
            this.Database.Controls.Add(this.applAlertsLabel);
            this.Database.Controls.Add(this.mainDBLabel);
            this.Database.Controls.Add(this.Refresh1);
            this.Database.Controls.Add(this.BlAlertsDG);
            this.Database.Controls.Add(this.AppAlertsDG);
            this.Database.Controls.Add(this.MainDG);
            this.Database.Location = new System.Drawing.Point(4, 22);
            this.Database.Name = "Database";
            this.Database.Padding = new System.Windows.Forms.Padding(3);
            this.Database.Size = new System.Drawing.Size(1024, 586);
            this.Database.TabIndex = 0;
            this.Database.Text = "Database";
            this.Database.UseVisualStyleBackColor = true;
            // 
            // Delete
            // 
            this.Delete.Location = new System.Drawing.Point(876, 103);
            this.Delete.Name = "Delete";
            this.Delete.Size = new System.Drawing.Size(140, 53);
            this.Delete.TabIndex = 15;
            this.Delete.Text = "Delete";
            this.Delete.UseVisualStyleBackColor = true;
            this.Delete.Click += new System.EventHandler(this.Delete_Click);
            // 
            // blAlertsLabel
            // 
            this.blAlertsLabel.AutoSize = true;
            this.blAlertsLabel.Location = new System.Drawing.Point(442, 309);
            this.blAlertsLabel.Name = "blAlertsLabel";
            this.blAlertsLabel.Size = new System.Drawing.Size(85, 13);
            this.blAlertsLabel.TabIndex = 14;
            this.blAlertsLabel.Text = "Websites alerts :";
            // 
            // applAlertsLabel
            // 
            this.applAlertsLabel.AutoSize = true;
            this.applAlertsLabel.Location = new System.Drawing.Point(8, 309);
            this.applAlertsLabel.Name = "applAlertsLabel";
            this.applAlertsLabel.Size = new System.Drawing.Size(93, 13);
            this.applAlertsLabel.TabIndex = 13;
            this.applAlertsLabel.Text = "Application alerts :";
            // 
            // mainDBLabel
            // 
            this.mainDBLabel.AutoSize = true;
            this.mainDBLabel.Location = new System.Drawing.Point(8, 5);
            this.mainDBLabel.Name = "mainDBLabel";
            this.mainDBLabel.Size = new System.Drawing.Size(131, 13);
            this.mainDBLabel.TabIndex = 12;
            this.mainDBLabel.Text = "Main database collection :";
            // 
            // Refresh1
            // 
            this.Refresh1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Refresh1.Location = new System.Drawing.Point(876, 24);
            this.Refresh1.Name = "Refresh1";
            this.Refresh1.Size = new System.Drawing.Size(140, 53);
            this.Refresh1.TabIndex = 11;
            this.Refresh1.Text = "Refresh";
            this.Refresh1.UseVisualStyleBackColor = true;
            this.Refresh1.Click += new System.EventHandler(this.Refresh1_Click);
            // 
            // BlAlertsDG
            // 
            this.BlAlertsDG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BlAlertsDG.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.BlAlertsDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.BlAlertsDG.Location = new System.Drawing.Point(445, 325);
            this.BlAlertsDG.Name = "BlAlertsDG";
            this.BlAlertsDG.ReadOnly = true;
            this.BlAlertsDG.Size = new System.Drawing.Size(425, 225);
            this.BlAlertsDG.TabIndex = 10;
            // 
            // AppAlertsDG
            // 
            this.AppAlertsDG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.AppAlertsDG.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.AppAlertsDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.AppAlertsDG.Location = new System.Drawing.Point(11, 325);
            this.AppAlertsDG.Name = "AppAlertsDG";
            this.AppAlertsDG.ReadOnly = true;
            this.AppAlertsDG.Size = new System.Drawing.Size(425, 225);
            this.AppAlertsDG.TabIndex = 9;
            // 
            // MainDG
            // 
            this.MainDG.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.MainDG.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.MainDG.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.MainDG.Location = new System.Drawing.Point(11, 24);
            this.MainDG.Name = "MainDG";
            this.MainDG.ReadOnly = true;
            this.MainDG.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.MainDG.Size = new System.Drawing.Size(859, 262);
            this.MainDG.TabIndex = 8;
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
            this.BlackListManagement.Size = new System.Drawing.Size(1024, 586);
            this.BlackListManagement.TabIndex = 1;
            this.BlackListManagement.Text = "Black lists";
            this.BlackListManagement.UseVisualStyleBackColor = true;
            // 
            // getBlackList
            // 
            this.getBlackList.Location = new System.Drawing.Point(377, 285);
            this.getBlackList.Name = "getBlackList";
            this.getBlackList.Size = new System.Drawing.Size(190, 46);
            this.getBlackList.TabIndex = 22;
            this.getBlackList.Text = "Get Data";
            this.getBlackList.UseVisualStyleBackColor = true;
            this.getBlackList.Click += new System.EventHandler(this.getBlackList_Click);
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(377, 337);
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
            this.blPageManagmentLabel.Location = new System.Drawing.Point(473, 38);
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
            this.blPagesManagmentGrid.Location = new System.Drawing.Point(476, 54);
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
            this.ClientSize = new System.Drawing.Size(1032, 612);
            this.Controls.Add(this.Tabs);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.DbFirstInit_Load);
            this.Tabs.ResumeLayout(false);
            this.Database.ResumeLayout(false);
            this.Database.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BlAlertsDG)).EndInit();
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
        private System.Windows.Forms.Label blAlertsLabel;
        private System.Windows.Forms.Label applAlertsLabel;
        private System.Windows.Forms.Label mainDBLabel;
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
    }
}


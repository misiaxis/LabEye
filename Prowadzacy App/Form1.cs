using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;

namespace Prowadzacy_App
{
    public partial class Form1 : Form
    {
        private DbManager manager;
        // Main DB management
        private DataTable dtMain;
        private DataTable applAlerts;
        private DataTable blAlerts;
        private BindingSource masterBindingSource = new BindingSource();
        private BindingSource appDetailsBindingSource = new BindingSource();
        private BindingSource blDetailsBindingSource = new BindingSource();
        // Black list management
        private BindingSource appBLBindingSource = new BindingSource();
        private BindingSource sitesBLBindingSource = new BindingSource();
        private DataTable blSitesManagmentTable;
        private DataTable blAppsManagmentTable;
        bool doItDetail = true;
        bool doItAlerts = true;
        string img1path;
        string img2path;
        string img3path;
        string folderpath;
        string ipConnectionPoint;
        public Form1()
        {
            InitializeComponent();
            manager = new DbManager();
        }
        private void Refresh1_Click(object sender, EventArgs e)
        {
            GetMainData();
        }
        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MainDG.SelectedRows.Count < 1)
                    throw new Exception();
                else
                {
                        int index = MainDG.SelectedCells[0].RowIndex;
                        DataGridViewRow selectedRow = MainDG.Rows[index];
                        manager.DeleteOne("StudentFirstAndLastName", selectedRow.Cells[0].Value.ToString(), 0);
                }
                GetMainData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select ONE row in Main database collection.");
            }
        }
        private void DbFirstInit_Load(object sender, EventArgs e)
        {
            GetMainData();
            PopulateDetailsLabels();
            GetBLData();
            PopulateAlertLabels();
        }
        private void getBlackList_Click(object sender, EventArgs e)
        {
            GetBLData();
        }
        private void updateButton_Click(object sender, EventArgs e)
        {

            List<string> tempAppBlackList = new List<string>();
            for (int rows = 1; rows < blAppsManagmentGrid.Rows.Count; rows++)
            {
                if (blAppsManagmentGrid.Rows[rows - 1].Cells[0].Value.ToString() == "") { }
                else tempAppBlackList.Add(blAppsManagmentGrid.Rows[rows - 1].Cells[0].Value.ToString());
            }


            List<string> tempSitesBlackList = new List<string>();
            for (int rows = 1; rows < blPagesManagmentGrid.Rows.Count; rows++)
            {
                if (blPagesManagmentGrid.Rows[rows - 1].Cells[0].Value.ToString() == "") { }
                else tempSitesBlackList.Add(blPagesManagmentGrid.Rows[rows - 1].Cells[0].Value.ToString());
            }
            if (manager.CheckIfExsistsBlackList() == true)
            {
                manager.UpdateOneBlackList(tempSitesBlackList, "Websites");
                manager.UpdateOneBlackList(tempAppBlackList, "Apps");
            }
            else
            {
                manager.BlackListsMakeNew(tempSitesBlackList, tempAppBlackList);
            }
            GetBLData();
        }
        private void GetBLData()
        {
            List<BlackList> list = new List<BlackList>();
            list = manager.ShowBlackListCollection();

            blPagesManagmentGrid.Columns.Clear();
            blAppsManagmentGrid.Columns.Clear();

            blAppsManagmentGrid.DataSource = appBLBindingSource;
            blPagesManagmentGrid.DataSource = sitesBLBindingSource;

            //Child table  
            blAppsManagmentTable = new DataTable("Apps black list manager");
            blAppsManagmentTable.Columns.Add("Niedozwolone aplikacje", typeof(string));

            //Child table  
            blSitesManagmentTable = new DataTable("Sites black list manager");
            blSitesManagmentTable.Columns.Add("Niedozwolone strony internetowe", typeof(string));

            foreach (BlackList bl in list)
            {
                foreach (string s in bl.Apps)
                {
                    blAppsManagmentTable.Rows.Add(s);
                }
                foreach (string s in bl.Websites)
                {
                    blSitesManagmentTable.Rows.Add(s);
                }
            }
            DataSet dsDataset2 = new DataSet();
            DataSet dsDataset3 = new DataSet();
            dsDataset2.Tables.Add(blAppsManagmentTable);
            dsDataset3.Tables.Add(blSitesManagmentTable);

            // Binding master data to Main grid
            appBLBindingSource.DataSource = dsDataset2;
            appBLBindingSource.DataMember = "Apps black list manager";

            sitesBLBindingSource.DataSource = dsDataset3;
            sitesBLBindingSource.DataMember = "Sites black list manager";

            blAppsManagmentGrid.AutoResizeColumns();
            blPagesManagmentGrid.AutoResizeColumns();
        }
        private void GetMainData()
        {
            try
            {
                MainDG.Columns.Clear();
                BlAlertsDG.Columns.Clear();
                AppAlertsDG.Columns.Clear();

                MainDG.DataSource = masterBindingSource;
                AppAlertsDG.DataSource = appDetailsBindingSource;
                BlAlertsDG.DataSource = blDetailsBindingSource;
                //Parent table  
                dtMain = new DataTable("Main");
                // add columns to datatable  
                dtMain.Columns.Add("Imię i nazwisko", typeof(string));
                dtMain.Columns.Add("ID", typeof(ObjectId));
                //Child table  
                applAlerts = new DataTable("Apps");
                applAlerts.Columns.Add("Uruchomione procesy", typeof(string));
                applAlerts.Columns.Add("ID", typeof(ObjectId));
                //Child table  
                blAlerts = new DataTable("Powiadomienia");
                blAlerts.Columns.Add("Powiadomienia", typeof(string));
                blAlerts.Columns.Add("ID", typeof(ObjectId));

                List<Workstations> list = new List<Workstations>();
                list = manager.ShowWorkstationsCollection();

                foreach (Workstations w in list)
                {
                    dtMain.Rows.Add(w.StudentFirstAndLastName, w._id);
                    foreach (string s in w.Apps)
                    {
                        applAlerts.Rows.Add(s, w._id);
                    }
                    foreach (var o in w.Alerts)
                    {
                        blAlerts.Rows.Add(o.AlertName, w._id);
                    }
                }
                
                DataSet dsDataset = new DataSet();
                dsDataset.Tables.Add(dtMain);
                dsDataset.Tables.Add(applAlerts);
                dsDataset.Tables.Add(blAlerts);
                // Relationships between Main table and app alerts list
                DataRelation relationApps = new DataRelation("MainApps",
                        dsDataset.Tables[0].Columns[1],
                        dsDataset.Tables[1].Columns[1]);
                dsDataset.Relations.Add(relationApps);
                // Binding master data to Main grid
                masterBindingSource.DataSource = dsDataset;
                masterBindingSource.DataMember = "Main";
                //Binding detailed data to master with created relation
                appDetailsBindingSource.DataSource = masterBindingSource;
                appDetailsBindingSource.DataMember = "MainApps";
                // Relationships between Main table and internet pages alerts 
                DataRelation relationAlerts = new DataRelation("MainAlerts",
                       dsDataset.Tables[0].Columns[1],
                       dsDataset.Tables[2].Columns[1]);
                dsDataset.Relations.Add(relationAlerts);
                //Binding detailed data with created relation
                blDetailsBindingSource.DataSource = masterBindingSource;
                blDetailsBindingSource.DataMember = "MainAlerts";
                
                MainDG.Columns[1].Visible = false;
                BlAlertsDG.Columns[1].Visible = false;
                AppAlertsDG.Columns[1].Visible = false;
                // Auto resize
                MainDG.AutoResizeColumns();
                AppAlertsDG.AutoResizeColumns();
                BlAlertsDG.AutoResizeColumns();
            }
            catch (Exception ex)
            {
                MessageBox.Show("" + ex);
            }
        }

        private void MainDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PopulateDetailsLabels();              
        }
        private void PopulateDetailsLabels()
        {
            var documents = manager.ShowWorkstationsCollection();
            DataGridViewRow selectedMainRow;
            foreach (var d in documents)
            {
                try
                {
                    if (MainDG.SelectedRows.Count < 1)
                        throw new Exception();
                    else
                    {
                        int index = MainDG.SelectedCells[0].RowIndex;
                        selectedMainRow = MainDG.Rows[index];
                    }
                    if (doItDetail == true)
                    {
                        if (selectedMainRow.Cells[0].Value.ToString() == d.StudentFirstAndLastName)
                        {
                            labelWorkstationName.Text = d.WorkstationName;
                            labelIpAdress.Text = d.IPAdress;
                            labelUsername.Text = d.UserName;
                            labelHostName.Text = d.HostName;
                            ipConnectionPoint = d.IPAdress;
                            viewDesktopButton.Enabled = true;
                            doItDetail = false;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Zaznacz jednego studenta.");
                }
            }
        }
        private void BlAlertsDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PopulateAlertLabels();
        }
        private void PopulateAlertLabels()
        {
            var documents = manager.ShowWorkstationsCollection();
            DataGridViewRow selectedMainRow;
            DataGridViewRow selectedAlertsRow;
            try
            {
                foreach (var d in documents)
                {
                    int index = MainDG.SelectedCells[0].RowIndex;
                    selectedMainRow = MainDG.Rows[index];

                    int indexAlerts = BlAlertsDG.SelectedCells[0].RowIndex;
                    selectedAlertsRow = BlAlertsDG.Rows[indexAlerts];

                    if (selectedMainRow.Cells[0].Value.ToString() == d.StudentFirstAndLastName)
                    {
                        foreach (var f in d.Alerts)
                        {
                            if (doItAlerts == true)
                            {
                                if (selectedAlertsRow.Cells[0].Value.ToString() == f.AlertName)
                                {
                                    labelAlertTime.Text = f.AddDate;
                                    img1path = manager.DownloadImage(f, f.Link1, 1);
                                    img2path = manager.DownloadImage(f, f.Link2, 2);
                                    img3path = manager.DownloadImage(f, f.Link3, 3);
                                    folderpath = f.StudentFirstAndLastName;
                                    openFolderButton.Enabled = true;
                                    doItAlerts = false;
                                }
                            }
                        }   
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd podczas wyświetlania informacji o alercie. Treść błędu : \n " + ex);
            }
        }
        private void Link1Clicked(object senderLinkClicked, EventArgs eLinkCLicked)
        {
            Process.Start(img1path);
        }
        private void Link2Clicked(object senderLinkClicked, EventArgs eLinkCLicked)
        {
            Process.Start(img2path);
        }
        private void Link3Clicked(object senderLinkClicked, EventArgs eLinkCLicked)
        {
            Process.Start(img3path);
        }
        private void openFolderButton_Click(object senderFolder, EventArgs eFolder)
        {
            Process.Start(folderpath);
        }
        private void viewDesktopButton_Click(object senderDesktop, EventArgs eDesktop)
        {
            var screenviewwindow = new ScreenViewer(ipConnectionPoint, 6700);
            screenviewwindow.Show();
        }

        private void MainDG_SelectionChanged(object sender, EventArgs e)
        {
            doItDetail = true;
        }

        private void BlAlertsDG_SelectionChanged(object sender, EventArgs e)
        {
            doItAlerts = true;
        }
    }
}

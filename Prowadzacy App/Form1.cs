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
        /// <summary>
        /// Main function
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            manager = new DbManager();
        }
        /// <summary>
        /// Refreshes Main Data grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Refresh1_Click(object sender, EventArgs e)
        {
            GetMainData();
        }
        /// <summary>
        /// Deletes selected student in a grid and removes him/her from database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Delete_Click(object sender, EventArgs e)
        {
            try
            {
                //If selected rows are smaller than 1 then...
                if (MainDG.SelectedRows.Count < 1)
                    throw new Exception();
                //Otherwise...
                else
                {
                        int index = MainDG.SelectedCells[1].RowIndex;
                        DataGridViewRow selectedRow = MainDG.Rows[index];
                    //Delete selected student
                        manager.DeleteOne("_id", selectedRow.Cells[1].Value.ToString(), 0);
                    
                }
                GetMainData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select ONE row in Main database collection.");
            }
        }
        /// <summary>
        /// Event that is called on first load of application used to populating grids and labels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DbFirstInit_Load(object sender, EventArgs e)
        {
            GetMainData();
            PopulateDetailsLabels();
            GetBLData();
            PopulateAlertLabels();
        }
        /// <summary>
        /// Event handling populating black list grids
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void getBlackList_Click(object sender, EventArgs e)
        {
            GetBLData();
        }
        /// <summary>
        /// Event handling updating black lists in database
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void updateButton_Click(object sender, EventArgs e)
        {
            List<string> tempAppBlackList = new List<string>();
            //For every row in application black list grid...
            for (int rows = 1; rows < blAppsManagmentGrid.Rows.Count; rows++)
            {
                //Get value from row in application black list
                if (!(blAppsManagmentGrid.Rows[rows - 1].Cells[0].Value.ToString() == ""))
                    tempAppBlackList.Add(blAppsManagmentGrid.Rows[rows - 1].Cells[0].Value.ToString());
            }

            List<string> tempSitesBlackList = new List<string>();
            //For every row in websites black list grid...
            for (int rows = 1; rows < blPagesManagmentGrid.Rows.Count; rows++)
            {
                //Get value from row in Websites black list
                if (!(blPagesManagmentGrid.Rows[rows - 1].Cells[0].Value.ToString() == ""))
                    tempSitesBlackList.Add(blPagesManagmentGrid.Rows[rows - 1].Cells[0].Value.ToString());
            }
            //If there is a collection in database containing black lists then...
            if (manager.CheckIfExsistsBlackList() == true)
            {
                //update websites black list and...
                manager.UpdateOneBlackList(tempSitesBlackList, "Websites");
                //update application black list
                manager.UpdateOneBlackList(tempAppBlackList, "Apps");
            }
            //Otherwise...
            else
            {
                //Make new collection with generated black lists
                manager.BlackListsMakeNew(tempSitesBlackList, tempAppBlackList);
            }
            GetBLData();
        }
        /// <summary>
        /// A function used to populate black list grids with data downloaded from a database
        /// </summary>
        private void GetBLData()
        {
            List<BlackList> list = new List<BlackList>();
            //Download collection
            list = manager.ShowBlackListCollection();
            //Clear websites grid's columns
            blPagesManagmentGrid.Columns.Clear();
            //Clear application grid's columns
            blAppsManagmentGrid.Columns.Clear();
            //Bind data source do app black list grid
            blAppsManagmentGrid.DataSource = appBLBindingSource;
            //Bind data source do websites black list grid
            blPagesManagmentGrid.DataSource = sitesBLBindingSource;
            //Create app black list table 
            blAppsManagmentTable = new DataTable("Apps black list manager");
            blAppsManagmentTable.Columns.Add("Niedozwolone aplikacje", typeof(string));
            //Create websites black list table  
            blSitesManagmentTable = new DataTable("Sites black list manager");
            blSitesManagmentTable.Columns.Add("Niedozwolone strony internetowe", typeof(string));
            //For each black list in black list collection..
            foreach (BlackList bl in list)
            {
                //and for each keyword in apps black list...
                foreach (string s in bl.Apps)
                {
                    // create new row containng this keyword
                    blAppsManagmentTable.Rows.Add(s);
                }
                //and for each keyword in websites black list...
                foreach (string s in bl.Websites)
                {
                    //create new row contating this keyword
                    blSitesManagmentTable.Rows.Add(s);
                }
            }
            DataSet dsDataset2 = new DataSet();
            DataSet dsDataset3 = new DataSet();
            //Create datasets to make Tables 
            dsDataset2.Tables.Add(blAppsManagmentTable);
            dsDataset3.Tables.Add(blSitesManagmentTable);
            //Binding data to app grid source
            appBLBindingSource.DataSource = dsDataset2;
            appBLBindingSource.DataMember = "Apps black list manager";
            //Binding data to websites grid source
            sitesBLBindingSource.DataSource = dsDataset3;
            sitesBLBindingSource.DataMember = "Sites black list manager";
            //Set both grid's columns to auto resize
            blAppsManagmentGrid.AutoResizeColumns();
            blPagesManagmentGrid.AutoResizeColumns();
        }
        /// <summary>
        /// Used to populate main data base grid
        /// </summary>
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
        /// <summary>
        /// Event handling populating Detail labels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PopulateDetailsLabels();              
        }
        /// <summary>
        /// A function used to populate details labels
        /// </summary>
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
        /// <summary>
        /// Event handling populating Alert labels
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BlAlertsDG_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            PopulateAlertLabels();
        }
        /// <summary>
        /// A function used to populate alert labels
        /// </summary>
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
        /// <summary>
        /// Event hanling opening a photo from linklabel1
        /// </summary>
        /// <param name="senderLinkClicked"></param>
        /// <param name="eLinkCLicked"></param>
        private void Link1Clicked(object senderLinkClicked, EventArgs eLinkCLicked)
        {
            Process.Start(img1path);
        }
        /// <summary>
        /// Event hanling opening a photo from linklabel2
        /// </summary>
        /// <param name="senderLinkClicked"></param>
        /// <param name="eLinkCLicked"></param>
        private void Link2Clicked(object senderLinkClicked, EventArgs eLinkCLicked)
        {
            Process.Start(img2path);
        }
        /// <summary>
        /// Event hanling opening a photo from linklabel3
        /// </summary>
        /// <param name="senderLinkClicked"></param>
        /// <param name="eLinkCLicked"></param>
        private void Link3Clicked(object senderLinkClicked, EventArgs eLinkCLicked)
        {
            Process.Start(img3path);
        }
        /// <summary>
        /// Event hanling opening a folder with alert logs
        /// </summary>
        /// <param name="senderFolder"></param>
        /// <param name="eFolder"></param>
        private void openFolderButton_Click(object senderFolder, EventArgs eFolder)
        {
            Process.Start(folderpath);
        }
        /// <summary>
        /// Event handling opening new ScreenViewer
        /// </summary>
        /// <param name="senderDesktop"></param>
        /// <param name="eDesktop"></param>
        private void viewDesktopButton_Click(object senderDesktop, EventArgs eDesktop)
        {
            var screenviewwindow = new ScreenViewer(ipConnectionPoint, 6700);
            screenviewwindow.Show();
        }
        /// <summary>
        /// Helper event which occurs everytime selection in main grid is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainDG_SelectionChanged(object sender, EventArgs e)
        {
            doItDetail = true;
        }
        /// <summary>
        /// Helper event which occurs everytime selection in main grid is changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BlAlertsDG_SelectionChanged(object sender, EventArgs e)
        {
            doItAlerts = true;
        }
    }
}

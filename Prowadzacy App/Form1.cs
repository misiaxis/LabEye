using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Data;
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

        public Form1()
        {
            InitializeComponent();
            manager = new DbManager();
        }
        private void Refresh1_Click(object sender, EventArgs e) /// Refreshes Workstations collection
        {
            GetMainData();
        }
        private void Delete_Click(object sender, EventArgs e) /// Deletes document form Workstations collection using selected row
        {
            try
            {
                if (MainDG.SelectedRows.Count != 1)
                    throw new Exception();
                int index = MainDG.SelectedCells[0].RowIndex;
                DataGridViewRow selectedRow = MainDG.Rows[index];
                manager.DeleteOne("WorkstationName", selectedRow.Cells[index].Value.ToString(), 0);
                GetMainData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Please select ONE row in Main database collection.");
            }
        }
        private void DbFirstInit_Load(object sender, EventArgs e) /// Executes on every application startup
        {
            GetMainData();
            GetBLData();
        }
        private void getBlackList_Click(object sender, EventArgs e) /// Gets black list into grids
        {
            GetBLData();
        }
        private void updateButton_Click(object sender, EventArgs e) /// Updates black lists
        {
            List<string> tempAppBlackList = new List<string>();
            for (int rows = 1; rows < blAppsManagmentGrid.Rows.Count; rows++)
            {
                if (blAppsManagmentGrid.Rows[rows - 1].Cells[0].Value.ToString() == "") { } 
                else tempAppBlackList.Add(blAppsManagmentGrid.Rows[rows - 1].Cells[0].Value.ToString());
            }
            manager.UpdateOneBlackList(tempAppBlackList, "Apps");

            List<string> tempSitesBlackList = new List<string>();
            for (int rows = 1; rows < blPagesManagmentGrid.Rows.Count; rows++)
            {
                if (blPagesManagmentGrid.Rows[rows - 1].Cells[0].Value.ToString() == "") { }
                else tempSitesBlackList.Add(blPagesManagmentGrid.Rows[rows - 1].Cells[0].Value.ToString());
            }
            manager.UpdateOneBlackList(tempSitesBlackList, "Alerts");
            GetBLData();
        }
        private void GetBLData() /// Black lists into grids creator
        {
            blPagesManagmentGrid.Columns.Clear();
            blAppsManagmentGrid.Columns.Clear();

            blAppsManagmentGrid.DataSource = appBLBindingSource;
            blPagesManagmentGrid.DataSource = sitesBLBindingSource;

            //Child table  
            blAppsManagmentTable = new DataTable("Apps black list manager");
            blAppsManagmentTable.Columns.Add("Forbiden apps", typeof(string));

            //Child table  
            blSitesManagmentTable = new DataTable("Sites black list manager");
            blSitesManagmentTable.Columns.Add("Forbiden sites", typeof(string));

            List<BlackList> list = new List<BlackList>();
            list = manager.ShowBlackListCollection();

            foreach (BlackList bl in list)
            {
                foreach (string s in bl.Apps)
                {
                    blAppsManagmentTable.Rows.Add(s);
                }
                foreach (string s in bl.Alerts)
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
        private void GetMainData() /// Workstations into grids creator
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
                dtMain.Columns.Add("Workstation name", typeof(string));
                dtMain.Columns.Add("First name and last name", typeof(string));
                dtMain.Columns.Add("Host name", typeof(string));
                dtMain.Columns.Add("IP adress", typeof(string));
                dtMain.Columns.Add("Username", typeof(string));
                dtMain.Columns.Add("ID", typeof(ObjectId));

                //Child table  
                applAlerts = new DataTable("Apps");
                applAlerts.Columns.Add("Workstation name", typeof(string));
                applAlerts.Columns.Add("App alerts", typeof(string));
                applAlerts.Columns.Add("ID", typeof(ObjectId));

                //Child table  
                blAlerts = new DataTable("Alerts");
                blAlerts.Columns.Add("Workstation name", typeof(string));
                blAlerts.Columns.Add("Black list alerts", typeof(string));
                blAlerts.Columns.Add("ID", typeof(ObjectId));

                List<Workstations> list = new List<Workstations>();
                list = manager.ShowWorkstationsCollection();

                foreach (Workstations w in list)
                {
                    dtMain.Rows.Add(w.WorkstationName, w.StudentFirstAndLastName, w.HostName, w.IPAdress, w.UserName, w._id);

                    foreach (string s in w.Apps)
                    {
                        applAlerts.Rows.Add(w.WorkstationName, s, w._id);
                    }
                    foreach (string s in w.Alerts)
                    {
                        blAlerts.Rows.Add(w.WorkstationName, s, w._id);
                    }
                }
                DataSet dsDataset = new DataSet();
                dsDataset.Tables.Add(dtMain);
                dsDataset.Tables.Add(applAlerts);
                dsDataset.Tables.Add(blAlerts);

                // Relationships between Main table and app alerts list
                DataRelation relationApps = new DataRelation("MainApps",
                        dsDataset.Tables[0].Columns[5],
                        dsDataset.Tables[1].Columns[2]);
                dsDataset.Relations.Add(relationApps);

                // Binding master data to Main grid
                masterBindingSource.DataSource = dsDataset;
                masterBindingSource.DataMember = "Main";
                //Binding detailed data to master with created relation
                appDetailsBindingSource.DataSource = masterBindingSource;
                appDetailsBindingSource.DataMember = "MainApps";

                // Relationships between Main table and internet pages alerts 
                DataRelation relationAlerts = new DataRelation("MainAlerts",
                       dsDataset.Tables[0].Columns[5],
                       dsDataset.Tables[2].Columns[2]);
                dsDataset.Relations.Add(relationAlerts);
                //Binding detailed data with created relation
                blDetailsBindingSource.DataSource = masterBindingSource;
                blDetailsBindingSource.DataMember = "MainAlerts";

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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace Agent
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        private NotifyIcon trayIcon;
        private ContextMenu contextMenu;
        private MenuItem menuItemSettings;
        private MenuItem menuItemClose;
        private MenuItem menuItemLogout;
        public MenuItem menuItemLock;
        public MenuItem menuItemStatus;

        /// <summary>
        /// Empty constructor of main class.
        /// </summary>
        public Welcome()
        {
            InitializeComponent();
            BeforeAgentStart();
            HideToTray();
            StartWorkingBackground();
        }

        /// <summary>
        /// Trying to read configuration file.
        /// </summary>
        private void ReadConfigurationFile()
        {
            using (StreamReader sw = new StreamReader(StationInformation.ConfigurationFilePath))
            {
                sw.ReadLine();
                StationInformation.WorkstationName = sw.ReadLine();
            }
        }

        /// <summary>
        /// Checking user configuration before agent start.
        /// </summary>
        private void BeforeAgentStart()
        {
            Window window;
            //If configuration file does not exist settings window will show up first
            if (File.Exists(StationInformation.ConfigurationFilePath) == false)
            {
                window = new SettingsWindow();
                window.ShowDialog();
            }
            // else sign in window will show up
            else
            {
                ReadConfigurationFile();
                if (!CheckIfDomainUser())
                {
                    window = new SignInWindow();
                    window.ShowDialog();
                }
            }
        }

        /// <summary>
        /// Delete previous user history of Alerts and Apps. Send Alerts to AlertsHistory.
        /// </summary>
        private void DeletePreviousHistory()
        {
            try
            {
                DbManager manager = new DbManager();
                var previousalerts = manager.GetWorkstationAlertList();
                foreach (var alert in previousalerts)
                    manager.AlertHistoryMakeNew(alert);
                manager.ClearAlertsList();
                manager.ClearAppList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystapił błąd podczas usuwania starych danych. Treść błędu: " + ex);
            }
        }

        /// <summary>
        /// Checking if user logged in as domain user, configuration of domain in StationInformation.DomainName
        /// </summary>
        /// <returns>True if user is logged in domain, else False.</returns>
        private Boolean CheckIfDomainUser()
        {
            Match result = Regex.Match(StationInformation.Username, StationInformation.DomainName);
            if (result.Success)
            {
                StationInformation.Username = StationInformation.Username.Replace('@', '.');
                string[] words = StationInformation.Username.Split('.');
                StationInformation.StudentFirstAndLastName = words[0] + " " + words[1];
                //update
                try
                {
                    DbManager manager = new DbManager();
                    manager.UpdateOne("UserName", StationInformation.Username, StationInformation.WorkstationName);
                    manager.UpdateOne("StudentFirstAndLastName", StationInformation.StudentFirstAndLastName, StationInformation.WorkstationName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
                return true;
            }
            else
                return false;
        }

        /// <summary>
        /// Hiding main process to tray and adding it context menu.
        /// </summary>
        private void HideToTray()
        {
            this.Hide();

            trayIcon = new NotifyIcon();
            contextMenu = new ContextMenu();
            menuItemSettings = new MenuItem();
            menuItemClose = new MenuItem();
            menuItemLock = new MenuItem();
            menuItemStatus = new MenuItem();
            menuItemLogout=new MenuItem();

            //create contextmenu and it items
            contextMenu.MenuItems.AddRange(new[] { menuItemStatus, menuItemClose, menuItemLock, menuItemSettings, menuItemLogout });

            menuItemStatus.Index = 0;
            menuItemStatus.Text = "Aplikacja zablokowana";

            menuItemClose.Index = 1;
            menuItemClose.Text = "Zakończ";
            menuItemClose.Click += menuItemClose_Click;

            menuItemLock.Index = 2;
            menuItemLock.Text = "Odblokuj";
            menuItemLock.Click += menuItemLock_Click;

            menuItemSettings.Index = 3;
            menuItemSettings.Text = "Ustawienia";
            menuItemSettings.Click += menuItemSettings_Click;

            menuItemLogout.Index = 4;
            menuItemLogout.Text = "Zmień studenta";
            menuItemLogout.Click += menuItemLogout_Click;

            //create trayicon
            trayIcon.Icon = Properties.Resources.TrayIcon;
            trayIcon.Visible = true;
            trayIcon.Text = "Aplikacja agenta działa w tle zalogowany jest: " + StationInformation.StudentFirstAndLastName;
            trayIcon.ContextMenu = contextMenu;

        }

        private void menuItemLock_Click(object sender, EventArgs e)
        {
            if (!StationInformation.isLocked)
            {
                StationInformation.isLocked = true;
                menuItemStatus.Text = "Aplikacja zablokowana";
                menuItemLock.Text = "Odblokuj";
            }
            else
            {
                Window unlock = new Unlocking();
                unlock.ShowDialog();
                if(!StationInformation.isLocked)
                {
                    menuItemStatus.Text = "Aplikacja odblokowana";
                    menuItemLock.Text = "Zablokuj";
                }
            }
        }
        private void menuItemSettings_Click(object Sender, EventArgs e)
        {
            MessageBox.Show("Tutaj zostania zaimplementowane okienko z ustawieniami");
        }

        private void menuItemLogout_Click(object Sender, EventArgs e)
        {
            //New student here
            //MongoDB update user
            // Nie zrozumialem o co chodzi - do poprawienia.
        }

        private void menuItemClose_Click(object Sender, EventArgs e)
        {
            Close();
        }
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (StationInformation.isLocked)
            {
                Window unlock = new Unlocking();
                unlock.ShowDialog();
                if (StationInformation.isLocked)
                    e.Cancel = true;
                else
                {
                    DeletePreviousHistory();
                }
            }

        }
        /// <summary>
        /// Start new threads to collect data and waiting for screen access.
        /// </summary>
        private void StartWorkingBackground()
        {
            DeletePreviousHistory();
            //DataCollecting
            DataCollector dataCollector = new DataCollector();
            Thread dataCollectorThread = new Thread(dataCollector.Run); //Data collecter in new thread
            dataCollectorThread.IsBackground = true;
            dataCollectorThread.Start();
            //ShareScreen
            DesktopViewerUser server = new DesktopViewerUser(6700); // already working on different thread 
            Thread viewerThread = new Thread(server.StartServer);
            viewerThread.IsBackground = true;
            viewerThread.Start();

        }
    }
}

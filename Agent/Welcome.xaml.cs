using System;
using System.ComponentModel;
using System.IO;
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
        public MenuItem menuItemLock;
        public MenuItem menuItemStatus;

        public Welcome()
        {
            InitializeComponent();
            BeforeAgentStart();
            HideToTray();
        }
        private void ReadConfigurationFile()
        {
            using (StreamReader sw = new StreamReader(StationInformation.ConfigurationFilePath))
            {
                sw.ReadLine();
                StationInformation.WorkstationName = sw.ReadLine();
            }
        }

        private void BeforeAgentStart()
        {
            Window window;
            //If configuration file does not exist settings window will show up first
            if (File.Exists(StationInformation.ConfigurationFilePath) == false)
            {
                window = new SettingsWindow();
            }
            // else sign in window will show up
            else
            {
                ReadConfigurationFile();
                window = new SignInWindow();
            }
            window.ShowDialog();
        }


        private void HideToTray()
        {
            Hide(); //Just hiding window because its impossible to close it

            //initialize
            trayIcon = new NotifyIcon();
            contextMenu = new ContextMenu();
            menuItemSettings = new MenuItem();
            menuItemClose = new MenuItem();
            menuItemLock = new MenuItem();
            menuItemStatus = new MenuItem();




            //create contextmenu and it items
            contextMenu.MenuItems.AddRange(new[] { menuItemSettings, menuItemClose, menuItemLock, menuItemStatus });

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
            MessageBox.Show("heloeeeee");
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
                unlock.Show();
            }
            
            if(StationInformation.isLocked)
            e.Cancel = true;
        }

        private void StartWorkingBackground()
        {
            /*
            DataCollecter dataCollecter = new DataCollecter();
            Thread dataCollecterThread = new Thread(dataCollecter.Run); //Data collecter in new thread
                dataCollecterThread.IsBackground = true;
                dataCollecterThread.Start();
            */
        }
    }
}

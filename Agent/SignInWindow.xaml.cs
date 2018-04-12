using System;
using System.ComponentModel;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using MessageBox = System.Windows.MessageBox;

namespace Agent
{
    /// <summary>
    /// Interaction logic for SignInWindow.xaml
    /// </summary>

    public partial class SignInWindow : Window
    {
        private NotifyIcon trayIcon;
        private ContextMenu contextMenu;
        private MenuItem menuItemSettings;
        private MenuItem menuItemClose;
        private MenuItem menuItemUnlock;
        private MenuItem menuItemLock;
        public static MenuItem menuItemStatus;

        public SignInWindow()
        {
            InitializeComponent();
            Topmost = true;
            WindowState = WindowState.Maximized;
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
        private void HideToTray()
        {
            //Hide(); //Just hiding window because its impossible to close it
            WindowState = WindowState.Minimized;
            return;

            //initialize
            trayIcon = new NotifyIcon();
            contextMenu = new ContextMenu();
            menuItemSettings = new MenuItem();
            menuItemClose = new MenuItem();
            menuItemUnlock=new MenuItem();
            menuItemLock=new MenuItem();
            menuItemStatus = new MenuItem();
            

            

            //create contextmenu and it items
            contextMenu.MenuItems.AddRange(new[] { menuItemSettings, menuItemClose, menuItemUnlock, menuItemLock, menuItemStatus });

            menuItemStatus.Index = 0;
            menuItemStatus.Text = "Status";

            menuItemClose.Index = 1;
            menuItemClose.Text = "Close";
            menuItemClose.Click += menuItemClose_Click;

            menuItemUnlock.Index = 2;
            menuItemUnlock.Text = "Odblokuj aplikację";
            menuItemUnlock.Click += menuItemUnlock_Click;

            menuItemLock.Index = 3;
            menuItemLock.Text = "Zablokuj aplikację";
            menuItemLock.Click += menuItemLock_Click;

            menuItemSettings.Index = 4;
            menuItemSettings.Text = "Settings";
            menuItemSettings.Click += menuItemSettings_Click;

            //create trayicon
            trayIcon.Icon = new Icon("TrayIcon.ico");
            trayIcon.Visible = true;
            trayIcon.Text = "Aplikacja agenta działa w tle zalogowany jest: " + StationInformation.StudentFirstAndLastName;
            trayIcon.ContextMenu = contextMenu;

            //DataCollecter dataCollecter = new DataCollecter();
            //Thread dataCollecterThread = new Thread(dataCollecter.Run); //Data collecter in new thread
            //dataCollecterThread.IsBackground = true;
            //dataCollecterThread.Start();

        }

        private void menuItemUnlock_Click(object sender, EventArgs e)
        {
            Window unlock=new Unlocking();
            unlock.Show();
        }

        private void menuItemLock_Click(object sender, EventArgs e)
        {
            StationInformation.isLocked = true;
            menuItemStatus.Text = "Aplikacja zablokowana";
        }

        private void menuItemSettings_Click(object Sender, EventArgs e)
        {
            MessageBox.Show("heloeeeee");
        }
        private void menuItemClose_Click(object Sender, EventArgs e)
        {
            //MessageBox.Show("close");
            Close();
        }
        private void SignInButton(object sender, RoutedEventArgs e)
        {  
            //validation
            if (FistAndSecondNameTextBox.Text.Length < 3 || StudentIdNumberTextBox.Text.Length <= 5) return;
            StationInformation.StudentFirstAndLastName = FistAndSecondNameTextBox.Text;
            StationInformation.studentId = StudentIdNumberTextBox.Text;
            HideToTray();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void BlockingScreen(object sender, EventArgs e)
        {
            Match result = Regex.Match(StationInformation.Username, StationInformation.DomainName);
            if (result.Success)
            {
                StationInformation.Username = StationInformation.Username.Replace('@', '.');
                string[] words = StationInformation.Username.Split('.');
                StationInformation.StudentFirstAndLastName = words[0] + " " + words[1];
                HideToTray();
            }
            else
            {
                Topmost = true;
                WindowState = WindowState.Maximized;
                FistAndSecondNameTextBox.Text = StationInformation.Username;
                FistAndSecondNameTextBox.Focus(); //This will set cursor to textbox resposible for First and Last name of user
            }
        }

        private void isEnter(object sender, System.Windows.Input.KeyEventArgs e)
        {
            //If enter key is pressed go to SignInButton
            if(e.Key==Key.Enter) SignInButton(sender,new RoutedEventArgs());
        }
    }
}

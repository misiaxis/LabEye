using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Agent
{
    /// <summary>
    /// Interaction logic for SignInWindow.xaml
    /// </summary>

    public partial class SignInWindow : Window
    {
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenu contextMenu;
        private System.Windows.Forms.MenuItem menuItemSettings;
        private System.Windows.Forms.MenuItem menuItemClose;
        public SignInWindow()
        {
            InitializeComponent();
            //Now it will startup maximized and user will be forced to log in
            this.WindowState = WindowState.Maximized;
            FistAndSecondNameTextBox.Focus(); //This will set cursor to textbox resposible for First and Last name of user
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Canceling closing aplication
            e.Cancel = true;
        }
        private void HideToTray()
        {
            this.Hide(); //Just hiding window because its impossible to close it
            //initialize
            this.trayIcon = new System.Windows.Forms.NotifyIcon();
            this.contextMenu = new System.Windows.Forms.ContextMenu();
            this.menuItemSettings = new System.Windows.Forms.MenuItem();
            this.menuItemClose = new System.Windows.Forms.MenuItem();

            //create contextmenu and it items
            this.contextMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { menuItemSettings, menuItemClose });
            this.menuItemSettings.Index = 0;
            this.menuItemSettings.Text = "Settings";
            this.menuItemSettings.Click += new EventHandler(menuItemSettings_Click);
            this.menuItemClose.Index = 1;
            this.menuItemClose.Text = "Close";
            this.menuItemClose.Click += new EventHandler(menuItemClose_Click);

            //create trayicon
            trayIcon.Icon = new System.Drawing.Icon("TrayIcon.ico");
            trayIcon.Visible = true;
            trayIcon.Text = "Aplikacja agenta działa w tle zalogowany jest: " + StationInformation.StudentFirstAndLastName;
            trayIcon.ContextMenu = contextMenu;

        }
        private void menuItemSettings_Click(object Sender, EventArgs e)
        {
            MessageBox.Show("heloeeeee");
        }
        private void menuItemClose_Click(object Sender, EventArgs e)
        {
            //MessageBox.Show("close");
            this.Close();
        }
        private void Sign_In_Button(object sender, RoutedEventArgs e)
        {  
            //validation
            if (FistAndSecondNameTextBox.Text.Length < 3 || StudentIdNumberTextBox.Text.Length < 6) return;
            StationInformation.StudentFirstAndLastName = FistAndSecondNameTextBox.Text;
            HideToTray();
            Console.WriteLine("hehe");
            // To dałbym tez gdzies indziej
            // Zamysł jest taki, że jeżeli uzytkownik juz zaloguje sie na konto domenowe xxx#student.put.poznan.pl to nie musi sie wpisywac
            DataCollecter dataCollecter=new DataCollecter();
            Thread dataCollecterThread = new Thread(dataCollecter.Run); //Data collecter in new thread
            //dataCollecterThread.IsBackground = true;
            //dataCollecterThread.Start();
        }
    }
}

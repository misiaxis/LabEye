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

        private void Sign_In_Button(object sender, RoutedEventArgs e)
        {  
            //validation

            if (FistAndSecondNameTextBox.Text.Length < 3 || StudentIdNumberTextBox.Text.Length < 6) return;

            this.Hide(); //Just hiding window because its impossible to close it
            StationInformation.StudentFirstAndLastName = FistAndSecondNameTextBox.Text;
            System.Windows.Forms.NotifyIcon trayicon = new System.Windows.Forms.NotifyIcon();
            trayicon.Icon = new System.Drawing.Icon("TrayIcon.ico");
            trayicon.Visible = true;
            trayicon.Text = "Aplikacja agenta działa w tle zalogowany jest: "+StationInformation.StudentFirstAndLastName+Environment.NewLine+
                "Nazwa stacji: "+StationInformation.WorkstationName+Environment.NewLine;

            

            DataCollecter dataCollecter=new DataCollecter();
            Thread dataCollecterThread = new Thread(dataCollecter.Run); //Data collecter in new thread


        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using VerticalAlignment = System.Windows.VerticalAlignment;
using WindowStyle = System.Windows.WindowStyle;

namespace Agent
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        public Welcome()
        {
            InitializeComponent();
            WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            WindowStyle = WindowStyle.None;

            //If configuration file does not exist settings window will show up first
            if (File.Exists(StationInformation.ConfigurationFilePath) == false)
            {
                Window settingsWindow = new Settings();
                settingsWindow.Show();
            }
            // else sign in window will show up
            else
            {
                Window loggingWindow=new SignInWindow();
                loggingWindow.Show();
            }
            Close();
        }
    }
}

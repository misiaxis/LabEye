using System.IO;
using System.Windows;

namespace Agent
{
    /// <summary>
    /// Interaction logic for Welcome.xaml
    /// </summary>
    public partial class Welcome : Window
    {
        private void ReadConfigurationFile()
        {
            using (StreamReader sw = new StreamReader(StationInformation.ConfigurationFilePath))
            {
                sw.ReadLine();
                StationInformation.WorkstationName = sw.ReadLine();
            }
        }

        public Welcome()
        {
            InitializeComponent();
            WindowStartupLocation = WindowStartupLocation.CenterScreen;
            WindowStyle = WindowStyle.None;

            //If configuration file does not exist settings window will show up first
            if (File.Exists(StationInformation.ConfigurationFilePath) == false)
            {
                Window settingsWindow = new SettingsWindow();
                settingsWindow.Show();
            }
            // else sign in window will show up
            else
            {
                ReadConfigurationFile();
                Window loggingWindow=new SignInWindow();
                loggingWindow.Show();
            }
            Close();
        }
    }
}

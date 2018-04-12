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
                window=new SignInWindow();
            }
            window.Show();
            window.Closed += Window_Closed;
            Hide();
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}

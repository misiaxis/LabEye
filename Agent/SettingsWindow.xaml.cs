using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace Agent
{
    /// <summary>
    /// Interaction logic for SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
            WorkstationNameTextbox.Text = StationInformation.HostName;
        }

        private void SaveConfiguration(object sender, RoutedEventArgs e)
        {

            var fs = new FileStream(StationInformation.ConfigurationFilePath, FileMode.Create);
            
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine("Workstation");
                    sw.WriteLine(WorkstationNameTextbox.Text);
                }
                //Because probably settings will be shown only on first run by administrator so finishing setting up will close window and aplication
                Close();
        }

        private void SaveConfigToFile(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Plik konfiguracyjny|*.cfg";
            saveFileDialog1.Title = "Zapisz konfigurację do pliku";

            if (saveFileDialog1.ShowDialog() == true)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    sw.WriteLine("Workstation");
                    sw.WriteLine(WorkstationNameTextbox.Text);

                    //Rest of configurations
                }
            }
        }

        private void OpenConfigFromFile(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Plik konfiguracyjny|*.cfg";
            openFileDialog.Title = "Wczytaj plik konfiguracyjny";

            if (openFileDialog.ShowDialog() == true)
            {
                using (StreamReader sw = new StreamReader(openFileDialog.FileName))
                {
                    sw.ReadLine();
                    WorkstationNameTextbox.Text = sw.ReadLine();

                    //Rest of configurations
                }
            }
        }
    }
}

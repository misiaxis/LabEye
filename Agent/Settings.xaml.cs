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

namespace Agent
{
    /// <summary>
    /// Interaction logic for Settings.xaml
    /// </summary>
    public partial class Settings : Window
    {
        public Settings()
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
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prowadzacy_App
{
    public partial class StartupSettings : Form
    {
        public StartupSettings()
        {
            InitializeComponent();
        }

        private void SaveConfiguration(object sender, EventArgs e)
        {
            var fs = new FileStream(StationInformation.ConfigurationFilePath, FileMode.Create);

            using (StreamWriter sw = new StreamWriter(fs))
            {
                sw.WriteLine("DbConfig");
                sw.WriteLine("DbName;" + textBox_MongoDbName.Text);
                sw.WriteLine("MongoDbPath;" + textBox_MongoPath.Text);
            }
            //Because probably settings will be shown only on first run by administrator so finishing setting up will close window and aplication
            Close();
        }

        private void button_SaveConfigToFile_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Plik konfiguracyjny|*.cfg";
            saveFileDialog1.Title = "Zapisz konfigurację do pliku";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(saveFileDialog1.FileName))
                {
                    sw.WriteLine("DbConfig");
                    sw.WriteLine("DbName;" + textBox_MongoDbName.Text);
                    sw.WriteLine("MongoDbPath;" + textBox_MongoPath.Text);
                    //Rest of configurations
                }
            }
        }

        private void button_LoadConfigFromFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Plik konfiguracyjny|*.cfg";
            openFileDialog.Title = "Wczytaj plik konfiguracyjny";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sw = new StreamReader(openFileDialog.FileName))
                {
                    sw.ReadLine();
                    var line_DbName = sw.ReadLine().Split(';');
                    textBox_MongoDbName.Text = line_DbName[1];
                    var line_DbPath = sw.ReadLine().Split(';');
                    textBox_MongoPath.Text = line_DbPath[1];


                    //Rest of configurations
                }
            }
        }
    }
}

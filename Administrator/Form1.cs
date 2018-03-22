using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Administrator
{
    public partial class Form1 : Form
    {
        private void UpdateAppsListBox()
        {
            //get list from database
            /*
            foreach (string blackkeyword in blacklist)
            {
                BlackListAppListBox.Items.Add(blackkeyword);
            }
            */
        }



        public Form1()
        {
            InitializeComponent();
            BlackListAppListBox.Text = "";
            BlackListAppListBox.Items.Add("Wpis");
        }

        private void AddNewKeywordToBlacklist(object sender, EventArgs e)
        {
            //sendtodatabasenewappblackkeyword(appkeywordtoadd.Text)
            BlackListAppListBox.Items.Add(appkeywordtoadd.Text);
        }
    }
}

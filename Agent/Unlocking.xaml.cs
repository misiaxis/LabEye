using System;
using System.Collections.Generic;
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
    /// Interaction logic for Unlocking.xaml
    /// </summary>
    public partial class Unlocking : Window
    {
        public Unlocking()
        {
            InitializeComponent();
            WindowStartupLocation=WindowStartupLocation.CenterScreen;
            AdminPasswordBox.Focus();

            Topmost = true;
        }

        private void isEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (AdminPasswordBox.Password == StationInformation.AdminPassword)
                {
                    StationInformation.isLocked = false;
                    Close();
                }
            }
        }

        private void VerifyPassword(object sender, RoutedEventArgs e)
        {
            if (AdminPasswordBox.Password == StationInformation.AdminPassword)
            {
                StationInformation.isLocked = false;
                Close();
            }
        }
    }
}

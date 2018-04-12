using System.Windows;
using System.Windows.Input;

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
            AdminPasswordBox.Focus();
        }

        private void isEnter(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                if (AdminPasswordBox.Password == StationInformation.AdminPassword)
                {
                    StationInformation.isLocked = false;
                    Welcome.menuItemStatus.Text = "Aplikacja odblokowana";
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

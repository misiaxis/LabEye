using System;
using System.ComponentModel;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Input;

namespace Agent
{
    /// <summary>
    /// Interaction logic for SignInWindow.xaml
    /// </summary>

    public partial class SignInWindow : Window
    {
        private bool IsRegistered;
        public SignInWindow()
        {
            InitializeComponent();
        }

        private void SignInButton(object sender, RoutedEventArgs e)
        {  
            //validation
            if (FistAndSecondNameTextBox.Text.Length < 3) return;

            StationInformation.StudentFirstAndLastName = FistAndSecondNameTextBox.Text;
            IsRegistered = true;
            Close();
        }

        private void BlockingScreen(object sender, EventArgs e)
        {
            Match result = Regex.Match(StationInformation.Username, StationInformation.DomainName);
            if (result.Success)
            {
                StationInformation.Username = StationInformation.Username.Replace('@', '.');
                string[] words = StationInformation.Username.Split('.');
                StationInformation.StudentFirstAndLastName = words[0] + " " + words[1];
            }
            else
            {
                FistAndSecondNameTextBox.Text = StationInformation.Username;
                FistAndSecondNameTextBox.Focus(); //This will set cursor to textbox resposible for First and Last name of user
            }
        }

        private void isEnter(object sender, KeyEventArgs e)
        {
            //If enter key is pressed go to SignInButton
            if(e.Key==Key.Enter) SignInButton(sender,new RoutedEventArgs());
        }

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (IsRegistered == false)
                e.Cancel = true;
        }
    }
}

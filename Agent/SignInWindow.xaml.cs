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
            try
            {
                DbManager manager = new DbManager();
                if (!manager.CheckIfExsists(StationInformation.WorkstationName))
                    manager.WorkstationsMakeNew();
                else
                {
                    manager.UpdateOne("UserName", StationInformation.Username, StationInformation.WorkstationName);
                    manager.UpdateOne("StudentFirstAndLastName", StationInformation.StudentFirstAndLastName, StationInformation.WorkstationName);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            Close();
        }

        private void BlockingScreen(object sender, EventArgs e)
        {
                FistAndSecondNameTextBox.Text = StationInformation.Username;
                FistAndSecondNameTextBox.Focus(); //This will set cursor to textbox resposible for First and Last name of user
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

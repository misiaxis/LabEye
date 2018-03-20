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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Agent
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //Now it will startup maximized and user will be forced to log in
            this.WindowState = WindowState.Maximized;

        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //Canceling closing aplication
            e.Cancel = true;
        }
    }
}

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

namespace AGV_Traffic_Controller
{
    /// <summary>
    /// Interaction logic for CloseWindow.xaml
    /// </summary>
    public partial class CloseWindow : Window
    {
        public string Result;

        public CloseWindow(string message)
        {
            InitializeComponent();

            lblMessage.Content = message;
            Result = "CANCEL";
        }

        private void btnYES_Click(object sender, RoutedEventArgs e)
        {
            Result = "YES";
            this.Close();
        }
        private void btnNO_Click(object sender, RoutedEventArgs e)
        {
            Result = "NO";
            this.Close();
        }
        private void btnCANCEL_Click(object sender, RoutedEventArgs e)
        {
            Result = "CANCEL";
            this.Close();
        }
    }
}

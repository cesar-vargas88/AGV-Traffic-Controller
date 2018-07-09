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
    /// Interaction logic for AddNodeWindow.xaml
    /// </summary>
    public partial class AddNodeWindow : Window
    {

        public bool add;

        public AddNodeWindow()
        {
            InitializeComponent();

            add = false;
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtName.Text != "" && txtID.Text != "")
                btnAdd.IsEnabled = true;
            else
                btnAdd.IsEnabled = false;
        }

        private void txtID_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtName.Text != "" && txtID.Text != "")
                btnAdd.IsEnabled = true;
            else
                btnAdd.IsEnabled = false;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            add = false;
            this.Close();
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            add = true;
            this.Close();
        }
    }
}

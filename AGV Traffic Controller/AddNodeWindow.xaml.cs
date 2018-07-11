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

        private List<Node> list_Nodes;

        public AddNodeWindow(List<Node> List_Nodes)
        {
            InitializeComponent();

            list_Nodes  = List_Nodes;
            add         = false;
        }

        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtName.Text != "")
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
            int x;

            for(x = 0; x < list_Nodes.Count; x++)
            {
                if(list_Nodes[x].name == txtName.Text)
                {
                    MessageBox.Show("Ya existe un vértice con ese nombre.", "Error");
                    x = list_Nodes.Count + 1;
                } 
            }

            if(x == 0 || x == list_Nodes.Count)
            {
                add = true;
                this.Close();
            } 
        }
    }
}

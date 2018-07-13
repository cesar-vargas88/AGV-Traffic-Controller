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
    /// Interaction logic for CreateMapWindow.xaml
    /// </summary>
    public partial class CreateMapWindow : Window
    {
        public bool flagCreate;

        private List<Map> list_Maps;

        public CreateMapWindow(List<Map> List_Maps)
        {
            InitializeComponent();

            list_Maps = List_Maps;
            flagCreate   = false;
        }

        /// <summary>
        /// This method will enable btnCreate button when the txtName contains text.
        /// </summary>
        private void txtName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtName.Text != "")
                btnAdd.IsEnabled = true;
            else
                btnAdd.IsEnabled = false;
        }
        /// <summary>
        /// This method will close the window.
        /// </summary>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// This method verify that the Node doesn't exist, if that is true changes the flagAdd to true and close the window. 
        /// </summary>
        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            int NodeIndex;

            for (NodeIndex = 0; NodeIndex < list_Maps.Count; NodeIndex++)
            {
                if (list_Maps[NodeIndex].name == txtName.Text)
                {
                    MessageBox.Show("Ya existe un vértice con ese nombre.", "Error");
                    NodeIndex = list_Maps.Count + 1;
                }
            }

            if (NodeIndex == 0 || NodeIndex == list_Maps.Count)
            {
                list_Maps.Add(new Map(txtName.Text));
                flagCreate = true;
                this.Close();
            }
        }
    }
}

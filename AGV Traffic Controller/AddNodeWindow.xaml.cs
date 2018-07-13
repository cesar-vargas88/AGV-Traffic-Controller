using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace AGV_Traffic_Controller
{
    /// <summary>
    /// Interaction logic for AddNodeWindow.xaml
    /// </summary>
    public partial class AddNodeWindow : Window
    {
        public bool flagAdd;

        private List<Node>  list_Nodes;

        public AddNodeWindow(List<Node> List_Nodes)
        {
            InitializeComponent();

            list_Nodes  = List_Nodes;
            flagAdd         = false;
        }

        /// <summary>
        /// This method will enabled btnAdd button when the txtName contains text.
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
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int NodeIndex;

            for(NodeIndex = 0; NodeIndex< list_Nodes.Count; NodeIndex++)
            {
                if(list_Nodes[NodeIndex].name == txtName.Text)
                {
                    MessageBox.Show("Ya existe un vértice con ese nombre.", "Error");
                    NodeIndex = list_Nodes.Count + 1;
                } 
            }

            if(NodeIndex == 0 || NodeIndex == list_Nodes.Count)
            {
                flagAdd = true;
                this.Close();
            } 
        }
    }
}

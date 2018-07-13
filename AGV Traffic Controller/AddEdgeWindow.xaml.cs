using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace AGV_Traffic_Controller
{
    /// <summary>
    /// Interaction logic for AddEdgeWindow.xaml
    /// </summary>
    public partial class AddEdgeWindow : Window
    {
        public bool add;
        public Edge edge;

        private List<Node> list_Nodes;
        private List<Edge> list_Edges;

        public AddEdgeWindow(List<Node> List_Nodes, List<Edge> List_Edges)
        {
            InitializeComponent();

            add         = false;
            list_Nodes  = List_Nodes;
            list_Edges  = List_Edges;

            for(int x = 0 ; x < list_Nodes.Count; x ++)
            {
                cboxPredecessor.Items.Add(list_Nodes[x].name);
                cboxSuccessor.Items.Add(list_Nodes[x].name);
            }

            for (int x = 1; x <= 100; x++)
                cboxWeight.Items.Add(x);

            cboxWeight.SelectedIndex = 0;
        }

        /// <summary>
        /// This method will close the window.
        /// </summary>
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            add = false;
            this.Close();
        }
        /// <summary>
        /// This method verify that the Edge doesn't exist, if that is true fills the edge struct. 
        /// </summary>
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int EdgeIndex;

            for (EdgeIndex = 0; EdgeIndex < list_Edges.Count; EdgeIndex++)
            {
                if (list_Edges[EdgeIndex].name.Contains((string)cboxPredecessor.SelectedItem + "<->" + (string)cboxSuccessor.SelectedItem) ||
                    list_Edges[EdgeIndex].name.Contains((string)cboxSuccessor.SelectedItem   + "<->" + (string)cboxPredecessor.SelectedItem))
                {
                    MessageBox.Show("Ya existe una arista entre los vértices " + (string)cboxPredecessor.SelectedItem + " y " + (string)cboxSuccessor.SelectedItem , "Error");
                    EdgeIndex = list_Nodes.Count + 1;
                }
            }

            if (EdgeIndex == 0 || EdgeIndex == list_Edges.Count)
            {
                edge.weight = (int)cboxWeight.SelectedItem;
                edge.node_predecessor.name  = (string) cboxPredecessor.SelectedItem;
                edge.node_successor.name    = (string) cboxSuccessor.SelectedItem;
                edge.name = edge.node_predecessor.name + "<->" + edge.node_successor.name + " : " + edge.weight.ToString();

                add = true;
                this.Close();
            }
        }
        /// <summary>
        /// This event method will enabled btnAdd button when the cboxPredecessor, chboxSucceessor and cboxWeight have a selected item.
        /// </summary>
        private void cboxPredecessor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboxPredecessor.SelectedIndex > -1 && cboxSuccessor.SelectedIndex > -1 && cboxWeight.SelectedIndex > -1)
                btnAdd.IsEnabled = true;
            else
                btnAdd.IsEnabled = false;
        }
        /// <summary>
        /// This event method will enabled btnAdd button when the cboxPredecessor, chboxSucceessor and cboxWeight have a selected item.
        /// </summary>
        private void cboxSuccessor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboxPredecessor.SelectedIndex > -1 && cboxSuccessor.SelectedIndex > -1 && cboxWeight.SelectedIndex > -1)
                btnAdd.IsEnabled = true;
            else
                btnAdd.IsEnabled = false;
        }
        /// <summary>
        /// This event method will enabled btnAdd button when the cboxPredecessor, chboxSucceessor and cboxWeight have a selected item.
        /// </summary>
        private void cboxWeight_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboxPredecessor.SelectedIndex > -1 && cboxSuccessor.SelectedIndex > -1 && cboxWeight.SelectedIndex > -1)
                btnAdd.IsEnabled = true;
            else
                btnAdd.IsEnabled = false;
        }
    }
}

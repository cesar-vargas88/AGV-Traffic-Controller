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

            cboxDirected.Items.Add("Sí");
            cboxDirected.Items.Add("No");

            for(int x = 0 ; x < list_Nodes.Count; x ++)
            {
                cboxPredecessor.Items.Add(list_Nodes[x].name);
                cboxSuccessor.Items.Add(list_Nodes[x].name);
            }

            for (int x = 0; x <= 100; x++)
                cboxWeight.Items.Add(x);

        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            add = false;
            this.Close();
        }
        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            int x;

            for (x = 0; x < list_Edges.Count; x++)
            {
                if (list_Edges[x].name.Contains((string)cboxPredecessor.SelectedItem + "-->" + (string)cboxSuccessor.SelectedItem) || 
                    list_Edges[x].name.Contains((string)cboxPredecessor.SelectedItem + "---" + (string)cboxSuccessor.SelectedItem))
                {
                    MessageBox.Show("Ya existe una arista con ese nombre.", "Error");
                    x = list_Nodes.Count + 1;
                }
            }

            if (x == 0 || x == list_Edges.Count)
            {
                edge.name_node_predecessor  = (string)cboxPredecessor.SelectedItem;
                edge.name_node_successor    = (string)cboxSuccessor.SelectedItem;
                edge.weight = (int)cboxWeight.SelectedItem;

                if ((string)cboxDirected.SelectedItem == "Sí")
                {
                    edge.directed = true;
                    edge.name = edge.name_node_predecessor + "-->" + edge.name_node_successor + " : " + edge.weight.ToString();
                }
                else
                {
                    edge.directed = false;
                    edge.name = edge.name_node_predecessor + "---" + edge.name_node_successor + " : " + edge.weight.ToString();
                }

                add = true;
                this.Close();
            }
        }

        private void cboxTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cboxDirected.SelectedIndex > -1 && cboxPredecessor.SelectedIndex > -1 && cboxSuccessor.SelectedIndex > -1 && cboxWeight.SelectedIndex > -1)
                btnAdd.IsEnabled = true;
            else
                btnAdd.IsEnabled =false;
        }
        private void cboxInicial_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(cboxDirected.SelectedIndex > -1 && cboxPredecessor.SelectedIndex > -1 && cboxSuccessor.SelectedIndex > -1 && cboxWeight.SelectedIndex > -1)
                btnAdd.IsEnabled = true;
            else
                btnAdd.IsEnabled = false;
        }
        private void cboxFinal_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboxDirected.SelectedIndex > -1 && cboxPredecessor.SelectedIndex > -1 && cboxSuccessor.SelectedIndex > -1 && cboxWeight.SelectedIndex > -1)
                btnAdd.IsEnabled = true;
            else
                btnAdd.IsEnabled = false;
        }
        private void cboxPeso_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboxDirected.SelectedIndex > -1 && cboxPredecessor.SelectedIndex > -1 && cboxSuccessor.SelectedIndex > -1 && cboxWeight.SelectedIndex > -1)
                btnAdd.IsEnabled = true;
            else
                btnAdd.IsEnabled = false;
        }
    }
}

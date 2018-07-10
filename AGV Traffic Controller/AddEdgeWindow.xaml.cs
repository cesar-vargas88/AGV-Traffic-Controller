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

        private List<Node> list_Nodes;
        private List<Edge> list_Edges;

        public AddEdgeWindow(List<Node> List_Nodes, List<Edge> List_Edges)
        {
            InitializeComponent();

            add         = false;
            list_Nodes  = List_Nodes;
            list_Edges  = List_Edges;

            cboxTipo.Items.Add("Sí");
            cboxTipo.Items.Add("No");
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

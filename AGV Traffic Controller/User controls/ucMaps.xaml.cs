using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AGV_Traffic_Controller
{
    /// <summary>
    /// Interaction logic for ucMaps.xaml
    /// </summary>

    public partial class ucMaps
    {
        private List<Map>   list_Maps;
        private List<Node>  list_Nodes;
        private List<Edge>  list_Edges;

        private Map         mapSelected;

        private Ellipse     nodeSelected;
        private Line        edgeSelected;
        private Brush       nodeColor;
        private Brush       edgeColor;
        private Brush       selectedNodeColor;
        private Brush       selectedEdgeColor;

        private bool        flagAddNode;

        private const int node_Diameter  = 20;
        private const int edge_Thickness = 3;
        private const int canvasMargin_X = 302;
        private const int canvasMargin_Y = 0;

        public ucMaps()
        {
            InitializeComponent();

            list_Nodes          = new List<Node> { };
            list_Edges          = new List<Edge> { };
            list_Maps           = new List<Map> { };
            nodeSelected        = new Ellipse();
            edgeSelected        = new Line();
            nodeColor           = Brushes.Black;
            edgeColor           = Brushes.Red;
            selectedNodeColor   = Brushes.Green;
            selectedEdgeColor   = Brushes.SteelBlue;

            flagAddNode         = false;
        }

        private void btnLoadMaps_Click(object sender, RoutedEventArgs e)
        {
            LoadMapWindow loadMapWindow = new LoadMapWindow(list_Maps);

            if (loadMapWindow.ShowDialog() == false && loadMapWindow.flagLoad)
            {
               
            }
        }
        private void btnCreateMaps_Click(object sender, RoutedEventArgs e)
        {
            CreateMapWindow createMapWindow = new CreateMapWindow(list_Maps);

            if (createMapWindow.ShowDialog() == false && createMapWindow.flagCreate)
            {
                mapSelected = list_Maps[list_Maps.Count - 1];
                lblMapName.Content = mapSelected.name;
            }
        }
        private void btnDeleteMaps_Click(object sender, RoutedEventArgs e)
        {
            DeleteMapWindow deleteMapWindow = new DeleteMapWindow(list_Maps);

            if (deleteMapWindow.ShowDialog() == false && deleteMapWindow.flagDelete)
            {

            }
            /*if (lboxMaps.SelectedIndex > -1)
            {
                ///<summary>
                /// In this part we look deleted the Edge selected.
                ///</summary>

                for (int MapsIndex = 0; MapsIndex < list_Maps.Count; MapsIndex++)
                {
                    if (list_Maps[MapsIndex].name == (string)lboxMaps.SelectedItem)
                    {
                        list_Maps.RemoveAt(MapsIndex);
                        lboxMaps.Items.RemoveAt(MapsIndex);
                        MapsIndex = list_Maps.Count;
                    }
                }
            }
            else
                MessageBox.Show("Seleccione el mapa que desea eliminar.", "Error");*/
        }

        /// <summary>
        /// This method adds a Node in the list_Nodes, lboxNodes and myCanvas.
        /// </summary>
        private void MyCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point start = e.GetPosition(this);

            start.X = start.X - canvasMargin_X - (node_Diameter / 2);
            start.Y = start.Y - canvasMargin_Y - (node_Diameter / 2);

            if (flagAddNode)
            {
                Ellipse ellipse_Node = new Ellipse()
                {
                    Fill = nodeColor,
                    Height = node_Diameter,
                    Width = node_Diameter
                };

                ellipse_Node.SetValue(Canvas.LeftProperty, start.X);
                ellipse_Node.SetValue(Canvas.TopProperty, start.Y);

                MyCanvas.Children.Add(ellipse_Node);

                AddNodeWindow addNodeWindow = new AddNodeWindow(list_Nodes);

                if (addNodeWindow.ShowDialog() == false && addNodeWindow.flagAdd)
                {
                    list_Nodes.Add
                    (
                        new Node
                        (
                            addNodeWindow.txtName.Text,
                            (int)start.X,
                            (int)start.Y,
                            ellipse_Node
                        )
                    );

                    lboxNodes.Items.Add(addNodeWindow.txtName.Text);

                    MyCanvas.Children.RemoveAt(MyCanvas.Children.Count - 1);
                    ellipse_Node.Name = addNodeWindow.txtName.Text;
                    MyCanvas.Children.Add(ellipse_Node);
                }
                else
                    MyCanvas.Children.RemoveAt(MyCanvas.Children.Count - 1);

                flagAddNode = false;
                btnAddNodes.IsEnabled = true;
            }
        }
        /// <summary>
        /// This method change the flagAddNode in order to allows the user to add a Node.
        /// </summary>
        private void btnAddNodes_Click(object sender, RoutedEventArgs e)
        {
            btnAddNodes.IsEnabled = false;
            flagAddNode = true;
            
            //MessageBox.Show("De clic en la posición donde desea colocar el vértice.", "Información");
        }
        /// <summary>
        /// This method deletes the selected Node from the list_Node, lboxNode and myCanvas.
        /// </summary>
        private void btnDeleteNodes_Click(object sender, RoutedEventArgs e)
        {
            if (lboxNodes.SelectedIndex > -1)
            {
                int NodeIndex = 0;

                ///<summary>
                /// In this part we look deleted the Node selected.
                ///</summary>
                
                for (int CanvasIndex = 0; CanvasIndex < MyCanvas.Children.Count; CanvasIndex++)
                {
                    if (MyCanvas.Children[CanvasIndex].GetType().Name == "Ellipse")
                    {
                        if (NodeIndex == lboxNodes.SelectedIndex)
                        {
                            int EdgesIndex = 0;

                            ///<summary>
                            /// In this part we look for a Edges related with the Node that we will to deleted. The purpose is to delete that Edges too.
                            ///</summary>

                            for (int canvasIndex = 0; canvasIndex < MyCanvas.Children.Count; canvasIndex++)
                            {
                                if (MyCanvas.Children[canvasIndex].GetType().Name == "Line")
                                {
                                    if (list_Edges[EdgesIndex].node_predecessor.name == list_Nodes[NodeIndex].name ||
                                        list_Edges[EdgesIndex].node_successor.name   == list_Nodes[NodeIndex].name)
                                    {
                                        list_Edges.RemoveAt(EdgesIndex);
                                        MyCanvas.Children.RemoveAt(canvasIndex);
                                        lboxEdges.Items.RemoveAt(EdgesIndex);
                                        canvasIndex--;
                                    }
                                    else
                                        EdgesIndex++;
                                }
                            }
                            
                            list_Nodes.RemoveAt(NodeIndex);
                            MyCanvas.Children.RemoveAt(CanvasIndex);
                            lboxNodes.Items.RemoveAt(NodeIndex);
                            CanvasIndex = MyCanvas.Children.Count;
                        }
                        else
                            NodeIndex++;
                    }
                }
            }
            else
                MessageBox.Show("Seleccione el vértice que desea eliminar.", "Error");
        }

        /// <summary>
        /// This method adds a Edge in the list_Edges, lboxEdges and myCanvas.
        /// </summary>
        private void btnAddEdges_Click(object sender, RoutedEventArgs e)
        {
            if (list_Nodes.Count > 0)
            {
                AddEdgeWindow addEdgeWindow = new AddEdgeWindow(list_Nodes, list_Edges);

                if (addEdgeWindow.ShowDialog() == false && addEdgeWindow.add)
                {
                    Point Start = new Point();
                    Point End   = new Point();
                    Node node_predecessor = new Node();
                    Node node_successor   = new Node();

                    int EdgeIndex = 0;

                    for (int NodeIndex = 0; NodeIndex < list_Nodes.Count; NodeIndex++)
                    {
                        if (list_Nodes[NodeIndex].name == addEdgeWindow.edge.node_predecessor.name)
                        {
                            node_predecessor = list_Nodes[NodeIndex];
                            Start.X = list_Nodes[NodeIndex].x_position + (list_Nodes[NodeIndex].ellipse.Width  / 2) + 1;
                            Start.Y = list_Nodes[NodeIndex].y_position + (list_Nodes[NodeIndex].ellipse.Height / 2) + 1;

                            EdgeIndex++;
                        }
                        if (list_Nodes[NodeIndex].name == addEdgeWindow.edge.node_successor.name)
                        {
                            node_successor = list_Nodes[NodeIndex];
                            End.X = list_Nodes[NodeIndex].x_position + (list_Nodes[NodeIndex].ellipse.Width  / 2) + 1;
                            End.Y = list_Nodes[NodeIndex].y_position + (list_Nodes[NodeIndex].ellipse.Height / 2) + 1;

                            EdgeIndex++;
                        }
                        if (EdgeIndex == 2)
                            NodeIndex = list_Nodes.Count;
                    }

                    lboxEdges.Items.Add(addEdgeWindow.edge.name);

                    Line line_Edge = new Line()
                    {
                        Stroke = edgeColor,
                        X1 = Start.X,
                        Y1 = Start.Y,
                        X2 = End.X,
                        Y2 = End.Y,
                        StrokeThickness = edge_Thickness,
                        StrokeStartLineCap = PenLineCap.Triangle,
                        StrokeEndLineCap = PenLineCap.Triangle
                    };

                    list_Edges.Add
                    (
                        new Edge
                        (
                            addEdgeWindow.edge.name,
                            addEdgeWindow.edge.weight,
                            false,
                            line_Edge,
                            node_predecessor,
                            node_successor
                        )
                    );

                    MyCanvas.Children.Add(line_Edge);
                }
            }
            else
                MessageBox.Show("Para agregar una arista debe existir al menos un vertice.", "Error");
        } 
        /// <summary>
        /// This method deletes the selected Edge from the list_Edges, lboxEdges and myCanvas.
        /// </summary>
        private void btnDeleteEdges_Click(object sender, RoutedEventArgs e)
        {
            if (lboxEdges.SelectedIndex > -1)
            {
                int EdgesIndex = 0;

                ///<summary>
                /// In this part we look deleted the Edge selected.
                ///</summary>
                
                for (int CanvasIndex = 0; CanvasIndex < MyCanvas.Children.Count; CanvasIndex++)
                {
                    if (MyCanvas.Children[CanvasIndex].GetType().Name == "Line")
                    {
                        if (EdgesIndex == lboxEdges.SelectedIndex)
                        {
                            list_Edges.RemoveAt(EdgesIndex);
                            MyCanvas.Children.RemoveAt(CanvasIndex);
                            lboxEdges.Items.RemoveAt(EdgesIndex);
                            CanvasIndex = MyCanvas.Children.Count;
                        }
                        else
                            EdgesIndex++;
                    }
                }
            }
            else
                MessageBox.Show("Seleccione la arista que desea eliminar.", "Error");
        }

        /// <summary>
        /// This method changes the color of the selected Node.
        /// </summary>
        private void lboxNodes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ///<summary>
            /// In this part we look chamge the color to the Node selected.
            ///</summary>
            ///
            if (lboxNodes.SelectedIndex > -1)
            {
                nodeSelected.Fill = Brushes.Black;
                list_Nodes[lboxNodes.SelectedIndex].ellipse.Fill = selectedNodeColor;
                nodeSelected = list_Nodes[lboxNodes.SelectedIndex].ellipse;
            }
        }
        /// <summary>
        /// This method changes the color of the selected Edge.
        /// </summary>
        private void lboxEdges_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ///<summary>
            /// In this part we look chamge the color to the Edge selected.
            ///</summary>
     
            if (lboxEdges.SelectedIndex > -1)
            {
                edgeSelected.Stroke = Brushes.Red;
                list_Edges[lboxEdges.SelectedIndex].line.Stroke = selectedEdgeColor;
                edgeSelected = list_Edges[lboxEdges.SelectedIndex].line;
            }
        }
    }
}   
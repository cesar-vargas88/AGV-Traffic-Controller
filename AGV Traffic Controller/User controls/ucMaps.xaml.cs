using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Xml;

namespace AGV_Traffic_Controller
{
    /// <summary>
    /// Interaction logic for ucMaps.xaml
    /// </summary>

    public partial class ucMaps
    {
        private List<Map>   list_Maps;

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

            mapSelected         = new Map("");
            nodeSelected        = new Ellipse();
            edgeSelected        = new Line();
            nodeColor           = Brushes.Black;
            edgeColor           = Brushes.Red;
            selectedNodeColor   = Brushes.Green;
            selectedEdgeColor   = Brushes.SteelBlue;
            flagAddNode         = false;

            ValidateRoboflexRunning();
            CreateDirectories("C:/AGV_Traffic_Controller/", "C:/AGV_Traffic_Controller/Maps/");
            list_Maps = LoadMaps("C:/AGV_Traffic_Controller/Maps/");
        }

        private void ValidateRoboflexRunning()
        {
            if (Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName).Length > 1)
            {
                MessageBox.Show("There is other  " + Process.GetCurrentProcess().ProcessName + " running, it will be closed to open a new one.", "Error");
                {
                    Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName)[0].Kill();
                }
            }
        }
        private void CreateDirectories(string DirectoriesBase, string DirectoriesMaps)
        {
            if (!Directory.Exists(DirectoriesBase))
                Directory.CreateDirectory(DirectoriesBase);
            if (Directory.Exists(DirectoriesBase) && !Directory.Exists(DirectoriesMaps))
                    Directory.CreateDirectory(DirectoriesMaps);
        }
        private List<Map> LoadMaps(string Path)
        {
            string[] fileEntries = Directory.GetFiles(Path);
            List<Map> List_Maps  = new List<Map>();

            for (int Index = 0; Index < fileEntries.Length; Index++)
            {
                if (fileEntries[Index].Substring(fileEntries[Index].Length - 4, 4) == ".xml")
                {
                    List<string> list_Xml = new List<string>();
                    XmlReader reader      = XmlReader.Create(fileEntries[Index]);
                    Map map = new Map("");

                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element || reader.NodeType == XmlNodeType.EndElement)
                            list_Xml.Add(reader.Name);
                        else if (reader.NodeType == XmlNodeType.Text)
                            list_Xml.Add(reader.Value);

                        reader.MoveToElement();
                    }

                    if (list_Xml.Count > 2 && list_Xml[0] == "map")
                    {
                        list_Xml.RemoveAt(0);

                        if (list_Xml[list_Xml.Count - 1] == "map")
                            list_Xml.RemoveAt(list_Xml.Count - 1);

                        if (list_Xml.Count > 1 && list_Xml[0] == "name" && list_Xml.Count > 1 && list_Xml[2] == "name")
                        {
                            map.name = list_Xml[1];
                            list_Xml.RemoveRange(0, 3);

                            if (list_Xml.Count > 2 && list_Xml[0] == "nodes")
                            {
                                list_Xml.RemoveAt(0);

                                while (list_Xml.Count > 19 && list_Xml[0] == "node")
                                {
                                    list_Xml.RemoveAt(0);

                                    if (list_Xml.Count > 3                  &&
                                        list_Xml[0] == "name"               && list_Xml[2] == "name"            &&
                                        list_Xml[3] == "x_position"         && list_Xml[5] == "x_position"      &&
                                        list_Xml[6] == "y_position"         && list_Xml[8] == "y_position"      &&
                                        list_Xml[9] == "ellipse_Fill"       && list_Xml[11] == "ellipse_Fill"   &&
                                        list_Xml[12] == "ellipse_Height"    && list_Xml[14] == "ellipse_Height" &&
                                        list_Xml[15] == "ellipse_Width"     && list_Xml[17] == "ellipse_Width"  )
                                    {
                                        double ellipse_height;
                                        double ellipse_width;
                                        int x_position;
                                        int y_position;

                                        if (int.TryParse(list_Xml[4], out x_position) &&
                                            int.TryParse(list_Xml[7], out y_position) &&
                                            double.TryParse(list_Xml[13], out ellipse_height) &&
                                            double.TryParse(list_Xml[16], out ellipse_width))
                                        {
                                            map.AddNode
                                            (
                                                list_Xml[1],
                                                x_position,
                                                y_position,
                                                new Ellipse()
                                                {
                                                    Fill = nodeColor,
                                                    Height = ellipse_height,
                                                    Width = ellipse_width
                                                }
                                            );

                                            Point Position = new Point {X = x_position, Y = y_position};

                                            map.GetList_Nodes()[map.GetList_Nodes().Count - 1].ellipse.SetValue(Canvas.LeftProperty, Position.X);
                                            map.GetList_Nodes()[map.GetList_Nodes().Count - 1].ellipse.SetValue(Canvas.TopProperty, Position.Y);
                                        }

                                        list_Xml.RemoveRange(0, 19);
                                    }
                                }
                                list_Xml.RemoveAt(0);
                            }
                            if (list_Xml.Count > 2 && list_Xml[0] == "edges")
                            {
                                list_Xml.RemoveAt(0);

                                while (list_Xml.Count > 33 && list_Xml[0] == "edge")
                                {
                                    list_Xml.RemoveAt(0);

                                    if (list_Xml.Count > 33 &&
                                        list_Xml[0]  == "name"                      && list_Xml[2]  == "name"                   &&
                                        list_Xml[3]  == "weight"                    && list_Xml[5]  == "weight"                 &&
                                        list_Xml[6]  == "directed"                  && list_Xml[8]  == "directed"               &&
                                        list_Xml[9]  == "node_predecessor"          && list_Xml[11] == "node_predecessor"       &&
                                        list_Xml[12] == "node_successor"            && list_Xml[14] == "node_successor"         &&
                                        list_Xml[15] == "line_Stroke"               && list_Xml[17] == "line_Stroke"            &&
                                        list_Xml[18] == "line_X1"                   && list_Xml[20] == "line_X1"                &&
                                        list_Xml[21] == "line_Y1"                   && list_Xml[23] == "line_Y1"                &&
                                        list_Xml[24] == "line_X2"                   && list_Xml[26] == "line_X2"                &&
                                        list_Xml[27] == "line_Y2"                   && list_Xml[29] == "line_Y2"                &&
                                        list_Xml[30] == "line_StrokeThickness"      && list_Xml[32] == "line_StrokeThickness"   )
                                    {
                                        int weight;
                                        bool directed;
                                        int line_X1;
                                        int line_Y1;
                                        int line_X2;
                                        int line_Y2;
                                        int line_StrokeThicknes;

                                        if (int.TryParse    (list_Xml[4]    , out weight)               &&
                                            bool.TryParse   (list_Xml[7]    , out directed)             &&
                                            int.TryParse    (list_Xml[19]   , out line_X1)              &&
                                            int.TryParse    (list_Xml[22]   , out line_Y1)              &&
                                            int.TryParse    (list_Xml[25]   , out line_X2)              &&
                                            int.TryParse    (list_Xml[28]   , out line_Y2)              &&
                                            int.TryParse    (list_Xml[31]   , out line_StrokeThicknes)  )
                                        {
                                            BrushConverter conv = new BrushConverter();
                                            Brush line_Stroke = conv.ConvertFromString("Red") as Brush;

                                            Node Node_predecessor = new Node() { name = "" };
                                            Node Node_successor = new Node() { name = "" };

                                            int IndexNode = 0;

                                            while (Node_predecessor.name == "" || Node_successor.name == "")
                                            {
                                                if (map.GetList_Nodes()[IndexNode].name == list_Xml[10])
                                                    Node_predecessor = map.GetList_Nodes()[IndexNode];
                                                if (map.GetList_Nodes()[IndexNode].name == list_Xml[13])
                                                    Node_successor   = map.GetList_Nodes()[IndexNode];

                                                IndexNode++;
                                            }

                                            map.AddEdge
                                            (
                                                list_Xml[1],
                                                weight,
                                                directed,
                                                new Line()
                                                {
                                                    Stroke = line_Stroke,
                                                    X1 = line_X1,
                                                    Y1 = line_Y1,
                                                    X2 = line_X2,
                                                    Y2 = line_Y2,
                                                    StrokeThickness = edge_Thickness
                                                },
                                                Node_predecessor,
                                                Node_successor
                                            );
                                        }

                                        list_Xml.RemoveRange(0, 34);
                                    }
                                }
                            }

                            List_Maps.Add(map);
                        }
                    }
                    
                }
            }

            return List_Maps;
        }

        private void btnCreateMaps_Click(object sender, RoutedEventArgs e)
        {
            CreateMapWindow createMapWindow = new CreateMapWindow(list_Maps);

            if (createMapWindow.ShowDialog() == false && createMapWindow.flagCreate)
            {
                mapSelected = list_Maps[list_Maps.Count - 1];
                mapSelected.CreateXML("C:/AGV_Traffic_Controller/Maps/");
                lblMapName.Content = mapSelected.name;

                lblNodes.Visibility = Visibility.Visible;
                lboxNodes.Visibility = Visibility.Visible;
                btnAddNodes.Visibility = Visibility.Visible;
                btnDeleteNodes.Visibility = Visibility.Visible;
                lblEdges.Visibility = Visibility.Visible;
                lboxEdges.Visibility = Visibility.Visible;
                btnAddEdges.Visibility = Visibility.Visible;
                btnDeleteEdges.Visibility = Visibility.Visible;
                lblAdjacencyLists.Visibility = Visibility.Visible;
                lboxAdjacencyLists.Visibility = Visibility.Visible;

                btnCreateMaps.Visibility = Visibility.Hidden;
                btnLoadMaps.Visibility   = Visibility.Hidden;
                btnSaveMaps.Visibility   = Visibility.Visible;
                btnCloseMaps.Visibility  = Visibility.Visible;
            }
        }
        private void btnLoadMaps_Click(object sender, RoutedEventArgs e)
        {
            LoadMapWindow loadMapWindow = new LoadMapWindow(list_Maps);

            if (loadMapWindow.ShowDialog() == false && loadMapWindow.flagLoad)
            {
                lblNodes.Visibility = Visibility.Visible;
                lboxNodes.Visibility = Visibility.Visible;
                btnAddNodes.Visibility = Visibility.Visible;
                btnDeleteNodes.Visibility = Visibility.Visible;
                lblEdges.Visibility = Visibility.Visible;
                lboxEdges.Visibility = Visibility.Visible;
                btnAddEdges.Visibility = Visibility.Visible;
                btnDeleteEdges.Visibility = Visibility.Visible;
                lblAdjacencyLists.Visibility = Visibility.Visible;
                lboxAdjacencyLists.Visibility = Visibility.Visible;

                btnCreateMaps.Visibility = Visibility.Hidden;
                btnLoadMaps.Visibility = Visibility.Hidden;
                btnSaveMaps.Visibility = Visibility.Visible;
                btnCloseMaps.Visibility = Visibility.Visible;

                mapSelected = loadMapWindow.map;

                lblMapName.Content = mapSelected.name;

                for(int Index = 0 ; Index < mapSelected.GetList_Nodes().Count; Index++)
                {
                    lboxNodes.Items.Add(mapSelected.GetList_Nodes()[Index].name);
                    MyCanvas.Children.Add(mapSelected.GetList_Nodes()[Index].ellipse);
                }
                for (int Index = 0; Index < mapSelected.GetList_Edges().Count; Index++)
                {
                    lboxEdges.Items.Add(mapSelected.GetList_Edges()[Index].name);
                    MyCanvas.Children.Add(mapSelected.GetList_Edges()[Index].line);
                }   
                
            }
        }    
        private void btnSaveMaps_Click(object sender, RoutedEventArgs e)
        {
            SaveWindow saveWindow = new SaveWindow();

            saveWindow.ShowDialog();

            mapSelected.CreateXML("C:/AGV_Traffic_Controller/Maps/");
            MyCanvas.Children.Clear();
        }
        private void btnCloseMaps_Click(object sender, RoutedEventArgs e)
        {
            CloseWindow closeWindow = new CloseWindow("¿Desea guardar el mapa actual?");
            
            if (closeWindow.ShowDialog() == false)
            {
                if      (closeWindow.Result == "YES")
                    mapSelected.CreateXML("C:/AGV_Traffic_Controller/Maps / ");
                else if (closeWindow.Result == "CANCEL")
                    return;
            }

            mapSelected = null;
            lblMapName.Content  = "";

            lblNodes.Visibility = Visibility.Hidden;
            lboxNodes.Visibility = Visibility.Hidden;
            btnAddNodes.Visibility = Visibility.Hidden;
            btnDeleteNodes.Visibility = Visibility.Hidden;
            lblEdges.Visibility = Visibility.Hidden;
            lboxEdges.Visibility = Visibility.Hidden;
            btnAddEdges.Visibility = Visibility.Hidden;
            btnDeleteEdges.Visibility = Visibility.Hidden;
            lblAdjacencyLists.Visibility = Visibility.Hidden;
            lboxAdjacencyLists.Visibility = Visibility.Hidden;

            btnCreateMaps.Visibility = Visibility.Visible;
            btnLoadMaps.Visibility = Visibility.Visible;
            btnSaveMaps.Visibility = Visibility.Hidden;
            btnCloseMaps.Visibility = Visibility.Hidden;

            MyCanvas.Children.Clear();
            lboxEdges.Items.Clear();
            lboxNodes.Items.Clear();
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

                AddNodeWindow addNodeWindow = new AddNodeWindow(mapSelected.GetList_Nodes());

                if (addNodeWindow.ShowDialog() == false && addNodeWindow.flagAdd)
                {
                    mapSelected.AddNode(addNodeWindow.txtName.Text, (int)start.X, (int)start.Y, ellipse_Node);                   
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
                                    if (mapSelected.GetList_Edges()[EdgesIndex].node_predecessor.name == mapSelected.GetList_Nodes()[NodeIndex].name ||
                                        mapSelected.GetList_Edges()[EdgesIndex].node_successor.name   == mapSelected.GetList_Nodes()[NodeIndex].name)
                                    {
                                        mapSelected.GetList_Edges().RemoveAt(EdgesIndex);
                                        MyCanvas.Children.RemoveAt(canvasIndex);
                                        lboxEdges.Items.RemoveAt(EdgesIndex);
                                        canvasIndex--;
                                    }
                                    else
                                        EdgesIndex++;
                                }
                            }

                            mapSelected.RemoveNode(NodeIndex);
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
            if (mapSelected.GetList_Nodes().Count > 0)
            {
                AddEdgeWindow addEdgeWindow = new AddEdgeWindow(mapSelected.GetList_Nodes(), mapSelected.GetList_Edges());

                if (addEdgeWindow.ShowDialog() == false && addEdgeWindow.add)
                {
                    Point Start = new Point();
                    Point End   = new Point();
                    Node node_predecessor = new Node();
                    Node node_successor   = new Node();

                    int EdgeIndex = 0;

                    for (int NodeIndex = 0; NodeIndex < mapSelected.GetList_Nodes().Count; NodeIndex++)
                    {
                        if (mapSelected.GetList_Nodes()[NodeIndex].name == addEdgeWindow.edge.node_predecessor.name)
                        {
                            node_predecessor = mapSelected.GetList_Nodes()[NodeIndex];
                            Start.X = mapSelected.GetList_Nodes()[NodeIndex].x_position + (mapSelected.GetList_Nodes()[NodeIndex].ellipse.Width  / 2) + 1;
                            Start.Y = mapSelected.GetList_Nodes()[NodeIndex].y_position + (mapSelected.GetList_Nodes()[NodeIndex].ellipse.Height / 2) + 1;

                            EdgeIndex++;
                        }
                        if (mapSelected.GetList_Nodes()[NodeIndex].name == addEdgeWindow.edge.node_successor.name)
                        {
                            node_successor = mapSelected.GetList_Nodes()[NodeIndex];
                            End.X = mapSelected.GetList_Nodes()[NodeIndex].x_position + (mapSelected.GetList_Nodes()[NodeIndex].ellipse.Width  / 2) + 1;
                            End.Y = mapSelected.GetList_Nodes()[NodeIndex].y_position + (mapSelected.GetList_Nodes()[NodeIndex].ellipse.Height / 2) + 1;

                            EdgeIndex++;
                        }
                        if (EdgeIndex == 2)
                            NodeIndex = mapSelected.GetList_Nodes().Count;
                    }

                    lboxEdges.Items.Add(addEdgeWindow.edge.name);
                    Line line_Edge = new Line() { Stroke = edgeColor, X1 = Start.X, Y1 = Start.Y, X2 = End.X, Y2 = End.Y, StrokeThickness = edge_Thickness};
                    mapSelected.AddEdge(addEdgeWindow.edge.name, addEdgeWindow.edge.weight, false, line_Edge, node_predecessor, node_successor);
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
                            mapSelected.RemoveEdge(EdgesIndex);
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
                mapSelected.GetList_Nodes()[lboxNodes.SelectedIndex].ellipse.Fill = selectedNodeColor;
                nodeSelected = mapSelected.GetList_Nodes()[lboxNodes.SelectedIndex].ellipse;
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
                mapSelected.GetList_Edges()[lboxEdges.SelectedIndex].line.Stroke = selectedEdgeColor;
                edgeSelected = mapSelected.GetList_Edges()[lboxEdges.SelectedIndex].line;
            }
        }
    }
}   
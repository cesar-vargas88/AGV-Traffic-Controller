using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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

    public struct Node
    {
        public string name;
        public string color;
        public int diameter;
        public int x_position;
        public int y_position;

        public Node(string Name, string Color, int Diameter, int X_position, int Y_position)
        {
            name = Name;
            color = Color;
            diameter = Diameter;
            x_position = X_position;
            y_position = Y_position;
        }
    }
    public struct Edge
    {
        public string name;
        public int weight;
        public bool directed;
        public string name_node_predecessor;
        public int radian_node_predecessor;
        public string name_node_successor;
        public int radian_node_successor;

        public string color;
        public int width;

        public Edge(string Name, int Weight, bool Directed, string Name_node_predecessor, int Radian_node_predecessor, string Name_node_successor, int Radian_node_successor, string Color, int Width)
        {
            name = Name;
            weight = Weight;
            directed = Directed;
            name_node_predecessor = Name_node_predecessor;
            radian_node_predecessor = Radian_node_predecessor;
            name_node_successor = Name_node_successor;
            radian_node_successor = Radian_node_successor;
            color = Color;
            width = Width;
        }
    }

    public partial class ucMaps
    {
        private List<Node> list_Nodes;
        private List<Edge> list_Edges;
        private List<List<Edge>> AdjacencyLists;

        private bool AddNode;
        private const int Node_Diameter  = 30;
        private const int Edge_Thickness = 2;
        private const int CanvasMargin_X = 300;
        private const int CanvasMargin_Y = 50;

        public ucMaps()
        {
            InitializeComponent();

            list_Nodes      = new List<Node> { };
            list_Edges      = new List<Edge> { };
            AdjacencyLists  = new List<List<Edge>> { };

            AddNode = false;
        }

        private void DrawNode(Brush color, int diameter, Point start)
        {
            Ellipse elipse_Node = new Ellipse() { Fill = color, Height = diameter, Width = diameter };

            elipse_Node.SetValue(Canvas.LeftProperty, start.X);
            elipse_Node.SetValue(Canvas.TopProperty, start.Y);

            MyCanvas.Children.Add(elipse_Node);

            AddNodeWindow addNodeWindow = new AddNodeWindow(list_Nodes);

            if (addNodeWindow.ShowDialog() == false && addNodeWindow.add)
            {
                list_Nodes.Add
                (
                    new Node
                    (
                        addNodeWindow.txtName.Text, 
                        color.ToString(), 
                        diameter, 
                        (int)start.X, 
                        (int)start.Y
                    )
                );

                lboxNodes.Items.Add(addNodeWindow.txtName.Text);

                MyCanvas.Children.RemoveAt(MyCanvas.Children.Count - 1);
                elipse_Node.Name = addNodeWindow.txtName.Text;
                MyCanvas.Children.Add(elipse_Node);
            }
            else
                MyCanvas.Children.RemoveAt(MyCanvas.Children.Count - 1);

            AddNode = false;
            btnAddNode.IsEnabled = true;
            btnAddNodes.IsEnabled = true;
        }
        private void DrawEdge(Brush color, int width)
        {
            if(list_Nodes.Count > 0)
            {
                AddEdgeWindow addEdgeWindow = new AddEdgeWindow(list_Nodes, list_Edges);

                if (addEdgeWindow.ShowDialog() == false && addEdgeWindow.add)
                {
                    list_Edges.Add
                    (
                        new Edge
                        (
                            addEdgeWindow.edge.name, 
                            addEdgeWindow.edge.weight,
                            addEdgeWindow.edge.directed,
                            addEdgeWindow.edge.name_node_predecessor, 
                            1, 
                            addEdgeWindow.edge.name_node_successor, 
                            1, 
                            color.ToString(), 
                            2 
                        )
                    );

                    int x;
                    int y = 0;

                    Point Start = new Point();
                    Point End   = new Point();

                    for (x = 0; x < list_Nodes.Count; x++)
                    {
                        if (list_Nodes[x].name == addEdgeWindow.edge.name_node_predecessor)
                        {
                            Start.X = list_Nodes[x].x_position + (list_Nodes[x].diameter / 2) + 1;
                            Start.Y = list_Nodes[x].y_position + (list_Nodes[x].diameter / 2) + 1;

                            y++;
                        }
                        if (list_Nodes[x].name == addEdgeWindow.edge.name_node_successor)
                        {
                            End.X = list_Nodes[x].x_position + (list_Nodes[x].diameter / 2) + 1;
                            End.Y = list_Nodes[x].y_position + (list_Nodes[x].diameter / 2) + 1;

                            y++;
                        }
                        if (y == 2)
                            x = list_Nodes.Count;
                    }

                    lboxEdges.Items.Add(addEdgeWindow.edge.name);

                    Line newLine = new Line() { Stroke = color, X1 = Start.X, Y1 = Start.Y, X2 = End.X, Y2 = End.Y, StrokeThickness = width};

                    MyCanvas.Children.Add(newLine);
                }
            }
            else
                MessageBox.Show("Para agregar una arista debe existir al menos un vertice.", "Error");
        }

        private void MyCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point start = e.GetPosition(this);

            start.X = start.X - CanvasMargin_X - (Node_Diameter/2);
            start.Y = start.Y - CanvasMargin_Y - (Node_Diameter/2);

            if(AddNode)
                DrawNode(Brushes.SteelBlue, Node_Diameter, start);
        }

        private void btnCreateMaps_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnDeleteMaps_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnShowMaps_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddNodes_Click(object sender, RoutedEventArgs e)
        {
            btnAddNode.IsEnabled = false;
            btnAddNodes.IsEnabled = false;
            AddNode = true;
            
            //MessageBox.Show("De clic en la posición donde desea colocar el vértice.", "Información");
        }
        private void btnDeleteNodes_Click(object sender, RoutedEventArgs e)
        {
            if (lboxNodes.SelectedIndex > -1)
            {
                int NodeIndex = 0;

                for (int CanvasIndex = 0; CanvasIndex < MyCanvas.Children.Count; CanvasIndex++)
                {
                    if (MyCanvas.Children[CanvasIndex].GetType().Name == "Ellipse")
                    {
                        if (NodeIndex == lboxNodes.SelectedIndex)
                        {
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
        private void btnSelectNodes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddEdges_Click(object sender, RoutedEventArgs e)
        {
            DrawEdge(Brushes.Black, Edge_Thickness);
        }
        private void btnDeleteEdges_Click(object sender, RoutedEventArgs e)
        {
            if (lboxEdges.SelectedIndex > -1)
            {
                int EdgesIndex = 0;

                for(int CanvasIndex = 0; CanvasIndex < MyCanvas.Children.Count; CanvasIndex++)
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
        private void btnSelectEdges_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}   
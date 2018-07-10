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
        public int name_node_predecessor;
        public int radian_node_predecessor;
        public int name_node_successor;
        public int radian_node_successor;

        public string color;
        public int width;

        public Edge(string Name, int Weight, bool Directed, int Name_node_predecessor, int Radian_node_predecessor, int Name_node_successor, int Radian_node_successor, string Color, int Width)
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

        public ucMaps()
        {
            InitializeComponent();

            list_Nodes      = new List<Node> { };
            list_Edges      = new List<Edge> { };
            AdjacencyLists  = new List<List<Edge>> { };

            AddNode = false;
        }

        private void DrawEdge(Brush color, int weight)
        {
            /*Line newLine = new Line()
            {
                 Stroke = Brushes.Blue,
                 X1 = start.X,
                 Y1 = start.Y - 50,
                 X2 = end.X,
                 Y2 = end.Y - 50
             };

             MyCanvas.Children.Add(newLine);*/

            AddEdgeWindow addEdgeWindow = new AddEdgeWindow(list_Nodes, list_Edges);

            if (addEdgeWindow.ShowDialog() == false && addEdgeWindow.add)
            {
                int x = 0;
            }
        }
        private void DrawNode(Brush color, int diameter, Point start)
        {
            Ellipse elipse_Node = new Ellipse() {Fill = color, Height = diameter, Width = diameter };

            elipse_Node.SetValue(Canvas.LeftProperty, start.X);
            elipse_Node.SetValue(Canvas.TopProperty, start.Y);

            MyCanvas.Children.Add(elipse_Node);

            AddNodeWindow addNodeWindow = new AddNodeWindow(list_Nodes);

            if (addNodeWindow.ShowDialog() == false && addNodeWindow.add)
            {
                list_Nodes.Add(new Node(addNodeWindow.txtName.Text, color.ToString(), diameter, (int) start.X, (int) start.Y));
                lboxNodes.Items.Add(addNodeWindow.txtName.Text);

                MyCanvas.Children.RemoveAt(MyCanvas.Children.Count - 1);
                elipse_Node.Name = addNodeWindow.txtName.Text;
                MyCanvas.Children.Add(elipse_Node);
            }
            else
                MyCanvas.Children.RemoveAt(MyCanvas.Children.Count - 1);

            AddNode                 = false;
            btnAddNode.IsEnabled    = true;
            btnAddNodes.IsEnabled   = true;
        }

        private void MyCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Point start = e.GetPosition(this);

            if(AddNode)
                DrawNode(Brushes.SteelBlue, 20, start);
        }
        private void MyCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // Draw the correct shape
            /*switch (currShape)
            {
                case MyShape.Line:
                    //DrawLine();
                    break;

                case MyShape.Ellipse:
                    DrawEllipse();
                    break;

                default:
                    return;
            }*/
        }
        private void MyCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            // Update the X & Y as the mouse moves
            /*if (e.LeftButton == MouseButtonState.Pressed)
            {
                end = e.GetPosition(this);
            }*/
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
            btnAddNode.IsEnabled    = false;
            btnAddNodes.IsEnabled   = false;
            AddNode                 = true;

            MessageBox.Show("De clic en la posición que quiere colocar el vértice.", "Información");
        }
        private void btnDeleteNodes_Click(object sender, RoutedEventArgs e)
        {
            if (lboxNodes.SelectedIndex > -1)
            {
                MyCanvas.Children.RemoveAt(lboxNodes.SelectedIndex);
                lboxNodes.Items.RemoveAt(lboxNodes.SelectedIndex);
            }
            else
                MessageBox.Show("Seleccione el nodo que desea eliminar.", "Error");
        }
        private void btnSelectNodes_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnAddEdges_Click(object sender, RoutedEventArgs e)
        {
            DrawEdge(Brushes.Black, 2);
        }
        private void btnDeleteEdges_Click(object sender, RoutedEventArgs e)
        {

        }
        private void btnSelectEdges_Click(object sender, RoutedEventArgs e)
        {

        }

       
    }
}   
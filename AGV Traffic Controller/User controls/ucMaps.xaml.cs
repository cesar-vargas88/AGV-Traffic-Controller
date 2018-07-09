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
    public partial class ucMaps
    {
        private enum MyShape
        {
           Ellipse, Line
        }
        private MyShape currShape;
        private Point start;
        private Point end;

        private struct Node
        {
            public string id;
            public string name;
            public int positionX;
            public int positionY;
            public int diameter;

            public Node(string ID, string Name, int PositionX, int PositionY, int Diameter)
            {
                id = ID;
                name = Name;
                positionX = PositionX;
                positionY = PositionY;
                diameter = Diameter;
            }
        }
        private struct Edge
        {
            public int vertexID;
            public int weight;

            public Edge(int VertexID, int Weight)
            {
                vertexID = VertexID;
                weight = Weight;
            }
        }

        private List<Node>       list_Nodes;
        private List<List<Edge>> AdjacencyLists;

        public ucMaps()
        {
            InitializeComponent();

            AdjacencyLists  = new List<List<Edge>> { };
            list_Nodes           = new List<Node> { };
        }

        private void DrawLine()
        {
           /* Line newLine = new Line()
            {
                Stroke = Brushes.Blue,
                X1 = start.X,
                Y1 = start.Y - 50,
                X2 = end.X,
                Y2 = end.Y - 50
            };

            MyCanvas.Children.Add(newLine);*/
        }
        private void DrawEllipse()
        {
            Ellipse elipse_Node = new Ellipse()
            {
                Fill = Brushes.DarkGoldenrod,
                Height = 20,
                Width = 20
            };

            elipse_Node.SetValue(Canvas.LeftProperty, start.X - 310);
            elipse_Node.SetValue(Canvas.TopProperty, start.Y - 50 - 15);
            MyCanvas.Children.Add(elipse_Node);

            AddNodeWindow addNodeWindow = new AddNodeWindow();

            if (addNodeWindow.ShowDialog() == false && addNodeWindow.add)
            {
                list_Nodes.Add(new Node(addNodeWindow.txtID.Text, addNodeWindow.txtName.Text, 0, 1, 20));
                lboxNodes.Items.Add(addNodeWindow.txtName.Text + "\t ID: " + addNodeWindow.txtID.Text);
            }
            else
                MyCanvas.Children.RemoveAt(MyCanvas.Children.Count - 1);
        }

        private void LineButton_Click(object sender, RoutedEventArgs e)
        {
            currShape = MyShape.Line;
        }
        private void EllipseButton_Click(object sender, RoutedEventArgs e)
        {
            currShape = MyShape.Ellipse;
        }

        private void MyCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            // Get the X & Y of where mouse is 1st clicked
            start = e.GetPosition(this);
        }
        private void MyCanvas_MouseUp(object sender, MouseButtonEventArgs e)
        {
            // Draw the correct shape
            switch (currShape)
            {
                case MyShape.Line:
                    DrawLine();
                    break;

                case MyShape.Ellipse:
                    DrawEllipse();
                    break;

                default:
                    return;
            }
        }
        private void MyCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            // Update the X & Y as the mouse moves
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                end = e.GetPosition(this);
            }
        }

        private void lboxNodes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            /*MyCanvas.Children.RemoveAt(lboxNodes.SelectedIndex);
            //list_Nodes.Add(new Node(addNodeWindow.txtID.Text, addNodeWindow.txtName.Text, 0, 1, 20));
            //lboxNodes.Items.Add(addNodeWindow.txtName.Text + "\t ID: " + addNodeWindow.txtID.Text);
            elipse_Node.SetValue(Canvas.LeftProperty, start.X - 310);
            elipse_Node.SetValue(Canvas.TopProperty, start.Y - 50 - 15);
            MyCanvas.Children.Add(elipse_Node);

            MyCanvas.Children[lboxNodes.SelectedIndex].Focus();*/
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
    }
}   
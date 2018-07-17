using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;
using System.Xml;

namespace AGV_Traffic_Controller
{
    public struct Node
    {
        public string name;
        public int x_position;
        public int y_position;
        public Ellipse ellipse;

        public Node(string Name, int X_position, int Y_position, Ellipse Ellipse)
        {
            name = Name;
            x_position = X_position;
            y_position = Y_position;
            ellipse = Ellipse;
        }
    }
    public struct Edge
    {
        public string name;
        public int weight;
        public bool directed;

        public Line line;
        public Node node_predecessor;
        public Node node_successor;

        public Edge(string Name, int Weight, bool Directed, Line Line, Node Node_predecessor, Node Node_successor)
        {
            name = Name;
            weight = Weight;
            directed = Directed;
            line = Line;
            node_predecessor = Node_predecessor;
            node_successor = Node_successor;
        }
    }
    public class Map
    {
        public string name;
        private List<Node> list_Nodes;
        private List<Edge> list_Edges;
        private List<List<Edge>> AdjacencyLists;

        public Map(string Name)
        {
            name = Name;

            list_Nodes      = new List<Node>();
            list_Edges      = new List<Edge>();
            AdjacencyLists  = new List<List<Edge>> { };
        }

        public void AddNode(string Name, int Xposition, int Yposition, Ellipse Ellipse)
        {
            list_Nodes.Add(new Node(Name,Xposition,Yposition,Ellipse));
        }
        public void AddEdge(string Name, int Weight, bool Directed, Line Line_edge, Node Node_predecessor, Node Node_successor)
        {
            list_Edges.Add(new Edge(Name, Weight, Directed, Line_edge, Node_predecessor, Node_successor));
        }
        public void RemoveNode(int Index)
        {
            list_Nodes.RemoveAt(Index);
        }
        public void RemoveEdge(int Index)
        {
            list_Edges.RemoveAt(Index);
        }
        public List<Node> GetList_Nodes()
        {
            return list_Nodes;
        }
        public List<Edge> GetList_Edges()
        {
            return list_Edges;
        }
        public List<List<Edge>> GetAdjacencyLists()
        {
            return AdjacencyLists;
        }
        public bool Load(string path)
        {
            return true;
        }
        public bool Save(string path)
        {
            return true;
        }
        public bool Clear()
        {
            return true;
        }
        public string CreateXML(string Path)
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            settings.OmitXmlDeclaration = true;
            settings.NewLineOnAttributes = false;
            XmlWriter writer = XmlWriter.Create(Path + "/" + name + ".xml", settings);

            using (writer)
            {
                writer.WriteStartDocument();
                writer.WriteStartElement("map");
                writer.WriteElementString("name", name);
                writer.WriteStartElement("nodes");
                    
                for(int Index = 0; Index < list_Nodes.Count; Index++)
                {
                    writer.WriteStartElement("node");
                    writer.WriteElementString("name", list_Nodes[Index].name);
                    writer.WriteElementString("x_position", list_Nodes[Index].x_position.ToString());
                    writer.WriteElementString("y_position", list_Nodes[Index].y_position.ToString());
                    writer.WriteElementString("ellipse_Fill", list_Nodes[Index].ellipse.Fill.ToString());
                    writer.WriteElementString("ellipse_Height", list_Nodes[Index].ellipse.Height.ToString());
                    writer.WriteElementString("ellipse_Width", list_Nodes[Index].ellipse.Width.ToString());
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteStartElement("edges");

                for (int Index = 0; Index < list_Edges.Count; Index++)
                {
                    writer.WriteStartElement("edge");
                    writer.WriteElementString("name", list_Edges[Index].name);
                    writer.WriteElementString("weight", list_Edges[Index].weight.ToString());
                    writer.WriteElementString("directed", list_Edges[Index].directed.ToString());
                    writer.WriteElementString("node_predecessor", list_Edges[Index].node_predecessor.name);
                    writer.WriteElementString("node_successor", list_Edges[Index].node_successor.name);

                    writer.WriteElementString("line_Stroke", list_Edges[Index].line.Stroke.ToString());
                    writer.WriteElementString("line_X1", list_Edges[Index].line.X1.ToString());
                    writer.WriteElementString("line_Y1", list_Edges[Index].line.Y1.ToString());
                    writer.WriteElementString("line_X2", list_Edges[Index].line.X2.ToString());
                    writer.WriteElementString("line_Y2", list_Edges[Index].line.Y2.ToString());
                    writer.WriteElementString("line_StrokeThickness", list_Edges[Index].line.StrokeThickness.ToString());
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
                writer.WriteEndElement();
                writer.Flush();
                writer.Close();

                return System.IO.File.ReadAllText(Path + "/" + name + ".xml");
            }
        }
    }
}

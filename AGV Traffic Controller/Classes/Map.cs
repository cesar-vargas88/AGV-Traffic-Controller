using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

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

        public bool AddNode(Node node)
        {
            return true;
        }
        public bool AddEdge(Edge node)
        {
            return true;
        }
        public bool RemoveNode(string node_Name)
        {
            return true;
        }
        public bool RemoveEdge(string edge_Name)
        {
            return true;
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
    }
}

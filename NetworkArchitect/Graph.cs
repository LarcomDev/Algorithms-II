using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkArchitect
{
    class Graph
    {
        public List<Node> Vertices { get; }

        public Graph()
        {
            Vertices = new List<Node>();
        }

        public void AddEdge(Node first, Node second, int dist)
        {
            first.AddEdge(new Edge(second, dist));
            second.AddEdge(new Edge(first, dist));
        }

        public void AddVertex(Node n)
        {
            Vertices.Add(n);
        }

        public Node Find(string id)
        {
            foreach(Node n in Vertices)
            {
                if (n.ID.Equals(id)) return n;
            }
            return null;
        }

        public string PrintSockets()
        {
            string sockets = "";
            foreach(Node n in Vertices)
            {
                sockets += n.ID + ", ";
            }
            sockets = sockets.Trim();
            return sockets.Remove(sockets.Length - 1);
        }
    }
}

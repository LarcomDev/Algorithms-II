using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkArchitect
{
    class Node
    {
        public string ID { get; set; }
        public List<Edge> Edges { get; }
        public List<Node> Connections { get; set; }

        public Node(string id)
        {
            Edges = new List<Edge>();
            Connections = new List<Node>();
            this.ID = id;
        }

        public void AddEdge(Edge e)
        {
            Edges.Add(e);
        }

        public void AddConn(Node n)
        {
            Connections.Add(n);
        }

        public bool VertexConnected(Node n)
        {
            return Connections.Find(node => node.Equals(n)) != null;
        }

        public int Dist(Node n)
        {
            Edge ed = Edges.Find(e => e.Connected.Equals(n));
            return ed.Distance;
        }

        public Edge GetShortest()
        {
            int smallest = Edges[0].Distance;
            Edge shortestEdge = Edges[0];
            foreach(Edge e in Edges)
            {
                if(e.Distance < smallest)
                {
                    smallest = e.Distance;
                    shortestEdge = e;
                }
            }
            return shortestEdge;
        }

        public override string ToString()
        {
            return ID;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace MazeSolver
{
    public class Graph
    {
        public List<Node> Nodes { get; }
        public Node Start { get; set; }
        public Node End { get; set; }

        public Graph()
        {
            Nodes = new List<Node>();
            Start = null;
            End = null;
        }

        public void AddNode(string value)
        {
            Nodes.Add(new Node(value));
        }

        public Node Find(string node)
        {
            Node found = null;
            foreach(Node n in Nodes)
            {
                if(n.Value == node)
                {
                    found = n;
                }
            }
            return found;
        }
    }
}

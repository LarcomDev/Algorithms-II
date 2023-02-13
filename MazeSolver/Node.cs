using System;
using System.Collections.Generic;
using System.Text;

namespace MazeSolver
{
    public class Node
    {
        public string Value { get; set; }
        public List<Node> Connections { get; }
        public int Distance { get; set; }

        public Node(string val)
        {
            this.Value = val;
            Connections = new List<Node>();
        }

        public override string ToString()
        {
            return Value;
        }
    }
}

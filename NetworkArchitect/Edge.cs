using System;
using System.Collections.Generic;
using System.Text;

namespace NetworkArchitect
{
    class Edge
    {
        public Node Connected { get; set; }
        public int Distance { get; set; }

        public Edge(Node con,int dist)
        {
            this.Connected = con;
            this.Distance = dist;
        }
    }
}

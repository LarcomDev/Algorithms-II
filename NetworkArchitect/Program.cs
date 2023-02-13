using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace NetworkArchitect
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the path to the cable file: ");
            var path = Console.ReadLine();

            string[] lines = File.ReadAllLines(path);
            Graph g = CreateGraph(lines);

            //Run Prims algo with the first vertex in the list of vertices, gets smallest amount of cable
            int minCable = PrimsAlgo(g, g.Vertices[0]);

            Console.WriteLine("Socket Set: " + g.PrintSockets());
            Console.WriteLine("Cable Needed: {0} ft.", minCable);
        }

        public static int PrimsAlgo(Graph g, Node start)
        {
            List<Edge> queue = new List<Edge>();
            List<Node> nodes = new List<Node>();
            Dictionary<Node, int> distances = new Dictionary<Node, int>();

            //Add the start node to visited nodes
            nodes.Add(start);

            //add the edges from the start node to the queue
            foreach (Edge e in start.Edges) queue.Add(e);

            while(queue.Count > 0)
            {
                //gets the next shortest edge in the queue and remove it from the queue
                Edge shortest = GetSmallest(queue);
                queue.Remove(shortest);

                //add node connected to Edge to the visited nodes if not already present.
                if(!nodes.Contains(shortest.Connected))
                {
                    //node connected to current Edge
                    Node Vert = shortest.Connected;

                    nodes.Add(Vert);
                    distances[Vert] = shortest.Distance;
                    foreach (Edge e in Vert.Edges)
                    {
                        if (!queue.Contains(e)) queue.Add(e);
                    }
                }
            }
            return distances.Sum(x => x.Value);
        }

        public static Edge GetSmallest(List<Edge> queue)
        {
            Edge shortest = null;
            int distance = int.MaxValue;
            foreach(Edge e in queue)
            {
                if(e.Distance < distance)
                {
                    distance = e.Distance;
                    shortest = e;
                }
            }
            return shortest;
        }

        public static Graph CreateGraph(string[] lines)
        {
            Graph g = new Graph();
            //add all nodes to the Vertices list
            foreach(string s in lines[0].Split(','))
            {
                g.AddVertex(new Node(s));
            }
            //set up edges using the lines after line 1
            for(int line = 1; line < lines.Length; line++)
            {
                string[] elements = lines[line].Split(',');

                //Find node to add edges to
                Node n = g.Find(elements[0]);

                //Add edges to selected node
                for(int con = 1; con < elements.Length; con++)
                {
                    string[] distAndNode = elements[con].Split(':');
                    Node conNode = g.Find(distAndNode[0]);
                    int distance = int.Parse(distAndNode[1]);
                    n.AddEdge(new Edge(conNode, distance));
                    n.AddConn(conNode);
                }
            }
            return g;
        }
    }
}

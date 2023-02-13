using DotNetty.Common.Utilities;
using System;
using System.Collections.Generic;
using System.IO;

namespace MazeSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter path to maze file");
            var path = Console.ReadLine();

            string[] res = File.ReadAllLines(path);

            //adds all lines to a single string
            string linesBlock = String.Join("\n", res);
            
            //splits input by empty lines to separate different mazes
            res = linesBlock.Split("\n\n", StringSplitOptions.RemoveEmptyEntries);
            int count = 0;
            foreach(string s in res)
            {
                count++;
                string[] lines = s.Split("\n");
                Graph g = CreateMaze(lines);
                Dictionary<Node, Node> paths = DijkstrasAlgo(g, g.Start);
                string finalResult = GetShortestDistance(paths, g.Start, g.End);
                Console.WriteLine("Maze {0}: " + finalResult, count);
            }
        }

        public static Graph CreateMaze(string[] maze)
        {
            Graph g = new Graph();
            foreach(string c in maze[0].Split(","))
            {
                //add each node on the first line as a node in the graph
                g.AddNode(c);
            }
            //set start and end nodes
            g.Start = g.Find(maze[1].Split(',')[0]);
            g.End = g.Find(maze[1].Split(',')[1]);

            //create adjacencies
            //starts at line 2 to avoid the list of all nodes and start/end. Only loops adjacencies.
            for(int i = 2; i < maze.Length; i++)
            {
                //makes sure the line is actually part of the graph, not a comment
                if(!maze[i].StartsWith("//"))
                {
                    string node = "";
                    foreach (string s in maze[i].Split(','))
                    {
                        if(s.Equals(maze[i].Split(',')[0]))
                        {
                            node = s;
                        } else
                        {
                            g.Find(node).Connections.Add(g.Find(s)); 
                        }
                    }
                }
            }
            return g;
        }

        public static Dictionary<Node, Node> DijkstrasAlgo(Graph g, Node start)
        {
            Dictionary<Node, Node> prevs = new Dictionary<Node, Node>();
            List<Node> unvisited = new List<Node>();
            List<Node> visited = new List<Node>();

            //costs.Add(start, 0);
            start.Distance = 0;

            foreach(Node n in g.Nodes)
            {
                unvisited.Add(n);

                //set distance for every node other than start to a very large number.
                if (n != start)
                {
                    n.Distance = int.MaxValue;
                }
            }

            //loop while there is still unvisited nodes.
            while(unvisited.Count > 0)
            {
                //get node with smallest distance and remove it from unvisited
                Node smallest = GetSmallest(unvisited);
                unvisited.Remove(smallest);

                foreach(Node n in smallest.Connections)
                {
                    if(!visited.Contains(n))
                    {
                        //only add 1 since all edges are weight 1 for this lab
                        int pathDistance = smallest.Distance + 1;

                        if(pathDistance < n.Distance)
                        {
                            //update value in dictionary if it already exists, else add it.
                            n.Distance = pathDistance;
                            prevs[n] = smallest;
                        }
                    }
                }
                //after all adjancent nodes are visited, add the node to the visited list.
                visited.Add(smallest);
            }
            //returns the list of previous nodes. Can be used to find shortest distance.
            return prevs;
        }

        public static string GetShortestDistance(Dictionary<Node, Node> res, Node a, Node b)
        {
            //gets the previous nodes
            Node previousNode = b;
            List<Node> order = new List<Node>();
            int count = 0;
            while(previousNode != a && count < res.Count)
            {
                if (!res.ContainsKey(previousNode)) return "No Solution";
                //adds shortest path to list in reverse order.
                order.Add(previousNode);
                previousNode = res[previousNode];
                count++;
            }
            order.Add(a);
            //returns the shortest path if it exists, else returns no solution.
            order.Reverse();
            string result = "";
            result = String.Join(" ", order);

            return result;
        }

        public static Node GetSmallest(List<Node> lst)
        {
            Node smallest = lst[0];
            foreach(Node n in lst)
            {
                if(n.Distance < smallest.Distance)
                {
                    smallest = n;
                }
            }
            return smallest;
        }
    }
}

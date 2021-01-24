using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace _03._Prim_s_Algorithm
{
    class Program
    {
        internal class Edge
        {
            public Edge(int from, int to, int weight)
            {
                this.From = from;
                this.To = to;
                this.Weight = weight;
            }
            public int From { get; set; }

            public int To { get; set; }

            public int Weight { get; set; }
        }

        public static Dictionary<int, List<Edge>> graph;
        public static HashSet<int> forest;
    
        static void Main(string[] args)
        {
            var numEdges = int.Parse(Console.ReadLine());


            graph = ReadGRaph(numEdges);
            forest = new HashSet<int>();

            foreach (var edge in graph)
            {
                if (!forest.Contains(edge.Key))
                {
                    startPrim(edge.Key);
                }
            }
        }

        private static void startPrim(int firstNode)
        {
            forest.Add(firstNode);

            var queue = new OrderedBag<Edge>(graph[firstNode]
                , Comparer<Edge>.Create((f, s) => f.Weight - s.Weight));

            while (queue.Count > 0)
            {
                var edgeDelete = queue.RemoveFirst();
                var nodeAdd = GetNode(edgeDelete.From, edgeDelete.To);

                if(nodeAdd == -1)
                {
                    continue;
                }

                forest.Add(nodeAdd);
                queue.AddMany(graph[nodeAdd]);
                Console.WriteLine($"{edgeDelete.From} - {edgeDelete.To}");
            }
        }

        private static int GetNode(int from, int to)
        {
            if (forest.Contains(from) && !forest.Contains(to))
            {
                return to;
            }

            if (forest.Contains(to) && !forest.Contains(from))
            {
                return from;
            }

            return -1;
        }

        private static Dictionary<int, List<Edge>> ReadGRaph(int numEdges)
        {
            var res = new Dictionary<int, List<Edge>>();

            for (int i = 0; i < numEdges; i++)
            {
                var line = Console.ReadLine()
                    .Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var from = line[0];
                var to = line[1];
                var weight = line[2];

                var edge = new Edge(from, to, weight);

                if (!res.ContainsKey(from))
                {
                    res[from] = new List<Edge>();
                }

                if (!res.ContainsKey(to))
                {
                    res[to] = new List<Edge>();
                }

                res[from].Add(edge);
                res[to].Add(edge);
            }

            return res;
        }
    }
}

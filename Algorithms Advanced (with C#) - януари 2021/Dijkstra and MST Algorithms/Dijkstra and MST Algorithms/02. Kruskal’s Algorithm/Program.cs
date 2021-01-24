using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Kruskal_s_Algorithm
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

        public static List<Edge> graph;

        static void Main(string[] args)
        {
            var numEdge = int.Parse(Console.ReadLine());

            graph = ReadGraph(numEdge);

            var orderedEdges = graph.OrderBy(edge => edge.Weight);
            var nodes = graph.Select(edge => edge.From)
                .Union(graph.Select(edge => edge.To));

            var parents = new int[nodes.Max() + 1];

            for (int i = 0; i < parents.Length; i++)
            {
                parents[i] = i;
            }

            foreach (var edge in orderedEdges)
            {
                var first = GetRoot(edge.From, parents);
                var second = GetRoot(edge.To, parents);

                if(first == second)
                {
                    continue;
                }
                parents[first] = parents[second];
                Console.WriteLine($"{edge.From} - {edge.To}");
            }
        }

        private static int GetRoot(int from,int[] arr)
        {
            while (from != arr[from])
            {
                from = arr[from];
            }
            return from;
        }

        private static List<Edge> ReadGraph(int numEdge)
        {
            var res = new List<Edge>();

            for (int i = 0; i < numEdge; i++)
            {
                var line = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

                var from = line[0];
                var to = line[1];
                var weight = line[2];

                res.Add(new Edge(from, to, weight));
            }

            return res;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Bellman_Ford
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
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            graph = ReadGraph(edges);
            var start = int.Parse(Console.ReadLine());
            var end = int.Parse(Console.ReadLine());

            var distances = new double[nodes + 1];
            var prev = new int[nodes + 1];
            Array.Fill(distances, double.PositiveInfinity);
            Array.Fill(prev, -1);
            distances[start] = 0;

            for (int i = 0; i < nodes - 1; i++)
            {
                var changed = false;
                foreach (var edge in graph)
                {
                    if (double.IsPositiveInfinity(distances[edge.From]))
                    {
                        continue;
                    }

                    var curDistance = distances[edge.From] + edge.Weight;
                    if (distances[edge.To] > curDistance)
                    {
                        changed = true;
                        prev[edge.To] = edge.From;
                        distances[edge.To] = curDistance;
                    }
                }

                if (!changed)
                {
                    break;
                }
            }

            foreach (var edge in graph)
            {
                if (double.IsPositiveInfinity(distances[edge.From]))
                {
                    continue;
                }

                var curDistance = distances[edge.From] + edge.Weight;
                if (distances[edge.To] > curDistance)
                {
                    Console.WriteLine("Negative Cycle Detected");
                    return;
                }
            }

            var stack = ReconstructGraph(prev, end);

            Console.WriteLine(string.Join(" ", stack));
            Console.WriteLine(distances[end]);
        }

        private static Stack<int> ReconstructGraph(int[] prev, int node)
        {
            var res = new Stack<int>();

            while (node != -1)
            {
                res.Push(node);
                node = prev[node];
            }

            return res;
        }

        private static List<Edge> ReadGraph(int edges)
        {
            var res = new List<Edge>();

            for (int i = 0; i < edges; i++)
            {
                var line = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var from = line[0];
                var to = line[1];
                var weight = line[2];

                res.Add(new Edge(from, to, weight));
            }

            return res;
        }
    }
}

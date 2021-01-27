using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Longest_Path
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

        public static List<Edge>[] graph;

        static void Main(string[] args)
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            graph = ReadGraph(edges);
            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());


            var sortedGraph = SortGraph(source);
            var distances = new double[edges + 1];
            Array.Fill(distances, double.NegativeInfinity);
            distances[source] = 0;

            while (sortedGraph.Count > 0)
            {
                var curNode = sortedGraph.Pop();

                foreach (var children in graph[curNode])
                {
                    var curDistance = distances[children.From] + children.Weight;

                    if(distances[children.To] < curDistance)
                    {
                        distances[children.To] = curDistance;
                    }
                }
            }

            Console.WriteLine(distances[destination]);
        }

        private static Stack<int> SortGraph(int source)
        {
            var stack = new Stack<int>();
            var visited = new bool[graph.Length];

            for (int i = 1; i < graph.Length; i++)
            {
                DFS(visited, i, ref stack);
            }

            return stack;
        }

        private static void DFS(bool[] visited, int node, ref Stack<int> stack)
        {
            if (visited[node])
            {
                return;
            }
            visited[node] = true;

            foreach (var children in graph[node])
            {
                DFS(visited, children.To, ref stack);
            }

            stack.Push(node);
        }

        private static List<Edge>[] ReadGraph(int edges)
        {
            var res = new List<Edge>[edges + 1];

            for (int node = 1; node <= edges; node++)
            {
                res[node] = new List<Edge>();
            }

            for (int i = 0; i < edges; i++)
            {
                var line = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var source = line[0];
                var destination = line[1];
                var weight = line[2];

                res[source].Add(new Edge(source, destination, weight));
            }

            return res;
        }
    }
}

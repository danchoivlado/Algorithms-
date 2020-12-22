using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Road_Reconstruction
{
    class Program
    {
        internal class Edge
        {
            public Edge(int first, int second)
            {
                this.first = first;
                this.second = second;
            }

            public int first { get; set; }

            public int second { get; set; }
        }

        public static List<int>[] graph;
        public static List<Edge> edges;

        static void Main(string[] args)
        {
            var buidlings = int.Parse(Console.ReadLine());
            var streets = int.Parse(Console.ReadLine());

            graph = ReadGraph(buidlings, streets);
            edges = GenEdges();

            var endRes = new List<Edge>();
            var blackList = new HashSet<string>();
            foreach (var edge in edges)
            {
                var first = edge.first;
                var second = edge.second;

                if(blackList.Contains($"{second} {first}"))
                {
                    continue;
                }
                blackList.Add($"{first} {second}");

                graph[first].Remove(second);
                graph[second].Remove(first);

                if (buidlings != CountBuildings(first))
                {
                    endRes.Add(edge);
                }

                graph[first].Add(second);
                graph[second].Add(first);
            }

            Console.WriteLine($"Important streets:");
            foreach (var edge in endRes)
            {
                Console.WriteLine($"{edge.first} {edge.second}");
            }
        }

        private static int CountBuildings(int starNode)
        {
            var counter = 0;
            var queue = new Queue<int>();
            var visited = new HashSet<int> { starNode };
            queue.Enqueue(starNode);

            while (queue.Count() > 0)
            {
                var nodeDelete = queue.Dequeue();
                counter++;

                foreach (var child in graph[nodeDelete])
                {
                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        queue.Enqueue(child);
                    }
                }
            }

            return counter;
        }

        private static List<Edge> GenEdges()
        {
            var res = new List<Edge>();

            for (int i = 0; i < graph.Length; i++)
            {
                var node = i;
                foreach (var child in graph[i])
                {
                    res.Add(new Edge(node, child));
                }
            }

            return res;
        }

        private static List<int>[] ReadGraph(int buidlings, int streets)
        {
            var res = new List<int>[buidlings];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = new List<int>();
            }

            for (int i = 0; i < streets; i++)
            {
                var line = Console.ReadLine()
                    .Split(new char[] { '-', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToArray();

                var node = line[0];
                var child = line[1];

                res[node].Add(child);
                res[child].Add(node);
            }

            return res;
        }
    }
}

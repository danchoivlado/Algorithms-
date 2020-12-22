using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Break_Cycles
{
    class Program
    {
        internal class Edge
        {
            public char first { get; set; }

            public char second { get; set; }
        }

        public static Dictionary<char, List<char>> graph;
        public static List<Edge> edges;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            graph = ReadGraph(n);

            edges = GenEdges();

            var endRes = new List<Edge>();
            var revEdges = new HashSet<string>();
            foreach (var edge in edges)
            {
                var first = edge.first;
                var second = edge.second;

                graph[first].Remove(second);
                graph[second].Remove(first);

                if (revEdges.Contains($"{second} {first}"))
                {
                    continue;
                }

                revEdges.Add($"{first} {second}");
                if (HasPath(first, second))
                {
                    endRes.Add(edge);
                }
                else
                {
                    graph[first].Add(second);
                    graph[second].Add(first);
                }
            }

            Console.WriteLine($"Edges to remove: {endRes.Count()}");
            foreach (var edge in endRes)
            {
                Console.WriteLine($"{edge.first} - {edge.second}");
            }
        }

        private static bool HasPath(char first, char second)
        {
            var queue = new Queue<char>();
            var hesh = new HashSet<char>() { first };
            queue.Enqueue(first);

            while (queue.Count > 0)
            {
                var nodeDelete = queue.Dequeue();
                if (nodeDelete == second)
                {
                    return true;
                }

                foreach (var child in graph[nodeDelete])
                {
                    if (!hesh.Contains(child))
                    {
                        hesh.Add(child);
                        queue.Enqueue(child);
                    }
                }
            }

            return false;
        }

        private static List<Edge> GenEdges()
        {
            var res = new List<Edge>();

            foreach (var kvp in graph)
            {
                var node = kvp.Key;
                foreach (var child in kvp.Value)
                {
                    Edge edge = new Edge()
                    {
                        first = node,
                        second = child
                    };
                    res.Add(edge);
                }
            }

            res = res.OrderBy(x => x.first).ThenBy(y => y.second).ToList();

            return res;
        }

        private static Dictionary<char, List<char>> ReadGraph(int n)
        {
            var res = new Dictionary<char, List<char>>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine().Split("->").ToArray();
                var node = char.Parse(line[0].TrimEnd());
                if (!res.ContainsKey(node))
                {
                    res.Add(node, new List<char>());
                }

                var children = line[1]
                    .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(char.Parse)
                    .ToList();
                res[node].AddRange(children);
            }

            return res;
        }
    }
}

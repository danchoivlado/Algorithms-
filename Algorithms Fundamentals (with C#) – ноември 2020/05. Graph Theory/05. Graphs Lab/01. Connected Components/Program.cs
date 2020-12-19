using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Connected_Components
{
    class Program
    {
        public static List<int>[] graph;
        public static bool[] visitedNodes;
        public static List<List<int>> result;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            graph = new List<int>[n];
            visitedNodes = new bool[n];
            result = new List<List<int>>();

            for (int node = 0; node < n; node++)
            {
                var line = Console.ReadLine();
                if (string.IsNullOrEmpty(line))
                {
                    graph[node] = new List<int>();
                    continue;
                }

                var currNodes = line.Split().Select(int.Parse).ToList();
                graph[node] = currNodes;
            }

            for (int node = 0; node < graph.Length; node++)
            {
                if (visitedNodes[node])
                {
                    continue;
                }

                var res = new List<int>();
                DFS(node, res);
                result.Add(res);
            }

            foreach (var res in result)
            {
                Console.WriteLine($"Connected component: {string.Join(" ",res)}");
            }
        }

        private static void DFS(int statNode, List<int> result)
        {
            if (visitedNodes[statNode])
            {
                return;
            }

            visitedNodes[statNode] = true;
            foreach (var node in graph[statNode])
            {
                    DFS(node, result);
            }

            result.Add(statNode);
        }
    }
}
;
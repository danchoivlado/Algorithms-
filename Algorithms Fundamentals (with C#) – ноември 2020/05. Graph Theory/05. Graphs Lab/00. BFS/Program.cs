using System;
using System.Collections.Generic;

namespace _00._BFS
{
    class Program
    {
        public static Dictionary<int, List<int>> graph;
        public static Queue<int> queue;
        public static HashSet<int> visitedNodes;

        static void Main(string[] args)
        {
            visitedNodes = new HashSet<int>();
            queue = new Queue<int>();
            graph = new Dictionary<int, List<int>>()
            {
                { 7, new List<int>(){19, 21, 14} },
                { 19, new List<int>(){1, 12, 31, 21} },
                { 21, new List<int>(){14} },
                { 14, new List<int>(){23, 6} },
                { 1, new List<int>(){7} },
                { 12, new List<int>() },
                { 31, new List<int>(){21} },
                { 23, new List<int>(){21} },
                { 6, new List<int>() },
            };

            foreach (var node in graph.Keys)
            {
                if (!visitedNodes.Contains(node))
                {
                    BFS(node);
                }
            }
        }

        private static void BFS(int statrNode)
        {
            queue.Enqueue(statrNode);
            visitedNodes.Add(statrNode);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                Console.WriteLine(node);

                foreach (var child in graph[node])
                {
                    if (!visitedNodes.Contains(child))
                    {
                        visitedNodes.Add(child);
                        queue.Enqueue(child);
                    }
                }
            }
        }
    }
}


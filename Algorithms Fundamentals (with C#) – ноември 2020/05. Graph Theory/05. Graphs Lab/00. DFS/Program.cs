using System;
using System.Collections.Generic;

namespace _00._DFS
{
    class Program
    {
        public static HashSet<int> visitedNodes;
        public static Dictionary<int, List<int>> graph;

        static void Main(string[] args)
        {
            visitedNodes = new HashSet<int>();
            graph = new Dictionary<int, List<int>>()
            {
                { 1, new List<int>(){19, 21, 14} },
                { 19, new List<int>(){7, 12, 31, 21} },
                { 21, new List<int>(){14} },
                { 14, new List<int>(){23, 6} },
                { 7, new List<int>(){1} },
                { 12, new List<int>() },
                { 31, new List<int>(){21} },
                { 23, new List<int>(){21} },
                { 6, new List<int>() },
            };

            foreach (var node in graph.Keys)
            {
                if (!visitedNodes.Contains(node))
                {
                    DFS(node);
                }
            }
        }

        private static void DFS(int startNode)
        {
            if (visitedNodes.Contains(startNode))
            {
                return;
            }

            visitedNodes.Add(startNode);
            foreach (var node in graph[startNode])
            {
                DFS(node);
            }

            Console.WriteLine(startNode);
        }
    }
}

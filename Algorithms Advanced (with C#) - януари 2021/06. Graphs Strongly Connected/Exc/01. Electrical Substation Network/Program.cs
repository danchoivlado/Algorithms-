using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Electrical_Substation_Network
{
    class Program
    {
        private static List<int>[] graph;
        public static List<int>[] revgraph;
        private static Stack<int> sorted;

        static void Main(string[] args)
        {
            var numNodes = int.Parse(Console.ReadLine());
            var numLines = int.Parse(Console.ReadLine());
            graph = ReadGraph(numNodes, numLines);
            sorted = SortTopologicaly(numNodes);
            ALG();
        }

        private static void ALG()
        {
            var visited = new bool[graph.Length];

            while (sorted.Count > 0)
            {
                var curNode = sorted.Pop();
                if (visited[curNode])
                {
                    continue;   
                }
                visited[curNode] = true;
                var components = new Stack<int>();
                DFS(curNode, visited, components, revgraph);
                Console.WriteLine(string.Join(", ", components));
            }
        }

        private static Stack<int> SortTopologicaly(int numNodes)
        {
            var visited = new bool[numNodes];
            var result = new Stack<int>();

            for (int node = 0; node < numNodes; node++)
            {
                if (!visited[node])
                {
                    DFS(node, visited, result, graph);
                }
            }

            return result;
        }

        private static void DFS(int node,
            bool[] visited,
            Stack<int> result,
            List<int>[] collection)
        {
            visited[node] = true;

            foreach (var child in collection[node])
            {
                if (!visited[child])
                {
                    DFS(child, visited, result, collection);
                }
            }

            result.Push(node);
        }

        private static List<int>[] ReadGraph(int numNodes, int numLines)
        {
            var result = new List<int>[numNodes];
            revgraph = new List<int>[numNodes];
            for (int i = 0; i < numNodes; i++)
            {
                result[i] = new List<int>();
                revgraph[i] = new List<int>();
            }

            for (int i = 0; i < numLines; i++)
            {
                var line = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                var parent = line[0];
                for (int j = 1; j < line.Length; j++)
                {
                    var child = line[j];

                    revgraph[child].Add(parent);
                    result[parent].Add(child);
                }
            }


            return result;
        }
    }
}

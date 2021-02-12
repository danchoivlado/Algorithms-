using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace _01._Strongly_Connected_Components
{
    class Program
    {
        private static List<int>[] graph;
        private static List<int>[] reversed;

        static void Main(string[] args)
        {
            var numNodes = int.Parse(Console.ReadLine());
            var numLines = int.Parse(Console.ReadLine());

            (graph, reversed) = ReadGraph(numNodes, numLines);

            Console.WriteLine("Strongly Connected Components:");
            SCCAlgorithum();
        }

        private static void SCCAlgorithum()
        {
            var sortedStack = SortTopologicaly();
            var visited = new bool[graph.Length];

            while (sortedStack.Count > 0)
            {
                var curNode = sortedStack.Pop();
                if (visited[curNode])
                {
                    continue;
                }
                
                var component = new Stack<int>();
                RevDFS(curNode, visited, component);
                Console.WriteLine($"{{{string.Join(", ", component)}}}");
            }
        }

        private static void RevDFS(int curNode, bool[] visited, Stack<int> component)
        {
            if (visited[curNode])
            {
                return;
            }

            visited[curNode] = true;

            foreach (var child in reversed[curNode])
            {
                RevDFS(child, visited, component);
            }

            component.Push(curNode);
        }

        private static Stack<int> SortTopologicaly()
        {
            var visited = new bool[graph.Length];
            var result = new Stack<int>();

            for (int node = 0; node < graph.Length; node++)
            {
                DFS(node, visited, result);
            }

            return result;
        }

        private static void DFS(int node, bool[] visited, Stack<int> result)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child, visited, result);
            }

            result.Push(node);
        }

        private static (List<int>[] original, List<int>[] rev) ReadGraph(int numNodes, int numLines)
        {
            var res = new List<int>[numNodes];
            var rev = new List<int>[numNodes];

            for (int node = 0; node < numNodes; node++)
            {
                res[node] = new List<int>();
                rev[node] = new List<int>();
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
                    res[parent].Add(child);
                    rev[child].Add(parent);
                }
            }

            return (res, rev);
        }
    }
}

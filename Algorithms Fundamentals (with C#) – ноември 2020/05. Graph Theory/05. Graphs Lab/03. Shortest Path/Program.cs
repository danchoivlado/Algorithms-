using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Shortest_Path
{
    class Program
    {
        public static List<int>[] graph;
        public static bool[] visited;
        public static int[] parentNode;
        public static Stack<int> result;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            ReadGraph(n, edges);

            var startNode = int.Parse(Console.ReadLine());
            var destinationNode = int.Parse(Console.ReadLine());

            FindShortestPath(startNode, destinationNode);
            Console.WriteLine($"Shortest path length is: {result.Count-1}");
            Console.WriteLine(string.Join(" ", result));
        }

        private static void FindShortestPath(int startNode, int destinationNode)
        {
            visited = new bool[graph.Length];
            var queue = new Queue<int>();
            parentNode = new int[graph.Length];
            queue.Enqueue(startNode);

            while (queue.Count > 0)
            {
                var nodeDelete = queue.Dequeue();
                if(nodeDelete == destinationNode)
                {
                    DeconstructArr(nodeDelete);
                    return;
                }

                foreach (var child in graph[nodeDelete])
                {
                    if (!visited[child])
                    {
                        parentNode[child] = nodeDelete;
                        visited[child] = true;
                        queue.Enqueue(child);
                    }
                }
            }


        }

        private static void DeconstructArr(int nodeDelete)
        {
            var currNode = nodeDelete;
            result = new Stack<int>();

            while (currNode != 0)
            {
                result.Push(currNode);
                currNode = parentNode[currNode];
            }
        }

        private static void ReadGraph(int graphLength, int edgesCount)
        {
            graph = new List<int>[graphLength + 1];
            for(int i = 1; i < graph.Length; i++)
            {
                graph[i] = new List<int>();
            }

            for (int i = 0; i < edgesCount; i++)
            {
                var line = Console.ReadLine().Split().Select(int.Parse).ToList();
                var node = line[0];
                var child = line[1];

                graph[node].Add(child);
            }
        }
    }
}

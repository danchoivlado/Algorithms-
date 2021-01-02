using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Black_Mesa
{
    class Program
    {
        public static Dictionary<int, List<int>> graph;
        public static List<int> path;

        static void Main(string[] args)
        {
            var versions = int.Parse(Console.ReadLine());
            var transitions = int.Parse(Console.ReadLine());

            graph = GenerateGraph(versions, transitions);

            var start = int.Parse(Console.ReadLine());
            var end = int.Parse(Console.ReadLine());

            var allPath = BFS(start, end);
            Console.WriteLine(string.Join(" ", path));
            foreach (var node in graph.Keys)
            {
                if (!allPath.Contains(node))
                {
                    Console.Write($"{node} ");
                }
            }


        }

        private static new List<int> BFS(int start, int end)
        {
            var queue = new Queue<int>();
            queue.Enqueue(start);
            var visited = new HashSet<int>() { start };
            var endRes = new List<int>();

            while (queue.Count > 0)
            {
                var nodeDelete = queue.Dequeue();
                endRes.Add(nodeDelete);
                if(nodeDelete == end)
                {
                    path = endRes.ToList();
                }
                foreach (var child in graph[nodeDelete])
                {
                    if (!visited.Contains(child))
                    {
                        visited.Add(child);
                        queue.Enqueue(child);
                    }
                }
            }

            return endRes;
        }

        private static Dictionary<int, List<int>> GenerateGraph(int versions, int transitions)
        {
            var res = new Dictionary<int, List<int>>();
            for (int i = 1; i <= versions; i++)
            {
                res.Add(i, new List<int>());
            }

            for (int i = 0; i < transitions; i++)
            {
                var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var node = line[0];
                var child = line[1];

                res[node].Add(child);
            }

            return res;
        }
    }
}

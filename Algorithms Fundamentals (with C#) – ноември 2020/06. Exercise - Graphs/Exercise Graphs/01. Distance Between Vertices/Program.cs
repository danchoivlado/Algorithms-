using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Distance_Between_Vertices
{
    class Program
    {
        internal class Pair
        {
            public int startNode;
            public int destNode;
        }

        public static Dictionary<int, List<int>> graph;
        public static Dictionary<int, bool> visited;
        public static List<Pair> pairs;
        public static Dictionary<int, int> parents;
        public static int n;

        static void Main(string[] args)
        {
            n = int.Parse(Console.ReadLine());
            var numberOfPairs = int.Parse(Console.ReadLine());

            ReadGraph(n);
            ReadPairs(numberOfPairs);

            foreach (var pair in pairs)
            {
                var count = FindDistannce(pair.startNode, pair.destNode);
                Console.WriteLine($"{{{pair.startNode}, {pair.destNode}}} -> {count}");
            }
        }

        private static int FindDistannce(int startNode, int destNode)
        {
            visited = new Dictionary<int, bool>();
            parents = new Dictionary<int, int>();
            var queue = new Queue<int>();
            queue.Enqueue(startNode);
            visited = FillDic();

            visited[startNode] = true;
            while (queue.Count > 0)
            {
                var deleteNode = queue.Dequeue();
                if(deleteNode == destNode)
                {
                    return ReconstructArr(deleteNode);
                }

                foreach (var child in graph[deleteNode])
                {
                    if (!visited[child])
                    {
                        queue.Enqueue(child);
                        visited[child] = true;
                        parents.Add(child, deleteNode);
                    }
                }
            }

            return -1;
        }

        private static Dictionary<int, bool> FillDic()
        {
            var res = new Dictionary<int, bool>();

            foreach (var node in graph.Keys)
            {
                res.Add(node, false);
            }

            return res;
        }

        private static int ReconstructArr(int deleteNode)
        {
            var curNode = deleteNode;
            var counter = 0;

            while (parents.ContainsKey(curNode))
            {
                counter++;
                curNode = parents[curNode];
            }

            return counter;
        }

        private static void ReadPairs(int numberOfPairs)
        {
            pairs = new List<Pair>();

            for (int i = 0; i < numberOfPairs; i++)
            {
                var line = Console.ReadLine().Split('-').Select(int.Parse).ToArray();

                Pair pair = new Pair()
                {
                    startNode = line[0],
                    destNode = line[1],
                };

                pairs.Add(pair);
            }
        }

        private static void ReadGraph(int n)
        {
            graph = new Dictionary<int, List<int>>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine()
                    .Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries)
                    .ToList();

                var node = int.Parse(line[0]);

                if (line.Count <= 1)
                {
                    graph.Add(node, new List<int>());
                }
                else
                {
                    graph[node] = line[1]
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToList();
                }
            }
        }
    }
}

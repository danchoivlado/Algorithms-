using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Cheap_Town_Tour
{
    internal class Node
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Cost { get; set; }

        public Node(int first, int second, int cost)
        {
            First = first;
            Second = second;
            Cost = cost;
        }
    }

    class Program
    {
        public static List<Node> forest;
        public static List<Node> orderedForest;

        public static void Main(string[] args)
        {
            var numTowns = int.Parse(Console.ReadLine());
            var numStreets = int.Parse(Console.ReadLine());

            forest = ReadForest(numTowns, numStreets);
            var root = GenRoot(numTowns);
            orderedForest = forest.OrderBy(x => x.Cost).ToList();
            FindCheapestPath(root);



        }

        private static void FindCheapestPath(int[] root)
        {
            var total = 0;
            foreach (var node in orderedForest)
            {
                var f = FindRoot(node.First, root);
                var s = FindRoot(node.Second, root);

                if (f != s)
                {
                    root[s] = root[f];
                    total += node.Cost;
                }
            }

            Console.WriteLine(total);
        }

        private static int FindRoot(int node, int[] root)
        {
            while (node != root[node])
            {
                node = root[node];
            }

            return node;
        }

        private static int[] GenRoot(int numTowns)
        {
            var res = new int[numTowns];

            for (int node = 0; node < numTowns; node++)
            {
                res[node] = node;
            }

            return res;
        }

        private static List<Node> ReadForest(int numTowns, int numStreets)
        {
            var res = new List<Node>();

            for (int i = 0; i < numStreets; i++)
            {
                var line = Console.ReadLine().Split(" - ").Select(int.Parse).ToArray();
                var from = line[0];
                var to = line[1];
                var cost = line[2];
                var node = new Node(from, to, cost);
                res.Add(node);
            }

            return res;
        }
    }
}

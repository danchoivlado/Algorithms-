using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Black_Friday
{
    class Program
    {
        internal class Edge
        {
            public int First { get; set; }

            public int Second { get; set; }

            public int Distance { get; set; }

            public Edge(int first, int second, int distance)
            {
                First = first;
                Second = second;
                Distance = distance;
            }
        }

        public static List<Edge> forest;
        public static List<Edge> orderedForest;

        static void Main(string[] args)
        {
            var numberShops = int.Parse(Console.ReadLine());
            var numberStreets = int.Parse(Console.ReadLine());

            forest = ReadForest(numberShops, numberStreets);
            var root = GenRoot(numberShops);
            orderedForest = forest
                .OrderBy(x => x.Distance)
                .ToList();

            Console.WriteLine(FindCheapestPath(root));
        }

        private static int FindCheapestPath(int[] root)
        {
            var total = 0;
            foreach (var edge in orderedForest)
            {
                var firstRoot = FindRoot(edge.First, root);
                var secondRoot = FindRoot(edge.Second, root);

                if (firstRoot != secondRoot)
                {
                    root[secondRoot] = firstRoot;
                    total += edge.Distance;
                }
            }

            return total;
        }

        private static int FindRoot(int node, int[] root)
        {
            while (node != root[node])
            {
                node = root[node];
            }

            return node;
        }

        private static int[] GenRoot(int shops)
        {
            var res = new int[shops];

            for (int a = 0; a < shops; a++)
            {
                res[a] = a;
            }

            return res;
        }


        private static List<Edge> ReadForest(int shops, int streets)
        {
            var res = new List<Edge>();

            for (int i = 0; i < streets; i++)
            {
                var line = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var first = line[0];
                var second = line[1];
                var distance = line[2];

                res.Add(new Edge(first, second, distance));
            }

            return res;
        }
    }
}

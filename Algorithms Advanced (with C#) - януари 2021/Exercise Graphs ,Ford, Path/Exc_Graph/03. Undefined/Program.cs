using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Undefined
{
    internal class Node
    {
        public int From { get; set; }

        public int To { get; set; }

        public int Weight { get; set; }

        public Node(int from, int to, int weight)
        {
            From = from;
            To = to;
            Weight = weight;
        }
    }

    class Program
    {
        public static List<Node> edges;

        static void Main(string[] args)
        {
            var numberNodes = int.Parse(Console.ReadLine());
            var numberEdges = int.Parse(Console.ReadLine());
            edges = ReadGraph(numberNodes + 1, numberEdges);
            var start = int.Parse(Console.ReadLine());
            var end = int.Parse(Console.ReadLine());


            var distnaces = new double[numberNodes + 1];
            Array.Fill(distnaces, double.PositiveInfinity);
            distnaces[start] = 0;
            var prev = new int[numberNodes + 1];
            prev[start] = -1;

            for (int i = 1; i <= numberNodes; i++)
            {
                foreach (var child in edges)
                {
                    var newDistance = distnaces[child.From] + child.Weight;

                    if (!double.IsPositiveInfinity(distnaces[child.From])
                        && newDistance < distnaces[child.To] )
                    {
                        distnaces[child.To] = newDistance;
                        prev[child.To] = child.From;
                    }
                }
            }
            
            foreach (var child in edges)
            {
                var newDistance = distnaces[child.From] + child.Weight;

                if (!double.IsPositiveInfinity(distnaces[child.From])
                    && newDistance < distnaces[child.To])
                {
                    Console.WriteLine("Undefined");
                    return;
                }
            }

            var path = GenPath(prev, end);
            Console.WriteLine(string.Join(" ", path));
            Console.WriteLine(distnaces[end]);
        }

        private static Stack<int> GenPath(int[] prev, int end)
        {
            var stack = new Stack<int>();

            while (end != -1)
            {
                stack.Push(end);
                end = prev[end];
            }

            return stack;
        }

        private static List<Node> ReadGraph(int numberNodes, int numberEdges)
        {
            var res = new List<Node>();
            for (int i = 0; i < numberEdges; i++)
            {
                var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var from = line[0];
                var to = line[1];
                var weight = line[2];
                var node = new Node(from, to, weight);
                res.Add(node);
            }

            return res;
        }
    }
}

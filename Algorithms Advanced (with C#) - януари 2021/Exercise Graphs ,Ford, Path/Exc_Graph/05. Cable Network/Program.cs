using System;
using System.Collections.Generic;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using Wintellect.PowerCollections;

namespace _05._Cable_Network
{
    internal class Node
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }

        public Node(int first, int second, int weight)
        {
            First = first;
            Second = second;
            Weight = weight;
        }
    }
    class Program
    {
        public static List<Node>[] graph;
        public static List<int> spanningTree;

        static void Main(string[] args)
        {
            var budget = int.Parse(Console.ReadLine());
            var numNodes = int.Parse(Console.ReadLine());
            var numEdges = int.Parse(Console.ReadLine());
            spanningTree = new List<int>();
            graph = ReadGraph(numNodes, numEdges);

            var costed = Prim(budget);
            Console.WriteLine($"Budget used: {costed}");
        }

        private static int Prim(int budget)
        {
            var costedBudget = 0;
            var queue = new OrderedBag<Node>
                (Comparer<Node>.Create((f, s) => f.Weight - s.Weight));
            foreach (var edge in spanningTree)
            {
                queue.AddMany(graph[edge]);
            }

            while (queue.Count > 0)
            {
                var curNod = queue.RemoveFirst();

                var actualNode = GetActualNode(curNod);

                if (actualNode == -1)
                {
                    continue;
                }

                if (budget < curNod.Weight)
                {
                    break;
                }

                budget -= curNod.Weight;
                costedBudget += curNod.Weight;

                spanningTree.Add(actualNode);
                queue.AddMany(graph[actualNode]);
            }

            return costedBudget;
        }

        private static int GetActualNode(Node node)
        {
            var an = -1;

            if (spanningTree.Contains(node.First) && !spanningTree.Contains(node.Second))
            {
                an = node.Second;
            }
            else if (!spanningTree.Contains(node.First) && spanningTree.Contains(node.Second))
            {
                an = node.First;
            }

            return an;
        }

        private static List<Node>[] ReadGraph(int numNodes, int numEdges)
        {
            var res = Fill(numNodes);

            for (int i = 0; i < numEdges; i++)
            {
                var line = Console.ReadLine().Split();
                var first = int.Parse(line[0]);
                var second = int.Parse(line[1]);
                var weight = int.Parse(line[2]);

                if (line.Length == 4)
                {
                    spanningTree.Add(first);
                    spanningTree.Add(second);
                }

                var node = new Node(first, second, weight);
                var node2 = new Node(second, first, weight);
                res[first].Add(node);
                res[second].Add(node2);
            }

            return res;
        }

        private static List<Node>[] Fill(int numNodes)
        {
            var res = new List<Node>[numNodes];
            for (int i = 0; i < numNodes; i++)
            {
                res[i] = new List<Node>();
            }

            return res;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography;
using Wintellect.PowerCollections;

namespace _02._Chain_Lightning
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

        public static List<Edge>[] graph;
        public static Dictionary<int, Dictionary<int, int>> nodeByTree;

        static void Main(string[] args)
        {
            var numberNeighbours = int.Parse(Console.ReadLine());
            var numDistances = int.Parse(Console.ReadLine());
            var numberLightbibgs = int.Parse(Console.ReadLine());

            nodeByTree = new Dictionary<int, Dictionary<int, int>>();
            graph = ReadGraph(numberNeighbours, numDistances);
            var damageByNode = new Dictionary<int, int>();

            var bestDemage = 0;
            for (int i = 0; i < numberLightbibgs; i++)
            {
                var line = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var neighbourhood = line[0];
                var damage = line[1];

                if (!nodeByTree.ContainsKey(neighbourhood))
                {
                    nodeByTree[neighbourhood] = Prim(neighbourhood);
                }

                foreach (var kvp in nodeByTree[neighbourhood])
                {
                    var curdemage = CalcDamage(damage, kvp.Value);

                    if (!damageByNode.ContainsKey(kvp.Key))
                    {
                        damageByNode[kvp.Key] = 0;
                    }

                    damageByNode[kvp.Key] += curdemage;
                    if (damageByNode[kvp.Key] > bestDemage)
                    {
                        bestDemage = damageByNode[kvp.Key];
                    }
                }
            }
            Console.WriteLine(bestDemage);
        }

        private static int CalcDamage(int damage, int depth)
        {
            for (int a = 0; a < depth; a++)
            {
                damage /= 2;
            }

            return damage;
        }

        private static Dictionary<int,int> Prim(int start)
        {
            var tree = new Dictionary<int, int>()
            {
                { start , 0}
            };

            var queue = new OrderedBag<Edge>
                (Comparer<Edge>.Create((f, s) => f.Distance - s.Distance));
            queue.AddMany(graph[start]);

            while (queue.Count > 0 )
            {
                var node = queue.RemoveFirst();

                var nonTreeNode = GetNonTreeNode(node, tree);
                if (nonTreeNode == -1)
                {
                    continue;
                }

                var treeNode = GetTreeNode(node, tree);

                tree.Add(nonTreeNode, tree[treeNode] + 1);
                queue.AddMany(graph[nonTreeNode]);
            }

            return tree;
        }

        private static int GetTreeNode(Edge node, Dictionary<int, int> tree)
        {
            if (tree.ContainsKey(node.First))
            {
                return node.First;
            }
            return node.Second;
        }

        private static int GetNonTreeNode(Edge node, Dictionary<int, int> tree)
        {
            if (tree.ContainsKey(node.First) && !tree.ContainsKey(node.Second))
            {
                return node.Second;
            }

            if (!tree.ContainsKey(node.First) && tree.ContainsKey(node.Second))
            {
                return node.First;
            }

            return -1;
        }

        private static List<Edge>[] ReadGraph(int numberNeighbours, int numDistances)
        {
            var res = new List<Edge>[numberNeighbours];

            for (int i = 0; i < res.Length; i++)
            {
                res[i] = new List<Edge>();
            }

            for (int i = 0; i < numDistances; i++)
            {
                var line = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var first = line[0];
                var second = line[1];
                var distance = line[2];

                res[first].Add(new Edge(first,second,distance));
                res[second].Add(new Edge(second, first, distance));
            }

            return res;
        }
    }
}

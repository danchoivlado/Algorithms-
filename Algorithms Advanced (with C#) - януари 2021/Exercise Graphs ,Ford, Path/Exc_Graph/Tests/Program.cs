using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Tests
{
    
    internal class Node
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Reliability { get; set; }

        public Node(int first, int second, int reliability)
        {
            this.First = first;
            this.Second = second;
            this.Reliability = reliability;
        }
    }

    class Program
    {
        public static List<Node>[] graph;
        static void Main(string[] args)
        {
            var numNodes = int.Parse(Console.ReadLine());
            var numEdges = int.Parse(Console.ReadLine());
            graph = ReadGraph(numNodes, numEdges);
            var start = int.Parse(Console.ReadLine());
            var end = int.Parse(Console.ReadLine());

            var mostReliablePath = FinPath(start, end);
            Console.WriteLine(mostReliablePath);
        }

        private static string FinPath(int start, int end)
        {
            var sb = new StringBuilder();
            var len = graph.Length;

            var distances = new double[len];
            var prev = new int[len];
            for (int i = 0; i < len; i++)
            {
                distances[i] = double.NegativeInfinity;
                prev[i] = -1;
            }
            distances[0] = 1;

            var queue = new OrderedBag<int>(Comparer<int>
                .Create((f, s) => distances[s].CompareTo(distances[f])));

            queue.Add(start);

            while (queue.Count > 0)
            {
                var delNode = queue.RemoveFirst();

                if (delNode == end)
                {
                    break;
                }

                foreach (var children in graph[delNode])
                {
                    var curTo = children.First == delNode ? children.Second : children.First;

                    if (double.IsNegativeInfinity(distances[curTo]))
                    {
                        queue.Add(curTo);
                    }

                    var newDistance = distances[delNode] * children.Reliability / 100.0;
                    if (newDistance > distances[curTo])
                    {
                        distances[curTo] = newDistance;
                        prev[curTo] = delNode;
                        queue = new OrderedBag<int>(queue,
                            Comparer<int>.Create((f, s) =>
                                distances[s].CompareTo(distances[f])));
                    }
                }

            }

            sb.AppendLine($"Most reliable path reliability: {(distances[end] * 100):F2}%");
            sb.AppendLine(DeconstructArr(end, prev));
            return sb.ToString();
        }

        private static string DeconstructArr(int end, int[] prev)
        {
            var stack = new Stack<int>();
            while (end != -1)
            {
                stack.Push(end);
                end = prev[end];
            }

            return string.Join(" -> ", stack);
        }


        private static List<Node>[] ReadGraph(int numNodes, int numEdges)
        {
            var res = GenArray(numNodes);

            for (int i = 0; i < numEdges; i++)
            {
                var line = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var first = line[0];
                var second = line[1];
                var reliability = line[2];
                var node = new Node(first, second, reliability);
                var node2 = new Node(second, first, reliability);
                res[first].Add(node);
                res[second].Add(node2);
            }

            return res;
        }

        private static List<Node>[] GenArray(int numNodes)
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Runtime.Serialization.Formatters;
using Wintellect.PowerCollections;

namespace _01._Le_Tour_de_Sofia
{
    class Program
    {
        public static List<Node>[] graph;
        public static double[] distances;

        static void Main(string[] args)
        {
            var numberJunctions = int.Parse(Console.ReadLine());
            var numberStreets = int.Parse(Console.ReadLine());
            var startRoute = int.Parse(Console.ReadLine());

            graph = ReadGraph(numberJunctions, numberStreets);

            distances = new double[numberJunctions];

            for (int i = 0; i < numberJunctions; i++)
            {
                distances[i] = double.PositiveInfinity;
            }

            var queue = new OrderedBag<int>
                (Comparer<int>.Create((f, s) => distances[f].CompareTo(distances[s])));
            foreach (var kvp in graph[startRoute])
            {
                var child = kvp.To;
                distances[child] = kvp.Value;
                queue.Add(child);
            }


            var visited = new HashSet<int>() { startRoute };
            while (queue.Count > 0)
            {
                var node = queue.RemoveFirst();
                visited.Add(node);

                foreach (var kvp in graph[node])
                {
                    var child = kvp.To;

                    if (double.IsPositiveInfinity(distances[child]))
                    {
                        queue.Add(child);
                    }

                    var newDistance = distances[node] + kvp.Value;
                    if (distances[child] > newDistance)
                    {
                        distances[child] = newDistance;
                        queue = new OrderedBag<int>
                        (queue, Comparer<int>
                            .Create((f, s) => distances[f].CompareTo(distances[s])));
                    }
                }
            }

            if (double.IsPositiveInfinity(distances[startRoute]))
            {
                Console.WriteLine(visited.Count);
            }
            else
            {
                Console.WriteLine(distances[startRoute]);
            }
        }

        private static List<Node>[] ReadGraph(int numberJunctions, int numberStreets)
        {
            var res = new List<Node>[numberJunctions];

            for (int i = 0; i < numberJunctions; i++)
            {
                res[i] = new List<Node>();
            }

            for (int i = 0; i < numberStreets; i++)
            {
                var line = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var parent = line[0];
                var child = line[1];
                var value = line[2];
                res[parent].Add(new Node(parent, child, value));
            }

            return res;
        }
    }

    internal class Node 
    {
        public int From { get; set; }

        public int To { get; set; }

        public int Value { get; set; }

        public Node(int from, int to, int value)
        {
            From = from;
            To = to;
            Value = value;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Wintellect.PowerCollections;

namespace _03._Emergency_Plan
{
    class Program
    {
        public static HashSet<int> exitRooms;
        public static List<Edge>[] graph;
        public static TimeSpan time;
        // public static TimeSpan[] distances;

        static void Main(string[] args)
        {
            var numRooms = int.Parse(Console.ReadLine());
            var line = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToList();
            exitRooms = new HashSet<int>();
            for (int i = 0; i < line.Count; i++)
            {
                exitRooms.Add(line[i]);
            }

            var numConnections = int.Parse(Console.ReadLine());

            graph = ReadGraph(numRooms, numConnections);
            time = TimeSpan
                .ParseExact(Console.ReadLine(), @"mm\:ss", CultureInfo.InvariantCulture, TimeSpanStyles.None);
            //distances = new TimeSpan[numRooms];

            for (int i = 0; i < numRooms; i++)
            {
                if (!exitRooms.Contains(i))
                {
                    Diikstra(i);
                }
            }
        }

        private static void Diikstra(int startNode)
        {
            var maxKey = graph.Length;
            var distances = new TimeSpan[maxKey];
            var prev = new int[maxKey];
            for (int i = 0; i < distances.Length; i++)
            {
                distances[i] = TimeSpan.MaxValue;
            }
            distances[startNode] = new TimeSpan(0, 0, 0);
            var queue = new OrderedBag<int>(Comparer<int>.Create((f, s) => distances[f].CompareTo(distances[s])));
            var end = -1;

            queue.Add(startNode);

            while (queue.Count > 0)
            {
                var minEdge = queue.RemoveFirst();

                if (exitRooms.Contains(minEdge))
                {
                    end = minEdge;
                    break;
                }

                foreach (var child in graph[minEdge])
                {
                    var actualChild = minEdge == child.First ? child.Second : child.First;
                    var actualChildWeight = child.Time + distances[minEdge];
                    if (distances[actualChild] == TimeSpan.MaxValue)
                    {
                        queue.Add(actualChild);
                    }

                    if (distances[actualChild] > actualChildWeight)
                    {
                        distances[actualChild] = actualChildWeight;
                        prev[actualChild] = minEdge;
                        queue = new OrderedBag<int>(queue, Comparer<int>.Create((f, s) => distances[f].CompareTo(distances[s])));
                    }
                }
            }

            if (end != -1)
            {
                var curTime = distances[end];
                if (curTime <= time)
                {
                    Console.WriteLine($"Safe {startNode} ({curTime})");
                }
                else
                {
                    Console.WriteLine($"Unsafe {startNode} ({curTime})");
                }
            }
            else
            {
                Console.WriteLine($"Unreachable {startNode} (N/A)");
            }
        }

        private static List<Edge>[] ReadGraph(int numRooms, int numConnections)
        {
            var res = new List<Edge>[numRooms];
            var format = @"h\:mm\:ss\.fff";


            for (int i = 0; i < numRooms; i++)
            {
                res[i] = new List<Edge>();
            }

            for (int i = 0; i < numConnections; i++)
            {
                var line = Console.ReadLine()
                    .Split()
                    .ToArray();

                var first = int.Parse(line[0]);
                var second = int.Parse(line[1]);
                var time = TimeSpan
                    .ParseExact(line[2], @"mm\:ss", CultureInfo.InvariantCulture, TimeSpanStyles.None);

                res[first].Add(new Edge(first, second, time));
                res[second].Add(new Edge(second, first, time));
            }

            return res;
        }
    }

    internal class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public TimeSpan Time { get; set; }

        public Edge(int first, int second, TimeSpan time)
        {
            First = first;
            Second = second;
            Time = time;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace Tets
{
    class Program
    {
        internal class Edge
        {
            public int First { get; set; }

            public int Second { get; set; }

            public int Weight { get; set; }
        }

        public static Dictionary<int, List<Edge>> graph;

        static void Main(string[] args)
        {
            var edgesNumber = int.Parse(Console.ReadLine());

            graph = ReadGraph(edgesNumber);

            var start = int.Parse(Console.ReadLine());
            var end = int.Parse(Console.ReadLine());

            var maxKey = graph.Keys.Max();
            var distances = new int[maxKey + 1];
            var prev = new int[maxKey + 1];
            Fill(distances, int.MaxValue, maxKey+1);
            distances[start] = 0;
            prev[0] = -1 ;
            var queue = new OrderedBag<int>(Comparer<int>.Create((f, s) => distances[f] - distances[s]));

            queue.Add(start);

            while (queue.Count > 0)
            {
                var minEdge = queue.RemoveFirst();

                if (minEdge == end)
                {
                    break;
                }

                foreach (var child in graph[minEdge])
                {
                    var actualChild = minEdge == child.First ? child.Second : child.First;
                    var actualChildWeight = child.Weight + distances[minEdge];
                    if (distances[actualChild] == int.MaxValue)
                    {
                        queue.Add(actualChild);
                    }

                    if (distances[actualChild] > actualChildWeight)
                    {
                        distances[actualChild] = actualChildWeight;
                        prev[actualChild] = minEdge;
                        queue = new OrderedBag<int>(queue, Comparer<int>.Create((f, s) => distances[f] - distances[s]));
                    }
                }
            }
            Console.WriteLine(distances[end]);
            Decode(end, prev);
        }

        private static void Fill(int[] distances, int maxValue,int times)
        {
            for (int i = 0; i < times; i++)
            {
                distances[i] = int.MaxValue;
            }
        }

        private static void Decode(int end, int[] prev)
        {

            var stack = new Stack<int>();
            
            var cur = end;
            while (cur != -1)
            {
                stack.Push(cur);
                cur = prev[cur];
            }
            Console.WriteLine(string.Join(" ", stack));
        }

        private static Dictionary<int, List<Edge>> ReadGraph(int edgesNumber)
        {
            var dic = new Dictionary<int, List<Edge>>();

            for (int i = 0; i < edgesNumber; i++)
            {
                var line = Console.ReadLine().Split(new char[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
                var start = line[0];
                var end = line[1];
                var weight = line[2];

                var edge = new Edge()
                {
                    First = start,
                    Second = end,
                    Weight = weight,
                };

                if (!dic.ContainsKey(start))
                {
                    dic[start] = new List<Edge>();
                }

                if (!dic.ContainsKey(end))
                {
                    dic[end] = new List<Edge>();
                }

                dic[start].Add(edge);
            }

            return dic;
        }
    }
}

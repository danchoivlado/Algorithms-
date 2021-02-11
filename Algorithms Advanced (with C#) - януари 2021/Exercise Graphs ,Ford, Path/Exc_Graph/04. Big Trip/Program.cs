using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace _04._Big_Trip
{
    internal class Node
    {
        public int From { get; set; }

        public int To { get; set; }

        public int Time { get; set; }

        public Node(int from, int to, int time)
        {
            From = from;
            To = to;
            Time = time;
        }
    }

    class Program
    {
        public static List<Node>[] graph;
        public static Stack<int> topologicalSort;

        static void Main(string[] args)
        {
            var numNodes = int.Parse(Console.ReadLine());
            var numEdges = int.Parse(Console.ReadLine());
            graph = ReadGraph(numNodes+1, numEdges);
            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            topologicalSort = SortTopologicaly();

            var distances = new double[numEdges];
            Array.Fill(distances,double.NegativeInfinity);
            distances[source] = 0;
            var prev = new int[graph.Length];
            Array.Fill(prev, -1);

            while (topologicalSort.Count > 0)
            {
                var curNode = topologicalSort.Pop();

                foreach (var children in graph[curNode])
                {
                    var newDistance = distances[curNode] + children.Time;
                    if (distances[children.To] < newDistance)
                    {
                        distances[children.To] = newDistance;
                        prev[children.To] = curNode;
                    }
                }
            }

            var path = GenRes(prev, destination);

            Console.WriteLine(distances[destination]);
            Console.WriteLine(string.Join(" ", path));
        }

        private static Stack<int> SortTopologicaly()
        {
            var stack = new Stack<int>();
            var visited = new bool[graph.Length]; 

            for (int i = 1; i < graph.Length; i++)
            {
                DFS(i, visited, stack);
            }

            return stack;
        }

        private static void DFS(int node, bool[] visited, Stack<int> sorted)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child.To, visited, sorted);
            }
            sorted.Push(node);
        }


        private static Stack<int> GenRes(int[] prev, int source)
        {
            var stack = new Stack<int>();
            while (source != -1)
            {
                stack.Push(source);
                source = prev[source];
            }

            return stack;
        }
        

        private static List<Node>[] ReadGraph(int numNode, int numEdges)
        {
            var res = GenArr(numNode);

            for (int i = 0; i < numEdges; i++)
            {
                var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var from = line[0];
                var to = line[1];
                var time = line[2];
                var node = new Node(from, to, time);
                res[from].Add(node);
            }

            return res;
        }

        private static List<Node>[] GenArr(int numNode)
        {
            var res = new List<Node>[numNode];

            for (int i = 1; i < numNode; i++)
            {
                res[i] = new List<Node>();
            }

            return res;
        }
    }
}

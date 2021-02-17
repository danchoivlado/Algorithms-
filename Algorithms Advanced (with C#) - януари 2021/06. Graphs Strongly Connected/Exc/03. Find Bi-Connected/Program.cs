using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading;

namespace _03._Find_Bi_Connected
{
    class Program
    {
        public static List<int>[] graph;
        public static int[] parents;
        public static bool[] visited;
        public static int[] lowPoints;
        public static int[] depths;
        public static List<int> articulationPoints;
        public static Stack<int> stack;
        public static List<HashSet<int>> components;

        static void Main(string[] args)
        {
            var numNodes = int.Parse(Console.ReadLine());
            var numEdges = int.Parse(Console.ReadLine());

            graph = ReadGraph(numNodes, numEdges);
            lowPoints = new int[numNodes];
            depths = new int[numNodes];
            visited = new bool[numNodes];
            articulationPoints = new List<int>();

            parents = new int[numNodes];
            Array.Fill(parents, -1);
            stack = new Stack<int>();
            components = new List<HashSet<int>>();

            for (int node = 0; node < numNodes; node++)
            {
                if (!visited[node])
                {
                    FindArticulationPoint(node, 0);

                    var component = new HashSet<int>();
                    while (stack.Count > 1)
                    {
                        var childNode = stack.Pop();
                        var parentNode = stack.Pop();

                        component.Add(parentNode);
                        component.Add(childNode);
                    }
                    components.Add(component);
                }
            }

            Console.WriteLine($"Number of bi-connected components: {components.Count}");
        }

        private static void FindArticulationPoint(int node, int depth)
        {
            depths[node] = depth;
            lowPoints[node] = depth;
            visited[node] = true;

            var childsCount = 0;

            foreach (var child in graph[node])
            {
                if (!visited[child])
                {
                    stack.Push(node);
                    stack.Push(child);

                    parents[child] = node;
                    childsCount += 1;
                    FindArticulationPoint(child, depth + 1);

                    if ((parents[node] == -1 && childsCount > 1)
                        || (parents[node] != -1  && 
                        lowPoints[child] >= depth))
                    {
                        var component = new HashSet<int>();
                        while (true)
                        {
                            var childNode = stack.Pop();
                            var parentNode = stack.Pop();

                            component.Add(parentNode);
                            component.Add(childNode);

                            if (childNode == child && parentNode == node)
                            {
                                break;
                            }
                        }
                        components.Add(component);
                    }

                    lowPoints[node] = Math.Min(lowPoints[node], lowPoints[child]);
                }
                else if (parents[node] != child && lowPoints[node] > depths[child])
                {
                    lowPoints[node] = depths[child];

                    stack.Push(node);
                    stack.Push(child);
                }
            }
        }

        private static List<int>[] ReadGraph(int numNodes, int numEdges)
        {
            var result = new List<int>[numNodes];

            for (int i = 0; i < numNodes; i++)
            {
                result[i] = new List<int>();
            }

            for (int i = 0; i < numEdges; i++)
            {
                var line = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var parent = line[0];
                var child = line[1];
                result[parent].Add(child);
                result[child].Add(parent);
            }

            return result;
        }
    }
}

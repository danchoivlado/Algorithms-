using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;

namespace _03._Articulation_Points
{
    class Program
    {
        public static List<int>[] graph;
        public static int[] depths;
        public static int[] lowpoints;
        public static int[] parents;
        public static bool[] visited;
        public static List<int> articulationPoints;

        static void Main(string[] args)
        {
            var numNodes = int.Parse(Console.ReadLine());
            var numLines = int.Parse(Console.ReadLine());
            graph = ReadGraph(numNodes, numLines);
            depths = new int[numNodes];
            lowpoints = new int[numNodes];
            parents = new int[numNodes];
            visited = new bool[numNodes];
            articulationPoints = new List<int>();
            Array.Fill(parents, -1);

            for (int i = 0; i < numNodes; i++)
            {
                if (!visited[i])
                {
                    FindArticulationPoints(i, 1);
                }
            }

            Console.WriteLine($"Articulation points: {string.Join(", ", articulationPoints)}");
        }

        private static void FindArticulationPoints(int node, int depth)
        {
            depths[node] = depth;
            visited[node] = true;
            lowpoints[node] = depth;
            var childsCount = 0;
            var isArticulationPoint = false;

            foreach (var child in graph[node])
            {
                if (!visited[child])
                {
                    parents[child] = node;
                    FindArticulationPoints(child, depth + 1);
                    childsCount += 1;
                    if (lowpoints[child] >= depths[node])
                    {
                        isArticulationPoint = true;
                    }
                    lowpoints[node] = Math.Min(lowpoints[child], lowpoints[node]); //TRY WIth Depth
                }
                else if(parents[child] != node)
                {
                    lowpoints[node] = Math.Min(lowpoints[node], depths[child]);// Zashtoto moje samo edin backage
                }
            }

            if ((parents[node] != -1 && isArticulationPoint)
                || (parents[node] == -1) && childsCount > 1)
            {
                articulationPoints.Add(node);
            }
        }

        private static List<int>[] ReadGraph(int numNodes, int numLines)
        {
            var result = new List<int>[numNodes];

            for (int i = 0; i < numNodes; i++)
            {
                result[i] = new List<int>();
            }

            for (int i = 0; i < numLines; i++)
            {
                var line = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                var parent = line[0];
                for (int j = 1; j < line.Length; j++)
                {
                    var child = line[j];
                    result[parent].Add(child);
                }
            }

            return result;
        }
    }
}

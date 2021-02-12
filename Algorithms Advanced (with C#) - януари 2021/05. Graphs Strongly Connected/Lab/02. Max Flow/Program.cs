using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Transactions;

namespace _02._Max_Flow
{
    class Program
    {
        private static int[,] matrix;
        private static int[] path;

        static void Main(string[] args)
        {
            var numberNodes = int.Parse(Console.ReadLine());
            matrix = ReadMatrix(numberNodes);
            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());
            MaxFlow(source, destination);
        }

        private static void MaxFlow(int source, int destination)
        {
            path = new int[matrix.GetLength(1)];
            path[source] = -1;
            var overAllMaxFlow = 0;
            while (BFS(source, destination))
            {
                var currentMaxFlow = ReconstructPath(source, destination);

                overAllMaxFlow += currentMaxFlow;

                RealxAllPathMembers(currentMaxFlow, source, destination);
            }

            Console.WriteLine($"Max flow = {overAllMaxFlow}");
        }

        private static void RealxAllPathMembers(int currentMaxFlow, int source, int destination)
        {
            while (destination != source)
            {
                var parent = path[destination];
                var child = destination;
                matrix[parent, child] -= currentMaxFlow;
                
                destination = parent;
            }
        }

        private static int ReconstructPath(int source, int destination)
        {
            var maxFlow = int.MaxValue;
            while (destination != source)
            {
                var parent = path[destination];
                var child = destination;
                var curFlow = matrix[parent, child];
                if (maxFlow > curFlow)
                {
                    maxFlow = curFlow;
                }

                destination = parent;
            }

            return maxFlow;
        }

        private static bool BFS(int source, int destination)
        {
            var queue = new Queue<int>();
            var visited = new bool[matrix.GetLength(1)];
            queue.Enqueue(source);
            visited[source] = true;

            while (queue.Count > 0)
            {
                var parentNode = queue.Dequeue();

                for (int child = 0; child < matrix.GetLength(1); child++)
                {
                    if (matrix[parentNode, child] > 0 && !visited[child])
                    {
                        queue.Enqueue(child);
                        visited[child] = true;
                        path[child] = parentNode;
                    }
                }
            }

            return visited[destination] ? true : false;
        }

        private static int[,] ReadMatrix(int numberNodes)
        {
            var result = new int[numberNodes, numberNodes];

            for (int node = 0; node < numberNodes; node++)
            {
                var capacities = Console.ReadLine()
                    .Split(", ")
                    .Select(int.Parse)
                    .ToArray();

                for (int child = 0; child < capacities.Length; child++)
                {
                    result[node, child] = capacities[child];
                }
            }

            return result;
        }
    }
}

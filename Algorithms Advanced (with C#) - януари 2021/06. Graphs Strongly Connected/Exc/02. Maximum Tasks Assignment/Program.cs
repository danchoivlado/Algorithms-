using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Reflection.Metadata;

namespace _02._Maximum_Tasks_Assignment
{
    class Program
    {
        public static int[,] graph;
        public static int[] parents;

        static void Main(string[] args)
        {
            var people = int.Parse(Console.ReadLine());
            var tasks = int.Parse(Console.ReadLine());
            graph = ReadGraph(people, tasks);

            var start = 0;
            var end = graph.GetLength(1) - 1;
            parents = new int[graph.GetLength(1)];
            Array.Fill(parents, -1);

            while (BFS(start, end))
            {
                var node = end;
                while (node != start)
                {
                    var parent = parents[node];
                    graph[parent, node] = 0;
                    graph[node, parent] = 1;

                    node = parent;
                }
            }
            for (int person = 1; person <= people; person++)
            {
                for (int task = people + 1; task <= people + tasks; task++)
                {
                    if (graph[task, person] == 1)
                    {
                        Console.WriteLine($"{(char) (64+person)}-{task - people}");
                    }
                }
            }
        }

        private static bool BFS(int start, int end)
        {
            var visited = new bool[graph.GetLength(0)];
            var queue = new Queue<int>();
            queue.Enqueue(start);
            visited[start] = true;

            while (queue.Count > 0)
            {
                var curNode = queue.Dequeue();
                for (int child = 0; child < graph.GetLength(1); child++)
                {
                    if (curNode == end)
                    {
                        return true;
                    }
                    if (!visited[child] && graph[curNode, child] > 0)
                    {
                        parents[child] = curNode;
                        visited[child] = true;
                        queue.Enqueue(child);
                    }
                }
            }

            return false;
        }

        private static int[,] ReadGraph(int people, int tasks)
        {
            var nodes = people + tasks + 2;
            var start = 0;
            var end = nodes - 1;
            var result = new int[nodes, nodes];

            for (int a = 1; a <= people; a++)
            {
                result[start, a] = 1;
            }

            for (int task = people + 1; task <= tasks + people; task++)
            {
                result[task, end] = 1;
            }

            for (int i = 1; i <= people; i++)
            {
                var line = Console.ReadLine();
                for (int task = 0; task < line.Length; task++)
                {
                    if (line[task] == 'Y')
                    {
                        result[i, people + 1 + task] = 1;
                    }
                }
            }

            return result;
        }

        public static void Print(int[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col] + " ");
                }

                Console.WriteLine();
            }
        }
    }
}

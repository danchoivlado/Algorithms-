using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Salaries
{
    class Program
    {
        public static List<int>[] graph;
        public static bool[] visited;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            graph = ReadGraph(n);

            visited = new bool[n];

            var res = 0;
            for (int i = 0; i < graph.Length; i++)
            {
                res+= DFS(i);
            }
            Console.WriteLine(res);
        }

        private static int DFS(int startNode, int sum = 0)
        {
            visited[startNode] = true;

            if (graph[startNode].Count <= 0)
            {
                return 1;
            }

            var salary = 0;
            foreach (var child in graph[startNode])
            {
                salary += DFS(child);
            }

            return salary;
        }


        private static List<int>[] ReadGraph(int n)
        {
            var res = new List<int>[n];
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = new List<int>();
            }


            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine();

                for (int r = 0; r < line.Length; r++)
                {
                    if (line[r] == 'Y')
                    {
                        res[i].Add(r);
                    }
                }
            }

            return res;
        }
    }
}

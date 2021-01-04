using System;
using System.Collections.Generic;
using System.Linq;

namespace _03_Path_Finder
{
    class Program
    {
        public static List<int>[] graph;
        public static List<List<int>> paths;
        public static string res;

        static void Main(string[] args)
        {
            var nodes = int.Parse(Console.ReadLine());
            graph = ReadGraph(nodes);

            var pathsNumber = int.Parse(Console.ReadLine());
            paths = ReadPaths(pathsNumber);

            foreach (var path in paths)
            {
                res = "";
                DFS(path[0], path[path.Count - 1], 0, path);
                Console.WriteLine(res);
            }
        }

        private static void DFS(int start, int end, int index, List<int> path)
        {
            if (!graph[start].Contains(path[index + 1]))
            {
                res = "no";
                return;
            }

            if (graph[start].Contains(end) && index == path.Count() - 2)
            {
                res = "yes";
                return;
            }

            DFS(path[index + 1], end, index + 1, path);
        }

        private static List<List<int>> ReadPaths(int pathsNumber)
        {
            var res = new List<List<int>>();

            for (int i = 0; i < pathsNumber; i++)
            {
                var line = Console.ReadLine().Split().Select(int.Parse).ToList();
                res.Add(line);
            }

            return res;
        }

        private static List<int>[] ReadGraph(int nodes)
        {
            var res = new List<int>[nodes];
            GenLists(ref res);

            for (int i = 0; i < nodes; i++)
            {
                var line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    continue;
                }

                var children = line.Split().Select(int.Parse).ToList();
                res[i].AddRange(children);
            }

            return res;
        }

        private static void GenLists(ref List<int>[] res)
        {
            for (int i = 0; i < res.Length; i++)
            {
                res[i] = new List<int>();
            }
        }
    }
}

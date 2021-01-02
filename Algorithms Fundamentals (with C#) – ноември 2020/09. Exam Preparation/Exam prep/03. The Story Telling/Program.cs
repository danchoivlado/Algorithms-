using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._The_Story_Telling
{
    class Program
    {
        public static Dictionary<string, List<string>> graph;
        public static Dictionary<string, int> dependencies;

        static void Main(string[] args)
        {
            ReadGraph();
            dependencies = GenDependecies();
            Console.WriteLine(TopologicalSort());

        }

        private static string TopologicalSort()
        {
            var res = new List<string>();

            while (dependencies.Count > 0)
            {
                string nodeDelete;
                if (dependencies.Where(x => x.Value == 0).Count() > 1)
                {
                    nodeDelete = dependencies.LastOrDefault(x => x.Value == 0).Key;
                }
                else
                {
                    nodeDelete = dependencies.FirstOrDefault(x => x.Value == 0).Key;
                }
                res.Add(nodeDelete);

                foreach (var child in graph[nodeDelete])
                {
                    dependencies[child]--;
                }

                dependencies.Remove(nodeDelete);
            }

            return string.Join(" ", res);
        }

        private static Dictionary<string, int> GenDependecies()
        {
            var res = new Dictionary<string, int>();
            foreach (var key in graph.Keys)
            {
                res.Add(key, 0);
            }
            var visited = new HashSet<string>();

            foreach (var node in graph.Keys)
            {
                foreach (var child in graph[node])
                {
                    visited.Add(child);
                    res[child]++;
                }
            }

            return res;
        }

        private static void ReadGraph()
        {
            graph = new Dictionary<string, List<string>>();
            while (true)
            {
                var line = Console.ReadLine().Split("->").ToArray();
                if (line[0] == "End")
                {
                    break;
                }

                var node = line[0].Trim();

                List<string> children = new List<string>();
                if (line.Count() != 0)
                {
                    children = line[1]
                        .Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                        .ToList();
                }

                if (!graph.ContainsKey(node))
                {
                    graph.Add(node, new List<string>());
                }

                graph[node].AddRange(children);
            }
        }
    }
}

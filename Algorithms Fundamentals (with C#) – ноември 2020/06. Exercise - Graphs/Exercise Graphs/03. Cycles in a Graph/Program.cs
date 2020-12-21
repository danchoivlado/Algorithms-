using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Cycles_in_a_Graph
{
    class Program
    {
        public static Dictionary<char, List<char>> graph;
        public static HashSet<char> visited;
        public static Dictionary<char, int> dependancies;

        static void Main(string[] args)
        {
            ReadGraph();
            GenerateDependacies();

            Console.WriteLine($"Acyclic: {CheckCyclis()}");
        }

        private static void GenerateDependacies()
        {
            dependancies = new Dictionary<char, int>();
            foreach (var node in graph.Keys)
            {
                if (!dependancies.ContainsKey(node))
                {
                    dependancies.Add(node, 0);
                }
                foreach (var child in graph[node])
                {
                    if (!dependancies.ContainsKey(child))
                    {
                        dependancies.Add(child, 0);
                    }

                    dependancies[child]++;
                }
            }

        }

        private static string CheckCyclis()
        {
            while (dependancies.Count > 0)
            {
                var nodeDelete = dependancies.FirstOrDefault(x => x.Value == 0).Key;

                if (nodeDelete == default(char))
                {
                    return "No";
                }
                dependancies.Remove(nodeDelete);
                if (!graph.ContainsKey(nodeDelete))
                    continue;
                foreach (var child in graph[nodeDelete])
                {
                    dependancies[child]--;
                }
            }

            return "Yes";
        }

        private static void ReadGraph()
        {
            var line = Console.ReadLine().Split('-').ToArray();
            graph = new Dictionary<char, List<char>>();

            while (line[0] != "End")
            {
                var node = char.Parse(line[0]);
                if (!graph.ContainsKey(node))
                {
                    graph.Add(node, new List<char>());
                }

                graph[node].Add(char.Parse(line[1]));
                line = Console.ReadLine().Split('-').ToArray();
            }
        }
    }
}

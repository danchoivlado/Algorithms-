using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02._Source_Removal_Topological_Sorting
{
    class Program
    {
        public static Dictionary<string, List<string>> graph;
        public static Dictionary<string, int> dependancies;
        public static bool Is = false;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            graph = ReadGraph(n);
            dependancies = SortGraph();
            var res = GenRes();

            if (Is)
            {
                Console.WriteLine("Invalid topological sorting");
                return;
            }

            Console.WriteLine($"Topological sorting: {string.Join(", ",res)}");

        }

        private static List<string> GenRes()
        {
            var lis = new List<string>();

            while (dependancies.Count > 0)
            {
                var nodeDelete = dependancies.FirstOrDefault(x => x.Value == 0);


                if (string.IsNullOrEmpty(nodeDelete.Key))
                {
                    Is = true;
                    break;
                }

                foreach (var child in graph[nodeDelete.Key])
                {
                    dependancies[child]--;
                }

                dependancies.Remove(nodeDelete.Key);
                lis.Add(nodeDelete.Key);
            }

            return lis;
        }

        private static Dictionary<string, int> SortGraph()
        {
            var result = new Dictionary<string, int>();

            foreach (var kvp in graph)
            {
                var node = kvp.Key;
                var nodeChildren = kvp.Value;

                if (!result.ContainsKey(node))
                {
                    result.Add(node, 0);
                }

                foreach (var child in nodeChildren)
                {
                    if (!result.ContainsKey(child))
                    {
                        result.Add(child, 1);
                    }
                    else
                    {
                        result[child]++;
                    }
                }
            }

            return result;
        }

        private static Dictionary<string, List<string>> ReadGraph(int n)
        {
            var result = new Dictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                var line = Console.ReadLine()
                    .Split(new[] { '-', '>'}, StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var node = line[0].Trim();
                if (line.Length <= 1)
                {
                    result.Add(node, new List<string>());
                    continue;
                }

                
                var childrenNodes = line[1]
                    .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                result.Add(node, childrenNodes);
            }

            return result;
        }
    }
}

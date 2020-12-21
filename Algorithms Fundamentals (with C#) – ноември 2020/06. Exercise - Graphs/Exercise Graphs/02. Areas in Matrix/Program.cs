using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Areas_in_Matrix
{
    class Program
    {
        internal class Node
        {
            public int row { get; set; }

            public int col { get; set; }
        }

        public static char[,] matrix;
        public static bool[,] visited;
        public static Dictionary<char, int> areas;

        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            matrix = ReadMatrix(rows, cols);
            visited = new bool[rows, cols];
            areas = new Dictionary<char, int>();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (!visited[row, col])
                    {
                        DFS(row, col, matrix[row, col]);
                        if (!areas.ContainsKey(matrix[row, col]))
                        {
                            areas.Add(matrix[row, col], 0);
                        }
                        areas[matrix[row, col]]++;
                    }
                }
            }

            Console.WriteLine($"Areas: {areas.Values.Sum()}");
            foreach (var area in areas.OrderBy(x => x.Key))
            {
                Console.WriteLine($"Letter '{area.Key}' -> {area.Value}");
            }
        }

        private static void DFS(int row, int col, char startedArea)
        {
            if (OutsideMatrix(row, col))
            {
                return;
            }

            if (visited[row, col] || matrix[row, col] != startedArea)
            {
                return;
            }

            visited[row, col] = true;
            var children = GetChildren(row, col);

            foreach (var node in children)
            {
                DFS(node.row, node.col, startedArea);
            }
        }

        private static bool OutsideMatrix(int row, int col)
        {
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
                return true;

            return false;
        }

        private static List<Node> GetChildren(int row, int col)
        {
            var res = new List<Node>();
            res.Add(new Node { row = row - 1, col = col });
            res.Add(new Node { row = row + 1, col = col });
            res.Add(new Node { row = row, col = col - 1 });
            res.Add(new Node { row = row, col = col + 1 });

            return res;
        }

        private static char[,] ReadMatrix(int rows, int cols)
        {
            var res = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    res[row, col] = line[col];
                }
            }

            return res;
        }
    }
}

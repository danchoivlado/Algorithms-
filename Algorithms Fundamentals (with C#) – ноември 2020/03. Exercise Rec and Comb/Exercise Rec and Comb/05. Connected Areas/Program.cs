using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Connected_Areas
{
    class Program
    {
        internal class Area
        {
            public int StartRow { get; set; }

            public int StartCol { get; set; }

            public int Size { get; set; }
        }

        static bool[,] visitedArea;
        static char[,] matrix;
        static int curSize;

        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());
            matrix = new char[rows, cols];
            visitedArea = new bool[rows, cols];
            var areas = new List<Area>();

            matrix = ReadMatrix(rows, matrix);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] == '*')
                    {
                        continue;
                    }

                    if (visitedArea[row, col])
                    {
                        continue;
                    }
                    curSize = 0;
                    CalculateSize(row, col);

                    var area = new Area()
                    {
                        StartRow = row,
                        StartCol = col,
                        Size = curSize,
                    };
                    areas.Add(area);
                    curSize = 0;
                }
            }

            areas = areas.OrderByDescending(x => x.Size)
                .ThenBy(x => x.StartRow)
                .ThenBy(x => x.StartCol)
                .ToList();

            var number = 1;
            Console.WriteLine($"Total areas found: {areas.Count}");
            foreach (var area in areas)
            {
                Console.WriteLine($"Area #{number} at ({area.StartRow}, {area.StartCol}), size: {area.Size}");
                number++;
            }
        }

        private static void CalculateSize(int row, int col)
        {
            if (Outsude(row, col) || visitedArea[row, col] || matrix[row, col] == '*')
            {
                return;
            }

            visitedArea[row, col] = true;
            curSize += 1;

            CalculateSize(row, col - 1); //LEFT
            CalculateSize(row, col + 1); //RIGHT
            CalculateSize(row + 1, col); //UP
            CalculateSize(row - 1, col); //DOWN
        }

        private static bool Outsude(int row, int col)
        {
            if (col < 0 || col >= matrix.GetLength(1) ||
                row < 0 || row >= matrix.GetLength(0))
            {
                return true;
            }

            return false;
        }

        private static void PrintMatrix(int rows, int cols, char[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static char[,] ReadMatrix(int rows, char[,] matrix)
        {
            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine();
                for (int col = 0; col < line.Length; col++)
                {
                    matrix[row, col] = line[col];
                }
            }
            return matrix;
        }
    }
}

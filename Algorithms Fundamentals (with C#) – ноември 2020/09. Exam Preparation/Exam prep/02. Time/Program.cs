using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Time
{
    class Program
    {
        public static int[,] matrix;

        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine().Split().ToArray();
            var secondLine = Console.ReadLine().Split().ToArray();

            matrix = new int[firstLine.Length + 1, secondLine.Length + 1];
            FillMatrix(firstLine, secondLine);


            DecodeMatrix(firstLine, secondLine);
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static void DecodeMatrix(string[] firstLine, string[] secondLine)
        {
            var count = matrix[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];

            var res = new Stack<string>();
            var curRow = matrix.GetLength(0) - 1;
            var curCol = matrix.GetLength(1) - 1;

            while (curCol > 0 && curRow > 0)
            {
                if (firstLine[curRow - 1] == secondLine[curCol - 1])
                {
                    res.Push(firstLine[curRow - 1]);
                    curRow--;
                    curCol--;
                    continue;
                }

                var up = matrix[curRow - 1, curCol];
                var left = matrix[curRow, curCol - 1];

                if (up > left)
                {
                    curRow--;
                }
                else
                {
                    curCol--;
                }
            }

            Console.WriteLine(string.Join(" ", res));
            Console.WriteLine(res.Count);
        }

        private static void FillMatrix(string[] firstLine, string[] secondLine)
        {
            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if (firstLine[row - 1] == secondLine[col - 1])
                    {
                        var diagonal = matrix[row - 1, col - 1];
                        matrix[row, col] = diagonal + 1;
                        continue;
                    }

                    var up = matrix[row - 1, col];
                    var left = matrix[row, col - 1];
                    var result = Math.Max(up, left);

                    matrix[row, col] = result;
                }
            }
        }
    }
}

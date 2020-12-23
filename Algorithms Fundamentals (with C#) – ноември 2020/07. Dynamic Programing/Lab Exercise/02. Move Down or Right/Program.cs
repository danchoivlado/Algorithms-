using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Move_Down_or_Right
{
    class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var matrix = new int[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            var sumsMatrix = new int[rows, cols];

            sumsMatrix[0, 0] = matrix[0, 0];

            for (int col = 1; col < cols; col++) // right line
            {
                var numMatrix = matrix[0, col]; //current number in old matrix
                var prevNumSums = sumsMatrix[0, col - 1]; //current number in curent matrix
                sumsMatrix[0, col] = numMatrix + prevNumSums;
            }

            for (int row = 1; row < rows; row++)
            {
                var prevSumMatrix = sumsMatrix[row - 1, 0];
                var currMatrix = matrix[row, 0];
                sumsMatrix[row, 0] = prevSumMatrix + currMatrix;
            }

            for (int row = 1; row < rows; row++)
            {
                for (int col = 1; col < cols; col++)
                {
                    var right = sumsMatrix[row - 1, col];
                    var down = sumsMatrix[row, col - 1];

                    var bigger = Math.Max(right, down);
                    var curMatrix = matrix[row, col];
                    sumsMatrix[row, col] = bigger + curMatrix;
                }
            }

            var curRow = rows - 1;
            var curCol = cols - 1;
            var endRes = new Stack<string>();
            while (curRow != 0 || curCol != 0)
            {
                var left = -1;
                if (curCol - 1 >= 0)
                {
                    left = sumsMatrix[curRow, curCol - 1];
                }

                var up = -1;
                if (curRow - 1 >= 0)
                {
                    up = sumsMatrix[curRow - 1, curCol];
                }

                if (left >= up)
                {
                    endRes.Push($"[{curRow}, {curCol}]");
                    curCol -= 1;
                }
                else
                {
                    endRes.Push($"[{curRow}, {curCol }]");
                    curRow -= 1;
                }
            }

            Console.WriteLine($"[0, 0] {string.Join(" ", endRes)}");
            
        }
    }
}

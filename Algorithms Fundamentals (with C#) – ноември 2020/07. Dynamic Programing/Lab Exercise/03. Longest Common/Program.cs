using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Longest_Common
{
    class Program
    {
        static void Main(string[] args)
        {
            var first = Console.ReadLine();
            var second = Console.ReadLine();
            var lcs = new int[first.Length + 1, second.Length + 1];

            for (int row = 1; row < lcs.GetLength(0); row++)
            {
                for (int col = 1; col < lcs.GetLength(1); col++)
                {
                    var up = lcs[row - 1, col];
                    var left = lcs[row, col - 1];
                    var result = Math.Max(up, left);

                    if (first[row - 1] == second[col - 1])
                    {
                        result = Math.Max(lcs[row - 1, col - 1] + 1,result);
                    }

                    lcs[row, col] = result;
                }
            }

            for (int row = 0; row < lcs.GetLength(0); row++)
            {
                for (int col = 0; col < lcs.GetLength(1); col++)
                {
                    Console.Write(lcs[row, col]);
                }
                Console.WriteLine();
            }

            var curRow = lcs.GetLength(0) - 1;
            var curCol = lcs.GetLength(1) - 1;

            var endRes = new Stack<char>();
            while (curCol != 0 && curRow != 0)
            {
                var up = -1;
                if (curRow - 1 >= 0)
                    up = lcs[curRow - 1, curCol];

                var left = -1;
                if (curCol - 1 >= 0)
                    left = lcs[curRow, curCol - 1];

                if (first[curRow - 1] == second[curCol - 1]
                    && lcs[curRow, curCol] - 1 == lcs[curRow - 1, curCol - 1])
                {
                    endRes.Push(first[curRow - 1]);
                    curCol--;
                    curRow--;
                }
                else if (up >= left)
                {
                    curRow--;
                }
                else
                {
                    curCol--;
                }
            }
            Console.WriteLine(endRes.Count);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace _04._Longest_Zigzag
{
    class Program
    {
        public static int[] numbers;
        public static int[,] dp;
        public static int[,] parent;

        static void Main(string[] args)
        {
            numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            dp = new int[2, numbers.Length];
            dp[0, 0] = 1;
            dp[1, 0] = 1;

            parent = new int[2, numbers.Length];
            parent[0, 0] = -1;
            parent[1, 0] = -1;

            LisAlg();
        }

        private static void LisAlg()
        {
            var bestLen = 0;
            var lastCol = 0;
            var lastRow = 0;

            for (int curIdx = 0; curIdx < numbers.Length; curIdx++)
            {
                var curNumber = numbers[curIdx];

                for (int prevIdx = curIdx - 1; prevIdx >= 0; prevIdx--)
                {
                    var prevNumber = numbers[prevIdx];

                    if (prevNumber < curNumber 
                        && dp[1,prevIdx] + 1 >= dp[0, curIdx])
                    {
                        dp[0, curIdx] = dp[1, prevIdx] +1;
                        parent[0, curIdx] = prevIdx;
                    }

                    if (prevNumber > curNumber 
                        && dp[0, prevIdx] + 1>= dp[1, curIdx])
                    {
                        dp[1, curIdx] = dp[0, prevIdx] + 1;
                        parent[1, curIdx] = prevIdx;
                    }
                }

                if (dp[0, curIdx] > bestLen)
                {
                    bestLen = dp[0, curIdx];
                    lastCol = curIdx;
                    lastRow = 0;
                }

                if (dp[1, curIdx] > bestLen)
                {
                    bestLen = dp[1, curIdx];
                    lastCol = curIdx;
                    lastRow = 1;
                }
            }

            var zigZag = new Stack<int>();

            while (lastCol != -1)
            {
                zigZag.Push(numbers[lastCol]);
                lastCol = parent[lastRow, lastCol];

                if (lastRow == 0)
                {
                    lastRow = 1;
                }
                else
                {
                    lastRow = 0;
                }
            }

            Console.WriteLine(string.Join(" ", zigZag));
        }
    }
}

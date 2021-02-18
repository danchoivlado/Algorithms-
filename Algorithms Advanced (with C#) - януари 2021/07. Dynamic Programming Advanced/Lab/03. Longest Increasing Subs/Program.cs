using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

namespace _03._Longest_Increasing_Subs
{
    class Program
    {
        public static int[] numbers;
        public static int[] lis;
        public static int[] prev;

        static void Main(string[] args)
        {
            numbers = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();
            lis = new int[numbers.Length];
            prev = new int[numbers.Length];
            Array.Fill(prev, -1);

            var lastIdx = LISAlg();
            Print(lastIdx);
        }

        private static void Print(int lastIdx)
        {
            var stack = new Stack<int>();
            stack.Push(numbers[lastIdx]);

            while (prev[lastIdx] != -1)
            {
                lastIdx = prev[lastIdx];
                stack.Push(numbers[lastIdx]);

            }

            Console.WriteLine(string.Join(" ", stack));
        }

        private static int LISAlg()
        {
            var bestLen = 0;
            var lastidx = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                var curNumber = numbers[i];
                var curMaxSubs = 1;

                for (int j = i - 1; j >= 0; j--)
                {
                    var prevNumber = numbers[j];

                    if (curNumber > prevNumber &&
                        lis[j] + 1 >= curMaxSubs )
                    {
                        curMaxSubs = lis[j] + 1;
                        prev[i] = j;
                    }
                }

                if (bestLen < curMaxSubs)
                {
                    bestLen = curMaxSubs;
                    lastidx = i;
                }
                
                lis[i] = curMaxSubs;
            }

            ;

            return lastidx;
        }
    }
}

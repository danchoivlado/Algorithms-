using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace _03._Longest_String_Chain
{
    class Program
    {
        public static string[] words;
        public static int[] lisArr;
        public static int[] prev; 

        static void Main(string[] args)
        {
            words = Console.ReadLine().Split().ToArray();
            lisArr = new int[words.Length];
            prev = new int[words.Length];

            var longestIndex = LISAlg();
            Print(longestIndex);
        }

        private static void Print(int longestIndex)
        {
            var stack = new Stack<string>();

            while (longestIndex != -1) 
            {
                stack.Push(words[longestIndex]);
                longestIndex = prev[longestIndex];
            }

            Console.WriteLine(string.Join(" ", stack));
        }

        private static int LISAlg()
        {
            var longest = 0;
            var longestIndex = 0;
            for (int wordIndex = 0; wordIndex < words.Length; wordIndex++)
            {
                var curWord = words[wordIndex];
                var lis = 1;
                prev[wordIndex] = -1;

                for (int i = wordIndex - 1; i >= 0; i--)
                {
                    if (curWord.Length > words[i].Length && lisArr[i] + 1 >= lis)
                    {
                        prev[wordIndex] = i;
                        lis = lisArr[i] + 1;
                    }
                }

                if (lis > longest)
                {
                    longest = lis;
                    longestIndex = wordIndex;
                }
                lisArr[wordIndex] = lis;
            }

            return longestIndex;
        }
    }
}

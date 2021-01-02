using System;
using System.Collections.Generic;

namespace _01._Two_Minutes
{
    class Program
    {
        public static Dictionary<string, long> cache;

        static void Main(string[] args)
        {
            var first = int.Parse(Console.ReadLine());
            var second = int.Parse(Console.ReadLine());
            cache = new Dictionary<string, long>();
            Console.WriteLine(FindBinom(first, second));
        }

        private static long FindBinom(int row, int col)
        {
            string st = $"{row} {col}";

            if (col <= 0 || col == row)
            {
                return 1;
            }

            if (cache.ContainsKey(st))
            {
                return cache[st];
            }
            long sum = 0;
            sum = FindBinom(row - 1, col - 1) + FindBinom(row - 1, col);


            cache.Add(st, sum);

            return sum;
        }
    }
}

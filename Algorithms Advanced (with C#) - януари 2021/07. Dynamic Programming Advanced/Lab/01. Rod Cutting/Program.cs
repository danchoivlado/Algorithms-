using System;
using System.Dynamic;
using System.Linq;

namespace _01._Rod_Cutting
{
    class Program
    {
        public static int[] bestPrices;
        public static int[] combo;

        static void Main(string[] args)
        {
            var prices = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var length = int.Parse(Console.ReadLine());
            bestPrices = new int[length + 1];
            combo = new int[length + 1];

            Console.WriteLine(CutRod(length, prices));

            while (combo[length] != 0)
            {
                Console.Write($"{combo[length]} ");
                length -= combo[length];
            }
        }

        private static int CutRod(int length, int[] prices)
        {
            if (length == 0)
            {
                return 0;
            }

            if (bestPrices[length] != 0)
            {
                return bestPrices[length];
            }

            var bestPrice = prices[length];
            var curcombo = length;
            for (int i = 1; i < length; i++)
            {
                var curPrice = prices[i] + CutRod(length - i, prices);

                if (curPrice > bestPrice)
                {
                    curcombo = i;
                    bestPrice = curPrice;
                }
            }

            combo[length] = curcombo;
            bestPrices[length] = bestPrice;

            return bestPrice;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Cable_Merchant
{
    class Program
    {
        public static List<int> prices;
        public static int[] bestPrices;

        static void Main(string[] args)
        {
            prices = new List<int>() {0};
            prices.AddRange(Console.ReadLine().Split().Select(int.Parse));
            var connectorPrice = int.Parse(Console.ReadLine());
            bestPrices = new int[prices.Count];


            for (int length = 1; length < prices.Count; length++)
            {
                var bestPriceForLength = CutCable(length, connectorPrice);
                Console.Write($"{bestPriceForLength} ");
            }

        }

        private static int CutCable(int length, int connectorPrice)
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
            for (int i = 1; i < length; i++)
            {
                var curPrice = (prices[i] + CutCable(length - i, connectorPrice))
                               - 2*connectorPrice;

                if (bestPrice < curPrice)
                {
                    bestPrice = curPrice;
                }
            }

            bestPrices[length] = bestPrice;

            return bestPrice;
        }
    }
}

using System;
using System.Dynamic;
using System.Linq;

namespace _03._Road_Trip
{
    class Program
    {
        public static int[,] dp;

        static void Main(string[] args)
        {
            var itemsValue = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            var amountOfSpace = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            var maxCapacity = int.Parse(Console.ReadLine());

            dp = new int[itemsValue.Length + 1, maxCapacity + 1];

            for (int itemIdx = 1; itemIdx < dp.GetLength(0); itemIdx++)
            {
                var curItemValue = itemsValue[itemIdx-1];
                var curItemSpace = amountOfSpace[itemIdx-1];
                for (int capacity = 1; capacity < dp.GetLength(1); capacity++)
                {
                    var skip = dp[itemIdx - 1, capacity];
                    if (capacity < curItemSpace)
                    {
                        dp[itemIdx, capacity] = skip;
                        continue;
                    }

                    var take = curItemValue + dp[itemIdx - 1, capacity - curItemSpace];

                    if (skip > take)
                    {
                        dp[itemIdx, capacity] = skip;
                    }
                    else
                    {
                        dp[itemIdx, capacity] = take;
                    }
                }
            }

            Console.WriteLine($"Maximum value: {dp[itemsValue.Length, maxCapacity]}");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace _02._Knapsack
{
    internal class Item
    {
        public string Name { get; set; }

        public int Weight { get; set; }

        public int Value { get; set; }

        public Item(string name, int weight, int value)
        {
            Name = name;
            Weight = weight;
            Value = value;
        }
    }
    class Program
    {
        public static int[,] dp;
        public static List<Item> items;
        public static bool[,] taken;

        static void Main(string[] args)
        {
            var maxCapacity = int.Parse(Console.ReadLine());
            items = ReadItems();

            dp = new int[items.Count + 1, maxCapacity + 1];
            taken = new bool[items.Count + 1, maxCapacity + 1];

            KnapsackAlg();

            Print(maxCapacity);
        }

        private static void Print(int maxCapacity)
        {
            var totalValue = dp[items.Count, maxCapacity];
            var totalWeight = 0;
            var takenItems = new SortedSet<string>();

            for (int itemIndex = dp.GetLength(0) - 1; itemIndex >= 0; itemIndex--)
            {
                if (taken[itemIndex, maxCapacity])
                {
                    var item = items[itemIndex - 1];
                    maxCapacity -= item.Weight;
                    totalWeight += item.Weight;

                    takenItems.Add(item.Name);
                }
            }

            Console.WriteLine($"Total Weight: {totalWeight}");
            Console.WriteLine($"Total Value: {totalValue}");
            Console.WriteLine(string.Join(Environment.NewLine, takenItems));
        }

        private static void KnapsackAlg()
        {
            for (int itemIndex = 1; itemIndex < dp.GetLength(0); itemIndex++)
            {
                var curItem = items[itemIndex-1];
                for (int capacity = 1; capacity < dp.GetLength(1); capacity++)
                {
                    var skip = dp[itemIndex - 1, capacity];
                    if (curItem.Weight > capacity)
                    {
                        dp[itemIndex, capacity] = skip;
                        continue;
                    }

                    var take = curItem.Value + dp[itemIndex - 1, capacity - curItem.Weight];

                    if (skip > take)
                    {
                        dp[itemIndex, capacity] = skip;
                    }
                    else
                    {
                        dp[itemIndex, capacity] = take;
                        taken[itemIndex, capacity] = true;
                    }
                }
            }
        }

        private static List<Item> ReadItems()
        {
            var res = new List<Item>();

            while (true)
            {
                var line = Console.ReadLine().Split();

                if (line[0] == "end")
                {
                    break;;
                }

                res.Add(new Item(line[0], int.Parse(line[1]), int.Parse(line[2])));
            }

            return res;
        }
    }
}

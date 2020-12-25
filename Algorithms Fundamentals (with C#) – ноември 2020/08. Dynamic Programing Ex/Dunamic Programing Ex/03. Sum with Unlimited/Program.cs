using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Sum_with_Unlimited
{
    class Program
    {
        static void Main(string[] args)
        {
            var coins = Console.ReadLine().Split().Select(int.Parse).ToList();
            var target = int.Parse(Console.ReadLine());

            var times = CalcTimes(coins, target);
            Console.WriteLine(times);
        }

        private static int CalcTimes(List<int> coins, int target)
        {
            var memo = new int[target + 1];
            memo[0] = 1;

            foreach (var coin in coins)
            {
                for (int i = coin; i < memo.Length; i++)
                {
                    memo[i] = memo[i] + memo[i - coin];
                }
            }

            return memo[target];
        }
    }
}

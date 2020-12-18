using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07._Sum_of_Coins
{
    class Program
    {
        static void Main(string[] args)
        {
            var coins = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
            var target = int.Parse(Console.ReadLine());
            var sortedCoins = new SortedSet<int>(coins);
            var sb = new StringBuilder();

            var coinsToTake = 0;
            while (target > 0 && sortedCoins.Count > 0)
            {
                var maxCoin = sortedCoins.Max;
                sortedCoins.Remove(maxCoin);

                var timesUsed = target / maxCoin;
                if(timesUsed < 1)
                {
                    continue;
                }

                coinsToTake += timesUsed;
                target -= timesUsed * maxCoin;
                sb.AppendLine($"{timesUsed} coin(s) with value {maxCoin}");
            }
            if(target > 0)
            {
                Console.WriteLine("Error");
                return;
            }

            Console.WriteLine($"Number of coins to take: {coinsToTake}");
            Console.WriteLine(sb.ToString());
        }
    }
}

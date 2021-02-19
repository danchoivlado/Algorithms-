using System;
using System.Linq;
using System.Security.Cryptography;

namespace _02._Battle_Points
{
    class Program
    {
        public static int[,] dp;

        static void Main(string[] args)
        {
            var energyRequiredDefeat = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var battlePoints = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            var initialPoints = int.Parse(Console.ReadLine());

            dp = new int[energyRequiredDefeat.Length + 1, initialPoints + 1];

            KnapsackAlg(energyRequiredDefeat, battlePoints, initialPoints);
            Console.WriteLine(dp[energyRequiredDefeat.Length,initialPoints]);
        }

        private static void KnapsackAlg
            (int[] energyRequiredDefeat, int[] battlePoints, int initialPoints)
        {
            for (int enemyIndex = 1; enemyIndex < dp.GetLength(0); enemyIndex++)
            {
                var curEnergyGained = battlePoints[enemyIndex-1];
                var curEnergyToDefeat = energyRequiredDefeat[enemyIndex-1];
                for (int initalPoints = 1; initalPoints < dp.GetLength(1); initalPoints++)
                {
                    var skip = dp[enemyIndex - 1, initalPoints];
                    if (curEnergyToDefeat > initalPoints)
                    {
                        dp[enemyIndex, initalPoints] = skip;
                        continue;
                    }

                    var take = curEnergyGained + dp[enemyIndex - 1, initalPoints - curEnergyToDefeat];
                    if (skip > take)
                    {
                        dp[enemyIndex, initalPoints] = skip;
                    }
                    else
                    {
                        dp[enemyIndex, initalPoints] = take;
                    }
                }
            }
        }
    }
}

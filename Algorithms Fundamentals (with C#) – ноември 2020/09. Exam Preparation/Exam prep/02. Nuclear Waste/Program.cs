using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Nuclear_Waste
{
    class Program
    {
        static void Main(string[] args)
        {
            var costs = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int n = int.Parse(Console.ReadLine());

            int[] db = new int[n + 1];
            int[] prev = new int[n + 1];

            for (int i = 1; i < n; i++)
            {
                db[i] = int.MaxValue;
                for (int j = 1; j <= i; j++)
                {
                    if(j > costs.Length)
                    {
                        break;
                    }
                    int newValue = db[i - j] + costs[j - 1];

                    if(newValue < db[i])
                    {
                        db[i] = newValue;
                        prev[i] = j; 
                    }
                }
            }
            ;
        }
    }
}

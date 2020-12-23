using System;
using System.Collections.Generic;
using System.Linq;

namespace _00._Subset_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new List<int>() { 3, 5, 1, 4, 2 };
            var target = 6;

            var allPossibleSums = GenSums(nums);

            while (true)
            {
                if(allPossibleSums[target] == 0)
                {
                    Console.WriteLine(target);
                    break;
                }
                else
                {
                    Console.WriteLine(allPossibleSums[target]);
                }
                target = target - allPossibleSums[target]; 
            }

        }

        private static Dictionary<int, int> GenSums(List<int> nums)
        {
            var sums = new Dictionary<int, int>();
            sums.Add(0, 0);

            foreach (var num in nums)
            {
                var currSums = sums.Keys.ToList();

                foreach (var sum in currSums)
                {
                    if(!sums.ContainsKey(sum + num))
                    {
                        sums.Add(sum + num, sum);
                    }
                }
            }

            return sums;
        }
    }
}

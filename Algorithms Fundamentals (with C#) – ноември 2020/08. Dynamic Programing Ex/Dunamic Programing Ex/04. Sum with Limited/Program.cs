using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Sum_with_Limited
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToList();
            var target = int.Parse(Console.ReadLine());

            var sums = CalcSums(nums);
            Console.WriteLine(sums[target]);
        }

        private static Dictionary<int, int> CalcSums(List<int> nums)
        {
            var result = new Dictionary<int, int>() { { 0, 0 } };

            foreach (var num in nums)
            {
                var sums = result.Keys.ToList();
                foreach (var sum in sums)
                {
                    var newSum = sum + num;
                    if (!result.ContainsKey(newSum))
                    {
                        result.Add(newSum, 0);
                    }
                    result[newSum]++;
                }
            }

            return result;
        }
    }
}

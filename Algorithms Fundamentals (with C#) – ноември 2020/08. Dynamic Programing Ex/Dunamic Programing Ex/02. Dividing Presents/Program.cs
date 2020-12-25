using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Dividing_Presents
{
    class Program
    {

        static void Main(string[] args)
        {
            var nums = Console.ReadLine().Split().Select(int.Parse).ToList();

            var allSums = CalcSums(nums);

            var sum = nums.Sum();
            var bobScope = BobScope(allSums, sum / 2);
            var alanSope = sum - bobScope;

            var alanPresents = new List<int>();

            var cur = alanSope;
            while (cur != 0)
            {
                alanPresents.Add(allSums[cur]);
                cur -= allSums[cur];
            }

            Console.WriteLine($"Difference: {bobScope-alanSope}");
            Console.WriteLine($"Alan:{alanSope} Bob:{bobScope}");
            Console.WriteLine($"Alan takes: {string.Join(" ", alanPresents)}");
            Console.WriteLine($"Bob takes the rest.");
        }

        private static int BobScope(Dictionary<int, int> allSums, int bobScope)
        {
            while (true)
            {
                if (allSums.ContainsKey(bobScope))
                {
                    break;
                }

                bobScope++;
            }

            return bobScope;
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
                        result.Add(newSum, num);
                    }
                }
            }

            return result;
        }
    }
}

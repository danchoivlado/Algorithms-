using System;
using System.Collections.Generic;

namespace _00._Subset_Sum_w_Rep
{
    class Program
    {
        static void Main(string[] args)
        {
            var nums = new List<int>() { 3, 5, 2 };
            var target = 14;

            var sums = new bool[target + 1];
            sums[0] = true;

            for (int i = 0; i < sums.Length; i++)
            {
                if (sums[i])
                {
                    foreach (var num in nums)
                    {
                        var curSum = num + i;
                        if(curSum <= target)
                        {
                            sums[curSum] = true;
                        }
                    }
                }
            }

            while (target > 0)
            {
                foreach (var num in nums)
                {
                    var prev = target - num;
                    if (prev >= 0 && sums[prev])
                    {
                        target = prev;
                        Console.WriteLine(num);
                    }
                }
            }
        }
    }
}

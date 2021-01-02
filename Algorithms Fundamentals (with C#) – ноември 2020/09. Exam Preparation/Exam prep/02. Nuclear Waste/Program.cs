using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Nuclear_Waste
{
    class Program
    {
        public static int[] nums;
        public static int[] permuts;
        public static List<int[]> endRes;

        static void Main(string[] args)
        {
            nums = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var slots = int.Parse(Console.ReadLine());
            permuts = new int[slots];
            endRes = new List<int[]>();
            GGen();
            Console.WriteLine(endRes.Any(x => x.Sum() == 104));
        }

        private static void GGen(int index = 0)
        {
            if(index >= permuts.Length)
            {
                endRes.Add(permuts.ToArray());
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                permuts[index] = nums[i];
                GGen(index + 1);
            }
        }
    }
}

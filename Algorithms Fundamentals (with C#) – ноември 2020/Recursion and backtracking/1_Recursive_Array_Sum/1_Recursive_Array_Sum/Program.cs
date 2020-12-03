using System;
using System.Linq;

namespace _1_Recursive_Array_Sum
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arr = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            Console.WriteLine(Sum(arr));
        }

        public static int Sum(int[] arr, int i = 0, int sum = 0)
        {
            if (i == arr.Length)
            {
                return sum;
            }
            return Sum(arr, i + 1, sum += arr[i]);
        }
    }
}

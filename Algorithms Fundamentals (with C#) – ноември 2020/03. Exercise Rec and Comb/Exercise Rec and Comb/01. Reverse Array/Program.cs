using System;
using System.Linq;

namespace _01._Reverse_Array
{
    class Program
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split().Select(x => int.Parse(x)).ToArray();

            arr = Reverse(0,arr);
            Console.WriteLine(string.Join(" ", arr));
        }

        private static int[] Reverse(int index,int[] arr)
        {
            if(index>= arr.Length / 2)
            {
                return arr;
            }

            Swap(index, arr);
            return Reverse(index + 1, arr);
        }

        private static void Swap(int index, int[] arr)
        {
            var last = arr[arr.Length - 1 - index];
            arr[arr.Length - 1 - index] = arr[index];
            arr[index] = last;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace _01._Binrary_Search
{
    class Program
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var searchedElements = int.Parse(Console.ReadLine());

            Console.WriteLine(BinarySearch(elements, searchedElements));
        }

        private static int BinarySearch(int[] elements, int searchedElements)
        {
            var left = 0;
            var right = elements.Length - 1;
            var middle = (left + right) / 2;

            while (left <= right)
            {
                if (elements[middle] == searchedElements)
                    return middle;

                if (elements[middle] < searchedElements)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
                middle = (left + right) / 2;
            }
            return -1;
        }
    }
}

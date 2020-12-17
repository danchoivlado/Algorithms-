using System;
using System.Linq;

namespace _04._Insertion_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

            InsertionSort(elements);
            Console.WriteLine(string.Join(" ", elements));
        }

        private static void InsertionSort(int[] elements)
        {
            for (int i = 1; i < elements.Length; i++)
            {
                for (int j = i; j >= 1; j--)
                {
                    if (elements[j] < elements[j - 1])
                    {
                        Swap(elements, j, j - 1);
                    }
                }
            }
        }

        private static void Swap(int[] elements, int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
    }
}

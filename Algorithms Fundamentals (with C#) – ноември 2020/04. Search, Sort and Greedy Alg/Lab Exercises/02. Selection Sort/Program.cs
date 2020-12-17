using System;
using System.Linq;

namespace _02._Selection_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

            SelectionSort(elements);
            Console.WriteLine(string.Join(" ", elements));
        }

        private static void SelectionSort(int[] elements)
        {
            for (int i = 0; i < elements.Length; i++)
            {
                var minValueIdx = i;
                for (int j = i + 1; j < elements.Length; j++)
                {
                    if (elements[minValueIdx] > elements[j])
                    {
                        minValueIdx = j;
                    }
                }
                Swap(elements, i, minValueIdx);
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

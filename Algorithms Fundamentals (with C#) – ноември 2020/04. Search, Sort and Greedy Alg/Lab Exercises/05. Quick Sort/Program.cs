using System;
using System.Linq;

namespace _05._Quick_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

            QuickSort(elements, 0, elements.Length - 1);
            Console.WriteLine(string.Join(" ", elements));
        }

        private static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                int pivot = Partition(arr, low, high);

                QuickSort(arr, low, pivot - 1);
                QuickSort(arr, pivot + 1, high);
            }
        }

        private static int Partition(int[] arr, int low, int high)
        {
            var i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (arr[j] < arr[high])
                {
                    i++;

                    Swap(arr, i, j);
                }
            }
            Swap(arr, i + 1, high);
            return i + 1;
        }

        private static void Swap(int[] elements, int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
    }
}

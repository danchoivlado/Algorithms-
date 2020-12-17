using System;
using System.Linq;

namespace _03._Bubble_Sort
{
    class Program
    {
        static void Main(string[] args)
        {
            var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

            BubbleSort(elements);
            Console.WriteLine(string.Join(" ", elements));
        }

        private static void BubbleSort(int[] elements)
        {
            var sorted = false;
            while (sorted != true)
            {
                sorted = true;

                for (int i = 0; i < elements.Length-1; i++)
                {
                    if(elements[i] > elements[i + 1])
                    {
                        Swap(elements, i, i + 1);
                        sorted = false;
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

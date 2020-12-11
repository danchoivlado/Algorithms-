using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Permutations_W_Rep
{
    //TODO
    class Program
    {
        private static char[] elements;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split().Select(x => char.Parse(x)).ToArray();

            Generate(0);
        }

        private static void Generate(int index)
        {
            if(index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", elements));
                return;
            }

            Generate(index + 1);

            var swapped = new HashSet<char> { elements[index] };
            for (int i = index +1; i < elements.Length; i++)
            {
                if (!swapped.Contains(elements[index]))
                {
                    Swap(index, i);
                    Generate(index + 1);
                    Swap(index, i);
                    swapped.Add(elements[i]);
                }
            }
        }

        private static void Swap(int first, int second)
        {
            var temp = elements[first];
            elements[first] = elements[second];
            elements[second] = temp;
        }
    }
}

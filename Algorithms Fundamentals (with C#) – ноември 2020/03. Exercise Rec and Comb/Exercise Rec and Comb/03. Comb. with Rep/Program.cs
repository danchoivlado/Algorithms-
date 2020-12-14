using System;
using System.Linq;

namespace _03._Comb._with_Rep
{
    class Program
    {
        static int[] slots;

        static void Main(string[] args)
        {
            var numElements = int.Parse(Console.ReadLine());
            var numSLots = int.Parse(Console.ReadLine());
            slots = new int[numSLots];

            Print(numElements);
        }

        private static void Print(int numElements, int index = 0, int element = 1)
        {
            if (index >= slots.Length)
            {
                Console.WriteLine(string.Join(" ", slots));
                return;
            }

            for (int i = element; i <= numElements; i++)
            {
                slots[index] = i;
                Print(numElements, index + 1, i);
            }
        }
    }
}

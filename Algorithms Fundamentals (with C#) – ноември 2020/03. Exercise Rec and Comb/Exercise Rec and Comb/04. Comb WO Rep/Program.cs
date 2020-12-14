using System;

namespace _04._Comb_WO_Rep
{
    class Program
    {
        static int[] slots;
        static void Main(string[] args)
        {
            var numElements = int.Parse(Console.ReadLine());
            var numSlots = int.Parse(Console.ReadLine());
            slots = new int[numSlots];

            Generate(numElements);
        }

        private static void Generate(int numElements, int index = 0, int element = 1)
        {
            if(index >= slots.Length)
            {
                Console.WriteLine(string.Join(" ", slots));
                return;
            }

            for (int i = element; i <= numElements; i++)
            {
                slots[index] = i;
                Generate(numElements, index + 1, i + 1);
            }
        }
    }
}

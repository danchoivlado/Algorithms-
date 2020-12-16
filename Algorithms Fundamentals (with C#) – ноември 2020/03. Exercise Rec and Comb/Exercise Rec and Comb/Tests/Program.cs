using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    class Program
    {
        private static char[] elements;
        private static char[] slots;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split().Select(char.Parse).ToArray();
            var numSlots = int.Parse(Console.ReadLine());
            slots = new char[numSlots];

            Generate(0, 0);
        }

        private static void Generate(int index, int start)
        {
            if(index >= slots.Length)
            {
                Console.WriteLine(string.Join(" ", slots));
                return;
            }


            for (int i = start; i < elements.Length; i++)
            {
                slots[index] = elements[i];
                Generate(index + 1, i);
            }
        }
    }
}

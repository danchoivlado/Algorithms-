﻿using System;
using System.Linq;

namespace _05._Combinations_WO_Rep
{
    class Program
    {
        private static char[] elements;
        private static char[] combinations;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split().Select(x => char.Parse(x)).ToArray();
            var k = int.Parse(Console.ReadLine());
            combinations = new char[k];

            Generate(0,0);
        }

        private static void Generate(int index, int start)
        {
            if(index >= combinations.Length)
            {
                Console.WriteLine(string.Join(" ",combinations));
                return;
            }

            for (int i = start; i < elements.Length; i++)
            {
                combinations[index] = elements[i];
                Generate(index + 1, i+1);
            }
        }
    }
}

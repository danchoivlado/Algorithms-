using System;
using System.Linq;

namespace _01._Permutations_WO_Rep
{
    class Program
    {
        private static char[] permuts;
        private static bool[] used;
        private static char[] elements;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split().Select(x => char.Parse(x)).ToArray();
            permuts = new char[elements.Length];
            used = new bool[elements.Length];

            Generate(0);
        }

        private static void Generate(int index)
        {
            if (index >= elements.Length)
            {
                Console.WriteLine(string.Join(" ", permuts));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    permuts[index] = elements[i];
                    Generate(index + 1);
                    used[i] = false;
                }
            }
        }
    }
}

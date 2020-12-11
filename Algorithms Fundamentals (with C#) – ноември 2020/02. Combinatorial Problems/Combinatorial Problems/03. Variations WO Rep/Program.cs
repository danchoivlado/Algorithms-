using System;
using System.Linq;

namespace _03._Variations_WO_Rep
{
    class Program
    {
        private static char[] elements;
        private static char[] variations;
        private static bool[] used;

        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split().Select(x => char.Parse(x)).ToArray();
            var k = int.Parse(Console.ReadLine());
            variations = new char[k];
            used = new bool[elements.Length];

            Generate(0);

        }

        private static void Generate(int index)
        {
            if(index >= variations.Length)
            {
                Console.WriteLine(string.Join(" " ,variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    variations[index] = elements[i];
                    Generate(index + 1);
                    used[i] = false;
                }
            }
        }
    }
}

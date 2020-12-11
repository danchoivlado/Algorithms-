using System;
using System.Linq;

namespace _04._Variations_W_Rep
{
    class Program
    {
        private static char[] variations;
        private static char[] elements;


        static void Main(string[] args)
        {
            elements = Console.ReadLine().Split().Select(x => char.Parse(x)).ToArray();
            var k = int.Parse(Console.ReadLine());
            variations = new char[k];

            Generate(0);
        }

        private static void Generate(int index)
        {
            if(index >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }

            for (int i = 0; i < elements.Length; i++)
            {
                variations[index] = elements[i];
                Generate(index+1);
            }
        }
    }
}

using System;

namespace _02._Nested_Loops
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var variations = new int[n];

            Generate(variations, 0);
        }

        private static void Generate(int[] variations, int index)
        {
            if(index >= variations.Length)
            {
                Console.WriteLine(string.Join(" ", variations));
                return;
            }


            for (int i = 0; i < variations.Length; i++)
            {
                variations[index] = i+1;
                Generate(variations, index + 1);
            }
        }
    }
}

using System;

namespace _03._Generating_Vectors
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Generate(new int[n]);
        }

        public static void Generate(int[] arr, int value = 0)
        {
            if (value == arr.Length)
            {
                Console.WriteLine(string.Join("", arr));
                return;
            }

            for (int i = 0; i <= 1; i++)
            {
                arr[value] = i;
                Generate(arr, value + 1);
            }
        }
    }
}

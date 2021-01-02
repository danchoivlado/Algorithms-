using System;

namespace _01._Alpha_Decay
{
    class Program
    {
        public static string[] nums;
        public static string[] permuts;
        public static bool[] visited;

        static void Main(string[] args)
        {
            nums = Console.ReadLine().Split();
            var slots = int.Parse(Console.ReadLine());
            visited = new bool[nums.Length];

            permuts = new string[slots];

            GenPermuts();
        }

        private static void GenPermuts(int index = 0)
        {
            if (index >= permuts.Length)
            {
                Console.WriteLine(string.Join(" ", permuts));
                return;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                if (!visited[i])
                {
                    visited[i] = true;
                    permuts[index] = nums[i];
                    GenPermuts(index + 1);
                    visited[i] = false;
                }
            }
        }
    }
}

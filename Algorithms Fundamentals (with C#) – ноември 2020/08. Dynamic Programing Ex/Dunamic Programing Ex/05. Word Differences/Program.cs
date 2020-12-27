using System;

namespace _05._Word_Differences
{
    class Program
    {
        public static int[,] matrix;
        public static string firstSt;
        public static string secondSt;

        static void Main(string[] args)
        {
            firstSt = Console.ReadLine();
            secondSt = Console.ReadLine();
            var firstLen = firstSt.Length;
            var secondLen = firstSt.Length;

            matrix = new int[firstLen + 1, secondLen + 1];

            GenMatrix();
            Console.WriteLine($"Deletions and Insertions: {matrix[firstLen, secondLen]}");
        }

        private static void GenMatrix()
        {
            matrix[0, 0] = 0;
            for (int i = 1; i < matrix.GetLength(0); i++)
            {
                matrix[0, i] = i;
            }
            for (int i = 1; i < matrix.GetLength(1); i++)
            {
                matrix[i, 0] = i;
            }

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if (firstSt[row - 1] == secondSt[col - 1])
                    {
                        matrix[row, col] = matrix[row - 1, col - 1];
                    }
                    else
                    {
                        var up = matrix[row - 1, col];
                        var left = matrix[row, col - 1];
                        var result = Math.Min(up, left) + 1;

                        matrix[row, col] = result;
                    }
                }
            }

        }
    }
}

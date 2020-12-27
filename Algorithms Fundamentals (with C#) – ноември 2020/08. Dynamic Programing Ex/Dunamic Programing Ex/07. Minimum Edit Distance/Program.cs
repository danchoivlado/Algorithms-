using System;

namespace _07._Minimum_Edit_Distance
{
    class Program
    {
        public static int[,] matrix;
        public static int replaceCost;
        public static int insertCost;
        public static int deleteCost;
        public static string firstSt;
        public static string secondSt;

        static void Main(string[] args)
        {
            replaceCost = int.Parse(Console.ReadLine());
            insertCost = int.Parse(Console.ReadLine());
            deleteCost = int.Parse(Console.ReadLine());
            firstSt = Console.ReadLine();
            secondSt = Console.ReadLine();

            matrix = new int[firstSt.Length + 1, secondSt.Length + 1];
            GenMatrix();
            Console.WriteLine($"Minimum edit distance: {matrix[firstSt.Length, secondSt.Length]}") ;

        }
        private static void GenMatrix()
        {
            matrix[0, 0] = 0;
            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                matrix[0, col] = matrix[0, col - 1] + deleteCost;
            }

            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                matrix[row, 0] = matrix[row - 1, 0] + insertCost;
            }
        ;
            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    var cost = firstSt[row - 1] == secondSt[col - 1] ? 0 : replaceCost;

                    var delete = matrix[row - 1, col] + deleteCost;
                    var insert = matrix[row, col - 1] + insertCost;
                    var replace = matrix[row - 1, col - 1] + cost;

                    matrix[row, col] = Math.Min(Math.Min(delete, insert), replace);
                }
            }
        }
    }
}

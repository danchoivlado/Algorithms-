using System;

namespace _01._Binomial_Coefficients
{
    class Program
    {
        public static long[,] cach;

        static void Main(string[] args)
        {
            var row = int.Parse(Console.ReadLine());
            var col = int.Parse(Console.ReadLine());

            cach = new long[row+1, col+1];
            Console.WriteLine(FindBionomical(row, col)); 
        }

        private static long FindBionomical(int row, int col)
        {
            if(cach[row, col] != 0)
            {
                return cach[row, col];
            }

            if(col == 0 || col == row)
            {
                return 1;
            }

            var result = FindBionomical(row - 1, col - 1) + FindBionomical(row - 1, col);
            cach[row, col] = result;
            return result;
        }
    }
}

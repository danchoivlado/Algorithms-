using System;

namespace _07._N_Choose_K
{
    class Program
    {
        static void Main(string[] args)
        {
            var row = int.Parse(Console.ReadLine());
            var cow = int.Parse(Console.ReadLine());

            Console.WriteLine(Pascal(row, cow));
        }

        private static int Pascal(int row, int cow)
        {
            if (row <= 1 || cow == 0 || cow == row)
            {
                return 1;
            }

            return  Pascal(row - 1, cow ) + Pascal(row - 1, cow - 1) ;
        }
    }
}

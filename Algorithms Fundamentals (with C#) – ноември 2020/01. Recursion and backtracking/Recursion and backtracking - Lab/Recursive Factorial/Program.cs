using System;

namespace Recursive_Factorial
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(Fib(n));
        }

        public static long Fib(int number)
        {
            if(number == 1)
            {
                return 1;
            }

            return number * Fib(number - 1);
        }

    }
}

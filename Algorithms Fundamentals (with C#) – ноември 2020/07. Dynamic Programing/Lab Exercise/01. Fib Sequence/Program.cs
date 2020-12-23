using System;
using System.Collections.Generic;

namespace _01._Fib_Sequence
{
    class Program
    {
        public static Dictionary<int, long> memo;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            memo = new Dictionary<int, long>();

            Console.WriteLine(Fib(n));
        }

        private static long Fib(int n)
        {
            if (memo.ContainsKey(n))
            {
                return memo[n];
            }

            if(n <=2)
            {
                return 1;
            }

            var res = Fib(n - 1) + Fib(n - 2);
            memo.Add(n, res);
            return res;
        }
    }
}

using System;

namespace _02._Recursive_Drawing
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Draw(n);
        }

        public static void Draw(int n)
        {
            if(n == 0)
            {
                return;
            }

            Console.WriteLine(new String('*', n));
            Draw(n - 1);
            Console.WriteLine(new String('#', n));
        }
    }
}

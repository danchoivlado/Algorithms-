using System;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    class Program
    {
        private static char[] elements;
        private static char[] slots;

        static void Main(string[] args)
        {
            var hehs = new HashSet<int>();

            hehs.Add(1);
            hehs.Add(1);
            hehs.Add(1);

            foreach (var item in hehs)
            {
                Console.WriteLine(item);
            }
        }
    }
}

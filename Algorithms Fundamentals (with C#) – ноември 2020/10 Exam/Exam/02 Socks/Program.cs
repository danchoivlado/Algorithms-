using System;

namespace _02_Socks
{
    class Program
    {
        public static int[,] matrix;

        static void Main(string[] args)
        {
            var firstLine = Console.ReadLine().Split();
            var secondLine = Console.ReadLine().Split();

            matrix = GenMatrix(firstLine, secondLine);
            Console.WriteLine(matrix[firstLine.Length, secondLine.Length]);
        }

        private static int[,] GenMatrix(string[] firstLine, string[] secondLine)
        {
            var res = new int[firstLine.Length + 1, secondLine.Length + 1];
            res[0, 0] = 0;

            for (int row = 1; row <= firstLine.Length; row++)
            {
                for (int col = 1; col <= secondLine.Length; col++)
                {
                    if (firstLine[row - 1] == secondLine[col - 1])
                    {
                        var diagonal = res[row - 1, col - 1];
                        res[row, col] = diagonal + 1;
                        continue;
                    }

                    var up = res[row - 1, col];
                    var left = res[row, col - 1];
                    var result = Math.Max(up, left);
                    res[row, col] = result;
                }
            }

            return res;
        }
    }
}

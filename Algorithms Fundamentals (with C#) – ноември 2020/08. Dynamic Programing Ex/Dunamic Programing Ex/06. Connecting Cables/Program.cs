using System;
using System.Linq;

namespace _06._Connecting_Cables
{
    class Program
    {
        public static int[] secondRoom;
        public static int[] firstRoom;
        public static int[,] matrix;

        static void Main(string[] args)
        {
            secondRoom = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var secondLen = secondRoom.Length;
            firstRoom = new int[secondLen];
            matrix = new int[secondLen + 1, secondLen + 1];


            GenMatrix();
            Console.WriteLine($"Maximum pairs connected: {matrix[secondLen, secondLen]}");
        }

        private static void GenMatrix()
        {
            for (int i = 0; i < firstRoom.Length; i++)
            {
                firstRoom[i] = i + 1;
            }

            matrix[0, 0] = 0;
            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                for (int col = 1; col < matrix.GetLength(1); col++)
                {
                    if (firstRoom[row - 1] == secondRoom[col - 1])
                    {
                        matrix[row, col] = matrix[row - 1, col - 1] + 1;
                    }
                    else
                    {
                        var up = matrix[row - 1, col];
                        var left = matrix[row, col - 1];
                        var result = Math.Max(up, left);

                        matrix[row, col] = result;
                    }
                }
            }
        }
    }
}

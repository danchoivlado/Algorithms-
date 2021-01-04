using System;

namespace _01_TBC
{
    class Program
    {
        public static char[,] matrix;
        public static bool[,] visited;

        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            matrix = ReadMatrix(rows, cols);
            var count = Search(rows, cols);
            Console.WriteLine(count);
        }

        private static int Search(int rows, int cols)
        {
            var count = 0;
            visited = new bool[rows, cols];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (matrix[row, col] != 'd' && visited[row, col] == false)
                    {
                        count++;
                        MarkArea(row, col);
                    }
                }
            }

            return count;
        }

        private static void MarkArea(int row, int col)
        {
            if (ItsOutside(row, col))
            {
                return;
            }

            if (matrix[row, col] == 'd' || visited[row, col])
            {
                return;
            }

            visited[row, col] = true;
            MarkArea(row - 1, col - 1); //Diagonal-
            MarkArea(row + 1, col + 1); // Diagonal+
            MarkArea(row + 1, col - 1);
            MarkArea(row - 1, col + 1);
            MarkArea(row, col - 1); // Left-
            MarkArea(row, col + 1); // Left+
            MarkArea(row - 1, col); // Down-
            MarkArea(row + 1, col); // Down+

        }

        private static bool ItsOutside(int row, int col)
        {
            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return true;
            }

            return false;
        }

        private static char[,] ReadMatrix(int rows, int cols)
        {
            var res = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine();
                for (int col = 0; col < cols; col++)
                {
                    res[row, col] = line[col];
                }
            }

            return res;
        }
    }
}

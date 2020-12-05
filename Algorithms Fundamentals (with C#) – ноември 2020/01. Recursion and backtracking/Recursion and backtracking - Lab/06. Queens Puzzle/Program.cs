using System;
using System.Collections.Generic;

namespace _06._Queens_Puzzle
{
    class Program
    {
        public static int placed = 0;
        public static HashSet<int> rows = new HashSet<int>();
        public static HashSet<int> cows = new HashSet<int>();
        public static HashSet<int> leftDiagonal = new HashSet<int>();
        public static HashSet<int> rightDiagonal= new HashSet<int>();

        static void Main(string[] args)
        {
            PlaceQueens(new bool[8,8], 0);
        }

        private static void PlaceQueens(bool[,] board,  int row)
        {
            if(row == 8)
            {
                Print(board);
                return;
            }

            for (int col = 0; col < 8; col++)
            {
                if (CanPlaceQueen(row, col))
                {
                    board[row, col] = true;
                    rows.Add(row);
                    cows.Add(col);
                    leftDiagonal.Add(row-col);
                    rightDiagonal.Add(col + row);

                    
                   
                    PlaceQueens(board, row + 1);

                    board[row, col] = false;
                    rows.Remove(row);
                    cows.Remove(col);
                    leftDiagonal.Remove(row - col);
                    rightDiagonal.Remove(col + row);
                }
            }
        }

        private static void Print(bool[,] board)
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (board[row, col])
                    {
                        Console.Write('*');
                    }
                    else
                    {
                        Console.Write('-');
                    }
                }
                Console.Write('\n');
            }
            Console.Write('\n');

        }

        private static bool CanPlaceQueen(int curRow, int curCow)
        {
            if (rows.Contains(curRow) || cows.Contains(curCow)
                || leftDiagonal.Contains(curRow - curCow) || rightDiagonal.Contains(curCow + curRow))
            {
                return false;
            }
            return true;
        }
    }
}

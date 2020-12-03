using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Find_All_Paths
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            int cows = int.Parse(Console.ReadLine());
            char[,] arr = new char[rows, cows];


            for (int r = 0; r < rows; r++)
            {
                string curRow = Console.ReadLine();
                for (int c = 0; c < cows; c++)
                {
                    arr[r, c] = curRow[c];
                }
            }

            FindPath(arr, new bool[rows, cows], 0, 0, new Stack<char>(), 's', rows - 1, cows - 1);
        }

        public static void FindPath(char[,] arr, bool[,] visited,
            int curRow, int curCow, Stack<char> path, char direction,
            int initialRows, int initialCows)
        {
            //Is wall
            if (curCow < 0 || curCow > initialCows || curRow < 0 || curRow > initialRows)
            {
                return;
            }

            //Is object or visited
            if (arr[curRow, curCow] == '*' || visited[curRow, curCow] == true)
            {
                return;
            }

            //Is destination
            if (arr[curRow, curCow] == 'e')
            {
                path.Push(direction);
                Console.WriteLine(string.Join("", path.Reverse().Skip(1)));
                visited[curRow, curCow] = false;
                path.Pop();
                return;
            }
            path.Push(direction);
            visited[curRow, curCow] = true;

            FindPath(arr, visited, curRow, curCow + 1, path, 'R', initialRows, initialCows);
            FindPath(arr, visited, curRow, curCow - 1, path, 'L', initialRows, initialCows);
            FindPath(arr, visited, curRow + 1, curCow, path, 'D', initialRows, initialCows);
            FindPath(arr, visited, curRow - 1, curCow, path, 'U', initialRows, initialCows);

            visited[curRow, curCow] = false;
            path.Pop();

        }



    }
}

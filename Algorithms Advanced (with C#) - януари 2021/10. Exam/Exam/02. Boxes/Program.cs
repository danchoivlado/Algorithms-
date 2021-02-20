using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Boxes
{
    class Program
    {
        public static Box[] boxes;
        public static int[] lisArr;
        public static int[] prev;

        static void Main(string[] args)
        {
            var numBoxes = int.Parse(Console.ReadLine());
            boxes = ReadBoxes(numBoxes);

            lisArr = new int[boxes.Length];
            prev = new int[boxes.Length];
            var longestIndex = LISAlg();
            Print(longestIndex);
        }

        private static void Print(int longestIndex)
        {
            var stack = new Stack<Box>();

            while (longestIndex != -1)
            {
                stack.Push(boxes[longestIndex]);
                longestIndex = prev[longestIndex];
            }

            Console.WriteLine(string.Join(Environment.NewLine, stack));
        }

        private static int LISAlg()
        {
            var longest = 0;
            var longestIndex = 0;
            for (int wordIndex = 0; wordIndex < boxes.Length; wordIndex++)
            {
                var curWord = boxes[wordIndex];
                var lis = 1;
                prev[wordIndex] = -1;

                for (int i = wordIndex - 1; i >= 0; i--)
                {
                    //IsLarger(cur, prev) curWord.Length > boxes[i].Length
                    if (IsLarger(curWord, boxes[i]) && lisArr[i] + 1 >= lis)
                    {
                        prev[wordIndex] = i;
                        lis = lisArr[i] + 1;
                    }
                }

                if (lis > longest)
                {
                    longest = lis;
                    longestIndex = wordIndex;
                }
                lisArr[wordIndex] = lis;
            }

            return longestIndex;
        }

        //IsLarger(cur, prev) curWord.Length > boxes[i].Length

        private static bool IsLarger(Box curBox, Box prevBox)
        {
            if (curBox.height > prevBox.height
                && curBox.width > prevBox.width && curBox.depth > prevBox.depth)
            {
                return true;
            }

            return false;
        }

        private static Box[] ReadBoxes(int numBoxes)
        {
            var res = new Box[numBoxes];

            for (int i = 0; i < numBoxes; i++)
            {
                var line = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var width = line[0];
                var depth = line[1];
                var height = line[2];

                res[i] = new Box(width, depth, height);
            }

            return res;
        }
    }

    internal class Box
    {
        public int width { get; set; }

        public int depth { get; set; }

        public int height { get; set; }

        public Box(int width, int depth, int height)
        {
            this.width = width;
            this.depth = depth;
            this.height = height;
        }

        public override string ToString()
        {
            return $"{width} {depth} {height}";
        }
    }
}

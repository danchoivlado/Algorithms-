using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Cinema
{
    class Program
    {
        private static string[] seats;
        private static List<string[]> permuts;
        private static HashSet<string> electedPeople;

        static void Main(string[] args)
        {
            var people = Console.ReadLine()
                .Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();
            seats = new string[people.Count];
            electedPeople = new HashSet<string>();

            while (true)
            {
                var nameNumber = Console.ReadLine().Split(" - ").ToArray();
                if (nameNumber[0] == "generate")
                {
                    break;
                }

                seats[int.Parse(nameNumber[1]) - 1] = nameNumber[0];
                electedPeople.Add(nameNumber[0]);
                people.Remove(nameNumber[0]);
            }

            permuts = new List<string[]>();
            Generate(0, people.ToArray());

            foreach (var permute in permuts)
            {
                int permuteCounter = 0;
                for (int i = 0; i < seats.Length; i++)
                {
                    if (electedPeople.Contains(seats[i]))
                        continue;

                    seats[i] = permute[permuteCounter];
                    permuteCounter++;
                }
                Console.WriteLine(string.Join(" ",seats));
            }
        }

        private static void Generate(int index, string[] arr)
        {
            if (index >= arr.Length)
            {
                permuts.Add(arr.ToArray());
                return;
            }

            Generate(index + 1, arr);

            for (int i = index + 1; i < arr.Length; i++)
            {
                Swap(index, i, arr);
                Generate(index + 1 , arr);
                Swap(index, i, arr);

            }
        }

        private static void Swap(int first, int second, string[] arr)
        {
            var temp = arr[first];
            arr[first] = arr[second];
            arr[second] = temp;
        }
    }
}

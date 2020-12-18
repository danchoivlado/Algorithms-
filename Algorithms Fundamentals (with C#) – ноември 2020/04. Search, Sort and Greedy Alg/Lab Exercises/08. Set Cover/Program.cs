using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._Set_Cover
{
    class Program
    {
        static void Main(string[] args)
        {
            var universe = Console.ReadLine().Split(", ").Select(int.Parse).ToList();
            var sets = new List<List<int>>();

            while (true)
            {
                var set = Console.ReadLine();
                if (string.IsNullOrEmpty(set))
                {
                    break;
                }

                sets.Add(set.Split(", ").Select(int.Parse).ToList());
            }

            var setsCounter = 0;
            var result = new List<List<int>>();
            while(universe.Count > 0)
            {
                sets = sets.OrderByDescending(
                    set => set.Count(elm => universe.Contains(elm))).ToList();

                var firstSet = sets.First();

                result.Add(firstSet);
                sets.Remove(firstSet);
                firstSet.ForEach(elm => universe.Remove(elm));
                setsCounter++;
            }

            //Print
            Console.WriteLine($"Sets to take ({setsCounter}):");
            foreach (var item in result)
            {
                Console.WriteLine(string.Join(", ",item));
            }
        }
    }
}

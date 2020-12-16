using System;
using System.Collections.Generic;
using System.Linq;

namespace _08._School_Teams
{
    class Program
    {
        static void Main(string[] args)
        {
            var girls = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var boys  = Console.ReadLine()
                .Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries)
                .ToArray();
            var girlsSlots = new string[3];
            var boysSlots = new string[2];

            var girlsComb = new List<string[]>();
            Generate(0, 0, girls, girlsSlots, girlsComb);

            var boysComb = new List<string[]>();
            Generate(0, 0, boys, boysSlots, boysComb);

            foreach (var girlsSlot in girlsComb)
            {
                foreach (var boysSlot in boysComb)
                {
                    Console.WriteLine(
                        string.Join(", ", girlsSlot) + ", " + string.Join(", ", boysSlot));
                }
            }
        }

        private static void Generate(
            int index, 
            int start, 
            string[] members, 
            string[] membersSlots,
            List<string[]> comb)
        {
            if(index >= membersSlots.Length)
            {
                comb.Add(membersSlots.ToArray());
                return;
            }

            for (int i = start; i < members.Length; i++)
            {
                membersSlots[index] = members[i];
                Generate(index + 1, i + 1, members, membersSlots, comb);
            }
        }
    }
}

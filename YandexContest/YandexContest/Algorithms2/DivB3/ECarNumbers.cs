using System;
using System.Collections.Generic;
using System.Linq;

namespace YandexContest.Algorithms2.DivB3
{
    public class ECarNumbers : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var witnessCount = reader.ReadInt32();
            var witnessList = new List<string>(witnessCount);
            for (var i = 0; i < witnessCount; i++)
            {
                witnessList.Add(Console.ReadLine());
            }

            var suspectCount = reader.ReadInt32();
            var suspectList = new List<Suspect>(suspectCount);
            var max = 0;
            for (var i = 0; i < suspectCount; i++)
            {
                var suspect = Console.ReadLine();
                var suspectSet = new HashSet<char>(suspect);
                var count = witnessList.Count(witness => witness.All(symbol => suspectSet.Contains(symbol)));

                if (count > max)
                    max = count;
                suspectList.Add(new Suspect{Number = suspect, Count = count});
            }
            Console.WriteLine(string.Join("\n", suspectList.Where(s => s.Count == max).Select(s => s.Number)));
        }
    }

    public class Suspect
    {
        public string Number { get; set; }
        public int Count { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace YandexContest.Algorithms2.DivB.DivB4
{
    public class DParlament : IRunnable
    {
        public void Run()
        {
            const string inFileName = "input.txt";
            const long places = 450;
            var dictionary = new Dictionary<string, Numbers>();
            long summ = 0;
            foreach (var line in File.ReadLines(inFileName))
            {
                var index = line.LastIndexOf(' ');
                var count = long.Parse(line.Substring(index + 1));
                var name = line.Substring(0, index);
                dictionary[name] = new Numbers { Name = name, TotalCount = count };
                summ += count;
            }

            var baseNumber = (double)summ / places;
            var baseNumberInt = summ / places;

            var tail = places;
            foreach (var pair in dictionary)
            {
                if (baseNumber != 0)
                {
                    pair.Value.Result = (long)Math.Floor(pair.Value.TotalCount / baseNumber);
                    pair.Value.Remainder = pair.Value.TotalCount / baseNumber - pair.Value.Result;
                }
                else
                {
                    pair.Value.Result = 0;
                    pair.Value.Remainder = pair.Value.TotalCount;
                }

                tail -= pair.Value.Result;
            }

            if (tail != 0)
            {
                var numbersList = new List<Numbers>(dictionary.Values);
                numbersList.Sort(Sort);
                var index = 0;
                while (tail != 0)
                {
                    dictionary[numbersList[index].Name].Result++;
                    index = (index + 1) % dictionary.Count;
                    tail--;
                }
            }
            Console.WriteLine(string.Join("\n", dictionary.Select(n => $"{n.Key} {n.Value.Result}")));
        }
        static int Sort(Numbers numbers, Numbers numbers1)
        {
            if (numbers.Remainder > numbers1.Remainder)
                return -1;
            if (numbers.Remainder < numbers1.Remainder)
                return 1;

            if (numbers.TotalCount > numbers1.TotalCount)
                return -1;
            if (numbers.TotalCount < numbers1.TotalCount)
                return 1;
            return 0;
        }
    }

    public class Numbers
    {
        public string Name { get; set; }
        public long TotalCount { get; set; }
        public long Result { get; set; }
        public double Remainder { get; set; }
    }
    
}
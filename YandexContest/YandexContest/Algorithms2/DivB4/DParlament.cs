using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;

namespace YandexContest.Algorithms2.DivB4
{
    public class DParlament : IRunnable
    {
        public void Run()
        {
            const string inFileName = "input.txt";
            const long places = 450;
            var numbersList = new List<Numbers>();
            long summ = 0;
            foreach (var line in File.ReadLines(inFileName))
            {
                var index = line.LastIndexOf(' ');
                var count = long.Parse(line.Substring(index + 1));
                var name = line.Substring(0, index);
                numbersList.Add(new Numbers { Name = name, TotalCount = count });
                summ += count;
            }

            var baseNumber = summ / places;

            var tail = places;
            foreach (var value in numbersList)
            {
                value.Result =  value.TotalCount / baseNumber;
                value.Remainder = value.TotalCount % baseNumber;
                tail -= value.Result;
            }

            if (tail != 0)
            {
                numbersList.Sort((numbers, numbers1) =>
                {
                    if (numbers.Remainder > numbers1.Remainder)
                        return 1;
                    if (numbers.Remainder < numbers1.Remainder)
                        return -1;
                    return numbers.TotalCount.CompareTo(numbers1.TotalCount);
                });
                var index = 0;
                while (tail != 0)
                {
                    numbersList[index].Result++;
                    index++;
                    tail--;
                }
            }
            Console.WriteLine(string.Join("\n", numbersList.Select(n => $"{n.Name} {n.Result}")));
        }
    }

    public class Numbers
    {
        public string Name { get; set; }
        public long TotalCount { get; set; }
        public long Result { get; set; }
        public long Remainder { get; set; }
    }
}
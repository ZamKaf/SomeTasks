using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace YandexContest
{
    class Program
    {
        static void Main(string[] args)
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

            var baseNumber = summ / places;

            var tail = places;
            foreach (var pair in dictionary)
            {
                if (baseNumber != 0)
                {
                    pair.Value.Result = pair.Value.TotalCount / baseNumber;
                    pair.Value.Remainder = pair.Value.TotalCount % baseNumber;
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
                numbersList.Sort((numbers, numbers1) =>
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
                });
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
    }

    public class Numbers
    {
        public string Name { get; set; }
        public long TotalCount { get; set; }
        public long Result { get; set; }
        public long Remainder { get; set; }
    }
    
    class NumbersReader
    {
        public int ReadInt32()
        {
            return int.Parse(Console.ReadLine());
        }

        public long ReadInt64()
        {
            return long.Parse(Console.ReadLine());
        }

        public int[] ReadInt32Array()
        {
            return Console.ReadLine().Trim(' ').Split(' ').Where(s => s != "")
                .Select(i => int.Parse(i)).ToArray();
        }
        
        public long[] ReadInt64Array()
        {
            return Console.ReadLine().Trim(' ').Split(' ').Where(s => s != "")
                .Select(i => long.Parse(i)).ToArray();
        }
    }
}
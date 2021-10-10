using System;
using System.Collections.Generic;

namespace YandexContest.Algorithms2.DivB.DivB4
{
    public class AStructs : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var n = reader.ReadInt32();
            var sortedDict = new SortedDictionary<long, long>();
            for (var i = 0; i < n; i++)
            {
                var numbers = reader.ReadInt64Array();
                var color = numbers[0];
                var value = numbers[1];
                if (sortedDict.ContainsKey(color))
                {
                    sortedDict[color] += value;
                }
                else
                {
                    sortedDict[color] = value;
                }
            }

            foreach (var key in sortedDict.Keys)
            {
                Console.WriteLine($"{key} {sortedDict[key]}");
            }
        }
    }
}
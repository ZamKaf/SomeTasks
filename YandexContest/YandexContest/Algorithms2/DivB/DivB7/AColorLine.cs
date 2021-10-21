using System;
using System.Collections.Generic;
using System.Globalization;

namespace YandexContest.Algorithms2.DivB.DivB7
{
    public class AColorLine : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var count = reader.ReadInt32();
            var list = new List<Pair>(count * 2);
            for (var i = 0; i < count; i++)
            {
                var nums = reader.ReadInt64Array();
                list.Add(new Pair(nums[0], -1));
                list.Add(new Pair(nums[1], 1));
            }

            list.Sort(((pair1, pair2) => pair1.Value == pair2.Value
                ? pair1.Type.CompareTo(pair2.Type)
                : pair1.Value.CompareTo(pair2.Value)));

            long result = 0;
            var linesCount = 0;
            for (var i = 0; i < list.Count; i++)
            {
                var point = list[i];
                if (linesCount != 0)
                    result += point.Value - list[i - 1].Value;

                if (point.Type == -1)
                    linesCount += 1;
                else
                    linesCount -= 1;
            }

            Console.WriteLine(result);
        }

        class Pair
        {
            public Pair(long value, int type)
            {
                Value = value;
                Type = type;
            }

            public long Value { get; set; }
            public int Type { get; set; }
        }
    }
}
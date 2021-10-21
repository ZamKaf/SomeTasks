using System;
using System.Collections.Generic;

namespace YandexContest.Algorithms2.DivB.DivB7
{
    public class BCustom : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var count = reader.ReadInt32();
            var list = new List<Pair>(count * 2);
            for (var i = 0; i < count; i++)
            {
                var nums = reader.ReadInt64Array();
                list.Add(new Pair(nums[0] + nums[1], -1));
                list.Add(new Pair(nums[0], 1));
            }

            list.Sort(((pair1, pair2) => pair1.Value == pair2.Value
                ? pair1.Type.CompareTo(pair2.Type)
                : pair1.Value.CompareTo(pair2.Value)));

            long result = 0;
            var loadCount = 0;
            foreach (var point in list)
            {
                if (point.Type == -1)
                    loadCount += 1;
                else
                    loadCount -= 1;
                
                result = Math.Max(loadCount, result);
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
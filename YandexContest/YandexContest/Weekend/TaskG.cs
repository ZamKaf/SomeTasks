using System;
using System.Collections.Generic;
using System.Linq;

namespace YandexContest.Weekend
{
    public class TaskG : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var count = reader.ReadInt32();

            var values = new List<RangValue>();
            var sorted = new List<RangeIndex>();
            for (var i = 0; i < count; i++)
            {
                var rang = int.Parse(Console.ReadLine());
                values.Add(new RangValue{Rang = rang});
                sorted.Add(new RangeIndex(rang, i));
            }
            sorted.Sort((r1, r2) =>
            {
                var (rang1, index1) = r1;
                var (rang2, index2) = r2;
                return rang1 != rang2 
                    ? rang1.CompareTo(rang2) 
                    : index1.CompareTo(index2);
            });
            var h = values.Select((e, i) => new { Value = e, Index = i })
                .GroupBy(a => a.Value)
                .ToDictionary(g => g.Key, g => g.Min());
            var sortedPointer = 0;
            while (sortedPointer < sorted.Count)
            {
                var minIndex = sorted[sortedPointer].Index;
                var min = values[minIndex];
                var leftValue = minIndex == 0 || values[minIndex - 1].Rang >= min.Rang 
                    ? 0
                    : values[minIndex - 1].Value;
                var rightValue = minIndex == sorted.Count - 1 || values[minIndex + 1].Rang >= min.Rang 
                    ? 0
                    : values[minIndex + 1].Value;
                min.Value = Math.Max(leftValue, rightValue) + 500;
                sortedPointer++;
            }
            Console.WriteLine(values.Sum(value => value.Value));
        }

        record RangValue
        {
            public int Rang { get; set; }
            public int Value { get; set; }
        }

        record RangeIndex(int Rang, int Index);
    }
}
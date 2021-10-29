using System;
using System.Collections.Generic;

namespace YandexContest.Algorithms2.DivB.DivB7
{
    public class CMinCover : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var m = reader.ReadInt32();
            var list = new List<Point>();
            while (true)
            {
                var nums = reader.ReadInt64Array();
                if (0 == nums[0] && 0 == nums[1])
                    break;
                if (nums[0] < m && nums[1] > 0)
                {
                    var section = $"{nums[0]} {nums[1]}";
                    list.Add(new Point(nums[0], -1, section, nums[1]));
                    list.Add(new Point(nums[1], 1, section, nums[1]));
                }
            }

            list.Sort(((pair1, pair2) => pair1.Value == pair2.Value
                ? pair1.Type.CompareTo(pair2.Type)
                : pair1.Value.CompareTo(pair2.Value)));

            if (list.Count == 0 || list[0].Value > 0 || list[list.Count - 1].Value < m)
            {
                Console.WriteLine("No solution");
                return;
            }

            var answers = new List<string>();
            long covered = 0;
            var maxCurrentSectionEnd = list[0];
            foreach (var point in list)
            {
                if (point.Value > covered)
                {
                    if (maxCurrentSectionEnd.EndOfSection <= covered)
                    {
                        Console.WriteLine("No solution");
                        return;
                    }

                    covered = maxCurrentSectionEnd.EndOfSection;
                    answers.Add(maxCurrentSectionEnd.Section);
                    if (covered >= m)
                        break;
                }

                if (point.Type == -1)
                {
                    if (point.EndOfSection > maxCurrentSectionEnd.EndOfSection)
                    {
                        maxCurrentSectionEnd = point;
                    }
                }
                
            }

            Console.WriteLine(answers.Count);
            answers.ForEach(Console.WriteLine);
        }

        class Point
        {
            public Point(long value, int type, string section, long endOfSection)
            {
                Value = value;
                Type = type;
                Section = section;
                EndOfSection = endOfSection;
            }

            public long Value { get; }
            public int Type { get; }
            public string Section { get; }
            public long EndOfSection { get; }

            public override string ToString()
            {
                var prefix = Type == -1 ? "Begin" : "End";
                return $"{prefix} of {Section}";
            }
        }
    }
}
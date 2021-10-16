using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace YandexContest.Algorithms2.DivB.DivB5
{
    public class ESum : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var sum = reader.ReadInt64();
            var aNumbers = reader.ReadInt64Array().Skip(1);
            var bNumbers = reader.ReadInt64Array().Skip(1);
            var cNumbers = reader.ReadInt64Array().Skip(1);

            var aList = RemoveDuplicates(aNumbers);
            var bList = RemoveDuplicates(bNumbers);
            var cList = RemoveDuplicates(cNumbers);
            aList.Sort(Compare);
            bList.Sort(Compare);
            cList.Sort(Compare);
            var answers = new List<int[]>();
            foreach (var aNumber in aList)
            {
                var a = aNumber.Value;

                var cIndex = cList.Count - 1;

                for (var bIndex = 0; bIndex < bList.Count; bIndex++)
                {
                    var bNumber = bList[bIndex];
                    var b = bNumber.Value;
                    var c = cList[cIndex].Value;
                    if (a + b + c == sum)
                    {
                        answers.Add(new int[] { aNumber.Position, bNumber.Position, cList[cIndex].Position });
                    }
                    else if (a + b + c > sum)
                    {
                        if (cIndex > 0)
                        {
                            cIndex--;
                            bIndex--; // Остаёмся на том же b.
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            if (answers.Count == 0)
            {
                Console.WriteLine(-1);
            }
            else
            {
                answers.Sort(Comparison);
                var answer = answers.First();
                Console.WriteLine($"{answer[0]} {answer[1]} {answer[2]}");
            }
        }

        static int Comparison(int[] x, int[] y)
        {
            for (var i = 0; i < 3; i++)
            {
                if (x[i] > y[i]) return 1;
                if (x[i] < y[i]) return -1;
            }

            return 0;
        }

        static List<Number> RemoveDuplicates(IEnumerable<long> list)
        {
            var dict = new Dictionary<long, Number>();
            var i = 0;
            foreach (var item in list)
            {
                if (!dict.ContainsKey(item))
                    dict[item] = new Number(item, i);
                i++;
            }

            return dict.Values.ToList();
        }

        static int Compare(Number n1, Number n2)
        {
            if (n1.Value > n2.Value) return 1;
            if (n1.Value < n2.Value) return -1;
            return 0;
        }
    }

    class Number
    {
        public Number(long value, int position)
        {
            Value = value;
            Position = position;
        }

        public long Value { get; set; }
        public int Position { get; set; }
    }
}
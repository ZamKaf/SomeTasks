using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
namespace YandexContest
{
    class Program
    {
        static void Main(string[] args)
        {
            var str = Console.ReadLine();
            var rle = ShortedString(str);
            var maxCharCount = new Dictionary<char, long>();
            foreach (var pair in rle)
            {
                if (!maxCharCount.ContainsKey(pair.Char))
                    maxCharCount[pair.Char] = pair.Count;
                else
                    maxCharCount[pair.Char] = Math.Max(maxCharCount[pair.Char], pair.Count);
            }

            var resultCount = maxCharCount.Values.Sum();
            var pairs = new Dictionary<string, Dictionary<long, long>>();
            for (var i = 0; i < rle.Count - 1; i++)
            {
                var first = rle[i];
                var second = rle[i + 1];
                var pair = $"{first.Char}{second.Char}";
                if (!pairs.ContainsKey(pair))
                {
                    pairs[pair] = new Dictionary<long, long> { { first.Count, second.Count } };
                    continue;
                }

                var currentPair = pairs[pair];
                currentPair[first.Count] = currentPair.ContainsKey(first.Count)
                    ? Math.Max(currentPair[first.Count], second.Count)
                    : second.Count;
            }

            foreach (var pair in pairs.Values)
            {
                var sortedKeys = pair.Keys.ToList();
                sortedKeys.Sort();
                sortedKeys.Reverse();

                long maxSecond = 0;
                foreach (var first in sortedKeys)
                {
                    var second = pair[first];
                    if (second <= maxSecond)
                        continue;
                    resultCount += (second - maxSecond) * first;
                    maxSecond = second;
                }
            }

            Console.WriteLine(resultCount);
        }

        static List<CharCount> ShortedString(string str)
        {
            var res = new List<CharCount> { new CharCount('#', 0) };
            foreach (var c in str)
            {
                var last = res[res.Count - 1];
                if (last.Char == c)
                    last.Count++;
                else
                    res.Add(new CharCount(c, 1));
            }

            return res.GetRange(1, res.Count - 1);
        }


        class CharCount
        {
            public CharCount(char c, long count)
            {
                Char = c;
                Count = count;
            }
            public char Char { get; set; }
            public long Count { get; set; }

            public override string ToString()
            {
                return $"{Char}{Count}";
            }

            public void Deconstruct(out char c, out long count)
            {
                c = Char;
                count = Count;
            }
        }


        static void ShowPrefix()
        {
            var reader = new NumbersReader();
            var array = reader.ReadInt64Array();
            var arrayLen = array.Length;
            var prefix = new long[arrayLen + 1];
            for (var i = 1; i < arrayLen + 1; i++)
            {
                prefix[i] = prefix[i - 1] + array[i - 1];
            }

            Console.WriteLine(string.Join(" ", prefix));
        }
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace YandexContest.Algorithms2.DivA.DivA5
{
    public class EStrangeStrings : IRunnable
    {
        public void Run()
        {
            var str = Console.ReadLine();
            var rle = ShortedString(str);
            var maxCharCount = new Dictionary<char, long>();
            foreach (var (c, count) in rle)
            {
                if (!maxCharCount.ContainsKey(c))
                    maxCharCount[c] = count;
                else
                    maxCharCount[c] = Math.Max(maxCharCount[c], count);
            }

            var resultCount = maxCharCount.Values.Sum();
            var pairs = new Dictionary<string, Dictionary<long, long>>();
            for (var i = 0; i < rle.Count - 1; i++)
            {
                var (char1, count1) = rle[i];
                var (char2, count2) = rle[i + 1];
                var pair = $"{char1}{char2}";
                if (!pairs.ContainsKey(pair))
                {
                    pairs[pair] = new Dictionary<long, long> { { count1, count2 } };
                    continue;
                }

                var currentPair = pairs[pair];
                currentPair[count1] = currentPair.ContainsKey(count1)
                    ? Math.Max(currentPair[count1], count2)
                    : count2;
            }

            foreach (var (_, pair) in pairs)
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

        List<CharCount> ShortedString(string str)
        {
            var res = new List<CharCount> { new('#', 0) };
            foreach (var c in str)
            {
                var last = res[^1];
                if (last.Char == c)
                    last.Count++;
                else
                    res.Add(new(c, 1));
            }

            return res.GetRange(1, res.Count - 1);
        }
    }

    record CharCount(char Char, long Count)
    {
        public long Count { get; set; } = Count;

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
}
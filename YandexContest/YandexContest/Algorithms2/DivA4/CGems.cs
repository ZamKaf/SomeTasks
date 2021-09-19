using System;
using System.Collections.Generic;
using System.Linq;

namespace YandexContest.Algorithms2.DivA4
{
    public class CGems : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var nums = reader.ReadInt32Array();
            var gemsCount = nums[0];
            var pairsCount = nums[1];
            var gems = Console.ReadLine();
            var pairs = new Dictionary<char, List<char>>();
            var secondGemCount = new Dictionary<char, long>();
            for (var i = 0; i < pairsCount; i++)
            {
                var pair = Console.ReadLine();
                var first = pair[0];
                var second = pair[1];
                if (pairs.ContainsKey(first))
                    pairs[first].Add(second);
                else
                    pairs[first] = new List<char>{second};
                if (!secondGemCount.ContainsKey(second))
                    secondGemCount[second] = 0;
            }

            long summ = 0;
            for (var i = gemsCount - 1; i >= 0; i--)
            {
                var current = gems[i];
                if (pairs.ContainsKey(current))
                    summ += pairs[current].Sum(c => secondGemCount[c]);

                if (secondGemCount.ContainsKey(current))
                    secondGemCount[current]++;
            }
            Console.WriteLine(summ);
        }
    }
}
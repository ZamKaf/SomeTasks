using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YandexContest.Algorithms2.DivA.DivA4
{
    public class APalindrome : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var length = reader.ReadInt32();
            var str = Console.ReadLine();
            var counts = new Dictionary<char, int>();
            foreach (var letter in str)
            {
                if (counts.ContainsKey(letter))
                    counts[letter]++;
                else
                    counts[letter] = 1;
            }

            var chars = new List<char>(counts.Keys);
            chars.Sort();
            var sb = new StringBuilder();
            var firstOdd = "";
            var oddFound = false;
            foreach (var c in chars)
            {
                if (!oddFound)
                {
                    oddFound = counts[c] % 2 == 1;
                    if (oddFound)
                    {
                        firstOdd = $"{c}";
                    }
                }
                var halfCount = counts[c] / 2;
                if (halfCount > 0)
                    sb.Append(Enumerable.Repeat(c, halfCount).ToArray());
            }

            var half = sb.ToString();
            Console.WriteLine(half + (oddFound ? firstOdd : "") + new string(half.Reverse().ToArray()));
        }
    }
}
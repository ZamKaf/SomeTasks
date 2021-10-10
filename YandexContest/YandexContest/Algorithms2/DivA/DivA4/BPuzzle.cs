using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YandexContest.Algorithms2.DivA.DivA4
{
    public class BPuzzle : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var nums = reader.ReadInt32Array();
            var tableSize = nums[0];
            var wordsCount = nums[1];
            var letters = new Dictionary<char, int>();
            for (var i = 0; i < tableSize; i++)
            {
                var word = Console.ReadLine();
                foreach (var c in word)
                {
                    if (letters.ContainsKey(c))
                        letters[c]++;
                    else
                        letters[c] = 1;
                }
            }

            for (var i = 0; i < wordsCount; i++)
            {
                var word = Console.ReadLine();
                foreach (var c in word)
                {
                    if (letters.ContainsKey(c))
                        letters[c]--;
                    else
                        Console.WriteLine("ERROR");
                }
            }

            var sb = new StringBuilder();
            foreach (var letter in letters)
            {
                sb.Append(Enumerable.Repeat(letter.Key, letter.Value).ToArray());
            }
            Console.WriteLine(sb.ToString());
        }
    }
}
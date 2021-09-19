﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YandexContest
{
    class Program
    {
        static void Main(string[] args)
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
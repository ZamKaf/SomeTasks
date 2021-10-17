using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using YandexContest.Algorithms2.DivB.DivB5;

namespace YandexContest
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class NumbersReader
    {
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
                .Select(int.Parse).ToArray();
        }

        public long[] ReadInt64Array()
        {
            return Console.ReadLine().Trim(' ').Split(' ').Where(s => s != "")
                .Select(long.Parse).ToArray();
        }
    }
}
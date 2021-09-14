using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace YandexContest.Algorithms2.DivB4
{
    public class BUsa :IRunnable
    {
        public void Run()
        {
            const string inFileName = "input.txt";
            var dict = new SortedDictionary<string, long>();
            foreach (var line in File.ReadLines(inFileName))
            {
                var splited = line.Split(" ");
                var name = splited[0];
                var voices = long.Parse(splited[1]);
                if (dict.ContainsKey(name))
                {
                    dict[name] += voices;
                }
                else
                {
                    dict[name] = voices;
                }
            }
            Console.WriteLine(string.Join("\n", dict.Keys.Select(k => $"{k} {dict[k]}")));
        }
    }
}
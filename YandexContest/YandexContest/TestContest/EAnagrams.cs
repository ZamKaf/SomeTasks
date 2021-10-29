using System;
using System.Collections.Generic;

namespace YandexContest.TestContest
{
    public class EAnagrams : IRunnable
    {
        public void Run()
        {
            
            var line1 = Console.ReadLine();
            var line2 = Console.ReadLine();
            var dict = new Dictionary<char, int>();
            foreach (var c in line1)
            {
                if (!dict.ContainsKey(c))
                    dict[c] = 1;
                else
                    dict[c]++;
            }
            foreach (var c in line2)
            {
                if (!dict.ContainsKey(c))
                {
                    Console.WriteLine(0);
                    return;
                }

                dict[c]--;
                if (dict[c] <= 0)
                    dict.Remove(c);
            }
            Console.WriteLine(dict.Count == 0 ? 1: 0);
        }
    }
}
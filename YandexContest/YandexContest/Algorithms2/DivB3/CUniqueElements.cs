using System;
using System.Collections.Generic;

namespace YandexContest.Algorithms2.DivB3
{
    public class CUniqueElements : IRunnable
    {
        public void Run()
        {
            var numbers = new NumbersReader().ReadInt32Array();
            var dict = new Dictionary<int, int>();
            foreach (var number in numbers)
            {
                if (dict.ContainsKey(number))
                {
                    dict[number]++;
                }
                else
                {
                    dict[number] = 1;
                }
            }
            Console.WriteLine(string.Join(" ", dict.Values));
        }
    }
}
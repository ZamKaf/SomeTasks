using System;
using System.Collections.Generic;

namespace YandexContest.Algorithms2.DivB3
{
    public class BWasBefore :IRunnable
    {
        public void Run()
        {
            var numbers = new NumbersReader().ReadInt32Array();
            var set = new HashSet<int>();
            foreach (var number in numbers)
            {
                if (set.Contains(number))
                {
                    Console.WriteLine("YES");
                }
                else
                {
                    set.Add(number);
                    Console.WriteLine("NO");
                }
            }
        }
    }
}
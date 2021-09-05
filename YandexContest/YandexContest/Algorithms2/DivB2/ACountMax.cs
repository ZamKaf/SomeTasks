using System;
using System.Collections.Generic;

namespace YandexContest.Algorithms2.DivB2
{
    public class ACountMax :IRunnable
    {
        public void Run()
        {
            var max = 0;
            var count = 0;
            var current = 0;
            while ((current = int.Parse(Console.ReadLine())) != 0)
            {
                if (current > max)
                {
                    max = current;
                    count = 1;
                }
                else if (current == max)
                {
                    count++;
                }
            }
            Console.WriteLine(count);
        }
    }
}
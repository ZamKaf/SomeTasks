using System;
using System.Collections.Generic;
using System.Linq;

namespace YandexContest.Weekend
{
    public class TaskB : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var nums = reader.ReadInt64Array();
            var n = nums[0];
            var x = nums[1];
            var k = nums[2];
            var deadlines = reader.ReadInt64Array();
            var dict = new Dictionary<long, long>();
            foreach (var deadline in deadlines)
            {
                var rem = deadline % x;
                if (!dict.ContainsKey(rem))
                    dict[rem] = deadline;
                else
                    dict[rem] = Math.Min(deadline, dict[rem]);
            }

            var dlDays = dict.Values;

            long left = 1;
            var right = deadlines[0] + x * k;
            while (left < right)
            {
                var day = (left + right) / 2;
                var clickCount = dlDays.Where(dl => dl <= day).Sum(dl => (day - dl) / x + 1);
                if (clickCount >= k)
                    right = day;
                else
                    left = day + 1;
            }
            
            Console.WriteLine(left);
        }
    }
}
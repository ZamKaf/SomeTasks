using System;
using System.ComponentModel.DataAnnotations;

namespace YandexContest.Algorithms2.DivA.DivA6
{
    public class BTickets : IRunnable
    {
        static long a;
        static long b;
        static long c;
        static long x;
        static long k;
        
        public void Run()
        {
            var reader = new NumbersReader();
            var nums = reader.ReadInt64Array();
            a = nums[0];
            b = nums[1];
            c = nums[2];
            x = nums[3];
            k = nums[4];
            if ((b + 1) * k <= x)
            {
                Console.WriteLine(x/k);
                return;
            }
            var res = Search(0, b, Compare);
            Console.WriteLine(res);
        }

        static long Search(long left, long right, Func<long, bool> compare)
        {
            while (right > left)
            {
                var mid = (right + left + 1) / 2 ;
                if (compare(mid))
                    left = mid;
                else
                    right = mid - 1;
            }

            return left;
        }

        static bool Compare(long value)
        {
            return value < a || value > b 
                ? value * k <= x 
                : value * k * (100 + c) <= x * 100;
        }
    }
}
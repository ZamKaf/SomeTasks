using System;
using System.Collections.Generic;
using System.Linq;

namespace YandexContest
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var c = int.Parse(Console.ReadLine());
            var d = int.Parse(Console.ReadLine());
            if (a == 0 && b == 0)
            {
                Console.WriteLine("INF");
                return;
            }

            if (a == 0 && b != 0)
            {
                Console.WriteLine("NO");
                return;
            }
            
            if (b % a != 0)
            {
                Console.WriteLine("NO");
                return;
            }

            var x = b / a;
            
            if (x * c == d)
            {
                Console.WriteLine("NO");
                return;
            }

            Console.WriteLine(-x);
        }
    }
}
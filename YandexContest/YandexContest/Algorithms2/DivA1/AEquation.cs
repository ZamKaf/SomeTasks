using System;

namespace YandexContest.Algorithms2.DivA1
{
    public class AEquation :IRunnable
    {
        public void Run()
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
            
            if ((double)a / c == (double)b / d)
            {
                Console.WriteLine("NO");
                return;
            }

            if (b % a != 0)
            {
                Console.WriteLine("NO");
                return;
            }
            Console.WriteLine(b/a);
        }
    }
}
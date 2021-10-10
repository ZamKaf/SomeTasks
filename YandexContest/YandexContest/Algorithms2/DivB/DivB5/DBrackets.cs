using System;

namespace YandexContest.Algorithms2.DivB.DivB5
{
    public class DBrackets :IRunnable
    {
        public void Run()
        {
            var str = Console.ReadLine();
            var check = 0;
            foreach (var c in str)
            {
                if ('(' == c)
                    check++;
                else if (')' == c)
                    check--;
                
                if (check < 0)
                {
                    Console.WriteLine("NO");
                    return;
                }
            }
            Console.WriteLine("YES");
        }
    }
}
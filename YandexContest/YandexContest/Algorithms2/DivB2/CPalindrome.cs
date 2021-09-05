using System;

namespace YandexContest.Algorithms2.DivB2
{
    public class CPalindrome :IRunnable
    {
        public void Run()
        {
            var data = Console.ReadLine();
            var len = data.Length;
            if (len < 2)
            {
                Console.WriteLine(0);
                return;
            }

            var cost = 0;
            for (var i = 0; i < len/2; i++)
            {
                if (data[i] != data[len - 1 - i])
                    cost++;
            }
            Console.WriteLine(cost);
        }
    }
}
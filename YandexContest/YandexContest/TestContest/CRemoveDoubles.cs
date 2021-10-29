using System;

namespace YandexContest.TestContest
{
    public class CRemoveDoubles : IRunnable
    {
        public void Run()
        {
            var count = int.Parse(Console.ReadLine());
            if (0 == count)
                return;
            var last = int.Parse(Console.ReadLine());
            Console.WriteLine(last);
            for (var i = 1; i < count; i++)
            {
                var current = int.Parse(Console.ReadLine());
                if (current != last)
                {
                    Console.WriteLine(current);
                    last = current;
                }
            }
        }
    }
}
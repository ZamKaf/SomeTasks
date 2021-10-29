using System;

namespace YandexContest.TestContest
{
    public class B1s : IRunnable
    {
        public void Run()
        {
            var count = int.Parse(Console.ReadLine());
            var maxLen = 0;
            var currentLen = 0;
            for (var i = 0; i < count; i++)
            {
                var n = int.Parse(Console.ReadLine());
                if (0 == n)
                {
                    maxLen = Math.Max(maxLen, currentLen);
                    currentLen = 0;
                }
                else
                {
                    currentLen++;
                }
            }
            maxLen = Math.Max(maxLen, currentLen);
            Console.WriteLine(maxLen);
        }
    }
}
using System;

namespace YandexContest.Algorithms2.DivA.DivA5
{
    public class DBrackets : IRunnable
    {
        public void Run()
        {
            var data = Console.ReadLine();
            var status = 0;
            var total = (data.Length + 1)*(data.Length + 2) / 2;
            var lastZero = -1;
            for (var i = 0; i < data.Length; i++)
            {
                if (data[i] == '(')
                    status++;
                else
                    status--;
                if (0 == status)
                {
                    total += (i - lastZero - 1)*(i - lastZero) / 2;

                    lastZero = i;
                }
            }
            Console.WriteLine(total);
        }
    }
}
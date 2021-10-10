using System;

namespace YandexContest.Algorithms2.DivB.DivB5
{
    public class BMaxSum : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var arrayLen = reader.ReadInt32();
            var array = reader.ReadInt64Array();
            var prefix = new long[arrayLen + 1];
            var max = array[0];
            var localMin = array[0];
            var min = array[0];
            
            for (var i = 1; i < arrayLen + 1; i++)
            {
                prefix[i] = prefix[i - 1] + array[i-1];
                if (prefix[i] > max)
                {
                    max = prefix[i];
                    localMin = min;
                }

                if (prefix[i] < min)
                    min = prefix[i];
            }
            Console.WriteLine(max - localMin);
        }
    }
}
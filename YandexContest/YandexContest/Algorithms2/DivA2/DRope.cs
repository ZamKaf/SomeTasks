using System;
using System.Linq;

namespace YandexContest.Algorithms2.DivA2
{
    public class DRope : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var count = reader.ReadInt32();
            var ropes = reader.ReadInt32Array();
            var max = ropes.Max();
            var sum = ropes.Sum();
            if (ropes.Count(r => r == max) > 1 ||
                sum - max >= max)
            {
                Console.WriteLine(sum);
                return;
            }

            Console.WriteLine(2*max - sum);
        }
    }
}
using System;
using System.Linq;

namespace YandexContest.Algorithms2.DivA2
{
    public class AConfuse : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var nums1 = reader.ReadInt32Array();
            var n = nums1[0];
            var k = nums1[1];
            var array = reader.ReadInt64Array();
            var delta = array.Max() - array.Min();
            if (k % 2 == 1)
                delta *= -1;
            Console.WriteLine(delta);
        }
    }
}
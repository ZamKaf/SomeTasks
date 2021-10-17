using System;
using System.Reflection.Metadata;
using YandexContest.Algorithms2.CommonAlgorithms;

namespace YandexContest.Algorithms2.DivB.DivB6
{
    public class CCubicEquation : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var nums = reader.ReadInt32Array();
            var a = nums[0];
            var b = nums[1];
            var c = nums[2];
            var d = nums[3];
            
            var res = BinarySearcher.FloatSearch(int.MinValue, int.MaxValue, 
                0.000001, new CubicEqComparer(a, b, c, d));
            Console.WriteLine(res);
        }
    }

    public class CubicEqComparer : CommonAlgorithms.IBinFloatComparer
    {
        readonly int _a;
        readonly int _b;
        readonly int _c;
        readonly int _d;

        public CubicEqComparer(int a, int b, int c, int d)
        {
            _a = a;
            _b = b;
            _c = c;
            _d = d;
        }

        public bool Compare(double value)
        {
            var res = _a * value * value * value + _b * value * value + _c * value + _d;
            return _a >= 0 ? res >= 0 : res <= 0;
        }
    }
}
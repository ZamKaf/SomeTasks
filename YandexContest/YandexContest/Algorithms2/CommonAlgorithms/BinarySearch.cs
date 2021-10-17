using System.Collections.Generic;

namespace YandexContest.Algorithms2.CommonAlgorithms
{
    public static class BinarySearcher
    {
        public static int Search(IReadOnlyList<long> data, IBinComparer comparer)
        {
            var l = 0;
            var r = data.Count - 1;
            while (l < r)
            {
                var i = (r + l) / 2;
                if (comparer.Compare(data[i]))
                    r = i;
                else
                    l = i + 1;
            }

            return l;
        }

        public static long NumberSearch(long left, long right, IBinComparer comparer)
        {
            while (right > left)
            {
                var i = (right + left) / 2;
                if (comparer.Compare(i))
                    right = i;
                else
                    left = i + 1;
            }

            return right;   
        }

        public static double FloatSearch(double left, double right, double delta, IBinFloatComparer comparer)
        {
            while (right - left > delta)
            {
                var i = (right + left) / 2;
                if (comparer.Compare(i))
                    right = i;
                else
                    left = i;
            }

            return right;
        }
    }

    public class EqComparer : IBinComparer
    {
        readonly long _n;
        public EqComparer(long n)
        {
            _n = n;
        }
        public bool Compare(long value)
        {
            return value >= _n;
        }
    }
    
    public class MoreComparer : IBinComparer
    {
        readonly long _n;
        public MoreComparer(long n)
        {
            _n = n;
        }
        public bool Compare(long value)
        {
            return value > _n;
        }
    }

    public interface IBinComparer
    {
        bool Compare(long value);
    }
    public interface IBinFloatComparer
    {
        bool Compare(double value);
    }
}

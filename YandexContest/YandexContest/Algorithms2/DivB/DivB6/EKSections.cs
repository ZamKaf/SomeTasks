using System;
using System.Collections.Generic;
using System.Linq;
using YandexContest.Algorithms2.CommonAlgorithms;

namespace YandexContest.Algorithms2.DivB.DivB6
{
    public class EKSections : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var nums = reader.ReadInt64Array();
            var pointsCount = nums[0];
            var sectionsCount = nums[1];
            var points = reader.ReadInt64Array().ToList();
            points.Sort();
            var res = BinarySearcher.NumberSearch(1, points[points.Count-1] - points[0] + 1, new PointsComparer(points, sectionsCount));
            Console.WriteLine(res);
        }
    }

    class PointsComparer : CommonAlgorithms.IBinComparer
    {
        readonly IReadOnlyList<long> _list;
        readonly long _sectionsCount;

        public PointsComparer(IReadOnlyList<long> list, long sectionsCount)
        {
            _list = list;
            _sectionsCount = sectionsCount;
        }

        public bool Compare(long value)
        {
            var nextPoint = _list[0];
            for (var i = 0; i < _sectionsCount; i++)
            {
                if (nextPoint >= _list[_list.Count - 1] - value)
                {
                    return true;
                }
                var covered = nextPoint + value;
                var nextIndex = Search(_list, new MoreComparer(covered));
                nextPoint = _list[nextIndex];
            }

            return false;
        }

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
    }
}
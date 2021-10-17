using System;
using YandexContest.Algorithms2.CommonAlgorithms;

namespace YandexContest.Algorithms2.DivB.DivB6
{
    public class DDeforestation : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var nums = reader.ReadInt64Array();
            var treesDmitry = nums[0];
            var skipDayDmitry = nums[1];
            var treesFedor = nums[2];
            var skipDayFedor = nums[3];
            var treesCount = nums[4];

            Console.WriteLine(BinarySearcher.NumberSearch(0, 2 * treesCount / treesDmitry,
                new TreesComparer(treesDmitry, skipDayDmitry, treesFedor, skipDayFedor, treesCount)));
        }
    }
    class TreesComparer : CommonAlgorithms.IBinComparer
    {
        readonly long _treesDmitry;
        readonly long _skipDayDmitry;
        readonly long _treesFedor;
        readonly long _skipDayFedor;
        readonly long _treesCount;

        public TreesComparer(long treesDmitry, long skipDayDmitry, long treesFedor, long skipDayFedor, long treesCount)
        {
            _treesDmitry = treesDmitry;
            _skipDayDmitry = skipDayDmitry;
            _treesFedor = treesFedor;
            _skipDayFedor = skipDayFedor;
            _treesCount = treesCount;
        }

        public bool Compare(long value)
        {
            var dmitry = _treesDmitry * ((decimal)value - value / _skipDayDmitry);
            var fedor = _treesFedor * ((decimal)value - value / _skipDayFedor);
            return dmitry >= _treesCount - fedor;
        }
    }
}
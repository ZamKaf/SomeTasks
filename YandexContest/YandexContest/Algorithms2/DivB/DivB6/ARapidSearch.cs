using System;
using System.Collections.Generic;
using System.Linq;
using YandexContest.Algorithms2.CommonAlgorithms;


namespace YandexContest.Algorithms2.DivB.DivB6
{
    public class ARapidSearch : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var masLen = reader.ReadInt32();
            var nums = reader.ReadInt64Array().ToList();
            nums.Sort();
            var requestCount = reader.ReadInt32();
            var answers = new List<int>();
            var max = nums[masLen - 1];
            for (var i = 0; i < requestCount; i++)
            {
                var ask = reader.ReadInt32Array();
                var left = ask[0];
                var right = ask[1];
                var leftIndex = BinarySearcher.Search(nums, new CommonAlgorithms.EqComparer(left));
                var rightIndex = ask[1] > max
                    ? masLen
                    : BinarySearcher.Search(nums, new CommonAlgorithms.MoreComparer(right));
                answers.Add(rightIndex - leftIndex);
            }

            Console.WriteLine(string.Join(" ", answers));
        }
    }
}
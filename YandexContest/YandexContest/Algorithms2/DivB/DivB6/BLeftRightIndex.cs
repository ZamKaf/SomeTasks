using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using YandexContest.Algorithms2.CommonAlgorithms;

namespace YandexContest.Algorithms2.DivB.DivB6
{
    public class BLeftRightIndex : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var masLen = reader.ReadInt32();
            var nums = reader.ReadInt64Array();
            var requestCount = reader.ReadInt32();
            var requests = reader.ReadInt32Array();
            
            var max = nums[masLen - 1];
            var min = nums[0];
            foreach (var request in requests)
            {
                if (request < min || request > max)
                {
                    Console.WriteLine("0 0");
                    continue;
                }
                
                var leftIndex = BinarySearcher.Search(nums, new CommonAlgorithms.EqComparer(request));
                var rightIndex = BinarySearcher.Search(nums, new CommonAlgorithms.MoreComparer(request));
                Console.WriteLine($"{leftIndex} {rightIndex}");
            }
        }
    }
}
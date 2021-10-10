using System;
using System.Collections.Generic;
using System.Linq;

namespace YandexContest.Algorithms2.DivA.DivA5
{
    public class BCandies : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var pairsCount = reader.ReadInt32();
            var candies = new List<long>();
            for (var i = 0; i < pairsCount; i++)
            {
                var nums = reader.ReadInt64Array();
                candies.AddRange(Enumerable.Repeat(nums[1], (int)nums[0]));
            }

            var leftPointer = 0;
            var rightPointer = candies.Count - 1;
            while (rightPointer - leftPointer > 1)
            {
                var left = candies[leftPointer];
                var right = candies[rightPointer];

                if (left < right)
                {
                    leftPointer++;
                    candies[leftPointer] += left;
                    candies[rightPointer] -= left;
                    candies[rightPointer - 1] += left;
                }
                
                if (left > right)
                {
                    rightPointer--;
                    candies[rightPointer] += right;
                    candies[leftPointer] -= right;
                    candies[leftPointer + 1] += right;
                }

                leftPointer++;
                candies[leftPointer] += left;
                rightPointer--;
                candies[rightPointer] += right;
            }

            if (leftPointer == rightPointer)
            {
                Console.WriteLine(1);
                Console.WriteLine(candies[leftPointer]);
            }
            else
            {
                Console.WriteLine(2);
                Console.WriteLine($"{candies[leftPointer]} {candies[rightPointer]}");
            }
        }
    }
}
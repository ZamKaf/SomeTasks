using System;
using System.Collections.Generic;

namespace YandexContest.Algorithms2.DivB.DivB5
{
    public class APrefixSum : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var nums = reader.ReadInt32Array();
            var arrayLen = nums[0];
            var requestsCount = nums[1];
            var array = reader.ReadInt64Array();
            var prefix = new long[arrayLen + 1];
            for (var i = 1; i < arrayLen + 1; i++)
            {
                prefix[i] = prefix[i - 1] + array[i-1];
            }

            var answers = new List<long>();
            for (var i = 0; i < requestsCount; i++)
            {
                var rq = reader.ReadInt32Array();
                answers.Add(prefix[rq[1]] - prefix[rq[0] - 1]);
            }
            answers.ForEach(Console.WriteLine);
        }
    }
}
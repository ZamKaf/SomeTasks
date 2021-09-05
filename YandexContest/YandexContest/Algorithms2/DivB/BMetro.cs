using System;
using System.Linq;

namespace YandexContest.Algorithms2.DivB
{
    public class BMetro : IRunnable
    {
        public void Run()
        {
            var nums = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            var count = nums[0];
            var stationIn = Math.Min(nums[1], nums[2]);
            var stationOut = Math.Max(nums[1], nums[2]);
            var result = Math.Min(stationOut - stationIn, count - stationOut + stationIn) - 1;
            Console.WriteLine(result);
        }
    }
}
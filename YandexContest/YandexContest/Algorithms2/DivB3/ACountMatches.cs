using System;
using System.Collections.Generic;

namespace YandexContest.Algorithms2.DivB3
{
    public class ACountMatches : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var firstSet = new HashSet<int>(reader.ReadInt32Array());
            var secondSet = new HashSet<int>(reader.ReadInt32Array());
            firstSet.IntersectWith(secondSet);
            Console.WriteLine(firstSet.Count);
        }
    }
}
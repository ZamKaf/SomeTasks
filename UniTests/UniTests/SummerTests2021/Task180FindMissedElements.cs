using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace UniTests.SummerTests2021
{
    public class Task180FindMissedElements : ITest
    {
        public List<int> GetMissingNumbers(int[] arr)
        {
            var set = new HashSet<int>(arr);
            return Enumerable.Range(1, arr.Length).Where(i => !set.Contains(i)).ToList();
        }
        
        public void Run()
        {
            var testList = new[] { 4, 3, 2, 7, 8, 2, 3, 1, 1 };
            foreach (var number in GetMissingNumbers(testList))
            {
                Console.Write($"{number} ");
            }
            Console.WriteLine();
        }
    }
}
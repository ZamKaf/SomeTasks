using System;

namespace UniTests.SummerTests2021
{
    public class Task178MaxCountBeer :ITest 
    {
        public int MaxBeerBottles(int n, int k)
        {
            var maxCount = 0;
            var current = n;
            while (current >= k)
            {
                var cashback = current / k;
                maxCount += cashback * k;
                current = cashback + current % k;
            }
            maxCount += current;
            
            return maxCount;
        }
        
        public void Run()
        {
            var n = 8;
            var k = 5;
            Console.WriteLine($"4 n = {n} and k = {k} result is {MaxBeerBottles(n, k)}");
        }
    }
}
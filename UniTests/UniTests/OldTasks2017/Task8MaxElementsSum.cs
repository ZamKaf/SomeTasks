using System;

namespace UniTests.OldTasks2017
{
    public class Task8MaxElementsSum : ITask
    {
        public int FindMaxSum(int[] elements)
        {
            var maxSum = 0;
            var deltaSum = 0;
            var firstPositiveFound = false;
            foreach (var element in elements)
            {
                if (element > 0)
                {
                    firstPositiveFound = true;
                    if (maxSum + deltaSum + element > maxSum)
                    {
                        maxSum += deltaSum + element;
                        deltaSum = 0;
                        continue;
                    }
                }
                if (firstPositiveFound)
                    deltaSum += element;
            }

            return maxSum < 0 ? 0 : maxSum;
        }
        
        public void Run()
        {
            var mas = new[] { -1, 10, -9, -5, 6, -10 };
            Console.WriteLine($"max sum of array [{string.Join(", ", mas)}] is {FindMaxSum(mas)}");
        }
    }
}
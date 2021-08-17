using System;

namespace UniTests.OldTasks2017
{
    public class Task4IndexOfElemInSortedShiftedArray : ITest
    {
        public int GetIndex(int[] mas, int elem)
        {
            var minIndex = 0;
            var maxIndex = mas.Length - 1;
            while (maxIndex - minIndex > 1)
            {
                var midIndex = (minIndex + maxIndex) / 2;
                var currentElem = mas[midIndex]; 
                if (currentElem == elem)
                    return midIndex;
                if (currentElem < elem )
                {
                    minIndex = midIndex;
                    continue;
                }

                if (elem >= mas[minIndex])
                {
                    maxIndex = midIndex;
                }
                else
                {
                    minIndex = midIndex;
                }
            }

            if (elem == mas[maxIndex]) return maxIndex;
            if (elem == mas[minIndex]) return minIndex;
            throw new IndexOutOfRangeException();
        }
        
        public void Run()
        {
            var array = new[] { 5, 6, 7, 8, 1, 2, 3, 4 };
            var elem = 7;
            Console.WriteLine($"index of {elem} in [{string.Join(", ", array)}] is {GetIndex(array, elem)}");
        }
    }
}
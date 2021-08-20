using System;

namespace UniTests.OldTasks2017
{
    public class Task2MinInSortedShiftedArray : ITask
    {
        public int GetElem(int[] array)
        {
            var minIndex = 0;
            var maxIndex = array.Length - 1;
            while (maxIndex - minIndex != 1)
            {
                var midIndex = (maxIndex + minIndex) / 2;
                if (array[midIndex] > array[maxIndex])
                    minIndex = midIndex;
                if (array[minIndex] > array[midIndex])
                    maxIndex = midIndex;
            }
            return array[maxIndex];
        }
        
        public void Run()
        {
            var mas = new[] { 5, 6, 1, 2, 3, 4 };
            Console.WriteLine($"min in sorted shifted array [{string.Join(", ", mas)}] is {GetElem(mas)}");
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace SomeTasks.Vovan
{
    /// <summary>
    /// Не добита) вход отсортированых целых чисел, нужно вывести отсортированные квадраты.
    /// </summary>
    public class Task2 : IRunnable
    {
        public void Run()
        {
            var mas = Enumerable.Range(-20, 40).ToList();
            Console.WriteLine(string.Join(" ", SortedSqr(mas)));
        }

        IEnumerable<int> SortedSqr(IReadOnlyCollection<int> list)
        {
            var totalCount = list.Count;
            
            var negativeSqr = list.Where(i => i < 0).Select(s => s* s).Reverse().ToList();
            var positiveSqr = list.Where(i => i >= 0).Select(s => s* s).ToList();
            negativeSqr.Add(int.MaxValue);
            positiveSqr.Add(int.MaxValue);

            var result = new List<int>(totalCount);
            var negativeIndex = 0;
            var positiveIndex = 0;
            while (negativeIndex < negativeSqr.Count - 1 || positiveIndex < positiveSqr.Count - 1)
            {
                var positive = positiveSqr[positiveIndex];
                var negative = negativeSqr[negativeIndex];
                
                if (positive < negative)
                {
                    result.Add(positive);
                    positiveIndex++;
                }
                else
                {
                    result.Add(negative);
                    negativeIndex++;
                }
            }

            return result;
        }
    }
}
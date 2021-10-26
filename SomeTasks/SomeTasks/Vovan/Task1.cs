using System;
using System.Collections.Generic;

namespace SomeTasks.Vovan
{
    /// <summary>
    /// Найти локальный минимум в массиве (элемент, у которого оба соседа не меньше его, вкл граничные)
    /// </summary>
    public class Task1 : IRunnable
    {
        public void Run()
        {
            var mas = new[] { 3, 2, 5, 4, 7, 10 };
            Console.WriteLine(LocalMinOLogN(mas));
        }

        int LocalMinOLogN(IReadOnlyList<int> mas)
        {
            if (mas.Count == 1)
                return 0;
            if (mas.Count == 0)
                return -1;

            if (mas[0] <= mas[1])
                return 0;
            if (mas[^1] <= mas[^2])
                return mas.Count - 1;

            var left = 1;
            var right = mas.Count - 2;
            var index = -1;
            while (left < right)
            {
                var current = (left + right) / 2;
                if (CheckMin(mas, current))
                {
                    index = current;
                    break;
                }

                if (mas[current - 1] < mas[current])
                    right = current;
                else
                    left = current;
                Console.WriteLine("wert");
            }

            return index;
        }

        bool CheckMin(IReadOnlyList<int> mas, int current) =>
            mas[current - 1] >= mas[current] && mas[current] < mas[current + 1];
        

        int LocalMinOn(IReadOnlyList<int> mas)
        {
            if (mas.Count < 3)
                return -1;
            for (var i = 2; i < mas.Count - 1; i++)
            {
                if (mas[i - 1] > mas[i] && mas[i] < mas[i + 1])
                {
                    return i;
                }
            }

            return -1;
        }
    }
}
using System;

namespace SomeTasks.Vovan
{
    public class Task6 : IRunnable
    {
        public void Run()
        {
            var data = new[] { 1, 2, 3, 0,4, 5, 6, 0, 0, 0, 0, 75, 0, 423, 4, 2, 5 };
            MoveZeros(data);
            Console.WriteLine(string.Join(" ", data));
        }

        void MoveZeros(int[] mas)
        {
            var i = 0;
            while (mas[i] != 0)
                i++;
            if (i >= mas.Length - 1)
                return;
            
            var left = i;

            for (var k = i + 1; k < mas.Length; k++)
            {
                if (mas[k] != 0)
                {
                    (mas[left], mas[k]) = (mas[k], mas[left]);
                    left++;
                }
            }
        }
    }
}
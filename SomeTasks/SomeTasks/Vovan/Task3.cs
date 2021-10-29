using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SomeTasks.Vovan
{
    /// <summary>
    /// Вывести матрицу спирально из центра
    /// </summary>
    public class Task3 : IRunnable
    {
        public void Run()
        {
            const int rowsCount = 41;
            
            var data = new List<int[]>();
            for (var i = 0; i < rowsCount; i++)
            {
                data.Add(Enumerable.Range(100, rowsCount).ToArray());
            }

            var res = Spiral(data);
            Console.WriteLine(string.Join(" ", res));;
        }

        List<int> Spiral(List<int[]> data)
        {
            var rowsCount = data.Count;
            if (rowsCount == 0)
                return new List<int>();
            return rowsCount % 2 == 1
                ? SpiralOdd(data)
                : SpiralEven(data);

        }
        List<int> SpiralOdd(List<int[]> data)
        {
            var rowsCount = data.Count;
            var result = new List<int>(rowsCount * rowsCount);
            var currentRow = rowsCount / 2;
            var currentColumn = rowsCount / 2;

            result.Add(data[currentRow][currentColumn]);
            var limit = 1;
            while (true)
            {
                if (currentRow == 0 && currentColumn == 0)
                {
                    break;
                }

                currentRow--;
                result.Add(data[currentRow][currentColumn]);

                for (var i = 0; i < limit; i++)
                {
                    currentColumn++;
                    result.Add(data[currentRow][currentColumn]);
                }

                for (var i = 0; i <= limit; i++)
                {
                    currentRow++;
                    result.Add(data[currentRow][currentColumn]);
                }
                
                for (var i = 0; i <= limit; i++)
                {
                    currentColumn--;
                    result.Add(data[currentRow][currentColumn]);
                }
                
                for (var i = 0; i <= limit; i++)
                {
                    currentRow--;
                    result.Add(data[currentRow][currentColumn]);
                }

                limit += 2;
            }

            return result;
        }
        List<int> SpiralEven(List<int[]> data)
        {
            var rowsCount = data.Count;
            var result = new List<int>(rowsCount * rowsCount);
            var currentRow = rowsCount / 2 - 1;
            var currentColumn = rowsCount / 2 - 1;

            result.Add(data[currentRow][currentColumn]);
            currentColumn++;
            result.Add(data[currentRow][currentColumn]);
            currentRow++;
            result.Add(data[currentRow][currentColumn]);
            currentColumn--;
            result.Add(data[currentRow][currentColumn]);

            var limit = 2;
            while (true)
            {
                if (currentRow == rowsCount - 1 && currentColumn == 0)
                {
                    break;
                }

                currentColumn--;
                result.Add(data[currentRow][currentColumn]);

                for (var i = 0; i < limit; i++)
                {
                    currentRow--;
                    result.Add(data[currentRow][currentColumn]);
                }

                for (var i = 0; i <= limit; i++)
                {
                    currentColumn++;
                    result.Add(data[currentRow][currentColumn]);
                }
                
                for (var i = 0; i <= limit; i++)
                {
                    currentRow++;
                    result.Add(data[currentRow][currentColumn]);
                }
                
                for (var i = 0; i <= limit; i++)
                {
                    currentColumn--;
                    result.Add(data[currentRow][currentColumn]);
                }

                limit += 2;
            }

            return result;
        }
        
    }
}
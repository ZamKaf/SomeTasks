using System;
using System.Collections.Generic;
using System.Linq;

namespace YandexContest.Weekend
{
    public class TaskF : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var k = reader.ReadInt64();
            var size = reader.ReadInt64Array();
            var m = size[0];
            var n = size[1];
            var data = new List<long[]>();
            for (var i = 0; i < m; i++)
            {
                var nums = reader.ReadInt64Array();
                data.Add(nums);
            }
            var prefixes = new List<Prefix[]>();
            var rectangles = GetRectangles(k);
            long max = 0;
            for (var i = 0; i < m; i++) 
            {
                prefixes.Add(new Prefix[n]);
                for (var j = 0; j < n; j++) // по столбцам
                {
                    var leftSum = 0 == i
                        ? data[i][j]
                        : prefixes[i - 1][j].LeftLineSum + data[i][j];
                    var p = new Prefix
                    {
                        LeftLineSum = leftSum,
                        
                        TotalValue = j == 0
                            ? leftSum
                            : prefixes[i][j - 1].TotalValue + leftSum
                    };

                    prefixes[i][j] = p;

                    foreach (var rectangle in rectangles.Where(r => r.X <= j + 1 && r.Y <= i + 1))
                    {
                        var left = j - rectangle.X + 1;
                        var top = i - rectangle.Y + 1;
                        long res = 0;
                        if (left == 0 && top == 0)
                        {
                            res = p.TotalValue;
                        }
                        else if (left == 0)
                        {
                            res = p.TotalValue - prefixes[(int)top - 1][j].TotalValue;
                        }
                        else if (top == 0)
                        {
                            res = p.TotalValue - prefixes[i][left - 1].TotalValue;
                        }
                        else
                        {
                            res = p.TotalValue - prefixes[(int)top - 1][j].TotalValue - prefixes[i][left - 1].TotalValue;
                        }

                        max = Math.Max(max, res);
                    }
                }
            }
            Console.WriteLine(max);

            static List<Rectangle> GetRectangles(long k)
            {
                var res = new List<Rectangle>();
                for (var i = 1; i <= k; i++)
                {
                    for (var j = 1; j <= k/i; j++)
                    {
                        res.Add(new Rectangle(i, j));
                    }
                }

                return res;
            }
        }

        class Rectangle
        {
            public Rectangle(long x, long y)
            {
                X = x;
                Y = y;
            }

            public long X { get; }
            public long Y { get; }
        }

        class Prefix
        {
            public long LeftLineSum { get; set; }
            public long TotalValue { get; set; }
        }
    }
}
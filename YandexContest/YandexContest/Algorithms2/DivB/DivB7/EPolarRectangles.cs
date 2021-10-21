using System;
using System.Collections.Generic;

namespace YandexContest.Algorithms2.DivB.DivB7
{
    public class EPolarRectangles : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var count = reader.ReadInt32();
            double insudeRarius = 0;
            double outsideRadius = double.MaxValue;
            var points = new List<Point>();
            for (var i = 0; i < count; i++)
            {
                var nums = reader.ReadDoubleArray();
                insudeRarius = Math.Max(insudeRarius, nums[0]);
                outsideRadius = Math.Min(outsideRadius, nums[1]);
                var open = nums[2];
                var close = nums[3];
                points.Add(new Point
                {
                    Value = close,
                    Type = -1,
                    SectionIndex = 1,
                });
                points.Add(new Point
                {
                    Value = open,
                    Type = 1,
                    SectionIndex = 1,
                });
            }

            var ringArea = outsideRadius * outsideRadius - insudeRarius * insudeRarius; // пи пропущено, т.к. сократится позднее.
            
            var opened = new HashSet<int>();
            var openedCount = 0;
            double area = 0;
            double crossBeginPoint = 0;
            var crossBegins = false;
            foreach (var point in points)
            {
                var index = point.SectionIndex; 
                if (point.Type == -1)
                {
                    if (!opened.Contains(index))
                        continue;
                    opened.Remove(index);
                    openedCount--;
                    if (crossBegins)
                    {
                        crossBegins = false;
                        area += ringArea * (point.Value - crossBeginPoint) / 2;
                    }
                }
                else
                {
                    opened.Add(index);
                    openedCount++;
                    if (openedCount == count)
                    {
                        crossBegins = true;
                        crossBeginPoint = point.Value;
                    }
                }
            }
            
            foreach (var point in points)
            {
                var index = point.SectionIndex; 
                if (point.Type == -1)
                {
                    openedCount--;
                    if (opened.Contains(index))
                        opened.Remove(index);
                    if (crossBegins)
                    {
                        crossBegins = false;
                        if (point.Value > crossBeginPoint)
                            area += ringArea * (point.Value - crossBeginPoint) / 2;
                        else
                            area += ringArea * (2*Math.PI - (crossBeginPoint - point.Value)) / 2;
                    }
                }
                else
                {
                    openedCount++;
                    if (openedCount == count)
                    {
                        crossBegins = true;
                        crossBeginPoint = point.Value;
                    }
                }

                if (opened.Count == 0)
                    break;
            }
            Console.WriteLine(area);
        }

        class Point
        {
            public double Value { get; set; }
            public int Type { get; set; }
            public int SectionIndex { get; set; }
        }
    }
}
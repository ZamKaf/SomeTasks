using System;
using System.Collections.Generic;

namespace YandexContest.Algorithms2.DivB.DivB7
{
    public class EPolarRectangles : IRunnable
    {
        public void Run()
        {
            //const string inFile = "input.txt";
            //const string outFile = "output.txt";
            var reader = new NumbersReader();
            var count = reader.ReadInt32();

            //var data = File.ReadAllLines(outFile);
            //var count = int.Parse(data[0]);
            double insudeRarius = 0;
            double outsideRadius = double.MaxValue;
            var points = new List<Point>();
            for (var i = 1; i <= count; i++)
            {
                //var line = data[i].Replace(".", ",");
                //var nums = line.Split(" ").Select(double.Parse).ToArray();
                var nums = reader.ReadDoubleArray();
                insudeRarius = Math.Max(insudeRarius, nums[0]);
                outsideRadius = Math.Min(outsideRadius, nums[1]);
                var open = nums[2];
                var close = nums[3];
                points.Add(new Point
                {
                    Value = close,
                    Type = -1,
                    SectionIndex = i,
                });
                points.Add(new Point
                {
                    Value = open,
                    Type = 1,
                    SectionIndex = i,
                });
            }

            var ringArea = outsideRadius * outsideRadius - insudeRarius * insudeRarius; // пи пропущено, т.к. сократится позднее.
            if (ringArea <= 0)
            {
                Console.WriteLine(0);
                //File.WriteAllText(outFile,$"0");
                return;
            }
            points.Sort(Comparison);

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

            var res = $"{area:F10}".Replace(",", ".");
            Console.WriteLine(res);
            //File.WriteAllText(outFile, res);
        }

        static int Comparison(Point x, Point y)
        {
            return x.Value.Equals(y.Value)
                ? x.Type.CompareTo(y.Type)
                : x.Value.CompareTo(y.Value);
        }

        class Point
        {
            public double Value { get; set; }
            public int Type { get; set; }
            public int SectionIndex { get; set; }
            public override string ToString()
            {
                var type = Type == 1
                    ? "Begin"
                    : "End";
                return $"{type} {Value} ({SectionIndex})";
            }
        }
    }
}
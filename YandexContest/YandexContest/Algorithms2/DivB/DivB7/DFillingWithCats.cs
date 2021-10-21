using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;

namespace YandexContest.Algorithms2.DivB.DivB7
{
    public class DFillingWithCats : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var nums = reader.ReadInt64Array();
            var catsCount = nums[0];
            var sectionsCount = nums[1];
            var cats = reader.ReadInt64Array();
            var sections = new List<Section>();
            for (var i = 0; i < sectionsCount; i++)
            {
                nums = reader.ReadInt64Array();
                sections.Add(new Section
                {
                    Begin = nums[0],
                    End = nums[1]
                });
            }

            var points = cats.Select(cat => new Point { Value = cat, Type = 0 }).ToList();
            foreach (var section in sections)
            {
                points.Add(new Point
                {
                    Value = section.Begin,
                    Type = -1,
                });
                points.Add(new Point
                {
                    Value = section.End,
                    Type = 1,
                });
            }

            points.Sort(Comparison);

            var catsCurrentCount = 0;
            var prefixCatsBegin = new Dictionary<long, int>();
            var prefixCatsEnd = new Dictionary<long, int>();
            foreach (var point in points)
            {
                switch (point.Type)
                {
                    case 0:
                        catsCurrentCount++;
                        break;
                    case -1:
                    {
                        if (!prefixCatsBegin.ContainsKey(point.Value))
                            prefixCatsBegin[point.Value] = catsCurrentCount;
                        break;
                    }
                    case 1:
                    {
                        if (!prefixCatsEnd.ContainsKey(point.Value))
                            prefixCatsEnd[point.Value] = catsCurrentCount;
                        break;
                    }
                }
            }
            

            foreach (var section in sections)
            {
                Console.WriteLine(prefixCatsEnd[section.End] - prefixCatsBegin[section.Begin]);
            }
        }
        

        static int Comparison(Point x, Point y)
        {
            return x.Value == y.Value ? x.Type.CompareTo(y.Type) : x.Value.CompareTo(y.Value);
        }

        class Section
        {
            public long Begin { get; set; }
            public long End { get; set; }
        }

        class Point
        {
            public long Value { get; set; }
            public int Type { get; set; }
        }
    }
}
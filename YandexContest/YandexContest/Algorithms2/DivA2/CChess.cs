using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Schema;

namespace YandexContest.Algorithms2.DivA2
{
    public class CChess : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var count = reader.ReadInt32();
            var cells = new List<Point>();
            for (var i = 0; i < count; i++)
            {
                var r = reader.ReadInt32Array();
                cells.Add(new Point(r[0], r[1]));
            }

            Console.WriteLine(cells.SelectMany(cell => Neighbors(cell)).Count(neighbor => !cells.Contains(neighbor)));
        }

        List<Point> Neighbors(Point cell)
        {
            var res = new List<Point>
            {
                new Point(cell.X - 1, cell.Y),
                new Point(cell.X + 1, cell.Y),
                new Point(cell.X, cell.Y - 1),
                new Point(cell.X, cell.Y + 1)
            };
            return res;
        }
    }
}
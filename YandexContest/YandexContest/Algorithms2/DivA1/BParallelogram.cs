using System;
using System.Collections.Generic;

namespace YandexContest.Algorithms2.DivA1
{
    public class BParallelogram : IRunnable
    {
        public void Run()
        {
            const int pointsCount = 4;
            var reader = new NumbersReader();
            var count = reader.ReadInt32();
            var questions = new List<Point[]>(count);
            var answers = new string[count];
            for (var i = 0; i < count; i++)
            {
                var questionNumbers = reader.ReadInt32Array();
                var question = new Point[]
                {
                    new()
                    {
                        X = questionNumbers[0],
                        Y = questionNumbers[1],
                    },
                    new()
                    {
                        X = questionNumbers[2],
                        Y = questionNumbers[3],
                    },
                    new()
                    {
                        X = questionNumbers[4],
                        Y = questionNumbers[5],
                    },
                    new()
                    {
                        X = questionNumbers[6],
                        Y = questionNumbers[7],
                    }
                };
                questions.Add(question);
                for (var j = 0; j < 4; j++)
                {
                    if (CheckOneLine(question[j], question[(j + 1) % pointsCount], question[(j + 2) % pointsCount]))
                    {
                        answers[i] = "NO";
                        break;
                    }
                }
            }

            var lines = new List<List<Line>>(pointsCount);
            for (var i = 0; i < count; i++)
            {
                if (answers[i] == "NO")
                {
                    lines.Add(new List<Line>());
                    continue;
                }

                var points = questions[i];
                var questionLines = new List<Line>();
                for (var j = 0; j < pointsCount; j++)
                {
                    for (var k = j + 1; k < pointsCount; k++)
                    {
                        var a = points[j];
                        var b = points[k];
                        var deltaX = b.X - a.X;
                        var deltaY = b.Y - a.Y;
                        var line = new Line
                        {
                            A = deltaY,
                            B = -deltaX,
                            C = -a.X * (deltaY) + a.Y * (deltaX),
                            LenSqr = deltaX * deltaX + deltaY * deltaY
                        };
                        questionLines.Add(line);
                    }
                }

                var correctCoupleCount = 0;
                for (var j = 0; j < 6; j++)
                {
                    var line1 = questionLines[j];
                    for (var k = j+1; k < 6; k++)
                    {
                        var line2 = questionLines[k];
                        if (line1.LenSqr == line2.LenSqr &&
                            line1.A * line2.B == line2.A * line1.B)
                        {
                            correctCoupleCount++;
                        }
                    }
                }

                answers[i] = correctCoupleCount == 2 ? "YES" : "NO";

                //lines.Add(questionLines);
            }

            foreach (var answer in answers)
            {
                Console.WriteLine($"{answer}");
            }
        }

        public static bool CheckOneLine(Point a, Point b, Point c)
        {
            return (c.X - a.X) * (b.Y - a.Y) == (c.Y - a.Y) * (b.X - a.X);
        }
    }

    public class Line
    {
        public int A { get; set; } // x коэффцициент
        public int B { get; set; } // y коэффцициент
        public int C { get; set; } // свободный коэффцициент
        public int LenSqr { get; set; }
    }

    public class Point
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
}
using System;

namespace YandexContest.Algorithms2.DivA2
{
    public class ELawn :IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var numbers = reader.ReadInt64Array();
            var rectangleBot = Math.Min(numbers[1], numbers[3]);
            var rectangleTop = Math.Max(numbers[1], numbers[3]);
            
            var rectangleLeft = Math.Min(numbers[0], numbers[2]);
            var rectangleRight = Math.Max(numbers[0], numbers[2]);
            
            numbers = reader.ReadInt64Array();
            var circleX = numbers[0];
            var circleY = numbers[1];
            var r = numbers[2];
            var circleBot = circleY - r;
            var circleTop= circleY + r;
            long count = 0;
            for (var i = Math.Max(rectangleBot, circleBot); i <= Math.Min(rectangleTop, circleTop); i++)
            {
                if ((i == circleBot ||
                     i == circleTop) &&
                    (circleX >= rectangleLeft &&
                     circleX <= rectangleRight))
                {
                    count++;
                    continue;
                }

                var leg = circleY - i;
                var delta = (int)Math.Floor(Math.Sqrt(r * r - leg * leg));
                var leftPosition = Math.Max(rectangleLeft, circleX - delta);
                var rightPosition = Math.Min(rectangleRight, circleX + delta);
                if (rightPosition >= leftPosition)
                    count += rightPosition - leftPosition + 1;
            }
            Console.WriteLine(count);
        }
    }
    public class Point
    {
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }
        public Point() { }
        public int X { get; set; }
        public int Y { get; set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as Point);
        }

        public bool Equals(Point point)
        {
            if (point is null) return false;
            return X == point.X && Y == point.Y;
        }

        public override int GetHashCode()
        {
            return (X, Y).GetHashCode();
        }

        public static bool operator ==(Point left, Point right)
        {
            if (left is null)
            {
                if (right is null)
                    return true;
                return false;
            }

            return left.Equals(right);
        }

        public static bool operator !=(Point left, Point right) => !(left == right);
    }
}
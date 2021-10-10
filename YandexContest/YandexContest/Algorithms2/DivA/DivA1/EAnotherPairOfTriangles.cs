using System;

namespace YandexContest.Algorithms2.DivA.DivA1
{
    public class EAnotherPairOfTriangles:IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var p = reader.ReadInt32();
            if (p == 4)
            {
                Console.WriteLine(-1);
                return;
            }
            
            var minA = p % 2 == 1 ? 1 : 2;
            var minLines = new int[3]
            {
                minA,
                (p - minA) / 2,
                (p - minA) / 2,
            };

            var maxA = p / 3;
            var excess = p % 3;
            var maxLines = new int[3]
            {
                maxA,
                excess == 2 ? maxA + 1 : maxA,
                excess >= 1 ? maxA + 1 : maxA,
            };
            Console.WriteLine(string.Join(" ", maxLines));
            Console.WriteLine(string.Join(" ", minLines));
        }

        static void TestBroot()
        {
            var reader = new NumbersReader();
            var p = reader.ReadInt32();
            double max = -1;
            double min = double.MaxValue;
            var maxLines = new int[3];
            var minLines = new int[3];
            var start = p % 2 == 1 ? 1 : 2;
            for (var a = start; a < p - 1; a++)
            {
                for (var b = start; b < p - a; b++)
                {
                    var c = p - a - b;
                    if (Check(a, b, c))
                    {
                        var area = Area(a, b, c, p);
                        if (area > max)
                        {
                            max = area;
                            maxLines[0] = a;
                            maxLines[1] = b;
                            maxLines[2] = c;
                        }
                        if (area < min)
                        {
                            min = area;
                            minLines[0] = a;
                            minLines[1] = b;
                            minLines[2] = c;
                        }
                    }
                }
            }

            if (max == -1)
            {
                Console.WriteLine(-1);
            }
            else
            {
                Console.WriteLine(string.Join(" ", maxLines));
                Console.WriteLine(string.Join(" ", minLines));   
            }
        }

        static bool Check(int a, int b, int c)
        {
            return a < b + c && b < a + c && c < a + b;
        }

        static double Area(int a, int b, int c, int p)
        {
            return (1 - (double)a / p) * (1 - (double)b / p) * (1 - (double)c / p);
        }
    }
}
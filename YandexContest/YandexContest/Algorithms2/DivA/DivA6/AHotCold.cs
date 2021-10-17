using System;
using System.IO;
using Microsoft.VisualBasic;

namespace YandexContest.Algorithms2.DivA.DivA6
{
    public class AHotCold : IRunnable
    {
        public void Run()
        {
            const int border = 1000000000; 
            var x = Search(0, border, (n) => AskX(n, 0));
            var y = Search(0, border, (n) => AskY(0, n));
            Console.WriteLine($"A {x} {y}");
        }

        static int Search(int left, int right, Func<int, bool> compare)
        {
            while (right > left)
            {
                compare(right); // Якорь для следующего вопроса. 
                var mid = (right + left) / 2;
                if (compare(mid))
                    right = (mid + right) / 2;
                else
                    left = (mid + right + 1) / 2;
            }

            return left;
        }

        static bool Ask(int x, int y)
        {
            Console.WriteLine($"{x} {y}");
            Console.Out.Flush();
            var data = Console.ReadLine();
            if (data != "1" && data != "0")
                Environment.Exit(0);
            return data == "1";
        }

        static int lastX = int.MinValue+2;
        static bool AskX(int x, int y)
        {
            const int test = 0;
            var res = Math.Abs(x - test) < Math.Abs(lastX - test);
            lastX = x;
            return res;
        }
        static int lastY = int.MinValue+2;
        static bool AskY(int x, int y)
        {
            const int test = 34563456;
            var res = Math.Abs(y - test) < Math.Abs(lastY - test);
            lastY = y;
            return res;
        }
    }
}
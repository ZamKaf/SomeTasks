using System;
using System.Linq;

namespace YandexContest.Algorithms2.DivA1
{
    public class CTicTacToe : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var desk = reader.ReadInt32Array().Concat(reader.ReadInt32Array()).Concat(reader.ReadInt32Array())
                .ToArray();
            var xCount = 0;
            var oCount = 0;
            foreach (var i in desk)
            {
                if (1 == i)
                    xCount++;
                else if (2 == i)
                    oCount++;
            }

            if (xCount < oCount || xCount > oCount + 1)
            {
                Console.WriteLine("NO");
                return;
            }

            var winLineXCount = 0;
            var winLineOCount = 0;
            for (var i = 0; i < 9; i+=3)
            {
                var res = CheckWinLine(desk[i], desk[i + 1], desk[i + 2]);
                if (1 == res)
                    winLineXCount++;
                else if (2 == res)
                    winLineOCount++;
            }

            for (var i = 0; i < 3; i++)
            {
                var res = CheckWinLine(desk[i], desk[i + 3], desk[i + 6]); 
                if (1 == res)
                    winLineXCount++;
                else if (2 == res)
                    winLineOCount++;
            }

            var res1 = CheckWinLine(desk[0], desk[4], desk[8]);
            if (1 == res1)
                winLineXCount++;
            else if (2 == res1)
                winLineOCount++;

            res1 = CheckWinLine(desk[2], desk[4], desk[6]);
            if (1 == res1)
                winLineXCount++;
            else if (2 == res1)
                winLineOCount++;

            if (winLineXCount > 0 && xCount == oCount)
            {
                Console.WriteLine("NO");
                return;
            }
            
            if (winLineOCount > 0 && xCount > oCount)
            {
                Console.WriteLine("NO");
                return;
            }

            if (winLineXCount == 2)
            {
                if (xCount == 5)
                {
                    Console.WriteLine("YES");
                    return;
                }
            }
            
            Console.WriteLine($"{(winLineXCount + winLineOCount > 1 ? "NO" : "YES")}");
        }

        static int CheckWinLine(int e1, int e2, int e3)
        {
            if (0 == e1)
                return 0;
            if (!(e1 == e2 && e2 == e3 && e1 == e3))
                return 0;
            return e1 == 1 ? 1 : 2;
        }
    }
}
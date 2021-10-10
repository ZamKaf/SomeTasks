using System;
using System.Linq;

namespace YandexContest.Algorithms2.DivB.DivB1
{
    public class EPointTriangle:IRunnable
    {
        public void Run()
        {
            var d = int.Parse(Console.ReadLine());
            var coordinates = Console.ReadLine().Split(' ').Select(i => int.Parse(i)).ToArray();
            var x = coordinates[0];
            var y = coordinates[1];
            if (x == 0 && y == 0)
            {
                Console.WriteLine(0);
                return;   
            }
            if (x <= 0 && y <= 0)
            {
                Console.WriteLine(1);
                return;
            }

            if (y < 0)
            {
                Console.WriteLine(2 * x <= d ? 1 : 2);
                return;
            }
            
            if (x < 0)
            {
                Console.WriteLine(2 * y <= d ? 1 : 3);
                return;
            }

            if (0 == y)
            {
                Console.WriteLine(x <= d ? 0 : 2);
                return;
            }
            
            if (0 == x)
            {
                Console.WriteLine(y <= d ? 0 : 3);
                return;
            }

            if (x + y <= d)
            {
                Console.WriteLine(0);
                return;
            }
            Console.WriteLine( x >= y ?  2 : 3);
        }
    }
}
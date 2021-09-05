using System;
using System.Linq;

namespace YandexContest.Algorithms2.DivB
{
    public class DSchool : IRunnable
    {
        public void Run()
        {
            var count = long.Parse(Console.ReadLine());
            var houses = Console.ReadLine().Split(' ').Select(i => long.Parse(i)).ToArray();
            Console.WriteLine(houses[count / 2]);
        }
    }
}
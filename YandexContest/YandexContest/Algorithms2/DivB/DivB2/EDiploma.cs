using System;
using System.Linq;

namespace YandexContest.Algorithms2.DivB.DivB2
{
    public class EDiploma :IRunnable
    {
        public void Run()
        {
            var count = int.Parse(Console.ReadLine());
            var diplomas = Console.ReadLine().Trim(' ').Split(' ').Where(s => s != "")
                .Select(i => int.Parse(i)).ToArray();
            Console.WriteLine(diplomas.Sum() - diplomas.Max());
        }
    }
}
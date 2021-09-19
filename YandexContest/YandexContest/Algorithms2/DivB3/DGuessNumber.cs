using System;
using System.Collections.Generic;
using System.Linq;

namespace YandexContest.Algorithms2.DivB3
{
    public class DGuessNumber :IRunnable
    {
        public void Run()
        {
            var max = int.Parse(Console.ReadLine());
            var str = "";
            var result = new SortedSet<int>(Enumerable.Range(1, max)); 
            while ((str = Console.ReadLine()) != "HELP")
            {
                var numbers = str.Trim(' ').Split(' ').Where(s => s != "")
                    .Select(i => int.Parse(i));
                var answer = Console.ReadLine() == "YES";
                if (answer)
                    result.IntersectWith(numbers);
                else
                    result.ExceptWith(numbers);
            }
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
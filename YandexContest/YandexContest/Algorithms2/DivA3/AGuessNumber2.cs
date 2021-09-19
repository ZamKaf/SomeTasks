using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace YandexContest.Algorithms2.DivA3
{
    public class AGuessNumber2 :IRunnable
    {
        public void Run()
        {
            const string helpAnswer = "HELP";
            const string yesAnswer = "YES";
            const string noAnswer = "NO";

            var max = int.Parse(Console.ReadLine());
            var str = "";
            var result = new HashSet<int>(Enumerable.Range(1, max));
            var answers = new List<string>();
            while ((str = Console.ReadLine()) != helpAnswer)
            {
                var numbers = str.Trim(' ').Split(' ').Where(s => s != "")
                    .Select(i => int.Parse(i));
                var tmpSet = new HashSet<int>(numbers);
                tmpSet.IntersectWith(result);
                var totalCount = result.Count;
                var intersectCount = tmpSet.Count;
                var exceptCount = totalCount - intersectCount;
                if (intersectCount > exceptCount)
                {
                    answers.Add(yesAnswer);
                    result = tmpSet;
                }
                else
                {
                    answers.Add(noAnswer);
                    result.ExceptWith(tmpSet);
                }
            }
            Console.WriteLine(string.Join("\n", answers));
            Console.WriteLine(string.Join(" ", result));
        }
    }
}
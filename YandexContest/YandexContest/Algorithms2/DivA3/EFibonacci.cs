using System;
using System.Collections.Generic;
using System.Linq;

namespace YandexContest.Algorithms2.DivA3
{
    public class EFibonacci : IRunnable
    {
        public void Run()
        {
            const int fibNumsCount = 40000;
            const string yes = "Yes";
            const string no = "No";
            
            var reader = new NumbersReader();
            var count = reader.ReadInt32();

            var baseP = (long)Math.Pow(10, 9);
            var modules = new[] { baseP + 7, baseP + 9, baseP + 13 };
            var modulesCount = modules.Length;
            var remainders = new HashSet<long>[]
            {
                new HashSet<long>(), new HashSet<long>(), new HashSet<long>()
            };
            
            for (var i = 0; i < modulesCount; i++)
            {
                long f1 = 1;
                long f2 = 1;
                for (var j = 0; j < fibNumsCount; j++)
                {
                    remainders[i].Add(f2);
                    var tmp = f2;
                    f2 = (f2 + f1) % modules[i];
                    f1 = tmp;
                }
            }

            var answers = new List<string>();
            for (var i = 0; i < count; i++)
            {
                var number = Console.ReadLine();
                var results = new long[modulesCount];

                for (var j = 0; j < modulesCount; j++)
                {
                    results[j] = number.Aggregate((long)0, (res, c) => (res * 10 + long.Parse($"{c}")) % modules[j]);
                }

                var answer = results.Select((result, index) => new { result, index })
                    .All(resContainer => remainders[resContainer.index].Contains(resContainer.result))
                    ? yes
                    : no;
                answers.Add(answer);
            }

            Console.WriteLine(string.Join("\n", answers));
        }
    }
}
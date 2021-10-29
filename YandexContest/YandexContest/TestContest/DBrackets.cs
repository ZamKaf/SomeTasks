using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YandexContest.TestContest
{
    public class DBrackets : IRunnable
    {
        
        const char op = '(';
        const char cl = ')';

        List<string> list = new List<string>();
        public void Run()
        {
            var count = int.Parse(Console.ReadLine());
            //Check();
            InternalRun(count);
        }

        void Check()
        {
            var nums = Enumerable.Range(0, 12);
            foreach (var num in nums)
            {
                list = new List<string>();
                InternalRun(num);
                var list1 = new List<string>(list);
                list1.Sort();
                var same = true;
                for (var i = 0; i < list.Count; i++)
                {
                    if (list[i] != list1[i])
                        same = false;
                }
                Console.WriteLine($"order {num} {same}");
                Console.WriteLine($"count {num} {list1.Count} (need {BracketsCount(num)})");
            }
        }

        int BracketsCount(int n)
        {
            if (n == 0)
                return 1;
            var sum = 0;
            for (var i = 0; i < n; i++)
            {
                sum += BracketsCount(i) * BracketsCount(n - 1 - i);
            }

            return sum;
        }

        void Handle(string str = "")
        {
            //list.Add(str);
            Console.WriteLine(str);
        }
        
        void InternalRun(int count)
        {
            if (0 == count)
            {
                Handle();
                return;
            }
            var s1 = string.Concat(Enumerable.Repeat(op, count).Concat(Enumerable.Repeat(cl, count)));
            Handle(s1);
            for (var i = 1; i < count; i++)
            {
                var pr = new string(Enumerable.Repeat(op, count - i).ToArray());
                pr += cl;
                PrintSuffix(pr, i, count + i - 1);
            }
        }
        
        void PrintSuffix(string prefix, int countO, int countTotal)
        {
            
            Handle($"{prefix}{new string(Enumerable.Repeat(op, countO).ToArray())}" +
                              $"{new string(Enumerable.Repeat(cl, countTotal - countO).ToArray())}");
            if (countO == 1)
            {
                for (var i = 1; i < countTotal - 1; i++)
                {
                    var sb = new StringBuilder();
                    sb.Append(prefix);
                    for (var j = 0; j < i; j++)
                    {
                        sb.Append(cl);
                    }
                    sb.Append(op);
                    
                    for (var j = i + 1; j < countTotal; j++)
                    {
                        sb.Append(cl);
                    }
                    Handle(sb.ToString());
                }
            }
            else
            {
                for (var i = 1; i < Math.Min(countO + 1, countTotal - countO); i++)
                {
                    var pr = prefix + new string(Enumerable.Repeat(op, countO - i).ToArray()) + cl;
                    PrintSuffix(pr, i, countTotal - countO + i - 1);
                }
            }
        }
    }
}
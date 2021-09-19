using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace YandexContest.Algorithms2.DivA4
{
    public class ENames :IRunnable
    {
        
        const int CharsCount = 26;
        public void Run()
        {
            var dad = Console.ReadLine();
            var mom = Console.ReadLine();
            var dadLetters = GetCharsCount(dad);
            var mamLetters = GetCharsCount(mom);
            var sb = new StringBuilder();
            var dadPosition = 0;
            var momPosition = 0;
            for (var i = CharsCount - 1; i >= 0; i--)
            {
                var dadList = mamLetters[i];
                var momList = dadLetters[i];
                dadList.RemoveAll(n => n < dadPosition);
                momList.RemoveAll(n => n < momPosition);
                var count = Math.Min(momList.Count, dadList.Count);
                sb.Append(Enumerable.Repeat(Char(i), count).ToArray());
                if (count > 0)
                {
                    dadPosition = dadList[count - 1];
                    momPosition = momList[count - 1];
                }
            }
            Console.WriteLine(sb.ToString());
        }

        List<int>[] GetCharsCount(string str)
        {
            var mas = Enumerable.Repeat(1, CharsCount).Select(_ => new List<int>()).ToArray();
            for (var i = 0; i < str.Length; i++)
            {
                var index = Index(str[i]);
                mas[index].Add(i);
            }

            return mas;
        }

        protected virtual char Char(int index)
        {
            return Convert.ToChar(index + Convert.ToInt32('a'));
        }
        
        protected virtual int Index(char c)
        {
            return Convert.ToInt32(c) - Convert.ToInt32('a');
        }  
    }
}
using System;
using System.Linq;
using System.Text;

namespace YandexContest.Algorithms2.DivA4
{
    public class DNumbers :IRunnable
    {
        const int CharsCount = 10;
        public void Run()
        {
            var sashaDigits = GetCharsCount(Console.ReadLine());
            var katyaDigits = GetCharsCount(Console.ReadLine());
            var sb = new StringBuilder();
            for (var i = CharsCount - 1; i >= 0; i--)
            {
                var count = Math.Min(sashaDigits[i], katyaDigits[i]);
                if (i == 0 &&
                    sb.Length == 0)
                {
                    sb.Clear();
                    if (count > 0)
                        sb.Append('0');
                    break;
                }
                sb.Append(Enumerable.Repeat(Char(i), count).ToArray());
            }

            var res = sb.ToString();
            Console.WriteLine($"{(res == "" ? "-1" : res)}");
        }

        int[] GetCharsCount(string str)
        {
            var chars = new int[CharsCount];
            foreach (var letter in str)
            {
                chars[Index(letter)]++;
            }

            return chars;
        }

        protected virtual char Char(int index)
        {
            return Convert.ToChar(index + Convert.ToInt32('0'));
        }
        
        protected virtual int Index(char c)
        {
            return Convert.ToInt32(c) - Convert.ToInt32('0');
        }
    }
}
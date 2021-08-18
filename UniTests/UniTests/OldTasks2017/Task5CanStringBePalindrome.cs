using System;
using System.Collections.Generic;
using System.Linq;

namespace UniTests.OldTasks2017
{
    public class Task5CanStringBePalindrome : ITest
    {
        public bool CheckStringPalindrome(string str)
        {
            var dict = new Dictionary<char, int>(str.Length);
            foreach (var symbol in str)
            {
                if (!dict.ContainsKey(symbol))
                    dict[symbol] = 1;
                else
                    dict[symbol]++;
            }

            var oddCunt = 0;
            var isStrEven = str.Length % 2 == 0;
            foreach (var value in dict.Values.Where(value => value % 2 != 0))
            {
                oddCunt++;
                switch (oddCunt)
                {
                    case 1 when isStrEven:
                    case > 1:
                        return false;
                }
            }

            return true;
        }
        
        public void Run()
        {
            var str = "asdffdsa";
            Console.WriteLine($"String {str} can {(CheckStringPalindrome(str) ? "" : "NOT ")}be palindrome");
        }
    }
}
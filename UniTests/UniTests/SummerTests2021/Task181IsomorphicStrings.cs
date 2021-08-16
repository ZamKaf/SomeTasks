using System;
using System.Collections.Generic;

namespace UniTests.SummerTests2021
{
    public class Task181IsomorphicStrings :ITest
    {
        public bool IsIsomorphicStrings(string s, string t)
        {
            var len = s.Length;
            if (len != t.Length)
                return false;
            
            var dict1 = new Dictionary<char, int>(len);
            var counter1 = 0;
            var dict2 = new Dictionary<char, int>(len);
            var counter2 = 0;
            for (var i = 0; i < len; i++)
            {
                var char1 = s[i];
                if (!dict1.ContainsKey(char1))
                    dict1[char1] = ++counter1;

                var char2 = t[i];
                if (!dict2.ContainsKey(char2))
                    dict2[char2] = ++counter2;
                
                if (dict1[char1] != dict2[char2])
                    return false;
            }
            
            return true;
        }
        
        public void Run()
        {
            var testString1 = "addbettsett";
            var testString2 = "daabepplepp";
            Console.WriteLine($"strings '{testString1}' and '{testString2}' are {(IsIsomorphicStrings(testString1, testString2) ? "" : "NOT ")}isomorphic!");
        }
    }
}
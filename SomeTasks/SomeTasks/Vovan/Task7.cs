using System;
using System.Text;

namespace SomeTasks.Vovan
{
    /// <summary>
    /// буквы и знаки вопроса, поменять знаки вопроса чтобы ее было рядом одинаковых букв
    /// </summary>
    class Task7 : IRunnable
    {
        public void Run()
        {
            var testStr1 = "asdf?few";
            var testStr2 = "?few";
            var testStr3 = "asdf?";
            var testStr4 = "?";
            var testStr5 = "sadf";
            var testStr6 = "aaaaaa";
            var testStr7 = "?aaab?ababa?bab?ab";
            Console.WriteLine(RemoveQuestions(testStr4));
        }

        string RemoveQuestions(string str)
        {
            const char changedChar = '?';
            if (string.IsNullOrEmpty(str))
                return str;
            if (str.Length == 1)
                return str != "?" ? str : "a";
			
            var sb = new StringBuilder();
            sb.Append(GetChar('#', str[1]));
            for (var i = 1; i < str.Length - 1; i++)
            {
                if (str[i] == changedChar)
                    sb.Append(GetChar(str[i-1], str[i+1]));
                else
                    sb.Append(str[i]);
            }
            if (str[^1] == changedChar)
                sb.Append(GetChar('#', str[^2]));
            else
                sb.Append(str[^1]);
            return sb.ToString();
        }

        char GetChar(char left, char right)
        {
            var letters = new[] { 'a', 'b', 'c' };
            foreach (var c in letters)
            {
                if (c != left && c != right)
                    return c;
            }

            return 'c';
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace UniTests.OldTasks2017
{
    class Task7SortWords : ITask
    {
        public List<string> SortWords(string phrase)
        {
            var words = phrase.Split(' ');
            return words.OrderByDescending(w => w.Length).ToList();
        }
        public void Run()
        {
            var phrase = "test phrase number one";
            Console.WriteLine($"for phrase '{phrase}' is [{string.Join(", ", SortWords(phrase))}]");
        }
    }
}
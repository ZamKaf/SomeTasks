using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace YandexContest.Algorithms2.DivB4
{
    public class CFrequency :IRunnable
    {
        public void Run()
        {
            const string inFileName = "input.txt";
            var dict = new Dictionary<string, long>();
            foreach (var line in File.ReadLines(inFileName))
            {
                foreach (var word in line.Split(' '))
                {
                    if (dict.ContainsKey(word))
                        dict[word]++;
                    else
                        dict[word] = 1;
                }
            }

            var list = new List<WordFrequency>(dict.Select(p => 
                new WordFrequency
                {
                    Word = p.Key, Frequency = p.Value 
                    
                }));
            list.Sort((frequency, wordFrequency) =>
            {
                if (frequency.Frequency > wordFrequency.Frequency)
                    return -1;
                if (frequency.Frequency < wordFrequency.Frequency)
                    return 1;
                return string.Compare(frequency.Word, wordFrequency.Word, StringComparison.Ordinal);
            });
            Console.WriteLine(string.Join("\n", list.Select(w => w.Word)));
        }
    } 

    public class WordFrequency
    {
        public string Word { get; set; }
        public long Frequency { get; set; }
    }
}
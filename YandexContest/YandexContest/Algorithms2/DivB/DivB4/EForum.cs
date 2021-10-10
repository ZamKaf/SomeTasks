using System;
using System.Collections.Generic;

namespace YandexContest.Algorithms2.DivB.DivB4
{
    public class EForum : IRunnable 
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var count = reader.ReadInt32();
            var themeNames = new Dictionary<int, string>();
            var themeCounts = new Dictionary<int, int>();
            
            var messages = new int[count+1];
            for (var i = 1; i <= count; i++)
            {
                var num = reader.ReadInt32();
                if (0 == num)
                {
                    var themeName = Console.ReadLine();
                    themeNames.Add(i, themeName);
                    themeCounts.Add(i, 1); 
                    messages[i] = i;
                }
                else
                {
                    var themeNumber = messages[num];
                    themeCounts[themeNumber]++;
                    messages[i] = themeNumber;
                }
                Console.ReadLine();
            }

            var maxCount = 0;
            var maxThemeNumber = 0;
            foreach (var (key, value) in themeCounts)
            {
                if (value > maxCount)
                {
                    maxCount = value;
                    maxThemeNumber = key;
                }
            }
            Console.WriteLine(themeNames[maxThemeNumber]);
        }
    }
}
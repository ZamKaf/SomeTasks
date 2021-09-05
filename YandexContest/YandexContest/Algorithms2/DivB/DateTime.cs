using System;
using System.Linq;

namespace YandexContest.Algorithms2.DivB
{
    public class DateTimeCheck : IRunnable
    {
        public void Run()
        {
            var nums = Console.ReadLine().Split(' ').Select(s => int.Parse(s)).ToArray();
            var days = nums[0];
            var months = nums[1];
            var years = nums[2];
            var dateTime = new DateTime();
            if (days == months)
                Console.WriteLine(1);
            else if (!DateTime.TryParse($"{days}.{months}.{years}", out dateTime)) 
                Console.WriteLine(1);
            else if (!DateTime.TryParse($"{months}.{days}.{years}", out dateTime)) 
                Console.WriteLine(1);
            else
                Console.WriteLine(0);
        }
    }
}
using System;
using System.Linq;

namespace YandexContest.Algorithms2.DivB2
{
    public class DBench : IRunnable
    {
        public void Run()
        {
            var numbers = Console.ReadLine().Trim(' ').Split(' ').Where(s => s != "")
                .Select(i => int.Parse(i)).ToArray();
            var benchLen = numbers[0];
            var blocksCount = numbers[1];
            var blocks = Console.ReadLine().Trim(' ').Split(' ').Where(s => s != "")
                .Select(i => int.Parse(i.Trim(' ', '\t'))).ToArray();
            var hasMiddle = benchLen % 2 == 1;  
            var mid = benchLen / 2;
            for (var i = 0; i < blocksCount; i++)
            {
                var block = blocks[i];
                if (hasMiddle && block == mid)
                {
                    Console.WriteLine(block);
                    return;
                }

                if (block >= mid)
                {
                    Console.WriteLine($"{blocks[i-1]} {blocks[i]}");
                    return;
                }
            }
        }
    }
}
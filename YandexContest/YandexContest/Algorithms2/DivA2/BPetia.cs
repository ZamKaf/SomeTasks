using System;

namespace YandexContest.Algorithms2.DivA2
{
    public class BPetia : IRunnable
    {
        public void Run()
        {
            var xWord = Console.ReadLine();
            var zWord = Console.ReadLine();
            var xLen = xWord.Length;
            var zLen = zWord.Length;
            var minLen = Math.Min(xLen, zLen);
            for (var i = minLen; i > 0; i--)
            {
                if (zWord.StartsWith(xWord.Substring((xLen - i))))
                {
                    zWord = zWord.Substring(i);
                    while (zWord.StartsWith(xWord))
                    {
                        zWord = zWord.Substring(xLen);
                    }
                    break;
                }
            }
            Console.WriteLine(zWord);
        }
    }
}
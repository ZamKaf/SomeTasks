using System;
using System.Xml.Schema;

namespace YandexContest.Algorithms2.DivA.DivA5
{
    public class CFullerenes : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var count = reader.ReadInt32();
            var tubes = reader.ReadInt64Array();
            if (count < 3)
            {
                Console.WriteLine(0);
                return;
            }
            var partiesCount = 0;
            var leftPointer = 0;
            var midPointer = 1;
            var rightPointer = 2;
            while (leftPointer < count-2 && midPointer < count -1 && rightPointer < count)
            {
                var a = tubes[leftPointer];
                var b = tubes[midPointer];
                var c = tubes[rightPointer];
                if (c >= a + b)
                {
                    if (midPointer < rightPointer - 1)
                    {
                        midPointer++;
                        rightPointer = Math.Max(midPointer + 1, rightPointer);
                    }
                    else
                    {
                        leftPointer++;
                        midPointer = Math.Max(leftPointer+1, midPointer);
                        rightPointer = Math.Max(midPointer + 1, rightPointer);
                    }
                    continue;
                }
            }
        }

    }
}
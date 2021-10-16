using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic;

namespace YandexContest.Algorithms2.DivA.DivA5
{
    public class AStyle : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var capsCount = reader.ReadInt32();
            var caps = reader.ReadInt32Array().ToList();
            var tShirtsCount = reader.ReadInt32();
            var tShirts = reader.ReadInt32Array().ToList();
            var pantsCount = reader.ReadInt32();
            var pants = reader.ReadInt32Array().ToList();
            var bootsCount = reader.ReadInt32();
            var boots = reader.ReadInt32Array().ToList();
            caps.Sort();
            tShirts.Sort();
            pants.Sort();
            boots.Sort();
            var clothes = new List<List<int>> { caps, tShirts, pants, boots };
            var result = new List<int> { 0, 0, 0, int.MaxValue };
            var indexes = new[] { 0, 0, 0, 0 };
            var lens = new[] { capsCount, tShirtsCount, pantsCount, bootsCount };
            var finishedLists = lens.Select((value, index) => value == 1 ? index : -1).Where(i => i != -1).ToList();
            while (true)
            {
                if (Delta(clothes, indexes) < Delta(result))
                {
                    for (var i = 0; i < 4; i++)
                        result[i] = clothes[i][indexes[i]];
                }

                var minIndex = MinIndexToMove(clothes, indexes, finishedLists);

                indexes[minIndex]++;
                if (indexes[minIndex] == lens[minIndex] - 1)
                {
                    finishedLists.Add(minIndex);
                    if (finishedLists.Count == 4)
                        break;
                }
            }
            Console.WriteLine(string.Join(" ", result));
        }

        static int Delta(IReadOnlyList<int> values)
        {
            var minValue = int.MaxValue;
            var maxValue = -1;
            for (var i = 0; i < 4; i++)
            {
                var value = values[i];
                if (value < minValue)
                    minValue = value;
                if (value > maxValue)
                    maxValue = value;
            }

            return maxValue - minValue;
        }

        static int Delta(List<List<int>> clothes, int[] indexes)
        {
            var minValue = int.MaxValue;
            var maxValue = -1;
            for (var i = 0; i < 4; i++)
            {
                var value = clothes[i][indexes[i]];
                if (value < minValue)
                    minValue = value;
                if (value > maxValue)
                    maxValue = value;
            }

            return maxValue - minValue;
        }

        static int MinIndexToMove(List<List<int>> clothes, int[] indexes, List<int> finishedLists)
        {
            var minValue = int.MaxValue;
            var minIndex = -1;

            for (var i = 0; i < 4; i++)
            {
                if (finishedLists.Contains(i))
                    continue;

                var value = clothes[i][indexes[i]];
                if (value < minValue)
                {
                    minValue = value;
                    minIndex = i;
                }
            }

            return minIndex;
        }
    }
}
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace YandexContest.Algorithms2.DivA.DivA5
{
    public class BCandies : IRunnable
    {
        public void Run()
        {
            //var sw = Stopwatch.StartNew();
            const string file = "input.txt";

            //const string file = "019(1)";
            var data = File.ReadLines(file);
            var readFirst = true;
            var pairsCount = 0;
            var candies = new List<Pair>();
            foreach (var line in data)
            {
                if (readFirst)
                {
                    pairsCount = int.Parse(line);
                    readFirst = false;
                    continue;
                }

                var nums = line.Split(' ').Select(long.Parse).ToList();
                candies.Add(new Pair { Count = nums[1], Value = nums[0] });
            }
/*
            
            var reader = new NumbersReader();
            var pairsCount = reader.ReadInt32();
            var candies = new List<Pair>();
            for (var i = 0; i < pairsCount; i++)
            {
                var nums = reader.ReadInt64Array();
                candies.Add(new Pair{Count = nums[1], Value = nums[0] });
                //candies.AddRange(Enumerable.Repeat(nums[0], (int)nums[1]));
            }
*/
            //Console.WriteLine(string.Join(" ", candies));

            var leftPointer = 0;
            var rightPointer = candies.Count - 1;

            var leftData = candies[leftPointer].Value;
            var secondLeftData = candies[leftPointer].Value;
            if (candies[leftPointer].Count == 1)
                secondLeftData = candies[leftPointer + 1].Value;

            var rightData = candies[rightPointer].Value;
            var secondRightData = candies[rightPointer].Value;
            if (candies[rightPointer].Count == 1)
                secondRightData = candies[rightPointer - 1].Value;

            
            
            var lastMove = LastMove.Both;
            while (true) //(rightPointer - leftPointer > 2)
            {
                var leftDataCurrent = leftData;
                var rightDataCurrent = rightData;

                if (leftDataCurrent < rightDataCurrent)
                {
                    leftData += secondLeftData;
                    var leftPointed = candies[leftPointer];
                    if (leftPointed.Count > 2)
                    {
                        secondLeftData = leftPointed.Value;
                        leftPointed.Count--;
                    }
                    else if (leftPointed.Count == 2)
                    {
                        secondLeftData = candies[leftPointer + 1].Value;
                        leftPointed.Count--;
                    }
                    else
                    {
                        leftPointer++;
                        secondLeftData = candies[leftPointer].Count > 1
                            ? candies[leftPointer].Value
                            : candies[leftPointer + 1].Value;
                    }
                    //candies[leftPointer] += left;

                    rightData -= leftDataCurrent;
                    secondRightData += leftDataCurrent;
                    //candies[rightPointer] -= left;
                    //candies[rightPointer - 1] += left;
                    lastMove = LastMove.Left;
                }
                else if (leftDataCurrent > rightDataCurrent)
                {
                    rightData += secondRightData;
                    var rightPointed = candies[rightPointer];
                    if (rightPointed.Count > 2)
                    {
                        secondRightData = rightPointed.Value;
                        rightPointed.Count--;
                    }
                    else if (rightPointed.Count == 2)
                    {
                        secondRightData = candies[rightPointer - 1].Value;
                        rightPointed.Count--;
                    }
                    else
                    {
                        rightPointer--;
                        secondRightData = candies[rightPointer].Count > 1
                            ? candies[rightPointer].Value
                            : candies[rightPointer - 1].Value;
                    }
                    //candies[leftPointer] += left;

                    leftData -= rightDataCurrent;
                    secondLeftData += rightDataCurrent;
                    //candies[rightPointer] -= left;
                    //candies[rightPointer - 1] += left;
                    lastMove = LastMove.Right;
                }
                else
                {
                    leftData += secondLeftData;
                    var leftPointed = candies[leftPointer];
                    if (leftPointed.Count > 2)
                    {
                        secondLeftData = leftPointed.Value;
                        leftPointed.Count--;
                    }
                    else if (leftPointed.Count == 2)
                    {
                        secondLeftData = candies[leftPointer + 1].Value;
                        leftPointed.Count--;
                    }
                    else
                    {
                        leftPointer++;
                        secondLeftData = candies[leftPointer].Count > 1
                            ? candies[leftPointer].Value
                            : candies[leftPointer + 1].Value;
                    }

                    rightData += secondRightData;
                    var rightPointed = candies[rightPointer];
                    if (rightPointed.Count > 2)
                    {
                        secondRightData = rightPointed.Value;
                        rightPointed.Count--;
                    }
                    else if (rightPointed.Count == 2)
                    {
                        secondRightData = candies[rightPointer - 1].Value;
                        rightPointed.Count--;
                    }
                    else
                    {
                        rightPointer--;
                        secondRightData = candies[rightPointer].Count > 1
                            ? candies[rightPointer].Value
                            : candies[rightPointer - 1].Value;
                    }

                    lastMove = LastMove.Both;
                }

                if (rightPointer - leftPointer == 0)
                {
                    if (candies[leftPointer].Count <= 3)
                        break;
                }

                if (rightPointer - leftPointer == 1)
                {
                    if (candies[rightPointer].Count + candies[leftPointer].Count <= 3)
                        break;
                }

                if (rightPointer - leftPointer == 2)
                {
                    if (candies[rightPointer].Count + candies[leftPointer].Count +
                        candies[(leftPointer + rightPointer) / 2].Count <= 3)
                        break;
                }
            }

            if (rightPointer - leftPointer == 1 &&
                candies[rightPointer].Count + candies[leftPointer].Count == 2)
            {
                Console.WriteLine(2);
                //Console.WriteLine($"{candies[leftPointer]} {candies[rightPointer]}");
                Console.WriteLine($"{leftData} {rightData}");
                return;
            }

            var leftLast = leftData;
            var rightLast = rightData;

            long mid = 0;
            switch (lastMove)
            {
                case LastMove.Left:
                    mid = secondRightData;
                    break;
                case LastMove.Right:
                    mid = secondLeftData;
                    break;
                case LastMove.Both:
                    if (rightPointer - leftPointer == 0)
                    {
                        mid = candies[leftPointer].Value;
                    }
                    else if (rightPointer - leftPointer == 1)
                    {
                        var leftPointedLast = candies[leftPointer];
                        var rightPointedLast = candies[rightPointer];
                        mid = leftPointedLast.Count > rightPointedLast.Count
                            ? leftPointedLast.Value
                            : rightPointedLast.Value;
                    }
                    else
                    {
                        mid = candies[(rightPointer + leftPointer) / 2].Value;
                    }
                    break;
            }

            if (leftLast < rightLast)
            {
                rightData -= leftLast;
                mid += 2 * leftLast;
                Console.WriteLine(2);
                Console.WriteLine($"{mid} {rightData}");
            }
            else if (leftLast > rightLast)
            {
                leftData -= rightLast;
                mid += 2 * rightLast;
                Console.WriteLine(2);
                Console.WriteLine($"{leftData} {mid}");
            }
            else
            {
                mid += 2 * leftLast;
                Console.WriteLine(1);
                Console.WriteLine(mid);
            }

            return;
        }
    }

    enum LastMove
    {
        Left,
        Right,
        Both,
    }

    class Pair
    {
        public long Count { get; set; }
        public long Value { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;

namespace YandexContest.Algorithms2.DivA.DivA3
{
    class DLot : IRunnable
    {
        public void Run()
        {
            const int infValue = 200;
            const int maxValue = 100;
            var reader = new NumbersReader();
            var totalCount = reader.ReadInt32();
            var currentTotalScores = reader.ReadInt32Array();
            var currentValues = reader.ReadInt32Array();
            var counts = new Dictionary<int, int>();
            foreach (var currentValue in currentValues)
            {
                if (!counts.ContainsKey(currentValue))
                    counts[currentValue] = 1;
                else
                    counts[currentValue]++;
            }

            var minWin = infValue;
            var minIndex = -1;
            var maxTotalScore = 0;
            for (var i = 0; i < totalCount - 1; i++)
            {
                var currentValue = currentValues[i];
                if (currentValue < minWin &&
                    counts[currentValue] == 1)
                {
                    minWin = currentValue;
                    minIndex = i;
                }

                if (maxTotalScore < currentTotalScores[i] - currentTotalScores[totalCount - 1])
                    maxTotalScore = currentTotalScores[i] - currentTotalScores[totalCount - 1];
            }

            if (minIndex == -1)
            {
                minWin = maxValue + 2;
            }

            var winValues = new HashSet<int>(Enumerable.Range(1, minWin - 1)
                .Where(i => !counts.ContainsKey(i)));

            var maxLosersCount = 0;
            var result = 1;
            for (var i = 1; i < maxValue + 2; i++)
            {
                var playerScore = currentTotalScores[totalCount-1];
                var minWinCurrent = infValue;
                var minIndexCurrent = -1;
                if (winValues.Contains(i))
                {
                    playerScore += i;
                }
                else
                {
                    if (i > minWin ||
                        !counts.ContainsKey(i) ||
                        counts[i] > 1)
                    {
                        minIndexCurrent = minIndex;
                        minWinCurrent = minWin;
                    }
                    else
                    {
                        counts[i] = counts.ContainsKey(i) ? counts[i] + 1 : 1;
                        for (var k = 0; k < totalCount - 1; k++)
                        {
                            var currentValue = currentValues[k];
                            if (currentValue < minWinCurrent &&
                                counts[currentValue] == 1)
                            {
                                minWinCurrent = currentValue;
                                minIndexCurrent = k;
                            }
                        }
                    
                        counts[i]--;
                    }
                }

                var countLosers = 0;
                for (var j = 0; j < totalCount - 1; j++)
                {
                    var currentPlayerScore = currentTotalScores[j];
                    if (j == minIndexCurrent)
                    {
                        currentPlayerScore += minWinCurrent;
                    }
                    if (currentPlayerScore < playerScore)
                        countLosers++;
                }

                if (countLosers > maxLosersCount)
                {
                    maxLosersCount = countLosers;
                    result = i;
                }
            }
            Console.WriteLine(result);
        }
    }
}
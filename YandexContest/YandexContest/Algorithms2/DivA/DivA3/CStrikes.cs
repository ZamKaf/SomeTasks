using System;

namespace YandexContest.Algorithms2.DivA.DivA3
{
    public class CStrikes : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var nums = reader.ReadInt32Array();
            var daysCount = nums[0];
            var partiesCount = nums[1];
            var parties = new int[partiesCount][];
            var currentPartyStrike = new int[partiesCount];
            for (var i = 0; i < partiesCount; i++)
            {
                parties[i] = reader.ReadInt32Array();
                currentPartyStrike[i] = parties[i][0];
            }

            var strikesCount = 0;
            for (var day = 1; day <= daysCount; day++)
            {
                var strike = false;
                for (var j = 0; j < partiesCount; j++)
                {
                    if (currentPartyStrike[j] != day) 
                        continue;
                    currentPartyStrike[j] += parties[j][1];
                    strike = true;
                }

                var d = day % 7;
                if (d % 7 == 0 || d % 7 == 6)
                {
                    strike = false;
                }

                if (strike)
                    strikesCount++;
            }
            Console.WriteLine(strikesCount);
        }
    }
}
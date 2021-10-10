using System;
using System.Collections.Generic;
using System.Linq;

namespace YandexContest.Algorithms2.DivB.DivB2
{
    public class HouseDistance
    {
        public int CurrentDistance { get; set; }
        public int Position { get; set; }
    }
    public class BHousesShops:IRunnable
    {
        public void Run()
        {
            const int housesCount = 10;
            var buildings = Console.ReadLine().Trim(' ').Split(' ').Select(i => int.Parse(i.Trim(' ', '\t'))).ToArray();
            var lastShopPosition = -1;
            var maxDistance = -1;

            var tmpDistances = new List<HouseDistance>();
            for (var i = 0; i < housesCount; i++)
            {
                var currentElem = buildings[i];
                switch (currentElem)
                {
                    case 0:
                        continue;
                    case 2:
                    {
                        foreach (var houseDistance in tmpDistances)
                        {
                            var realDistance = Math.Min(houseDistance.CurrentDistance, i - houseDistance.Position);
                            if (realDistance > maxDistance) maxDistance = realDistance;
                        }

                        tmpDistances.Clear();
                        lastShopPosition = i;
                        break;
                    }
                    case 1:
                    {
                        if (lastShopPosition != -1)
                        {
                            var currentDistance = i - lastShopPosition;
                            if (maxDistance < currentDistance)
                                tmpDistances.Add(new HouseDistance { Position = i, CurrentDistance = currentDistance });
                        }
                        else
                        {
                            tmpDistances.Add(new HouseDistance { Position = i, CurrentDistance = int.MaxValue });
                        }

                        break;
                    }
                }
            }

            foreach (var houseDistance in tmpDistances)
            {
                if (houseDistance.CurrentDistance > maxDistance) 
                    maxDistance = houseDistance.CurrentDistance;
            }

            Console.WriteLine(maxDistance);
        }
    }
}
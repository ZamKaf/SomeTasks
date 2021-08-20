using System;

namespace UniTests.SummerTasks2021
{
    public class Task179ColorHouses : ITask
    {
        public int GetMinCost(int[][] costs)
        {
            const int countColors = 3;
            var minCosts = 0;

            var previousCosts = new int[countColors];
            var currentCosts = new int[countColors];

            foreach (var cost in costs)
            {
                for (var i = 0; i < countColors; i++)
                {
                    var (otherColor1, otherColor2) = i switch
                    {
                        0 => (1, 2),
                        1 => (0, 2),
                        2 => (0, 1),
                        _ => throw new Exception("WrongIndex!")
                    };
                    currentCosts[i] = Math.Min(previousCosts[otherColor1], previousCosts[otherColor2]) + cost[i];
                }

                Array.Copy(currentCosts, previousCosts, countColors);
            }

            minCosts = Min(currentCosts[0], currentCosts[1], currentCosts[2]);
            return minCosts;
        }

        // He's so ugly! I love him!!!
        int Min(int a, int b, int c) => a < b ? a < c ? a : c : b < c ? b : c;

        public void Run()
        {
            var costs = new[] { new[] {17, 2, 1 }, new[] {16, 16, 2}, new[] {14, 3, 19} };
            var res = GetMinCost(costs);
            Console.WriteLine(res);
        }
    }
}
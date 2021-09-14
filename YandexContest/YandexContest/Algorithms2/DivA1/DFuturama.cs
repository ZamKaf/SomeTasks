using System;
using System.Collections.Generic;
using System.Linq;

namespace YandexContest.Algorithms2.DivA1
{
    public class DFuturama : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var numbers = reader.ReadInt32Array();
            var n = numbers[0];
            var m = numbers[1];
            var shifts = new List<int[]>();
            for (var i = 0; i < m; i++)
            {
                shifts.Add(reader.ReadInt32Array());
            }

            var people = Enumerable.Range(0, n+1).ToArray(); // На 1 элемент больше, 0й будем игнорировать.
            foreach (var shift in shifts)
            {
                (people[shift[0]], people[shift[1]]) = (people[shift[1]], people[shift[0]]);
            }

            for (var i = 1; i < n - 1; i++)
            {
                if (people[i] != i)
                {
                    var current = i;
                    while (people[current] != i)
                    {
                        Console.WriteLine($"{current} {n-1}");
                        (people[current], people[n-1]) = (people[n-1], people[current]);
                        current = people[n - 1];
                    }
                    Console.WriteLine($"{current} {n}");
                    (people[current], people[n]) = (people[n], people[current]);
                    
                    Console.WriteLine($"{i} {n}");
                    (people[i], people[n]) = (people[n], people[i]);
                    
                    Console.WriteLine($"{people[n-1]} {n-1}");
                    (people[people[n-1]], people[n-1]) = (people[n-1], people[people[n-1]]);
                }
            }

            if (people[n - 1] == n)
            {
                Console.WriteLine($"{n-1} {n}");
                (people[n-1], people[n]) = (people[n-1], people[n]);
            }
        }
    }
}
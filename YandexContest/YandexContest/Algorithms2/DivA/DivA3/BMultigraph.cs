using System;
using System.Collections.Generic;

namespace YandexContest.Algorithms2.DivA.DivA3
{
    public class BMultigraph : IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var nums = reader.ReadInt32Array();
            var vertexCount = nums[0];
            var edgeCount = nums[1];
            var vertices = new HashSet<ValueTuple<int, int>>();
            for (var i = 0; i < edgeCount; i++)
            {
                var vertex = reader.ReadInt32Array();
                var first = vertex[0];
                var second = vertex[1];
                if (first == second)
                    continue;
                vertices.Add((Math.Min(first, second), Math.Max(first, second)));
                
            }
            Console.WriteLine($"{vertexCount} {vertices.Count}");
            foreach (var vertex in vertices)
            {
                Console.WriteLine($"{vertex.Item1} {vertex.Item2}");
            }
        }
    }
}
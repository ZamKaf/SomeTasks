using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using SomeTasks.Patterns.Strategy;
using SomeTasks.Vovan;
using SomeTasks.WeirdSamples;

namespace SomeTasks
{
    class EqualsTest : IEqualityComparer<EqualsTest>
    {
        public bool Equals(EqualsTest? x, EqualsTest? y)
        {
            Console.WriteLine("123");
            return true;
        }

        public int GetHashCode(EqualsTest obj)
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        public static async Task Main()
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            IAsyncEnumerable<int> enumerable = AsyncYielding();
            Console.WriteLine($"Time after calling: {sw.ElapsedMilliseconds}");

            await foreach (var element in enumerable.ConfigureAwait(false))
            {
                Console.WriteLine($"element: {element}");
                Console.WriteLine($"Time: {sw.ElapsedMilliseconds}");
            }
        }

        static async IAsyncEnumerable<int> AsyncYielding()
        {
            foreach (var uselessElement in Enumerable.Range(1, 3))
            {
                Task task = Task.Delay(TimeSpan.FromSeconds(uselessElement));
                Console.WriteLine($"Task run: {uselessElement}");
                await task;
                yield return uselessElement;
            }
        }
        
    }
}
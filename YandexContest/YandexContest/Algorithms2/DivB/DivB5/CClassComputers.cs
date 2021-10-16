using System;
using System.Collections.Generic;
using System.Linq;

namespace YandexContest.Algorithms2.DivB.DivB5
{
    public class CClassComputers :IRunnable
    {
        public void Run()
        {
            var reader = new NumbersReader();
            var nums = reader.ReadInt32Array();
            var groupsCount = nums[0];
            var classCount = nums[1];
            var groups = reader.ReadInt32Array().Select((g, i) => new Group { Students = g, Index = i +1 }).ToList();
            var classes = reader.ReadInt32Array().Select((c, i) => new { Comps = c, Index = i + 1 }).ToList();
            groups.Sort((g, g1) => g.Students.CompareTo(g1.Students));
            classes.Sort((c1, c2) => c1.Comps.CompareTo(c2.Comps));
            var classesIndex = classCount - 1;
            var groupClassesCount = 0;
            for (var groupsIndex = groupsCount - 1; groupsIndex >= 0; groupsIndex--)
            {
                var currentGroup = groups[groupsIndex];
                var currentClass = classes[classesIndex];
                // Если группа помещается в текущий класс
                if (currentGroup.Students < currentClass.Comps)
                {
                    currentGroup.Class = currentClass.Index;
                    classesIndex--;
                    groupClassesCount++;
                }
            }

            groups.Sort((g1, g2) => g1.Index.CompareTo(g2.Index));
            Console.WriteLine(groupClassesCount);
            Console.WriteLine(string.Join(" ", groups.Select(g => g.Class)));
        }
    }

    class Group
    {
        public int Students { get; set; }
        public int Index { get; set; }
        public int Class { get; set; } = 0;
    }
}
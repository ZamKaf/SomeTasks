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
            var groups = reader.ReadInt32Array().Select((g, i) => new Group { Students = g, Index = i }).ToList();
            var classes = reader.ReadInt32Array().Select((c, i) => new { Comps = c, Index = i + 1 }).ToList();
            groups.Sort((g, g1) => g.Students.CompareTo(g1.Students));
            classes.Sort((c1, c2) => c1.Comps.CompareTo(c2.Comps));
            var stack = new Stack<Group>();
            var classesIndex = 0;
            var groupsIndex = 0;
            var groupClassesCount = 0;
            while (classesIndex < classCount && groupsIndex < groupsCount)
            {
                var currentGroup = groups[groupsIndex];
                var currentClass = classes[classesIndex];
                // Если группа помещается в текущий класс
                if (currentGroup.Students < currentClass.Comps)
                {
                    stack.Push(currentGroup);
                    groupsIndex++;
                    continue;
                    
                }

                if (stack.Count == 0)
                {
                    classesIndex++;
                    continue;
                }

                var lilGroup = stack.Pop();
                lilGroup.Class = currentClass.Index;
                classesIndex++;
                groupClassesCount++;
            }

            while (stack.Count != 0 && classesIndex < classCount)
            {
                stack.Pop().Class = classes[classesIndex].Index;
                groupClassesCount++;
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
using System;

namespace SomeTasks.WeirdSamples
{
    public static class Increment
    {
        public static void Test()
        {
            var i = 0;
            i += Inc(ref i);
            Console.WriteLine(i);
        }

        static int Inc(ref int i)
        {
            return i++;
        }
    }
}
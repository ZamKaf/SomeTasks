using System;
using System.Linq;
using System.Globalization;

/// В контекстах mono 5.2.0
namespace YandexContest
{
    class Program
    {
        const string Freeze = "freeze";
        const string Heat = "heat";
        const string Auto = "auto";
        const string Fan = "fan";
        
        public static void Main()
        {
            var reader = new NumbersReader();
            var nums = reader.ReadInt32Array();
            var troom = nums[0];
            var tcond = nums[1];
            var mode = Console.ReadLine();

            if (troom == tcond || mode == Auto)
                Console.WriteLine(tcond);
            else if (mode == Fan)
                Console.WriteLine(troom);
            else if ((troom > tcond && mode == Freeze) || 
                     (troom < tcond && mode == Heat))
                Console.WriteLine(tcond);
            else
                Console.WriteLine(troom);
        }
    }

      class NumbersReader
    {
        public int ReadInt32()
        {
            return int.Parse(Console.ReadLine());
        }
        

        public long ReadInt64()
        {
            return long.Parse(Console.ReadLine());
        }

        public int[] ReadInt32Array()
        {
            return Console.ReadLine().Trim(' ').Split(' ').Where(s => s != "")
                .Select(i => int.Parse(i)).ToArray();
        }

        public long[] ReadInt64Array()
        {
            return Console.ReadLine().Trim(' ').Split(' ').Where(s => s != "")
                .Select(i => long.Parse(i)).ToArray();
        }

        public double[] ReadDoubleArray()
        {
            return Console.ReadLine().Trim(' ').Split(' ').Where(s => s != "")
                .Select(d => double.Parse(d, new NumberFormatInfo())).ToArray();
        }
    }
}
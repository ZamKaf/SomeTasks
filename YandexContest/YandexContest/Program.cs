using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Globalization;
using System.Text;

namespace YandexContest
{
    internal class Program
    {
        static void Main()
        {
            var t1 = new Test1();
            var t2 = new Test1();
            t1.Incr(t2);
            t1.Incr(t2);
            t1.Incr(t2);
            t1.Incr(t2);
            t1.Incr(t2);
            t1.Incr(t2);
            Console.WriteLine(t2.GetD());
        }
    }

    class Test1
    {
        int data;

        public void Incr(Test1 t)
        {
            t.data++;
        }

        public int GetD()
        {
            return data;
        }
    }

    internal class NumbersReader
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
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Globalization;
using YandexContest.Algorithms2.DivA.DivA1;

namespace YandexContest
{
    class Program
    {
        delegate void Message();
 
        static void Main(string[] args)
        {
            Message mes1 = Hello;
            Message mes2 = HowAreYou;
            Message mes3 = mes1 + mes2; // объединяем делегаты
            mes1 += HowAreYou;
            mes3 += Hello;
            mes3(); // вызываются все методы из mes1 и mes2
         
            Console.Read();
        }
        private static void Hello()
        {
            Console.WriteLine("Hello");
        }
        private static void HowAreYou()
        {
            Console.WriteLine("How are you?");
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
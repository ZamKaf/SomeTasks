using System;
using System.Runtime.InteropServices;

namespace YandexContest.Algorithms.Homework1
{
    public class Conditioner : IRunnable
    {
        const string Freeze = "freeze";
        const string Heat = "heat";
        const string Auto = "auto";
        const string Fan = "fan";
        
        public void Run()
        {
            var reader = new NumbersReader();
            var nums = reader.ReadInt32Array();
            var troom = nums[0];
            var tcond = nums[1];
            var mode = Console.ReadLine();

            if (troom == tcond || mode is Auto)
                Console.WriteLine(tcond);
            else if (mode is Fan)
                Console.WriteLine(troom);
            else if ((troom > tcond && mode is Freeze) || 
                (troom < tcond && mode is Heat))
                Console.WriteLine(tcond);
            else
                Console.WriteLine(troom);
        }
    }
}
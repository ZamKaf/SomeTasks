using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace SomeTasks.Vovan
{
    public class Task4 : IRunnable
    {
        int _max;
        int _mid;
        int _min;

        public void Run()
        {
            _min = 15;
            _mid = 20;
            _max = 30;
            var mas = new[] { 1, 2, 4, 5, 6, };
            var h = new HashSet<int>(mas);
            var n = int.Parse(Console.ReadLine());

            NewMethod(n);
            
            Console.WriteLine($"{_min} {_mid} {_max}");
        }

        void NewMethod(int n)
        {
            if (_max < n)
                (_min, _mid, _max) = (_mid, _max, n);
            else if (_mid < n)
                (_min, _mid) = (_mid, n);
            else
                _min = Math.Max(_min, n);
        }
    }
}
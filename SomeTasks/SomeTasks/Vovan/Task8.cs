using System;
using System.Collections.Generic;

namespace SomeTasks.Vovan
{
    public class Task8 : IRunnable
    {
        public void Run()
        {
            
        }
		
        class Numbers
        {
            Dictionary<int, MyList> _data = new();
            void SetArray(int[] mas)
            {
                foreach (var num in mas)
                {
                    var digitSum = DigitSum(num);
                    if (!_data.ContainsKey(digitSum))
                        _data[digitSum] = new MyList(num);
                    else
                        _data[digitSum].Add(num);
                }
            }
			
            int DigitSum(int value)
            {
                var sum = 0;
                while (value != 0)
                {
                    sum += value % 10;
                    value /= 10;
                }
                return sum;
            }
		
        }
		
        class MyList
        {
            List<int> _data = new();
            int _max1 = int.MinValue;
            int _max2 = int.MinValue;
			
            public int MaxSum => _max1 + _max2;
            public bool MoreThan1 => _data.Count > 1;
			
            public MyList(int value)
            {
                _data.Add(value);
                _max1 = value;
            }
			
            public void Add(int value)
            {
                _data.Add(value);
                if (value > _max1)
                    (_max2, _max1) = (_max1, value);
                else if (value > _max2)
                    _max2 = value;
            }
        }
    }
}
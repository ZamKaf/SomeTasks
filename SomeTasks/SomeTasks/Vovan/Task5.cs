using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace SomeTasks.Vovan
{
    /// <summary>
    /// Стек с минимумом
    /// </summary>
    public class Task5 : IRunnable
    {
        public void Run()
        {
            throw new System.NotImplementedException();
        }

        class StackWithMin
        {
            readonly Stack<int> _internalStack = new();
            readonly Stack<int> _minStack = new();

            public int Count => _internalStack.Count;

            public int Min => _minStack.Peek();
            
            public int Pop()
            {
                var res = _internalStack.Pop();
                if (_minStack.Peek() == res)
                    _minStack.Pop();
                return res;
            }

            public int Peek() => _internalStack.Peek();

            public void Push(int value)
            {
                _internalStack.Push(value);

                if (_minStack.Count == 0)
                    _minStack.Push(value);
                else if (value <= _minStack.Peek())
                    _minStack.Push(value);
            }
        }
    }
}
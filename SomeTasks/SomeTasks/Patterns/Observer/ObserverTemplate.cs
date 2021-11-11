using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

namespace SomeTasks.Patterns.Observer
{
    interface IObserver
    {
        void Update(object data, object sender);
    }

    class ConcreteObserver : IObserver
    {
        public void Update(object data, object sender)
        {
            Console.WriteLine($"{sender.GetType()} - {data}");
        }
    }
    
    interface IObservable
    {
        void AddObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers();
    }

    class ConcreteObservable : IObservable
    {
        readonly List<IObserver> _observers = new();
        volatile object _data = new();
        public void AddObserver(IObserver o) => _observers.Add(o);

        public void RemoveObserver(IObserver o) => _observers.Remove(o);

        public void NotifyObservers()
        {
            _observers.ForEach(o => o.Update(_data, this));
        }
    }
}
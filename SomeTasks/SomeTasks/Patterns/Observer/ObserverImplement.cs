using System;
using System.Collections.Generic;

namespace SomeTasks.Patterns.Observer
{
    public static class ObserverImplement
    {
        static void Run()
        {
            var stock = new Stock();
            var bank = new Bank("ЮнитБанк", stock);
            var broker = new Broker("Иван Иваныч", stock);
            // имитация торгов
            stock.Market();
            // брокер прекращает наблюдать за торгами
            broker.StopTrade();
            // имитация торгов
            stock.Market();
        }
    }

    interface IObserverImpl
    {
        void Update(object data);
    }

    interface IObservableIml
    {
        void RegisterObserver(IObserverImpl o);
        void RemoveObserver(IObserverImpl o);
        void NotifyObservers();
    }

    class Stock : IObservableIml
    {
        readonly StockInfo _info = new();
        readonly List<IObserverImpl> _observers = new();
        public void RegisterObserver(IObserverImpl o) => _observers.Add(o);

        public void RemoveObserver(IObserverImpl o) => _observers.Remove(o);

        public void NotifyObservers()
        {
            _observers.ForEach(o => o.Update(_info));
        }

        public void Market()
        {
            var rnd = new Random();
            _info.Usd = rnd.Next(20, 40);
            _info.Euro = rnd.Next(30, 50);
            NotifyObservers();
        }
    }

    class StockInfo
    {
        public int Usd { get; set; }
        public int Euro { get; set; }
    }

    class Broker : IObserverImpl
    {
        public string Name { get; }
        IObservableIml _stock;

        public Broker(string name, IObservableIml obs)
        {
            Name = name;
            _stock = obs;
            _stock.RegisterObserver(this);
        }
        public void Update(object data)
        {
            var stockInfo = data as StockInfo;
            if (stockInfo is { Usd: > 30 })
                Console.WriteLine($"Брокер {Name} продает доллары;  Курс доллара: {stockInfo.Usd}");
            else
                Console.WriteLine($"Брокер {Name} покупает доллары;  Курс доллара: {stockInfo.Usd}");
        }

        public void StopTrade()
        {
            _stock.RemoveObserver(this);
            _stock = null;
        }
    }

    class Bank : IObserverImpl
    {
        public string Name { get; }
        readonly IObservableIml _stock;

        public Bank(string name, IObservableIml stock)
        {
            Name = name;
            _stock = stock;
            _stock.RegisterObserver(this);
        }

        public void Update(object data)
        {
            var stockInfo = data as StockInfo;
            if (stockInfo is { Usd: > 40 })
                Console.WriteLine($"Банк {Name} продает доллары;  Курс доллара: {stockInfo.Usd}");
            else
                Console.WriteLine($"Банк {Name} покупает доллары;  Курс доллара: {stockInfo.Usd}");
        }
    }
}
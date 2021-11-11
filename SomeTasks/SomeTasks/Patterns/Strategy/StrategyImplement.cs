using System;

namespace SomeTasks.Patterns.Strategy
{
    public static class StrategyImplement
    {
        public static void Run()
        {
            var auto = new Car(4, "Volvo", new PetrolMove());
            auto.Move();
            auto.Movable = new ElectricMove();
            auto.Move();
        }
    }

    interface IMovable
    {
        void Move();
    }

    class PetrolMove : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Перемещение на бензине");
        }
    }

    class ElectricMove : IMovable
    {
        public void Move()
        {
            Console.WriteLine("Перемещение на электричестве");
        }
    }

    class Car
    {
        public IMovable Movable { private get; set; }
        
        protected int _passengers;
        protected string _model;
        

        public Car(int passengers, string model, IMovable movable)
        {
            _passengers = passengers;
            _model = model;
            Movable = movable;
        }

        public void Move() => Movable.Move();
    }
}
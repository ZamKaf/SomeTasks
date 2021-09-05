using System;
using System.Linq;
using System.Threading;
using UniTests.OldTasks2017;
using System.Dynamic;

namespace UniTests
{
    public class BaseClass
    {
        public static Field StaticField { get; set; } = new Field("Base static");
        public Field Field { get; set; } = new Field("Base instance");

        static BaseClass()
        {
            Console.WriteLine($"Base static ctr");
        }
        public BaseClass()
        {
            Console.WriteLine("Base instance ctr");
            Foo();
        }

        public virtual void Foo()
        {
            Console.WriteLine("Foo base");
        }
    }

    public class DerivedClass :BaseClass
    {
        public static Field StaticFieldD { get; set; } = new Field("Derived static");
        public Field FieldD { get; set; } = new Field("Derived instance");

        public static DerivedClass Instance => new DerivedClass();
        static readonly Lazy<DerivedClass> _instance = new Lazy<DerivedClass>();

        static DerivedClass()
        {
            Console.WriteLine($"Derived static ctr");
        }

        public DerivedClass()
        {
            Console.WriteLine("Derived instance ctr");
            Foo();
        }

        public override void Foo()
        {
            Console.WriteLine($"Foo derived");
        }
    }

    public class Field
    {
        public Field(string str)
        {
            Console.WriteLine($"{str} field");
        }
    }
    
    class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var test = new Task8MaxElementsSum();
            test.Run();
        }
    }
}
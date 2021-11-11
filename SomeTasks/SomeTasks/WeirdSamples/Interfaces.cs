using System;

namespace SomeTasks.WeirdSamples
{
    
    interface IInterface
    {
        public void Foo1()
        {
            Console.WriteLine("werid1");
        }
        public sealed void Foo()
        {
            Console.WriteLine("werid");
        }
    }

    class MyClass: IInterface
    {
        
    }

    public class Interfaces
    {
        
    }
}
using System;

namespace PrototypeDemo
{


    class Program
    {
        abstract class Prototype 
        {
            public abstract Prototype Clone();
        }


        class A : Prototype
        {
            public int Id { get; set; }
            public override Prototype Clone()
            {
                return new A {Id=this.Id };
            }
        }
        class B : Prototype
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public override Prototype Clone()
            {
                return new B { Id = this.Id ,Name=this.Name};
            }
        }

        static void Main(string[] args)
        {
            var a = new A() { Id = 10 };
            var b = a.Clone();

          
            Console.WriteLine("Hello World!");
        }
    }
}

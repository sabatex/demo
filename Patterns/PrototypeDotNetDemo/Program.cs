using System;

namespace PrototypeDotNetDemo
{
    class Program
    {
        class A : ICloneable
        {
            public int Id { get; set; }
            public object Clone()
            {
                return new A { Id = this.Id };
            }
        }
        class B : ICloneable
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public object Clone()
            {
                return new B { Id = this.Id, Name = this.Name };
            }
        }

        static void Main(string[] args)
        {
            var a = new A() { Id = 10 };

            var b =   ((ICloneable)a).Clone();


            Console.WriteLine("Hello World!");
        }
    }
}

using System;

namespace BuilderDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Director director = new Director();
            Builder b1 = new ConcreteBuilder1();
            Builder b2 = new ConcreteBuilder2();

           Console.WriteLine(director.Construct(new ConcreteBuilder1()).GetResult());

            director.Construct(b2);
            Product p2 = b2.GetResult();
            Console.WriteLine(p2);


        }
    }
}

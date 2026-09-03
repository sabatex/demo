using System;

namespace FactoryMethodDemo
{
    abstract class Product { }
    class ConcreteProductA:Product { }
    class ConcreteProductB:Product { }
    abstract class Creator
    {
        public abstract Product FactoryMethod();
    }

    class ConcreteCreator<C> where C : Product, new()
    {
        public  C FactoryMethod()
        {
            return new C();
        }
    }

    class ConcreteCreatorA : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductA();
        }
    }
    class ConcreteCreatorB : Creator
    {
        public override Product FactoryMethod()
        {
            return new ConcreteProductB();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Creator[] creators = new Creator[] { new ConcreteCreatorA(), new ConcreteCreatorB() };



           foreach (Creator creator in creators)
            {
                Product product= creator.FactoryMethod();
                Console.WriteLine($"Created {product}");
            }

            Console.ReadKey();
        }
    }
}

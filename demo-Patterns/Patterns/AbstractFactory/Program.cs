using System;

namespace AbstractFactory
{
    class Program
    {
        static AbstractProductA SetName(AbstractProductA productA,string name)
        {
            productA.Name = name;
            return productA;
        } 


        static void Main(string[] args)
        {
            AbstractFactory[] abstractFactories = new AbstractFactory[]
            {
                new ConcreteFactory1(),new ConcreteFactory2(),new ConcreteFactory1()
            };

            foreach (AbstractFactory factory in abstractFactories)
            {
                var a = factory.CreateProductA();
                Console.WriteLine(a.Name);
                Console.WriteLine(SetName(a,$"{factory.GetType()}"));
            }
 



            
        }
    }
}

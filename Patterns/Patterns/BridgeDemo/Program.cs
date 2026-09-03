using BridgeImplementor;
using System;

namespace BridgeDemo
{


    public class Abstraction
    {
        protected Implementor implementor;
        public Implementor Implementor { set { implementor = value; }  }
        public virtual void Operation()
        {
            implementor.Operation();
        }
       
    }

    public class RefinedAbstraction : Abstraction
    {
        public override void Operation()
        {
            implementor.Operation();
        }
    }

    public class ConcreteImplementorA : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteImplementorA Operation");
        }
    }

    public class ConcreteImplementorB : Implementor
    {
        public override void Operation()
        {
            Console.WriteLine("ConcreteImplementorB Operation");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Abstraction ab = new RefinedAbstraction();
            ab.Implementor=new ConcreteImplementorA();
            ab.Operation();

            ab.Implementor= new ConcreteImplementorB();
            ab.Operation();



            Console.WriteLine("Hello World!");
        }
    }
}

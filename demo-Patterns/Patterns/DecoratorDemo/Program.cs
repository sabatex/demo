using System;

namespace DecoratorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }



    }


    abstract class Component
    {
        public abstract void Operation();    
    }

    class ConcreteComponent : Component
    {
        public override void Operation()
        {
            Console.WriteLine("Concrete Component ");
        }
    }

    abstract class Decorator:Component
    {
        protected Component component;
        public void SetComponent(Component component)=>this.component=component;

        public override void Operation()
        {
            component?.Operation();
        }
    }


    class ConcreteDecoratorA:Decorator
    {
        public override void Operation()
        {
            base.Operation();
        }
    }

    class ConcreteDecoratorB : Decorator
    {
        public override void Operation()
        {
            base.Operation();
        }
    }





    public abstract class Pizza
    {
        public string Name { get; protected set; }
        public Pizza(string name)
        {
            Name = name; 
        }

        public abstract int GetCost();

    }

    public class GavaiPazza : Pizza
    {
        public GavaiPazza():base("Гавайська піца")
        {

        }
        public override int GetCost()
        {
            return 52;
        }
    }

    public abstract class PizzaDecorator:Pizza
    {
        protected Pizza pizza;
        public PizzaDecorator(string name,Pizza pizza):base(name)
        {
            this.pizza = pizza;
        }
    }

    public class TomatoPizza : PizzaDecorator
    {
        public TomatoPizza(Pizza p):base(p.Name + ", з томатами",p)
        {

        }

        public override int GetCost()
        {
            return pizza.GetCost() + 10;
        }
    }

    public class CheesePizza : PizzaDecorator
    {
        public CheesePizza(Pizza p) : base(p.Name + ", з сиром", p)
        {

        }

        public override int GetCost()
        {
            return pizza.GetCost() + 20;
        }
    }



}

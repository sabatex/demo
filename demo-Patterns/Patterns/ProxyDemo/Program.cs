using System;

namespace ProxyDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public abstract class Subject
    {
        public abstract void Request();
    }

    public class RealSubject : Subject
    {
        public override void Request()
        {
            Console.WriteLine("Called RealSubject.Request()");
        }
    }


    public class Proxy : Subject
    {
        private RealSubject realSubject;
        public override void Request()
        {
            // Use 'lazy initialization'
            if (realSubject == null)
            {
                realSubject = new RealSubject();
            }
            realSubject.Request();
        }
    }

}

using System;

namespace InterfaceDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new Wheel[]
            {
                new Wheel() { Radius = 1},
                new Wheel() { Radius = 5},
                new Wheel() { Radius = 2}
            };
            Array.Sort(a);
            var b = 2;
        }
    }
}

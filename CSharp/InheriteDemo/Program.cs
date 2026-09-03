//using System;
//using InheriteDemo.MyConsole;

using System;
using System.Collections.Generic;
using System.Text;

namespace InheriteDemo
{
    class Program
    {
        static void Main(string[] args)
        {


            Class1 a  = new Class2() { a = 10, b = 5 };

            var summ = a.Summ();
           

            Class2 b = a as Class2;
            int b2 = b.b;
            int getA(object a)
            {
                
                int[,] arr = a as int[,];
                if (arr != null)
                {
                        
                }
                return 0;
            }


 

            System.Console.WriteLine("Hello World!");
        }
    }
}

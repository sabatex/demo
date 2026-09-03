using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace DLLImportDemo
{
    class Program
    {




        static void Main(string[] args)
        {

            //var a = Native32.Add(10, 20);
            //var b = Native32.Div(a, 5);
            //var c = Native32.Mul(b, 30);
            ////var d = Native32.Sub(c, 350);
            //var i = Native32.testString("фффф");
            IntPtr wHnd = Process.GetCurrentProcess().MainWindowHandle;//assuming you are in a C# form application
            Native32.MessageBox(wHnd.ToInt32(), "New Window Title","Демо");


            //Console.WriteLine($"Hello World! {i}");
            Console.ReadLine();
        }
    }
}

using System;
using System.Diagnostics;

namespace SystemPromming
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var handle = Process.Start("C:\\Intel\\test.txt");

            //try
            //{
            //    using (Process myProcess = new Process())
            //    {
            //        //myProcess.StartInfo.UseShellExecute = false;
            //        // You can start any process, HelloWorld is a do-nothing example.
            //        //myProcess.StartInfo.FileName = "C:\\Intel\\test.txt";
            //        //myProcess.StartInfo.CreateNoWindow = true;
            //        //myProcess.Start("C:\\Intel\\test.txt");
            //        // This code assumes the process you are starting will terminate itself. 
            //        // Given that is is started without a window so you cannot terminate it 
            //        // on the desktop, it must terminate itself or you can do it programmatically
            //        // from this application using the Kill method.
            //    }


            //    Console.WriteLine("Hello World!");
            //}
            //catch (Exception e)
            //{
            //    Console.WriteLine(e.Message);
            //}
            //AppDomain.CurrentDomain.ExecuteAssembly(@"C:\Users\serhiy\source\repos\SystemPromming\HelloWorld\bin\Debug\netcoreapp3.1\HelloWorld.exe");


        }
    }
}

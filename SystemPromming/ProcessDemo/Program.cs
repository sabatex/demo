using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;

namespace ProcessDemo
{
    class Program
    {


        // Loads the content of a file to a byte array. 
        static byte[] loadFile(string filename)
        {
            FileStream fs = new FileStream(filename, FileMode.Open);
            byte[] buffer = new byte[(int)fs.Length];
            fs.Read(buffer, 0, buffer.Length);
            fs.Close();

            return buffer;
        }

        static void Main(string[] args)
        {
            //Process.Start(@"C:\Intel\test.txt");
            try
            {
                //    using (Process myProcess = new Process())
                //    {
                //        myProcess.StartInfo.UseShellExecute = false;
                //        // You can start any process, HelloWorld is a do-nothing example.
                //        myProcess.StartInfo.FileName = @"C:\Users\serhiy\source\repos\SystemPromming\HelloWorld\bin\Debug\netcoreapp3.1\HelloWorld.exe";
                //        myProcess.StartInfo.CreateNoWindow = true;

                //        myProcess.Start();
                //        //var ps = Process.GetProcessesByName("HelloWorld");
                //        //ps[0].PriorityClass = ProcessPriorityClass.BelowNormal;

                //        // This code assumes the process you are starting will terminate itself. 
                //        // Given that is is started without a window so you cannot terminate it 
                //        // on the desktop, it must terminate itself or you can do it programmatically
                //        // from this application using the Kill method.
                //        myProcess.Kill();
                //    }
                //
 
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            byte[] ass = loadFile(@"C:\Users\serhiy\source\repos\SystemPromming\HelloWorldDN\bin\Debug\HelloWorldDN.exe");
            var typ = ass.GetType();
            var s = AppDomain.CurrentDomain.Load(ass);
            var p =  s.GetType("HelloWorldDN.Program");
            var method = p.GetMethod("Main");
            var instance = Activator.CreateInstance(p);
            var res = method.Invoke(instance, new object[] { new string[] {"ffff" } });

            var r = AppDomain.CurrentDomain.ExecuteAssembly(@"C:\Users\serhiy\source\repos\SystemPromming\HelloWorldDN\bin\Debug\HelloWorldDN.exe");

            Console.WriteLine("Hello World Main");
            Console.ReadKey();

        }
    }
}

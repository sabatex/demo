using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ThreadDemoNET
{
        class Program
        {
        static int common = 20;
        
        static int TakeAsWhile(string name, int count)
        {
            //common--;
            Console.WriteLine($"Thread {name} стартував!");
            while (--count > 0)
            {
                Thread.Sleep(100);
                Console.WriteLine($"Thread {name} count={count}");
            }
            Console.WriteLine($"Thread {name} завершився!");
            return count;
        }

        public delegate int TakeAsWhileDelegate(string name, int count);

        static void Main(string[] args)
            {

            TakeAsWhileDelegate dl = TakeAsWhile;
            var t1 = new Thread(() => dl.Invoke("Поток 1", 20)); // default priority status
            var t2 = new Thread(() => dl.Invoke("Поток 2", 30), 200);
            t1.Priority = ThreadPriority.Highest;
            //t1.IsBackground = true;
            t1.Start();
            //t2.IsBackground = true;
            t2.Start(); 
            IAsyncResult t3= dl.BeginInvoke("Асинхронне виконання метода ", 20, CallBack, null);
            for (int i=20;i>0;i--)
            {
                t1.Join();
                Thread.Sleep(100);
                Console.WriteLine($"Thread Поток 0 count={i}");
            }

            //Thread.Sleep(200);
            //t2.Suspend();
            //Thread.Sleep(800);
            //t2.Resume();


              
                while (!t3.IsCompleted)
                {
                    Console.WriteLine("Чекаємо завершення потоку...");
                    Thread.Sleep(100);
                }
                var r = dl.EndInvoke(t3);
                Console.WriteLine($"Результат {r}");
                Console.ReadLine();

            }

        private static void CallBack(IAsyncResult ar)
        {
            var s = ar.AsyncState as Func<string,int,int>;
            //var r = s.EndInvoke(ar);
        }
    }
    }

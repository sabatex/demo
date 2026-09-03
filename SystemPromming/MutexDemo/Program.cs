using System;
using System.Threading;
using System.Threading.Tasks;

namespace MutexDemo
{
    class Program
    {       

        static int Counter=1;
        private static Mutex locker = new Mutex();

        private static EventWaitHandle ew;
        static void TaskIncrementThreadStatic(string msg)
        {
            for (int i = 1; i < 10000000; i++)
            {
                if(locker.WaitOne())
                {
                    Counter++;
                }
            }
            
        }

        static void TaskIncrementWaiter(string msg)
        {
            for (int i = 1; i < 10; i++)
            {
                if (ew.WaitOne())
                {
                    Counter++;
                    Console.WriteLine($"Task {msg} counter {Counter}");
                }
            }

        }



        static void Main(string[] args)
        {
            ew = new EventWaitHandle(false, EventResetMode.AutoReset);


            //var ds = Thread.AllocateDataSlot();
            var t1 = new Thread(() => TaskIncrementWaiter("1"));
            var t2 = new Thread(() => TaskIncrementWaiter("2"));
            t1.Start();
            t2.Start();
            //TaskIncrement("Non Task");
            //var t3 = new Thread(() => TaskIncrement("3"));
            //var t4 = new Thread(() => TaskIncrement("4"));
            //t3.Start();
            //t4.Start();

            //Parallel.Invoke(() => TaskIncrementWaiter("1"), () => TaskIncrementWaiter("2"));
            //Parallel.Invoke(() => TaskIncrementWaiter("3"), () => TaskIncrementWaiter("4"));
            for (int i = 0;i<100;i++)
            {
                ew.Set();
                Thread.Sleep(100);
            }

            







            //Thread.BeginCriticalRegion();



            //Semaphore semaphore = new Semaphore(1, 5, "AccesToFile", out bool createdNew);
            ////semaphore.Release();
            //Mutex mutex = new Mutex(false, "FileAccessDemo", out bool  createNew);
            //if (!createNew)
            //{
            //    Console.WriteLine("The anathe application started");
            //    //mutex.ReleaseMutex();
            //    Console.ReadKey();
            //}
            //else
            //if (mutex.WaitOne())
            //{
            //  try
            //        {

            //        }



            //        finally
            //        {
            //            mutex.ReleaseMutex();
            //        }
            //}

            Console.WriteLine("Hello World!");
            Console.ReadLine();
        }
    }
}

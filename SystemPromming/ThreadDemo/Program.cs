using System;
using System.Threading;
using System.Threading.Tasks;

namespace ThreadDemo
{
    class Program
    {
        static int TakeAsWhile(string name,int count)
        {
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
        static void DoSomethinginThread(object state) // Метод, который будет добавлен в поток.
        {
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"выполнение внутри потока из пула {Thread.CurrentThread.ManagedThreadId}, на этапе{i}");
            Thread.Sleep(50);
        }
    }

    static void Main(string[] args)
        {
           
            TakeAsWhileDelegate dl = TakeAsWhile;
            var t1 = new Thread(() => dl.Invoke("Поток 1",20)); // default priority status
            t1.Start();
            t1.Interrupt();


            //var t2 = new Thread(() => dl.Invoke("Поток з обмеженням стека",20),200);
            //t1.Start();
            //t2.Start();
            //IAsyncResult t3 = dl.BeginInvoke("Асинхронне виконання метода ", 20, null, null);
            //var wt = new Task(() => dl.Invoke("Асинхронне виконання метода ", 20));
            //var followUp = wt.ContinueWith(new TaskCallback);
            //var workTask = Task.Run(() => dl.Invoke("Асинхронне виконання метода ",20));
            //Thread.Sleep(200);
            //t2.Suspend();
            //Console.WriteLine("Синронне старт");
            //for (int i = 20; i > 0; i--)
            //{
            //    var s =TakeAsWhile("Синхронне виконання метода",20);
            //}
            //Console.WriteLine("Синронне кінець");

            //while (!workTask.IsCompleted)
            //{
            //    Console.WriteLine("Чекаємо завершення потоку...");
            //    Thread.Sleep(100);
            //}
            //var r = workTask.Result;
            //Console.WriteLine($"Результат {r}");
            //Console.ReadLine();

            //int CountofWorkThreads;
            //int CountofImputOutputThreads;
            ThreadPool.GetMaxThreads(out int CountofWorkThreads, out int CountofImputOutputThreads);
            Console.WriteLine("Максимальное количество потоков: " + CountofWorkThreads + "\nКоличество потоков ввода-вывода: " + CountofImputOutputThreads);
            //ThreadPool.SetMaxThreads(2);
            for (int i = 0; i < 5000; i++)
                ThreadPool.QueueUserWorkItem(DoSomethinginThread); // Добавляем в пул потоков метод.
            Thread.Sleep(3000);

            Console.ReadLine();
        }

        private static void TaskCallback(Task arg1, object arg2)
        {
            throw new NotImplementedException();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskSummDemo
{
    class Program
    {
        static int Summ(params int[] args)
        {
            int result = 0;
            foreach (var a in args) result += a;
            return result;
        }

        static void Main(string[] args)
        {
            var tasks =
                new Task<int>[]
                {
                Task.Run(() => Summ(10, 23, 23, 54456, 64, 545)),
                Task.Run(()=>Summ(23,23,246,5656,56,5757,76)),
                Task.Run(()=>Summ(23,23))

                };
                
               foreach (var t in tasks)
               {
                    t.Wait();
                    Console.WriteLine($"Result {t.Result}");
               }


            Console.WriteLine("Hello World!");
        }
    }
}

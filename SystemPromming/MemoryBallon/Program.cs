using System;
using System.Collections.Generic;

namespace MemoryBallon
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new List<int[]>();
            for (int i=1;i<1000000;i++)
            {
                var b = new int[1000000];
                for(int j =0;j< 1000000;j++)
                {
                    b[j]= j;
                }

                a.Add(new int[1000000]);

            }

            Console.WriteLine("Hello World!");
        }
    }
}

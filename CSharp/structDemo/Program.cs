using System;

namespace structDemo
{
    class Program
    {
        
        static void Main(string[] args)
        {
            var t1 = new object();
            var t2 = new object();
            var t3 = new { a = 10,b=22 };
           





            sabatex.UInt128? t = 10;

 
            int? a1 = 42;
            if (a1 is int valueOfA)
            {
                Console.WriteLine($"a is {valueOfA}");
            }
            else
            {
                Console.WriteLine("a does not have a value");
            }




            string maxDecimalValue = "340282366920938463463374607431768211455";
            sabatex.UInt128 a = 0;
            if (a != 0) throw new Exception();
            a++;
            if (a!=1) throw new Exception();
            a--;


            a = 0xFFFFFFFFFFFFFFFF;
            ulong b = (ulong)a;
            a++;
            a--;
            var c = a + a;
            var d = c - a;
            var s = d.ToString();
            var m = a * 0x100;
            var cc = a * 0;
            a++;
            var sf = a >> 1;

            var dv = m / 0x100;
            var os = m % 0x103;

            var hex = sabatex.UInt128.Parse("0x ffff ffff ffff ffff ffff ffff ffff ffff");
            var bin = sabatex.UInt128.Parse("0b 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111 1111");
            var dec = sabatex.UInt128.Parse(maxDecimalValue);
            
            if (hex != bin) throw new Exception();
            if (hex != sabatex.UInt128.MaxValue) throw new Exception();
            var dc = sabatex.UInt128.Parse("255");
            var str = dc.ToDecimalString();
            sabatex.UInt128 test = 1;
            Console.WriteLine((test = 1).ToDecimalString());
            Console.WriteLine((test = 10).ToDecimalString());
            Console.WriteLine((test = 100).ToDecimalString());
            Console.WriteLine((test = sabatex.UInt128.Parse("1000000000000000000000000000000")).ToDecimalString());
            Console.WriteLine(hex.ToHexString());
            Console.WriteLine(bin.ToDecimalString());
        }
    }
}

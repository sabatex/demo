using System;
using System.Collections.Generic;
using System.Text;

namespace InheriteDemo
{
    public class Class1
    {
        public   int a;

        public  int Summ()
        {
            return a;
        }
 
    }

public class Class2 : Class1
{
        public int b;
        public int Summ()
        {
            return a + b;
        }

    }


}


using System;
using System.Collections.Generic;
using System.Text;

namespace CSharp
{
    public class MyException:Exception
    {
        public MyException(string msg):base(msg)
        {

        }
    }
}

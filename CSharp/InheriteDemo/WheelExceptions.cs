using System;
using System.Collections.Generic;
using System.Text;

namespace InheriteDemo
{
    public class WheelExceptionInitial:Exception
    {
        public override string Message => base.Message;
    }
}

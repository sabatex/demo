using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CommonLib
{
    public class StateObject
    {
        private int state = 5;
        private object sync = new object();
        public void ChangeState(int loop)
        {
            lock (sync)
            {
                if (state == 5)
                {
                    state++;
                    Trace.Assert(state == 6, $"Race condition occured after {loop} loops");
                }
                state = 5;
            }
        }
    }
}


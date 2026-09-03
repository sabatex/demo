using System;
using System.Diagnostics;

namespace CommonLib
{
    public class SampleTask
    {
        public void RaceCondition(object o)
        {
            Trace.Assert(o is StateObject, "o must be of type StateObject");
            var state = o as StateObject;
            int i = 0;
            while (true)
            {
                lock (state)
                {
                    state.ChangeState(i++);
                }
            }
        }
    }
}

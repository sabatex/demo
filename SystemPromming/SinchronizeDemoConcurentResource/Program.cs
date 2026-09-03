using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace SinchronizeDemoConcurentResource
{
    class Program
    {
        static void Main(string[] args)
        {
            var state = new StateObject();
            for (int i=0; i<20;i++)
            {
                //new Task(new SampleThread().RaceCondition,state).Start();
                Task.Run(() => new SampleThread().RaceCondition(state));
            }
            Thread.Sleep(10000);
        }
    }

    public class StateObject
    {
        private int state = 5;
        public void ChangeState(int loop)
        {
            if (state == 5)
            {
                state++;
                Trace.Assert(state == 6, $"Race condition occured after {loop} loops");
            }
            state = 5;
        }
    }


    public class SampleThread
    {
        public void RaceCondition(object o)
        {
            Trace.Assert(o is StateObject, "o must be of type StateObject");
            var state = o as StateObject;
            int i = 0;
            while (true)
            {
                state.ChangeState(i++);
            }
        }
    }
}

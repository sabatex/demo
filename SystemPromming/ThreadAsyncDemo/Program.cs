using System;

namespace ThreadAsyncDemo
{
    class Program
    {
        public delegate int WorkSumm(params int[] args);

        static int Summ(params int[] args)
        {
            int result = 0;
            foreach (var a in args) result += a;
            return result;
        }

        static void Main(string[] args)
        {
            WorkSumm d = Summ;
            var handler = d.BeginInvoke(new int[] { 10, 20, 30 },SummCallBack,null);

            Console.WriteLine("Hello World!");
        }

        private static void SummCallBack(IAsyncResult ar)
        {
            throw new NotImplementedException();
        }
    }
}

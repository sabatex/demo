using System;

namespace SingeltonDemo
{
    class Singelton
    {

        static Singelton()
        {
            _instance = new Singelton();
        }

        private static Singelton _instance;
        private Singelton()
        {

        }
        public static Singelton InstanceStatic => _instance;
 

        public static Singelton Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new Singelton();
                }
                return _instance;
            }
        }


    }



    class Program
    {

        


        static void Main(string[] args)
        {
            var s = Singelton.InstanceStatic;
            var b = Singelton.InstanceStatic;
            Console.WriteLine("Hello World!");
        }
    }
}

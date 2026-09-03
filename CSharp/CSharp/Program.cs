// See https://aka.ms/new-console-template for more information
using CSharp;

Console.WriteLine("Hello, World!");

class Demo { 
static int Plus(int a, int b, object c)
{
    return a + b + (int)c;
}
int s;

int sg { get { return s; } set { s = value + 20; } }


int a { get => 10 + 20 - b; }
int b { get { return 10; } }


struct Ad
{
    public int A;
    public int B;

}

class DemoClass
{
    public int A;
    public int B;

}


    static void Main1(string[] args)
    {
        var wheel = new Wheel();
        var wheel2 = new Wheel(23);
        Wheel.Width = 10;

        var db = wheel.Calc();

        Wheel.CalcDiametr(10, new object[] { 12, 23, 23, 23, 232, "232342", "Ot" });

        wheel.Radius = 5;
        wheel2.Radius = 15;
        decimal pr = 10;
        Wheel rr = new Wheel();
        wheel.SetDiameter(pr, out rr);

        {
            wheel.SetDiameter(pr, out Wheel r);
            var br = r;
        }
        var brr = rr;


        wheel.DiameterL = 10;
        var dd = wheel.DiameterL;
        var d = wheel.GetDiameter();
        var s = wheel.GetSquare();
        s = Wheel.CalcDiametr(wheel);

        //if (args.Length > 1)
        //{
        //    Console.WriteLine("Перший параметр {0} - {1}",args[0], args[1]);
        //}
        //Console.Write("ssss");
        //Console.Write("eeee");
        //var s = Console.ReadLine();


        //var key =      Console.ReadKey();
        //Console.Write("Введи значення:");
        //var s = Console.ReadLine();
        //Console.WriteLine();
        //Console.WriteLine($"Ви ввели : {s}");

        int a = 10;
        int b = 9;

        string s3 = a == b ? "aaaaa" : "bbbb";
        //object d = s ?? "rtyty";
        // for,while,do while

        //foreach (char c in s3)
        //{
        //    Console.WriteLine(c);    
        //}

        //for (int i=0;i<s3.Length;i++)
        //{
        //    Console.WriteLine(s3[i]);
        //}

        //string s = "sssss"; // heap
        //s = s + "fddhghfh";
        //// ssssss, sssssfddhghfh
        //object c = 10;

        //StringBuilder sb = new StringBuilder();
        //sb.Append("fdgfdhh");
        //sb.Append("2222");
        //// sb = fdgfdhh2222
        //s = "";
        //for (int i = 0;i< 100000;i++)
        //{
        //    if (i % 2 == 0)
        //    {
        //        sb = sb.Append("парне число -" + i.ToString());
        //    }
        //}
        //sb.ToString();

        //StringBuilder[] mi = new StringBuilder[] {new StringBuilder() , new StringBuilder(), new StringBuilder(), new StringBuilder(), new StringBuilder() };

        int[,] td = new int[,] { { 2, 3 }, { 4, 5 } };

        int[] od = new int[] { 1, 2, 3, 4, 5 };
        int c1 = od[1];  //= pointer + 2 * sizeof(int))

        int ccc = td[0, 0];
        var num = td.GetEnumerator();



        //foreach (var e in td)
        //{
        //    Console.   WriteLine(e.ToString());
        //}


        int lg = td.Length;

        List<int> ls = new List<int>();





























        var ma = new[,] { { 10, 15 }, { 23, 24 } };
        var mb = new[,] { { 2, 6 }, { 9, 12 } };
    }

}

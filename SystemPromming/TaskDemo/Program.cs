using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using TaskDemo;

    [DllImport("DemoDll.dll", CallingConvention = CallingConvention.Cdecl, EntryPoint = "MultipleOneElement")]
    static extern double MultipleOneElementCpp(int rows, int row, int column, double[,] a, double[,] b);


object sync = new object();

    void TaskIncrement(string msg)
    {
        for (int i = 1; i < 10; i++)
        {
            lock (sync)
            {
                
                MP.Counter++;
                Console.WriteLine($"Task {msg} counter {MP.Counter}");
            }
        }
    }

    void TaskIncrementMonitor(string msg)
    {
        for (int i = 1; i < 10; i++)
        {
            Monitor.Enter(sync);
            try
            {

                MP.Counter++;
                Console.WriteLine($"Task {msg} counter {MP.Counter}");
            }
            finally
            {
                Monitor.Exit(sync);
            }
        }
    }

    void TaskIncrementLock(string msg)
    {
        for (int i = 1; i < 10; i++)
        {
            lock (sync)
            {

                MP.Counter++;
                Console.WriteLine($"Task {msg} counter {MP.Counter}");
            }
            Thread.Sleep(100);
        }
    }

    decimal TaskMethod(string msg, int loops)
    {
        if (loops < 1)  return 0;
        decimal test = 0;
        for (int i = 0; i < loops; i++)
        {
            Console.WriteLine($"Task Id: {Task.CurrentId} For {msg} loop {loops}/{i}");
            for (int j = 1; j < 10000000; j++)
            {
                test = (test * j + j) / j;
            }
        }
        return test;
    }
    
decimal TaskMethodContinue(string msg, int loops, int ownerId, decimal baseResult)
    {
        if (loops < 1)
            return 0;
        Console.WriteLine($"Continue task {ownerId} Task Id: {Task.CurrentId} For {msg} start = {baseResult}");
        decimal test = baseResult;
        for (int i = 0; i < loops; i++)
        {
            Console.WriteLine($"Task Id: {Task.CurrentId} For {msg} loop {loops}/{i}");
            for (int j = 1; j < 1000000; j++)
            {
                test = (test * j + j) / j;
            }
        }
        Console.WriteLine($"Task Id: {Task.CurrentId} result = {baseResult}");
        return test;
    }

    decimal TaskMethodWithCancelation(string msg, int loops, CancellationToken ct)
    {
        if (loops < 1)  return 0;
        decimal test = 0;
        for (int i = 0; i < loops; i++)
        {
            Console.WriteLine($"Task Id: {Task.CurrentId} For {msg} loop {loops}/{i}");
            for (int j = 1; j < 1000000; j++)
            {
                test = (test * j + j) / j;
                ct.ThrowIfCancellationRequested();
            }
        }
        return test;
    }

    async Task<decimal> CalcAsync()
    {

        return 10;
    }

    void TaskFactoryMethodDemo()
    {
        var tf = new TaskFactory();
        for (int i=1;i<10;i++)
        {
            var msg = $"Task {i}"; 
            tf.StartNew(() => TaskMethod(msg,i));
        }
    }
    
void TaskMethodDemo()
    {
        for (int i = 1; i < 10; i++)
        {
            var p = new TaskParams { msg = $"Task {i}", loops = i };
            Task.Run(() => TaskMethod(p.msg,p.loops));
        }
    }

    void TaskMethodContinueDemo()
    {
        for (int i = 1; i < 10; i++)
        {
            var t = new TaskParams { loops = i, msg = $"Task {i}" };
            var r = Task.Run(() => TaskMethod(t.msg, t.loops));
            var cont = r.ContinueWith(r=>TaskMethodContinue(t.msg,t.loops,r.Id, r.Result));
        }
    }


    void ParallelDemo()
    {
        Parallel.For(0, 10, i => TaskMethod($"Task {i}", i));
        var values = new int[] {1,2,3,4,5,6,7,8,9,1 };
        Parallel.ForEach(values, i => TaskMethod($"Task {i}", i));
    }


    double MultipleOneElement(MP p, double[,] a, double[,] b)
    {
        double result = 0;
        for (int i = 0; i < p.rows; i++)
            result = result + a[p.i, i] * b[i, p.j];
        return result;
    }



    double[,] MatrixMultiple(double[,] a, double[,] b)
    {
        var rows = a.GetUpperBound(0) + 1;
        var columns = a.Length / rows;
        var tasks = new  Task<double>[rows, columns];
        for (int i=0;i<rows;i++)
        {
            for (int j=0;j<columns;j++)
            {
                var par = new MP { i = i, j = j, rows = rows };
                tasks[i, j] = Task.Run(() => MultipleOneElement(par,a,b));
            }
        }

        var result = new double[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                tasks[i, j].Wait();
                result[i, j] = tasks[i,j].Result;
            }
        }


        return result;

    }
    async Task<double[,]> MatrixMultipleAsync(double[,] a, double[,] b)
    {
        var rows = a.GetUpperBound(0) + 1;
        var columns = a.Length / rows;
        var tasks = new Task<double>[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                var par = new MP { i = i, j = j, rows = rows };
                tasks[i, j] = Task.Run(() => MultipleOneElement(par, a, b));
            }
        }

        var result = new double[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                result[i, j] = await tasks[i, j];
            }
        }
        return result;
    }


    double[,] MatrixMultipleOneThread(double[,] a, double[,] b)
    {
        var rows = a.GetUpperBound(0) + 1;
        var columns = a.Length / rows;
        var result = new double[rows, columns];
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                var par = new MP { i = i, j = j, rows = rows };
                result[i, j] = MultipleOneElement(par, a, b);
            }
        }
        return result;
    }

    void CancelationDemo()
    {
        CancellationTokenSource cts = new CancellationTokenSource();

        // Use ParallelOptions instance to store the CancellationToken
        ParallelOptions po = new ParallelOptions();
        po.CancellationToken = cts.Token;
        po.MaxDegreeOfParallelism = System.Environment.ProcessorCount;
        Console.WriteLine("Press any key to start. Press 'c' to cancel.");
        Console.ReadKey();


        // Run a task so that we can cancel from another thread.
        Task.Factory.StartNew(() =>
        {
            if (Console.ReadKey().KeyChar == 'c')
                cts.Cancel();
            Console.WriteLine("press any key to exit");
        });

        try
        {
            Parallel.For(0,
                             1000,
                             po,
                             (i) =>
                             {
                                 TaskMethod($"Task {i}", 1);
                                 //Console.WriteLine($"Task {i}");
                                 //Thread.Sleep(100);
                                 po.CancellationToken.ThrowIfCancellationRequested();
                             });
        }
        catch (OperationCanceledException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            cts.Dispose();
        }
    }

    void ParallelCancelationDemo()
    {
        int[] nums = Enumerable.Range(0, 10000000).ToArray();
        CancellationTokenSource cts = new CancellationTokenSource();

        // Use ParallelOptions instance to store the CancellationToken
        ParallelOptions po = new ParallelOptions();
        po.CancellationToken = cts.Token;
        po.MaxDegreeOfParallelism = System.Environment.ProcessorCount;
        Console.WriteLine("Press any key to start. Press 'c' to cancel.");
        Console.ReadKey();

        // Run a task so that we can cancel from another thread.
        Task.Factory.StartNew(() =>
        {
            if (Console.ReadKey().KeyChar == 'c')
                cts.Cancel();
            Console.WriteLine("press any key to exit");
        });

        try
        {
            Parallel.ForEach(nums, po, (num) =>
            {
                double d = Math.Sqrt(num);
                Console.WriteLine("{0} on {1}", d, Thread.CurrentThread.ManagedThreadId);
                po.CancellationToken.ThrowIfCancellationRequested();
            });
        }
        catch (OperationCanceledException e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            cts.Dispose();
        }

        Console.ReadKey();


    }

    void ParallelInvokeDemo()
    {
        Parallel.Invoke(() => TaskMethod("Task1", 5), () => TaskMethod("Task5", 10));
    }

    void TaskCancelationDemo()
    {
        CancellationTokenSource cts = new CancellationTokenSource();
        cts.Token.Register(()=>Console.WriteLine("******** Task Canceled *****"));
        var ct = cts.Token;
        Console.WriteLine("Press any key to start.");
        Console.ReadKey();

        // Run a task so that we can cancel from another thread.
        Task.Factory.StartNew(() =>
        {
            Thread.Sleep(1000);
            cts.Cancel();
        });
        try
        {
            Task.Run(() => TaskMethodWithCancelation("Task CancelationTest", 100, ct), cts.Token).Wait();
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
        finally
        {
            cts.Dispose();
        }
    }

    void ParallelInvokeIncDemo()
    {
        Parallel.Invoke(() => TaskIncrement("1"), () => TaskIncrement("2"), () => TaskIncrement("3"));
    }

    void TaskFactoryMethodDemoWithBag()
    {
        var tf = new TaskFactory();
        for (int i = 1; i < 10; i++)
        {
           tf.StartNew(() => TaskMethod($"Task {i}",i));
           //Task.Run(() => TaskMethod($"Task {i}", i));
        }

    }

    double[,] GenerateMatrix(int dimension)
    {
        double[,] result = new double[dimension, dimension];
        var r = new Random();
        for (int i=0;i<dimension;i++)
        {
            for (int j=0;j<dimension;j++)
            {
                result[i, j] = r.NextDouble();
            }
            
        }
        return result;

    }


        //TaskFactoryMethodDemoWithBag();
        //TaskMethodDemo();
        //TaskFactoryMethodDemo();
        //TaskMethodContinueDemo();
        //CancelationDemo();
        //ParallelCancelationDemo();
        //ParallelInvokeDemo();
        //TaskCancelationDemo();
        //ParallelInvokeIncDemo();
        //TaskMethod("test", 10000);
        //ParallelDemo();
        //var a = new double[,] { { 2, 3 }, { 5, 6 } };
        //var b = new double[,] { { 2, 3 }, { 5, 6 } };
        //var c = MatrixMultiple(a, b);




        //var a = GenerateMatrix(2000);
        //var b = GenerateMatrix(2000);
        var a = new double[,] { { 2, 3 }, { 4, 5 } };
        var b = new double[,] { { 6, 7 }, { 8, 9 } };
        var c = MultipleOneElementCpp(2, 0, 0, a, b);
        var d = MultipleOneElement(new MP { i = 0, j = 0, rows = 2 }, a, b);

        //Console.WriteLine($"Start {DateTime.Now}");
        //var c = MatrixMultipleOneThread(a, b);
        //Console.WriteLine($"One thread {DateTime.Now}");
        //var d = MatrixMultiple(a, b);
        //Console.WriteLine($"end {DateTime.Now}");
        //var e = await MatrixMultipleAsync(a, b);
        Console.WriteLine($"end async {DateTime.Now}");



        Console.ReadKey();
    


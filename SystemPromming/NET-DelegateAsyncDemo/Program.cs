
using static NET_DelegateAsyncDemo.DelegateWorkSumm;

void SummCallBack(IAsyncResult ar)
{
    if (ar.IsCompleted)
    {
        //AsyncResult asyncResult = (AsyncResult)ar;
        //var caller = (WorkSumm)asyncResult.AsyncDelegate;
        //string formatString = (string)ar.AsyncState;
        //Console.WriteLine($"Result {caller.EndInvoke(ar)}");
    }
    else
        throw new NotImplementedException();
}

int Summ(params int[] args)
{
    int result = 0;
    foreach (var a in args) result += a;
    return result;
}



WorkSumm d = Summ;
var handler = d.BeginInvoke(new int[] { 10, 20, 30 }, SummCallBack, null);
d.BeginInvoke(new int[] { 10, 20, 30, 56 }, SummCallBack, null);
d.BeginInvoke(new int[] { 10, 20, 30, 1 }, SummCallBack, null);
//handler.AsyncWaitHandle.WaitOne();
Thread.Sleep(500);

Console.WriteLine("Hello World!");
Console.ReadKey();

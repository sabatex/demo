using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BroadCastDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            int PORT = 9876;
            UdpClient udpClient = new UdpClient();
            udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, PORT));


            var from = new IPEndPoint(0, PORT);
            Task.Run(() =>
            {
                while (true)
                {


                    var recvBuffer = udpClient.Receive(ref from);

                    
                    //Console.WriteLine($"{Encoding.UTF8.GetString(recvBuffer)}->{from.Address}");
                }
            });


            var data = Encoding.UTF8.GetBytes("ABCD");
            //for (int i = 0; i < 100; i++)
            //{
            Thread.Sleep(100);
            var ipAddress = new IPAddress(new byte[] {255,255,255,255 });
            udpClient.Send(data, data.Length, "255.255.255.255", PORT);
            udpClient.JoinMulticastGroup(0,ipAddress);
            //udpClient.
   


            Console.WriteLine("Hello World!");
            Console.ReadKey();
        }
    }
}

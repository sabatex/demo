using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BroadCastUDP
{
    class Program
    {
        static void Main(string[] args)
        {
            int PORT = 9876;
            UdpClient udpClient = new UdpClient();
            udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, PORT));

            var from = new IPEndPoint(0, 0);
            Task.Run(() =>
            {
                while (true)
                {
                    var recvBuffer = udpClient.Receive(ref from);
                    Console.WriteLine(Encoding.UTF8.GetString(recvBuffer));
                }
            });

            var data = Encoding.UTF8.GetBytes("ABCD");
            for (int i = 0; i < 100; i++)
            {
                udpClient.Send(data, data.Length, "255.255.255.255", PORT);
                Thread.Sleep(100);
            }

        }
    }
}

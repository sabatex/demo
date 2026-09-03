using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace NetProgramming
{
    class Program
    {
        static Socket ConnectSocket(string server, int port)
        {
            var hostEntry = Dns.GetHostEntry(server);
            foreach (IPAddress address in hostEntry.AddressList)
            {
                var ipe = new IPEndPoint(address, port);
                var tempSocket = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                tempSocket.Connect(ipe);
                if (tempSocket.Connected)
                {
                    return tempSocket;
                }
            }
            return null;
        }


        static string RecivePage(string server, int port)
        {
            string request = $"GET / HTTP/1.1\r\nHost: {server}\r\nConnection: Close\r\n\r\n";
            var bytesSent = Encoding.ASCII.GetBytes(request);
            var bytesReceived = new byte[256];
            var page = new StringBuilder();
            using (var s = ConnectSocket(server, port))
            {
                if (s == null) return ("Connection failed");
                s.Send(bytesSent, bytesSent.Length, 0);
                int bytes = 0;
                do
                {
                    bytes = s.Receive(bytesReceived, bytesReceived.Length, 0);
                    page.Append(Encoding.ASCII.GetString(bytesReceived, 0, bytes));


                } while (bytes > 0);
            }
            return page.ToString();

        }



        static void Main(string[] args)
        {
            // create ip address
            IPAddress ip = new IPAddress(new byte[] { 192, 168, 1, 1 });
            ip = IPAddress.Parse("192.168.1.1");
            IPHostEntry google = Dns.GetHostEntry("www.google.com");
            IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = ipHostInfo.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);
            var gs = RecivePage(google.HostName, 80);


            var s = Dns.GetHostAddresses("www.google.com");

            var ls = new List<IPHostEntry>();
            for (byte i =0;i<255;i++)
            {
                IPAddress a = new IPAddress(new byte[] { 216, 58, 209, i });
                var n = Dns.GetHostEntry(a);
                Console.WriteLine($"Ip: {a}  name: {n.HostName}");

            }
            



            var htmlGet = new SocketHTMLGet();
            string result = htmlGet.SocketSendReceive("www.google.com",80);
            Console.WriteLine(result);
        }
    }
}

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SocketListnerAsync
{
    class Program
    {

        static async void ReciveMessage(Socket handler)
        {
            
            ArraySegment<byte> bytes = new ArraySegment<byte>(new  byte[1024]);
            var sb = new StringBuilder();
            bool end = false;
            do
            {
                int bytesRec = await handler.ReceiveAsync(bytes, 0);
                string s = Encoding.UTF8.GetString(bytes.Array, 0, bytesRec);
                sb.Append(s);

                if (s.IndexOf("\r\n") > -1)
                {
                    Console.WriteLine($"Message from:{handler.RemoteEndPoint}  {sb}");
                    sb.Clear();
                }



            } while (true);
             handler.Shutdown(SocketShutdown.Both);
            handler.Close();
        }

        static void Main(string[] args)
        {
            // Dns.GetHostName returns the name of the
            // host running the application.  
            IPAddress ipAddress = new IPAddress(new byte[] { 192, 168, 10, 1 });
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);
            // Create a TCP/IP socket.  
            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                listener.Bind(localEndPoint);
                listener.Listen(10);
                
                do
                {
                    Console.WriteLine($"Waiting for a connection in {localEndPoint}");
                    Socket handler = listener.Accept();
                    Console.WriteLine($"Connected {handler.RemoteEndPoint}");
                    var tr = new Thread(() => ReciveMessage(handler));
                    tr.IsBackground = true;
                    tr.Start();
                } while (true);

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }



            Console.WriteLine("Hello World!");
        }
    }
}

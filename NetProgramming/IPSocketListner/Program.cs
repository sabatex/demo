// See https://aka.ms/new-console-template for more information
using System.Net;
using System.Net.Sockets;

var ip = new IPAddress(new byte[] { 127, 0, 0, 1 });
var localEndpoint = new IPEndPoint(ip, 11000);
var socketListner = new Socket(ip.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

Console.WriteLine("Hello, World!");

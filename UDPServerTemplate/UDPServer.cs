using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UDPServerTemplate
{
    class UDPServer
    {
        static void Main(string[] args)
        {
            //Eksempel på at sende nummer
            //Laver variable samt angiver værdi 
            int number = 0;

            // Laver IPaddress string om til en readable IP
            IPAddress ip = IPAddress.Parse("127.0.0.1"); //
            
            UdpClient udpSender = new UdpClient("127.0.0.1", 7000); 
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(ip, 7000);
            
            while (true)
            {
                number++;
                Console.WriteLine(" " + number);
                Thread.Sleep(100);

                Byte[] sendBytes = Encoding.ASCII.GetBytes("The number is: " + number);
                try
                {
                    udpSender.Send(sendBytes, sendBytes.Length);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}

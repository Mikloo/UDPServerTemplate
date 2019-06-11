using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UDPServerTemplate
{
    public class UDPServerBroad
    {
        static void MainX(string[] args)
        {
            int number = 0;
            
            UdpClient udpServer = new UdpClient(0);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Broadcast, 7000);

            while (true)
            {
                number++;
                Console.WriteLine(" " + number);
                Thread.Sleep(100);

                Byte[] sendBytes = Encoding.ASCII.GetBytes("The number is: " + number);
                try
                {
                    udpServer.Send(sendBytes, sendBytes.Length, endPoint); 

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }
    }
}

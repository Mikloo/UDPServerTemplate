using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace UDPReceiver
{
    public class UDPReceiverBroad
    {
        static void Main(string[] args)
        {
            //Creates a UdpClient for reading incoming data.
            UdpClient udpReceiver = new UdpClient(7000);

            //BROADCASTING RECEIVER
            //This IPEndPoint will allow you to read datagrams sent from any ip-source on port 7000
            IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 7000);

            //IPEndPoint object will allow us to read datagrams sent from any source.
            //IPEndPoint RemoteIpEndPoint = new IPEndPoint(IPAddress.Any, 0);

            // Blocks until a message returns on this socket from a remote host.
            Console.WriteLine("Receiver is blocked");
            try
            {
                while (true)
                {
                    Byte[] receiveBytes = udpReceiver.Receive(ref RemoteIpEndPoint);

                    string receivedData = Encoding.ASCII.GetString(receiveBytes);

                    Console.WriteLine("Sender: " + receivedData.ToString());
                    Console.WriteLine("This message was sent from " +
                                      RemoteIpEndPoint.Address.ToString() +
                                      " on their port number " +
                                      RemoteIpEndPoint.Port.ToString());
                    Thread.Sleep(200);

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}

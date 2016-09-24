using System;
using System.IO.Ports;

using Leap;
using System.Net.Sockets;
using System.Net;

namespace LeapUniJoysticle
{
    class NetworkStuff
    {
        Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
        IPEndPoint endPoint = null;

        public NetworkStuff(String IpAddress, int port)
        {
          IPAddress serverAddr = IPAddress.Parse(IpAddress);
          endPoint = new IPEndPoint(serverAddr, port);
        }

        public void sendData(byte[] tosend)
        {
          if (endPoint != null)
          {
            sock.SendTo(tosend, endPoint);
          }
        }
    }
}
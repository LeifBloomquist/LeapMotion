using System;
using System.IO.Ports;

using Leap;

namespace LeapMIDI
{
    class SerialStuff
    {
        private SerialPort port;

        public SerialStuff(String portname)
        {
            port = new SerialPort(portname, 57600, Parity.None, 8, StopBits.One);          
            port.Open();            
        }

        public static String[] GetPortNames()
        {
            return SerialPort.GetPortNames();
        }


        public void sendByte(byte tosend)
        {
            byte[] buffer = new byte[1];
            buffer[0] = tosend;

            port.Write(buffer, 0, 1);
        }

        public void sendString(String tosend)
        {
            try
            {
                port.WriteLine(tosend);
            }
            catch (Exception e)
            {
                throw (e);
            }
        }
    }
}
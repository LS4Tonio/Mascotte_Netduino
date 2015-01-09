using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerFront
{
    public class TestSocketManager
    {
        TcpListener listener;
        public TestSocketManager()
        {
            byte[] localIP = new byte[4];
            localIP = LocalIPAddress();
            TcpListener listener = new TcpListener(new IPAddress(localIP), 8080);
            listener.Start();

            while (true)
            {
                Socket soc = listener.AcceptSocket();


                // TODO :des trucs se passent hanhan mystere
                try
                {
                    Stream s = new NetworkStream(soc);
                    StreamReader sr = new StreamReader(s);
                    StreamWriter sw = new StreamWriter(s);

                    sw.AutoFlush = true;


                    sr.Close();
                    sw.Close();
                    s.Close();
                }
                catch (Exception e)
                {

                }

                soc.Close();
            }
        }
        public byte[] LocalIPAddress()
        {
            IPHostEntry host;
            byte[] localIP = null;
            host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    localIP = ip.GetAddressBytes();
                    break;
                }
            }
            return localIP;
        }
    }

}

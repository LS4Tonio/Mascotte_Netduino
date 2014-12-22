using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            listener = new TcpListener(8080);
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
    }
    public class TCPClientNetduino
    {
        TcpClient client;
        public TCPClientNetduino()
        {
            client = new TcpClient("host", 8080);
            try
            {
                Stream s = client.GetStream();
                StreamReader sr = new StreamReader(s);
                StreamWriter sw = new StreamWriter(s);
                sw.AutoFlush = true;

                while (true)
                {
                    // TODO : some mysterious things 
                }
                s.Close();
            }
            finally
            {
                client.Close();
            }
        }
    }
}

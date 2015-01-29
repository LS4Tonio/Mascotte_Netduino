using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RobotMock
{
    public class Wifi
    {
        TcpClient client;
        TcpListener listener;
        NetworkStream s;

        public Wifi()
        {
            client = new TcpClient();
            string message = "";
            Connect(out message);
            byte[] localIP = new byte[4];
            localIP = LocalIPAddress();
            s = client.GetStream();
            // Listener
            listener = new TcpListener(new IPAddress(localIP), 6000);
            CallInitialization();
        }
        private async void CallInitialization()
        {
            await InitializationAsync();
        }
        private Task InitializationAsync()
        {
            return Task.Run(() => InitializeConnection());
        }
        private async Task InitializeConnection()
        {
            try
            {
                while (true)
                {
                    // Get client if there is one
                    client = await listener.AcceptTcpClientAsync();
                    Console.WriteLine("Client connected!");
                    
                    s = client.GetStream();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        /// <summary>
        /// Try to connect to the server.
        /// </summary>
        public bool Connect(out string message)
        {
            string name = Dns.GetHostName();
            try
            {
                client.Connect(name, 3000);
                message = "Connexion effectuée.\n";
                Console.WriteLine(message);
                return true;
            }
            catch (SocketException e)
            {
                message = "Erreur de connexion.\n" + e.Message;
                Console.WriteLine(message);
                return false;
            }
        }
        /// <summary>
        /// Check if connection still active with server.
        /// </summary>
        /// <returns>False is not connected.</returns>
        public bool CheckConnection(out string message)
        {
            message = "";
            if (!client.Client.Connected)
                return Connect(out message);

            return client.Connected;
        }

        /// <summary>
        /// Sending datas for action move
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <param name="oldLine"></param>
        public void SendMove(byte direction, byte posX, byte posY, byte[] oldLine)
        {
            try
            {
                BinaryWriter binaryWriter = new BinaryWriter(s);

                binaryWriter.Write("MOVE"); // Instrution to realize
                binaryWriter.Write(new byte[3] { direction, posX, posY }); // Informations about the move
                binaryWriter.Write(BitConverter.GetBytes((Int32)oldLine.Length)); // Sending length of the table with 4 bytes
                binaryWriter.Write(oldLine, 0, oldLine.Length);
                //binaryWriter.Flush();

                s.Flush();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// Sending data for map synchronization
        /// </summary>
        /// <param name="map"></param>
        public void SendMap(byte[][] map)
        {
            try
            {

                Stream s = client.GetStream();
                BinaryWriter _binaryWriter = new BinaryWriter(s);
                _binaryWriter.Write("MAP");
                _binaryWriter.Write(BitConverter.GetBytes((Int32)map.Length)); // Sending length of the table with 4 bytes
                for (int i = 0; i < map.Length; i++)
                {
                    _binaryWriter.Write(BitConverter.GetBytes((Int32)map[i].Length)); // Sending length of the table with 4 bytes
                    _binaryWriter.Write(map[i], 0, map[i].Length);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public byte getOrders()
        {
            Console.WriteLine("getOrders : " + DateTime.UtcNow.ToString() + DateTime.UtcNow.Millisecond.ToString());
            try
            {
                BinaryReader br = new BinaryReader(s);
                byte value = br.ReadByte();
                if (value == null)
                    return 0;
                else
                    return value;
            }
            catch (Exception e)
            {
                Console.WriteLine("In getOrders() :" + e.Message);
            }
            return 0;
        }
        private byte[] LocalIPAddress()
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
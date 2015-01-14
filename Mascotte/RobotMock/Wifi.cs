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
        public byte[][] GetMap()
        {
            return null;
        }
        TcpClient client;
        bool isConnected;
        public Wifi()
        {
            string name = Dns.GetHostName();
            try
            {
                IPAddress[] addrs = Dns.GetHostEntry(name).AddressList;
                foreach (IPAddress addr in addrs)
                    Console.WriteLine("{0}/{1}", name, addr);
                isConnected = true;
            }
            catch (Exception e)
            {
                isConnected = false;
                Console.WriteLine(e.Message);
            }

            client = new TcpClient(name, 8080);

        }

        public bool IsConnected
        {
            get { return isConnected; }
            set { isConnected = value; }
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

                Stream s = client.GetStream();
                BinaryReader _binaryReader = new BinaryReader(s);
                BinaryWriter _binaryWriter = new BinaryWriter(s);

                _binaryWriter.Write("MOVE"); // Instrution to realize
                _binaryWriter.Write(new byte[3] { direction, posX, posY }); // Informations about the move
                _binaryWriter.Write(BitConverter.GetBytes((Int32)oldLine.Length)); // Sending length of the table with 4 bytes
                _binaryWriter.Write(oldLine, 0, oldLine.Length);

                while (_binaryReader.ReadBoolean()) { } // Wait for Validation by the server
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
                BinaryReader _binaryReader = new BinaryReader(s);
                BinaryWriter _binaryWriter = new BinaryWriter(s);
                _binaryWriter.Write("MAP");
                _binaryWriter.Write(BitConverter.GetBytes((Int32)map.Length)); // Sending length of the table with 4 bytes
                for (int i = 0; i < map.Length; i++)
                {
                    _binaryWriter.Write(BitConverter.GetBytes((Int32)map[i].Length)); // Sending length of the table with 4 bytes
                    _binaryWriter.Write(map[i], 0, map[i].Length);
                }
                while (_binaryReader.ReadBoolean()) { } // Wait for Validation by the server
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}

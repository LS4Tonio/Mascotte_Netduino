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

        public Wifi()
        {
            client = new TcpClient();
            string message = "";
            Connect(out message);
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

            return client.Client.Connected;
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
                NetworkStream s = client.GetStream();
                BinaryReader binaryReader = new BinaryReader(s);
                BinaryWriter binaryWriter = new BinaryWriter(s);

                binaryWriter.Write("MOVE"); // Instrution to realize
                binaryWriter.Write(new byte[3] { direction, posX, posY }); // Informations about the move
                binaryWriter.Write(BitConverter.GetBytes((Int32)oldLine.Length)); // Sending length of the table with 4 bytes
                binaryWriter.Write(oldLine, 0, oldLine.Length);
                binaryWriter.Flush();

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

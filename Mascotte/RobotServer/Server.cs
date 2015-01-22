using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Net.Sockets;
using System.Net;
using System.Threading;
using RobotServer.GridMaker;

namespace RobotServer
{
    public class Server
    {
        GeneralMap _generalMap;
        TcpListener listener;
        string path;

        public Server()
        {
            _generalMap = new GeneralMap();
            path = @"D:\INTECH\Mascotte_Netduino\Mascotte\Mascotte\toto.dat";

            // Server IP
            byte[] localIP = new byte[4];
            localIP = LocalIPAddress();

            // Listener
            listener = new TcpListener(new IPAddress(localIP), 3000);
            listener.Start();
            CallInitialization();
        }

        public GeneralMap GeneralMap
        {
            get { return _generalMap; }
            set { _generalMap = value; }
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
        public bool IsClientConnected()
        {
            if (listener.Server.Connected)
                return true;
            else
                return false;
        }
        public void Close()
        {
            listener.Stop();
        }

        // Connect Async
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
                    TcpClient client = await listener.AcceptTcpClientAsync();
                    Console.WriteLine("Client connected!");
                    //Socket soc = await listener.AcceptSocketAsync();

                    CallReadAsync(client);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        // Read Async
        private async void CallReadAsync(TcpClient client)
        {
            await InitializationReadAsync(client);
        }
        private Task InitializationReadAsync(TcpClient client)
        {
            return Task.Run(() => Read(client));
        }
        private async Task Read(TcpClient client)
        {
            int i = 0;
            try
            {
                while (true)
                {
                    Console.WriteLine("Read: " + i.ToString());
                    // Get stream
                    NetworkStream s = client.GetStream();
                    //Stream s = new NetworkStream(soc);

                    // Create binaries writer et reader
                    BinaryReader binaryReader = new BinaryReader(s);
                    BinaryWriter binaryWriter = new BinaryWriter(s);

                    switch (binaryReader.ReadString())
                    {
                        case "MOVE":
                            {
                                GetGridAndMove(binaryReader, binaryWriter);
                                binaryWriter.Write(true);
                                break;
                            }
                        case "MAP":
                            {
                                GeneralMap.Minimap.DatasInMiniMap = SyncMap(binaryReader);
                                _generalMap.Synchronize();
                                binaryWriter.Write(true);
                                break;
                            }
                        default:
                            break;
                    }
                    i++;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // Movement
        private void GetGridAndMove(BinaryReader br, BinaryWriter bw)
        {
            try
            {
                while (true)
                {
                    //NetworkStream s = new NetworkStream(soc);
                    //BinaryReader br = new BinaryReader(s);
                    //BinaryWriter bw = new BinaryWriter(s);
                    Console.WriteLine(@"Some works to do");

                    // Get positions and direction int on byte array
                    // Direction | PosX | PosY |
                    byte[] informations = br.ReadBytes(3); // read position with direction of movement

                    // Get length first
                    byte[] lineLen;
                    lineLen = br.ReadBytes(4);
                    int dataLen = BitConverter.ToInt32(lineLen, 0);

                    // Get datas
                    byte[] readMsgData = new byte[dataLen];
                    readMsgData = br.ReadBytes(dataLen);
                    if (readMsgData != null)
                    {
                        bw.Write(true);
                        _generalMap.MoveGrid(informations[0], readMsgData);
                        break;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        // Map
        private byte[][] SyncMap(BinaryReader br)
        {
            byte[] tableLen;
            tableLen = br.ReadBytes(4);
            int dataLen = BitConverter.ToInt32(tableLen, 0);
            byte[][] tmpMap = new byte[dataLen][];
            for (int i = 0; i < dataLen; i++)
            {
                byte[] lineLen = br.ReadBytes(4);
                int _dataLen = BitConverter.ToInt32(lineLen, 0);
                tmpMap[i] = new byte[_dataLen];
                tmpMap[i] = br.ReadBytes(_dataLen);
            }
            return tmpMap;
        }
        public void Serialize()
        {
            FileStream file;
            if (!(File.Exists(path)))
            {
                file = File.Create(path);
            }
            else
            {
                file = File.Open(path, FileMode.Open);
            }
            var formatter = new BinaryFormatter();
            formatter.Serialize(file, _generalMap);
            file.Close();
        }
        public void Deserialize()
        {
            FileStream file;
            if (!(File.Exists(path)))
            {
                throw new NullReferenceException("Le fichier n'a pas été trouvé par le programme");
            }
            else
            {
                file = File.OpenRead(path);
                var formatter = new BinaryFormatter();
                _generalMap = (GeneralMap)formatter.Deserialize(file);
            }
        }
    }
}

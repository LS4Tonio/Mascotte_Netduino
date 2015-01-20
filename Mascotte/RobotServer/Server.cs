﻿using System;
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

            byte[] localIP = new byte[4];
            localIP = LocalIPAddress();

            listener = new TcpListener(new IPAddress(localIP), 3000);
            listener.Start();
            CallInitialization();
        }

        public GeneralMap GeneralMap
        {
            get { return _generalMap; }
            set { _generalMap = value; }
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
        private async void CallInitialization()
        {
             await InitializationAsync();
        }
        private Task InitializationAsync()
        {
            return Task.Run(() => InitializeConnection());
        }
        public void InitializeConnection()
        {
            while (true)
            {
                try
                {
                    soc = listener.AcceptSocket();
                    s = new NetworkStream(soc);
                    _binaryReader = new BinaryReader(s);
                    _binaryWriter = new BinaryWriter(s);
                    string order;
                    order = _binaryReader.ReadString();
                    switch (order)
                    {
                        case "MOVE":
                            GetGridAndMove(soc);
                            _binaryWriter.Write(true);
                            break;
                        case "MAP":
                            GeneralMap.Minimap.DatasInMiniMap = SyncMap();
                            _generalMap.Synchronize();
                            _binaryWriter.Write(true);
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                finally
                {
                    _binaryReader.Close();
                    s.Close();
                    soc.Close();
                }
        }
        public byte[][] SyncMap(BinaryReader br)
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
        public void GetGridAndMove(Socket soc)
        {
            try
            {
                Stream s = new NetworkStream(soc);
                BinaryReader br = new BinaryReader(s);
                BinaryWriter bw = new BinaryWriter(s);
                Console.WriteLine(@"Some works to do");
                while (true)
                {
                    //GET POSITIONs AND DIRECTION IN ONE BYTE ARRAY
                    // DIRECTION | POSX | POSY |
                    byte[] informations = br.ReadBytes(3); // read position with direction of movement

                    // GET LENGTH FIRST
                    byte[] lineLen;
                    lineLen = br.ReadBytes(4);
                    int dataLen = BitConverter.ToInt32(lineLen, 0);

                    // GET CONTENT
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
        public void Close()
        {
            listener.Stop();
        }
    }
}

using Mascotte.GridMaker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Mascotte
{
    public class Server
    {
        GeneralMap _generalMap;
        string path;

        public Server()
        {
            _generalMap = new GeneralMap();
            //path = @"D:\INTECH\Mascotte_Netduino\Mascotte\Mascotte\toto.dat";
            path = @"D:\LS4Tonio\IN'TECH_INFO\PI\Mascotte_Netduino\Mascotte\Mascotte\toto.dat"; // Pour le PC d'Antoine
        }
        public GeneralMap GeneralMap
        {
            get { return _generalMap; }
            set { _generalMap = value; }
        }
        public void Serialize()
        {
            //XmlSerializer serializer = new XmlSerializer(typeof(GeneralMap));
            //TextWriter tw = File.CreateText(@"D:\INTECH\Mascotte_Netduino\Mascotte\Mascotte\toto.txt");
            //serializer.Serialize(tw, _generalMap);
            //tw.Close(); 
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
            //XmlSerializer serializer = new XmlSerializer(typeof(GeneralMap));
            //TextReader tr = new StreamReader(@"D:\INTECH\Mascotte_Netduino\Mascotte\Mascotte\toto.txt");
            //_generalMap = (GeneralMap)serializer.Deserialize(tr);
            //tr.Close();
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

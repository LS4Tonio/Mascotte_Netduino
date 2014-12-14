using Mascotte.GridMaker;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Mascotte
{
    public class Server
    {
        XmlSerializer serializer = new XmlSerializer(typeof(GeneralMap));
        GeneralMap _generalMap;
        string xml;

        public Server()
        {
            _generalMap = new GeneralMap();
        }
        public GeneralMap GeneralMap
        {
            get { return _generalMap; }
            set { _generalMap = value; }
        }
        public void Serialize()
        {
            //using (StreamWriter streamWriter = File.CreateText(@"D:\INTECH\Mascotte_Netduino\Mascotte\Mascotte\toto.txt"))
            //{
                _generalMap = new GeneralMap();
            //    serializer.Serialize(streamWriter, _generalMap);
            //    xml = streamWriter.ToString();
            //}


            XmlSerializer serializer = new XmlSerializer(typeof(GeneralMap));
            StreamWriter streamWriter = File.CreateText(@"D:\INTECH\Mascotte_Netduino\Mascotte\Mascotte\toto.txt");
            TextWriter tw = streamWriter;
            serializer.Serialize(tw, _generalMap);
            tw.Close(); 
        }
        public void Deserialize()
        {
            //using (StringReader _stringReader = new StringReader(xml))
            //{
            //    _generalMap = (GeneralMap)serializer.Deserialize(_stringReader);
            //}
            XmlSerializer serializer = new XmlSerializer(typeof(GeneralMap));
            TextReader tr = new StreamReader(@"D:\INTECH\Mascotte_Netduino\Mascotte\Mascotte\toto.txt");
            //Book b = (Book)serializer.Deserialize(tr);
            _generalMap = (GeneralMap)serializer.Deserialize(tr);
            tr.Close(); 
        }


    }
}

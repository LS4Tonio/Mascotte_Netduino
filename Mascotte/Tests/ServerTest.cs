using Mascotte;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class ServerTest
    {
        [Test]
        public void SerializerTest()
        {
            Server s = new Server();
            for (int i = 0; i < s.GeneralMap.GridContent.Length; i++)
            {
                for (int j = 0; j < s.GeneralMap.GridContent[i].Length; j++)
                {
                    s.GeneralMap.GridContent[i][j] = 1;
                }
            }
            s.Serialize();
            s = new Server();
            s.Deserialize();
            for (int i = 0; i < s.GeneralMap.GridContent.Length; i++)
            {
                System.Console.WriteLine(s.GeneralMap.GridContent.ToString());
                for (int j = 0; j < s.GeneralMap.GridContent[i].Length; j++)
                {
                    Assert.AreEqual((int)s.GeneralMap.GridContent[i][j], 1);
                }
            }
        }
    }
}

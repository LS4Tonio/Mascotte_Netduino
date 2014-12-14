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
            for (int i = 0; i < s.GeneralMap.GridContent.Length; i++)
            {
                for (int j = 0; j < s.GeneralMap.GridContent[i].Length; j++)
                {
                    s.GeneralMap.GridContent[i][j] = 0;
                }
            }
            s = new Server();
            s.Deserialize();
            for (int i = 0; i < s.GeneralMap.GridContent.Length; i++)
            {
                for (int j = 0; j < s.GeneralMap.GridContent[i].Length; j++)
                {
                   // Assert.Equals((int)s.GeneralMap.GridContent[i][j], 1);
                }
            }
        }
    }
}

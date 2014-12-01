using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Mascotte;

namespace Tests
{

    [TestFixture]
    public class Class1
    {

        [Test]
        public void testMoveGrid()
        {
            byte[][] _datas = new byte[8][];
            byte[][] _parentdatas = new byte[16][];
            MiniGrid mg = new MiniGrid(_datas, _parentdatas);
            mg.MapPosX = 1;
            mg.MapPosY = 2;
            byte[] results = new byte[8];
            results = mg.MoveGrid(1);
            for (int i = 0; i < results.Length; i++)
            {
                Assert.Null(results[i]);
            }
        }
    }
}

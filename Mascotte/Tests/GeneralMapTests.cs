using Mascotte;
using Mascotte.GridMaker;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    public class GeneralMapTests
    {
        [Test]
        public void synchronizeTest()
        {
            GeneralMap gm = new GeneralMap();

            addDatasInMinimap(gm.Minimap);

            for(int i=0; i<8; i++)
            {
                for(int j=0; j<8; j++)
                {
                    Assert.AreEqual(gm.GridContent[i][j], 0, "BeforeTest");
                }
            }

            gm.Synchronize();

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                            Assert.AreEqual(gm.GridContent[i][j], 0, "i && j pair");
                        else
                            Assert.AreEqual(gm.GridContent[i][j], 63, "i pair && j impair");
                    }
                    else
                    {
                        if (j % 2 == 0)
                            Assert.AreEqual(gm.GridContent[i][j], 127, "i impair && j pair");
                        else
                            Assert.AreEqual(gm.GridContent[i][j], 255, "i && j impair");
                    }
                }
            }
        }

        public void addDatasInMinimap(MiniGrid grid)
        {
            for (int i = 0; i < grid.DatasInMiniMap.Length; i++)
            {
                for (int j = 0; j < grid.DatasInMiniMap[i].Length; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                            grid.DatasInMiniMap[i][j] = 0;
                        else
                            grid.DatasInMiniMap[i][j] = 63;
                    }
                    else
                    {
                        if (j % 2 == 0)
                            grid.DatasInMiniMap[i][j] = 127;
                        else
                            grid.DatasInMiniMap[i][j] = 255;
                    }
                }
            }
        }
    }
}

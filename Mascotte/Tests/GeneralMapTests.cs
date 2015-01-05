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
        public void SynchronizeTest()
        {
            GeneralMap gm = new GeneralMap();

            addDatasInMinimap(gm.Minimap);

            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    Assert.AreEqual(gm.GridContent[i][j], 0, "BeforeTest");
                }
            }
            for (int i = 0; i < gm.GridContent.Length; i++)
            {
                for (int j = 0; j < gm.GridContent[i].Length; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                            gm.GridContent[i][j] = 0;
                        else
                            gm.GridContent[i][j] = 63;
                    }
                    else
                    {
                        if (j % 2 == 0)
                            gm.GridContent[i][j] = 127;
                        else
                            gm.GridContent[i][j] = 255;
                    }
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
                            Assert.AreEqual(gm.GridContent[i][j], 1, "i && j pair");
                        else
                            Assert.AreEqual(gm.GridContent[i][j], 62, "i pair && j impair");
                    }
                    else
                    {
                        if (j % 2 == 0)
                            Assert.AreEqual(gm.GridContent[i][j], 126, "i impair && j pair");
                        else
                            Assert.AreEqual(gm.GridContent[i][j], 127, "i && j impair");
                    }
                }
            }
        }

        public void addDatasInMinimap(MiniGrid grid)
        {

            for (int i = 0; i < grid.DatasInMiniMap.Length; i++)
            {
                for(int j = 0; j < grid.DatasInMiniMap[i].Length; j++)
                {
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                            grid.DatasInMiniMap[i][j] = 1;
                        else
                            grid.DatasInMiniMap[i][j] = 0;
                    }
                    else
                        grid.DatasInMiniMap[i][j] = 0;

                }
            }
        }

        public void addDatasInGrid(byte[][] grid)
        {
            for (int i = 2; i < 5; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (i == 2 && j < 10)
                    {
                        grid[i][j] = 63;
                    }
                    else if (i == 3 && j < 10)
                    {
                        grid[i][j] = 127;
                    }
                    else if (i == 4 && j < 10)
                    {
                        grid[i][j] = 63;
                    }
                }
            }
        }
    }
}

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
    public class MiniGridTests
    {
        [Test]
        public void isNotNull()
        {
            byte[] results = new byte[8];
            byte[][] datas = new byte[8][];
            initByteArray(datas);
            byte[][] parent = new byte[16][];
            initByteArray(parent);
            MiniGrid mg = new MiniGrid(datas, parent);

            // Test if mg & results exists
            Assert.IsNotNull(mg, "Minigrid is null");
            Assert.IsNotNull(results, "Results is null");

            // Get one data
            Assert.IsNotNull(mg.DatasInMiniMap[0][0], "Datas[0][0] is null");
        }

        [Test]
        public void moveGridUp()
        {
            byte[] results = new byte[8];
            byte[][] datas = new byte[8][];
            initByteArray(datas);
            byte[][] parent = new byte[16][];
            initByteArray(parent);
            MiniGrid mg = new MiniGrid(datas, parent);

            // Fill parent grid with some datas
            fillParent(parent);

            // Fill grid with some datas
            fillMiniGrid(mg.DatasInMiniMap);

            // Set parent's positions
            mg.MapPosX = 0;
            mg.MapPosY = 1;

            // Move grid up
            mg.MoveGrid(1);

            // Test if parent's datas are on the 1st line of the minigrid
            Assert.AreEqual(mg.DatasInMiniMap[0][0], 0, "mg 0-0 != 0");
            Assert.AreEqual(mg.DatasInMiniMap[0][1], 255, "mg 0-1 != 255");
            Assert.AreEqual(mg.DatasInMiniMap[0][2], 0, "mg 0-2 != 0");
            Assert.AreEqual(mg.DatasInMiniMap[7][0], 255, "mg 7-0 != 255");
            Assert.AreEqual(mg.DatasInMiniMap[7][1], 0, "mg 7-1 != 0");
            Assert.AreEqual(mg.DatasInMiniMap[7][2], 255, "mg 7-2 != 255");
        }

        [Test]
        public void moveGridDown()
        {
            byte[] results = new byte[8];
            byte[][] datas = new byte[8][];
            initByteArray(datas);
            byte[][] parent = new byte[16][];
            initByteArray(parent);
            MiniGrid mg = new MiniGrid(datas, parent);

            // Fill parent grid with some datas
            fillParent(parent);

            // Fill grid with some datas
            fillMiniGrid(mg.DatasInMiniMap);

            // Set parent's map positions
            mg.MapPosX = 0;
            mg.MapPosY = 0;

            // Move grid down
            mg.MoveGrid(2);

            // Test if parent's datas are on the 1st line of the minigrid
            Assert.AreEqual(mg.DatasInMiniMap[0][0], 255, "mg 0-0 != 255");
            Assert.AreEqual(mg.DatasInMiniMap[0][1], 0, "mg 0-1 != 0");
            Assert.AreEqual(mg.DatasInMiniMap[0][2], 255, "mg 0-1 != 255");
            Assert.AreEqual(mg.DatasInMiniMap[7][0], 0, "mg 7-0 != 0");
            Assert.AreEqual(mg.DatasInMiniMap[7][1], 255, "mg 7-1 != 0");
            Assert.AreEqual(mg.DatasInMiniMap[7][2], 0, "mg 7-2 != 0");
        }

        [Test]
        public void moveGridLeft()
        {
            byte[] results = new byte[8];
            byte[][] datas = new byte[8][];
            initByteArray(datas);
            byte[][] parent = new byte[16][];
            initByteArray(parent);
            MiniGrid mg = new MiniGrid(datas, parent);

            // Fill parent grid with some datas
            fillParent(parent);

            // Fill grid with some datas
            fillMiniGrid(mg.DatasInMiniMap);

            // Set parent's map positions
            mg.MapPosX = 1;
            mg.MapPosY = 0;

            // Move grid left
            mg.MoveGrid(3);

            // Test if parent's datas are on the 1st line of the minigrid
            Assert.AreEqual(mg.DatasInMiniMap[0][0], 0, "mg 0-0 != 0");
            Assert.AreEqual(mg.DatasInMiniMap[1][0], 0, "mg 1-0 != 0");
            Assert.AreEqual(mg.DatasInMiniMap[2][0], 0, "mg 2-0 != 0");

            Assert.AreEqual(mg.DatasInMiniMap[0][7], 255, "mg 0-7 != 255");
            Assert.AreEqual(mg.DatasInMiniMap[1][7], 255, "mg 1-7 != 255");
            Assert.AreEqual(mg.DatasInMiniMap[2][7], 255, "mg 2-7 != 255");
        }

        [Test]
        public void moveGridRight()
        {
            byte[] results = new byte[8];
            byte[][] datas = new byte[8][];
            initByteArray(datas);
            byte[][] parent = new byte[16][];
            initByteArray(parent);
            MiniGrid mg = new MiniGrid(datas, parent);

            // Fill parent grid with some datas
            fillParent(parent);

            // Fill grid with some datas
            fillMiniGrid(mg.DatasInMiniMap);

            // Set parent's map positions
            mg.MapPosX = 0;
            mg.MapPosY = 0;

            // Move grid right
            mg.MoveGrid(4);

            // Test if parent's datas are on the 1st line of the minigrid
            Assert.AreEqual(mg.DatasInMiniMap[0][0], 0, "mg 0-0 != 0");
            Assert.AreEqual(mg.DatasInMiniMap[1][0], 0, "mg 1-0 != 0");
            Assert.AreEqual(mg.DatasInMiniMap[2][0], 0, "mg 2-0 != 0");

            Assert.AreEqual(mg.DatasInMiniMap[0][7], 0, "mg 0-7 != 0");
            Assert.AreEqual(mg.DatasInMiniMap[1][7], 0, "mg 1-7 != 0");
            Assert.AreEqual(mg.DatasInMiniMap[2][7], 0, "mg 2-7 != 0");
        }


        public void initByteArray(byte[][] b)
        {
            var length = b.Length;

            for (int i = 0; i < length; i++)
            {
                b[i] = new byte[length];

                for (int j = 0; j < b[i].Length; j++)
                {
                    b[i][j] = 0;
                }
            }
        }

        // Functions for Up tests
        public void fillParent(byte[][] p)
        {
            for (int i = 0; i < p.Length; i++)
            {
                for (int j = 0; j < p[i].Length; j++)
                {
                    if (j % 2 == 0)
                    {
                        p[i][j] = 0;
                    }
                    else
                    {
                        p[i][j] = 255;
                    }
                }
            }
        }
        public void fillMiniGrid(byte[][] g)
        {
            for (int i = 0; i < g.Length; i++)
            {
                for (int j = 0; j < g[i].Length; j++)
                {
                    if (j % 2 == 0)
                    {
                        g[i][j] = 255;
                    }
                    else
                    {
                        g[i][j] = 0;
                    }
                }
            }
        }
    }
}

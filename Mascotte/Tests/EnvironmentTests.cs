using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tests
{
    public class EnvironmentTests
    {
        string bitmapPath = @"D:\LS4Tonio\Pictures\Mascotte\OpenSpace.bmp";

        [Test]
        public void IsExists()
        {
            RobotMock.Environment e = new RobotMock.Environment(bitmapPath, 0.25, 1, 1, 90);
            Assert.NotNull(e);
        }
        [Test]
        public void CheckObstacle()
        {
            RobotMock.Environment e = new RobotMock.Environment(bitmapPath, 0.25, 1, 1, 180);
            double x = 50;
            double y = 50;
            Assert.IsTrue(e.ObstacleInFront(out x, out y));
            double dist = 1;
            Assert.IsTrue(e.ObstacleDistance(out dist));
            Assert.AreNotEqual(dist, 1);
            Assert.AreEqual(dist, 0.3120503994485494d); //0.3120503994485494d
        }
    }
}
using System;
using Microsoft.SPOT;
using RobotControl;

namespace NetduinoApplication5
{
    class Algorythms
    {
        double _angleOfRobot;
        private const int DELTA = 15;
        public void CalibrateRobot(RangeSensor captor)
        {
            double dist1;
            double dist2;

            dist1 = captor.Read();
            Rover rover = new Rover();
            rover.Move();// TODO : Add distance 
            dist2 = captor.Read();
            _angleOfRobot = System.Math.Atan((dist1 - dist2) / 15);

            if (_angleOfRobot < 0 && captor.Name == "Left")
                rover.Turn(); // TODO : Add -angle
            else if (_angleOfRobot < 0 && captor.Name == "Right")
                rover.Turn(); // TODO : Add angle
            else if (_angleOfRobot > 0 && captor.Name == "Left")
                rover.Turn(); // TODO : Add angle
            else if (_angleOfRobot > 0 && captor.Name == "Right")
                rover.Turn(); // TODO : Add -angle
        }

        public bool IsObjectHere(RangeSensor captor)
        {
            if (captor.Read().Equals(null))
                return false;
            else
                return true;
        }

        /// <summary>
        /// Get the position of one point and make advance the robot while the object is not ended.
        /// The consecutives points are registered in a bidimentionnal table of int.
        /// </summary>
        /// <param name="captor"></param>
        /// <param name="rover"></param>
        /// <returns>Bidimensionnal table of int containing location information</returns>
        public int[][] getPositionsForObject(RangeSensor captor, Rover rover)
        {
            int hypotenuse;
            int[][] objectPos = new int[0][];
            int[][] tmp;
            int i = 0;
            while (IsObjectHere(captor))
            {
                tmp = objectPos;
                rover.Move(); // TODO : Add distance 
                hypotenuse = captor.Read();
                int adjacent = (int)(rover.AngleOfRobot * System.Math.Acos(hypotenuse));
                int opposite = (int)(rover.AngleOfRobot * System.Math.Asin(hypotenuse));
                i++;
                objectPos = new int[i][];
                tmp.CopyTo(objectPos, 0);
                objectPos[i - 1] = new int[2] { adjacent, opposite };
            }
            return objectPos;
        }
    }
}

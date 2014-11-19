using System;
using Microsoft.SPOT;

namespace NetduinoApplication5
{
    class Algorythms
    {
        RobotTools robotTools;
        Cartographia cartographia;
        bool _obstacleInRange;
        public void CalibrateRobot(Captor captor)
        {
            double dist1;
            double dist2;
           
            dist1 = robotTools.getDistance(captor);
            robotTools.goStraight(15);
            dist2 = robotTools.getDistance(captor);
            double angle = System.Math.Atan((dist1 - dist2) / 15);

            if (angle < 0 && captor.Name == "captG")
                robotTools.rotate(-angle);
            else if (angle < 0 && captor.Name == "captD")
                robotTools.rotate(angle);
            else if (angle > 0 && captor.Name == "captG")
                robotTools.rotate(angle);
            else if (angle > 0 && captor.Name == "captD")
                robotTools.rotate(-angle);
        }

        public void GetDataForObject(Captor captor)
        {
            bool _isObjectEnded = false;
            while(_isObjectEnded == false)
            {
                cartographia.AddNewPoint(_posX, _posY);
                robotTools.goStraight(15);
                if (robotTools.GetDistance(captor) == null)
                    _isObjectEnded = true;
            }
            VectorializeMiniMap();
        }

    }
}

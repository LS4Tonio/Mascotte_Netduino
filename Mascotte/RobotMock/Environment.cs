using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;

//frankly eurgh non tested, sucks.
//the idea was to use a bitmap.
//black here is when the color IS BLACK or OUT OF RANGE OF BITMAP. BLACK = OBSTACLE (no % chances here)

//TODO:
//a position. absolute. => plug onto the movements of the rover.
//sensors should refer to this.
//take care of speed meaning time. meaning refreshing position.
//a system to send this kind of message : the robot bangued the wall !


//SensorMaxRange well it can be taken out. I was just thinking there was no point calculating further than needed
namespace RobotMock
{
    public class Environment
    {
        EnvironmentMap _envMap;
        double _posX;
        double _posY;
        double _angle;
        double _speed;
        double _pixelRealDistanceRatio;

        public Double PosX { get { return _posX; } set { _posX = value; } }
        public Double PosY { get { return _posY; } set { _posY = value; } }
        public Double Angle { get { return _angle; } set { _angle = value; } }

        public Environment(string bitmapPath, double pixelRealDistanceRatio, double startPositionX, double startPositionY, double startAngle)
        {
            _envMap = new EnvironmentMap();
            _envMap.Initialize(bitmapPath);
            _posX = startPositionX;
            _posY = startPositionY;
            _angle = startAngle;
            _speed = 0;
            _pixelRealDistanceRatio = pixelRealDistanceRatio;
            SensorMaxRange = 100;//valeur au pif
        }

        /// <summary>
        /// eum just so that it does not go for almost forever. not real distance as it will just check x and y
        /// just make sure this is bigger than your sensor range.
        /// </summary>
        public double SensorMaxRange { get; set; }
        public double Speed { get; set; }
        public EnvironmentMap Environment
        {
            get { return _envMap; }
        }

        public bool IsPixelBlack(int x, int y)
        {

            if( x > (_envMap.Width-1) || y > (_envMap.Height-1) )
                return true;
            
            Color color = _envMap.GetPixel(x, y);
            if (color == Color.Black)
                return true;
            else
                return false;
        }
        //out of range is considered an obstacle.
        public bool ObstacleInFront(out double x, out double y, double angle2)
        {
            //calculate which grid squares are in front
            //y=_angle *x+ b 
            //double b =_posY - _angle * _posX; //or not.
            // anyhow calculate x&y for each x+1 and each y+1. stop when an obstacle is found. 
            //get the closest between each of them.

            double a1 = 0;
            double b1 = 0;
            double a2 = 0;
            double b2 = 0;
            double angle = angle2 % 2 * Math.PI;
            bool wayX = true;
            bool wayY = true;
            if (angle > Math.PI)
            {
                wayY = false;
                angle = angle - Math.PI;
            }
            if (angle < Math.PI / 2)
            {
                a1 = Math.Tan(angle);
                if (!wayY)
                    wayX = false;
            }
            else if (angle < Math.PI)
            {
                a1 = -Math.Tan(angle);
                if (wayY)
                    wayX = false;
            }

            b1 = _posY - a1 * _posX;
            if (a1 != 0)
                a2 = 1 / a1;
            b2 = _posX - a2 * _posY;
            //x= a2y + b2
            //y= a1x + b1
            double tmpPosX1 = _posX;
            double tmpPosY1 = _posY;
            double distanceSquare1 = -1;
            bool isPoint1Black = false;
            double tmpPosX2 = _posX;
            double tmpPosY2 = _posY;
            double distanceSquare2 = -1;
            bool isPoint2Black = false;

            while (!isPoint1Black && tmpPosX1 < SensorMaxRange)
            {
                if (wayX)
                    tmpPosX1 += _pixelRealDistanceRatio;
                else
                    tmpPosX1 -= _pixelRealDistanceRatio;
                //y=a1x+b1 
                tmpPosY1 = a1 * tmpPosX1 + b1;
                //check grid.
                isPoint1Black = IsPixelBlack((int)Math.Truncate(tmpPosX1 / _pixelRealDistanceRatio), (int)Math.Truncate(tmpPosY1 / _pixelRealDistanceRatio));
            }
            while (!isPoint2Black && tmpPosY2 < SensorMaxRange)
            {
                if (wayY)
                    tmpPosY2 += _pixelRealDistanceRatio;
                else
                    tmpPosY2 -= _pixelRealDistanceRatio;
                //x=a2x + b2
                tmpPosX2 = a2 * tmpPosY2 + b2;
                //check grid.
                isPoint2Black = IsPixelBlack((int)Math.Truncate(tmpPosX1 / _pixelRealDistanceRatio), (int)Math.Truncate(tmpPosY1 / _pixelRealDistanceRatio));
            }
            if (isPoint2Black && isPoint1Black)
            {
                distanceSquare1 = (tmpPosX1 - _posX) * (tmpPosX1 - _posX) + (tmpPosY1 - _posY) * (tmpPosY1 - _posY);
                distanceSquare2 = (tmpPosX2 - _posX) * (tmpPosX2 - _posX) + (tmpPosY2 - _posY) * (tmpPosY2 - _posY);
                if (distanceSquare1 < distanceSquare2)
                {
                    x = tmpPosX1;
                    y = tmpPosY1;
                }
                else
                {
                    x = tmpPosX2;
                    y = tmpPosY2;
                }
            }
            else if (isPoint1Black)
            {
                x = tmpPosX1;
                y = tmpPosX2;
            }
            else if (isPoint2Black)
            {
                x = tmpPosX2;
                y = tmpPosY2;
            }
            else
            {
                x = 0;
                y = 0;
            }

            return isPoint1Black || isPoint2Black;

        }
     
        public bool ObstacleDistance(double sensorAngle, out double dist)
        {
            double x = 0;
            double y = 0;
            bool Is = ObstacleInFront(out x, out y, _angle+sensorAngle);
            dist = 0;
            if (!Is)
                return false;

            dist = Math.Sqrt((x - _posX) * (x - _posX) + (y - _posY) * (y - _posY));
            return true;
        }


        /// <summary>
        /// ONLY USE WHEN RATIO=1. directly takes bitmap coordinate values
        /// </summary>
        /// <param name="sensorAngle"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="dist"></param>
        /// <returns></returns>
        public bool Allinfo(double sensorAngle, out int x, out int y, out double dist)
        {
            double x2 = 0;
            double y2 = 0;
            bool Is = ObstacleInFront( out x2, out y2, _angle + sensorAngle );
            x = (int) x2;
            y = (int) y2;
            dist = 0;
            if( !Is )
                return false;

            dist = Math.Sqrt( (x2 - _posX) * (x2 - _posX) + (y2 - _posY) * (y2 - _posY) );
            return true;
        }
    }
}

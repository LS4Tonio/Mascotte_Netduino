using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMock
{
    public class InfraredSensor
    {
        private char _sensorPosition;
        const int MIN_DISTANCE = 10;
        const int MAX_DISTANCE = 80;
        const int WARNING_DISTANCE = 30;
        bool isObstacle;
        Environment _env;

        public InfraredSensor(char position, Environment env)
        {
            _sensorPosition = position;
            _env = env;
        }

        /// <summary>
        /// Gets distance between obstacle and sensor.
        /// </summary>
        public double DistanceDetected
        {
            get
            {
                double dist = 0;
                Read(out dist);
                return dist;
            }
        }
        /// <summary>
        /// ONLY USE WHEN RATIO = 1
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="dist"></param>
        /// <returns></returns>
        public bool DetectedPoint(out int x, out int y, out double dist)
        {
                double angle=0;
                double dist2=0;
                int x2;
                int y2;
                bool detected=false;
                if( _sensorPosition == 'L' )
                    angle=Math.PI / 2;
                if( _sensorPosition == 'R' )
                    angle= 3 * Math.PI / 2;
                detected=_env.Allinfo(angle, out x2, out y2, out dist2);
                x=x2; y=y2; dist=dist2;
                return detected;
        }
        /// <summary>
        /// Gets if an obstacle is detected.
        /// </summary>
        public bool IsObstacle
        {
            get
            {
                double dist = 0;
                return Read(out dist); 
            }
        }
        /// <summary>
        /// Gets position of the sensor.
        /// L = left side, R = right side, F = front side.
        /// </summary>
        public char Position
        {
            get { return _sensorPosition; }
        }

        /// <summary>
        /// Read distance between sensor and obstacle.
        /// If distance to obstacle < MIN_DISTANCE returns MIN_DISTANCE
        /// If distance to obstalce > MAX_DISTANCE returns MAX_DISTANCE
        /// </summary>
        /// <returns></returns>
        private bool Read(out double distance)
        {
            double angle = 0;
            distance = 0;

            if (_sensorPosition == 'L')
                angle = Math.PI / 2;
            if (_sensorPosition == 'R')
                angle = 3 * Math.PI / 2;

            return _env.ObstacleDistance(angle, out distance);
        }
    }
}

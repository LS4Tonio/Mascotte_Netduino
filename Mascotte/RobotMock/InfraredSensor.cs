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
        private byte[][] obstacleMap;
        const int MIN_DISTANCE = 10;
        const int MAX_DISTANCE = 80;
        const int WARNING_DISTANCE = 30;

        public InfraredSensor(char position)
        {
            _sensorPosition = position;
            obstacleMap = CreateObstacleMap();
        }
        
        /// <summary>
        /// Gets distance between obstacle and sensor.
        /// </summary>
        public double DistanceDetected
        {
            get { return Read(); }
        }
        /// <summary>
        /// Gets if an obstacle is detected.
        /// </summary>
        public bool IsObstacle
        {
            get
            {
                if (Read() <= WARNING_DISTANCE)
                    return true;

                return false;
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
        public double Read()
        {
            return 0;
        }

        private byte[][] CreateObstacleMap()
        {
            int size = 100;
            byte[][] map = new byte[size][];
            for (int i = 0; i < size; i++)
                map[i] = new byte[size];

            // Fill map with obstacles
            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    // Map border
                    if (i == 0 || j == 0 || i == size - 1 || j == size - 1)
                        map[i][j] = 127;

                    // Add some walls
                    if (i >= 5 && i <= 10 && j >= 5 && i <= 10)
                        map[i][j] = 127;
                    if (i == 3 && j > 7 && j < 15)
                        map[i][j] = 127;
                    if (i == 9 && j > 15 && j < 23)
                        map[i][j] = 127;
                    if (i == 11 && j < 4)
                        map[i][j] = 127;
                    if (i == 16 && j > 15 && j < 28)
                        map[i][j] = 127;
                    if (i == 18 && j < 3)
                        map[i][j] = 127;
                    if (i == 19 && j > 2 && j < 8)
                        map[i][j] = 127;
                    if (i == 20 && j > 7 && j < 13)
                        map[i][j] = 127;
                    if (i == 21 && j > 12 && j < 18)
                        map[i][j] = 127;

                    if (j == 4 && i > 22 && i < 25)
                        map[i][j] = 127;
                    if (j == 5 && i == 25)
                        map[i][j] = 127;
                    if (j == 6 && i > 25 && i < 28)
                        map[i][j] = 127;
                    if (j == 8 && i == 24)
                        map[i][j] = 127;
                    if (j == 9 && i > 13 && i < 26)
                        map[i][j] = 127;
                    if (j == 10 && i == 22)
                        map[i][j] = 127;
                    if (j == 12 && i > 25 && i < 31)
                        map[i][j] = 127;
                    if (j == 14 && (i == 27 || i == 29))
                        map[i][j] = 127;
                    if (j == 16 && ((i > 6 && i < 12) || (i > 13 && i < 17)))
                        map[i][j] = 127;
                    if (j == 22 && (i < 3 || (i > 5 && i < 31)))
                        map[i][j] = 127;
                }
                
            }

            return map;
        }
    }
}

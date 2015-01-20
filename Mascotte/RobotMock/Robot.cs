using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RobotMock
{
    public class Robot
    {
        private Wifi _wifi;
        private Rover _rover;
        private InfraredSensor[] _infraredSensors;
        private Map _map;
        private Environment _env;

        public Robot(int xMapSize, int yMapSize, int xPos, int yPos, int angle)
        {
            //_env = new Environment(@"C:\dossier_git\Mascotte_Netduino\Mascotte\RobotApplication\bin\Debug\test.bmp", (double)1, (double)xPos, (double)yPos, (double)angle);
            _env = new Environment(@"../../Resources/OpenSpace.bmp", (double)1, (double)xPos, (double)yPos, (double)angle);
            _wifi = new Wifi();
            _rover = new Rover(_env);
            _infraredSensors = new InfraredSensor[3] { new InfraredSensor('F', _env), new InfraredSensor('L', _env), new InfraredSensor('R', _env) };
            _map = new Map(xMapSize, yMapSize, xPos, yPos, _env);
        }

        /// <summary>
        /// Gets wifi module.
        /// </summary>
        public Wifi Wifi
        {
            get { return _wifi; }
        }
        /// <summary>
        /// Gets robot chassis module.
        /// </summary>
        public Rover Rover
        {
            get { return _rover; }
        }
        /// <summary>
        /// Gets infrared sensors array.
        /// 0 = front, 1 = left, 2 = right.
        /// </summary>
        public InfraredSensor[] InfraredSensors
        {
            get { return _infraredSensors; }
        }
        /// <summary>
        /// Gets or sets robot minimap.
        /// </summary>
        public Map MiniMap
        {
            get { return _map; }
            set { _map = value; }
        }
        /// <summary>
        /// Gets environment map
        /// </summary>
        public Environment Environment
        {
            get { return _env; }
        }

        public void GetObstacle()
        {
            double robotDistance = 0;
            int size = 0;

            // Up / Down
            if ((Rover.Direction > 315 && Rover.Direction <= 360) || (Rover.Direction >= 0 && Rover.Direction < 45) || (Rover.Direction > 135 && Rover.Direction < 225))
            {
                robotDistance = MiniMap.ySize / 2;
                size = MiniMap.ySize;
            }
            // Left / Right
            if ((Rover.Direction > 315 && Rover.Direction <= 360) || (Rover.Direction >= 0 && Rover.Direction < 45) || (Rover.Direction > 135 && Rover.Direction < 225))
            {
                robotDistance = MiniMap.xSize / 2;
                size = MiniMap.xSize;
            }

            int x = 0;
            int y = 0;
            double dist = 0;
            if (InfraredSensors[0].DetectedPoint(out x, out y, out robotDistance) && dist < robotDistance)
            {
                MiniMap.AddObstacle(MiniMap.FindDirection(Rover.Direction) ,x, y);
            }
        }

        // TO DO: Programmable function for robot automatic movement
        public void Main()
        {
            // Start pos: (0, 0)

        }
    }
}

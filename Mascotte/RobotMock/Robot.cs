using System;
using System.Collections.Generic;
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

        public Robot(int xMapSize, int yMapSize)
        {
            _env = new Environment( @"C:\dossier_git\Mascotte_Netduino\Mascotte\RobotApplication\bin\Debug\test.bmp", (double)1, (double)0, (double)0, (double)0 );
            _wifi = new Wifi();
            _rover = new Rover(_env);
            _infraredSensors = new InfraredSensor[3] { new InfraredSensor('F', _env), new InfraredSensor('L', _env), new InfraredSensor('R', _env) };
            _map = new Map(xMapSize, yMapSize);
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

        public void Main()
        {
            // Start pos: (0, 0)

        }
    }
}

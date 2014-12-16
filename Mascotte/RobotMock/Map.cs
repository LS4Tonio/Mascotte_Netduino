using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotMock
{
    public class Map
    {
        byte[][] _map;

        public Map(int xSize, int ySize)
        {
            _map = new byte[xSize][];
            for (int i = 0; i < xSize; i++)
                _map[i] = new byte[ySize];
        }

        /// <summary>
        /// Gets or sets robot's map.
        /// </summary>
        public byte[][] MapArray
        {
            get { return _map; }
            set { _map = value; }
        }
    }
}

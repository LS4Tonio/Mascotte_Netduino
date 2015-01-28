using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RobotServer.GridMaker
{
    public class MiniGrid
    {
        byte[][] _datas;
        byte[][] _parentGrid;
        int _xPos;
        int _yPos;
        private const int TAB_SIZE = 9;

        public MiniGrid(byte[][] datas, byte[][] parentGrid)
        {
            _datas = datas;
            _parentGrid = parentGrid;
        }
        /// <summary>
        /// Getter & setter for the map calling the minimap
        /// </summary>
        public byte[][] ParentGridContent
        {
            get { return _parentGrid; }
            set { _parentGrid = value; }
        }
        /// <summary>
        /// Gets grid content
        /// </summary>
        public byte[][] DatasInMiniMap
        {
            get { return _datas; }
            set { _datas = value; }
        }
        public int MiniMapSize
        {
            get { return TAB_SIZE; }
        }
        /// <summary>
        /// Gets or sets X parent's map position.
        /// Can't be negative.
        /// </summary>
        public int MapPosX
        {
            get
            {
                return _xPos;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _xPos = value;
            }
        }
        /// <summary>
        /// Gets or sets Y parent's map position.
        /// Can't be negative.
        /// </summary>
        public int MapPosY
        {
            get
            {
                return _yPos;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException();
                }
                _yPos = value;
            }
        }
        /// <summary>
        /// Gets or sets map confidence indice
        /// TO DO LATER
        /// </summary>
        public byte MapConfidenceIndice { get; set; }

        /// <summary>
        /// Get direction and move the local gridMap for the robot.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        
        
    }
}

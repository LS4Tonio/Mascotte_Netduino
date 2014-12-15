using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mascotte
{
    public class MiniGrid
    {
        byte[][] _datas;
        byte[][] _parentGrid;
        int _xPos;
        int _yPos;
        private const int TAB_SIZE = 8;

        public MiniGrid(byte[][] datas, byte[][] parentGrid)
        {
            _datas = datas;
            _parentGrid = parentGrid;
        }

        /// <summary>
        /// Gets grid content
        /// </summary>
        public byte[][] DatasInMiniMap
        {
            get { return _datas; }
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
        public byte[] MoveGrid(int direction)
        {
            byte[] tmp = new byte[_datas[0].Length];
            switch (direction)
            {
                case 1:     // Up
                    if (MapPosY > 0)
                    {
                        MapPosY--;

                        // Save datas of the last line
                        tmp = _datas[_datas.Length - 1];

                        // Move datas
                        for (int i = _datas.Length - 1; i > 0; i--)
                        {
                            _datas[i] = _datas[i - 1];
                        }

                        // Get first line from parent
                        for (int i = 0; i < _datas[0].Length; i++)
                        {
                            _datas[0][i] = _parentGrid[MapPosY][MapPosX + i];
                        }
                    }
                    return _datas[0];

                case 2:     // Down
                    var length = _datas.Length - 1;

                    MapPosY++;

                    // Move datas
                    for (int i = 0; i < length; i++)
                    {
                        _datas[i] = _datas[i + 1];
                    }

                    // Get last line from parent
                    for (int i = 0; i < _datas[0].Length; i++)
                    {
                        _datas[length][i] = _parentGrid[MapPosY + length][i + MapPosX];
                    }
                    return _datas[length];

                case 3:     // Left
                    if (MapPosX > 0)
                    {
                        MapPosX--;

                        for (int i = 0; i < _datas.Length; i++)
                        {
                            // Move datas
                            for (int j = _datas[i].Length - 1; j > 1; j--)
                            {
                                _datas[i][j] = _datas[i][j - 1];
                            }

                            // Get first column from parent
                            _datas[i][0] = _parentGrid[MapPosY + i][MapPosX];

                            tmp[i] = _datas[i][0];
                        }
                    }
                    return tmp;

                case 4:     // Right
                    MapPosX++;

                    for (int i = 0; i < _datas.Length; i++)
                    {
                        // Move datas
                        for (int j = 0; j < _datas[i].Length - 1; j++)
                        {
                            _datas[i][j] = _datas[i][j + 1];
                        }

                        // Get last column from parent 
                        _datas[i][_datas[i].Length - 1] = _parentGrid[i][MapPosX + _datas[i].Length - 1];

                        tmp[i] = _datas[i][_datas[i].Length - 1];
                    }
                    return tmp;

                default:
                    throw new ArgumentException();
            }
        }
    }
}

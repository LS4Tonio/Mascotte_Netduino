using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace RobotMock
{
    public class Map : INotifyPropertyChanged
    {
        byte[][] _map;
        int _xPos;
        int _yPos;
        int _xSize;
        int _ySize;
        Environment env;
        public event PropertyChangedEventHandler PropertyChanged;

        public Map(int xSize, int ySize, int xPos, int yPos, Environment env)
        {
            this.env = env;
            this._xSize = xSize;
            this._ySize = ySize;
            _xPos = xPos;
            _yPos = yPos;
            _map = new byte[ySize][];
            for (int i = 0; i < xSize; i++)
                _map[i] = new byte[xSize];
            //FillMap();
        }

        // Properties
        /// <summary>
        /// Gets or sets robot's map.
        /// </summary>
        public byte[][] MapArray
        {
            get { return _map; }
            set { _map = value; }
        }
        /// <summary>
        /// Gets or sets map X position from the parent
        /// </summary>
        public int Xposition
        {
            get { return _xPos; }
            set { _xPos = value; }
        }
        /// <summary>
        /// Gets or sets map Y position from the parent
        /// </summary>
        public int Yposition
        {
            get { return _yPos; }
            set { _yPos = value; }
        }
        public int xSize
        {
            get { return _xSize; }
        }
        public int ySize
        {
            get { return _ySize; }
        }

        // Methods
        /// <summary>
        /// Move map in choosen direction.
        /// Only 4 possible directions: Up, Right, Down, Left.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public byte[][] MoveMap(int direction)
        {
            byte[] tmp = new byte[MapArray[0].Length];

            switch (direction)
            {
                case 1:     // Up
                    {
                        if (_xPos > 0)
                        {
                            var length = MapArray.Length - 1;

                            // Move datas
                            for (int i = length; i > 0; i--)
                            {
                                MapArray[i] = MapArray[i - 1];
                            }

                            // Add new empty line
                            MapArray[0] = new byte[length + 1];

                            // Move x position
                            _xPos--;

                            // Move this grid on env
                            env.PosX = _xPos;

                            RaisePropertyChanged("MapArray");
                        }
                        return MapArray;
                    }

                case 2:     // Down
                    {
                        if (_xPos < env.EnvironmentMap.Height - 1)
                        {
                            var length = MapArray.Length - 1;

                            // Move datas
                            for (int i = 0; i < length; i++)
                            {
                                MapArray[i] = MapArray[i + 1];
                            }

                            // Add new empty line
                            MapArray[length] = new byte[length + 1];

                            // Move x position
                            _xPos++;

                            // Move this grid on env
                            env.PosX = _xPos;

                            RaisePropertyChanged("MapArray");
                        }
                        return MapArray;
                    }

                case 3:     // Left
                    {
                        if (_yPos > 0)
                        {
                            for (int i = 0; i < MapArray.Length; i++)
                            {
                                // Move datas
                                for (int j = MapArray[i].Length - 1; j > 1; j--)
                                {
                                    MapArray[i][j] = MapArray[i][j - 1];
                                }

                                // Add empty column
                                MapArray[i][0] = 0;

                            }

                            // Move x position
                            _yPos--;

                            // Move this grid on env
                            env.PosY = _yPos;

                            RaisePropertyChanged("MapArray");
                        }
                        return MapArray;
                    }

                case 4:     // Right
                    {
                        if (_yPos < env.EnvironmentMap.Width - 1)
                        {
                            for (int i = 0; i < MapArray.Length; i++)
                            {
                                // Move datas
                                for (int j = 0; j < MapArray[i].Length - 1; j++)
                                {
                                    MapArray[i][j] = MapArray[i][j + 1];
                                }

                                // Add empty column
                                MapArray[i][MapArray[i].Length - 1] = 0;

                                tmp[i] = MapArray[i][MapArray[i].Length - 1];
                            }

                            // Move x position
                            _yPos++;

                            // Move this grid on env
                            env.PosY = _yPos;

                            RaisePropertyChanged("MapArray");
                        }
                        return MapArray;
                    }

                default:
                    throw new ArgumentException();
            }
        }
        /// <summary>
        /// Move map in choosen direction.
        /// Only 4 possible directions: Up, Right, Down, Left.
        /// </summary>
        /// <param name="direction"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public byte[][] AddObstacle(int direction, int x, int y)
        {
            switch (direction)
            {
                case 1: // Up
                    {
                        _map[0][4] = 255;
                        RaisePropertyChanged("MapArray");
                        return _map;
                    }
                case 2: // Down
                    {
                        _map[_map.Length - 1][4] = 255;
                        RaisePropertyChanged("MapArray");
                        return _map;
                    }
                case 3: // Left
                    {
                        _map[4][0] = 255;
                        RaisePropertyChanged("MapArray");
                        return _map;
                    }
                case 4: // Right
                    {
                        _map[4][_map[4].Length - 1] = 255;
                        RaisePropertyChanged("MapArray");
                        return _map;
                    }
                default:{
                        return _map;
                    }
            }
        }
        /// <summary>
        /// Return int for the direction with the given angle.
        /// Direction is between 1 and 4.
        /// Angle is between 0 and 360.
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public int FindDirection(int angle)
        {
            int direction = 0; // Must change, if not throw argumentexception

            // Up
            if ((angle >= 0 && angle < 45) || (angle > 315 && angle <= 360))
                direction = 1;
            // Down
            else if (angle > 135 && angle < 225)
                direction = 2;
            // Left
            else if (angle >= 225 && angle <= 315)
                direction = 3;
            // Right
            else if (angle >= 45 && angle <= 135)
                direction = 4;

            return direction;
        }
        /// <summary>
        /// Add some random datas in the byte array of array.
        /// </summary>
        private void FillMap()
        {
            Random r = new Random(12012015);
            for (int i = 0; i < _map.Length; i++)
            {
                for (int j = 0; j < _map[i].Length; j++)
                {
                    var nb = r.Next(0, 5);
                    if (nb > 3)
                        _map[i][j] = 255;
                }
            }
        }

        // Events
        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            var h = PropertyChanged;
            if (h != null) h(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
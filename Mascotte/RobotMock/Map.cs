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
    public enum directions
    {
        NONE = 0,
        TOP = 1,
        BOTTOM = 2,
        LEFT = 3,
        RIGHT = 4
    };
    public class Map : INotifyPropertyChanged
    {
        byte[][] _map;
        int _xPos;
        int _yPos;
        int _xSize;
        int _ySize;
        Environment env;
        public event PropertyChangedEventHandler PropertyChanged;

        public int XSize { get { return _xSize; } }
        public int YSize { get { return _ySize; } }
        public int XPos { get { return _xPos; } }
        public int YPos { get { return _yPos; } }

        public Map(int xSize, int ySize, int xPos, int yPos, Environment env)
        {
            this.env = env;
            this._xSize = xSize;
            this._ySize = ySize;
            _xPos = xPos;
            _yPos = yPos;
            _map = new byte[ySize][];
            for (int i = 0; i < ySize; i++)//xSize
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
        public byte[] MoveMap(/*int direction*/ directions direction)
        {
            switch (direction)
            {
                case directions.RIGHT:
                        byte[] oldLine = new byte[_ySize];
                        for( int i=0; i < _ySize; i++ )
                        {
                            oldLine[i] = MapArray[i][0];
                            for( int j=0; j < _xSize; j++ )
                            {
                                if( j > 0 )
                                    MapArray[i][j - 1] = MapArray[i][j];
                            }
                            MapArray[i][_xSize - 1] = 0;
                        }
                        _xPos++;
                        RaisePropertyChanged( "MapArray" );
                        return oldLine;
                case directions.LEFT://ERROR
                        byte[] oldLine2 = new byte[_ySize];
                        for( int i=0; i < _ySize; i++ )
                        {
                            oldLine2[i] = MapArray[i][_xSize - 1];
                            for( int j=_xSize-1; j >=0; j-- )
                            {
                                if( j >0 )
                                    MapArray[i][j] = MapArray[i][j-1];
                            }
                            MapArray[i][0] = 0;
                        }
                        _xPos--;
                        RaisePropertyChanged( "MapArray" );
                        return oldLine2;
                case directions.TOP://ERROR
                        byte[] oldLine3 = new byte[_xSize];
                        oldLine3 = MapArray[_ySize - 1];
                        for( int i=_ySize-1; i >=0; i-- )
                        {
                            if(i>0)
                                MapArray[i]=MapArray[i-1];
                        }
                        MapArray[0] = new byte[_xSize];
                        RaisePropertyChanged( "MapArray" );
                        _yPos++;
                        return oldLine3;
                case directions.BOTTOM:
                        byte[] oldLine4 = new byte[_xSize];
                        oldLine4 = MapArray[0];
                        for( int i=0; i <_ySize; i++ )
                        {
                            if( i > 0 )
                                MapArray[i-1] = MapArray[i];
                        }
                        MapArray[_ySize - 1] = new byte[_xSize];
                        RaisePropertyChanged( "MapArray" );
                        _yPos--;
                        return oldLine4;
                case directions.NONE:
                    return null;
                default:
                    return null;
                    /*




                case 1: // Up
                    {
                        int length = MapArray.Length - 1;
                        byte[] oldLine = new byte[MapArray[length].Length];

                        if (_xPos > 0)
                        {
                            // Save old line
                            oldLine = MapArray[length];
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
                            // Throw event
                            RaisePropertyChanged("MapArray");
                        }
                        return oldLine;
                    }
                case 2: // Down
                    {
                        int length = MapArray.Length - 1;
                        byte[] oldLine = new byte[MapArray[0].Length];
                        if (_xPos < env.EnvironmentMap.Height - 1)
                        {
                            // Save old line
                            oldLine = MapArray[0];
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
                            // Throw envent
                            RaisePropertyChanged("MapArray");
                        }
                        return oldLine;
                    }
                case 3: // Left
                    {
                        byte[] oldColumn = new byte[MapArray.Length];

                        if (_yPos > 0)
                        {
                            for (int i = 0; i < MapArray.Length; i++)
                            {
                                // Save old column
                                oldColumn[i] = MapArray[i][MapArray[i].Length - 1];
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
                            // Throw event
                            RaisePropertyChanged("MapArray");
                        }
                        return oldColumn;
                    }
                case 4: // Right
                    {
                        byte[] oldColumn = new byte[MapArray.Length];

                        if (_yPos < env.EnvironmentMap.Width - 1)
                        {
                            for (int i = 0; i < MapArray.Length; i++)
                            {
                                // Save old column
                                oldColumn[i] = MapArray[i][0];
                                // Move datas
                                for (int j = 0; j < MapArray[i].Length - 1; j++)
                                {
                                    MapArray[i][j] = MapArray[i][j + 1];
                                }
                                // Add empty column
                                MapArray[i][MapArray[i].Length - 1] = 0;
                            }
                            // Move x position
                            _yPos++;
                            // Move this grid on env
                            env.PosY = _yPos;
                            // Throw event
                            RaisePropertyChanged("MapArray");
                        }
                        return oldColumn;
                    }
                default:
                    throw new ArgumentException();*/
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
        public byte[][] AddObstacle(directions direction, int x, int y)
        {
            //be careful x and y are inverted....
            _map[ x - XPos+ _xSize/2][(_ySize-1) - (y - YPos + _ySize/2) /*-(_yPos-_ySize/2)*/] = 255;//NOT
            _map[_xSize / 2][_ySize/2] = 255;
            _map[2][2] = 255;
            RaisePropertyChanged( "MapArray" );
            return _map;

            /*switch (direction)
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
            }*/
        }
        /// <summary>
        /// Return int for the direction with the given angle.
        /// Direction is between 1 and 4.
        /// Angle is between 0 and 360.
        /// </summary>
        /// <param name="angle"></param>
        /// <returns></returns>
        public directions FindDirection(int angle)
        {
           // int direction = 0; // Must change, if not throw argumentexception
/*
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
                direction = 4;*/

            directions direction = directions.NONE;

            if( (angle >= 0 && angle < 45) || (angle > 315 && angle <= 360) )
                direction = directions.RIGHT;
            else if( angle > 135 && angle < 225 )
                direction = directions.LEFT;
            else if( angle >= 225 && angle <= 315 )
                direction = directions.BOTTOM;
            else if( angle >= 45 && angle <= 135 )
                direction = directions.TOP;

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
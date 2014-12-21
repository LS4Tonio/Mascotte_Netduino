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
//black here is when the color IS BLACK or OUT OF RANGE. BLACK = OBSTACLE (no % chances here)

//TODO:
//a position. absolute. => plug onto the movements of the rover.
//sensors should refer to this.
//take care of speed meaning time. meaning refreshing position.
//a system to send this kind of message : the robot bangued the wall !


//SensorMaxRange well it can be taken out. I was just thinking there was no point calculating further than needed
namespace RobotMock
{
    internal class Environment
    {
        internal Environment( string bitmapPath, double pixelRealDistanceRatio,double startPositionX, double startPositionY, double startAngle )
        {
            _envMap = new EnvironmentMap();
            _envMap.Initialize( bitmapPath );
            _posX = startPositionX;
            _posY = startPositionY;
            _angle = startAngle;
            _speed = 0;
            _pixelRealDistanceRatio = pixelRealDistanceRatio;
            SensorMaxRange = 100;//valeur au pif
        }
        EnvironmentMap _envMap;
        double _posX;
        double _posY;
        double _angle;
        double _speed;
        double _pixelRealDistanceRatio;
        /// <summary>
        /// eum just so that it does not go for almost forever. not real distance as it will just check x and y
        /// just make sure this is bigger than your sensor range.
        /// </summary>
        public double SensorMaxRange { get; set; }
        public double Speed { get; set; }


        class EnvironmentMap
        {
            Bitmap source=null;
            BitmapData bitmapData = null;

            public byte[] Pixels { get; set; }
            public int Depth { get; private set; }//PixelFormatSize
            public int Width { get; private set; }
            public int Height { get; private set; }

            public void Initialize(string bitmapPath)
            {
                source = Bitmap.FromFile( bitmapPath ) as Bitmap;//peut péter des exceptions hein ^^.
                    
                 //Image a =  Bitmap.FromFile(bitmapPath);
                 //a.RawFormat
                if( source != null )
                {
                    try
                    {
                        // Get width and height of bitmap
                        Width = source.Width;
                        Height = source.Height;

                        // get total locked pixels count
                        int PixelCount = Width * Height;

                        // Create rectangle to lock
                        Rectangle rect = new Rectangle( 0, 0, Width, Height );

                        // get source bitmap pixel format size
                        Depth = System.Drawing.Bitmap.GetPixelFormatSize( source.PixelFormat );

                        // Check if bpp (Bits Per Pixel) is 8, 24, or 32
                        if( Depth != 8 && Depth != 24 && Depth != 32 )
                        {
                            throw new ArgumentException( "Only 8, 24 and 32 bpp images are supported." );
                        }

                        // Lock bitmap and return bitmap data
                        bitmapData = source.LockBits( rect, ImageLockMode.ReadOnly,
                                                     source.PixelFormat );

                        IntPtr iptr = IntPtr.Zero;
                        // create byte array to copy pixel values
                        int step = Depth / 8;
                        Pixels = new byte[PixelCount * step];
                        iptr = bitmapData.Scan0;

                        // Copy data from pointer to array
                        Marshal.Copy( iptr, Pixels, 0, Pixels.Length );
                    }
                    catch( Exception ex )
                    {
                        throw ex;
                    }
                }

            }

            /// <summary>
            /// Get the color of the specified pixel
            /// </summary>
            /// <param name="x"></param>
            /// <param name="y"></param>
            /// <returns></returns>
            public Color GetPixel( int x, int y )
            {
                Color clr = Color.Empty;

                // Get color components count
                int cCount = Depth / 8;

                // Get start index of the specified pixel
                int i = ((y * Width) + x) * cCount;

                if( i > Pixels.Length - cCount )
                    throw new IndexOutOfRangeException();

                if( Depth == 32 ) // For 32 bpp get Red, Green, Blue and Alpha
                {
                    byte b = Pixels[i];
                    byte g = Pixels[i + 1];
                    byte r = Pixels[i + 2];
                    byte a = Pixels[i + 3]; // a
                    clr = Color.FromArgb( a, r, g, b );
                }
                if( Depth == 24 ) // For 24 bpp get Red, Green and Blue
                {
                    byte b = Pixels[i];
                    byte g = Pixels[i + 1];
                    byte r = Pixels[i + 2];
                    clr = Color.FromArgb( r, g, b );
                }
                if( Depth == 8 )
                // For 8 bpp get color value (Red, Green and Blue values are the same)
                {
                    byte c = Pixels[i];
                    clr = Color.FromArgb( c, c, c );
                }
                return clr;
            }
        }
        bool IsPixelBlack( int x, int y )
        {
            try
            {
                Color color = _envMap.GetPixel( x, y );
                if( color == Color.Black )
                    return true;
                else
                    return false;
            }
            catch( IndexOutOfRangeException )
            {
                return true;
            }
        }
        //out of range is considered an obstacle.
        public bool ObstacleInFront(out double x, out double y)
        {
            //calculate which grid squares are in front
            //y=_angle *x+ b 
            //double b =_posY - _angle * _posX; //or not.
            // anyhow calculate x&y for each x+1 and each y+1. stop when an obstacle is found. 
            //get the closest between each of them.

            double a1=0;
            double b1=0;
            double a2=0;
            double b2=0;
            double angle= _angle % 2* Math.PI;
            bool wayX=true;
            bool wayY=true;
            if( angle > Math.PI )
            {
                wayY = false;
                angle = angle - Math.PI;
            }
            if( angle < Math.PI / 2 )
            {
                a1=Math.Tan( _angle );
                if( !wayY )
                    wayX = false;
            }
            else if( angle < Math.PI )
            {
                a1 = -Math.Tan( _angle );
                if(wayY)
                    wayX = false;
            }

            b1 = _posY - a1 * _posX;
            if(a1!=0)
                a2 = 1 / a1;
            b2 = _posX - a2 * _posY;
            //x= a2y + b2
            //y= a1x + b1
            double tmpPosX1=_posX;
            double tmpPosY1=_posY;
            double distanceSquare1= -1;
            bool isPoint1Black=false;
            double tmpPosX2=_posX;
            double tmpPosY2=_posY;
            double distanceSquare2= -1;
            bool isPoint2Black=false;

                while( !isPoint1Black && tmpPosX1<SensorMaxRange )
                {
                    if (wayX)
                        tmpPosX1 +=  _pixelRealDistanceRatio;
                    else
                        tmpPosX1 -= _pixelRealDistanceRatio;
                    //y=a1x+b1 
                    tmpPosY1 = a1 * tmpPosX1 + b1;
                    //check grid.
                    isPoint1Black =  IsPixelBlack( (int) Math.Truncate(tmpPosX1 / _pixelRealDistanceRatio), (int) Math.Truncate(tmpPosY1 / _pixelRealDistanceRatio) );
                }
                while( !isPoint2Black && tmpPosY2<SensorMaxRange )
                {
                    if (wayY)
                        tmpPosY2 += _pixelRealDistanceRatio;
                    else
                        tmpPosY2 -= _pixelRealDistanceRatio;
                    //x=a2x + b2
                    tmpPosX2 = a2 * tmpPosY2 + b2;
                    //check grid.
                    isPoint2Black = IsPixelBlack( (int)Math.Truncate( tmpPosX1 / _pixelRealDistanceRatio ), (int)Math.Truncate( tmpPosY1 / _pixelRealDistanceRatio ) );
                }
                if( isPoint2Black && isPoint1Black )
                {
                    distanceSquare1 = (tmpPosX1 - _posX) * (tmpPosX1 - _posX) + (tmpPosY1 - _posY) * (tmpPosY1 - _posY);
                    distanceSquare2 = (tmpPosX2 - _posX) * (tmpPosX2 - _posX) + (tmpPosY2 - _posY) * (tmpPosY2 - _posY);
                    if( distanceSquare1 < distanceSquare2 )
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
                else if( isPoint1Black )
                {
                    x = tmpPosX1;
                    y = tmpPosX2;
                }
                else if( isPoint2Black )
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

        public bool ObstacleDistance(out double dist)
        {            
            double x=0;
            double y=0;
            bool Is = ObstacleInFront(out x, out y );
            dist = 0;
            if( !Is )
                return false;

            dist = Math.Sqrt( (x - _posX) * (x - _posX) + (y - _posY) * (y - _posY) );
            return true;
        }
    }
}

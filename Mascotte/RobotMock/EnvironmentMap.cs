using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace RobotMock
{
    class EnvironmentMap
    {
        Bitmap source = null;
        BitmapData bitmapData = null;
        byte[][] datasInMap;

        public byte[] Pixels { get; set; }
        public int Depth { get; private set; }//PixelFormatSize
        public int Width { get; private set; }
        public int Height { get; private set; }

        public void Initialize(string bitmapPath)
        {
            
            source = Bitmap.FromFile(bitmapPath) as Bitmap;//peut péter des exceptions hein ^^.
            
            // Converts bitmap into bidimensionnal byte array
            datasInMap = ConvertBitmapIntoByte(source);
            //Image a =  Bitmap.FromFile(bitmapPath);
            //a.RawFormat
            if (source != null)
            {
                try
                {
                    // Get width and height of bitmap
                    Width = source.Width;
                    Height = source.Height;

                    // get total locked pixels count
                    int PixelCount = Width * Height;

                    // Create rectangle to lock
                    Rectangle rect = new Rectangle(0, 0, Width, Height);

                    // get source bitmap pixel format size
                    Depth = System.Drawing.Bitmap.GetPixelFormatSize(source.PixelFormat);

                    // Check if bpp (Bits Per Pixel) is 8, 24, or 32
                    if (Depth != 8 && Depth != 24 && Depth != 32)
                    {
                        throw new ArgumentException("Only 8, 24 and 32 bpp images are supported.");
                    }

                    // Lock bitmap and return bitmap data
                    bitmapData = source.LockBits(rect, ImageLockMode.ReadOnly, source.PixelFormat);

                    IntPtr iptr = IntPtr.Zero;
                    // create byte array to copy pixel values
                    int step = Depth / 8;
                    Pixels = new byte[PixelCount * step];
                    iptr = bitmapData.Scan0;

                    // Copy data from pointer to array
                    Marshal.Copy(iptr, Pixels, 0, Pixels.Length);
                }
                catch (Exception ex)
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
        public Color GetPixel(int x, int y)
        {
            Color clr = Color.Empty;

            // Get color components count
            int cCount = Depth / 8;

            // Get start index of the specified pixel
            int i = ((y * Width) + x) * cCount;

            if (i > Pixels.Length - cCount)
                throw new IndexOutOfRangeException();

            if (Depth == 32) // For 32 bpp get Red, Green, Blue and Alpha
            {
                byte b = Pixels[i];
                byte g = Pixels[i + 1];
                byte r = Pixels[i + 2];
                byte a = Pixels[i + 3]; // a
                clr = Color.FromArgb(a, r, g, b);
            }
            if (Depth == 24) // For 24 bpp get Red, Green and Blue
            {
                byte b = Pixels[i];
                byte g = Pixels[i + 1];
                byte r = Pixels[i + 2];
                clr = Color.FromArgb(r, g, b);
            }
            if (Depth == 8)
            // For 8 bpp get color value (Red, Green and Blue values are the same)
            {
                byte c = Pixels[i];
                clr = Color.FromArgb(c, c, c);
            }
            return clr;
        }
        /// <summary>
        /// Converts Bitmap Image into bidimensionnal byte array
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public byte[][] ConvertBitmapIntoByte(Bitmap image)
        {
            ImageConverter converter = new ImageConverter();
            byte[] bytesInLine = (byte[])converter.ConvertTo(image, typeof(byte[]));
            byte[][] result = new byte[Height][];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    result[i][j] = bytesInLine[i * Width + Height];
                }
            }
            return result;
        }
    }
}

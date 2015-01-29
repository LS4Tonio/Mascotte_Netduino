using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotApplication
{
    public partial class ObstaclesMapDraw : Form
    {
        private Graphics g;
        private byte[][] _map;

        public ObstaclesMapDraw(int width, int height, byte[][] map)
        {
            InitializeComponent();

            _map = map;
            g = this.drawPanel.CreateGraphics();
        }

        private void drawnMap()
        {
            for (int row = 0; row < _map.Length; row++)
            {
                for (int col = 0; col < _map[row].Length; col++)
                {
                    if (_map[row][col] > 0)
                    {
                        Brush b = new SolidBrush(Color.FromArgb(_map[row][col], _map[row][col], _map[row][col]));
                        //Brush b = new SolidBrush(Color.Black);
                        g.FillRectangle(b, col, row, 1, 1);
                        b.Dispose();
                    }
                }
            }
        }

        private void drawPanel_Paint(object sender, PaintEventArgs e)
        {
            drawnMap();
        }
    }
}

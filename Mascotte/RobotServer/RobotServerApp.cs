using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using RobotServer.GridMaker;

namespace RobotServer
{
    public partial class RobotServerApp : Form
    {
        private const int MAP_X_SIZE = 100;
        private const int MAP_Y_SIZE = 100;
        private Server server;
        private Graphics mapGraphics;

        public RobotServerApp()
        {
            InitializeComponent();

            // Create server
            server = new Server();

            // Create map
            mapGraphics = this.mapPanel.CreateGraphics();
            server.GeneralMap.PropertyChanged += new PropertyChangedEventHandler(GridChanged);
        }

        // Application closing event
        private void RobotServerApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Close();
        }
        
        // Map
        private void CreateRobotMap(Graphics g)
        {
            int width = this.mapPanel.Width / MAP_X_SIZE;
            int height = this.mapPanel.Height / MAP_Y_SIZE;

            for (int i = 0; i < MAP_Y_SIZE; i++)
            {
                for (int j = 0; j < MAP_X_SIZE; j++)
                {
                    byte mapValue = server.GeneralMap.GridContent[i][j];
                    if (mapValue > 0)
                        FillRectangle(j, i, g, server.GeneralMap.GridContent[i][j]);
                }
            }
        }
        private void FillRectangle(int x, int y, Graphics g, byte colorValue)
        {
            int xPos = this.mapPanel.Width / MAP_X_SIZE * x;
            int yPos = this.mapPanel.Height / MAP_Y_SIZE * y;
            int width = this.mapPanel.Width / MAP_X_SIZE;
            int height = this.mapPanel.Height / MAP_Y_SIZE;

            Brush brush;
            if (colorValue < 63)
                brush = new SolidBrush(Color.FromArgb(colorValue, 0, 0, 0));
            else if (colorValue >= 63 && colorValue < 127) 
                brush = new SolidBrush(Color.FromArgb(255, 0, 0));
            else if (colorValue > 127)
                brush = new SolidBrush(Color.FromArgb(0, 0, 255)); // TODO : possibly not ok to verify 
            else
                throw new ArgumentException();


            g.FillRectangle(brush, xPos, yPos, width, height);
            brush.Dispose();
        }

        // Map events
        private void mapPanel_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Graphics g = e.Graphics)
            {
                CreateRobotMap(g);
            }
        }
        private void GridChanged(object sender, EventArgs e)
        {
            this.CreateRobotMap(mapGraphics);
            Brush b;
            int width = this.mapPanel.Width / MAP_X_SIZE;
            int height = this.mapPanel.Height / MAP_Y_SIZE;

            b = new SolidBrush(Color.White);
            mapGraphics.FillRectangle(b,server.GeneralMap.ActualPosX + 3, server.GeneralMap.ActualPosY + 3, width, height);
            b.Dispose();
            b = new SolidBrush(Color.FromArgb(255,255,0));
            mapGraphics.FillRectangle(b, server.GeneralMap.ActualPosX + 4, server.GeneralMap.ActualPosY + 4, width, height);
        }

        // Menus
        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void sauvegarderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.saveMapDialog.ShowDialog();
        }
        private void chargerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.loadMapDialog.ShowDialog();
        }
        
        // Load/Save dialog
        private void loadMapDialog_FileOk(object sender, CancelEventArgs e)
        {
            //TO DO: Set loaded map in obstacle grid
            string file = this.loadMapDialog.FileName;
        }
        private void saveMapDialog_FileOk(object sender, CancelEventArgs e)
        {
            //TO DO: Create file of actual map anf change version number
        }

        // Movement orders
        private void directionTopButton_Click(object sender, EventArgs e)
        {
            server.SendMove(1);
        }
        private void directionTurnRightButton_Click(object sender, EventArgs e)
        {
            server.SendMove(3);
        }
        private void directionTurnLeftButton_Click(object sender, EventArgs e)
        {
            server.SendMove(4);
        }
        private void directionDownButton_Click(object sender, EventArgs e)
        {
            server.SendMove(3);
            server.SendMove(3);
        }

        // Speed
        private void speedTextBox_TextChanged(object sender, EventArgs e)
        {
            int speed = 0;
            if (int.TryParse(speedTextBox.Text, out speed))
            {
                if (speed < 0)
                {
                    speedTextBox.Text = "0";
                    speedBar.Value = 0;
                }
                else if (speed > 100)
                {
                    speedTextBox.Text = "100";
                    speedBar.Value = 100;
                }
                else
                {
                    speedTextBox.Text = speed.ToString();
                    speedBar.Value = speed;
                }
            }
            else
            {
                speedTextBox.Text = "50";
                speedBar.Value = 50;
            }
        }
        private void speedBar_Scroll(object sender, EventArgs e)
        {
            speedTextBox.Text = speedBar.Value.ToString();
        }
    }
}
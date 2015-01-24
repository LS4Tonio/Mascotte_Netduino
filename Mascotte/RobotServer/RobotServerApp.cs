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
        private Graphics g;
        private System.Windows.Forms.Timer timer;

        public RobotServerApp()
        {
            InitializeComponent();
            g = this.mapPanel.CreateGraphics();
            server = new Server();
            server.GeneralMap.PropertyChanged += new PropertyChangedEventHandler(GridChanged);

            // Timer for connection checks
            timer = new System.Windows.Forms.Timer();
            timer.Tick += new EventHandler(ConnectionTimer);
            timer.Interval = 2000; // in miliseconds
            //timer.Start();
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
                    int x = j * width;
                    int y = i * height;

                    byte mapValue = server.GeneralMap.GridContent[i][j];
                    if (mapValue > 0)
                        FillRectangle(i, j, g, server.GeneralMap.GridContent[i][j]);
                    //index++;
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
            this.CreateRobotMap(g);
            Brush b;
            int width = this.mapPanel.Width / MAP_X_SIZE;
            int height = this.mapPanel.Height / MAP_Y_SIZE;

            b = new SolidBrush(Color.White);
            g.FillRectangle(b,server.GeneralMap.ActualPosX + 3, server.GeneralMap.ActualPosY + 3, width, height);
            b.Dispose();
            b = new SolidBrush(Color.FromArgb(255,255,0));
            g.FillRectangle(b, server.GeneralMap.ActualPosX + 4, server.GeneralMap.ActualPosY + 4, width, height);
        }

        // Connection check
        private void CheckConnectionWithClient()
        {
            var networkOff = global::RobotServer.Properties.Resources.networkOff;
            var networkOn = global::RobotServer.Properties.Resources.networkOn;

            if (server.IsClientConnected())
            {
                if (this.connectionStatus.Image != networkOn)
                    this.connectionStatus.Image = networkOn;
                this.connectionStatus.Text = @"Connecté";
            }
            else
            {
                if (this.connectionStatus.Image != networkOff)
                    this.connectionStatus.Image = networkOff;
                this.connectionStatus.Text = @"Déconnecté";
            }
        }
        private void ConnectionTimer(object sender, EventArgs e)
        {
            CheckConnectionWithClient();
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

    }
}
﻿using System;
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
        const int MAP_X_SIZE = 100;
        const int MAP_Y_SIZE = 100;
        Graphics g;

        public RobotServerApp()
        {
            InitializeComponent();
            g = this.mapPanel.CreateGraphics();
            server = new Server();
            server.GeneralMap.PropertyChanged += new PropertyChangedEventHandler(GridChanged);
        }
        // Robot Map
        private void CreateRobotMap(Graphics g)
        {
        }

        private void RobotServerApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Close();
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
        }
    }
}
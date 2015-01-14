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

        Server server;

        public RobotServerApp()
        {
            InitializeComponent();
            Graphics g = this.mapPanel.CreateGraphics();
            server = new Server();
        }
        // Robot Map
        private void CreateRobotMap(Graphics g)
        {
            int width = this.mapPanel.Width / MAP_X_SIZE;
            int height = this.mapPanel.Height / MAP_Y_SIZE;
            //int index = 0;
            //Pen pen = new Pen(Color.White, 1);
            //Rectangle[] rectangles = new Rectangle[MAP_X_SIZE * MAP_Y_SIZE];

            for (int i = 0; i < MAP_Y_SIZE; i++)
            {
                for (int j = 0; j < MAP_X_SIZE; j++)
                {
                    int x = j * width;
                    int y = i * height;
                    //Rectangle rectangle = new Rectangle(x, y, width, height);
                    //g.DrawRectangle(pen, rectangle);

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
                brush = new SolidBrush(Color.FromArgb(0, 0, 255));
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
    }
}
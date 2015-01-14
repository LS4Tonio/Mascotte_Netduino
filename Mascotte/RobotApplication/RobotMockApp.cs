﻿using RobotMock;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotApplication
{
    public partial class RobotMockApp : Form
    {
        ConfigurationWindow confWindow;
        Robot robot;
        Graphics robotMapGraphic;
        ClientConnection connection;
        const int ROBOTMAP_X_SIZE = 8;
        const int ROBOTMAP_Y_SIZE = 8;

        public RobotMockApp()
        {
            InitializeComponent();

            confWindow = new ConfigurationWindow();
            /*connection = new ClientConnection();
            if (connection.IsConnected)
                connectionStatus.Image = global::RobotApplication.Properties.Resources.networkOn;*/

            robot = new Robot(ROBOTMAP_X_SIZE, ROBOTMAP_Y_SIZE);
            robotMapGraphic = this.robotMapPanel.CreateGraphics();
            this.robotAngleTextBox.Text = robot.Rover.Direction.ToString();
            robot.MiniMap.PropertyChanged += MiniMap_PropertyChanged;
        }

        // Menu
        private void quitMenuButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void configureMenuButton_Click(object sender, EventArgs e)
        {
            confWindow.ShowDialog();
        }
        private void loadMapMenuButton_Click(object sender, EventArgs e)
        {
            this.loadMapDialog.ShowDialog();
        }
        private void saveMapMenuButton_Click(object sender, EventArgs e)
        {
            this.saveMapDialog.ShowDialog();
        }

        // Load/Save dialog
        private void loadMapDialog_FileOk(object sender, CancelEventArgs e)
        {
            //TO DO: Set loaded map in obstacle grid
            string file = this.loadMapDialog.FileName;

            try
            {
                this.obstacleMapPictureBox.ImageLocation = file;
            }
            catch (IOException)
            {
            }
        }
        private void saveMapDialog_FileOk(object sender, CancelEventArgs e)
        {
            //TO DO: Create/Replace actual map file
        }

        // Speed
        private void speedBar_Scroll(object sender, EventArgs e)
        {
            this.speedTextBox.Text = this.speedBar.Value.ToString();
        }
        private void speedTextBox_TextChanged(object sender, EventArgs e)
        {
            int speedValue;

            if (int.TryParse(this.speedTextBox.Text, out speedValue))
            {
                if (speedValue < 0)
                    speedValue = 0;
                if (speedValue > 100)
                    speedValue = 100;
            }

            this.speedBar.Value = speedValue;
            this.speedTextBox.Text = speedValue.ToString();
        }

        // Direction
        private void directionForwardButton_Click(object sender, EventArgs e)
        {
            // Move robot
            robot.Rover.Move(true, this.speedBar.Value / 100);

            // Change status
            if (this.robotStatus.Image != global::RobotApplication.Properties.Resources.running)
                this.robotStatus.Image = global::RobotApplication.Properties.Resources.running;

            // Move map
            robot.MiniMap.MoveMap(robot.MiniMap.FindDirection(robot.Rover.Direction));
        }
        private void directionBackwardButton_Click(object sender, EventArgs e)
        {
            // Move robot
            robot.Rover.Move(false, this.speedBar.Value / 100);

            // Change status
            if (this.robotStatus.Image != global::RobotApplication.Properties.Resources.running)
                this.robotStatus.Image = global::RobotApplication.Properties.Resources.running;

            // Move map
            int direction = robot.Rover.Direction;
            direction += 180;
            if (direction > 360)
                direction -= 360;
            if (direction < 0)
                direction += 360;
            robot.MiniMap.MoveMap(robot.MiniMap.FindDirection(direction));
        }
        private void directionTurnLeftButton_Click(object sender, EventArgs e)
        {
            // Change robot angle
            robot.Rover.Turn(false, this.speedBar.Value / 100, 90);

            // Change status
            if (this.robotStatus.Image != global::RobotApplication.Properties.Resources.running)
                this.robotStatus.Image = global::RobotApplication.Properties.Resources.running;

            // Display new angle
            this.robotAngleTextBox.Text = robot.Rover.Direction.ToString();
        }
        private void directionTurnRightButton_Click(object sender, EventArgs e)
        {
            // Change robot angle
            robot.Rover.Turn(true, this.speedBar.Value / 100, 90);

            // Change status
            if (this.robotStatus.Image != global::RobotApplication.Properties.Resources.running)
                this.robotStatus.Image = global::RobotApplication.Properties.Resources.running;
            
            // Display new angle
            this.robotAngleTextBox.Text = robot.Rover.Direction.ToString();
        }

        // Movement
        private void startButton_Click(object sender, EventArgs e)
        {
            //TO DO: Start robot movement
            if (this.robotStatus.Image != global::RobotApplication.Properties.Resources.running)
                this.robotStatus.Image = global::RobotApplication.Properties.Resources.running;
        }
        private void stopButton_Click(object sender, EventArgs e)
        {
            //TO DO: Stop robot movement
            if (this.robotStatus.Image != global::RobotApplication.Properties.Resources.stopped)
                this.robotStatus.Image = global::RobotApplication.Properties.Resources.stopped;
        }
        private void pauseButton_Click(object sender, EventArgs e)
        {
            //TO DO: Stop robot movement, but when robot restart finish 
            //what it was doing before pause
            if (this.robotStatus.Image != global::RobotApplication.Properties.Resources.stopped)
                this.robotStatus.Image = global::RobotApplication.Properties.Resources.stopped;
        }

        // Robot Map
        private void CreateRobotMap(Graphics g)
        {
            int width = this.robotMapPanel.Width / ROBOTMAP_X_SIZE;
            int height = this.robotMapPanel.Height / ROBOTMAP_Y_SIZE;
            int index = 0;
            Pen pen = new Pen(Color.Black, 1);
            Rectangle[] rectangles = new Rectangle[ROBOTMAP_X_SIZE * ROBOTMAP_Y_SIZE];

            for (int i = 0; i < ROBOTMAP_Y_SIZE; i++)
            {
                for (int j = 0; j < ROBOTMAP_X_SIZE; j++)
                {
                    int x = j * width;
                    int y = i * height;
                    Rectangle rectangle = new Rectangle(x, y, width, height);
                    g.DrawRectangle(pen, rectangle);
                    //rectangles[index] = rectangle;

                    byte mapValue = robot.MiniMap.MapArray[i][j];
                    if (mapValue > 0)
                        FillRectangle(j, i, g);

                    index++;
                }
            }

            //g.DrawRectangles(pen, rectangles);
        }
        private void FillRectangle(int x, int y, Graphics g)
        {
            int xPos = this.robotMapPanel.Width / ROBOTMAP_X_SIZE * x;
            int yPos = this.robotMapPanel.Height / ROBOTMAP_Y_SIZE * y;
            int width = this.robotMapPanel.Width / ROBOTMAP_X_SIZE;
            int height = this.robotMapPanel.Height / ROBOTMAP_Y_SIZE;
            Brush brush = new SolidBrush(Color.Black);

            g.FillRectangle(brush, xPos, yPos, width, height);
            brush.Dispose();
        }
        private void EmptyRectangle(int x, int y, Graphics g)
        {
            int xPos = this.robotMapPanel.Width / ROBOTMAP_X_SIZE * x + 1;
            int yPos = this.robotMapPanel.Height / ROBOTMAP_Y_SIZE * y + 1;
            int width = this.robotMapPanel.Width / ROBOTMAP_X_SIZE - 1;
            int height = this.robotMapPanel.Height / ROBOTMAP_Y_SIZE - 1;
            Brush brush = new SolidBrush(Color.White);

            g.FillRectangle(brush, xPos, yPos, width, height);
            brush.Dispose();
        }
        private void UpdateMap(Graphics g, Map m)
        {
            var xLength = m.MapArray.Length;

            for (int i = 0; i < xLength; i++)
            {
                var yLength = m.MapArray[i].Length;

                for (int j = 0; j < yLength; j++)
                {
                    if (m.MapArray[i][j] > 0)
                        FillRectangle(j, i, g);
                    else
                        EmptyRectangle(j, i, g);
                }
            }
        }
        private void robotMapPanel_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            using (Graphics g = e.Graphics)
            {
                CreateRobotMap(g);
            }
        }
        private void xTextBox_TextChanged(object sender, EventArgs e)
        {
            int x = 0;
            int.TryParse(this.xTextBox.Text, out x);

            if (x < 0)
                x = 0;
            if (x > ROBOTMAP_X_SIZE - 1)
                x = ROBOTMAP_X_SIZE - 1;

            this.xTextBox.Text = x.ToString();
        }
        private void yTextBox_TextChanged(object sender, EventArgs e)
        {
            int y = 0;
            int.TryParse(this.yTextBox.Text, out y);

            if (y < 0)
                y = 0;
            if (y > ROBOTMAP_Y_SIZE - 1)
                y = ROBOTMAP_Y_SIZE - 1;

            this.yTextBox.Text = y.ToString();
        }
        private void fillRectangleButton_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;

            int.TryParse(this.xTextBox.Text, out x);
            int.TryParse(this.yTextBox.Text, out y);

            robot.MiniMap.MapArray[x][y] = 255;
            FillRectangle(x, y, robotMapGraphic);
        }
        private void emptyRectangleButton_Click(object sender, EventArgs e)
        {
            int x = 0;
            int y = 0;

            int.TryParse(this.xTextBox.Text, out x);
            int.TryParse(this.yTextBox.Text, out y);

            robot.MiniMap.MapArray[x][y] = 0;
            EmptyRectangle(x, y, robotMapGraphic);
        }

        // Map operations
        private void forceGetMapButton_Click(object sender, EventArgs e)
        {
            //TO DO: Force getting map from server
        }
        private void forceSendButton_Click(object sender, EventArgs e)
        {
            //TO DO: Force sending map to the server
        }
        private void MiniMap_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            UpdateMap(robotMapGraphic, robot.MiniMap);
        }
    }
}

using RobotMock;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotApplication
{
    public partial class RobotMockApp : Form
    {
        private ConfigurationWindow confWindow;
        private ErrorWindow errorWindow;
        private ObstaclesMapDraw omd;
        private Robot robot;
        private Graphics robotMapGraphic;
        private Graphics obstacleMapGraphic;
        private bool isConnectionErrorShown;
        private bool isRunning;
        const int ROBOTMAP_X_SIZE = 51;
        const int ROBOTMAP_Y_SIZE = 51;
        const int PAUSE_TIME_MAX = 1000; // Pause time in ms

        public RobotMockApp()
        {
            // Window components
            InitializeComponent();
            confWindow = new ConfigurationWindow();
            errorWindow = new ErrorWindow();

            // Mock
            robot = new Robot(ROBOTMAP_X_SIZE, ROBOTMAP_Y_SIZE, 10, 10, 0);
            this.robotAngleTextBox.Text = robot.Rover.Direction.ToString();
            isRunning = false;

            // Display direction arrow
            DisplayDirection(robot.MiniMap.FindDirection(robot.Rover.Direction));

            // Display speed
            speedTextBox.Text = speedBar.Value.ToString();

            // Robot map
            robotMapGraphic = this.robotMapPanel.CreateGraphics();
            robot.MiniMap.PropertyChanged += MiniMap_PropertyChanged;

            // Obstacle map
            obstacleMapGraphic = this.obstacleMapPictureBox.CreateGraphics();
            //omd = new ObstaclesMapDraw(robot.Environment.EnvironmentMap.Width, robot.Environment.EnvironmentMap.Height, robot.Environment.EnvironmentMap.ObstaclesMap);

            // Launch connection checks
            isConnectionErrorShown = false;
            CallCheckConnectionAsync();

            //Check information for movement
            //CallMovementOrderAsync();
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
            robot.Rover.Speed = speedBar.Value / 100;
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
            robot.Rover.Speed = speedBar.Value / 100;
        }

        // Direction
        private void directionForwardButton_Click(object sender, EventArgs e)
        {
            ForwardAction();
        }
        private void directionBackwardButton_Click(object sender, EventArgs e)
        {
            BackwardAction();
        }
        private void directionTurnLeftButton_Click(object sender, EventArgs e)
        {
            TurnAction(true);
        }
        private void directionTurnRightButton_Click(object sender, EventArgs e)
        {
            TurnAction(false);
        }
        private void DisplayDirection(directions direction)
        {
            var up = global::RobotApplication.Properties.Resources.arrowUp;
            var left = global::RobotApplication.Properties.Resources.arrowLeft;
            var down = global::RobotApplication.Properties.Resources.arrowDown;
            var right = global::RobotApplication.Properties.Resources.arrowRight;
            var stop = global::RobotApplication.Properties.Resources.stopped;

            switch (direction)
            {
                case directions.TOP:
                    {
                        this.actualDirection.Image = up;
                        break;
                    }
                case directions.BOTTOM:
                    {
                        this.actualDirection.Image = down;
                        break;
                    }
                case directions.LEFT:
                    {
                        this.actualDirection.Image = left;
                        break;
                    }
                case directions.RIGHT:
                    {
                        this.actualDirection.Image = right;
                        break;
                    }
                default:
                    {
                        this.actualDirection.Image = stop;
                        break;
                    }
            }
        }
        private void ForwardAction()
        {
            double speedValue = robot.Rover.Speed;

            // Direction of the robot
            directions direction = robot.MiniMap.FindDirection(robot.Rover.Direction);

            // Position of map
            int xPos = (int)robot.MiniMap.Xposition;
            int yPos = (int)robot.MiniMap.Yposition;

            // Move
            MoveRobot(true, speedValue, direction, xPos, yPos);
        }
        private void BackwardAction()
        {
            TurnAction(true);
            TurnAction(true);
        }
        private void TurnAction(bool isLeft)
        {
            // Change robot angle
            robot.Rover.Turn(isLeft, robot.Rover.Speed, 90);

            // Display new angle
            this.robotAngleTextBox.Text = robot.Rover.Direction.ToString();

            // Change image
            DisplayDirection(robot.MiniMap.FindDirection(robot.Rover.Direction));
        }

        // Movement
        private void startButton_Click(object sender, EventArgs e)
        {
            // Change image status
            if (this.robotStatus.Image != global::RobotApplication.Properties.Resources.running)
                this.robotStatus.Image = global::RobotApplication.Properties.Resources.running;

            // Block "forward" button
            this.directionTopButton.Enabled = false;

            // Move
            if (!isRunning)
            {
                isRunning = true;
                CallMovementAsync();
                //CallMovementOrderAsync();
            }
        }
        private void stopButton_Click(object sender, EventArgs e)
        {
            // Change image status
            if (this.robotStatus.Image != global::RobotApplication.Properties.Resources.stopped)
                this.robotStatus.Image = global::RobotApplication.Properties.Resources.stopped;

            // Block "forward" button
            this.directionTopButton.Enabled = true;

            // Stop robot
            if (isRunning)
                isRunning = false;
        }
        private void pauseButton_Click(object sender, EventArgs e)
        {
            // Change image status
            if (this.robotStatus.Image != global::RobotApplication.Properties.Resources.stopped)
                this.robotStatus.Image = global::RobotApplication.Properties.Resources.pause;
        }
        private void MoveRobot(bool isForward, double speed, directions direction, int x, int y)
        {
            // Move rover
            robot.Rover.Move(isForward, speed);
            // Move map
            byte[] datas = robot.MiniMap.MoveMap(direction);
            // Drawn moved map
            UpdatePaintOnObstacleMap();
            // Get obstacles
            robot.GetObstacle();
            //robot.GetObstacleEasy();
            // Send movement
            robot.Wifi.SendMove((byte)direction, (byte)x, (byte)y, datas);
        }
        private async void CallMovementAsync()
        {
            //await InitializationMovement();
            await Task.Run(() =>
            {
                while (isRunning)
                {
                    double speed = robot.Rover.Speed;
                    int pauseTime = (PAUSE_TIME_MAX + 10) - ((int)speed * 1000);
                    directions direction = robot.MiniMap.FindDirection(robot.Rover.Direction);
                    int xPos = (int)robot.MiniMap.Xposition;
                    int yPos = (int)robot.MiniMap.Yposition;

                    MoveRobot(true, speed, direction, xPos, yPos);

                    Thread.Sleep(pauseTime);
                }
            });
        }

        //Movement order receiving 
        private async void CallMovementOrderAsync()
        {
            //await InitializationReceivingMovement();
            await Task.Run(() =>
            {
                try
                {
                    while (true)
                    {
                        switch ((int)robot.Wifi.getOrders())
                        {
                            case 1: //UP
                                MoveRobot(true, robot.Rover.Speed,
                                         robot.MiniMap.FindDirection(robot.Rover.Direction),
                                         (int)robot.MiniMap.Yposition,
                                         (int)robot.MiniMap.Xposition);
                                break;
                            case 2: // DOWN
                                MoveRobot(false, robot.Rover.Speed,
                                            robot.MiniMap.FindDirection(robot.Rover.Direction),
                                            (int)robot.MiniMap.Yposition,
                                            (int)robot.MiniMap.Xposition);
                                break;
                            case 3: // LEFT
                                robot.Rover.Turn(false, 0.5, 90);
                                DisplayDirection(robot.MiniMap.FindDirection(robot.Rover.Direction));
                                break;
                            case 4: //RIGHT
                                robot.Rover.Turn(true, 0.5, 90);
                                DisplayDirection(robot.MiniMap.FindDirection(robot.Rover.Direction));
                                break;
                        }

                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            });
        }

        // Robot Map
        private void CreateRobotMap(Graphics g)
        {
            int width = this.robotMapPanel.Width / ROBOTMAP_X_SIZE;
            int height = this.robotMapPanel.Height / ROBOTMAP_Y_SIZE;
            int index = 0;
            Pen pen = new Pen(Color.Black, 1);

            for (int i = 0; i < ROBOTMAP_Y_SIZE; i++)
            {
                for (int j = 0; j < ROBOTMAP_X_SIZE; j++)
                {
                    int x = j * width;
                    int y = i * height;
                    Rectangle rectangle = new Rectangle(x, y, width, height);
                    g.DrawRectangle(pen, rectangle);

                    byte mapValue = robot.MiniMap.MapArray[i][j];
                    if (mapValue > 0)
                        FillRectangle(j, i, g, confWindow.ObstacleColor);

                    index++;
                }
            }

            ColorRobotPosition(g);
        }
        private void FillRectangle(int x, int y, Graphics g, Color c)
        {
            int xPos = this.robotMapPanel.Width / ROBOTMAP_X_SIZE * x + 1;
            int yPos = this.robotMapPanel.Height / ROBOTMAP_Y_SIZE * y + 1;
            int width = this.robotMapPanel.Width / ROBOTMAP_X_SIZE - 1;
            int height = this.robotMapPanel.Height / ROBOTMAP_Y_SIZE - 1;
            Brush brush = new SolidBrush(c);

            g.FillRectangle(brush, xPos, yPos, width, height);
            brush.Dispose();
        }
        private void ColorRobotPosition(Graphics g)
        {
            FillRectangle(ROBOTMAP_X_SIZE / 2, ROBOTMAP_Y_SIZE / 2, g, confWindow.RobotColor);
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
                        FillRectangle(j, i, g, confWindow.ObstacleColor);
                    else
                        EmptyRectangle(j, i, g);
                }
            }

            ColorRobotPosition(g);
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
            FillRectangle(x, y, robotMapGraphic, confWindow.ObstacleColor);
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

        // Check connection
        private async void CallCheckConnectionAsync()
        {
            //await InitializationCheckConnection();
            await Task.Run(() =>
            {
                var networkOff = global::RobotApplication.Properties.Resources.networkOff;
                var networkOn = global::RobotApplication.Properties.Resources.networkOn;

                while (true)
                {
                    string message = "";
                    if (robot.Wifi.CheckConnection(out message))
                    {
                        this.connectionStatus.Text = @"Connecté";
                        this.connectionStatus.Image = networkOn;
                        isConnectionErrorShown = false;
                    }
                    else
                    {
                        this.connectionStatus.Text = @"Déconnecté";
                        this.connectionStatus.Image = networkOff;
                        if (!isConnectionErrorShown)
                        {
                            isConnectionErrorShown = true;
                            errorWindow.SetErrorMessage("Erreur de connexion", "Aucune connexion", message);
                        }
                    }
                    Thread.Sleep(10);
                }
            });
        }

        // Obstacle Map
        private void UpdatePaintOnObstacleMap()
        {
            CleanObstacleMap();
        }
        private void PaintOnObstacleMap(Graphics g)
        {
            Pen pen = new Pen(Color.Red, 1);
            int imageWidth = this.obstacleMapPictureBox.Image.Width;
            int imageHeight = this.obstacleMapPictureBox.Image.Height;
            int pictureBoxWidth = this.obstacleMapPictureBox.Width;
            int pictureBoxHeight = this.obstacleMapPictureBox.Height;

            float widthPercent = 1;
            float heightPercent = 1;

            // Find proper size for the red rectange according the shown map
            if (imageWidth > pictureBoxWidth)
                widthPercent = (float) 1 - (imageWidth - pictureBoxWidth) / imageWidth;
            else if (pictureBoxWidth > imageWidth && this.obstacleMapPictureBox.SizeMode == PictureBoxSizeMode.StretchImage)
                widthPercent = (float)(pictureBoxWidth - imageWidth) / pictureBoxWidth + 1;

            if (imageHeight > pictureBoxHeight)
                heightPercent = (float)(imageHeight - pictureBoxHeight) / imageHeight;
            else if (pictureBoxHeight > imageHeight && this.obstacleMapPictureBox.SizeMode == PictureBoxSizeMode.StretchImage)
                heightPercent = (float)(pictureBoxHeight - imageHeight) / pictureBoxHeight + 1;

            float robotWidth = ROBOTMAP_X_SIZE * widthPercent;
            float robotHeight = ROBOTMAP_Y_SIZE * heightPercent;

            float mapX = robot.MiniMap.Xposition - robotWidth / 2;
            float mapY = robot.Environment.EnvironmentMap.Height - 1 - robot.MiniMap.Yposition - robotHeight / 2;

            // Place the red rectangle on the proper X/Y pos
            //if (this.obstacleMapPictureBox.SizeMode == PictureBoxSizeMode.StretchImage)
            //{
            //    mapX = mapX * widthPercent;
            //    mapY = mapY * heightPercent - robotHeight;
            //}

            // Drawn rectangle
            g.DrawRectangle(pen, mapX, mapY, robotWidth, robotHeight);
        }
        private void CleanObstacleMap()
        {
            this.obstacleMapPictureBox.Invalidate();
        }
        private void obstacleMapPictureBox_Paint(object sender, PaintEventArgs e)
        {
            base.OnPaint(e);
            obstacleMapGraphic = e.Graphics;
            PaintOnObstacleMap(obstacleMapGraphic);
        }
        private void obstacleMapDrawButon_Click(object sender, EventArgs e)
        {
            omd.ShowDialog();
        }

        // Key binding
        private void KeyAction(Keys k)
        {
            switch (k)
            {
                case Keys.Z:
                    TurnAction(true);
                    break;
                case Keys.Q:
                    TurnAction(false);
                    break;
                case Keys.D:
                    ForwardAction();
                    break;
                case Keys.S:
                    BackwardAction();
                    break;
            }
        }
        private void RobotMockApp_KeyDown(object sender, KeyEventArgs e)
        {
            KeyAction(e.KeyCode);
        }
    }
}

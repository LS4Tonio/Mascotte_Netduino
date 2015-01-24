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
        private Robot robot;
        private Graphics robotMapGraphic;
        private bool isConnectionErrorShown;
        private bool isRunning;
        const int ROBOTMAP_X_SIZE = 9;
        const int ROBOTMAP_Y_SIZE = 9;
        const int PAUSE_TIME_MAX = 1000; // Pause time in ms

        public RobotMockApp()
        {
            // Window components
            InitializeComponent();
            confWindow = new ConfigurationWindow();
            errorWindow = new ErrorWindow();

            // Mock
            robot = new Robot(ROBOTMAP_X_SIZE, ROBOTMAP_Y_SIZE, 10, 10, Math.PI/2);
            this.robotAngleTextBox.Text = robot.Rover.Direction.ToString();
            isRunning = false;

            // Display direction arrow
            DisplayDirection(robot.MiniMap.FindDirection(robot.Rover.Direction));

            // Display speed
            speedTextBox.Text = speedBar.Value.ToString();

            // Robot map
            robotMapGraphic = this.robotMapPanel.CreateGraphics();
            robot.MiniMap.PropertyChanged += MiniMap_PropertyChanged;

            // Timer for connection checks
            isConnectionErrorShown = false;
            CallCheckConnectionAsync();
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
            double speedValue = robot.Rover.Speed;
            int direction = robot.MiniMap.FindDirection(robot.Rover.Direction);
           
            int xPos = (int)robot.MiniMap.Yposition;
            int yPos = (int)robot.MiniMap.Xposition;

            // Move
            MoveRobot(true, speedValue, direction, xPos, yPos);
        }
        private void directionBackwardButton_Click(object sender, EventArgs e)
        {
            double speedValue = robot.Rover.Speed;
            int direction = robot.Rover.Direction;
            direction += 180;
            if (direction > 360)
                direction -= 360;
            if (direction < 0)
                direction += 360;
            direction = robot.MiniMap.FindDirection(direction);
            int xPos = (int)robot.MiniMap.Xposition;
            int yPos = (int)robot.MiniMap.Yposition;

            // Move
            MoveRobot(false, speedValue, direction, xPos, yPos);
        }
        private void directionTurnLeftButton_Click(object sender, EventArgs e)
        {
            // Change robot angle
            robot.Rover.Turn(false, robot.Rover.Speed, 90);

            // Display new angle
            this.robotAngleTextBox.Text = robot.Rover.Direction.ToString();

            // Change image
            DisplayDirection(robot.MiniMap.FindDirection(robot.Rover.Direction));
        }
        private void directionTurnRightButton_Click(object sender, EventArgs e)
        {
            // Change robot angle
            robot.Rover.Turn(true, robot.Rover.Speed, 90);

            // Display new angle
            this.robotAngleTextBox.Text = robot.Rover.Direction.ToString();

            // Change image
            DisplayDirection(robot.MiniMap.FindDirection(robot.Rover.Direction));
        }
        private void DisplayDirection(int direction)
        {
            var up = global::RobotApplication.Properties.Resources.arrowUp;
            var left = global::RobotApplication.Properties.Resources.arrowLeft;
            var down = global::RobotApplication.Properties.Resources.arrowDown;
            var right = global::RobotApplication.Properties.Resources.arrowRight;
            var stop = global::RobotApplication.Properties.Resources.stopped;

            switch (direction)
            {
                case 1:
                    {
                        this.actualDirection.Image = up;
                        break;
                    }
                case 2:
                    {
                        this.actualDirection.Image = down;
                        break;
                    }
                case 3:
                    {
                        this.actualDirection.Image = left;
                        break;
                    }
                case 4:
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

        // Movement
        private void startButton_Click(object sender, EventArgs e)
        {
            // Change image status
            if (this.robotStatus.Image != global::RobotApplication.Properties.Resources.running)
                this.robotStatus.Image = global::RobotApplication.Properties.Resources.running;

            // Move
            if (!isRunning)
            {
                isRunning = true;
                CallMovementAsync();
            }
        }
        private void stopButton_Click(object sender, EventArgs e)
        {
            // Change image status
            if (this.robotStatus.Image != global::RobotApplication.Properties.Resources.stopped)
                this.robotStatus.Image = global::RobotApplication.Properties.Resources.stopped;

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
        private void MoveRobot(bool isForward, double speed, int direction, int x, int y)
        {
            // Move rover
            robot.Rover.Move(isForward, speed);
            // Move map
            byte[] datas = robot.MiniMap.MoveMap(direction);
            // Get obstacles
            robot.GetObstacle();
            // Send movement
            robot.Wifi.SendMove((byte)direction, (byte)x, (byte)y, datas);
        }
        private async void CallMovementAsync()
        {
            await InitializationMovement();
        }
        private Task InitializationMovement()
        {
            return Task.Run(() => Movement());
        }
        private async Task Movement()
        {
            while (isRunning)
            {
                double speed = robot.Rover.Speed;
                int pauseTime = (PAUSE_TIME_MAX + 10) - ((int)speed * 1000);
                int direction = robot.MiniMap.FindDirection(robot.Rover.Direction);
                int xPos = (int)robot.MiniMap.Xposition;
                int yPos = (int)robot.MiniMap.Yposition;

                MoveRobot(true, speed, direction, xPos, yPos);

                Thread.Sleep(pauseTime);
            }
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

        // Check connection
        private async void CallCheckConnectionAsync()
        {
            await InitializationCheckConnection();
        }
        private Task InitializationCheckConnection()
        {
            return Task.Run(() => CheckConnection());
        }
        private async Task CheckConnection()
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
        }
    }
}

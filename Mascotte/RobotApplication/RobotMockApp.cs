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
    public partial class RobotMockApp : Form
    {
        ConfigurationWindow confWindow;

        public RobotMockApp()
        {
            InitializeComponent();
            confWindow = new ConfigurationWindow();
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
            //TO DO: Set loaded map in grid
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
        private void directionTopButton_Click(object sender, EventArgs e)
        {
            //TO DO: Move robot up
        }
        private void directionDownButton_Click(object sender, EventArgs e)
        {
            //TO DO: Move robot down
        }
        private void directionTurnLeftButton_Click(object sender, EventArgs e)
        {
            //TO DO: Move robot left
        }
        private void directionTurnRightButton_Click(object sender, EventArgs e)
        {
            //TO DO: Move robot right
        }

        // Movement
        private void startButton_Click(object sender, EventArgs e)
        {
            //TO DO: Start robot movement
        }
        private void stopButton_Click(object sender, EventArgs e)
        {
            //TO DO: Stop robot movement
        }
        private void pauseButton_Click(object sender, EventArgs e)
        {
            //TO DO: Stop robot movement, but when robot restart finish 
            //what it was doing before pause
        }

        // Map
        private void forceGetMapButton_Click(object sender, EventArgs e)
        {
            //TO DO: Force getting map from server
        }
        private void forceSendButton_Click(object sender, EventArgs e)
        {
            //TO DO: Force sending map to the server
        }
    }
}

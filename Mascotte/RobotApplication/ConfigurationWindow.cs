using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotApplication
{
    public partial class ConfigurationWindow : Form
    {
        const string CONF_NAME = "netduino_simulator.cfg";
        private Color robotDefaultColor = Color.Red;
        private Color obstacleDefaultColor = Color.Black;
        private Color robotChoosenColor;
        private Color obstacleChoosenColor;

        public ConfigurationWindow()
        {
            InitializeComponent();
            ReadConfiguration(CONF_NAME);

            this.robotColorPictureBox.BackColor = robotDefaultColor;
            this.obstaclesColorPictureBox.BackColor = obstacleDefaultColor;
            robotChoosenColor = robotDefaultColor;
            obstacleChoosenColor = obstacleDefaultColor;
        }

        public Color RobotColor
        {
            get { return robotChoosenColor; }
        }
        public Color ObstacleColor
        {
            get { return obstacleChoosenColor; }
        }

        // Radio events
        private void localNetwork_CheckedChanged(object sender, EventArgs e)
        {
            toggleIPConf(this.localNetwork.Checked);
        }

        // Close buttons
        private void saveButton_Click(object sender, EventArgs e)
        {
            //TO DO: Save configuration on a file & apply
            this.Close();
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.SetDefaultValues();
            this.Close();
        }

        // Export/Import buttons
        private void importConfFileButton_Click(object sender, EventArgs e)
        {
            this.importConfFileDialog.ShowDialog();
        }
        private void exportConfFileButton_Click(object sender, EventArgs e)
        {
            this.exportConfFileDialog.ShowDialog();
        }
        
        // Export/Import file
        private void importConfFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            //TO DO: Load conf file and apply it
        }
        private void exportConfFileDialog_FileOk(object sender, CancelEventArgs e)
        {
            //TO DO: Write conf in file
        }

        // Colors
        private void changeRobotColorButton_Click(object sender, EventArgs e)
        {
            // Set selected color if it was selected
            if (robotChoosenColor != robotDefaultColor)
                this.colorPickerDialog.Color = robotChoosenColor;
            else
                this.colorPickerDialog.Color = robotDefaultColor;

            // Show dialog
            this.colorPickerDialog.ShowDialog();

            // Apply changes when changed
            if (this.colorPickerDialog.ShowDialog() == DialogResult.OK)
                this.robotColorPictureBox.BackColor = this.colorPickerDialog.Color;
        }
        private void defaultRobotColorButton_Click(object sender, EventArgs e)
        {
            this.colorPickerDialog.Color = robotDefaultColor;
            robotChoosenColor = robotDefaultColor;
        }
        private void changeObstacleColorButton_Click(object sender, EventArgs e)
        {
            // Set selected color if it was selected
            if (obstacleChoosenColor != obstacleDefaultColor)
                this.colorPickerDialog.Color = obstacleChoosenColor;
            else
                this.colorPickerDialog.Color = obstacleDefaultColor;

            // Show dialog
            this.colorPickerDialog.ShowDialog();

            // Apply changes when changed
            if(this.colorPickerDialog.ShowDialog() == DialogResult.OK)
                this.obstaclesColorPictureBox.BackColor = this.colorPickerDialog.Color;
        }
        private void defaultObstacleColorButton_Click(object sender, EventArgs e)
        {
            this.colorPickerDialog.Color = obstacleDefaultColor;
            obstacleChoosenColor = obstacleDefaultColor;
        }

        // Some methods
        private bool WriteConfiguration(FileStream f)
        {
            if (f.CanWrite)
            {
                f.Close();
                return true;
            }
            return false;
        }
        private void ReadConfiguration(string path)
        {
            // If conf file doesn't exist, create and fill it
            if (!File.Exists(path))
            {
                SetDefaultValues();
                //WriteConfiguration(f);
            }

            //TO DO: Read conf file and set values
        }
        private void SetDefaultValues()
        {
            // Network setting
            this.localhost.Checked = true;
            this.localNetwork.Checked = false;

            // Network conf
            this.ip0TextBox.Text = "";
            this.ip1TextBox.Text = "";
            this.ip2TextBox.Text = "";
            this.ip3TextBox.Text = "";
            this.portTextBox.Text = "";

            // Disable ip & port text box
            toggleIPConf(false);
        }
        private void toggleIPConf(bool value)
        {
            this.ipLabel.Enabled = value;
            this.ip0TextBox.Enabled = value;
            this.label1.Enabled = value;
            this.ip1TextBox.Enabled = value;
            this.label2.Enabled = value;
            this.ip2TextBox.Enabled = value;
            this.label3.Enabled = value;
            this.ip3TextBox.Enabled = value;
            this.portLabel.Enabled = value;
            this.portTextBox.Enabled = value;
        }
    }
}

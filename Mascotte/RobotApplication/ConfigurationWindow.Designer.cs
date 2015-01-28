namespace RobotApplication
{
    partial class ConfigurationWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.serverBox = new System.Windows.Forms.GroupBox();
            this.portTextBox = new System.Windows.Forms.TextBox();
            this.portLabel = new System.Windows.Forms.Label();
            this.ip3TextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.ip2TextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.ip1TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ip0TextBox = new System.Windows.Forms.TextBox();
            this.ipLabel = new System.Windows.Forms.Label();
            this.serverLocationLabel = new System.Windows.Forms.Label();
            this.localhost = new System.Windows.Forms.RadioButton();
            this.localNetwork = new System.Windows.Forms.RadioButton();
            this.importConfFileButton = new System.Windows.Forms.Button();
            this.exportConfFileButton = new System.Windows.Forms.Button();
            this.importConfFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.exportConfFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.colorBox = new System.Windows.Forms.GroupBox();
            this.robotColorLabel = new System.Windows.Forms.Label();
            this.colorPickerDialog = new System.Windows.Forms.ColorDialog();
            this.changeRobotColorButton = new System.Windows.Forms.Button();
            this.robotColorPictureBox = new System.Windows.Forms.PictureBox();
            this.defaultRobotColorButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.obstaclesColorPictureBox = new System.Windows.Forms.PictureBox();
            this.changeObstacleColorButton = new System.Windows.Forms.Button();
            this.defaultObstacleColorButton = new System.Windows.Forms.Button();
            this.serverBox.SuspendLayout();
            this.colorBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.robotColorPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.obstaclesColorPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // saveButton
            // 
            this.saveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.saveButton.Location = new System.Drawing.Point(216, 181);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "OK";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelButton.Location = new System.Drawing.Point(297, 181);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = "Annuler";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // serverBox
            // 
            this.serverBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.serverBox.Controls.Add(this.portTextBox);
            this.serverBox.Controls.Add(this.portLabel);
            this.serverBox.Controls.Add(this.ip3TextBox);
            this.serverBox.Controls.Add(this.label3);
            this.serverBox.Controls.Add(this.ip2TextBox);
            this.serverBox.Controls.Add(this.label2);
            this.serverBox.Controls.Add(this.ip1TextBox);
            this.serverBox.Controls.Add(this.label1);
            this.serverBox.Controls.Add(this.ip0TextBox);
            this.serverBox.Controls.Add(this.ipLabel);
            this.serverBox.Controls.Add(this.serverLocationLabel);
            this.serverBox.Controls.Add(this.localhost);
            this.serverBox.Controls.Add(this.localNetwork);
            this.serverBox.Location = new System.Drawing.Point(12, 12);
            this.serverBox.Name = "serverBox";
            this.serverBox.Size = new System.Drawing.Size(360, 74);
            this.serverBox.TabIndex = 2;
            this.serverBox.TabStop = false;
            this.serverBox.Text = "Serveur";
            // 
            // portTextBox
            // 
            this.portTextBox.Enabled = false;
            this.portTextBox.Location = new System.Drawing.Point(249, 41);
            this.portTextBox.Name = "portTextBox";
            this.portTextBox.Size = new System.Drawing.Size(47, 20);
            this.portTextBox.TabIndex = 12;
            // 
            // portLabel
            // 
            this.portLabel.AutoSize = true;
            this.portLabel.Enabled = false;
            this.portLabel.Location = new System.Drawing.Point(211, 44);
            this.portLabel.Name = "portLabel";
            this.portLabel.Size = new System.Drawing.Size(32, 13);
            this.portLabel.TabIndex = 11;
            this.portLabel.Text = "Port :";
            // 
            // ip3TextBox
            // 
            this.ip3TextBox.Enabled = false;
            this.ip3TextBox.Location = new System.Drawing.Point(173, 41);
            this.ip3TextBox.Name = "ip3TextBox";
            this.ip3TextBox.Size = new System.Drawing.Size(32, 20);
            this.ip3TextBox.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Enabled = false;
            this.label3.Location = new System.Drawing.Point(161, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(10, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = ".";
            // 
            // ip2TextBox
            // 
            this.ip2TextBox.Enabled = false;
            this.ip2TextBox.Location = new System.Drawing.Point(127, 41);
            this.ip2TextBox.Name = "ip2TextBox";
            this.ip2TextBox.Size = new System.Drawing.Size(32, 20);
            this.ip2TextBox.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Enabled = false;
            this.label2.Location = new System.Drawing.Point(115, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(10, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = ".";
            // 
            // ip1TextBox
            // 
            this.ip1TextBox.Enabled = false;
            this.ip1TextBox.Location = new System.Drawing.Point(81, 41);
            this.ip1TextBox.Name = "ip1TextBox";
            this.ip1TextBox.Size = new System.Drawing.Size(32, 20);
            this.ip1TextBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Enabled = false;
            this.label1.Location = new System.Drawing.Point(69, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(10, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = ".";
            // 
            // ip0TextBox
            // 
            this.ip0TextBox.Enabled = false;
            this.ip0TextBox.Location = new System.Drawing.Point(35, 41);
            this.ip0TextBox.Name = "ip0TextBox";
            this.ip0TextBox.Size = new System.Drawing.Size(32, 20);
            this.ip0TextBox.TabIndex = 4;
            // 
            // ipLabel
            // 
            this.ipLabel.AutoSize = true;
            this.ipLabel.Enabled = false;
            this.ipLabel.Location = new System.Drawing.Point(6, 44);
            this.ipLabel.Name = "ipLabel";
            this.ipLabel.Size = new System.Drawing.Size(23, 13);
            this.ipLabel.TabIndex = 3;
            this.ipLabel.Text = "IP :";
            // 
            // serverLocationLabel
            // 
            this.serverLocationLabel.AutoSize = true;
            this.serverLocationLabel.Location = new System.Drawing.Point(6, 21);
            this.serverLocationLabel.Name = "serverLocationLabel";
            this.serverLocationLabel.Size = new System.Drawing.Size(130, 13);
            this.serverLocationLabel.TabIndex = 2;
            this.serverLocationLabel.Text = "Emplacement du serveur :";
            // 
            // localhost
            // 
            this.localhost.AutoSize = true;
            this.localhost.Checked = true;
            this.localhost.Location = new System.Drawing.Point(142, 19);
            this.localhost.Name = "localhost";
            this.localhost.Size = new System.Drawing.Size(51, 17);
            this.localhost.TabIndex = 0;
            this.localhost.TabStop = true;
            this.localhost.Text = "Local";
            this.localhost.UseVisualStyleBackColor = true;
            // 
            // localNetwork
            // 
            this.localNetwork.AutoSize = true;
            this.localNetwork.Location = new System.Drawing.Point(199, 19);
            this.localNetwork.Name = "localNetwork";
            this.localNetwork.Size = new System.Drawing.Size(58, 17);
            this.localNetwork.TabIndex = 1;
            this.localNetwork.TabStop = true;
            this.localNetwork.Text = "Distant";
            this.localNetwork.UseVisualStyleBackColor = true;
            this.localNetwork.CheckedChanged += new System.EventHandler(this.localNetwork_CheckedChanged);
            // 
            // importConfFileButton
            // 
            this.importConfFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.importConfFileButton.Location = new System.Drawing.Point(12, 181);
            this.importConfFileButton.Name = "importConfFileButton";
            this.importConfFileButton.Size = new System.Drawing.Size(75, 23);
            this.importConfFileButton.TabIndex = 3;
            this.importConfFileButton.Text = "Importer";
            this.importConfFileButton.UseVisualStyleBackColor = true;
            this.importConfFileButton.Click += new System.EventHandler(this.importConfFileButton_Click);
            // 
            // exportConfFileButton
            // 
            this.exportConfFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.exportConfFileButton.Location = new System.Drawing.Point(93, 181);
            this.exportConfFileButton.Name = "exportConfFileButton";
            this.exportConfFileButton.Size = new System.Drawing.Size(75, 23);
            this.exportConfFileButton.TabIndex = 4;
            this.exportConfFileButton.Text = "Exporter";
            this.exportConfFileButton.UseVisualStyleBackColor = true;
            this.exportConfFileButton.Click += new System.EventHandler(this.exportConfFileButton_Click);
            // 
            // importConfFileDialog
            // 
            this.importConfFileDialog.Title = "Importer une configuration";
            this.importConfFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.importConfFileDialog_FileOk);
            // 
            // exportConfFileDialog
            // 
            this.exportConfFileDialog.Title = "Exporter la configuration";
            this.exportConfFileDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.exportConfFileDialog_FileOk);
            // 
            // colorBox
            // 
            this.colorBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.colorBox.Controls.Add(this.defaultObstacleColorButton);
            this.colorBox.Controls.Add(this.changeObstacleColorButton);
            this.colorBox.Controls.Add(this.obstaclesColorPictureBox);
            this.colorBox.Controls.Add(this.label4);
            this.colorBox.Controls.Add(this.defaultRobotColorButton);
            this.colorBox.Controls.Add(this.robotColorPictureBox);
            this.colorBox.Controls.Add(this.changeRobotColorButton);
            this.colorBox.Controls.Add(this.robotColorLabel);
            this.colorBox.Location = new System.Drawing.Point(12, 92);
            this.colorBox.Name = "colorBox";
            this.colorBox.Size = new System.Drawing.Size(360, 74);
            this.colorBox.TabIndex = 13;
            this.colorBox.TabStop = false;
            this.colorBox.Text = "Couleurs";
            // 
            // robotColorLabel
            // 
            this.robotColorLabel.AutoSize = true;
            this.robotColorLabel.Location = new System.Drawing.Point(6, 21);
            this.robotColorLabel.Name = "robotColorLabel";
            this.robotColorLabel.Size = new System.Drawing.Size(91, 13);
            this.robotColorLabel.TabIndex = 2;
            this.robotColorLabel.Text = "Couleur du robot :";
            // 
            // changeRobotColorButton
            // 
            this.changeRobotColorButton.Location = new System.Drawing.Point(164, 16);
            this.changeRobotColorButton.Name = "changeRobotColorButton";
            this.changeRobotColorButton.Size = new System.Drawing.Size(75, 23);
            this.changeRobotColorButton.TabIndex = 3;
            this.changeRobotColorButton.Text = "Changer";
            this.changeRobotColorButton.UseVisualStyleBackColor = true;
            this.changeRobotColorButton.Click += new System.EventHandler(this.changeRobotColorButton_Click);
            // 
            // robotColorPictureBox
            // 
            this.robotColorPictureBox.BackColor = System.Drawing.Color.Red;
            this.robotColorPictureBox.Location = new System.Drawing.Point(129, 19);
            this.robotColorPictureBox.Name = "robotColorPictureBox";
            this.robotColorPictureBox.Size = new System.Drawing.Size(20, 20);
            this.robotColorPictureBox.TabIndex = 4;
            this.robotColorPictureBox.TabStop = false;
            // 
            // defaultRobotColorButton
            // 
            this.defaultRobotColorButton.Location = new System.Drawing.Point(249, 16);
            this.defaultRobotColorButton.Name = "defaultRobotColorButton";
            this.defaultRobotColorButton.Size = new System.Drawing.Size(75, 23);
            this.defaultRobotColorButton.TabIndex = 5;
            this.defaultRobotColorButton.Text = "Défaut";
            this.defaultRobotColorButton.UseVisualStyleBackColor = true;
            this.defaultRobotColorButton.Click += new System.EventHandler(this.defaultRobotColorButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 46);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Couleur des obstacles :";
            // 
            // obstaclesColorPictureBox
            // 
            this.obstaclesColorPictureBox.BackColor = System.Drawing.Color.Black;
            this.obstaclesColorPictureBox.Location = new System.Drawing.Point(129, 44);
            this.obstaclesColorPictureBox.Name = "obstaclesColorPictureBox";
            this.obstaclesColorPictureBox.Size = new System.Drawing.Size(20, 20);
            this.obstaclesColorPictureBox.TabIndex = 7;
            this.obstaclesColorPictureBox.TabStop = false;
            // 
            // changeObstacleColorButton
            // 
            this.changeObstacleColorButton.Location = new System.Drawing.Point(164, 41);
            this.changeObstacleColorButton.Name = "changeObstacleColorButton";
            this.changeObstacleColorButton.Size = new System.Drawing.Size(75, 23);
            this.changeObstacleColorButton.TabIndex = 8;
            this.changeObstacleColorButton.Text = "Changer";
            this.changeObstacleColorButton.UseVisualStyleBackColor = true;
            this.changeObstacleColorButton.Click += new System.EventHandler(this.changeObstacleColorButton_Click);
            // 
            // defaultObstacleColorButton
            // 
            this.defaultObstacleColorButton.Location = new System.Drawing.Point(249, 41);
            this.defaultObstacleColorButton.Name = "defaultObstacleColorButton";
            this.defaultObstacleColorButton.Size = new System.Drawing.Size(75, 23);
            this.defaultObstacleColorButton.TabIndex = 9;
            this.defaultObstacleColorButton.Text = "Défaut";
            this.defaultObstacleColorButton.UseVisualStyleBackColor = true;
            this.defaultObstacleColorButton.Click += new System.EventHandler(this.defaultObstacleColorButton_Click);
            // 
            // ConfigurationWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 216);
            this.Controls.Add(this.colorBox);
            this.Controls.Add(this.serverBox);
            this.Controls.Add(this.exportConfFileButton);
            this.Controls.Add(this.importConfFileButton);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ConfigurationWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Configuration";
            this.serverBox.ResumeLayout(false);
            this.serverBox.PerformLayout();
            this.colorBox.ResumeLayout(false);
            this.colorBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.robotColorPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.obstaclesColorPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.GroupBox serverBox;
        private System.Windows.Forms.Label serverLocationLabel;
        private System.Windows.Forms.RadioButton localhost;
        private System.Windows.Forms.RadioButton localNetwork;
        private System.Windows.Forms.TextBox portTextBox;
        private System.Windows.Forms.Label portLabel;
        private System.Windows.Forms.TextBox ip3TextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox ip2TextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox ip1TextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ip0TextBox;
        private System.Windows.Forms.Label ipLabel;
        private System.Windows.Forms.Button importConfFileButton;
        private System.Windows.Forms.Button exportConfFileButton;
        private System.Windows.Forms.OpenFileDialog importConfFileDialog;
        private System.Windows.Forms.SaveFileDialog exportConfFileDialog;
        private System.Windows.Forms.GroupBox colorBox;
        private System.Windows.Forms.Button defaultObstacleColorButton;
        private System.Windows.Forms.Button changeObstacleColorButton;
        private System.Windows.Forms.PictureBox obstaclesColorPictureBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button defaultRobotColorButton;
        private System.Windows.Forms.PictureBox robotColorPictureBox;
        private System.Windows.Forms.Button changeRobotColorButton;
        private System.Windows.Forms.Label robotColorLabel;
        private System.Windows.Forms.ColorDialog colorPickerDialog;
    }
}
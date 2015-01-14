﻿namespace RobotServer
{
    partial class RobotServerApp
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RobotServerApp));
            this.datasStatusStrip = new System.Windows.Forms.StatusStrip();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.applicationStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sauvegarderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chargerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mapPanel = new System.Windows.Forms.Panel();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.controlBox = new System.Windows.Forms.GroupBox();
            this.speedBox = new System.Windows.Forms.GroupBox();
            this.speedBar = new System.Windows.Forms.TrackBar();
            this.speedTextBox = new System.Windows.Forms.TextBox();
            this.robotAngleTextBox = new System.Windows.Forms.TextBox();
            this.robotAngleLabel = new System.Windows.Forms.Label();
            this.pauseButton = new System.Windows.Forms.Button();
            this.actualMovement = new System.Windows.Forms.PictureBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.directionTurnRightButton = new System.Windows.Forms.Button();
            this.directionDownButton = new System.Windows.Forms.Button();
            this.directionTurnLeftButton = new System.Windows.Forms.Button();
            this.directionTopButton = new System.Windows.Forms.Button();
            this.contentTabControl = new System.Windows.Forms.TabControl();
            this.mapTab = new System.Windows.Forms.TabPage();
            this.cameraTab = new System.Windows.Forms.TabPage();
            this.connectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.datasStatusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.controlPanel.SuspendLayout();
            this.controlBox.SuspendLayout();
            this.speedBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.actualMovement)).BeginInit();
            this.contentTabControl.SuspendLayout();
            this.mapTab.SuspendLayout();
            this.SuspendLayout();
            // 
            // datasStatusStrip
            // 
            this.datasStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionStatus});
            this.datasStatusStrip.Name = "datasStatusStrip";
            this.datasStatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.datasStatusStrip.Size = new System.Drawing.Size(983, 22);
            this.datasStatusStrip.TabIndex = 0;
            this.datasStatusStrip.Text = "Status";
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationStripMenu,
            this.carteToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip.Size = new System.Drawing.Size(983, 28);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "Menus";
            // 
            // applicationStripMenu
            // 
            this.applicationStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitterToolStripMenuItem});
            this.applicationStripMenu.Name = "applicationStripMenu";
            this.applicationStripMenu.Size = new System.Drawing.Size(98, 24);
            this.applicationStripMenu.Text = "Application";
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.quitterToolStripMenuItem.Text = "Quitter";
            // 
            // carteToolStripMenuItem
            // 
            this.carteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sauvegarderToolStripMenuItem,
            this.chargerToolStripMenuItem});
            this.carteToolStripMenuItem.Name = "carteToolStripMenuItem";
            this.carteToolStripMenuItem.Size = new System.Drawing.Size(56, 24);
            this.carteToolStripMenuItem.Text = "Carte";
            // 
            // sauvegarderToolStripMenuItem
            // 
            this.sauvegarderToolStripMenuItem.Name = "sauvegarderToolStripMenuItem";
            this.sauvegarderToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.sauvegarderToolStripMenuItem.Text = "Sauvegarder";
            // 
            // chargerToolStripMenuItem
            // 
            this.chargerToolStripMenuItem.Name = "chargerToolStripMenuItem";
            this.chargerToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.chargerToolStripMenuItem.Text = "Charger";
            // 
            // mapPanel
            // 
            this.mapPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapPanel.Location = new System.Drawing.Point(3, 3);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(470, 438);
            this.mapPanel.TabIndex = 2;
            // 
            // controlPanel
            // 
            this.controlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlPanel.Controls.Add(this.controlBox);
            this.controlPanel.Location = new System.Drawing.Point(490, 24);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(247, 470);
            this.controlPanel.TabIndex = 3;
            // 
            this.controlPanel.Size = new System.Drawing.Size(329, 578);
            this.controlPanel.TabIndex = 3;
            // 
            // controlBox
            // 
            this.controlBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.controlBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.controlBox.Controls.Add(this.speedBox);
            this.controlBox.Controls.Add(this.robotAngleTextBox);
            this.controlBox.Controls.Add(this.robotAngleLabel);
            this.controlBox.Controls.Add(this.pauseButton);
            this.controlBox.Controls.Add(this.actualMovement);
            this.controlBox.Controls.Add(this.stopButton);
            this.controlBox.Controls.Add(this.startButton);
            this.controlBox.Controls.Add(this.directionTurnRightButton);
            this.controlBox.Controls.Add(this.directionDownButton);
            this.controlBox.Controls.Add(this.directionTurnLeftButton);
            this.controlBox.Controls.Add(this.directionTopButton);
            this.controlBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.controlBox.Location = new System.Drawing.Point(4, 4);
            this.controlBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.controlBox.Name = "controlBox";
            this.controlBox.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.controlBox.Size = new System.Drawing.Size(321, 327);
            this.controlBox.TabIndex = 5;
            this.controlBox.TabStop = false;
            this.controlBox.Text = "Contrôle";
            // 
            // speedBox
            // 
            this.speedBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.speedBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.speedBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.speedBox.Controls.Add(this.speedBar);
            this.speedBox.Controls.Add(this.speedTextBox);
            this.speedBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.speedBox.Location = new System.Drawing.Point(6, 175);
            this.speedBox.Name = "speedBox";
            this.speedBox.Size = new System.Drawing.Size(229, 60);
            this.speedBox.TabIndex = 6;
            this.speedBox.TabStop = false;
            this.speedBox.Text = "Vitesse";
            // 
            // speedBar
            // 
            this.speedBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.speedBar.AutoSize = false;
            this.speedBar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.speedBar.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.speedBar.LargeChange = 10;
            this.speedBar.Location = new System.Drawing.Point(6, 19);
            this.speedBar.Maximum = 100;
            this.speedBar.Name = "speedBar";
            this.speedBar.Size = new System.Drawing.Size(170, 20);
            this.speedBar.SmallChange = 5;
            this.speedBar.TabIndex = 0;
            this.speedBar.TickFrequency = 10;
            // 
            // speedTextBox
            // 
            this.speedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.speedTextBox.Location = new System.Drawing.Point(190, 19);
            this.speedTextBox.Name = "speedTextBox";
            this.speedTextBox.Size = new System.Drawing.Size(33, 20);
            this.speedTextBox.TabIndex = 1;
            this.speedTextBox.Text = "0";
            // 
            this.speedTextBox.Size = new System.Drawing.Size(43, 22);
            this.speedTextBox.TabIndex = 1;
            this.speedTextBox.Text = "0";
            // 
            // robotAngleTextBox
            // 
            this.robotAngleTextBox.BackColor = System.Drawing.SystemColors.HighlightText;
            this.robotAngleTextBox.Location = new System.Drawing.Point(148, 294);
            this.robotAngleTextBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.robotAngleTextBox.Name = "robotAngleTextBox";
            this.robotAngleTextBox.ReadOnly = true;
            this.robotAngleTextBox.Size = new System.Drawing.Size(40, 22);
            this.robotAngleTextBox.TabIndex = 9;
            // 
            // robotAngleLabel
            // 
            this.robotAngleLabel.AutoSize = true;
            this.robotAngleLabel.Location = new System.Drawing.Point(12, 298);
            this.robotAngleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.robotAngleLabel.Name = "robotAngleLabel";
            this.robotAngleLabel.Size = new System.Drawing.Size(134, 17);
            this.robotAngleLabel.TabIndex = 8;
            this.robotAngleLabel.Text = "Angle de direction : ";
            // 
            // pauseButton
            // 
            this.pauseButton.Image = global::RobotServer.Properties.Resources.pause;
            this.pauseButton.Location = new System.Drawing.Point(148, 170);
            this.pauseButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(40, 37);
            this.pauseButton.TabIndex = 7;
            this.pauseButton.UseVisualStyleBackColor = true;
            // 
            // actualMovement
            // 
            this.actualMovement.Location = new System.Drawing.Point(148, 73);
            this.actualMovement.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.actualMovement.Name = "actualMovement";
            this.actualMovement.Size = new System.Drawing.Size(40, 37);
            this.actualMovement.TabIndex = 7;
            this.actualMovement.TabStop = false;
            // 
            // stopButton
            // 
            this.stopButton.Image = global::RobotServer.Properties.Resources.stop;
            this.stopButton.Location = new System.Drawing.Point(87, 170);
            this.stopButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(40, 37);
            this.stopButton.TabIndex = 6;
            this.stopButton.UseVisualStyleBackColor = true;
            // 
            // startButton
            // 
            this.startButton.Image = global::RobotServer.Properties.Resources.start;
            this.startButton.Location = new System.Drawing.Point(212, 170);
            this.startButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(40, 37);
            this.startButton.TabIndex = 5;
            this.startButton.UseVisualStyleBackColor = true;
            // 
            // directionTurnRightButton
            // 
            this.directionTurnRightButton.Image = global::RobotServer.Properties.Resources.arrowTurnRight;
            this.directionTurnRightButton.Location = new System.Drawing.Point(212, 73);
            this.directionTurnRightButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.directionTurnRightButton.Name = "directionTurnRightButton";
            this.directionTurnRightButton.Size = new System.Drawing.Size(40, 37);
            this.directionTurnRightButton.TabIndex = 3;
            this.directionTurnRightButton.UseVisualStyleBackColor = true;
            // 
            // directionDownButton
            // 
            this.directionDownButton.Image = global::RobotServer.Properties.Resources.arrowDown;
            this.directionDownButton.Location = new System.Drawing.Point(148, 126);
            this.directionDownButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.directionDownButton.Name = "directionDownButton";
            this.directionDownButton.Size = new System.Drawing.Size(40, 37);
            this.directionDownButton.TabIndex = 2;
            this.directionDownButton.UseVisualStyleBackColor = true;
            // 
            // directionTurnLeftButton
            // 
            this.directionTurnLeftButton.Image = global::RobotServer.Properties.Resources.arrowTurnLeft;
            this.directionTurnLeftButton.Location = new System.Drawing.Point(87, 73);
            this.directionTurnLeftButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.directionTurnLeftButton.Name = "directionTurnLeftButton";
            this.directionTurnLeftButton.Size = new System.Drawing.Size(40, 37);
            this.directionTurnLeftButton.TabIndex = 1;
            this.directionTurnLeftButton.UseVisualStyleBackColor = true;
            // 
            // directionTopButton
            // 
            this.directionTopButton.Image = global::RobotServer.Properties.Resources.arrowUp;
            this.directionTopButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.directionTopButton.Location = new System.Drawing.Point(148, 20);
            this.directionTopButton.Margin = new System.Windows.Forms.Padding(0);
            this.directionTopButton.Name = "directionTopButton";
            this.directionTopButton.Size = new System.Drawing.Size(40, 37);
            this.directionTopButton.TabIndex = 0;
            this.directionTopButton.UseVisualStyleBackColor = true;
            // 
            // contentTabControl
            // 
            this.contentTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentTabControl.Controls.Add(this.mapTab);
            this.contentTabControl.Controls.Add(this.cameraTab);
            this.contentTabControl.Location = new System.Drawing.Point(0, 30);
            this.contentTabControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.contentTabControl.Name = "contentTabControl";
            this.contentTabControl.SelectedIndex = 0;
            this.contentTabControl.Size = new System.Drawing.Size(645, 578);
            this.contentTabControl.TabIndex = 4;
            // 
            // mapTab
            // 
            this.mapTab.Controls.Add(this.mapPanel);
            this.mapTab.Location = new System.Drawing.Point(4, 25);
            this.mapTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mapTab.Name = "mapTab";
            this.mapTab.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.mapTab.Size = new System.Drawing.Size(637, 549);
            this.mapTab.TabIndex = 0;
            this.mapTab.Text = "Carte";
            this.mapTab.UseVisualStyleBackColor = true;
            // 
            // cameraTab
            // 
            this.cameraTab.Location = new System.Drawing.Point(4, 25);
            this.cameraTab.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cameraTab.Name = "cameraTab";
            this.cameraTab.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cameraTab.Size = new System.Drawing.Size(476, 444);
            this.cameraTab.TabIndex = 1;
            this.cameraTab.Text = "Caméra";
            this.cameraTab.UseVisualStyleBackColor = true;
            // 
            // connectionStatus
            // 
            this.connectionStatus.Image = global::RobotServer.Properties.Resources.networkOff;
            this.connectionStatus.Name = "connectionStatus";
            this.connectionStatus.Size = new System.Drawing.Size(135, 17);
            this.connectionStatus.Text = "Status de connexion :";
            this.connectionStatus.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // RobotServerApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 635);
            this.Controls.Add(this.contentTabControl);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.datasStatusStrip);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RobotServerApp";
            this.Text = "Netduino Control Server";
            this.datasStatusStrip.ResumeLayout(false);
            this.datasStatusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.controlPanel.ResumeLayout(false);
            this.controlBox.ResumeLayout(false);
            this.controlBox.PerformLayout();
            this.speedBox.ResumeLayout(false);
            this.speedBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.actualMovement)).EndInit();
            this.contentTabControl.ResumeLayout(false);
            this.mapTab.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip datasStatusStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem applicationStripMenu;
        private System.Windows.Forms.Panel mapPanel;
        private System.Windows.Forms.Panel controlPanel;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem carteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem sauvegarderToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem chargerToolStripMenuItem;
        private System.Windows.Forms.GroupBox controlBox;
        private System.Windows.Forms.TextBox robotAngleTextBox;
        private System.Windows.Forms.Label robotAngleLabel;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.PictureBox actualMovement;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button directionTurnRightButton;
        private System.Windows.Forms.Button directionDownButton;
        private System.Windows.Forms.Button directionTurnLeftButton;
        private System.Windows.Forms.Button directionTopButton;
        private System.Windows.Forms.GroupBox speedBox;
        private System.Windows.Forms.TrackBar speedBar;
        private System.Windows.Forms.TextBox speedTextBox;
        private System.Windows.Forms.TabControl contentTabControl;
        private System.Windows.Forms.TabPage mapTab;
        private System.Windows.Forms.TabPage cameraTab;
        private System.Windows.Forms.ToolStripStatusLabel connectionStatus;
    }
}


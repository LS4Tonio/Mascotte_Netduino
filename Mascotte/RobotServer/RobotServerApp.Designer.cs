namespace RobotServer
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
            this.connectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.applicationStripMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.carteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sauvegarderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.chargerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.controlPanel = new System.Windows.Forms.Panel();
            this.controlBox = new System.Windows.Forms.GroupBox();
            this.speedBar = new System.Windows.Forms.TrackBar();
            this.speedBox = new System.Windows.Forms.GroupBox();
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
            this.loadMapDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveMapDialog = new System.Windows.Forms.SaveFileDialog();
            this.mapTab = new System.Windows.Forms.TabPage();
            this.mapPanel = new System.Windows.Forms.Panel();
            this.contentTabControl = new System.Windows.Forms.TabControl();
            this.datasStatusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.controlPanel.SuspendLayout();
            this.controlBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).BeginInit();
            this.speedBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actualMovement)).BeginInit();
            this.mapTab.SuspendLayout();
            this.contentTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // datasStatusStrip
            // 
            this.datasStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionStatus});
            this.datasStatusStrip.Location = new System.Drawing.Point(0, 610);
            this.datasStatusStrip.Name = "datasStatusStrip";
            this.datasStatusStrip.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.datasStatusStrip.Size = new System.Drawing.Size(983, 25);
            this.datasStatusStrip.TabIndex = 0;
            this.datasStatusStrip.Text = "Status";
            // 
            // connectionStatus
            // 
            this.connectionStatus.Image = global::RobotServer.Properties.Resources.networkOff;
            this.connectionStatus.Name = "connectionStatus";
            this.connectionStatus.Size = new System.Drawing.Size(165, 20);
            this.connectionStatus.Text = "Status de connexion :";
            this.connectionStatus.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
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
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(124, 24);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
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
            this.sauvegarderToolStripMenuItem.Size = new System.Drawing.Size(161, 24);
            this.sauvegarderToolStripMenuItem.Text = "Sauvegarder";
            this.sauvegarderToolStripMenuItem.Click += new System.EventHandler(this.sauvegarderToolStripMenuItem_Click);
            // 
            // chargerToolStripMenuItem
            // 
            this.chargerToolStripMenuItem.Name = "chargerToolStripMenuItem";
            this.chargerToolStripMenuItem.Size = new System.Drawing.Size(161, 24);
            this.chargerToolStripMenuItem.Text = "Charger";
            this.chargerToolStripMenuItem.Click += new System.EventHandler(this.chargerToolStripMenuItem_Click);
            // 
            // controlPanel
            // 
            this.controlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlPanel.Controls.Add(this.controlBox);
            this.controlPanel.Location = new System.Drawing.Point(648, 55);
            this.controlPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(329, 549);
            this.controlPanel.TabIndex = 3;
            // 
            // controlBox
            // 
            this.controlBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.controlBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.controlBox.Controls.Add(this.speedBar);
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
            // speedBar
            // 
            this.speedBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.speedBar.AutoSize = false;
            this.speedBar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.speedBar.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.speedBar.LargeChange = 10;
            this.speedBar.Location = new System.Drawing.Point(19, 241);
            this.speedBar.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.speedBar.Maximum = 100;
            this.speedBar.Name = "speedBar";
            this.speedBar.Size = new System.Drawing.Size(241, 41);
            this.speedBar.SmallChange = 5;
            this.speedBar.TabIndex = 0;
            this.speedBar.TickFrequency = 10;
            // 
            // speedBox
            // 
            this.speedBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.speedBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.speedBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.speedBox.Controls.Add(this.speedTextBox);
            this.speedBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.speedBox.Location = new System.Drawing.Point(7, 226);
            this.speedBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.speedBox.Name = "speedBox";
            this.speedBox.Padding = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.speedBox.Size = new System.Drawing.Size(308, 60);
            this.speedBox.TabIndex = 6;
            this.speedBox.TabStop = false;
            this.speedBox.Text = "Vitesse";
            // 
            // speedTextBox
            // 
            this.speedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.speedTextBox.Location = new System.Drawing.Point(255, 23);
            this.speedTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.speedTextBox.Name = "speedTextBox";
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
            this.directionTurnRightButton.Click += new System.EventHandler(this.directionTurnRightButton_Click);
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
            this.directionTurnLeftButton.Click += new System.EventHandler(this.directionTurnLeftButton_Click);
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
            this.directionTopButton.Click += new System.EventHandler(this.directionTopButton_Click);
            // 
            // loadMapDialog
            // 
            this.loadMapDialog.FileName = "openFileDialog1";
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
            // mapPanel
            // 
            this.mapPanel.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.mapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mapPanel.Location = new System.Drawing.Point(4, 4);
            this.mapPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.mapPanel.Name = "mapPanel";
            this.mapPanel.Size = new System.Drawing.Size(629, 541);
            this.mapPanel.TabIndex = 2;
            // 
            // contentTabControl
            // 
            this.contentTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.contentTabControl.Controls.Add(this.mapTab);
            this.contentTabControl.Location = new System.Drawing.Point(0, 30);
            this.contentTabControl.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.contentTabControl.Name = "contentTabControl";
            this.contentTabControl.SelectedIndex = 0;
            this.contentTabControl.Size = new System.Drawing.Size(645, 578);
            this.contentTabControl.TabIndex = 4;
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
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RobotServerApp_FormClosing);
            this.datasStatusStrip.ResumeLayout(false);
            this.datasStatusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.controlPanel.ResumeLayout(false);
            this.controlBox.ResumeLayout(false);
            this.controlBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).EndInit();
            this.speedBox.ResumeLayout(false);
            this.speedBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actualMovement)).EndInit();
            this.mapTab.ResumeLayout(false);
            this.contentTabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip datasStatusStrip;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem applicationStripMenu;
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
        private System.Windows.Forms.ToolStripStatusLabel connectionStatus;
        private System.Windows.Forms.OpenFileDialog loadMapDialog;
        private System.Windows.Forms.SaveFileDialog saveMapDialog;
        private System.Windows.Forms.TabPage mapTab;
        private System.Windows.Forms.Panel mapPanel;
        private System.Windows.Forms.TabControl contentTabControl;
    }
}


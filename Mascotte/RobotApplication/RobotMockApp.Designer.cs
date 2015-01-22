namespace RobotApplication
{
    partial class RobotMockApp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RobotMockApp));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.connectionStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.robotStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip = new System.Windows.Forms.ToolStrip();
            this.applicationStripMenu = new System.Windows.Forms.ToolStripDropDownButton();
            this.loadMapMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMapMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.quitMenuButton = new System.Windows.Forms.ToolStripMenuItem();
            this.configureMenuButton = new System.Windows.Forms.ToolStripButton();
            this.controlPanel = new System.Windows.Forms.GroupBox();
            this.rectangleBox = new System.Windows.Forms.GroupBox();
            this.emptyRectangleButton = new System.Windows.Forms.Button();
            this.yLabel = new System.Windows.Forms.Label();
            this.xLabel = new System.Windows.Forms.Label();
            this.yTextBox = new System.Windows.Forms.TextBox();
            this.xTextBox = new System.Windows.Forms.TextBox();
            this.fillRectangleButton = new System.Windows.Forms.Button();
            this.mapBox = new System.Windows.Forms.GroupBox();
            this.forceSendButton = new System.Windows.Forms.Button();
            this.forceGetMapButton = new System.Windows.Forms.Button();
            this.directionBox = new System.Windows.Forms.GroupBox();
            this.robotAngleTextBox = new System.Windows.Forms.TextBox();
            this.robotAngleLabel = new System.Windows.Forms.Label();
            this.pauseButton = new System.Windows.Forms.Button();
            this.actualDirection = new System.Windows.Forms.PictureBox();
            this.stopButton = new System.Windows.Forms.Button();
            this.startButton = new System.Windows.Forms.Button();
            this.directionTurnRightButton = new System.Windows.Forms.Button();
            this.directionDownButton = new System.Windows.Forms.Button();
            this.directionTurnLeftButton = new System.Windows.Forms.Button();
            this.directionTopButton = new System.Windows.Forms.Button();
            this.speedBox = new System.Windows.Forms.GroupBox();
            this.speedBar = new System.Windows.Forms.TrackBar();
            this.speedTextBox = new System.Windows.Forms.TextBox();
            this.mapsPanel = new System.Windows.Forms.TabControl();
            this.robotMapTab = new System.Windows.Forms.TabPage();
            this.robotMapPanel = new System.Windows.Forms.Panel();
            this.obstaclesMapTab = new System.Windows.Forms.TabPage();
            this.obstacleMapPanel = new System.Windows.Forms.Panel();
            this.obstacleMapPictureBox = new System.Windows.Forms.PictureBox();
            this.loadMapDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveMapDialog = new System.Windows.Forms.SaveFileDialog();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.controlPanel.SuspendLayout();
            this.rectangleBox.SuspendLayout();
            this.mapBox.SuspendLayout();
            this.directionBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actualDirection)).BeginInit();
            this.speedBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).BeginInit();
            this.mapsPanel.SuspendLayout();
            this.robotMapTab.SuspendLayout();
            this.obstaclesMapTab.SuspendLayout();
            this.obstacleMapPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.obstacleMapPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.connectionStatus,
            this.robotStatus});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(657, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "Barre d\'état";
            // 
            // connectionStatus
            // 
            this.connectionStatus.Image = global::RobotApplication.Properties.Resources.networkOff;
            this.connectionStatus.Name = "connectionStatus";
            this.connectionStatus.Size = new System.Drawing.Size(135, 17);
            this.connectionStatus.Text = "Status de connexion :";
            this.connectionStatus.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // robotStatus
            // 
            this.robotStatus.ActiveLinkColor = System.Drawing.Color.Green;
            this.robotStatus.Image = global::RobotApplication.Properties.Resources.stopped;
            this.robotStatus.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.robotStatus.Name = "robotStatus";
            this.robotStatus.Size = new System.Drawing.Size(109, 17);
            this.robotStatus.Text = "Status du robot :";
            this.robotStatus.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.applicationStripMenu,
            this.configureMenuButton});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(657, 25);
            this.menuStrip.TabIndex = 3;
            this.menuStrip.Text = "Menu";
            // 
            // applicationStripMenu
            // 
            this.applicationStripMenu.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.applicationStripMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadMapMenuButton,
            this.saveMapMenuButton,
            this.quitMenuButton});
            this.applicationStripMenu.Image = ((System.Drawing.Image)(resources.GetObject("applicationStripMenu.Image")));
            this.applicationStripMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.applicationStripMenu.Name = "applicationStripMenu";
            this.applicationStripMenu.Size = new System.Drawing.Size(81, 22);
            this.applicationStripMenu.Text = "Application";
            // 
            // loadMapMenuButton
            // 
            this.loadMapMenuButton.Name = "loadMapMenuButton";
            this.loadMapMenuButton.Size = new System.Drawing.Size(168, 22);
            this.loadMapMenuButton.Text = "Charger carte";
            this.loadMapMenuButton.Click += new System.EventHandler(this.loadMapMenuButton_Click);
            // 
            // saveMapMenuButton
            // 
            this.saveMapMenuButton.Name = "saveMapMenuButton";
            this.saveMapMenuButton.Size = new System.Drawing.Size(168, 22);
            this.saveMapMenuButton.Text = "Sauvegarder carte";
            this.saveMapMenuButton.Click += new System.EventHandler(this.saveMapMenuButton_Click);
            // 
            // quitMenuButton
            // 
            this.quitMenuButton.Name = "quitMenuButton";
            this.quitMenuButton.Size = new System.Drawing.Size(168, 22);
            this.quitMenuButton.Text = "Quitter";
            this.quitMenuButton.Click += new System.EventHandler(this.quitMenuButton_Click);
            // 
            // configureMenuButton
            // 
            this.configureMenuButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.configureMenuButton.Image = ((System.Drawing.Image)(resources.GetObject("configureMenuButton.Image")));
            this.configureMenuButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.configureMenuButton.Name = "configureMenuButton";
            this.configureMenuButton.Size = new System.Drawing.Size(68, 22);
            this.configureMenuButton.Text = "Configurer";
            this.configureMenuButton.Click += new System.EventHandler(this.configureMenuButton_Click);
            // 
            // controlPanel
            // 
            this.controlPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlPanel.BackColor = System.Drawing.SystemColors.Control;
            this.controlPanel.Controls.Add(this.rectangleBox);
            this.controlPanel.Controls.Add(this.mapBox);
            this.controlPanel.Controls.Add(this.directionBox);
            this.controlPanel.Controls.Add(this.speedBox);
            this.controlPanel.Location = new System.Drawing.Point(415, 28);
            this.controlPanel.Name = "controlPanel";
            this.controlPanel.Size = new System.Drawing.Size(242, 400);
            this.controlPanel.TabIndex = 0;
            this.controlPanel.TabStop = false;
            this.controlPanel.Text = "Panneau de contrôle";
            // 
            // rectangleBox
            // 
            this.rectangleBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.rectangleBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.rectangleBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.rectangleBox.Controls.Add(this.emptyRectangleButton);
            this.rectangleBox.Controls.Add(this.yLabel);
            this.rectangleBox.Controls.Add(this.xLabel);
            this.rectangleBox.Controls.Add(this.yTextBox);
            this.rectangleBox.Controls.Add(this.xTextBox);
            this.rectangleBox.Controls.Add(this.fillRectangleButton);
            this.rectangleBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rectangleBox.Location = new System.Drawing.Point(9, 327);
            this.rectangleBox.Name = "rectangleBox";
            this.rectangleBox.Size = new System.Drawing.Size(221, 66);
            this.rectangleBox.TabIndex = 9;
            this.rectangleBox.TabStop = false;
            this.rectangleBox.Text = "Rectangle";
            // 
            // emptyRectangleButton
            // 
            this.emptyRectangleButton.Location = new System.Drawing.Point(140, 39);
            this.emptyRectangleButton.Name = "emptyRectangleButton";
            this.emptyRectangleButton.Size = new System.Drawing.Size(75, 23);
            this.emptyRectangleButton.TabIndex = 12;
            this.emptyRectangleButton.Text = "Vider";
            this.emptyRectangleButton.UseVisualStyleBackColor = true;
            this.emptyRectangleButton.Click += new System.EventHandler(this.emptyRectangleButton_Click);
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(70, 24);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(20, 13);
            this.yLabel.TabIndex = 11;
            this.yLabel.Text = "Y :";
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(7, 24);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(23, 13);
            this.xLabel.TabIndex = 10;
            this.xLabel.Text = "X : ";
            // 
            // yTextBox
            // 
            this.yTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.yTextBox.Location = new System.Drawing.Point(92, 21);
            this.yTextBox.Name = "yTextBox";
            this.yTextBox.Size = new System.Drawing.Size(33, 20);
            this.yTextBox.TabIndex = 9;
            this.yTextBox.Text = "0";
            this.yTextBox.TextChanged += new System.EventHandler(this.yTextBox_TextChanged);
            // 
            // xTextBox
            // 
            this.xTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.xTextBox.Location = new System.Drawing.Point(29, 21);
            this.xTextBox.Name = "xTextBox";
            this.xTextBox.Size = new System.Drawing.Size(33, 20);
            this.xTextBox.TabIndex = 2;
            this.xTextBox.Text = "0";
            this.xTextBox.TextChanged += new System.EventHandler(this.xTextBox_TextChanged);
            // 
            // fillRectangleButton
            // 
            this.fillRectangleButton.Location = new System.Drawing.Point(140, 12);
            this.fillRectangleButton.Name = "fillRectangleButton";
            this.fillRectangleButton.Size = new System.Drawing.Size(75, 23);
            this.fillRectangleButton.TabIndex = 8;
            this.fillRectangleButton.Text = "Remplir";
            this.fillRectangleButton.UseVisualStyleBackColor = true;
            this.fillRectangleButton.Click += new System.EventHandler(this.fillRectangleButton_Click);
            // 
            // mapBox
            // 
            this.mapBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.mapBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.mapBox.Controls.Add(this.forceSendButton);
            this.mapBox.Controls.Add(this.forceGetMapButton);
            this.mapBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.mapBox.Location = new System.Drawing.Point(9, 269);
            this.mapBox.Name = "mapBox";
            this.mapBox.Size = new System.Drawing.Size(221, 52);
            this.mapBox.TabIndex = 4;
            this.mapBox.TabStop = false;
            this.mapBox.Text = "Carte";
            // 
            // forceSendButton
            // 
            this.forceSendButton.Location = new System.Drawing.Point(140, 19);
            this.forceSendButton.Name = "forceSendButton";
            this.forceSendButton.Size = new System.Drawing.Size(75, 23);
            this.forceSendButton.TabIndex = 8;
            this.forceSendButton.Text = "Envoyer";
            this.forceSendButton.UseVisualStyleBackColor = true;
            this.forceSendButton.Click += new System.EventHandler(this.forceSendButton_Click);
            // 
            // forceGetMapButton
            // 
            this.forceGetMapButton.Location = new System.Drawing.Point(6, 19);
            this.forceGetMapButton.Name = "forceGetMapButton";
            this.forceGetMapButton.Size = new System.Drawing.Size(75, 23);
            this.forceGetMapButton.TabIndex = 8;
            this.forceGetMapButton.Text = "Actualiser";
            this.forceGetMapButton.UseVisualStyleBackColor = true;
            this.forceGetMapButton.Click += new System.EventHandler(this.forceGetMapButton_Click);
            // 
            // directionBox
            // 
            this.directionBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.directionBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.directionBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.directionBox.Controls.Add(this.robotAngleTextBox);
            this.directionBox.Controls.Add(this.robotAngleLabel);
            this.directionBox.Controls.Add(this.pauseButton);
            this.directionBox.Controls.Add(this.actualDirection);
            this.directionBox.Controls.Add(this.stopButton);
            this.directionBox.Controls.Add(this.startButton);
            this.directionBox.Controls.Add(this.directionTurnRightButton);
            this.directionBox.Controls.Add(this.directionDownButton);
            this.directionBox.Controls.Add(this.directionTurnLeftButton);
            this.directionBox.Controls.Add(this.directionTopButton);
            this.directionBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.directionBox.Location = new System.Drawing.Point(9, 89);
            this.directionBox.Name = "directionBox";
            this.directionBox.Size = new System.Drawing.Size(221, 174);
            this.directionBox.TabIndex = 4;
            this.directionBox.TabStop = false;
            this.directionBox.Text = "Direction";
            // 
            // robotAngleTextBox
            // 
            this.robotAngleTextBox.BackColor = System.Drawing.SystemColors.ControlLight;
            this.robotAngleTextBox.Location = new System.Drawing.Point(47, 17);
            this.robotAngleTextBox.Name = "robotAngleTextBox";
            this.robotAngleTextBox.ReadOnly = true;
            this.robotAngleTextBox.Size = new System.Drawing.Size(31, 20);
            this.robotAngleTextBox.TabIndex = 9;
            // 
            // robotAngleLabel
            // 
            this.robotAngleLabel.AutoSize = true;
            this.robotAngleLabel.Location = new System.Drawing.Point(7, 20);
            this.robotAngleLabel.Name = "robotAngleLabel";
            this.robotAngleLabel.Size = new System.Drawing.Size(43, 13);
            this.robotAngleLabel.TabIndex = 8;
            this.robotAngleLabel.Text = "Angle : ";
            // 
            // pauseButton
            // 
            this.pauseButton.Image = global::RobotApplication.Properties.Resources.pause;
            this.pauseButton.Location = new System.Drawing.Point(95, 138);
            this.pauseButton.Name = "pauseButton";
            this.pauseButton.Size = new System.Drawing.Size(30, 30);
            this.pauseButton.TabIndex = 7;
            this.pauseButton.UseVisualStyleBackColor = true;
            this.pauseButton.Click += new System.EventHandler(this.pauseButton_Click);
            // 
            // actualDirection
            // 
            this.actualDirection.Location = new System.Drawing.Point(95, 59);
            this.actualDirection.Name = "actualDirection";
            this.actualDirection.Size = new System.Drawing.Size(30, 30);
            this.actualDirection.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.actualDirection.TabIndex = 7;
            this.actualDirection.TabStop = false;
            // 
            // stopButton
            // 
            this.stopButton.Image = global::RobotApplication.Properties.Resources.stop;
            this.stopButton.Location = new System.Drawing.Point(50, 138);
            this.stopButton.Name = "stopButton";
            this.stopButton.Size = new System.Drawing.Size(30, 30);
            this.stopButton.TabIndex = 6;
            this.stopButton.UseVisualStyleBackColor = true;
            this.stopButton.Click += new System.EventHandler(this.stopButton_Click);
            // 
            // startButton
            // 
            this.startButton.Image = global::RobotApplication.Properties.Resources.start;
            this.startButton.Location = new System.Drawing.Point(140, 138);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(30, 30);
            this.startButton.TabIndex = 5;
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // directionTurnRightButton
            // 
            this.directionTurnRightButton.Image = global::RobotApplication.Properties.Resources.arrowTurnRight;
            this.directionTurnRightButton.Location = new System.Drawing.Point(140, 59);
            this.directionTurnRightButton.Name = "directionTurnRightButton";
            this.directionTurnRightButton.Size = new System.Drawing.Size(30, 30);
            this.directionTurnRightButton.TabIndex = 3;
            this.directionTurnRightButton.UseVisualStyleBackColor = true;
            this.directionTurnRightButton.Click += new System.EventHandler(this.directionTurnRightButton_Click);
            // 
            // directionDownButton
            // 
            this.directionDownButton.Image = global::RobotApplication.Properties.Resources.arrowDown;
            this.directionDownButton.Location = new System.Drawing.Point(95, 101);
            this.directionDownButton.Name = "directionDownButton";
            this.directionDownButton.Size = new System.Drawing.Size(30, 30);
            this.directionDownButton.TabIndex = 2;
            this.directionDownButton.UseVisualStyleBackColor = true;
            this.directionDownButton.Click += new System.EventHandler(this.directionBackwardButton_Click);
            // 
            // directionTurnLeftButton
            // 
            this.directionTurnLeftButton.Image = global::RobotApplication.Properties.Resources.arrowTurnLeft;
            this.directionTurnLeftButton.Location = new System.Drawing.Point(50, 59);
            this.directionTurnLeftButton.Name = "directionTurnLeftButton";
            this.directionTurnLeftButton.Size = new System.Drawing.Size(30, 30);
            this.directionTurnLeftButton.TabIndex = 1;
            this.directionTurnLeftButton.UseVisualStyleBackColor = true;
            this.directionTurnLeftButton.Click += new System.EventHandler(this.directionTurnLeftButton_Click);
            // 
            // directionTopButton
            // 
            this.directionTopButton.Image = global::RobotApplication.Properties.Resources.arrowUp;
            this.directionTopButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.directionTopButton.Location = new System.Drawing.Point(95, 19);
            this.directionTopButton.Margin = new System.Windows.Forms.Padding(0);
            this.directionTopButton.Name = "directionTopButton";
            this.directionTopButton.Size = new System.Drawing.Size(30, 30);
            this.directionTopButton.TabIndex = 0;
            this.directionTopButton.UseVisualStyleBackColor = true;
            this.directionTopButton.Click += new System.EventHandler(this.directionForwardButton_Click);
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
            this.speedBox.Location = new System.Drawing.Point(9, 19);
            this.speedBox.Name = "speedBox";
            this.speedBox.Size = new System.Drawing.Size(221, 64);
            this.speedBox.TabIndex = 3;
            this.speedBox.TabStop = false;
            this.speedBox.Text = "Vitesse";
            // 
            // speedBar
            // 
            this.speedBar.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.speedBar.AutoSize = false;
            this.speedBar.BackColor = System.Drawing.SystemColors.ControlLight;
            this.speedBar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.speedBar.LargeChange = 10;
            this.speedBar.Location = new System.Drawing.Point(6, 19);
            this.speedBar.Maximum = 100;
            this.speedBar.Name = "speedBar";
            this.speedBar.Size = new System.Drawing.Size(170, 24);
            this.speedBar.SmallChange = 5;
            this.speedBar.TabIndex = 0;
            this.speedBar.TickFrequency = 10;
            this.speedBar.Scroll += new System.EventHandler(this.speedBar_Scroll);
            // 
            // speedTextBox
            // 
            this.speedTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.speedTextBox.Location = new System.Drawing.Point(182, 19);
            this.speedTextBox.Name = "speedTextBox";
            this.speedTextBox.Size = new System.Drawing.Size(33, 20);
            this.speedTextBox.TabIndex = 1;
            this.speedTextBox.Text = "0";
            this.speedTextBox.TextChanged += new System.EventHandler(this.speedTextBox_TextChanged);
            // 
            // mapsPanel
            // 
            this.mapsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mapsPanel.Controls.Add(this.robotMapTab);
            this.mapsPanel.Controls.Add(this.obstaclesMapTab);
            this.mapsPanel.Location = new System.Drawing.Point(0, 28);
            this.mapsPanel.Name = "mapsPanel";
            this.mapsPanel.SelectedIndex = 0;
            this.mapsPanel.Size = new System.Drawing.Size(409, 400);
            this.mapsPanel.TabIndex = 4;
            // 
            // robotMapTab
            // 
            this.robotMapTab.Controls.Add(this.robotMapPanel);
            this.robotMapTab.Location = new System.Drawing.Point(4, 22);
            this.robotMapTab.Name = "robotMapTab";
            this.robotMapTab.Padding = new System.Windows.Forms.Padding(3);
            this.robotMapTab.Size = new System.Drawing.Size(401, 374);
            this.robotMapTab.TabIndex = 0;
            this.robotMapTab.Text = "Robot";
            this.robotMapTab.UseVisualStyleBackColor = true;
            // 
            // robotMapPanel
            // 
            this.robotMapPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.robotMapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.robotMapPanel.Location = new System.Drawing.Point(3, 3);
            this.robotMapPanel.Name = "robotMapPanel";
            this.robotMapPanel.Size = new System.Drawing.Size(395, 368);
            this.robotMapPanel.TabIndex = 0;
            this.robotMapPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.robotMapPanel_Paint);
            // 
            // obstaclesMapTab
            // 
            this.obstaclesMapTab.Controls.Add(this.obstacleMapPanel);
            this.obstaclesMapTab.Location = new System.Drawing.Point(4, 22);
            this.obstaclesMapTab.Name = "obstaclesMapTab";
            this.obstaclesMapTab.Padding = new System.Windows.Forms.Padding(3);
            this.obstaclesMapTab.Size = new System.Drawing.Size(401, 374);
            this.obstaclesMapTab.TabIndex = 1;
            this.obstaclesMapTab.Text = "Obstacles";
            this.obstaclesMapTab.UseVisualStyleBackColor = true;
            // 
            // obstacleMapPanel
            // 
            this.obstacleMapPanel.AutoScroll = true;
            this.obstacleMapPanel.Controls.Add(this.obstacleMapPictureBox);
            this.obstacleMapPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.obstacleMapPanel.Location = new System.Drawing.Point(3, 3);
            this.obstacleMapPanel.Name = "obstacleMapPanel";
            this.obstacleMapPanel.Size = new System.Drawing.Size(395, 368);
            this.obstacleMapPanel.TabIndex = 1;
            // 
            // obstacleMapPictureBox
            // 
            this.obstacleMapPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.obstacleMapPictureBox.Image = global::RobotApplication.Properties.Resources.OpenSpace;
            this.obstacleMapPictureBox.Location = new System.Drawing.Point(0, 0);
            this.obstacleMapPictureBox.Name = "obstacleMapPictureBox";
            this.obstacleMapPictureBox.Size = new System.Drawing.Size(395, 368);
            this.obstacleMapPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.obstacleMapPictureBox.TabIndex = 0;
            this.obstacleMapPictureBox.TabStop = false;
            // 
            // loadMapDialog
            // 
            this.loadMapDialog.Title = "Charger une carte";
            this.loadMapDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.loadMapDialog_FileOk);
            // 
            // saveMapDialog
            // 
            this.saveMapDialog.Title = "Sauvegarder la map";
            this.saveMapDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.saveMapDialog_FileOk);
            // 
            // RobotMockApp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 453);
            this.Controls.Add(this.mapsPanel);
            this.Controls.Add(this.controlPanel);
            this.Controls.Add(this.menuStrip);
            this.Controls.Add(this.statusStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(1300, 940);
            this.MinimumSize = new System.Drawing.Size(650, 470);
            this.Name = "RobotMockApp";
            this.Text = "Netduino Simulator";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.controlPanel.ResumeLayout(false);
            this.rectangleBox.ResumeLayout(false);
            this.rectangleBox.PerformLayout();
            this.mapBox.ResumeLayout(false);
            this.directionBox.ResumeLayout(false);
            this.directionBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.actualDirection)).EndInit();
            this.speedBox.ResumeLayout(false);
            this.speedBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.speedBar)).EndInit();
            this.mapsPanel.ResumeLayout(false);
            this.robotMapTab.ResumeLayout(false);
            this.obstaclesMapTab.ResumeLayout(false);
            this.obstacleMapPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.obstacleMapPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel connectionStatus;
        private System.Windows.Forms.ToolStrip menuStrip;
        private System.Windows.Forms.ToolStripDropDownButton applicationStripMenu;
        private System.Windows.Forms.ToolStripMenuItem loadMapMenuButton;
        private System.Windows.Forms.ToolStripMenuItem saveMapMenuButton;
        private System.Windows.Forms.ToolStripMenuItem quitMenuButton;
        private System.Windows.Forms.ToolStripButton configureMenuButton;
        private System.Windows.Forms.GroupBox controlPanel;
        private System.Windows.Forms.GroupBox speedBox;
        private System.Windows.Forms.TrackBar speedBar;
        private System.Windows.Forms.TextBox speedTextBox;
        private System.Windows.Forms.GroupBox mapBox;
        private System.Windows.Forms.Button forceSendButton;
        private System.Windows.Forms.Button forceGetMapButton;
        private System.Windows.Forms.GroupBox directionBox;
        private System.Windows.Forms.PictureBox actualDirection;
        private System.Windows.Forms.Button stopButton;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.Button directionTurnRightButton;
        private System.Windows.Forms.Button directionDownButton;
        private System.Windows.Forms.Button directionTurnLeftButton;
        private System.Windows.Forms.Button directionTopButton;
        private System.Windows.Forms.TabControl mapsPanel;
        private System.Windows.Forms.TabPage robotMapTab;
        private System.Windows.Forms.TabPage obstaclesMapTab;
        private System.Windows.Forms.ToolStripStatusLabel robotStatus;
        private System.Windows.Forms.Button pauseButton;
        private System.Windows.Forms.OpenFileDialog loadMapDialog;
        private System.Windows.Forms.SaveFileDialog saveMapDialog;
        private System.Windows.Forms.PictureBox obstacleMapPictureBox;
        private System.Windows.Forms.Panel robotMapPanel;
        private System.Windows.Forms.GroupBox rectangleBox;
        private System.Windows.Forms.Button fillRectangleButton;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.TextBox yTextBox;
        private System.Windows.Forms.TextBox xTextBox;
        private System.Windows.Forms.Button emptyRectangleButton;
        private System.Windows.Forms.Panel obstacleMapPanel;
        private System.Windows.Forms.TextBox robotAngleTextBox;
        private System.Windows.Forms.Label robotAngleLabel;
    }
}


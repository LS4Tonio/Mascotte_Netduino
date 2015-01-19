using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RobotServer
{
    public partial class RobotServerApp : Form
    {
        private Server server;

        public RobotServerApp()
        {
            InitializeComponent();
            server = new Server();
        }

        private void RobotServerApp_FormClosing(object sender, FormClosingEventArgs e)
        {
            server.Close();
        }
    }
}
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
    public partial class ErrorWindow : Form
    {
        private bool isDisplayed;

        public ErrorWindow()
        {
            InitializeComponent();
            isDisplayed = false;
        }

        public void SetErrorMessage(string originError, string title, string message)
        {
            Text = originError;
            this.titleError.Text = title;
            this.errorMessage.Text = message;
            if (!isDisplayed)
            {
                isDisplayed = true;
                this.ShowDialog();
            }
        }
        private void cancelButton_Click(object sender, EventArgs e)
        {
            isDisplayed = false;
            this.Close();
        }
        private void validateButton_Click(object sender, EventArgs e)
        {
            isDisplayed = false;
            this.Close();
        }
    }
}

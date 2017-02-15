using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace espaceNetSAV
{
    public partial class SplashScreen : Form
    {

        const int _SECONDS = 3;
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            notifyIcon1.ShowBalloonTip(5000);
            this.Opacity = 0.01;
            timer1.Start();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        int counter = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
                this.Opacity += 0.05;

            if (this.Opacity >= 1)
            {
                timer1.Interval = 1000;
                counter++;
            }

            if (counter == _SECONDS)
            {
                Admin.LoginForm loginFormObject = new Admin.LoginForm();
                loginFormObject.Show();

                this.Hide();
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace espaceNetSAV.Admin
{
    public partial class LoginForm : Form
    {

        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //This will try to connect the user to the app
            User userObject = new User();

            CrysptingService crypt = new CrysptingService();

            var cryptedPwd = crypt.Encrypt(passwordTBox.Text, Program._KEY);
            var stuff = userObject.CheckCredentials(usernameTBox.Text, cryptedPwd);
            //MessageBox.Show(stuff.ToString(), "Status");



            
        }
    }
}

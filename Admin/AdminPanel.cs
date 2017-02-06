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
    public partial class AdminPanel : Form
    {
        public const string _KEY = "ESPACENETSAV";

        public AdminPanel()
        {
            InitializeComponent();
        }

        private void makeUserBtn_Click(object sender, EventArgs e)
        {


            CrysptingService cryptingObject = new CrysptingService();
            string cryptedPassword = cryptingObject.Encrypt(passwordTBox.Text, _KEY);
            User userObject = new User(usernameTBox.Text, cryptedPassword);

            var reuslt = userObject.createUser();
            MessageBox.Show(reuslt.ToString());


            //User userObject = new User();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            //This will eitehr let the user in or give error message
            User userObject = new User();

            CrysptingService crypt = new CrysptingService();

            var cryptedPwd = crypt.Encrypt(passwordTBox.Text, _KEY);
            var stuff = userObject.CheckCredentials(usernameTBox.Text, cryptedPwd);
            MessageBox.Show(stuff.ToString(), "Status");

        }
    }
}

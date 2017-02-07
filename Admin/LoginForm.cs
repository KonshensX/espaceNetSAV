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

            if (stuff)
            {
                Program._USER = userObject.GetUser(usernameTBox.Text, cryptedPwd);

                if (Program._USER.isAdmin())
                {
                    AdminPanel adminPanelObject = new AdminPanel();

                    adminPanelObject.Show();

                    this.Hide();
                }
                else if (!Program._USER.isAdmin())
                {
                    FormulaireReception formObject = new FormulaireReception();
                    formObject.Show();
                    this.Hide();
                }
            }

            
        }
    }
}

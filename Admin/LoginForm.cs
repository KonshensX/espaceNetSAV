using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

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
                return;
            }

            errorHolderLabel.Visible = true;

            errorHolderLabel.Text = "Mot de passe ou Pseudo erroné";
            
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            errorHolderLabel.Visible = false;
            //The logic for remember me button goes here 
            //Checking if the file exists 
            //If the file exists it means that last time the user logged in he checked this option
            string fileName = "config.data";
            if (File.Exists(fileName))
            {
                FileStream file = File.Open(fileName, FileMode.Open);
                
                return;
            }
            File.Create(fileName);
        }
        int howMany = 0;
        private void passwordTBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (howMany == 0)
            {
                howMany++;
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                this.button1_Click(sender, e);
                passwordTBox.Text = "";
            }

        }

        
    }
}

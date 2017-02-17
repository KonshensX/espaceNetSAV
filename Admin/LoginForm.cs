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
        string fileName = "config.data";

        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            
            
            this.ConnectUser(usernameTBox.Text, passwordTBox.Text);
        }
        
        private void LoginForm_Load(object sender, EventArgs e)
        {
            errorHolderLabel.Visible = false;
            checkBox1.Visible = false;
            //string fileName = "config.data";
            //StreamReader file = new StreamReader(fileName);
            ////The logic for remember me button goes here 
            ////Checking if the file exists 
            ////If the file exists it means that last time the user logged in he checked this option
            //if (File.Exists(fileName))
            //{
            //    string line;
            //    while ((line = file.ReadLine()) != null)
            //    {
            //        if (line.Contains("username"))
            //            username = line.Split(':')[1];
            //        else if (line.Contains("password"))
            //            password = line.Split(':')[1];

            //    }
            //    Remembered = true;
            //    return;
            //}
            //File.Create(fileName);
            //file.Close();
            //this.ConnectUser(username, password);
            //this.ConnectUser("admin", "admin");
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


        private void ConnectUser(string USERNAME, string PWD)
        {
            //This will try to connect the user to the app
            User userObject = new User();

            CrysptingService crypt = new CrysptingService();

            var cryptedPwd = crypt.Encrypt(PWD, Program._KEY);
            var stuff = userObject.CheckCredentials(USERNAME, cryptedPwd);

            if (stuff)
            {

                if (checkBox1.Checked)
                {
                    // Compose a string that consists of three lines.
                    string lines = String.Format("username:{0}\npassword:{1}", USERNAME, PWD);

                    // Write the string to a file.
                    System.IO.StreamWriter file = new System.IO.StreamWriter(fileName);
                    file.WriteLine(lines);

                    file.Close();
                }

                Program._USER = userObject.GetUser(USERNAME, cryptedPwd);

                if (Program._USER.isAdmin())
                {
                    AdminPanel adminPanelObject = new AdminPanel();

                    adminPanelObject.Show();

                    this.Close();
                }
                else if (!Program._USER.isAdmin())
                {
                    if (Program._USER.category.Name.Equals("Réception"))
                    {
                        FormulaireReception formObject = new FormulaireReception();
                        formObject.Show();
                        this.Close();
                        return;
                    }
                    TechniquesList techFormObject = new TechniquesList();
                    techFormObject.Show();
                    this.Hide();

                }
                return;
            }

            errorHolderLabel.Visible = true;

            errorHolderLabel.Text = "Mot de passe ou Pseudo erroné";
        }
        
    }
}

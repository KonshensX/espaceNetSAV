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
        const string _KEY = "ESPACENETSAV";
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void makeUserBtn_Click(object sender, EventArgs e)
        {

            
           // User userObject = new User(usernameTBox.Text, passwordTBox.Text);
            CrysptingService cryptingObject = new CrysptingService();
            string cryptedPassword = cryptingObject.Encrypt(passwordTBox.Text, _KEY);
            User userObject = new User(usernameTBox.Text, cryptedPassword);

            var reuslt = userObject.createUser();
            MessageBox.Show(reuslt.ToString());
        }
    }
}

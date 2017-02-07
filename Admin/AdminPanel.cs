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
        List<User> usersListDB;
        public const string _KEY = "ESPACENETSAV";

        public AdminPanel()
        {
            usersListDB = new List<User>();

            InitializeComponent();
        }

        private void makeUserBtn_Click(object sender, EventArgs e)
        {


            //CrysptingService cryptingObject = new CrysptingService();
            //string cryptedPassword = cryptingObject.Encrypt(passwordTBox.Text, _KEY);
            //User userObject = new User(usernameTBox.Text, cryptedPassword);

            //var reuslt = userObject.createUser();
            //MessageBox.Show(reuslt.ToString());


            //User userObject = new User();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            ////This will eitehr let the user in or give error message
            //User userObject = new User();

            //CrysptingService crypt = new CrysptingService();

            //var cryptedPwd = crypt.Encrypt(passwordTBox.Text, _KEY);
            //var stuff = userObject.CheckCredentials(usernameTBox.Text, cryptedPwd);
            //MessageBox.Show(stuff.ToString(), "Status");

        }


        private void clearStatusBarWithMessage(string message)
        {
            this.statusStrip1.Items.Clear();

            statusStrip1.Items.Add(message);
        }


        private void AdminPanel_Load(object sender, EventArgs e)
        {
            User userObject = new User();

            Category catObject = new Category();

            List<Category> myCategoriesList = catObject.GetCategories();

            usersListDB = userObject.GetAllUsers();

            //Creating the Category Nodes 

            foreach (Category category in myCategoriesList)
            {
                TreeNode myNode = new TreeNode(category.Name);
                TreeNode[] tempArray;
                foreach (User user in usersListDB)
                {
                    TreeNode
                }
                
                usersList.Nodes.Add(myNode);
            }

            //
            // This is the first node in the view.
            //
            TreeNode treeNode = new TreeNode("Windows");
            usersList.Nodes.Add(treeNode);
            //
            // Another node following the first node.
            //
            treeNode = new TreeNode("Linux");
            usersList.Nodes.Add(treeNode); 
            //
            // Create two child nodes and put them in an array.
            // ... Add the third node, and specify these as its children.
            //
            TreeNode node2 = new TreeNode("C#");
            TreeNode node3 = new TreeNode("VB.NET");
            TreeNode[] array = new TreeNode[] { node2, node3 };
            //
            // Final node.
            //
            treeNode = new TreeNode("Dot Net Perls", array);




            usersList.Nodes.Add(treeNode);
        }

        private void cetegoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCategory cat = new AddCategory();

            cat.Show();
        }
    }
}

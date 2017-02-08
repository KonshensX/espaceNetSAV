using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace espaceNetSAV.Admin
{
    public partial class AdminPanel : Form
    {
        User userObject;
        List<User> usersListDB;
        List<Category> myCategoriesList;
        Category catObject;
        User currentUser;
        public const string _KEY = "ESPACENETSAV";

        public AdminPanel()
        {
            usersListDB = new List<User>();
            userObject = new User();

            catObject = new Category();

            myCategoriesList = catObject.GetCategories();

            usersListDB = userObject.GetAllUsers();
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

            clearStatusBarWithMessage("");
            this.FillCategoryiesComboBox();
            //Creating the Category Nodes 

            foreach (Category category in myCategoriesList)
            {
                //This will insert the parent node
                TreeNode myNode = new TreeNode(category.Name);

                //This array will be holding the child nodes 
                List<TreeNode> tempList = new List<TreeNode>();

                //This loop should fill the above array with the child nodes 
                for (int i = 0; i < usersListDB.Count; i++)
                {
                    //Checking if the users belongs to this category before adding to the nodes 
                    if (usersListDB[i].category.ID == category.ID)
                    {
                        //Creating the node for the user and adding it to the list
                        tempList.Add(new TreeNode(usersListDB[i].Name));
                    }
                }

                //Filtering the array to get rid of null values ???
                //var array = tempArray.Where(c => c.Text.Equals("Empty node to be deleted!"));
                //TreeNode[] realArray = new TreeNode[]

                myNode = new TreeNode(category.Name, tempList.ToArray());
                usersList.Nodes.Add(myNode);
            }

            #region Tutorial
            /*
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
             * */
            #endregion




            //usersList.Nodes.Add(treeNode);
        }

        private void cetegoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCategory cat = new AddCategory();

            cat.Show();
        }

        public void FillCategoryiesComboBox()
        {
            foreach (Category item in myCategoriesList)
            {
                categoryCBox.Items.Add(item.Name);
                categoryEditCbox.Items.Add(item.Name);
            }
            //categoryCBox.SelectedIndex = 0;
            categoryCBox.Text = "Veuillez selectionner le category";
        }

        private void createBtn_Click(object sender, EventArgs e)
        {
            CrysptingService cryptObject = new CrysptingService();

            var crypted = cryptObject.Encrypt(pwdTBox.Text, Program._KEY);

            Category categoryObject = new Category();

            categoryObject.FetchCategoryBasedOnName(categoryCBox.Text);

            User userObject = new User(usernameTBox.Text, crypted, categoryObject);

            var queriesResult = userObject.createUser();

            MessageBox.Show(queriesResult.ToString());

            if (queriesResult > 0)
            {
                this.clearStatusBarWithMessage("Utilisateur bien creé");
            }
        }

        private void usersList_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            

        }

        private void usersList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //Checking whether the selected node is a parent node or a child node 
            if (!(usersList.SelectedNode.Parent == null))
            {
                //This is a child node
                //The code below this comment should display the informations of each user in the tab control

                //Fetching the user from the current users list and NOT from the database, Performance optimization
                currentUser = usersListDB.Find(user => user.Name.Equals(usersList.SelectedNode.Text));

                usernameEditTbox.Text = currentUser.Name;

                passwordEditTBox.Text = "**********";
                passwordEditTboxConf.Text = "**********";

                categoryEditCbox.SelectedItem = currentUser.category.Name;

                //Display data in the form fields 

            }
        }

        private void saveChangesBtn_Click(object sender, EventArgs e)
        {
            //Checking if the password is okay or not 
            if (passwordEditTBox.Text.Equals(passwordEditTboxConf.Text))
            {

                //Passwords match eachother 
                currentUser.Name = usernameEditTbox.Text;
                currentUser.Password = passwordEditTboxConf.Text;
                var categoryID = new Category().GetIDBasedOnName(categoryEditCbox.Text);
                currentUser.category = new Category().getCategory(categoryID);

                currentUser.saveChanges();
            }
            else
            {
                MessageBox.Show("Les mots de passes ne sont pas identiques", "Erreur mot de passe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.clearStatusBarWithMessage("");
            }
        }
    }
}

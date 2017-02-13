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


            this.ResizeColumns();
            this.FillSomeDummyData();
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

                myNode = new TreeNode(category.Name, tempList.ToArray()) { Name = category.Name };
                usersList.Nodes.Add(myNode);

            }

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
            if (!pwdTBox.Text.Equals(pwdTBoxConf.Text))
            {
                MessageBox.Show("Les mots de passes ne sont pas identiques", "Erreur mot de passe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            CrysptingService cryptObject = new CrysptingService();

            var crypted = cryptObject.Encrypt(pwdTBox.Text, Program._KEY);

            Category categoryObject = new Category();

            categoryObject.FetchCategoryBasedOnName(categoryCBox.Text);

            User userObject = new User(usernameTBox.Text, crypted, categoryObject);


            this.createUserAndAddToUI(userObject, categoryObject);
            var queriesResult = userObject.createUser();


            MessageBox.Show(queriesResult.ToString());

            if (queriesResult > 0)
            {
                this.clearStatusBarWithMessage("Utilisateur bien creé");
            }

            usersListDB = userObject.GetAllUsers();
        }

        private void createUserAndAddToUI(User userObject, Category category)
        {

            TreeNode[] result = usersList.Nodes.Find(category.Name, true);

            TreeNode myTempNode = new TreeNode(userObject.Name);

            result[0].Nodes.Add(myTempNode);
            
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

                passwordEditTBox.Text = "Nouveau mot de passe";
                passwordEditTboxConf.Text = "Confirmation de nouveau mot de passe";

                categoryEditCbox.SelectedItem = currentUser.category.Name;

                //Display data in the form fields 

                //Load the history of the user
                this.FillUserHistoryListView();
            }
        }

        private void saveChangesBtn_Click(object sender, EventArgs e)
        {
            this.tempName();

            if (passwordEditTBox.Text.Equals("Nouveau mot de passe"))
            {
                MessageBox.Show("Enter nouveau mot de passe", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (passwordEditTBox.Text.Equals(""))
            { 
                MessageBox.Show("Champs mot de passe est vide!");
                return;
            }

            if (usersList.SelectedNode == null )
            {
                MessageBox.Show("Nothing is selected!");
                return;
            }
            if (MessageBox.Show("Confimer les nouveaux modifications ?", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
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
                    this.clearStatusBarWithMessage("Modifications bien enregister!");
                }
                else
                {
                    MessageBox.Show("Les mots de passes ne sont pas identiques", "Erreur mot de passe", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.clearStatusBarWithMessage("");
                }
            }
        }

        private void deleteUserBtn_Click(object sender, EventArgs e)
        {
            //This will delete the user after confirmation 
            if (MessageBox.Show("Voulez vous vraiment supprimer ", "Confirmer", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
            {
                //Confirm the delete proccess
                if (currentUser.Delete())
                {
                    usersList.SelectedNode.Remove();
                    MessageBox.Show("L'utilisateur a été bien suprprimé!", "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void FillUserHistoryListView()
        {

            this.EmptyListView();
            //Fill the list view 
            History historyObject = new History(currentUser);

            List<History> myList = historyObject.GetUserHistoryLast30Days();

            foreach (History item in myList)
            {
                ListViewItem tempItem = new ListViewItem(new string[] {item.Date.ToString("dd/MM/yyyy HH:mm"), item.OldValue, item.NewValue});
                listView1.Items.Add(tempItem);
            }

        }

        /// <summary>
        /// Inserts some dummy data in the history table 
        /// </summary>
        private void FillSomeDummyData()
        {
            //new History("sxcvbn", "edfghjklm", new User().GetUser(1)).Save();
            //new History("ioreoirezio", "ioreoirezio", new User().GetUser(1)).Save();
            //new History("dfghjk,;", "dfghjk,;", new User().GetUser(1)).Save();
            //new History("itititit", "itititit", new User().GetUser(1)).Save();
        }

        private void ResizeColumns()
        {
            this.listView1.Columns[0].Width = 120;
            this.listView1.Columns[1].Width = 220;
            this.listView1.Columns[2].Width = 200;
        }

        private void viderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirmation de suppression!!", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
            {
                if (new History(Program._USER).EmptyHistory())
                {

                    this.EmptyListView();
                    this.FillUserHistoryListView();
                    listView1.Refresh();
                    MessageBox.Show("Bien vider l'historique", "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void EmptyListView()
        {
            foreach (ListViewItem item in listView1.Items)
            {
                item.Remove();
            }
            listView1.Refresh();
        }

        private void historiqueToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CompleteHistoryList formObject = new CompleteHistoryList();
            formObject.Show();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void passwordEditTBox_Enter(object sender, EventArgs e)
        {
            if (passwordEditTBox.Text.Equals("Nouveau mot de passe"))
            {
                passwordEditTBox.Text = "";
                passwordEditTboxConf.Text = "";
            }
        }

        private void tempName()
        {
            var temp = usersList.SelectedNode;
            if (temp.Parent == null)
                return;
            temp.Text = usernameEditTbox.Text;

        }

        private void réceptionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormulaireReception formObject = new FormulaireReception();

            formObject.Show();
        }

        private void listCompleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void techniqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TechniquesList formObject = new TechniquesList();

            formObject.Show();
        }

        private void valdéToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //List des dossier validés 
            BonReceptionListValide formObject = new BonReceptionListValide();

            formObject.Show();
        }

        private void pasEncoreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Pas Encore 
            BonReceptionList formObject = new BonReceptionList();

            formObject.Show();
        }
    }
}

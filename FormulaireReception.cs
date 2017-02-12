using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace espaceNetSAV
{
    public partial class FormulaireReception : Form
    {
        public FormulaireReception()
        {
            InitializeComponent();
            clientTypeRB.Checked = true;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (clientTypeRB.Checked)
            {
                contactLabel.Visible = false;
                contactTBox.Visible = false;
            } 
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void FormulaireReception_Load(object sender, EventArgs e)
        {

            //Program._USER = new Admin.User().GetUser(2);
            this.clearStatusBarWithMessage("Bienvenue!");
            dateValuelbl.Text = DateTime.Now.ToString();
            Client clientObject = new Client();
            var clientsNames = clientObject.getClientsList();
            var clientsDataSource = new AutoCompleteStringCollection();
            foreach (var nom in clientsNames)
            {
                clientsDataSource.Add(nom);
                clientComboBox.Items.Add(nom);
            }

            clientComboBox.AutoCompleteCustomSource = clientsDataSource;

            //Program._USER = new Admin.User().GetUser(1);
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (rsTypeRB.Checked)
            {
                contactLabel.Visible = true;
                contactTBox.Visible = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //#####################################################
            // THIS IS THE TESTING AREA! ALL TESTING CODE CODE BELOW
            //#####################################################
            //Checking if the client exists in the database or should we create a new one
            try
            {
                Client clientService = new Client();
                Client clientObject;
                DesignationReception designReception = new DesignationReception(designTBox.Text, problTBox.Text);
                designReception.persistObjectToDatabase();

                //Checking whether the client field is empty or nah!!
                if (clientComboBox.Text == "" || telTBox.Text == "" || designTBox.Text == "" || problTBox.Text == "")
                {
                    this.clearStatusBarWithMessage("* - Champs obligatoire");
                    return;
                }

                if (clientService.clientExists(clientComboBox.Text, telTBox.Text))
                {
                    //Insert into database without adding a new client
                    clientObject = clientService.getClientByNameAndPhone(clientComboBox.Text, telTBox.Text);
                }
                else
                {
                    //Add a new client to the database
                    clientObject = new Client(clientComboBox.Text, telTBox.Text, emailTBox.Text, faxTBox.Text, contactTBox.Text, (clientTypeRB.Checked) ? ClientType.Client : ClientType.RaisonSociale);
                    clientObject.persistClientToDatabase();
                }

                Technique techObject = new Technique();
                BonReception bonReceptionObject = new BonReception(clientObject, designReception, techObject, refAchattbox.Text);


                techObject.persistObjectToDatabase(bonReceptionObject.id);
                bonReceptionObject.persistObjectToDatabase();

                //Admin.History history = new Admin.History(String.Format("Creation du bon: N°: {0}", bonReceptionObject.client), "", Program._USER);
                //history.Save();
                BonReception bonObject = new BonReception();

                bonObject.getItem(bonObject.GetLastID());
                PdfGenerator pdfObject = new PdfGenerator(bonObject);

                Process.Start(@"myPdf.pdf");

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            //MessageBox.Show(client.clientExists(clientComboBox.Text, telTBox.Text).ToString());
            statusStrip1.Items.Clear();
            statusStrip1.Items.Add("Bien ajouter");

        }

        private void clientTBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void clientTBox_Enter(object sender, EventArgs e)
        {

        }

        private void clientComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Client clientObject = new Client();
            clientObject = clientObject.getClientByName(clientComboBox.Text);
            faxTBox.Text = clientObject.fax;
            telTBox.Text = clientObject.tel;
            contactTBox.Text = clientObject.contact;
            emailTBox.Text = clientObject.email;

        }

        private void clientComboBox_TextChanged(object sender, EventArgs e)
        {
            if (clientComboBox.Text == "")
            {
                emptyAllFields();
            }
        }


        /*This is used to reset all fields and make empty, wow such english */
        private void emptyAllFields()
        {
            telTBox.Text = "";
            faxTBox.Text = "";
            contactTBox.Text = "";
            emailTBox.Text = "";

        }

        private void diusplayListBtn_Click(object sender, EventArgs e)
        {
            BonReceptionList windowObject = new BonReceptionList();
            windowObject.Show();
        }

        private void makePdfButton_Click(object sender, EventArgs e)
        {
            //PdfGenerator pdfObject = new PdfGenerator();
        }
        /// <summary>
        /// This will clear the status bar and inserts a new message 
        /// </summary>
        /// <param name="message">The new message to be displayed </param>
        private void clearStatusBarWithMessage(string message)
        {
            statusStrip1.Items.Clear();
            statusStrip1.Items.Add(message);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            TechniquesList formObject = new TechniquesList();

            formObject.Show();
        }

        private void nOTOKOKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BonReceptionList formObject = new BonReceptionList();
            formObject.Show();
        }

        private void technqiueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TechniquesList formObject = new TechniquesList();

            formObject.Show();
        }

        private void oKOKToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }
    }
}

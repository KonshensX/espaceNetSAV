using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
            //try
            //{
            //    Client client = new Client(clientComboBox.Text, telTBox.Text, emailTBox.Text, faxTBox.Text, contactTBox.Text, (clientTypeRB.Checked) ? ClientType.Client : ClientType.RasionSociale);
            //    client.persistClientToDatabase();

            //    DesignationReception designationReception = new DesignationReception(designTBox.Text, problTBox.Text);
            //    designationReception.persistObjectToDatabase();

            //    BonReception bonReception = new BonReception();
            //    MessageBox.Show("Ajouter avec success!", "Success");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.StackTrace, ex.Message);
            //}



            //MessageBox.Show("Date:" + DateTime.Now, "DateTiem.now");




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
                if (clientService.clientExists(clientComboBox.Text, telTBox.Text))
                {
                    //Insert into database without adding a new client
                    clientObject = clientService.getClientByNameAndPhone(clientComboBox.Text, telTBox.Text);
                }
                else
                {
                    //Add a new client to the database
                    clientObject = new Client(clientComboBox.Text, telTBox.Text, emailTBox.Text, faxTBox.Text, contactTBox.Text, (clientTypeRB.Checked) ? ClientType.Client : ClientType.RasionSociale);
                    clientObject.persistClientToDatabase();
                }

                BonReception bonReceptionObject = new BonReception(clientObject, designReception, refAchattbox.Text);
                bonReceptionObject.persistObjectToDatabase();
                MessageBox.Show("Bien ajouter", "Message");
            }
            catch (Exception)
            {
                throw;
            }
            //MessageBox.Show(client.clientExists(clientComboBox.Text, telTBox.Text).ToString());

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
    }
}

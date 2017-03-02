using System;
using System.Windows.Forms;

namespace espaceNetSAV
{
    public partial class ChangeValuesBonReception : Form
    {

        BonReception bonObject;
        public ChangeValuesBonReception(BonReception bonObeject)
        {
            InitializeComponent();
            bonObject = bonObeject;
        }

        private void ChangeValuesBonReception_Load(object sender, EventArgs e)
        {
            this.FillFieldsWithData();
        }

        private void applybtn_Click(object sender, EventArgs e)
        {
            //This is the apply button
            var clientname = clientTBox.Text;
            var tel = telTBox.Text;
            var fax = faxTBox.Text;
            var contact = contactTBox.Text;
            var email = emailTBox.Text;
            var designation = designTBox.Text;
            var probleme = problTBox.Text;


            bonObject.client.nom = clientname;
            bonObject.client.tel = tel;
            bonObject.client.fax = fax;
            bonObject.client.email = email;
            bonObject.contact = contact;
            bonObject.designationReception.designation = designation;
            bonObject.designationReception.probleme = probleme;



            bonObject.Update();
            this.Close();
            //TODO: I need to update the data in the datagridview in order for the user to see the changes.
        }

        private void cancelbtn_Click(object sender, EventArgs e)
        {
            //This is the cancel button
            this.Close();
        }

        /// <summary>
        /// Fill the fields with the passed in data 
        /// </summary>
        public void FillFieldsWithData()
        {
            clientTBox.Text = bonObject.client.nom;
            telTBox.Text = bonObject.client.tel;
            faxTBox.Text = bonObject.client.fax;
            dateValuelbl.Text = bonObject.date.ToString("dd/MM/yyyy HH:mm");
            contactTBox.Text = bonObject.contact;
            emailTBox.Text = bonObject.client.email;
            refAchattbox.Text = bonObject.ref_achat;
            designTBox.Text = bonObject.designationReception.designation;
            problTBox.Text = bonObject.designationReception.probleme;
        }
    }
}

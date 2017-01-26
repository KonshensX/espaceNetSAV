using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace espaceNetSAV
{
    public partial class UpdateBon : Form
    {
        BonReception bonObject;
        public UpdateBon(BonReception bon)
        {
            InitializeComponent();
            bonObject = bon;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void UpdateBon_Load(object sender, EventArgs e)
        {
            clientTBox.Text = bonObject.client.nom;
            telTBox.Text = bonObject.client.tel;
            faxTBox.Text = bonObject.client.fax;
            dateValuelbl.Text = bonObject.date.ToString("dd/MM/yyyy HH:mm");
            contactTBox.Text = bonObject.client.contact;
            emailTBox.Text = bonObject.client.email;
            refAchattbox.Text = bonObject.ref_achat;
            designTBox.Text = bonObject.designationReception.designation;
            problTBox.Text = bonObject.designationReception.probleme;

        }
    }
}

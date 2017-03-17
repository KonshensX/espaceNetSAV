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
    public partial class Details : Form
    {
        BonReception bonObject;
        public Details(BonReception bon)
        {
            InitializeComponent();
            this.bonObject = bon;
        }

        private void Details_Load(object sender, EventArgs e)
        {
            clientTBox.Text = bonObject.client.nom;
            telTBox.Text = bonObject.client.tel;
            faxTBox.Text = bonObject.client.fax;
            dateValuelbl.Text = bonObject.date.ToString("dd-MM-yyyy HH:mm");
            contactTBox.Text = bonObject.contact;
            emailTBox.Text = bonObject.client.email;
            refAchattbox.Text = bonObject.ref_achat;
            designTBox.Text = bonObject.designationReception.designation;
            problTBox.Text = bonObject.designationReception.probleme;
            diagnosicTBox.Text = bonObject.tech.diagnostics;
            taskTBox.Text = bonObject.tech.tasks;

        }
    }
}

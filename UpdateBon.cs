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
            contactTBox.Text = bonObject.contact;
            emailTBox.Text = bonObject.client.email;
            refAchattbox.Text = bonObject.ref_achat;
            designTBox.Text = bonObject.designationReception.designation;
            problTBox.Text = bonObject.designationReception.probleme;
            diagnosicTBox.Text = bonObject.tech.diagnostics;
            taskTBox.Text = bonObject.tech.tasks;
            devisTBox.Text = bonObject.devis;

            pictureBox1.Image = this.getImage(bonObject.tech.status);
        }

        private void devisButton_Click(object sender, EventArgs e)
        {
            //This will attach a devis number to an item
            bonObject.getItem(bonObject.id);
            bonObject.devis = devisTBox.Text;
            bonObject.updateDevis();
            this.clearStatusBarWithMessage("Numero devis bien changer");

        }
        /// <summary>
        /// This gets the correct image based on the given Status
        /// </summary>
        /// <param name="status">The status of the item</param>
        /// <returns></returns>
        private Bitmap getImage(Status status)
        {
            switch (status)
            {
                case Status.Fixed:
                    return Properties.Resources.ok;
                case Status.BeingRepeared:
                    return Properties.Resources.NOT_OK;
                default:
                    return Properties.Resources.NOT_OK;
            }
        }

        private void clearStatusBarWithMessage(string message) 
        {
            this.statusStrip1.Items.Clear();
            this.statusStrip1.Items.Add(message);
        }
    }
}

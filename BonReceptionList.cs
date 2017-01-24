using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace espaceNetSAV
{
    public partial class BonReceptionList : Form
    {
        public BonReceptionList()
        {
            InitializeComponent();
        }

        private void BonReceptionList_Load(object sender, EventArgs e)
        {
            BonReception bonReceptionService = new BonReception();
            DataTable myDataSource = bonReceptionService.GetData();

            BonDataGrid.DataSource = myDataSource;

            DataGridViewButtonColumn pdfButton = new DataGridViewButtonColumn();

            BonDataGrid.Columns.Add(pdfButton);

            pdfButton.HeaderText = "Voir";
            pdfButton.Name = "pdfButton";
            pdfButton.Text = "Fichier";
            pdfButton.UseColumnTextForButtonValue = true;

            BonDataGrid.Columns["Bon ID"].Visible = false;
            BonDataGrid.Columns["Client ID"].Visible = false;
            BonDataGrid.Columns["Designations ID"].Visible = false;
            BonDataGrid.Columns["Designation ID"].Visible = false;
            BonDataGrid.Columns["Clients ID"].Visible = false;
            BonDataGrid.Columns["Client Type"].Visible = false;
        }

        private void BonDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

                MessageBox.Show("Buttonwas clicked");
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                //TODO - Button Clicked - Execute Code Here
                
            }
        }
    }
}

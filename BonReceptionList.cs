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

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                //TODO - Button Clicked - Execute Code Here
                BonReception bonObject = new BonReception();
                bonObject.getDataForPdf((int)BonDataGrid.CurrentRow.Cells[BonDataGrid.Columns["Bon ID"].Index].Value);

                //MessageBox.Show(String.Format("Bon réception ID: {0}", BonDataGrid.Rows[BonDataGrid.CurrentRow.Index].Cells[0].Value));
                PdfGenerator pdfObject = new PdfGenerator(bonObject);

            }
        }
    }
}

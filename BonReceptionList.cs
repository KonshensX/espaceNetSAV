using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace espaceNetSAV
{
    public partial class BonReceptionList : Form
    {
        BonReception bonReceptionService;
        DataTable myDataSource;

        public BonReceptionList()
        {
            InitializeComponent();
            bonReceptionService = new BonReception();
            myDataSource = bonReceptionService.GetData();
        }

        private void BonReceptionList_Load(object sender, EventArgs e)
        {
            
            BonDataGrid.RowTemplate.Height = 30;
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
                var passObject = bonObject.getDataForPdf((int)BonDataGrid.CurrentRow.Cells[BonDataGrid.Columns["Bon ID"].Index].Value);

                //MessageBox.Show(String.Format("Bon réception ID: {0}", BonDataGrid.Rows[BonDataGrid.CurrentRow.Index].Cells[0].Value));
                PdfGenerator pdfObject = new PdfGenerator(passObject);

                statusStrip1.Items.Add("Pdf bien générer");

                Process.Start(@"C:\Program Files (x86)\Foxit Software\Foxit Reader\FoxitReader.exe", "myPdf.pdf");

            }
        }

        private void statusStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void BonDataGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = BonDataGrid.CurrentRow.Index;

            BonReception bonObject = new BonReception();
            bonObject.getItem((int)BonDataGrid.Rows[rowIndex].Cells[0].Value);
            UpdateBon formObject = new UpdateBon(bonObject);
            formObject.Show();

        }
    }
}

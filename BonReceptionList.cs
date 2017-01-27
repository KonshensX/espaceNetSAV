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
        DataView dataView;
        BonReception bonReceptionService;
        DataTable myDataSource;

        public BonReceptionList()
        {
            InitializeComponent();
            bonReceptionService = new BonReception();
            myDataSource = bonReceptionService.GetData();
            dataView = new DataView(myDataSource);
        }

        private void BonReceptionList_Load(object sender, EventArgs e)
        {
            
            BonDataGrid.RowTemplate.Height = 30;
            BonDataGrid.DataSource = dataView;

            DataGridViewButtonColumn pdfButton = new DataGridViewButtonColumn();

            BonDataGrid.Columns.Add(pdfButton);

            pdfButton.HeaderText = "Voir";
            
            pdfButton.Name = "pdfButton";
            pdfButton.Text = "Fichier";
            pdfButton.UseColumnTextForButtonValue = true;

            BonDataGrid.Columns["Bon N°"].Visible = true;
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


        private void BonDataGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = BonDataGrid.CurrentRow.Index;

            BonReception bonObject = new BonReception();
            bonObject.getItem((int)BonDataGrid.Rows[rowIndex].Cells[0].Value);
            UpdateBon formObject = new UpdateBon(bonObject);
            formObject.Show();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!(clientTBox.Text == "")) 
            {
                dataView.RowFilter = "Nom LIKE '%" + clientTBox.Text + "%'";
                //MessageBox.Show(dataView.RowFilter);
                BonDataGrid.DataSource = dataView;
            }
            else
            {
                BonDataGrid.DataSource = myDataSource;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            //Telephone textbox, i forgot this one too :'(
            if (!(telTBox.Text == ""))
            {
                dataView.RowFilter = "Telephone LIKE '%" + telTBox.Text + "%'";
                //MessageBox.Show(dataView.RowFilter);
                BonDataGrid.DataSource = dataView;
            }
            else
            {
                BonDataGrid.DataSource = myDataSource;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //Bon textbox, i just forgot to rename it lol pls don't judge :'(
            if (!(bonNumTBox.Text == ""))
            {
                dataView.RowFilter = "[Bon N°] = " + bonNumTBox.Text + "";
                //MessageBox.Show(dataView.RowFilter);
                BonDataGrid.DataSource = dataView;
            }
            else
            {
                BonDataGrid.DataSource = myDataSource;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (!(dateTimePicker1.Text == ""))
            {
                dataView.RowFilter = "Date >= #" + dateTimePicker1.Text + " 00:00# AND Date <= #" +dateTimePicker1.Text+ " 23:59#";
                //MessageBox.Show(dataView.RowFilter);
                BonDataGrid.DataSource = dataView;
            }
            else
            {
                BonDataGrid.DataSource = myDataSource;
            }
        }
    }
}

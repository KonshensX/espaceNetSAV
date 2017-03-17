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
        DataGridViewTextBoxColumn myEtatColumn;
        DataGridViewCheckBoxColumn myCheckbox;
        DataGridViewRow currentSelectedRow;

        public BonReceptionList()
        {
            InitializeComponent();
            bonReceptionService = new BonReception();
        }

        private void BonReceptionList_Load(object sender, EventArgs e)
        {
            this.GetDataFromDataBase();
            this.LoadDataIntoDataGrid();

            BonDataGrid.Columns["Bon N°"].Visible = true;
            BonDataGrid.Columns["Client ID"].Visible = false;
            BonDataGrid.Columns["Designations ID"].Visible = false;
            BonDataGrid.Columns["Tech ID"].Visible = false;
            BonDataGrid.Columns["Designation ID"].Visible = false;
            BonDataGrid.Columns["Clients ID"].Visible = false;
            BonDataGrid.Columns["Telephone"].Visible = false;
            BonDataGrid.Columns["Ref Achat"].Visible = false;
            BonDataGrid.Columns["Devis"].Visible = false;
            BonDataGrid.Columns["Fax"].Visible = false;
            BonDataGrid.Columns["Contact"].Visible = false;
            BonDataGrid.Columns["Email"].Visible = false;
            BonDataGrid.Columns["ID Bon"].Visible = false;
            BonDataGrid.Columns["Tech ID ID"].Visible = false;
            BonDataGrid.Columns["Etat"].Visible = false; //Index of this field is 20 (Original Field)
            BonDataGrid.Columns["Validé"].Visible = false;
            //Adding a new text columns to the checkbox 
            myEtatColumn = new DataGridViewTextBoxColumn() 
            {
                HeaderText = "Etat courant",
                Name = "myEtatColumn"
            };
            BonDataGrid.Columns.Add(myEtatColumn);
            //End of adding the text box
            BonDataGrid.Columns["Client Type"].Visible = false;
            //PDF button 
            DataGridViewButtonColumn pdfButton = new DataGridViewButtonColumn();

            BonDataGrid.Columns.Add(pdfButton);

            pdfButton.HeaderText = "Voir";

            pdfButton.Name = "pdfButton";
            pdfButton.Text = "Fichier";
            pdfButton.UseColumnTextForButtonValue = true;
            //End of PDF Button

            //`Folder` Checbox 

            myCheckbox = new DataGridViewCheckBoxColumn();

            myCheckbox.HeaderText = "Validé";
            myCheckbox.HeaderText = "Validé";
            myCheckbox.Name = "myFoler";

            BonDataGrid.Columns.Add(myCheckbox);

            #region Changing columns width 
            BonDataGrid.Columns["Bon N°"].Width = 40;
            #endregion

            //this.changeRowsColors();
            //this.onLoadCheckboxStatusChange();
            this.BonDataGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.BonDataGrid_CellValueChanged);
            
            this.onLoadUpdateStatusText();
            //this.onLoadCheckboxStatusChange();
        }

        private void BonDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                //MessageBox.Show(BonDataGrid.CurrentRow.Cells[BonDataGrid.Columns["Bon N°"].Index].Value.ToString());
                //TODO - Button Clicked - Execute Code Here
                //MessageBox.Show(String.Format("Bon réception ID: {0}", BonDataGrid.Rows[BonDataGrid.CurrentRow.Index].Cells[0].Value));
                BonReception passObject = new BonReception();
                passObject.getDataForPdf((int)BonDataGrid.CurrentRow.Cells[BonDataGrid.Columns["Bon N°"].Index].Value);
                PdfGenerator pdfObject = new PdfGenerator(passObject);

                statusStrip1.Items.Add("Pdf bien générer");

                Process.Start(@"myPdf.pdf");

            }
        }


        private void BonDataGrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var rowIndex = BonDataGrid.CurrentRow.Index;

            BonReception bonObject = new BonReception();
            var id = (int)BonDataGrid.Rows[rowIndex].Cells[0].Value;
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
                this.onTextChangeUpdateStatus(dataView.ToTable());
            }
            else
            {
                BonDataGrid.DataSource = myDataSource;
                this.onLoadUpdateStatusText();
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
                
                this.onTextChangeUpdateStatus(dataView.ToTable());
            }
            else
            {
                BonDataGrid.DataSource = myDataSource;
                this.onLoadUpdateStatusText();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            try
            {
                    //Bon textbox, i just forgot to rename it lol pls don't judge :'(
                if (!(bonNumTBox.Text == ""))
                {
                    dataView.RowFilter = "[Bon N°] = " + bonNumTBox.Text + "";
                    //MessageBox.Show(dataView.RowFilter);
                    BonDataGrid.DataSource = dataView;
                    this.onTextChangeUpdateStatus(dataView.ToTable());
                }
                else
                {
                    BonDataGrid.DataSource = myDataSource;
                    this.onLoadUpdateStatusText();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Opps Error!!");
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (!(dateTimePicker1.Text == ""))
            {
                dataView.RowFilter = "Date >= #" + dateTimePicker1.Text + " 00:00# AND Date <= #" +dateTimePicker1.Text+ " 23:59#";
                //MessageBox.Show(dataView.RowFilter);
                BonDataGrid.DataSource = dataView;
                this.onTextChangeUpdateStatus(dataView.ToTable());
            }
            else
            {
                BonDataGrid.DataSource = myDataSource;
                this.onLoadUpdateStatusText();
            }
        }

        private void changeRowsColors()
        {
            foreach (DataGridViewRow row in BonDataGrid.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.OrangeRed;
            }
        }

        private void onLoadUpdateStatusText()
        {

            for (int i = 0; i < myDataSource.Rows.Count; i++)
            {
                var valueOfField = myDataSource.Rows[i].ItemArray[22].ToString();
                BonDataGrid.Rows[i].Cells[myEtatColumn.Index].Value = ((valueOfField == "1")? "Réparé" : "Pas Encore");
            }
        }

        private void onTextChangeUpdateStatus(DataTable table)
        {
            int counter = 0;
            foreach (DataRow row in table.Rows)
            {

                var valueOfStatusField = Convert.ToInt32(row.ItemArray[row.ItemArray.Length - 2]);
                if (valueOfStatusField == 1)
                {
                    BonDataGrid.Rows[counter++].Cells[myEtatColumn.Index].Value = "Réparé";
                }
                else
                {
                    BonDataGrid.Rows[counter++].Cells[myEtatColumn.Index].Value = "Pas Encore";
                }
            }
        }

        private void actualiserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Refresh();
        }

        private void actualiséToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //this.BonReceptionList_Load(sender, e);
                
        }

        private void onLoadCheckboxStatusChange()
        {

            //Update the checkbox 
            int counter = 0;
            foreach (DataRow row in myDataSource.Rows)
            {

                var valueOfStatusField = Convert.ToInt32(row.ItemArray[row.ItemArray.Length - 1]);
                if (valueOfStatusField == 1)
                {
                    BonDataGrid.Rows[counter].Cells[myCheckbox.Index].Value = true;
                }
                else
                {
                    BonDataGrid.Rows[counter].Cells[myCheckbox.Index].Value = false;
                }
                counter++;
            }
            //End of updating the checkbox
        }

        private void BonDataGrid_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == myCheckbox.Index)
            {
                BonDataGrid.EndEdit();
            }
        }

        private void BonDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            
            if (e.ColumnIndex == myCheckbox.Index)
            {
                if (AccessRow(e.RowIndex, myCheckbox.Index).ToLower() == "true")
                {
                    if (MessageBox.Show("Attention!", "Attention", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
                    {
                        BonReception bonObject = new BonReception().getItem(Convert.ToInt32(BonDataGrid.Rows[e.RowIndex].Cells["Bon N°"].Value));

                        bonObject.dossier = Dossier.Valide;

                        bonObject.UpdateDossierStatus();

                        new Admin.History(Convert.ToInt32(AccessRow(e.RowIndex, "Bon N°")), String.Format("Validé le dossier N° {0} de {1}", AccessRow(e.RowIndex, "Bon N°"), AccessRow(e.RowIndex, "Nom")), "", Program._USER).Save();
                        this.statusStrip1.Items.Clear();

                        this.statusStrip1.Items.Add("Dossier validé et notification mail a été envoyé");
                        this.statusStrip1.Items.Clear();
                        this.statusStrip1.Items.Add("Ayyeee");
                        this.DoWork();

                        try
                        {
                            //new Admin.EmailNotification(bonObject);
                        }
                        catch (Exception ex)
                        {

                            MessageBox.Show("Error : " + ex.StackTrace, ex.Message);
                        }

                        //dataView.Delete();
                    }
                } 
            }
        }

        private string AccessRow(int rowIndex, int cellIndex)
        {
            return BonDataGrid.Rows[rowIndex].Cells[cellIndex].Value.ToString();
        }

        private string AccessRow(int rowIndex, string cellIndex)
        {
            return BonDataGrid.Rows[rowIndex].Cells[cellIndex].Value.ToString();
        }

        private void LoadDataIntoDataGrid()
        {

            BonDataGrid.RowTemplate.Height = 30;
            BonDataGrid.DataSource = dataView;
        }

        private void DoWork()
        {
            this.GetDataFromDataBase();
            this.LoadDataIntoDataGrid();
            this.onLoadUpdateStatusText();
        }

        public void GetDataFromDataBase()
        {
            myDataSource = bonReceptionService.GetData();

            dataView = new DataView(myDataSource);
            //dataView.Sort = "Bon N° DESC";
        }

        private void modifierLaLigneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BonReception bonObject = new BonReception().getItem(Convert.ToInt32(AccessRow(currentSelectedRow.Index, "Bon N°")));
            ChangeValuesBonReception formObject = new ChangeValuesBonReception(bonObject);

            formObject.Show();
        }

        private void BonDataGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            currentSelectedRow = BonDataGrid.Rows[e.RowIndex];
        }

        private void detailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var rowIndex = BonDataGrid.CurrentRow.Index;

            BonReception bonObject = new BonReception();
            var id = (int)BonDataGrid.Rows[rowIndex].Cells[0].Value;
            bonObject.getItem((int)BonDataGrid.Rows[rowIndex].Cells[0].Value);
            UpdateBon formObject = new UpdateBon(bonObject);
            formObject.Show();
        }

    }
}

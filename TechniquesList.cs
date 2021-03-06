﻿using System;
using System.Data;
using System.Windows.Forms;

namespace espaceNetSAV
{
    public partial class TechniquesList : Form
    {
        DataView dataView;
        int howMany = 0;
        BonReception bonReceptionService;
        DataTable myDataSource;
        DataGridViewCheckBoxColumn repeared;
        DataGridViewButtonColumn myButton;
        DataGridViewButtonColumn detailButton;
        bool isClicked = false;

        //DataGridViewTextBoxColumn myPrixColumn;
            

        //Vars 

        string initialDiagnostic;
        string initialTasks;
        string intitialPrice;

        public TechniquesList()
        {
            InitializeComponent();
            bonReceptionService = new BonReception();
            myDataSource = bonReceptionService.GetData();
            //dataView = new DataView(myDataSource);
            
        }

        private void TechniquesList_Load(object sender, EventArgs e)
        {

            howMany++;
            //dataView = new dataView()
            BonDataGrid.RowTemplate.Height = 30;
            //BonDataGrid.DataSource = dataView;

            //Update the values of etat according to the datat from the database

            dataView = new DataView(myDataSource);

            dataView.Sort = "Bon N° DESC";

            BonDataGrid.DataSource = dataView;
            
            
            //END OF A SECIOTN 
            repeared = new DataGridViewCheckBoxColumn();

            BonDataGrid.Columns.Add(repeared);
            repeared.HeaderText = "Status";
            repeared.Name = "status";
            repeared.Width = 20;

            //Adding a new text columns to the checkbox 
            //Why this Field?
            //myPrixColumn = new DataGridViewTextBoxColumn()
            //{
            //    HeaderText = "Prix",
            //    Name = "myPrixColumn",
                
            //};
            //BonDataGrid.Columns.Add(myPrixColumn);

            //Adding a Datagrid type button just for testing purposes

            myButton = new DataGridViewButtonColumn();

            myButton.Name = "myButton";
            myButton.HeaderText = "Enregistrer";
            myButton.Text = "Enregistrer";
            


            myButton.UseColumnTextForButtonValue = true;
            BonDataGrid.Columns.Add(myButton);
           

            //Details button
            detailButton = new DataGridViewButtonColumn();

            detailButton.Name = "detailButton";
            detailButton.HeaderText = "Details";
            detailButton.Text = "Details";

            detailButton.UseColumnTextForButtonValue = true;
            BonDataGrid.Columns.Add(detailButton);
            

            //End of test 

            BonDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            #region Renaming the columns 
            BonDataGrid.Columns["Bon N°"].Visible = true;
            BonDataGrid.Columns["Client ID"].Visible = false;
            BonDataGrid.Columns["Designations ID"].Visible = false;
            BonDataGrid.Columns["Tech ID"].Visible = false;
            BonDataGrid.Columns["Designation ID"].Visible = false;
            BonDataGrid.Columns["Clients ID"].Visible = false;
            BonDataGrid.Columns["Telephone"].Visible = false;
            BonDataGrid.Columns["Client Type"].Visible = false;
            BonDataGrid.Columns["Ref Achat"].Visible = false;
            BonDataGrid.Columns["Devis"].Visible = false;
            BonDataGrid.Columns["Fax"].Visible = false;
            BonDataGrid.Columns["Contact"].Visible = false;
            BonDataGrid.Columns["Email"].Visible = false;
            BonDataGrid.Columns["ID Bon"].Visible = false;
            BonDataGrid.Columns["Tech ID ID"].Visible = false;
            BonDataGrid.Columns["Etat"].Visible = false; //Index of this field is 20 (Original Field)
            BonDataGrid.Columns["Validé"].Visible = false;
            BonDataGrid.Columns["Status"].HeaderText = "Validé";
            //MessageBox.Show(repeared.Index.ToString());
            #endregion

            #region Changing the columns width
            //Change the width of the columns 
            BonDataGrid.Columns["Bon N°"].Width = 40;
            detailButton.Width = 50;
            myButton.Width = 80;
            #endregion

            this.onLoadCheckboxStatusChange();

            if(dataView.Count > 0)
                BonDataGrid.Rows[0].Selected = true;



            if (!Program._USER.Permissions.CanValideDossier)
            {
                myButton.ReadOnly = false;
                repeared.ReadOnly = false;
            }


            this.BonDataGrid.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.BonDataGrid_CellValueChanged);
        }


        private void BonDataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            //When we click on the Enter Button
            if (e.KeyCode == Keys.Enter)
            {
                
                //BonReception bonObject = new BonReception();
                //bonObject.getItem((int)BonDataGrid.Rows[BonDataGrid.CurrentRow.Index].Cells["Bon N°"].Value);
                //Technique techObject = new Technique();
                //techObject.getItem(bonObject.id);
                MessageBox.Show("THE ID IS: " + BonDataGrid.Rows[BonDataGrid.CurrentRow.Index].Cells["Diagnostics"].Value.ToString());
                //techObject.UpdateObject(bonObject.id);
                //techObject.persistObjectToDatabase();

                e.SuppressKeyPress = true;
            }
        }
        //TODO
        private void BonDataGrid_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            //if (howMany == 1)
            //{
            //    howMany++;
            //    return;
            //}
            //Handle the checkbox state change here 
            if (e.ColumnIndex == repeared.Index && isClicked)
            {
                if (!Program._USER.Permissions.CanValideDossier)
                {
                    MessageBox.Show("Vous avez pas le droit de modifier ce champs!", "Permissions requis", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                var cellValue = (bool)BonDataGrid.Rows[BonDataGrid.CurrentRow.Index].Cells[repeared.Index].Value;
                var techID = Convert.ToInt32(BonDataGrid.Rows[BonDataGrid.CurrentRow.Index].Cells["Tech ID"].Value);
                var rowIndex = BonDataGrid.CurrentRow.Index;
                Technique techObject = new Technique();
                techObject.getItem(techID);
                //var finalStatus = ((cellValue) ? Status.Fixed : Status.BeingRepeared);
                if (((bool)BonDataGrid.Rows[BonDataGrid.CurrentRow.Index].Cells[repeared.Index].Value) == true)
                {
                    //This where the value should be updated to 1 which means it was fixed 
                    techObject.updateItemStatus((cellValue) ? Status.Fixed : Status.BeingRepeared);

                    new Admin.History(Convert.ToInt32(AccessRow(e.RowIndex, "Bon N°")), "En Cours ", "Réparé", Program._USER).Save();

                    //Send mail to notify admin that the item is ready to be handed

                    new Admin.EmailNotification(new BonReception().getItem(Convert.ToInt32(AccessRow(e.RowIndex, "Bon N°"))), "malik.benmakhlouf@gmail.com");

                    new Admin.EmailNotification(new BonReception().getItem(Convert.ToInt32(AccessRow(e.RowIndex, "Bon N°"))), "en.samira01@gmail.com");

                }
                else if (((bool)BonDataGrid.Rows[BonDataGrid.CurrentRow.Index].Cells[repeared.Index].Value) == false)
                {
                    ///TODO: THIS IS NOT PERSIST TO HISTORY FIX IT.
                    //This is where the value updates to 0 which means the item was not fixed or its still being repeared
                    techObject.updateItemStatus((cellValue) ? Status.Fixed : Status.BeingRepeared);

                    new Admin.History(Convert.ToInt32(AccessRow(e.RowIndex, "Bon N°")), "Réparé", "En Cours", Program._USER).Save();
                }
                this.ClearStatusBarWithMessage("Etat bien changer");
            }
            
            
        }

        private void BonDataGrid_CellMouseUp(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex == repeared.Index)
            {
                BonDataGrid.EndEdit();
            }
        }

        private void BonDataGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            //MessageBox.Show("CurrentRow index is " + BonDataGrid.CurrentRow.Index.ToString());
            //if (MessageBox.Show("Confirmation du click!", "Confirmation", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
            //{
            //    if (AccessRow(e.RowIndex, "Validé") == "true")
            //    {
            //        BonDataGrid.Rows[e.RowIndex].Cells["Validé"].Value = false;
            //    }
            //    return;
            //}

            if (e.ColumnIndex == repeared.Index)
            {
                isClicked = true;
                return;
            }

            if (e.ColumnIndex == myButton.Index && !myButton.ReadOnly)
            {
                var diagnosticsText = BonDataGrid.Rows[BonDataGrid.CurrentRow.Index].Cells["Diagnostics"].Value.ToString();
                var tasksText = BonDataGrid.Rows[BonDataGrid.CurrentRow.Index].Cells["Tàches Effectuer"].Value.ToString();
                var numeroBon = Convert.ToInt32(BonDataGrid.Rows[BonDataGrid.CurrentRow.Index].Cells["ID Bon"].Value);
                var price = Convert.ToDouble(AccessRow(e.RowIndex, "Prix"));
                //var price = BonDataGrid.Rows[e.RowIndex].Cells[myPrixColumn.Index].Value.ToString();
                //SO FAR SO GOOD 

                //Persist the values to the database
                Technique techObject = new Technique();
                //This is passing the bon id but the query actualy wants the Tech.id ???
                techObject.getItem(Convert.ToInt32(numeroBon));
                techObject.UpdateObject(diagnosticsText, tasksText, numeroBon, price);

                this.ClearStatusBarWithMessage("Modifications bien enregistré");

                if (AccessRow(e.RowIndex, "Diagnostics").Equals(initialDiagnostic) && AccessRow(e.RowIndex, "Tàches Effectuer").Equals(initialTasks) && AccessRow(e.RowIndex, "Prix").Equals(intitialPrice))
                    return;

                if (!initialDiagnostic.Equals(BonDataGrid.Rows[e.RowIndex].Cells["Diagnostics"].Value.ToString()))
                {
                    var diagnostics = AccessRow(e.RowIndex, "Diagnostics");
                    new Admin.History(Convert.ToInt32(AccessRow(e.RowIndex, "Bon N°")), String.Format("{1}", this.AccessRow(e.RowIndex, "Bon N°"), initialDiagnostic), diagnostics, Program._USER).Save();
                }

                if (!initialTasks.Equals(BonDataGrid.Rows[e.RowIndex].Cells["Tàches Effectuer"].Value.ToString()))
                {
                    var tasks = AccessRow(e.RowIndex, "Tàches Effectuer");
                    new Admin.History(Convert.ToInt32(AccessRow(e.RowIndex, "Bon N°")), String.Format("{1}", this.AccessRow(e.RowIndex, "Bon N°"), initialTasks), tasks, Program._USER).Save();
                }


                if (!intitialPrice.Equals(BonDataGrid.Rows[e.RowIndex].Cells["Prix"].Value.ToString()))
                {
                    //This is going to hold the history section*
                    new Admin.History(Convert.ToInt32(AccessRow(e.RowIndex, "Bon N°")), String.Format("Ancienne Valeur: {0}", intitialPrice), String.Format("Nouvelle Valeur: {0}", AccessRow(e.RowIndex, "Prix")), Program._USER).Save();
                }

            }
            else if (e.ColumnIndex == detailButton.Index)
            {
                Admin.Details formObject = new Admin.Details(new BonReception().getItem(Convert.ToInt32(AccessRow(e.RowIndex, "Bon N°"))));
                formObject.Show();
            }

            

        }

        private void clientTBox_TextChanged(object sender, EventArgs e)
        {
            if (!(clientTBox.Text == ""))
            {
                dataView.RowFilter = "Nom LIKE '%" + clientTBox.Text + "%'";
                //MessageBox.Show(dataView.RowFilter);
                DataTable myTempTable = dataView.ToTable();
                BonDataGrid.DataSource = dataView;
                this.onTextChangeUpdateCheckboxes(myTempTable);
            }
            else
            {
                BonDataGrid.DataSource = myDataSource;
                this.onLoadCheckboxStatusChange();
            }
            isClicked = false;
        }

        private void telTBox_TextChanged(object sender, EventArgs e)
        {
            //Telephone textbox, i forgot this one too :'(
            if (!(telTBox.Text == ""))
            {
                dataView.RowFilter = "Telephone LIKE '%" + telTBox.Text + "%'";
                //MessageBox.Show(dataView.RowFilter);

                DataTable myTempTable = dataView.ToTable();
                BonDataGrid.DataSource = dataView;
                this.onTextChangeUpdateCheckboxes(myTempTable);
            }
            else
            {
                BonDataGrid.DataSource = myDataSource;
                this.onLoadCheckboxStatusChange();
            }

            isClicked = false;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            if (!(dateTimePicker1.Text == ""))
            {
                dataView.RowFilter = "Date >= #" + dateTimePicker1.Text + " 00:00# AND Date <= #" + dateTimePicker1.Text + " 23:59#";
                //MessageBox.Show(dataView.RowFilter);

                DataTable myTempTable = dataView.ToTable();
                BonDataGrid.DataSource = dataView;
                this.onTextChangeUpdateCheckboxes(myTempTable);
            }
            else
            {
                BonDataGrid.DataSource = myDataSource;
                this.onLoadCheckboxStatusChange();
            }
        }

        private void bonNumTBox_TextChanged(object sender, EventArgs e)
        {
            //Bon textbox, i just forgot to rename it lol pls don't judge :'(
            if (!(bonNumTBox.Text == ""))
            {
                dataView.RowFilter = "[Bon N°] = " + bonNumTBox.Text + "";
                //MessageBox.Show(dataView.RowFilter);

                DataTable myTempTable = dataView.ToTable();
                BonDataGrid.DataSource = dataView;
                this.onTextChangeUpdateCheckboxes(myTempTable);
            }
            else
            {
                BonDataGrid.DataSource = myDataSource;
                this.onLoadCheckboxStatusChange();
            }

            isClicked = false;
        }

        public void ClearStatusBarWithMessage(string message)
        {
            this.statusStrip1.Items.Clear();
            statusStrip1.Items.Add(message);

        }

        private void onLoadCheckboxStatusChange()
        {

            //Update the checkbox 
            int counter = 0;
            foreach (DataRow row in myDataSource.Rows)
            {

                var valueOfStatusField = Convert.ToInt32(row.ItemArray[row.ItemArray.Length - 2]);
                if (valueOfStatusField == 1)
                {
                    BonDataGrid.Rows[counter].Cells[repeared.Index].Value = true;
                }
                else
                {
                    BonDataGrid.Rows[counter].Cells[repeared.Index].Value = false;
                }
                counter++;
            }
            //End of updating the checkbox
        }

        private void onTextChangeUpdateCheckboxes(DataTable table)
        {
            int counter = 0;
            foreach (DataRow row in table.Rows)
            {

                var valueOfStatusField = Convert.ToInt32(row.ItemArray[row.ItemArray.Length - 2]);
                if (valueOfStatusField == 1)
                {
                    BonDataGrid.Rows[counter].Cells[repeared.Index].Value = true;
                }
                else
                {
                    BonDataGrid.Rows[counter].Cells[repeared.Index].Value = false;
                }
                counter++;
            }
        }
        
        private void BonDataGrid_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            initialDiagnostic = BonDataGrid.Rows[e.RowIndex].Cells["Diagnostics"].Value.ToString();
            initialTasks = BonDataGrid.Rows[e.RowIndex].Cells["Tàches Effectuer"].Value.ToString();
            intitialPrice = BonDataGrid.Rows[e.RowIndex].Cells["Prix"].Value.ToString();
        }



        private string AccessRow(int rowIndex, int cellIndex)
        {
            return BonDataGrid.Rows[rowIndex].Cells[cellIndex].Value.ToString();
        }

        private string AccessRow(int rowIndex, string cellsIndexName)
        {
            return BonDataGrid.Rows[rowIndex].Cells[cellsIndexName].Value.ToString();
        }

        private void TechniquesList_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Dispose();
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void technqiueToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void oKOKToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void historiqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Program._USER.Permissions.CanSeeHistory)
            {
                MessageBox.Show("Vous pouvez pas ouvrir ce fenetre!");
                return;
            }
            
            Admin.CompleteHistoryList formObject = new Admin.CompleteHistoryList();
            formObject.Show();

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace espaceNetSAV
{
    public partial class TechniquesList : Form
    {
        DataView dataView;
        BonReception bonReceptionService;
        DataTable myDataSource;
        public TechniquesList()
        {
            InitializeComponent();
            bonReceptionService = new BonReception();
            myDataSource = bonReceptionService.GetData();
            dataView = new DataView(myDataSource);
        }

        private void TechniquesList_Load(object sender, EventArgs e)
        {

            BonDataGrid.RowTemplate.Height = 30;
            BonDataGrid.DataSource = dataView;

            DataGridViewCheckBoxColumn repeared = new DataGridViewCheckBoxColumn();

            BonDataGrid.Columns.Add(repeared);
            repeared.HeaderText = "Etat";

            BonDataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;

            BonDataGrid.Columns["Bon N°"].Visible = true;
            BonDataGrid.Columns["Client ID"].Visible = false;
            BonDataGrid.Columns["Designations ID"].Visible = false;
            BonDataGrid.Columns["Designation ID"].Visible = false;
            BonDataGrid.Columns["Clients ID"].Visible = false;
            BonDataGrid.Columns["Client Type"].Visible = false;
            BonDataGrid.Columns["Tech ID"].Visible = false;
            BonDataGrid.Columns["Tech ID ID"].Visible = false;
        }


        private void BonDataGrid_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Technique techObject = new Technique();

                MessageBox.Show(BonDataGrid.Rows[BonDataGrid.CurrentRow.Index].Cells["Diagnostics"].Value.ToString());

                e.SuppressKeyPress = true;
            }
        }

    }
}

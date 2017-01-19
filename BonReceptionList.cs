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

            BonDataGrid.Columns["Bon ID"].Visible = false;
            BonDataGrid.Columns["Client ID"].Visible = false;
            BonDataGrid.Columns["Designations ID"].Visible = false;
            BonDataGrid.Columns["Designation ID"].Visible = false;
            BonDataGrid.Columns["Clients ID"].Visible = false;
            BonDataGrid.Columns["Client Type"].Visible = false;
        }
    }
}

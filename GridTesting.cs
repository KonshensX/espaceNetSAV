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
    public partial class GridTesting : Form
    {
        DataView dataView;
        DataTable data;
        public GridTesting()
        {
            InitializeComponent();
            
            //dataView = new DataView(data);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //THis is my reference

            foreach (DataRow row in data.Rows)
            {
                row.SetField(20, 22);
            }
            dataGridView1.DataSource = data;
            //data.
        }

        private void GridTesting_Load(object sender, EventArgs e)
        {

            BonReception bonObject = new BonReception();

            data = bonObject.GetData();
            dataView = new DataView(data);
            dataGridView1.DataSource = dataView;
        }
    }
}

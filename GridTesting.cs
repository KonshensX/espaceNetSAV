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
        public GridTesting()
        {
            InitializeComponent();
        }


        private void GridTesting_Load(object sender, EventArgs e)
        {
            Program._USER.GetUser(1);
        }
    }
}

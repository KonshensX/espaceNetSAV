using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace espaceNetSAV.Admin
{
    public partial class AddCategory : Form
    {
        public AddCategory()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Category catObject = new Category(textBox1.Text);

            catObject.saveToDatabase();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

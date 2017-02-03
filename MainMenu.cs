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
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void technique_Click(object sender, EventArgs e)
        {
            TechniquesList formObject = new TechniquesList();
            formObject.Show();
        }

        private void reception_Click(object sender, EventArgs e)
        {
            FormulaireReception formObject = new FormulaireReception();
            formObject.Show();
        }

        private void bonList_Click(object sender, EventArgs e)
        {
            BonReceptionList formObject = new BonReceptionList();
            formObject.Show();
        }
    }
}

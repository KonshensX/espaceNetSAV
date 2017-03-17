using System;
using System.Windows.Forms;
using espaceNetSAV.Admin;

namespace espaceNetSAV.Testing
{
    public partial class Logger : Form
    {
        const int _LIMIT = 2000;
        public Logger()
        {
            InitializeComponent();
        }

        private void Logger_Load(object sender, EventArgs e)
        {
            Program._USER.GetUser(9);
            for (int i = 0; i < _LIMIT; i++)
            {
                //new Admin.History(String.Format("Old value {0}", i), String.Format("New Value {0}", i), Program._USER).Save();

                listView1.Items.Add(new ListViewItem(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss"), String.Format("{0} Ajouter avec success!", i)));
            }
        }
    }
}

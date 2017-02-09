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
    public partial class CompleteHistoryList : Form
    {
        public CompleteHistoryList()
        {
            InitializeComponent();
        }

        private void CompleteHistoryList_Load(object sender, EventArgs e)
        {
            List<History> myList = new History().GetCompleteHistoryWithUsers();

            foreach (History item in myList)
            {
                listView1.Items.Add(new ListViewItem(new string[] { item.User.Name, item.Date.ToString("dd/MM/yyyy HH:mm"), item.OldValue, item.NewValue }));
            }
        }
    }
}

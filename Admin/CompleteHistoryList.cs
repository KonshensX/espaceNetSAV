using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Diagnostics;

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
            if (!Program._USER.Permissions.CanSeeHistory && !Program._USER.isAdmin())
                return;
            List<History> myList = new History().GetCompleteHistoryWithUsers();

            foreach (History item in myList)
            {
                listView1.Items.Add(new ListViewItem(new string[] { item.User.Name, item.Date.ToString("dd/MM/yyyy HH:mm"), item.OldValue, item.NewValue, item.BonNumero.ToString() }));
            }

        }
    }
}

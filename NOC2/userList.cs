using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NOC2
{
    public partial class userList : Form
    {
        public int userId { get; set; }

        public userList()
        {
            InitializeComponent();
        }

        private void userList_Load(object sender, EventArgs e)
        {
            string getUsersQuery = "SELECT userid as `Id`, username as `Felhasznalonev`, groupName as `Jogosultsagi csoport` FROM users, groups WHERE users.group_id = groups.groupid AND users.userid != "+Framework.MyUserId;
            var data = Framework.db.GetData(getUsersQuery);
            dataGridView1.DataSource = data;

            DataGridViewButtonColumn dltbuttonColumn = new DataGridViewButtonColumn();
            dltbuttonColumn.Name = "delete";
            dltbuttonColumn.HeaderText = "Törlés";
            dltbuttonColumn.Text = "Törlés";
            dltbuttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Insert(3, dltbuttonColumn);

            DataGridViewButtonColumn updtbuttonColumn = new DataGridViewButtonColumn();
            updtbuttonColumn.Name = "update";
            updtbuttonColumn.HeaderText = "Szerkesztés";
            updtbuttonColumn.Text = "Szerkesztés";
            updtbuttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Insert(4, updtbuttonColumn);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            //MessageBox.Show(Convert.ToString(e.ColumnIndex));
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string user_id = senderGrid.CurrentRow.Cells["Id"].Value.ToString();
                userId = Convert.ToInt32(senderGrid.CurrentRow.Cells["Id"].Value.ToString());
                if (e.ColumnIndex == 0)//Delete user
                {
                    if (MessageBox.Show("Biztosan törlöd?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //MessageBox.Show(user_id);
                        string deleteQuery = "DELETE FROM `users` WHERE `userid` = "+ user_id;
                        Framework.db.RunQuery(deleteQuery);
                        MessageBox.Show("Felhasználó törölve!");
                    }
                }

                if (e.ColumnIndex == 1)//Update user
                {
                    UpdateUser updateForm = new UpdateUser();
                    updateForm.user = this;
                    updateForm.Show();
                }
            }
        }
    }
}

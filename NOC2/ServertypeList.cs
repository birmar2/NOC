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
    public partial class ServertypeList : Form
    {
        public int servertypeId { get; set; }
        public ServertypeList()
        {
            InitializeComponent();
        }

        private void ServertypeList_Load(object sender, EventArgs e)
        {
            string getServersQuery = "SELECT servertypeid as `Id`, servertypename as `Tipus` FROM servertypes";
            var data = Framework.db.GetData(getServersQuery);
            dataGridView1.DataSource = data;

            DataGridViewButtonColumn dltbuttonColumn = new DataGridViewButtonColumn();
            dltbuttonColumn.Name = "delete";
            dltbuttonColumn.HeaderText = "Törlés";
            dltbuttonColumn.Text = "Törlés";
            dltbuttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Insert(2, dltbuttonColumn);

            DataGridViewButtonColumn updtbuttonColumn = new DataGridViewButtonColumn();
            updtbuttonColumn.Name = "update";
            updtbuttonColumn.HeaderText = "Szerkesztés";
            updtbuttonColumn.Text = "Szerkesztés";
            updtbuttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Insert(3, updtbuttonColumn);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            //MessageBox.Show(Convert.ToString(e.ColumnIndex));
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string servertype_id = senderGrid.CurrentRow.Cells["Id"].Value.ToString();
                servertypeId = Convert.ToInt32(senderGrid.CurrentRow.Cells["Id"].Value.ToString());
                if (e.ColumnIndex == 0)//Delete group
                {
                    if (MessageBox.Show("Biztosan törlöd?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //MessageBox.Show(user_id);
                        string deleteQuery = "DELETE FROM `servertypes` WHERE `servertypeid` = " + servertype_id;
                        Framework.db.RunQuery(deleteQuery);
                        MessageBox.Show("Szervertípus törölve!");
                    }
                }

                if (e.ColumnIndex == 1)//Update user
                {
                    UpdateServertype updateForm = new UpdateServertype();
                    updateForm.servertype = this;
                    updateForm.Show();
                }
            }
        }
    }
}

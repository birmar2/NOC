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
    public partial class ServerList : Form
    {
        public int serverId { get; set; }
        Connection db = new Connection();
        public ServerList()
        {
            InitializeComponent();
        }

        private void ServerList_Load(object sender, EventArgs e)
        {
            string getServersQuery = "SELECT serverid as `Id`, servername as `Nev`, servertypename as `Tipusa`, servermemory as `Memoria`, serverdisk as `Hattertar`, servercpu as `CPU`,serveropsystem as `Op. rendszer`  FROM servers,servertypes WHERE servers.servertype_id = servertypes.servertypeid";
            var data = db.GetData(getServersQuery);
            dataGridView1.DataSource = data;

            DataGridViewButtonColumn dltbuttonColumn = new DataGridViewButtonColumn();
            dltbuttonColumn.Name = "delete";
            dltbuttonColumn.HeaderText = "Töröl";
            dltbuttonColumn.Text = "Töröl";
            dltbuttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Insert(7, dltbuttonColumn);

            DataGridViewButtonColumn updtbuttonColumn = new DataGridViewButtonColumn();
            updtbuttonColumn.Name = "update";
            updtbuttonColumn.HeaderText = "Szerkeszt";
            updtbuttonColumn.Text = "Szerkeszt";
            updtbuttonColumn.UseColumnTextForButtonValue = true;
            dataGridView1.Columns.Insert(8, updtbuttonColumn);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;
            //MessageBox.Show(Convert.ToString(e.ColumnIndex));
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string server_id = senderGrid.CurrentRow.Cells["Id"].Value.ToString();
                serverId = Convert.ToInt32(senderGrid.CurrentRow.Cells["Id"].Value.ToString());
                if (e.ColumnIndex == 0)//Delete group
                {
                    if (MessageBox.Show("Biztosan törlöd?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        //MessageBox.Show(user_id);
                        string deleteQuery = "DELETE FROM `servers` WHERE `serverid` = " + server_id;
                        db.RunQuery(deleteQuery);
                        MessageBox.Show("Azonosítási szerver törölve!");
                    }
                }

                if (e.ColumnIndex == 1)//Update user
                {
                    UpdateServer updateForm = new UpdateServer();
                    updateForm.server = this;
                    updateForm.Show();
                }
            }
        }
    }
}

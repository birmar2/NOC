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
    public partial class SystemParamList : Form
    {
        public int sysParamId { get; set; }
        public SystemParamList()
        {
            InitializeComponent();
        }

        private void SystemParamList_Load(object sender, EventArgs e)
        {
            string getGroupsQuery = "SELECT sysparamid as `Id`, syskey as `Kulcs`, sysvalue as `Ertek` FROM systemparams";
            var data = Framework.db.GetData(getGroupsQuery);
            dataGridView1.DataSource = data;

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
            sysParamId = Convert.ToInt32(senderGrid.CurrentRow.Cells["Id"].Value.ToString());
            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                string sysparamid = senderGrid.CurrentRow.Cells["Id"].Value.ToString();

                if (e.ColumnIndex == 0)
                {
                    Framework.mainForm.panel1.Controls.Clear();

                    UpdateSystemParam updateForm = new UpdateSystemParam();
                    updateForm.sysparam = this;
                    updateForm.TopLevel = false;
                    updateForm.AutoScroll = true;
                    Framework.mainForm.panel1.Controls.Add(updateForm);
                    updateForm.Show();
                }
            }
        }
    }
}

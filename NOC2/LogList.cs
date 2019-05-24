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
    public partial class LogList : Form
    {
        public LogList()
        {
            InitializeComponent();
        }

        private void LogList_Load(object sender, EventArgs e)
        {
            string getServersQuery = "SELECT username as `Felhasznalonev`, operationname as `Művelet`, record_id as `RekordId`, inserttime as `Felvitel` FROM log, operations, users WHERE log.operation_id = operations.operationid AND log.user_id = users.userid ORDER BY inserttime DESC";
            var data = Framework.db.GetData(getServersQuery);
            dataGridView1.DataSource = data;
        }
    }
}

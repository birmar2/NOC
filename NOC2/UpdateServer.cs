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
    public partial class UpdateServer : Form
    {
        public ServerList server { get; set; }
        Connection db = new Connection();
        public string serverid;
        public int selectedTypeIndex = 0;
        public UpdateServer()
        {
            InitializeComponent();
        }

        public List<Servertype> GetServertypes(int serverTypeId)
        {
            string getServertypesQuery = "SELECT * FROM servertypes";
            var typeTable = db.GetData(getServertypesQuery);
            DataView typeView = new DataView(typeTable);

            List<Servertype> items = new List<Servertype>();
            int i = 0;
            foreach (DataRowView row in typeView)
            {
                items.Add(new Servertype() { Text = row["servertypename"].ToString(), Value = row["servertypeid"].ToString() });
                if (serverTypeId == Convert.ToInt32(row["servertypeid"].ToString()))selectedTypeIndex = i;
                i++;
            }
            return items;
        }

        private void UpdateServer_Load(object sender, EventArgs e)
        {
            serverid = Convert.ToString(server.serverId);
            string getServersQuery = "SELECT * FROM servers WHERE serverid = " + serverid;
            var serverTable = db.GetData(getServersQuery);
            DataView serverView = new DataView(serverTable);
            int countRows = Int32.Parse(serverView.Count.ToString());

            string serverName   = serverView[0]["servername"].ToString();
            string serverMemory = serverView[0]["servermemory"].ToString();
            string serverDisk   = serverView[0]["serverdisk"].ToString();
            string serverCpu    = serverView[0]["servercpu"].ToString();
            string serverOpsystem = serverView[0]["serveropsystem"].ToString();
            int serverActive = Convert.ToInt32(serverView[0]["serveractive"]);
            int servertypeId = Convert.ToInt32(serverView[0]["servertype_id"]);

            if(serverActive==1) checkBox1.Checked = true;

            label1.Text = serverName + " szerkesztése";
            textBox1.Text = serverName;
            textBox2.Text = serverMemory;
            textBox3.Text = serverDisk;
            textBox4.Text = serverCpu;
            textBox5.Text = serverOpsystem;

            var types = GetServertypes(servertypeId);
            comboBox1.DataSource = types;
            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";
            comboBox1.SelectedIndex = selectedTypeIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string serverName     = textBox1.Text;
            Servertype selectedType = (Servertype)comboBox1.SelectedItem;
            string servertype_id  = selectedType.Value;
            int serverActive = checkBox1.Checked ? 1 : 0;
            string serverMemory   = textBox2.Text;
            string serverDisk     = textBox3.Text;
            string serverCpu      = textBox4.Text;
            string serverOpsystem = textBox5.Text;

            string updateQuery = "UPDATE `servers` " +
                "SET " +
                "`servername` = '" + serverName + "', " +
                "`servertype_id` = '" + servertype_id + "', " +
                "`serveractive` = '" + serverActive + "', " +
                "`servermemory` = '" + serverMemory + "', " +
                "`serverdisk` = '" + serverDisk + "', " +
                "`servercpu` = '" + serverCpu + "', " +
                "`serveropsystem` = '" + serverOpsystem + "' " +
                "WHERE `serverid` =" + serverid;
            db.RunQuery(updateQuery);
            MessageBox.Show("Azonosítási szerver frissítve!");
            this.Close();
        }
    }
}

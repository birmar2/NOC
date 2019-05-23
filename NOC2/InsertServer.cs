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
    public partial class InsertServer : Form
    {
        public InsertServer()
        {
            InitializeComponent();
        }

        public List<Servertype> GetServertypes()
        {
            string getServertypesQuery = "SELECT * FROM servertypes";
            var typeTable = Framework.db.GetData(getServertypesQuery);
            DataView typeView = new DataView(typeTable);

            List<Servertype> items = new List<Servertype>();
            int i = 0;
            foreach (DataRowView row in typeView)
            {
                items.Add(new Servertype() { Text = row["servertypename"].ToString(), Value = row["servertypeid"].ToString() });
                i++;
            }
            return items;
        }

        private void InsertServer_Load(object sender, EventArgs e)
        {
            var types = GetServertypes();
            comboBox1.DataSource = types;
            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string serverName = textBox1.Text;
            Servertype selectedType = (Servertype)comboBox1.SelectedItem;
            string servertype_id = selectedType.Value;
            int serverActive = checkBox1.Checked ? 1 : 0;
            string serverMemory = textBox2.Text;
            string serverDisk = textBox3.Text;
            string serverCpu = textBox4.Text;
            string serverOpsystem = textBox5.Text;

            string insertQuery = "INSERT INTO " +
                "servers " +
                "(`servername`,`servertype_id`,`serveractive`,`servermemory`,`serverdisk`,`servercpu`,`serveropsystem`) " +
                "VALUES " +
                "('"+ serverName + "','"+ servertype_id + "','"+ serverActive + "','"+ serverMemory + "','"+ serverDisk + "','"+ serverCpu + "','"+ serverOpsystem + "') ";
            Framework.db.RunQuery(insertQuery);
            MessageBox.Show("Azonosítási szerver feltöltve!");

            Framework.mainForm.panel1.Controls.Clear();
            ServerList listForm = new ServerList();
            listForm.TopLevel = false;
            listForm.AutoScroll = true;
            Framework.mainForm.panel1.Controls.Add(listForm);
            listForm.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace NOC2
{
    public partial class InsertUser : Form
    {
        Connection db = new Connection();
        public InsertUser()
        {
            InitializeComponent();
        }

        public List<Group> GetGroups()
        {
            string getGroupsQuery = "SELECT * FROM groups";
            var groupTable = db.GetData(getGroupsQuery);
            DataView groupView = new DataView(groupTable);

            List<Group> items = new List<Group>();
            int i = 0;
            foreach (DataRowView row in groupView)
            {
                items.Add(new Group() { Text = row["groupName"].ToString(), Value = row["groupid"].ToString() });
                i++;
            }
            return items;
        }

        public List<Server> GetServers()
        {
            string getServersQuery = "SELECT * FROM servers";
            var serverTable = db.GetData(getServersQuery);
            DataView serverView = new DataView(serverTable);

            List<Server> items = new List<Server>();
            int i = 0;
            foreach (DataRowView row in serverView)
            {
                items.Add(new Server() { Text = row["servername"].ToString(), Value = row["serverid"].ToString() });
                i++;
            }
            return items;
        }

        static string Hash(string input)
        {
            var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Concat(hash.Select(b => b.ToString("x2")));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string repassword = textBox3.Text;
            Group selectedGroup = (Group)comboBox1.SelectedItem;
            string group_id = selectedGroup.Value;
            Server selectedServer = (Server)comboBox2.SelectedItem;
            string server_id = selectedServer.Value;

            string insertQuery = "INSERT INTO " +
                "users " +
                "(`username`,`password`,`group_id`,`server_id`) " +
                "VALUES " +
                "('"+ username + "','"+ Hash(password) + "','"+ group_id + "','"+ server_id + "')";
            db.RunQuery(insertQuery);
            MessageBox.Show("Felhasználó feltöltve!");
            this.Close();
        }

        private void InsertUser_Load(object sender, EventArgs e)
        {
            var groups = GetGroups();
            comboBox1.DataSource = groups;
            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember = "Value";

            var servers = GetServers();
            comboBox2.DataSource = servers;
            comboBox2.DisplayMember = "Text";
            comboBox2.ValueMember = "Value";
        }
    }
}

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
    public partial class UpdateUser : Form
    {
        public userList user { get; set; }
        Connection db = new Connection();
        public string userid;
        public int selectedGroupIndex = 0;
        public int selectedServerIndex = 0;
        public UpdateUser()
        {
            InitializeComponent();
        }

        public List<Group> GetGroups(int groupId)
        {
            string getGroupsQuery = "SELECT * FROM groups";
            var groupTable = db.GetData(getGroupsQuery);
            DataView groupView = new DataView(groupTable);

            List<Group> items = new List<Group>();
            int i = 0;
            foreach (DataRowView row in groupView)
            {
                items.Add(new Group() { Text = row["groupName"].ToString(), Value = row["groupid"].ToString() });
                if (groupId == Convert.ToInt32(row["groupid"].ToString())) selectedGroupIndex = i;
                i++;
            }
            return items;
        }

        public List<Server> GetServers(int serverId)
        {
            string getServersQuery = "SELECT * FROM servers";
            var serverTable = db.GetData(getServersQuery);
            DataView serverView = new DataView(serverTable);

            List<Server> items = new List<Server>();
            int i = 0;
            foreach (DataRowView row in serverView)
            {
                items.Add(new Server() { Text = row["servername"].ToString(), Value = row["serverid"].ToString() });
                if (serverId == Convert.ToInt32(row["serverid"].ToString())) selectedServerIndex = i;
                i++;
            }
            return items;
        }

        private void UpdateUser_Load(object sender, EventArgs e)
        {
            userid = Convert.ToString(user.userId);
            string getUsersQuery = "SELECT * FROM users WHERE userid = " + userid;
            var userTable = db.GetData(getUsersQuery);
            DataView userView = new DataView(userTable);
            int countRows = Int32.Parse(userView.Count.ToString());

            string username = userView[0]["username"].ToString();
            string password = userView[0]["password"].ToString();
            int groupId     = Convert.ToInt32(userView[0]["group_id"].ToString());
            int serverId    = Convert.ToInt32(userView[0]["server_id"].ToString());
            //MessageBox.Show(username);
            label1.Text = username + " szerkesztése";
            textBox1.Text = username;
            textBox2.Text = "";

            var groups = GetGroups(groupId);
            comboBox1.DataSource    = groups;
            comboBox1.DisplayMember = "Text";
            comboBox1.ValueMember   = "Value";
            comboBox1.SelectedIndex = selectedGroupIndex;

            var servers = GetServers(serverId);
            comboBox2.DataSource    = servers;
            comboBox2.DisplayMember = "Text";
            comboBox2.ValueMember   = "Value";
            comboBox2.SelectedIndex = selectedServerIndex;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username   = textBox1.Text;
            string password   = textBox2.Text;
            string repassword = textBox3.Text;
            Group selectedGroup   = (Group)comboBox1.SelectedItem;
            string group_id  = selectedGroup.Value;
            Server selectedServer = (Server)comboBox2.SelectedItem;
            string server_id = selectedServer.Value;

            string updateQuery = "UPDATE `users` SET `username` = '" + username+ "', `group_id` = '" + group_id+ "', `server_id` = '" + server_id+ "' WHERE `userid` =" + userid;
            db.RunQuery(updateQuery);
            MessageBox.Show("Felhasználó frissítve!");
            this.Close();
            /*Main myForm = new Main();
            myForm.TopLevel = true;
            myForm.Refresh();
            myForm.Show();*/
        }
    }
}

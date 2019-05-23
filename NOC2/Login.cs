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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            button1.BackColor = Framework.getColor.FromName(Framework.Systemparam("gombHatterszin"));
            button1.ForeColor = Framework.getColor.FromName(Framework.Systemparam("gombSzovegszin"));
        }

        static string Hash(string input)
        {
            var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Concat(hash.Select(b => b.ToString("x2")));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = Hash(textBox2.Text);

            string getUsersQuery = "SELECT * FROM users, servers WHERE users.server_id = servers.serverid AND serveractive = 1 AND username = '" + username + "' AND password = '" + password + "'";
            var groupTable = Framework.db.GetData(getUsersQuery);
            DataView groupView = new DataView(groupTable);
            int countRows = Int32.Parse(groupView.Count.ToString());
            if (countRows==1)
            {
                Framework.MyUserId = Convert.ToInt32(groupView[0]["userid"]);
                Framework.MyUserName = groupView[0]["username"].ToString();
                Framework.MyGroupId = Convert.ToInt32(groupView[0]["group_id"]);
                Framework.insertLog(Framework.MyUserId, Framework.Operation("Sikeres bejelentkezés"), Framework.MyUserId);
                this.Hide();


                Framework.mainForm = new Main();
                Framework.mainForm.Show();

                /*var frm = new Main();
                frm.TopLevel = true;
                frm.Closed += (s, args) => this.Close();
                frm.Show();*/
            }
            else
            {
                MessageBox.Show("Hibás felhasználónév és/vagy jelszó!");
            }
        }
    }
}

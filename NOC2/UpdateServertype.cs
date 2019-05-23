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
    public partial class UpdateServertype : Form
    {
        public ServertypeList servertype { get; set; }
        public string servertypeid;
        public UpdateServertype()
        {
            InitializeComponent();
        }

        private void UpdateServertype_Load(object sender, EventArgs e)
        {
            servertypeid = Convert.ToString(servertype.servertypeId);
            string getServersQuery = "SELECT * FROM servertypes WHERE servertypeid = " + servertypeid;
            var serverTable = Framework.db.GetData(getServersQuery);
            DataView serverView = new DataView(serverTable);
            int countRows = Int32.Parse(serverView.Count.ToString());

            string servertypename = serverView[0]["servertypename"].ToString();

            label1.Text = servertypename + " szerkesztése";
            textBox1.Text = servertypename;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string servertypename = textBox1.Text;

            bool requiredError = false;
            if (servertypename == "") requiredError = true;

            if (requiredError==false)
            {
                string updateQuery = "UPDATE `servertypes` SET `servertypename` = '" + servertypename + "' WHERE `servertypeid` =" + servertypeid;
                Framework.db.RunQuery(updateQuery);
                MessageBox.Show("Szervertípus frissítve!");

                Framework.insertLog(Framework.MyUserId, Framework.Operation("Sikeres szervertípus frissítés"), Convert.ToInt32(servertypeid));

                Framework.mainForm.panel1.Controls.Clear();
                ServertypeList listForm = new ServertypeList();
                listForm.TopLevel = false;
                listForm.AutoScroll = true;
                Framework.mainForm.panel1.Controls.Add(listForm);
                listForm.Show();
            }
            else
            {
                Framework.insertLog(Framework.MyUserId, Framework.Operation("Sikertelen szervertípus frissítés"), Convert.ToInt32(servertypeid));
                MessageBox.Show("Minden mező kitöltése kötelező");
            }
        }

        private void UpdateServertype_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }
    }
}

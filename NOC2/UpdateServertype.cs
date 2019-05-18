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
        Connection db = new Connection();
        public string servertypeid;
        public UpdateServertype()
        {
            InitializeComponent();
        }

        private void UpdateServertype_Load(object sender, EventArgs e)
        {
            servertypeid = Convert.ToString(servertype.servertypeId);
            string getServersQuery = "SELECT * FROM servertypes WHERE servertypeid = " + servertypeid;
            var serverTable = db.GetData(getServersQuery);
            DataView serverView = new DataView(serverTable);
            int countRows = Int32.Parse(serverView.Count.ToString());

            string servertypename = serverView[0]["servertypename"].ToString();

            label1.Text = servertypename + " szerkesztése";
            textBox1.Text = servertypename;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string servertypename = textBox1.Text;
            string updateQuery = "UPDATE `servertypes` SET `servertypename` = '" + servertypename + "' WHERE `servertypeid` =" + servertypeid;
            db.RunQuery(updateQuery);
            MessageBox.Show("Szervertípus frissítve!");
            this.Close();
        }
    }
}

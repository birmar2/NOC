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
    public partial class InsertServertype : Form
    {
        Connection db = new Connection();
        public InsertServertype()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string servertypename = textBox1.Text;
            string insertQuery = "INSERT INTO servertypes (`servertypename`) VALUES ('"+ servertypename + "')";
            db.RunQuery(insertQuery);
            MessageBox.Show("Szervertípus feltöltve!");
            this.Close();
        }
    }
}

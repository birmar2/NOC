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
    public partial class InsertSystemParam : Form
    {
        public InsertSystemParam()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string syskey = textBox1.Text;
            string sysvalue = textBox2.Text;

            string insertQuery = "INSERT INTO " +
                "systemparams " +
                "(`syskey`,`sysvalue`) " +
                "VALUES " +
                "('" + syskey + "','" + sysvalue + "')";
            Framework.db.RunQuery(insertQuery);
            MessageBox.Show("Rendszerparaméter feltöltve!");
            this.Close();
        }
    }
}

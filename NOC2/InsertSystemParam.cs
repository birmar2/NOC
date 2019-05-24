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

            bool requiredError = false;
            string err = "";
            if (syskey == ""|| sysvalue=="")
            {
                err = "Minden mező kitöltése kötelező";
                requiredError = true;
            }

            if (requiredError == false)
            {
                string insertQuery = "INSERT INTO " +
                "systemparams " +
                "(`syskey`,`sysvalue`) " +
                "VALUES " +
                "('" + syskey + "','" + sysvalue + "')";
                Framework.db.RunQuery(insertQuery);
                MessageBox.Show("Rendszerparaméter feltöltve!");

                int lastId = Framework.LastInsertId();
                Framework.insertLog(Framework.MyUserId, Framework.Operation("Sikeres rendszerparaméter feltöltés"), lastId);

                Framework.mainForm.panel1.Controls.Clear();
                SystemParamList listForm = new SystemParamList();
                listForm.TopLevel = false;
                listForm.AutoScroll = true;
                Framework.mainForm.panel1.Controls.Add(listForm);
                listForm.Show();
            }
            else
            {
                Framework.insertLog(Framework.MyUserId, Framework.Operation("Sikertelen rendszerparaméter feltöltés"), 0);
                MessageBox.Show(err);
            }
        }
    }
}

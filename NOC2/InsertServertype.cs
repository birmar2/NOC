﻿using System;
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
        public InsertServertype()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string servertypename = textBox1.Text;

            bool requiredError = false;
            string err = "";
            if (servertypename == "")
            {
                err = "Minden mező kitöltése kötelező";
                requiredError = true;
            }

            if (requiredError == false)
            {
                string insertQuery = "INSERT INTO servertypes (`servertypename`) VALUES ('" + servertypename + "')";
                Framework.db.RunQuery(insertQuery);
                MessageBox.Show("Szervertípus feltöltve!");

                int lastId = Framework.LastInsertId();
                Framework.insertLog(Framework.MyUserId, Framework.Operation("Sikeres szervertípus feltöltés"), lastId);

                Framework.mainForm.panel1.Controls.Clear();
                ServertypeList listForm = new ServertypeList();
                listForm.TopLevel = false;
                listForm.AutoScroll = true;
                Framework.mainForm.panel1.Controls.Add(listForm);
                listForm.Show();
            }
            else
            {
                Framework.insertLog(Framework.MyUserId, Framework.Operation("Sikertelen szervertípus feltöltés"), 0);
                MessageBox.Show(err);
            }
        }
    }
}

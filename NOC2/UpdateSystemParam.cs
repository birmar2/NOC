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
    public partial class UpdateSystemParam : Form
    {
        public SystemParamList sysparam { get; set; }
        public string sysparamid;
        public UpdateSystemParam()
        {
            InitializeComponent();
        }

        private void UpdateSystemParam_Load(object sender, EventArgs e)
        {
            sysparamid = Convert.ToString(sysparam.sysParamId);
            string getSysQuery = "SELECT * FROM systemparams WHERE sysparamid = " + sysparamid;
            var sysTable = Framework.db.GetData(getSysQuery);
            DataView sysView = new DataView(sysTable);
            int countRows = Int32.Parse(sysView.Count.ToString());

            string syskey = sysView[0]["syskey"].ToString();
            string sysvalue = sysView[0]["sysvalue"].ToString();
            textBox1.Text = syskey;
            textBox2.Text = sysvalue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string syskey = textBox1.Text;
            string sysvalue = textBox2.Text;

            bool requiredError = false;
            if (syskey == ""|| sysvalue == "") requiredError = true;

            if (requiredError == false)
            {
                string updateQuery = "UPDATE `systemparams` SET `sysvalue` = '" + sysvalue + "'WHERE `sysparamid` =" + sysparamid;
                Framework.db.RunQuery(updateQuery);
                MessageBox.Show("Rendszerparaméter frissítve!");

                Framework.insertLog(Framework.MyUserId, Framework.Operation("Sikeres rendszerparaméter szerkesztés"), Convert.ToInt32(sysparamid));

                Framework.mainForm.panel1.Controls.Clear();
                SystemParamList listForm = new SystemParamList();
                listForm.TopLevel = false;
                listForm.AutoScroll = true;
                Framework.mainForm.panel1.Controls.Add(listForm);
                listForm.Show();
            }
            else
            {
                Framework.insertLog(Framework.MyUserId, Framework.Operation("Sikertelen rendszerparaméter szerkesztés"), Convert.ToInt32(sysparamid));
                MessageBox.Show("Minden mező kitöltése kötelező");
            }
        }
    }
}

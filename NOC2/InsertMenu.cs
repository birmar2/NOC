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
    public partial class InsertMenu : Form
    {
        public MenuList menu { get; set; }
        Connection db = new Connection();
        public InsertMenu()
        {
            InitializeComponent();
        }

        private void InsertMenu_Load(object sender, EventArgs e)
        {
            label1.Text = menu.sMenuname;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string insertQuery = "INSERT INTO mainmenus (`menuName`,`parentId`,`active`) VALUES ('" + textBox1.Text + "','" + menu.sMenuId + "',1)";
            db.RunQuery(insertQuery);
            MessageBox.Show("Menü feltöltve!");
            this.Close();
        }
    }
}

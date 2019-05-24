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
    public partial class InsertMenu : Form
    {
        public MenuList menu { get; set; }
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
            bool requiredError = false;
            string err = "";
            if (textBox1.Text == "")
            {
                err = "Minden mező kitöltése kötelező";
                requiredError = true;
            }

            if (requiredError == false)
            {
                string insertQuery = "INSERT INTO mainmenus (`menuName`,`parentId`,`active`) VALUES ('" + textBox1.Text + "','" + menu.sMenuId + "',1)";
                Framework.db.RunQuery(insertQuery);

                int lastId = Framework.LastInsertId();
                Framework.insertLog(Framework.MyUserId, Framework.Operation("Sikeres menü feltöltés"), lastId);

                MessageBox.Show("Menü feltöltve!");

                Framework.mainForm.panel1.Controls.Clear();
                MenuList listForm = new MenuList();
                listForm.TopLevel = false;
                listForm.AutoScroll = true;
                Framework.mainForm.panel1.Controls.Add(listForm);
                listForm.Show();
            }
            else
            {
                Framework.insertLog(Framework.MyUserId, Framework.Operation("Sikertelen menü feltöltés"), 0);
                MessageBox.Show(err);
            }
        }
    }
}

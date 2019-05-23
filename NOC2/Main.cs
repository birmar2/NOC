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
    public partial class Main : Form
    {
        int groupId = Framework.MyGroupId;
        public Main()
        {
            InitializeComponent();
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            label1.Text = "Bejelentkezve, mint "+Framework.MyUserName;
            //var dbMenus = new Connection();
            /*
            string getMenuIdsQuery = "SELECT menu_id FROM groupsmenus WHERE group_id = " + groupId;
            var menuIdTable = db.GetData(getMenuIdsQuery);

            DataView idView = new DataView(menuIdTable);
            int countRows = Int32.Parse(idView.Count.ToString());
            int[] idArr = new int[countRows];
            int i = 0;
            foreach (DataRowView row in idView)
            {
                idArr[i++] = Int32.Parse(row["menu_id"].ToString());
                //System.Windows.Forms.MessageBox.Show(row["menu_id"].ToString());
            }
            */

            string getAllMenusQuery = groupId==1 ? "SELECT * FROM mainmenus WHERE active = 1" : "" +
                "SELECT m.* " +
                "FROM mainmenus m, groupsmenus gm " +
                "WHERE m.active = 1 " +
                "AND m.menuId = gm.menu_id " +
                "AND gm.group_id = " + groupId;
            var menuTable = Framework.db.GetData(getAllMenusQuery);

            DataView view   = new DataView(menuTable);
            view.RowFilter  = "parentId=0";

            foreach (DataRowView row in view)
            {
                foreach (ToolStripMenuItem item in menuStrip1.Items)
                {
                    //System.Windows.Forms.MessageBox.Show(item.Name);
                    if (row["menuName"].ToString() == item.Name)item.Visible = true;
                    AddChildForms(menuTable, row["menuId"].ToString(), item);
                }
            }
        }

        //Rekurzív fv. a hierarchikus adatszerkezethez
        private void AddChildForms(DataTable table, string id, ToolStripMenuItem ToolSMI)
        {
            DataView viewChild = new DataView(table);
            viewChild.RowFilter = "parentId = " + id;

            foreach (DataRowView childViewItem in viewChild)
            {
                foreach (ToolStripMenuItem item in ToolSMI.DropDownItems)
                {
                    if (childViewItem["menuName"].ToString() == item.Name)item.Visible = true;
                    AddChildForms(table, childViewItem["menuId"].ToString(), item);
                }
            }
        }

        private void tesztToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }


        private void aSaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void userList_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            userList myForm = new userList();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            panel1.Controls.Add(myForm);
            myForm.Show();
        }

        private void GroupList_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            GroupList myForm = new GroupList();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            panel1.Controls.Add(myForm);
            myForm.Show();
        }

        private void listToolStripMenuItem_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            MenuList myForm = new MenuList();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            panel1.Controls.Add(myForm);
            myForm.Show();
        }

        private void listToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            ServerList myForm = new ServerList();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            panel1.Controls.Add(myForm);
            myForm.Show();
        }

        private void listToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            ServertypeList myForm = new ServertypeList();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            panel1.Controls.Add(myForm);
            myForm.Show();
        }

        private void newToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            InsertServertype myForm = new InsertServertype();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            panel1.Controls.Add(myForm);
            myForm.Show();
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            InsertServer myForm = new InsertServer();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            panel1.Controls.Add(myForm);
            myForm.Show();
        }

        private void groupNew_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            InsertGroup myForm = new InsertGroup();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            panel1.Controls.Add(myForm);
            myForm.Show();
        }

        private void userNew_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            InsertUser myForm = new InsertUser();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            panel1.Controls.Add(myForm);
            myForm.Show();
        }

        private void listToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            SystemParamList myForm = new SystemParamList();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            panel1.Controls.Add(myForm);
            myForm.Show();
        }

        private void newToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();
            InsertSystemParam myForm = new InsertSystemParam();
            myForm.TopLevel = false;
            myForm.AutoScroll = true;
            panel1.Controls.Add(myForm);
            myForm.Show();
        }
    }
}

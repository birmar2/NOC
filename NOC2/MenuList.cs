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
    public partial class MenuList : Form
    {
        TreeNode parentNode = null;
        int selectedMenuId = 0;
        public int sMenuId { get; set; }
        public string sMenuname { get; set; }
        public MenuList()
        {
            InitializeComponent();
        }

        private void TreeStructure(string parentId, TreeNode parentNode)
        {
            TreeNode childNode;
            string getMenusQuery = "SELECT * FROM mainmenus WHERE parentId = "+ parentId;
            var data = Framework.db.GetData(getMenusQuery);
            DataView view = new DataView(data);
            foreach (DataRowView row in view)
            {
                TreeNode node = new TreeNode();
                node.Text = row["menuName"].ToString();
                node.Name = row["menuId"].ToString();
                //node.Nodes.Add(row["menuName"].ToString());
                //treeView1.Nodes.Add(node);
                if (parentNode == null)
                {
                    treeView1.Nodes.Add(node);
                    childNode = node;
                }
                else
                {
                    parentNode.Nodes.Add(node);
                    childNode = node;
                }
                TreeStructure(row["menuId"].ToString(), childNode);
            }
        }

        private void MenuList_Load(object sender, EventArgs e)
        {
            string parentId = "0";
            TreeStructure(parentId, parentNode);
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            string menuId = node.Name;
            selectedMenuId = Convert.ToInt32(menuId);
            textBox1.Text = node.Text;

            sMenuId = selectedMenuId;
            sMenuname = node.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text!="")
            {
                treeView1.SelectedNode.Text = textBox1.Text;
                string updateQuery = "UPDATE `mainmenus` SET `menuName` = '" + textBox1.Text + "' WHERE `menuId` =" + selectedMenuId.ToString();
                Framework.db.RunQuery(updateQuery);
                MessageBox.Show("Menürendszer frissítve!");
            }
            
            //MessageBox.Show(selectedMenuId.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Framework.mainForm.panel1.Controls.Clear();
                InsertMenu insertForm = new InsertMenu();
                insertForm.menu = this;
                insertForm.TopLevel = false;
                insertForm.AutoScroll = true;
                Framework.mainForm.panel1.Controls.Add(insertForm);
                insertForm.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Biztosan törlöd?", "CONFIRM", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                //MessageBox.Show(user_id);
                string deleteQuery = "DELETE FROM `mainmenus` WHERE `menuId` = " + selectedMenuId;
                Framework.db.RunQuery(deleteQuery);
                Framework.insertLog(Framework.MyUserId, Framework.Operation("Menü törölve"), Convert.ToInt32(selectedMenuId));
                MessageBox.Show("Menü törölve!");
                treeView1.SelectedNode.Remove();
            }
        }
    }
}

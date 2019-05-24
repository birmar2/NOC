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
    public partial class InsertGroup : Form
    {
        TreeNode parentNode = null;
        public string groupid;
        public string selectedMenu;
        List<string> selectedMenus = new List<string>();
        public InsertGroup()
        {
            InitializeComponent();
        }

        private void TreeStructure(string parentId, TreeNode parentNode)
        {
            TreeNode childNode;
            string getMenusQuery = "SELECT * FROM mainmenus WHERE parentId = " + parentId;
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
                node.ForeColor = Color.Red;

                //treeView1.SelectedNode.ForeColor = Color.Red;
                TreeStructure(row["menuId"].ToString(), childNode);
            }
        }

        private void InsertGroup_Load(object sender, EventArgs e)
        {
            string parentId = "0";
            TreeStructure(parentId, parentNode);
            treeView1.ExpandAll();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            string menuId = node.Name;
            selectedMenu = menuId;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                treeView1.SelectedNode.ForeColor = Color.Green;
                selectedMenus.Add(selectedMenu);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                selectedMenus.Remove(selectedMenu);
                treeView1.SelectedNode.ForeColor = Color.Red;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string groupName = textBox1.Text;

            bool requiredError = false;
            string err = "";
            if (groupName == "")
            {
                err = "Minden mező kitöltése kötelező";
                requiredError = true;
            }

            if (requiredError == false)
            {
                string insertQuery = "INSERT INTO `groups` (`groupName`) VALUES ('" + groupName + "')";
                Framework.db.RunQuery(insertQuery);

                int lastId = Framework.LastInsertId();

                string getGroupsQuery = "SELECT * FROM groups WHERE groupName = '" + groupName + "' ORDER BY groupid DESC";
                var groupTable = Framework.db.GetData(getGroupsQuery);
                DataView groupView = new DataView(groupTable);
                int countRows = Int32.Parse(groupView.Count.ToString());

                string groupid = groupView[0]["groupid"].ToString();

                string insertQueryJoin = "";
                foreach (string menu_id in selectedMenus)
                {
                    insertQueryJoin = "INSERT INTO groupsmenus (`group_id`,`menu_id`) VALUES ('" + groupid + "','" + menu_id + "')";
                    Framework.db.RunQuery(insertQueryJoin);
                }

                MessageBox.Show("Jogosultsági csoport feltöltve!");
                Framework.insertLog(Framework.MyUserId, Framework.Operation("Sikeres jogosultsági csoport feltöltés"), lastId);

                Framework.mainForm.panel1.Controls.Clear();
                GroupList listForm = new GroupList();
                listForm.TopLevel = false;
                listForm.AutoScroll = true;
                Framework.mainForm.panel1.Controls.Add(listForm);
                listForm.Show();
            }
            else
            {
                Framework.insertLog(Framework.MyUserId, Framework.Operation("Sikertelen jogosultsági csoport feltöltés"), 0);
                MessageBox.Show(err);
            }
        }
    }
}

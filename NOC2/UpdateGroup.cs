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
    public partial class UpdateGroup : Form
    {
        public GroupList group { get; set; }
        TreeNode parentNode = null;
        public string groupid;
        public string selectedMenu;
        List<string> selectedMenus = new List<string>();
        public UpdateGroup()
        {
            InitializeComponent();
        }

        private Array getMenuIds()
        {
            string getMenusQuery = "SELECT * FROM groupsmenus WHERE group_id = " + group.groupId;
            var data = Framework.db.GetData(getMenusQuery);
            DataView view = new DataView(data);
            int i = 0;
            int countRows = Int32.Parse(view.Count.ToString());
            string[] menuIds = new string[countRows];
            foreach (DataRowView row in view)
            {
                menuIds[i] = row["menu_id"].ToString();
                i++;
            }
            return menuIds;
        }

        private void TreeStructure(string parentId, TreeNode parentNode, string sgroupId)
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
                if (Array.IndexOf(getMenuIds(), row["menuId"].ToString()) >= 0)
                {
                    selectedMenus.Add(row["menuId"].ToString());
                    node.ForeColor = Color.Green;
                }
                
                //treeView1.SelectedNode.ForeColor = Color.Red;
                TreeStructure(row["menuId"].ToString(), childNode, sgroupId);
            }
        }

        private void UpdateGroup_Load(object sender, EventArgs e)
        {
            groupid = Convert.ToString(group.groupId);
            string getUsersQuery = "SELECT * FROM groups WHERE groupid = " + groupid;
            var groupTable = Framework.db.GetData(getUsersQuery);
            DataView groupView = new DataView(groupTable);
            int countRows = Int32.Parse(groupView.Count.ToString());

            string groupName = groupView[0]["groupName"].ToString();
            string sgroupId = groupView[0]["groupid"].ToString();
            label1.Text = groupName + " szerkesztése";
            textBox1.Text = groupName;

            string parentId = "0";
            TreeStructure(parentId, parentNode, sgroupId);
            treeView1.ExpandAll();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string groupName = textBox1.Text;

            string updateQuery = "UPDATE `groups` SET `groupName` = '" + groupName + "' WHERE `groupid` =" + groupid;
            Framework.db.RunQuery(updateQuery);

            string insertQuery = "";
            string deleteQuery = "DELETE FROM groupsmenus WHERE `group_id` =" + groupid;
            Framework.db.RunQuery(deleteQuery);
            foreach (string menu_id in selectedMenus)
            {
                insertQuery = "INSERT INTO groupsmenus (`group_id`,`menu_id`) VALUES ('"+ groupid + "','"+ menu_id + "')";
                Framework.db.RunQuery(insertQuery);
            }

            MessageBox.Show("Jogosultsági csoport frissítve!");
            this.Close();
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            TreeNode node = e.Node;
            string menuId = node.Name;
            selectedMenu = menuId;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string result = selectedMenus.FirstOrDefault(x => x == selectedMenu);
            //if (result != null)
            //{
            //selectedMenus.Remove(selectedMenu);
            if (treeView1.SelectedNode!=null)
            {
                treeView1.SelectedNode.ForeColor = Color.Green;
                selectedMenus.Add(selectedMenu);
            }
            
            //}
            //selectedMenus.Add(selectedMenu);
            //MessageBox.Show(menuId);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (treeView1.SelectedNode != null)
            {
                selectedMenus.Remove(selectedMenu);
                treeView1.SelectedNode.ForeColor = Color.Red;
            }
        }
    }
}

namespace NOC2
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mainSystem = new System.Windows.Forms.ToolStripMenuItem();
            this.systemUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.userList = new System.Windows.Forms.ToolStripMenuItem();
            this.userNew = new System.Windows.Forms.ToolStripMenuItem();
            this.systemGroups = new System.Windows.Forms.ToolStripMenuItem();
            this.GroupList = new System.Windows.Forms.ToolStripMenuItem();
            this.groupNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.serversToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.servertypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.systemparametersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.GrayText;
            this.menuStrip1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainSystem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            this.menuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip1_ItemClicked);
            // 
            // mainSystem
            // 
            this.mainSystem.BackColor = System.Drawing.SystemColors.GrayText;
            this.mainSystem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.systemUsers,
            this.systemGroups,
            this.menusToolStripMenuItem,
            this.serversToolStripMenuItem,
            this.systemparametersToolStripMenuItem,
            this.logToolStripMenuItem});
            this.mainSystem.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.mainSystem.Name = "mainSystem";
            this.mainSystem.Size = new System.Drawing.Size(80, 23);
            this.mainSystem.Text = "Rendszer";
            this.mainSystem.Visible = false;
            this.mainSystem.Click += new System.EventHandler(this.tesztToolStripMenuItem_Click);
            // 
            // systemUsers
            // 
            this.systemUsers.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.userList,
            this.userNew});
            this.systemUsers.Name = "systemUsers";
            this.systemUsers.Size = new System.Drawing.Size(239, 24);
            this.systemUsers.Text = "Felhasználók";
            this.systemUsers.Visible = false;
            this.systemUsers.Click += new System.EventHandler(this.aSaToolStripMenuItem_Click);
            // 
            // userList
            // 
            this.userList.Name = "userList";
            this.userList.Size = new System.Drawing.Size(109, 24);
            this.userList.Text = "Lista";
            this.userList.Visible = false;
            this.userList.Click += new System.EventHandler(this.userList_Click);
            // 
            // userNew
            // 
            this.userNew.Name = "userNew";
            this.userNew.Size = new System.Drawing.Size(109, 24);
            this.userNew.Text = "Új";
            this.userNew.Visible = false;
            this.userNew.Click += new System.EventHandler(this.userNew_Click);
            // 
            // systemGroups
            // 
            this.systemGroups.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.GroupList,
            this.groupNew});
            this.systemGroups.Name = "systemGroups";
            this.systemGroups.Size = new System.Drawing.Size(239, 24);
            this.systemGroups.Text = "Jogosultsági csoportok";
            this.systemGroups.Visible = false;
            // 
            // GroupList
            // 
            this.GroupList.Name = "GroupList";
            this.GroupList.Size = new System.Drawing.Size(109, 24);
            this.GroupList.Text = "Lista";
            this.GroupList.Visible = false;
            this.GroupList.Click += new System.EventHandler(this.GroupList_Click);
            // 
            // groupNew
            // 
            this.groupNew.Name = "groupNew";
            this.groupNew.Size = new System.Drawing.Size(109, 24);
            this.groupNew.Text = "Új";
            this.groupNew.Visible = false;
            this.groupNew.Click += new System.EventHandler(this.groupNew_Click);
            // 
            // menusToolStripMenuItem
            // 
            this.menusToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listToolStripMenuItem});
            this.menusToolStripMenuItem.Name = "menusToolStripMenuItem";
            this.menusToolStripMenuItem.Size = new System.Drawing.Size(239, 24);
            this.menusToolStripMenuItem.Text = "Menürendszer (modulok)";
            this.menusToolStripMenuItem.Visible = false;
            // 
            // listToolStripMenuItem
            // 
            this.listToolStripMenuItem.Name = "listToolStripMenuItem";
            this.listToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.listToolStripMenuItem.Text = "Lista";
            this.listToolStripMenuItem.Visible = false;
            this.listToolStripMenuItem.Click += new System.EventHandler(this.listToolStripMenuItem_Click);
            // 
            // serversToolStripMenuItem
            // 
            this.serversToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listToolStripMenuItem1,
            this.newToolStripMenuItem1,
            this.servertypesToolStripMenuItem});
            this.serversToolStripMenuItem.Name = "serversToolStripMenuItem";
            this.serversToolStripMenuItem.Size = new System.Drawing.Size(239, 24);
            this.serversToolStripMenuItem.Text = "Szerverek";
            this.serversToolStripMenuItem.Visible = false;
            // 
            // listToolStripMenuItem1
            // 
            this.listToolStripMenuItem1.Name = "listToolStripMenuItem1";
            this.listToolStripMenuItem1.Size = new System.Drawing.Size(180, 24);
            this.listToolStripMenuItem1.Text = "Lista";
            this.listToolStripMenuItem1.Visible = false;
            this.listToolStripMenuItem1.Click += new System.EventHandler(this.listToolStripMenuItem1_Click);
            // 
            // newToolStripMenuItem1
            // 
            this.newToolStripMenuItem1.Name = "newToolStripMenuItem1";
            this.newToolStripMenuItem1.Size = new System.Drawing.Size(180, 24);
            this.newToolStripMenuItem1.Text = "Új";
            this.newToolStripMenuItem1.Visible = false;
            this.newToolStripMenuItem1.Click += new System.EventHandler(this.newToolStripMenuItem1_Click);
            // 
            // servertypesToolStripMenuItem
            // 
            this.servertypesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listToolStripMenuItem2,
            this.newToolStripMenuItem2});
            this.servertypesToolStripMenuItem.Name = "servertypesToolStripMenuItem";
            this.servertypesToolStripMenuItem.Size = new System.Drawing.Size(180, 24);
            this.servertypesToolStripMenuItem.Text = "Szervertípusok";
            this.servertypesToolStripMenuItem.Visible = false;
            // 
            // listToolStripMenuItem2
            // 
            this.listToolStripMenuItem2.Name = "listToolStripMenuItem2";
            this.listToolStripMenuItem2.Size = new System.Drawing.Size(180, 24);
            this.listToolStripMenuItem2.Text = "Lista";
            this.listToolStripMenuItem2.Visible = false;
            this.listToolStripMenuItem2.Click += new System.EventHandler(this.listToolStripMenuItem2_Click);
            // 
            // newToolStripMenuItem2
            // 
            this.newToolStripMenuItem2.Name = "newToolStripMenuItem2";
            this.newToolStripMenuItem2.Size = new System.Drawing.Size(180, 24);
            this.newToolStripMenuItem2.Text = "Új";
            this.newToolStripMenuItem2.Visible = false;
            this.newToolStripMenuItem2.Click += new System.EventHandler(this.newToolStripMenuItem2_Click);
            // 
            // systemparametersToolStripMenuItem
            // 
            this.systemparametersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.listToolStripMenuItem3,
            this.newToolStripMenuItem3});
            this.systemparametersToolStripMenuItem.Name = "systemparametersToolStripMenuItem";
            this.systemparametersToolStripMenuItem.Size = new System.Drawing.Size(239, 24);
            this.systemparametersToolStripMenuItem.Text = "Rendszerparaméterek";
            this.systemparametersToolStripMenuItem.Visible = false;
            // 
            // listToolStripMenuItem3
            // 
            this.listToolStripMenuItem3.Name = "listToolStripMenuItem3";
            this.listToolStripMenuItem3.Size = new System.Drawing.Size(180, 24);
            this.listToolStripMenuItem3.Text = "Lista";
            this.listToolStripMenuItem3.Visible = false;
            this.listToolStripMenuItem3.Click += new System.EventHandler(this.listToolStripMenuItem3_Click);
            // 
            // newToolStripMenuItem3
            // 
            this.newToolStripMenuItem3.Name = "newToolStripMenuItem3";
            this.newToolStripMenuItem3.Size = new System.Drawing.Size(180, 24);
            this.newToolStripMenuItem3.Text = "Új";
            this.newToolStripMenuItem3.Visible = false;
            this.newToolStripMenuItem3.Click += new System.EventHandler(this.newToolStripMenuItem3_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(178, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(610, 439);
            this.panel1.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Location = new System.Drawing.Point(0, 38);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(172, 439);
            this.panel2.TabIndex = 3;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(153, 121);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Bejelentkezve, mint {username}";
            // 
            // logToolStripMenuItem
            // 
            this.logToolStripMenuItem.Name = "logToolStripMenuItem";
            this.logToolStripMenuItem.Size = new System.Drawing.Size(239, 24);
            this.logToolStripMenuItem.Text = "Log";
            this.logToolStripMenuItem.Visible = false;
            this.logToolStripMenuItem.Click += new System.EventHandler(this.logToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 481);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NOC";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mainSystem;
        private System.Windows.Forms.ToolStripMenuItem systemUsers;
        private System.Windows.Forms.ToolStripMenuItem userList;
        private System.Windows.Forms.ToolStripMenuItem userNew;
        private System.Windows.Forms.ToolStripMenuItem systemGroups;
        private System.Windows.Forms.ToolStripMenuItem GroupList;
        private System.Windows.Forms.ToolStripMenuItem groupNew;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripMenuItem menusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem serversToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem servertypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem systemparametersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listToolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem3;
        public System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
    }
}
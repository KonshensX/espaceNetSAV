﻿namespace espaceNetSAV.Admin
{
    partial class AdminPanel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AdminPanel));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gérerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.réceptionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listCompleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.valdéToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasEncoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.techniqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historiqueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historiqueToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.usersList = new System.Windows.Forms.TreeView();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.deleteUserBtn = new System.Windows.Forms.Button();
            this.saveChangesBtn = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBoxValide = new System.Windows.Forms.CheckBox();
            this.checkBoxHistory = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.usernameEditTbox = new System.Windows.Forms.TextBox();
            this.categoryEditCbox = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.passwordEditTBox = new System.Windows.Forms.TextBox();
            this.passwordEditTboxConf = new System.Windows.Forms.TextBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.createdmessageholder = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.categoryCBox = new System.Windows.Forms.ComboBox();
            this.pwdTBoxConf = new System.Windows.Forms.TextBox();
            this.pwdTBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.usernameTBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.createBtn = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gérerToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.historiqueToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1022, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gérerToolStripMenuItem
            // 
            this.gérerToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.réceptionToolStripMenuItem,
            this.listCompleteToolStripMenuItem,
            this.techniqueToolStripMenuItem});
            this.gérerToolStripMenuItem.Image = global::espaceNetSAV.Properties.Resources._191_menu2;
            this.gérerToolStripMenuItem.Name = "gérerToolStripMenuItem";
            this.gérerToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.gérerToolStripMenuItem.Text = "Gérer";
            // 
            // réceptionToolStripMenuItem
            // 
            this.réceptionToolStripMenuItem.Image = global::espaceNetSAV.Properties.Resources._119_user_tie;
            this.réceptionToolStripMenuItem.Name = "réceptionToolStripMenuItem";
            this.réceptionToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.réceptionToolStripMenuItem.Text = "Réception";
            this.réceptionToolStripMenuItem.Click += new System.EventHandler(this.réceptionToolStripMenuItem_Click);
            // 
            // listCompleteToolStripMenuItem
            // 
            this.listCompleteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.valdéToolStripMenuItem,
            this.pasEncoreToolStripMenuItem});
            this.listCompleteToolStripMenuItem.Image = global::espaceNetSAV.Properties.Resources._039_file_text2;
            this.listCompleteToolStripMenuItem.Name = "listCompleteToolStripMenuItem";
            this.listCompleteToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.listCompleteToolStripMenuItem.Text = "List complete";
            this.listCompleteToolStripMenuItem.Click += new System.EventHandler(this.listCompleteToolStripMenuItem_Click);
            // 
            // valdéToolStripMenuItem
            // 
            this.valdéToolStripMenuItem.Image = global::espaceNetSAV.Properties.Resources._273_checkmark;
            this.valdéToolStripMenuItem.Name = "valdéToolStripMenuItem";
            this.valdéToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.valdéToolStripMenuItem.Text = "Validé";
            this.valdéToolStripMenuItem.Click += new System.EventHandler(this.valdéToolStripMenuItem_Click);
            // 
            // pasEncoreToolStripMenuItem
            // 
            this.pasEncoreToolStripMenuItem.Image = global::espaceNetSAV.Properties.Resources._131_spinner91;
            this.pasEncoreToolStripMenuItem.Name = "pasEncoreToolStripMenuItem";
            this.pasEncoreToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.pasEncoreToolStripMenuItem.Text = "Pas encore";
            this.pasEncoreToolStripMenuItem.Click += new System.EventHandler(this.pasEncoreToolStripMenuItem_Click);
            // 
            // techniqueToolStripMenuItem
            // 
            this.techniqueToolStripMenuItem.Image = global::espaceNetSAV.Properties.Resources._429_steam;
            this.techniqueToolStripMenuItem.Name = "techniqueToolStripMenuItem";
            this.techniqueToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.techniqueToolStripMenuItem.Text = "Technique";
            this.techniqueToolStripMenuItem.Click += new System.EventHandler(this.techniqueToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.quitterToolStripMenuItem});
            this.optionsToolStripMenuItem.Image = global::espaceNetSAV.Properties.Resources._150_cogs;
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Image = global::espaceNetSAV.Properties.Resources._277_exit;
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(111, 22);
            this.quitterToolStripMenuItem.Text = "Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // historiqueToolStripMenuItem
            // 
            this.historiqueToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.historiqueToolStripMenuItem1});
            this.historiqueToolStripMenuItem.Image = global::espaceNetSAV.Properties.Resources._033_books;
            this.historiqueToolStripMenuItem.Name = "historiqueToolStripMenuItem";
            this.historiqueToolStripMenuItem.Size = new System.Drawing.Size(90, 20);
            this.historiqueToolStripMenuItem.Text = "Historique";
            // 
            // historiqueToolStripMenuItem1
            // 
            this.historiqueToolStripMenuItem1.Image = global::espaceNetSAV.Properties.Resources._033_books;
            this.historiqueToolStripMenuItem1.Name = "historiqueToolStripMenuItem1";
            this.historiqueToolStripMenuItem1.Size = new System.Drawing.Size(151, 22);
            this.historiqueToolStripMenuItem1.Text = "Liste complete";
            this.historiqueToolStripMenuItem1.Click += new System.EventHandler(this.historiqueToolStripMenuItem1_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tabControl1);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer1.Size = new System.Drawing.Size(1022, 429);
            this.splitContainer1.SplitterDistance = 340;
            this.splitContainer1.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.usersList);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(7);
            this.groupBox1.Size = new System.Drawing.Size(320, 409);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Utilisateurs";
            // 
            // usersList
            // 
            this.usersList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.usersList.Indent = 19;
            this.usersList.ItemHeight = 20;
            this.usersList.Location = new System.Drawing.Point(7, 20);
            this.usersList.Name = "usersList";
            this.usersList.Size = new System.Drawing.Size(306, 382);
            this.usersList.TabIndex = 0;
            this.usersList.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.usersList_AfterSelect);
            this.usersList.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.usersList_NodeMouseClick);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(10, 10);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(658, 409);
            this.tabControl1.TabIndex = 2;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox5);
            this.tabPage2.Controls.Add(this.groupBox4);
            this.tabPage2.Controls.Add(this.groupBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(650, 383);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Modifier";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.groupBox5.Controls.Add(this.deleteUserBtn);
            this.groupBox5.Controls.Add(this.saveChangesBtn);
            this.groupBox5.Location = new System.Drawing.Point(46, 251);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(558, 114);
            this.groupBox5.TabIndex = 20;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Buttons";
            // 
            // deleteUserBtn
            // 
            this.deleteUserBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteUserBtn.ForeColor = System.Drawing.Color.DarkRed;
            this.deleteUserBtn.Image = global::espaceNetSAV.Properties.Resources._117_user_minus;
            this.deleteUserBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.deleteUserBtn.Location = new System.Drawing.Point(9, 19);
            this.deleteUserBtn.Name = "deleteUserBtn";
            this.deleteUserBtn.Size = new System.Drawing.Size(163, 46);
            this.deleteUserBtn.TabIndex = 3;
            this.deleteUserBtn.Text = "Supprimer utilisateur";
            this.deleteUserBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.deleteUserBtn.UseVisualStyleBackColor = true;
            this.deleteUserBtn.Click += new System.EventHandler(this.deleteUserBtn_Click);
            // 
            // saveChangesBtn
            // 
            this.saveChangesBtn.Image = global::espaceNetSAV.Properties.Resources._118_user_check;
            this.saveChangesBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.saveChangesBtn.Location = new System.Drawing.Point(360, 19);
            this.saveChangesBtn.Name = "saveChangesBtn";
            this.saveChangesBtn.Size = new System.Drawing.Size(192, 46);
            this.saveChangesBtn.TabIndex = 2;
            this.saveChangesBtn.Text = "Enregistrer les modifications";
            this.saveChangesBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.saveChangesBtn.UseVisualStyleBackColor = true;
            this.saveChangesBtn.Click += new System.EventHandler(this.saveChangesBtn_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.checkBox3);
            this.groupBox4.Controls.Add(this.checkBoxValide);
            this.groupBox4.Controls.Add(this.checkBoxHistory);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox4.Location = new System.Drawing.Point(364, 3);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(283, 377);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Permissions";
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(36, 115);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(53, 17);
            this.checkBox3.TabIndex = 3;
            this.checkBox3.Text = "Temp";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.Visible = false;
            // 
            // checkBoxValide
            // 
            this.checkBoxValide.AutoSize = true;
            this.checkBoxValide.Location = new System.Drawing.Point(36, 74);
            this.checkBoxValide.Name = "checkBoxValide";
            this.checkBoxValide.Size = new System.Drawing.Size(58, 17);
            this.checkBoxValide.TabIndex = 2;
            this.checkBoxValide.Text = "Valider";
            this.checkBoxValide.UseVisualStyleBackColor = true;
            this.checkBoxValide.CheckedChanged += new System.EventHandler(this.checkBoxValide_CheckedChanged);
            // 
            // checkBoxHistory
            // 
            this.checkBoxHistory.AutoSize = true;
            this.checkBoxHistory.Location = new System.Drawing.Point(36, 30);
            this.checkBoxHistory.Name = "checkBoxHistory";
            this.checkBoxHistory.Size = new System.Drawing.Size(94, 17);
            this.checkBoxHistory.TabIndex = 1;
            this.checkBoxHistory.Text = "Voir Historique";
            this.checkBoxHistory.UseVisualStyleBackColor = true;
            this.checkBoxHistory.CheckedChanged += new System.EventHandler(this.checkBoxHistory_CheckedChanged);
            this.checkBoxHistory.MouseClick += new System.Windows.Forms.MouseEventHandler(this.checkBoxHistory_MouseClick);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.usernameEditTbox);
            this.groupBox3.Controls.Add(this.categoryEditCbox);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.passwordEditTBox);
            this.groupBox3.Controls.Add(this.passwordEditTboxConf);
            this.groupBox3.Location = new System.Drawing.Point(3, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(349, 377);
            this.groupBox3.TabIndex = 18;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Informations";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Pseudo:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Category";
            // 
            // usernameEditTbox
            // 
            this.usernameEditTbox.Location = new System.Drawing.Point(92, 28);
            this.usernameEditTbox.Name = "usernameEditTbox";
            this.usernameEditTbox.Size = new System.Drawing.Size(156, 20);
            this.usernameEditTbox.TabIndex = 1;
            // 
            // categoryEditCbox
            // 
            this.categoryEditCbox.FormattingEnabled = true;
            this.categoryEditCbox.Location = new System.Drawing.Point(92, 160);
            this.categoryEditCbox.Name = "categoryEditCbox";
            this.categoryEditCbox.Size = new System.Drawing.Size(156, 21);
            this.categoryEditCbox.TabIndex = 16;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 75);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(74, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Mot de passe:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 116);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Confirmation:";
            // 
            // passwordEditTBox
            // 
            this.passwordEditTBox.Location = new System.Drawing.Point(92, 72);
            this.passwordEditTBox.Name = "passwordEditTBox";
            this.passwordEditTBox.Size = new System.Drawing.Size(156, 20);
            this.passwordEditTBox.TabIndex = 4;
            this.passwordEditTBox.Enter += new System.EventHandler(this.passwordEditTBox_Enter);
            // 
            // passwordEditTboxConf
            // 
            this.passwordEditTboxConf.Location = new System.Drawing.Point(92, 113);
            this.passwordEditTboxConf.Name = "passwordEditTboxConf";
            this.passwordEditTboxConf.Size = new System.Drawing.Size(156, 20);
            this.passwordEditTboxConf.TabIndex = 5;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(650, 383);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Creé utilisateur";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.createdmessageholder);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.categoryCBox);
            this.groupBox2.Controls.Add(this.pwdTBoxConf);
            this.groupBox2.Controls.Add(this.pwdTBox);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.usernameTBox);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.createBtn);
            this.groupBox2.Location = new System.Drawing.Point(-1, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(10);
            this.groupBox2.Size = new System.Drawing.Size(645, 372);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Informations";
            // 
            // createdmessageholder
            // 
            this.createdmessageholder.AutoSize = true;
            this.createdmessageholder.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createdmessageholder.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.createdmessageholder.Location = new System.Drawing.Point(150, 242);
            this.createdmessageholder.Name = "createdmessageholder";
            this.createdmessageholder.Size = new System.Drawing.Size(142, 24);
            this.createdmessageholder.TabIndex = 16;
            this.createdmessageholder.Text = "Some message";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 207);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Category";
            // 
            // categoryCBox
            // 
            this.categoryCBox.FormattingEnabled = true;
            this.categoryCBox.Location = new System.Drawing.Point(150, 197);
            this.categoryCBox.Name = "categoryCBox";
            this.categoryCBox.Size = new System.Drawing.Size(419, 21);
            this.categoryCBox.TabIndex = 12;
            // 
            // pwdTBoxConf
            // 
            this.pwdTBoxConf.Location = new System.Drawing.Point(150, 152);
            this.pwdTBoxConf.Name = "pwdTBoxConf";
            this.pwdTBoxConf.Size = new System.Drawing.Size(419, 20);
            this.pwdTBoxConf.TabIndex = 11;
            // 
            // pwdTBox
            // 
            this.pwdTBox.Location = new System.Drawing.Point(150, 122);
            this.pwdTBox.Name = "pwdTBox";
            this.pwdTBox.Size = new System.Drawing.Size(419, 20);
            this.pwdTBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Mot de passe:";
            // 
            // usernameTBox
            // 
            this.usernameTBox.Location = new System.Drawing.Point(150, 77);
            this.usernameTBox.Name = "usernameTBox";
            this.usernameTBox.Size = new System.Drawing.Size(419, 20);
            this.usernameTBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Pseudo: ";
            // 
            // createBtn
            // 
            this.createBtn.Image = global::espaceNetSAV.Properties.Resources._116_user_plus;
            this.createBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.createBtn.Location = new System.Drawing.Point(476, 224);
            this.createBtn.Name = "createBtn";
            this.createBtn.Size = new System.Drawing.Size(93, 49);
            this.createBtn.TabIndex = 13;
            this.createBtn.Text = "Créé";
            this.createBtn.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.createBtn.UseVisualStyleBackColor = true;
            this.createBtn.Click += new System.EventHandler(this.createBtn_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox6);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(650, 383);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Historique";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.listView1);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(3, 3);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(644, 377);
            this.groupBox6.TabIndex = 0;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Dernier 30 jours";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader1});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.Location = new System.Drawing.Point(3, 16);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(638, 358);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Date";
            // 
            // columnHeader3
            // 
            this.columnHeader3.DisplayIndex = 2;
            this.columnHeader3.Text = "A changé";
            // 
            // columnHeader4
            // 
            this.columnHeader4.DisplayIndex = 3;
            this.columnHeader4.Text = "à ";
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 1;
            this.columnHeader1.Text = "Bon N°";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            this.statusStrip1.Location = new System.Drawing.Point(0, 431);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1022, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1007, 17);
            this.toolStripStatusLabel1.Spring = true;
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1022, 453);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AdminPanel";
            this.Text = "Paneau d\'Administration";
            this.Load += new System.EventHandler(this.AdminPanel_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gérerToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TreeView usersList;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox pwdTBoxConf;
        private System.Windows.Forms.TextBox pwdTBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usernameTBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button createBtn;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox categoryCBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox passwordEditTboxConf;
        private System.Windows.Forms.TextBox passwordEditTBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button saveChangesBtn;
        private System.Windows.Forms.TextBox usernameEditTbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox categoryEditCbox;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button deleteUserBtn;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ToolStripMenuItem historiqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historiqueToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem réceptionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listCompleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem techniqueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem valdéToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasEncoreToolStripMenuItem;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBoxValide;
        private System.Windows.Forms.CheckBox checkBoxHistory;
        private System.Windows.Forms.Label createdmessageholder;
        private System.Windows.Forms.ColumnHeader columnHeader1;

    }
}
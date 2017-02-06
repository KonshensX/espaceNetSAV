namespace espaceNetSAV.Admin
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.usernameTBox = new System.Windows.Forms.TextBox();
            this.passwordTBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.makeUserBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.makeUserBtn);
            this.groupBox1.Controls.Add(this.passwordTBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.usernameTBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(531, 257);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username:";
            // 
            // usernameTBox
            // 
            this.usernameTBox.Location = new System.Drawing.Point(102, 26);
            this.usernameTBox.Name = "usernameTBox";
            this.usernameTBox.Size = new System.Drawing.Size(160, 20);
            this.usernameTBox.TabIndex = 1;
            // 
            // passwordTBox
            // 
            this.passwordTBox.Location = new System.Drawing.Point(102, 70);
            this.passwordTBox.Name = "passwordTBox";
            this.passwordTBox.Size = new System.Drawing.Size(160, 20);
            this.passwordTBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password:";
            // 
            // makeUserBtn
            // 
            this.makeUserBtn.Location = new System.Drawing.Point(333, 26);
            this.makeUserBtn.Name = "makeUserBtn";
            this.makeUserBtn.Size = new System.Drawing.Size(125, 60);
            this.makeUserBtn.TabIndex = 4;
            this.makeUserBtn.Text = "Create user";
            this.makeUserBtn.UseVisualStyleBackColor = true;
            this.makeUserBtn.Click += new System.EventHandler(this.makeUserBtn_Click);
            // 
            // AdminPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(903, 392);
            this.Controls.Add(this.groupBox1);
            this.Name = "AdminPanel";
            this.Text = "AdminPanel";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button makeUserBtn;
        private System.Windows.Forms.TextBox passwordTBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox usernameTBox;
        private System.Windows.Forms.Label label1;
    }
}
namespace espaceNetSAV.Admin
{
    partial class LoginForm
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.errorHolderLabel = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.passwordTBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.connecter = new System.Windows.Forms.Button();
            this.usernameTBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.errorHolderLabel);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.passwordTBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.connecter);
            this.groupBox1.Controls.Add(this.usernameTBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(315, 505);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Login section";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::espaceNetSAV.Properties.Resources.ok_ok_ok_ok;
            this.pictureBox1.Location = new System.Drawing.Point(51, 66);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(220, 129);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // errorHolderLabel
            // 
            this.errorHolderLabel.AutoSize = true;
            this.errorHolderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.errorHolderLabel.ForeColor = System.Drawing.Color.DarkRed;
            this.errorHolderLabel.Location = new System.Drawing.Point(48, 370);
            this.errorHolderLabel.Name = "errorHolderLabel";
            this.errorHolderLabel.Size = new System.Drawing.Size(104, 15);
            this.errorHolderLabel.TabIndex = 5;
            this.errorHolderLabel.Text = "Message d\'erreur";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(51, 336);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(153, 17);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "Se souvient de moi (BETA)";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // passwordTBox
            // 
            this.passwordTBox.Location = new System.Drawing.Point(51, 310);
            this.passwordTBox.Name = "passwordTBox";
            this.passwordTBox.PasswordChar = '*';
            this.passwordTBox.Size = new System.Drawing.Size(212, 20);
            this.passwordTBox.TabIndex = 2;
            this.passwordTBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.passwordTBox_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(47, 287);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "Mot de pass";
            // 
            // connecter
            // 
            this.connecter.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connecter.Location = new System.Drawing.Point(139, 408);
            this.connecter.Name = "connecter";
            this.connecter.Size = new System.Drawing.Size(124, 39);
            this.connecter.TabIndex = 4;
            this.connecter.Text = "Se connecter";
            this.connecter.UseVisualStyleBackColor = true;
            this.connecter.Click += new System.EventHandler(this.button1_Click);
            // 
            // usernameTBox
            // 
            this.usernameTBox.Location = new System.Drawing.Point(51, 243);
            this.usernameTBox.Name = "usernameTBox";
            this.usernameTBox.Size = new System.Drawing.Size(212, 20);
            this.usernameTBox.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(47, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pseudo";
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 517);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "LoginForm";
            this.ShowIcon = false;
            this.Text = "Connexion";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox passwordTBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button connecter;
        private System.Windows.Forms.TextBox usernameTBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Label errorHolderLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}
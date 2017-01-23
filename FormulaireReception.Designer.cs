namespace espaceNetSAV
{
    partial class FormulaireReception
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
            this.diusplayListBtn = new System.Windows.Forms.Button();
            this.clientComboBox = new System.Windows.Forms.ComboBox();
            this.refAchattbox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.clientTypeRB = new System.Windows.Forms.RadioButton();
            this.rsTypeRB = new System.Windows.Forms.RadioButton();
            this.contactTBox = new System.Windows.Forms.TextBox();
            this.contactLabel = new System.Windows.Forms.Label();
            this.emailTBox = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.faxTBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.buttonValider = new System.Windows.Forms.Button();
            this.problTBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.designTBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dateValuelbl = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.telTBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.makePdfButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.makePdfButton);
            this.groupBox1.Controls.Add(this.diusplayListBtn);
            this.groupBox1.Controls.Add(this.clientComboBox);
            this.groupBox1.Controls.Add(this.refAchattbox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.contactTBox);
            this.groupBox1.Controls.Add(this.contactLabel);
            this.groupBox1.Controls.Add(this.emailTBox);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.faxTBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.buttonValider);
            this.groupBox1.Controls.Add(this.problTBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.designTBox);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dateValuelbl);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.telTBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(929, 389);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Formulaire";
            // 
            // diusplayListBtn
            // 
            this.diusplayListBtn.Location = new System.Drawing.Point(155, 345);
            this.diusplayListBtn.Name = "diusplayListBtn";
            this.diusplayListBtn.Size = new System.Drawing.Size(123, 23);
            this.diusplayListBtn.TabIndex = 23;
            this.diusplayListBtn.Text = "Display List";
            this.diusplayListBtn.UseVisualStyleBackColor = true;
            this.diusplayListBtn.Click += new System.EventHandler(this.diusplayListBtn_Click);
            // 
            // clientComboBox
            // 
            this.clientComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.clientComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.clientComboBox.FormattingEnabled = true;
            this.clientComboBox.Location = new System.Drawing.Point(238, 35);
            this.clientComboBox.Name = "clientComboBox";
            this.clientComboBox.Size = new System.Drawing.Size(158, 21);
            this.clientComboBox.TabIndex = 22;
            this.clientComboBox.SelectedIndexChanged += new System.EventHandler(this.clientComboBox_SelectedIndexChanged);
            this.clientComboBox.TextChanged += new System.EventHandler(this.clientComboBox_TextChanged);
            // 
            // refAchattbox
            // 
            this.refAchattbox.Location = new System.Drawing.Point(238, 116);
            this.refAchattbox.Name = "refAchattbox";
            this.refAchattbox.Size = new System.Drawing.Size(158, 20);
            this.refAchattbox.TabIndex = 21;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(152, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(65, 16);
            this.label8.TabIndex = 20;
            this.label8.Text = "Réf achat";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.clientTypeRB);
            this.groupBox2.Controls.Add(this.rsTypeRB);
            this.groupBox2.Location = new System.Drawing.Point(12, 20);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(134, 100);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Type";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // clientTypeRB
            // 
            this.clientTypeRB.AutoSize = true;
            this.clientTypeRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.clientTypeRB.Location = new System.Drawing.Point(6, 19);
            this.clientTypeRB.Name = "clientTypeRB";
            this.clientTypeRB.Size = new System.Drawing.Size(59, 20);
            this.clientTypeRB.TabIndex = 11;
            this.clientTypeRB.TabStop = true;
            this.clientTypeRB.Text = "Client";
            this.clientTypeRB.UseVisualStyleBackColor = true;
            this.clientTypeRB.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // rsTypeRB
            // 
            this.rsTypeRB.AutoSize = true;
            this.rsTypeRB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rsTypeRB.Location = new System.Drawing.Point(6, 46);
            this.rsTypeRB.Name = "rsTypeRB";
            this.rsTypeRB.Size = new System.Drawing.Size(118, 20);
            this.rsTypeRB.TabIndex = 12;
            this.rsTypeRB.TabStop = true;
            this.rsTypeRB.Text = "Raison Sociale";
            this.rsTypeRB.UseVisualStyleBackColor = true;
            this.rsTypeRB.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // contactTBox
            // 
            this.contactTBox.Location = new System.Drawing.Point(507, 77);
            this.contactTBox.Name = "contactTBox";
            this.contactTBox.Size = new System.Drawing.Size(158, 20);
            this.contactTBox.TabIndex = 18;
            // 
            // contactLabel
            // 
            this.contactLabel.AutoSize = true;
            this.contactLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactLabel.Location = new System.Drawing.Point(415, 78);
            this.contactLabel.Name = "contactLabel";
            this.contactLabel.Size = new System.Drawing.Size(53, 16);
            this.contactLabel.TabIndex = 17;
            this.contactLabel.Text = "Contact";
            // 
            // emailTBox
            // 
            this.emailTBox.Location = new System.Drawing.Point(747, 77);
            this.emailTBox.Name = "emailTBox";
            this.emailTBox.Size = new System.Drawing.Size(158, 20);
            this.emailTBox.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(683, 78);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Email";
            // 
            // faxTBox
            // 
            this.faxTBox.Location = new System.Drawing.Point(747, 33);
            this.faxTBox.Name = "faxTBox";
            this.faxTBox.Size = new System.Drawing.Size(158, 20);
            this.faxTBox.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(683, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 16);
            this.label4.TabIndex = 13;
            this.label4.Text = "Fax";
            // 
            // buttonValider
            // 
            this.buttonValider.Location = new System.Drawing.Point(782, 345);
            this.buttonValider.Name = "buttonValider";
            this.buttonValider.Size = new System.Drawing.Size(123, 23);
            this.buttonValider.TabIndex = 10;
            this.buttonValider.Text = "Valider";
            this.buttonValider.UseVisualStyleBackColor = true;
            this.buttonValider.Click += new System.EventHandler(this.button1_Click);
            // 
            // problTBox
            // 
            this.problTBox.Location = new System.Drawing.Point(555, 179);
            this.problTBox.Multiline = true;
            this.problTBox.Name = "problTBox";
            this.problTBox.Size = new System.Drawing.Size(350, 145);
            this.problTBox.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(705, 160);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 16);
            this.label6.TabIndex = 8;
            this.label6.Text = "Problème";
            // 
            // designTBox
            // 
            this.designTBox.Location = new System.Drawing.Point(155, 179);
            this.designTBox.Multiline = true;
            this.designTBox.Name = "designTBox";
            this.designTBox.Size = new System.Drawing.Size(394, 145);
            this.designTBox.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(299, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 16);
            this.label5.TabIndex = 6;
            this.label5.Text = "Désignation";
            // 
            // dateValuelbl
            // 
            this.dateValuelbl.AutoSize = true;
            this.dateValuelbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateValuelbl.Location = new System.Drawing.Point(235, 78);
            this.dateValuelbl.Name = "dateValuelbl";
            this.dateValuelbl.Size = new System.Drawing.Size(90, 16);
            this.dateValuelbl.TabIndex = 5;
            this.dateValuelbl.Text = "dd/mm/YYYY";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(152, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 16);
            this.label3.TabIndex = 4;
            this.label3.Text = "Date:";
            // 
            // telTBox
            // 
            this.telTBox.Location = new System.Drawing.Point(507, 35);
            this.telTBox.Name = "telTBox";
            this.telTBox.Size = new System.Drawing.Size(158, 20);
            this.telTBox.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(415, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 16);
            this.label2.TabIndex = 2;
            this.label2.Text = "Télephone";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(152, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Client";
            // 
            // makePdfButton
            // 
            this.makePdfButton.Location = new System.Drawing.Point(302, 345);
            this.makePdfButton.Name = "makePdfButton";
            this.makePdfButton.Size = new System.Drawing.Size(123, 23);
            this.makePdfButton.TabIndex = 24;
            this.makePdfButton.Text = "Make pdf";
            this.makePdfButton.UseVisualStyleBackColor = true;
            this.makePdfButton.Click += new System.EventHandler(this.makePdfButton_Click);
            // 
            // FormulaireReception
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(929, 401);
            this.Controls.Add(this.groupBox1);
            this.Name = "FormulaireReception";
            this.Text = "µ";
            this.Load += new System.EventHandler(this.FormulaireReception_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox contactTBox;
        private System.Windows.Forms.Label contactLabel;
        private System.Windows.Forms.TextBox emailTBox;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox faxTBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.RadioButton rsTypeRB;
        private System.Windows.Forms.RadioButton clientTypeRB;
        private System.Windows.Forms.Button buttonValider;
        private System.Windows.Forms.TextBox problTBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox designTBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label dateValuelbl;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox telTBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox refAchattbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox clientComboBox;
        private System.Windows.Forms.Button diusplayListBtn;
        private System.Windows.Forms.Button makePdfButton;
    }
}
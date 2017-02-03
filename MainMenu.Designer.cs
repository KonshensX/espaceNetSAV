namespace espaceNetSAV
{
    partial class MainMenu
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
            this.technique = new System.Windows.Forms.Button();
            this.reception = new System.Windows.Forms.Button();
            this.bonList = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // technique
            // 
            this.technique.Location = new System.Drawing.Point(275, 214);
            this.technique.Name = "technique";
            this.technique.Size = new System.Drawing.Size(233, 46);
            this.technique.TabIndex = 0;
            this.technique.Text = "Technique";
            this.technique.UseVisualStyleBackColor = true;
            this.technique.Click += new System.EventHandler(this.technique_Click);
            // 
            // reception
            // 
            this.reception.Location = new System.Drawing.Point(275, 91);
            this.reception.Name = "reception";
            this.reception.Size = new System.Drawing.Size(233, 46);
            this.reception.TabIndex = 0;
            this.reception.Text = "Réception";
            this.reception.UseVisualStyleBackColor = true;
            this.reception.Click += new System.EventHandler(this.reception_Click);
            // 
            // bonList
            // 
            this.bonList.Location = new System.Drawing.Point(275, 152);
            this.bonList.Name = "bonList";
            this.bonList.Size = new System.Drawing.Size(233, 46);
            this.bonList.TabIndex = 1;
            this.bonList.Text = "Liste";
            this.bonList.UseVisualStyleBackColor = true;
            this.bonList.Click += new System.EventHandler(this.bonList_Click);
            // 
            // MainMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(773, 328);
            this.Controls.Add(this.bonList);
            this.Controls.Add(this.reception);
            this.Controls.Add(this.technique);
            this.Name = "MainMenu";
            this.Text = "MainMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button technique;
        private System.Windows.Forms.Button reception;
        private System.Windows.Forms.Button bonList;
    }
}
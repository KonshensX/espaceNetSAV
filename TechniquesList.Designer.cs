namespace espaceNetSAV
{
    partial class TechniquesList
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.BonDataGrid = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.bonNumTBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.telTBox = new System.Windows.Forms.TextBox();
            this.clientTBox = new System.Windows.Forms.TextBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            ((System.ComponentModel.ISupportInitialize)(this.BonDataGrid)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BonDataGrid
            // 
            this.BonDataGrid.AllowUserToAddRows = false;
            this.BonDataGrid.AllowUserToDeleteRows = false;
            this.BonDataGrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.BonDataGrid.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.BonDataGrid.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Raised;
            this.BonDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.BonDataGrid.DefaultCellStyle = dataGridViewCellStyle1;
            this.BonDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BonDataGrid.GridColor = System.Drawing.Color.White;
            this.BonDataGrid.Location = new System.Drawing.Point(0, 100);
            this.BonDataGrid.Name = "BonDataGrid";
            this.BonDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.BonDataGrid.Size = new System.Drawing.Size(968, 373);
            this.BonDataGrid.TabIndex = 1;
            this.BonDataGrid.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.BonDataGrid_CellContentClick);
            this.BonDataGrid.CellMouseUp += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.BonDataGrid_CellMouseUp);
            this.BonDataGrid.RowEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.BonDataGrid_RowEnter);
            this.BonDataGrid.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BonDataGrid_KeyDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.bonNumTBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.telTBox);
            this.groupBox1.Controls.Add(this.clientTBox);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(968, 100);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filter";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePicker1.Location = new System.Drawing.Point(575, 53);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(160, 20);
            this.dateTimePicker1.TabIndex = 8;
            this.dateTimePicker1.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(184, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Bon N°";
            // 
            // bonNumTBox
            // 
            this.bonNumTBox.Location = new System.Drawing.Point(242, 53);
            this.bonNumTBox.Name = "bonNumTBox";
            this.bonNumTBox.Size = new System.Drawing.Size(208, 20);
            this.bonNumTBox.TabIndex = 6;
            this.bonNumTBox.TextChanged += new System.EventHandler(this.bonNumTBox_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(500, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(500, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Telephone";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(184, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Client";
            // 
            // telTBox
            // 
            this.telTBox.Location = new System.Drawing.Point(575, 19);
            this.telTBox.Name = "telTBox";
            this.telTBox.Size = new System.Drawing.Size(160, 20);
            this.telTBox.TabIndex = 1;
            this.telTBox.TextChanged += new System.EventHandler(this.telTBox_TextChanged);
            // 
            // clientTBox
            // 
            this.clientTBox.Location = new System.Drawing.Point(242, 19);
            this.clientTBox.Name = "clientTBox";
            this.clientTBox.Size = new System.Drawing.Size(208, 20);
            this.clientTBox.TabIndex = 0;
            this.clientTBox.TextChanged += new System.EventHandler(this.clientTBox_TextChanged);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 451);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(968, 22);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // TechniquesList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(968, 473);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.BonDataGrid);
            this.Controls.Add(this.groupBox1);
            this.Name = "TechniquesList";
            this.ShowIcon = false;
            this.Text = "Technique";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.TechniquesList_FormClosed);
            this.Load += new System.EventHandler(this.TechniquesList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.BonDataGrid)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView BonDataGrid;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox bonNumTBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox telTBox;
        private System.Windows.Forms.TextBox clientTBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
    }
}
﻿namespace FormProjectPRG2781
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_ViewAll = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Summary = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.btn_Clear = new System.Windows.Forms.Button();
            this.btn_Search = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_ImportCSV = new System.Windows.Forms.Button();
            this.lblLine = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.btn_Add.ForeColor = System.Drawing.Color.White;
            this.btn_Add.Location = new System.Drawing.Point(68, 618);
            this.btn_Add.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(149, 64);
            this.btn_Add.TabIndex = 0;
            this.btn_Add.Text = "Add Student";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            this.btn_Add.MouseLeave += new System.EventHandler(this.btn_Add_MouseLeave);
            this.btn_Add.MouseHover += new System.EventHandler(this.btn_Add_MouseHover);
            // 
            // btn_ViewAll
            // 
            this.btn_ViewAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.btn_ViewAll.ForeColor = System.Drawing.Color.White;
            this.btn_ViewAll.Location = new System.Drawing.Point(1248, 144);
            this.btn_ViewAll.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btn_ViewAll.Name = "btn_ViewAll";
            this.btn_ViewAll.Size = new System.Drawing.Size(243, 58);
            this.btn_ViewAll.TabIndex = 1;
            this.btn_ViewAll.Text = "View All Students";
            this.btn_ViewAll.UseVisualStyleBackColor = false;
            this.btn_ViewAll.Click += new System.EventHandler(this.btn_ViewAll_Click);
            this.btn_ViewAll.MouseLeave += new System.EventHandler(this.btn_ViewAll_MouseLeave);
            this.btn_ViewAll.MouseHover += new System.EventHandler(this.btn_ViewAll_MouseHover);
            // 
            // btn_Update
            // 
            this.btn_Update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.btn_Update.ForeColor = System.Drawing.Color.White;
            this.btn_Update.Location = new System.Drawing.Point(1587, 652);
            this.btn_Update.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(251, 71);
            this.btn_Update.TabIndex = 1;
            this.btn_Update.Text = "Update Student Information";
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            this.btn_Update.MouseLeave += new System.EventHandler(this.btn_Update_MouseLeave);
            this.btn_Update.MouseHover += new System.EventHandler(this.btn_Update_MouseHover);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 204);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(112, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "StudentID:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(61, 311);
            this.label2.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 25);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 415);
            this.label3.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Age:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(61, 532);
            this.label4.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 25);
            this.label4.TabIndex = 2;
            this.label4.Text = "Course:";
            // 
            // btn_Summary
            // 
            this.btn_Summary.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.btn_Summary.ForeColor = System.Drawing.Color.White;
            this.btn_Summary.Location = new System.Drawing.Point(1181, 652);
            this.btn_Summary.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btn_Summary.Name = "btn_Summary";
            this.btn_Summary.Size = new System.Drawing.Size(232, 79);
            this.btn_Summary.TabIndex = 1;
            this.btn_Summary.Text = "Generate Summary Report";
            this.btn_Summary.UseVisualStyleBackColor = false;
            this.btn_Summary.Click += new System.EventHandler(this.btn_Summary_Click);
            this.btn_Summary.MouseLeave += new System.EventHandler(this.btn_Summary_MouseLeave);
            this.btn_Summary.MouseHover += new System.EventHandler(this.btn_Summary_MouseHover);
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.btn_Delete.ForeColor = System.Drawing.Color.White;
            this.btn_Delete.Location = new System.Drawing.Point(1684, 144);
            this.btn_Delete.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(152, 58);
            this.btn_Delete.TabIndex = 1;
            this.btn_Delete.Text = "Delete";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            this.btn_Delete.MouseLeave += new System.EventHandler(this.btn_Delete_MouseLeave);
            this.btn_Delete.MouseHover += new System.EventHandler(this.btn_Delete_MouseHover);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(677, 214);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.Size = new System.Drawing.Size(1157, 428);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(244, 194);
            this.textBox1.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(311, 31);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(244, 298);
            this.textBox2.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(311, 31);
            this.textBox2.TabIndex = 4;
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(248, 402);
            this.textBox3.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(305, 31);
            this.textBox3.TabIndex = 4;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(248, 519);
            this.textBox4.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(305, 31);
            this.textBox4.TabIndex = 4;
            // 
            // btn_Clear
            // 
            this.btn_Clear.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.btn_Clear.ForeColor = System.Drawing.Color.White;
            this.btn_Clear.Location = new System.Drawing.Point(408, 618);
            this.btn_Clear.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btn_Clear.Name = "btn_Clear";
            this.btn_Clear.Size = new System.Drawing.Size(149, 64);
            this.btn_Clear.TabIndex = 1;
            this.btn_Clear.Text = "Clear";
            this.btn_Clear.UseVisualStyleBackColor = false;
            this.btn_Clear.Click += new System.EventHandler(this.btn_Clear_Click_1);
            this.btn_Clear.MouseLeave += new System.EventHandler(this.btn_Clear_MouseLeave);
            this.btn_Clear.MouseHover += new System.EventHandler(this.btn_Clear_MouseHover);
            // 
            // btn_Search
            // 
            this.btn_Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.btn_Search.ForeColor = System.Drawing.Color.White;
            this.btn_Search.Location = new System.Drawing.Point(749, 144);
            this.btn_Search.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(149, 58);
            this.btn_Search.TabIndex = 5;
            this.btn_Search.Text = "Search";
            this.btn_Search.UseVisualStyleBackColor = false;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            this.btn_Search.MouseLeave += new System.EventHandler(this.btn_Search_MouseLeave);
            this.btn_Search.MouseHover += new System.EventHandler(this.btn_Search_MouseHover);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Elephant", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Orange;
            this.label6.Location = new System.Drawing.Point(318, -5);
            this.label6.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(1013, 83);
            this.label6.TabIndex = 7;
            this.label6.Text = "Student Management System";
            // 
            // btn_ImportCSV
            // 
            this.btn_ImportCSV.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(44)))), ((int)(((byte)(44)))));
            this.btn_ImportCSV.ForeColor = System.Drawing.Color.White;
            this.btn_ImportCSV.Location = new System.Drawing.Point(209, 736);
            this.btn_ImportCSV.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_ImportCSV.Name = "btn_ImportCSV";
            this.btn_ImportCSV.Size = new System.Drawing.Size(199, 50);
            this.btn_ImportCSV.TabIndex = 9;
            this.btn_ImportCSV.Text = "Import CSV";
            this.btn_ImportCSV.UseVisualStyleBackColor = false;
            this.btn_ImportCSV.Click += new System.EventHandler(this.btn_ImportCSV_Click);
            this.btn_ImportCSV.MouseLeave += new System.EventHandler(this.btn_ImportCSV_MouseLeave);
            this.btn_ImportCSV.MouseHover += new System.EventHandler(this.btn_ImportCSV_MouseHover);
            // 
            // lblLine
            // 
            this.lblLine.AutoSize = true;
            this.lblLine.ForeColor = System.Drawing.Color.Orange;
            this.lblLine.Location = new System.Drawing.Point(204, 62);
            this.lblLine.Name = "lblLine";
            this.lblLine.Size = new System.Drawing.Size(1308, 25);
            this.lblLine.TabIndex = 10;
            this.lblLine.Text = "_________________________________________________________________________________" +
    "___________________________";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(238, 10);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(72, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(1893, 865);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblLine);
            this.Controls.Add(this.btn_ImportCSV);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.btn_Clear);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.btn_Summary);
            this.Controls.Add(this.btn_ViewAll);
            this.Controls.Add(this.btn_Add);
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_ViewAll;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Summary;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Button btn_Clear;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_ImportCSV;
        private System.Windows.Forms.Label lblLine;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}


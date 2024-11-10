namespace FormProjectPRG2781
{
    partial class SummaryReport
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
            this.richTextBoxSumm = new System.Windows.Forms.RichTextBox();
            this.btnBack = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // richTextBoxSumm
            // 
            this.richTextBoxSumm.Location = new System.Drawing.Point(41, 32);
            this.richTextBoxSumm.Name = "richTextBoxSumm";
            this.richTextBoxSumm.Size = new System.Drawing.Size(792, 237);
            this.richTextBoxSumm.TabIndex = 0;
            this.richTextBoxSumm.Text = "";
            // 
            // btnBack
            // 
            this.btnBack.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnBack.Location = new System.Drawing.Point(373, 275);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(107, 36);
            this.btnBack.TabIndex = 1;
            this.btnBack.Text = "Back";
            this.btnBack.UseVisualStyleBackColor = false;
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // SummaryReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(244)))), ((int)(((byte)(247)))));
            this.ClientSize = new System.Drawing.Size(891, 335);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.richTextBoxSumm);
            this.Name = "SummaryReport";
            this.Text = "SummaryReport";
            this.Load += new System.EventHandler(this.SummaryReport_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxSumm;
        private System.Windows.Forms.Button btnBack;
    }
}
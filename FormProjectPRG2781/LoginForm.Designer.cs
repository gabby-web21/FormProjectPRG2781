namespace FormProjectPRG2781
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
            this.usernametxt = new System.Windows.Forms.TextBox();
            this.Passwordtxt = new System.Windows.Forms.TextBox();
            this.Username = new System.Windows.Forms.Label();
            this.s = new System.Windows.Forms.Label();
            this.btn_Login = new System.Windows.Forms.Button();
            this.Heading = new System.Windows.Forms.Label();
            this.Showpasswordchk = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // usernametxt
            // 
            this.usernametxt.Location = new System.Drawing.Point(376, 216);
            this.usernametxt.Name = "usernametxt";
            this.usernametxt.Size = new System.Drawing.Size(193, 26);
            this.usernametxt.TabIndex = 0;
            this.usernametxt.TextChanged += new System.EventHandler(this.usernametxt_TextChanged);
            // 
            // Passwordtxt
            // 
            this.Passwordtxt.Location = new System.Drawing.Point(376, 317);
            this.Passwordtxt.Name = "Passwordtxt";
            this.Passwordtxt.Size = new System.Drawing.Size(193, 26);
            this.Passwordtxt.TabIndex = 1;
            this.Passwordtxt.UseSystemPasswordChar = true;
            this.Passwordtxt.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // Username
            // 
            this.Username.AutoSize = true;
            this.Username.Location = new System.Drawing.Point(212, 222);
            this.Username.Name = "Username";
            this.Username.Size = new System.Drawing.Size(83, 20);
            this.Username.TabIndex = 2;
            this.Username.Text = "Username";
            // 
            // s
            // 
            this.s.AutoSize = true;
            this.s.Location = new System.Drawing.Point(217, 320);
            this.s.Name = "s";
            this.s.Size = new System.Drawing.Size(78, 20);
            this.s.TabIndex = 3;
            this.s.Text = "Password";
            // 
            // btn_Login
            // 
            this.btn_Login.Location = new System.Drawing.Point(306, 388);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(155, 32);
            this.btn_Login.TabIndex = 4;
            this.btn_Login.Text = "LOGIN";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // Heading
            // 
            this.Heading.AutoSize = true;
            this.Heading.Location = new System.Drawing.Point(212, 67);
            this.Heading.Name = "Heading";
            this.Heading.Size = new System.Drawing.Size(110, 20);
            this.Heading.TabIndex = 5;
            this.Heading.Text = "LOGIN FORM";
            // 
            // Showpasswordchk
            // 
            this.Showpasswordchk.AutoSize = true;
            this.Showpasswordchk.Location = new System.Drawing.Point(582, 319);
            this.Showpasswordchk.Name = "Showpasswordchk";
            this.Showpasswordchk.Size = new System.Drawing.Size(148, 24);
            this.Showpasswordchk.TabIndex = 6;
            this.Showpasswordchk.Text = "Show Password";
            this.Showpasswordchk.UseVisualStyleBackColor = true;
            this.Showpasswordchk.CheckedChanged += new System.EventHandler(this.Showpasswordchk_CheckedChanged);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(742, 438);
            this.Controls.Add(this.Showpasswordchk);
            this.Controls.Add(this.Heading);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.Username);
            this.Controls.Add(this.Passwordtxt);
            this.Controls.Add(this.usernametxt);
            this.Controls.Add(this.s);
            this.Name = "LoginForm";
            this.Text = "LoginForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox usernametxt;
        private System.Windows.Forms.TextBox Passwordtxt;
        private System.Windows.Forms.Label Username;
        private System.Windows.Forms.Label s;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Label Heading;
        private System.Windows.Forms.CheckBox Showpasswordchk;
    }
}
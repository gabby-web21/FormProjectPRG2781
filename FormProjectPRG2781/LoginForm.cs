using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;


namespace FormProjectPRG2781
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void usernametxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            string filepath = @"Resources\credentials.txt";

            string username = usernametxt.Text.Trim();
            string password = Passwordtxt.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter both username and password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            

            try
            {
                var lines = File.ReadAllLines(filepath);

                //THIS CHECKS IF THE ANY OF THE LINES MATCHES THE USERNAME AND PASSWORD
                bool isValidUser = lines.Any(line =>
                {
                    var parts = line.Split(',');
                    return parts.Length == 2 && parts[0] == username && parts[1] == password;
                });

                if (!IsValidPassword(password))
                {
                    MessageBox.Show("Password must be at least 8 characters long, contain at least one uppercase letter and one number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                if (isValidUser)
                {
                    //IF THE USER IS VALID, THIS WILL OPEN THE MAIN FORM
                    Form1 form1 = new Form1();
                    form1.Show();
                    this.Hide(); //THIS HIDES THE LOGIN FORM
                }
                else
                {
                    MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Showpasswordchk_CheckedChanged(object sender, EventArgs e)
        {
            Passwordtxt.UseSystemPasswordChar = !Showpasswordchk.Checked;
        }

        private bool IsValidPassword(string password)
        {
            // Check for minimum length, at least one uppercase letter, and at least one number
            return password.Length >= 8 &&
                   Regex.IsMatch(password, @"[A-Z]") &&
                   Regex.IsMatch(password, @"[0-9]");
        }
    }
}

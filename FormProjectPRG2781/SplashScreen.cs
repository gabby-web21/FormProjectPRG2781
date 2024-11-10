using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FormProjectPRG2781
{
    public partial class SplashScreen : Form
    {
        public SplashScreen()
        {
            InitializeComponent();
        }

        private void progressBar_Click(object sender, EventArgs e)
        {

        }
        private void timer1_Tick(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (progressBar.Value < 100)
            {
                progressBar.Value += 2;
                label3.Text = progressBar.Value.ToString() + "%";
            }
            else
            {
                timer1.Stop();
                LoginForm frmMyLog = new LoginForm();
                frmMyLog.Show();
                this.Hide();
            }
        }

        private void SplashScreen_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }
    }
}

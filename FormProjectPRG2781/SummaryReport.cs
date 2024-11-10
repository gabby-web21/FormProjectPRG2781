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

namespace FormProjectPRG2781
{
    public partial class SummaryReport : Form
    {
        public SummaryReport()
        {
            InitializeComponent();
        }

        private void SummaryReport_Load(object sender, EventArgs e)
        {
            string filePath = @"Resources\Summary.txt";

            try
            {
                if (File.Exists(filePath))
                {
                    string summaryContent = File.ReadAllText(filePath);
                    richTextBoxSumm.Text = summaryContent;
                }
                else
                {
                    richTextBoxSumm.Text = "Summary file not found.";
                }
            }
            catch (Exception ex)
            {
                richTextBoxSumm.Text = "Error loading summary: " + ex.Message;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 main = new Form1();
            main.Show();
        }
    }
}

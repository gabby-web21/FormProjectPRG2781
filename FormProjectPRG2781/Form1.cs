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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string studentID = textBox1.Text;
            string studName = textBox2.Text;
            int studAge = int.Parse(textBox3.Text); 
            string course = textBox4.Text;

            try
            {
                string filepath = @"C:\Users\Kirsten\source\repos\PRG2781_Project(1)\PRG2781_Project(1)\bin\Debug\students.txt"; 
                using (StreamWriter writer = new StreamWriter(filepath, true))
                {
                    writer.WriteLine($"{studentID}, {studName}, {studAge}, {course}"); 
                }

                MessageBox.Show("Student Details Saved Successfully"); 
            }
            catch (Exception ex)
            {
               MessageBox.Show("Error, data not saved" + ex.Message);
                throw;
            }
        }
    }
}

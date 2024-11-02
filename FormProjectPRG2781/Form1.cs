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
        DataTable table = new DataTable(); 
        //specifying file path for text file
        string filepath = @"C:\Users\Kirsten\source\repos\PRG2781_Project(1)\PRG2781_Project(1)\bin\Debug\students.txt";

        private void Form1_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Student ID", typeof(int));
            table.Columns.Add("Full Name", typeof(string));
            table.Columns.Add("Age", typeof(int));
            table.Columns.Add("Course", typeof(string));

            dataGridView1.DataSource = table;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //declaring and initializing variables with textboxes to refer to them. 
            string studentID = textBox1.Text;
            string studName = textBox2.Text;
            int studAge = int.Parse(textBox3.Text); 
            string course = textBox4.Text;

            try
            {
                
                //using streamwriter to write to file 
                using (StreamWriter writer = new StreamWriter(filepath, true))
                {
                    writer.WriteLine($"{studentID}, {studName}, {studAge}, {course}"); 
                }

                MessageBox.Show("Student Details Saved Successfully"); 
            }
            //error message displayed if try doesnt work
            catch (Exception ex)
            {
               MessageBox.Show("Error, data not saved" + ex.Message);
                throw;
            }

            textBox1.Text = " ";
            textBox2.Text = " ";
            textBox3.Text = " ";
            textBox4.Text = " ";
        }


        private void button2_Click(object sender, EventArgs e)
        {

            string[] allStudents = File.ReadAllLines(filepath); 
            string[] allValues;
            for (int i = 0; i < allStudents.Length; i++)
            {
                allValues = allStudents[i].ToString().Split(','); 
                string[] row = new string[allValues.Length];

                for (int j = 0; j < allValues.Length; j++)
                {
                    row[j] = allValues[j].Trim(); 
                }
                try
                {
                    table.Rows.Add(row);

                }
                catch (Exception except)
                {
                    MessageBox.Show(except.Message); 
                    throw;
                }
                
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        

        private void button3_Click(object sender, EventArgs e)
        {

        }
    }
}

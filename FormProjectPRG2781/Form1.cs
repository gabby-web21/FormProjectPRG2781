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
            string studAge = textBox3.Text; 
            string course = textBox4.Text;

            if(string.IsNullOrWhiteSpace(studentID) || string.IsNullOrWhiteSpace(studName) || string.IsNullOrWhiteSpace(studAge) || string.IsNullOrWhiteSpace(course))
            {
                MessageBox.Show("Please enter information in all fields required (ID, Name, Age, Course");
                return; 
            }
            else
            {
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

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {
            table.Rows.Clear(); 
            string[] allStudents = File.ReadAllLines(filepath); 

            foreach(string student in allStudents)
            {
                string[] allValues = student.Split(',').Select(value => value.Trim()).ToArray();
                if (allValues.Length == table.Columns.Count)
                {
                    table.Rows.Add(allValues);
                }
                else
                {
                    MessageBox.Show("File is incorrect"); 
                }
            } 
           
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                textBox1.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                textBox3.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox4.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();

            }
            else
            {
                MessageBox.Show("Invalid index number"); 
            }
        }

        

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }
    }
}

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

        string relativePath = @"Resources\students.txt";

        string filepath;
        //try open or create file 

        private void Form1_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Student ID", typeof(int));
            table.Columns.Add("Full Name", typeof(string));
            table.Columns.Add("Age", typeof(int));
            table.Columns.Add("Course", typeof(string));

            dataGridView1.DataSource = table;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;



            filepath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, relativePath);

            if (!File.Exists(filepath))
            {
                MessageBox.Show("File not found, creating new file");
                //File.Create(filepath).Close();
            }
            else
            {
                MessageBox.Show("File has been found!"); 
            }
            MessageBox.Show("Filepath: " + filepath); 
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //declaring and initializing variables with textboxes to refer to them. 
            string studentID = textBox1.Text;
            string studName = textBox2.Text;
            int studAge; 
            string course = textBox4.Text;

            //creating validation for age to make sure a numeric value is entered
            if (!int.TryParse(textBox3.Text, out studAge))
            {
                
                MessageBox.Show("Please enter a numeric value for age e.g. 19");
                return;
            }
            else
            {
                studAge = int.Parse(textBox3.Text);
            }
            

            if (string.IsNullOrWhiteSpace(studentID) || string.IsNullOrWhiteSpace(studName) || string.IsNullOrWhiteSpace(course))
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
                    try
                    {
                        table.Rows.Add(allValues);
                    }
                    catch (Exception eBug)
                    {
                        MessageBox.Show("Enter valid ID number" + eBug.Message); 
                        return;
                    }
                   
                }
                else
                {
                    MessageBox.Show("Text file error"); 
                    
                }
            } 
           
        }

        //this method is for the information to autofill in the textboxes for convenience when editing or updating
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                //string cellValue = dataGridView1.Rows
                
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

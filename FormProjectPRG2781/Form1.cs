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
using System.Drawing.Design;

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
        string filepath = @"C:\Users\Kirsten\source\repos\FormProjectPRG2781\FormProjectPRG2781\Resources\Students.txt";

        
        
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
            if (string.IsNullOrEmpty(filepath))
            {
                MessageBox.Show("File path is not set");
                return; 
            }

            //Creating a filestream to open or create file at specified filepath and specificying that the file should be open for 
            //appending, as well as indicating that the file will be opened with writing access.  
            using (FileStream myStream = new FileStream(filepath, FileMode.Append, FileAccess.Write))
            {
                using (StreamWriter writer = new StreamWriter(myStream))
                {
                    //declaring and initializing variables with textboxes to refer to them. 
                    //adding Trim function to eliminate any whitespace in between inputs
                    string studentID = textBox1.Text.Trim();
                    string studName = textBox2.Text.Trim();
                    int studAge;
                    string course = textBox4.Text.Trim();
                    //creating validation for age to make sure a numeric value for age is entered
                    if (!int.TryParse(textBox3.Text, out studAge))
                    {

                        MessageBox.Show("Please enter a numeric value for age e.g. 19");
                        return;
                    }
                    else
                    {
                        studAge = int.Parse(textBox3.Text.Trim());
                    }


                    if (string.IsNullOrWhiteSpace(studentID) || string.IsNullOrWhiteSpace(studName) || string.IsNullOrWhiteSpace(course) || studAge < 0)
                    {
                        MessageBox.Show("Please enter valid information in all fields required (ID, Name, Age, Course");
                        return;
                    }
                        try
                        {
                            writer.WriteLine($"{studentID}, {studName}, {studAge}, {course}");

                            MessageBox.Show("Student Details Saved Successfully");
                        }
                        //error message displayed if try doesnt work
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error, data not saved" + ex.Message);
                        }

                        textBox1.Clear();
                        textBox2.Clear();
                        textBox3.Clear();
                        textBox4.Clear();
                }
            }
            

            
        }


        private void button2_Click(object sender, EventArgs e)
        {

            if (File.Exists(filepath))
            {
                table.Rows.Clear();
                try
                {
                    using (StreamReader reader = new StreamReader(filepath))
                    {
                        string txt;
                        while ((txt = reader.ReadLine()) != null)
                        {
                                string[] allValues = txt.Split(',').Select(value => value.Trim()).ToArray();

                            if (allValues.Length == table.Columns.Count)
                            {
                                try
                                {
                                  table.Rows.Add(allValues);
                                }
                                catch (Exception eBug)
                                {
                                    MessageBox.Show("Error adding rows" + eBug.Message);
                                    return;
                                }

                            }
                            else
                            {
                                MessageBox.Show("Text file error");

                            }

                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error reading file" + ex.Message); 
                    throw;
                }


            }
            else
            {
                MessageBox.Show("File does not exist"); 
            }


        }

        //this method is for the information to autofill in the textboxes for convenience when editing or updating
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow selectedRow = dataGridView1.Rows[e.RowIndex];

                textBox1.Text = selectedRow.Cells[0].Value.ToString();
                textBox2.Text = selectedRow.Cells[1].Value.ToString();
                textBox3.Text = selectedRow.Cells[2].Value.ToString();
                textBox4.Text = selectedRow.Cells[3].Value.ToString();
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

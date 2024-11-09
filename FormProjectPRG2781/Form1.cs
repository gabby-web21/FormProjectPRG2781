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
using Microsoft.VisualBasic; 

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
        string filepath = @"Resources\Students.txt";
        private int studentID;
        private string studName;
        private int studAge;
        private string course; 
        
        private void Form1_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Student ID", typeof(int));
            table.Columns.Add("Full Name", typeof(string));
            table.Columns.Add("Age", typeof(int));
            table.Columns.Add("Course", typeof(string));

            dataGridView1.DataSource = table;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        //creating a method for input from textboxes to reduce redundancy and clean up code
        private void ReadStudentInput()
        {
            //declaring and initializing variables with textboxes to refer to them. 
            //adding Trim function to eliminate any whitespace in between inputs
            if (!int.TryParse(textBox1.Text, out studentID))
            {

                MessageBox.Show("Please enter a numeric value for age e.g. 19");
                return;
            }
            else
            {
                studentID = int.Parse(textBox1.Text.Trim());
            }
            studName = textBox2.Text.Trim();
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
            course = textBox4.Text.Trim();

            //Ensuring no nulls and whitespaces are accepted into txt file. 
            if (studentID < 0|| string.IsNullOrWhiteSpace(studName) || string.IsNullOrWhiteSpace(course) || studAge < 0)
            {
                MessageBox.Show("Please enter valid information in all fields required (ID, Name, Age, Course");
                return;
            }
        }


        public void LoadStudentData()
        {
            table.Rows.Clear();
            if (File.Exists(filepath))
            {
                //clearing rows to ensure no duplication
                table.Rows.Clear();
                try
                {
                    using (StreamReader reader = new StreamReader(filepath))
                    {
                        string txt; 
                        
                        while ((txt = reader.ReadLine()) != null)
                        {
                            //splitting the line of text into an array of values, seperating them using a comma and
                            //trimming any whitespace
                            txt = txt.Trim();

                            if (string.IsNullOrWhiteSpace(txt) || string.IsNullOrEmpty(txt))
                            {
                                continue;
                            }
                            string[] allValues = txt.Split(',').Select(value => value.Trim()).ToArray();

                            //MessageBox.Show($"Found {allValues.Length} values in line: {txt}"); 

                            

                            if (allValues.Length == table.Columns.Count)
                            {
                                try
                                {
                                    table.Rows.Add(allValues);
                                }
                                catch (Exception eBug)
                                {
                                    MessageBox.Show("Error adding rows" + eBug.Message);
                                    
                                }

                            }
                            else
                            {
                                MessageBox.Show($"Text file error : Expected {table.Columns.Count} values bt found {allValues.Length} in line {txt}");

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

        private void btn_Add_Click(object sender, EventArgs e)
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
                    ReadStudentInput(); 
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


        private void btn_ViewAll_Click(object sender, EventArgs e)
        {
            //LoadStudentData(); 
            if (File.Exists(filepath))
            {
                //clearing rows to ensure no duplication
                table.Rows.Clear();
                try
                {
                    using (StreamReader reader = new StreamReader(filepath))
                    {
                        string txt;
                        while ((txt = reader.ReadLine()) != null)
                        {

                            txt = txt.Trim();
                            if (string.IsNullOrWhiteSpace(txt))
                            {
                                continue; 
                            }
                                //splitting the line of text into an array of values, seperating them using a comma and
                                //trimming any whitespace
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

            if(dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Please select a student record to update.");
                return; 
            }
        }

        private bool ISValidStudentID(string studentID)
        {
            return studentID.All(char.IsDigit) && studentID.Length >= 6; 
        }
        

        

        private void btn_Update_Click(object sender, EventArgs e)
        {
            // Read inputs and validate
            ReadStudentInput();
            if (studentID <= 0 || string.IsNullOrWhiteSpace(studName) || studAge <= 0 || string.IsNullOrWhiteSpace(course))
            {
                // Stop if inputs are invalid
                MessageBox.Show("Please enter valid student details.");
                return;
            }

            // Read existing records from file into a list
            List<string> studentRecs = new List<string>();
            try
            {
                using (StreamReader reader = new StreamReader(filepath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (!string.IsNullOrWhiteSpace(line))
                        {
                            studentRecs.Add(line.Trim());
                        }
                    }
                }
            }
            catch (Exception ee)
            {
                MessageBox.Show("Error reading the file: " + ee.Message);
                return;
            }

            // Flag to check if a matching student record is found
            bool validStudentID = false;

            // Update the record that matches the studentID
            for (int i = 0; i < studentRecs.Count; i++)
            {
                string[] recs = studentRecs[i].Split(',').Select(p => p.Trim()).ToArray();
                if (recs[0] == studentID.ToString()) // Check if ID matches
                {
                    studentRecs[i] = $"{studentID}, {studName}, {studAge}, {course}"; // Update record
                    validStudentID = true;
                    break;
                }
            }

            if (!validStudentID)
            {
                MessageBox.Show("Student ID not found.");
                return;
            }

            // Write updated records back to file
            try
            {
                File.WriteAllLines(filepath, studentRecs);
                MessageBox.Show("Student details updated successfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating data: " + ex.Message);
                return;
            }

            // Refresh the data grid to reflect changes
            LoadStudentData();
        }

        private void btn_Clear_Click_1(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            string deleteStudentID = textBox1.Text.Trim();
            if (string.IsNullOrWhiteSpace(deleteStudentID))
            {
                MessageBox.Show("Please enter a valid Student ID.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                var lines = File.ReadAllLines(filepath).ToList();
                bool studentFound = false;

                for (int i = 0; i < lines.Count; i++)
                {
                    var fields = lines[i].Split(',').Select(field => field.Trim()).ToArray();
                    if (fields[0] == deleteStudentID)
                    {
                        lines.RemoveAt(i);
                        studentFound = true;
                        break;
                    }

                }
                if (studentFound)
                {
                    File.WriteAllLines(filepath, lines);  // Rewrite the file without the deleted entry
                    MessageBox.Show("Student deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStudentData(); // Refresh the data in the grid
                }
                else
                {
                    MessageBox.Show("Student ID not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
               


            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                throw;
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            string studentID = string.Empty;

            while (string.IsNullOrEmpty(studentID) || !ISValidStudentID(studentID))
            {
                studentID = Interaction.InputBox("Enter student ID");
                if (string.IsNullOrEmpty(studentID))
                {
                    MessageBox.Show("No input provided");

                }
                else if (!ISValidStudentID(studentID))
                {
                    MessageBox.Show("Invalid ID format. Please enter valid student ID");
                }
            }

        }
    }
}

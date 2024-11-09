﻿using System;
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
            LoadStudentData(); 
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
            
            studName = textBox2.Text.Trim();
            //creating validation for age to make sure a numeric value for age is entered
            studName = textBox2.Text.Trim();
            //Ensuring no nulls and whitespaces are accepted into txt file. 
            if (string.IsNullOrWhiteSpace(studName))
            {
                MessageBox.Show("Please enter a valid name.");
                return;
            }

            if (!int.TryParse(textBox3.Text.Trim(), out studAge) || studAge < 0)
            {
                MessageBox.Show("Please enter a valid numeric value for age.");
                return;
            }

            course = textBox4.Text.Trim();
            if (string.IsNullOrWhiteSpace(course))
            {
                MessageBox.Show("Please enter a valid course.");
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
                        string line; 
                        
                        while ((line = reader.ReadLine()) != null)
                        {
                            //splitting the line of text into an array of values, seperating them using a comma and
                            //trimming any whitespace
                            line = line.Trim();

                            if (string.IsNullOrWhiteSpace(line))
                            {
                                continue;
                            }
                            string[] allValues = line.Split(',').Select(value => value.Trim()).ToArray();
                            if (allValues.Length == table.Columns.Count)
                            {
                               table.Rows.Add(allValues);

                            }
                            else
                            {
                                MessageBox.Show($"Text file error : Expected {table.Columns.Count} values bt found {allValues.Length} in line {line}");

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
            ReadStudentInput(); 
            if(studentID<0 || string.IsNullOrWhiteSpace(studName) || studAge <0 || string.IsNullOrWhiteSpace(course))
            {
                return; 
            }
           
            //Creating a filestream to open or create file at specified filepath and specificying that the file should be open for 
            //appending, as well as indicating that the file will be opened with writing access.  
            using (FileStream myStream = new FileStream(filepath, FileMode.Append, FileAccess.Write))
            using (StreamWriter writer = new StreamWriter(myStream))
            { 
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
            }
            ClearTextBoxes();
            LoadStudentData(); 
        }


        private void btn_ViewAll_Click(object sender, EventArgs e)
        {
            LoadStudentData(); 
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
            else 
            { 
                MessageBox.Show("Please select a student record to update.");
                return; 
            }
        }

        private bool ISValidStudentID(string studentID)
        {
            return studentID.All(char.IsDigit) && studentID.Length >= 6; 
        }

        List<string> studentRecs = new List<string>();
        private bool isEditMode = false; //flag to check if we are able to edit 

        private void btn_Update_Click(object sender, EventArgs e)
        {
            // Frst get the Student ID using a interaction box 
            if (!isEditMode)
            {
                string studentIDInput = Interaction.InputBox("Enter the Student ID to update:");
                if (string.IsNullOrWhiteSpace(studentIDInput) || !ISValidStudentID(studentIDInput))
                {
                    MessageBox.Show("Invalid Student ID. Please enter a valid numeric Student ID.");
                    return;
                }

                // Search for the student and highlight the row
                int rowIndex = SearchAndHighlightStudent(studentIDInput);
                if (rowIndex == -1)
                {
                    MessageBox.Show("Student ID not found.");
                    return;
                }

                studentRecs = File.ReadAllLines(filepath).ToList(); // Read from file and put data in a list 
                var selectedRecord = studentRecs[rowIndex].Split(','); // Assuming comma-separated values

                // Populate the text boxes with current values
                textBox1.Text = selectedRecord[0].Trim();
                textBox2.Text = selectedRecord[1].Trim();
                textBox3.Text = selectedRecord[2].Trim();
                textBox4.Text = selectedRecord[3].Trim();

                MessageBox.Show("Please edit the information in the text boxes and press 'Save Changes'.");

                // Update button text and set edit mode to true
                btn_Update.Text = "Save Changes";
                isEditMode = true;
            }
            else
            {
                //Save updated information if editing allowes
                ReadStudentInput(); // Read new values from text boxes

                // Update the student record in the list
                int rowIndex = SearchAndHighlightStudent(textBox1.Text);
                studentRecs[rowIndex] = $"{studentID}, {studName}, {studAge}, {course}"; // Update record

                try
                {
                    File.WriteAllLines(filepath, studentRecs); // Save to file
                    MessageBox.Show("Student details updated successfully.");
                }
                catch (Exception ee)
                {
                    MessageBox.Show("Error updating the file: " + ee.Message);
                }

                // Refresh the data grid to reflect changes
                LoadStudentData();
                HighlightRow(rowIndex);

                // Reset button text and edit mode flag
                btn_Update.Text = "Update Student";
                isEditMode = false;
            }
        }


        private int SearchAndHighlightStudent(string studentID)
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if (dataGridView1.Rows[i].Cells[0].Value != null && dataGridView1.Rows[i].Cells[0].Value.ToString() == studentID)
                    {
                        //highlights and scrolls to the selected row 
                        dataGridView1.Rows[i].Selected = true;
                        dataGridView1.FirstDisplayedScrollingRowIndex = i;
                        return i;
                    }
                }
            }
            catch (Exception e)
            {

                MessageBox.Show("Error occurred" + e.Message); 
                throw;
            }
            return -1; //Not found


        }

        private void HighlightRow(int rowIndex)
        {
            // Reset previous highlights
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                row.DefaultCellStyle.BackColor = Color.White;
                row.DefaultCellStyle.SelectionBackColor = Color.Blue; 
            }

            // Highlight the updated row
            if (rowIndex >= 0 && rowIndex < dataGridView1.Rows.Count)
            {
                dataGridView1.Rows[rowIndex].DefaultCellStyle.BackColor = Color.Yellow;
            }
        }

        private void ClearTextBoxes()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void btn_Clear_Click_1(object sender, EventArgs e)
        {
            ClearTextBoxes(); 
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

            FilterStudents(studentID);

        }

        private void FilterStudents(string studentID)
        {
            table.Rows.Clear();
            var filteredStudents = File.ReadAllLines(filepath)
                .Where(record => record.Split(',')[0].Trim() == studentID)
                .ToList();

            if (filteredStudents.Count == 0)
            {
                MessageBox.Show("No student found with that ID");
            }
            else
            {
                foreach (var student in filteredStudents)
                {
                    string[] fields = student.Split(',').Select(field => field.Trim()).ToArray();
                    table.Rows.Add(fields);
                }
            }
        }

        
    }
}

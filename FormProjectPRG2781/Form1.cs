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
using System.Threading;

namespace FormProjectPRG2781
{
    public partial class Form1 : Form
    {

        DataTable tableCSV = new DataTable();
        DataTable table = new DataTable();
        public Form1()
        {
            
            InitializeComponent();
            tableCSV = new DataTable();
            tableCSV.Columns.Add("StudentID");
            tableCSV.Columns.Add("Name");
            tableCSV.Columns.Add("Age");
            tableCSV.Columns.Add("Course");
            getIni(); 

        }
        
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
                try
                {
                    studentRecs[rowIndex] = $"{studentID}, {studName}, {studAge}, {course}"; // Update record
                }
                catch(Exception exx)
                {
                    MessageBox.Show("Unable to change student ID's" + exx.Message);
                    return; 
                }
               

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
                        dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
                        dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
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
            string studentID = Interaction.InputBox("Enter student ID to search:");

            if (string.IsNullOrEmpty(studentID) || !ISValidStudentID(studentID))
            {
                MessageBox.Show("Invalid input. Please enter a valid numeric Student ID with a minimum of 6 digits.");
                return;
            }

            int rowIndex = SearchAndHighlightStudent(studentID);

            if (rowIndex == -1)
            {
                MessageBox.Show("Student ID not found.");
            }
            else
            {
                MessageBox.Show("Student record found and filtered");
            }
            FilterStudents(studentID);

        }

        private void FilterStudents(string studentID)
        {
            table.Rows.Clear();
            if (File.Exists(filepath))
            {
                try
                {
                    var filteredLines = File.ReadAllLines(filepath)
                                            .Where(line => line.StartsWith(studentID + ","))
                                            .ToList();

                    if (filteredLines.Count > 0)
                    {
                        foreach (var line in filteredLines)
                        {
                            var fields = line.Split(',').Select(field => field.Trim()).ToArray();

                            if (fields.Length == table.Columns.Count)
                            {
                                table.Rows.Add(fields);
                            }
                            else
                            {
                                MessageBox.Show($"Data format error in line: {line}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("No matching records found.", "Search Results", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while filtering data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("File does not exist.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_ImportCSV_Click(object sender, EventArgs e)
        {            
        }
        private void ImportFromCSV()
        {            
        }
        
        private void ShowPreview(List<string> importedRecords)
        {
        }

        private void btn_Summary_Click(object sender, EventArgs e)
        {
            this.Close();
            string filenewPath = @"Resources\Summary.txt";
            
            try
            {
                if (File.Exists(filenewPath))
                {
                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("Does not exist and could not be created");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error loading summary: " + ex.Message);
                throw;
            }

            using (StreamReader sr = new StreamReader(filepath))
            {
                string text;
                int studCount = 0;
                int sumAge = 0;
                double avgAge = 0;
                while ((text = sr.ReadLine()) != null)
                {
                    string[] info = text.Split(',');
                    string studentNumber = info[0];
                    string name = info[1];
                    int age = int.Parse(info[2]);
                    string courseCode = info[3];
                    studCount++;
                    sumAge += age;
                }
                if (studCount > 0)
                {
                    avgAge = sumAge / studCount;
                }

                using (StreamWriter sw = new StreamWriter(filenewPath))
                {
                    sw.WriteLine($"You have {studCount} students");
                    sw.WriteLine("The average age is {0}", avgAge);
                }

                SummaryReport summaryReportForm = new SummaryReport();
                summaryReportForm.Show();
            }

            SummaryReport summr = new SummaryReport();
            summr.Show();
        }

        private void btn_Clear_MouseHover(object sender, EventArgs e)
        {
            btn_Clear.BackColor = Color.Orange;
        }

        private void btn_Clear_MouseLeave(object sender, EventArgs e)
        {
            btn_Clear.BackColor = Color.Gray;
        }

        private void btn_Add_MouseHover(object sender, EventArgs e)
        {
            btn_Add.BackColor = Color.Orange;
        }

        private void btn_Add_MouseLeave(object sender, EventArgs e)
        {
            btn_Add.BackColor = Color.Gray;
        }

        private void btn_ImportCSV_MouseHover(object sender, EventArgs e)
        {
         
        }

        private void btn_ImportCSV_MouseLeave(object sender, EventArgs e)
        {
           
        }

        private void btn_Search_MouseHover(object sender, EventArgs e)
        {
            btn_Search.BackColor = Color.Orange;
        }

        private void btn_Search_MouseLeave(object sender, EventArgs e)
        {
            btn_Search.BackColor = Color.Gray;
        }

        private void btn_ViewAll_MouseHover(object sender, EventArgs e)
        {
            btn_ViewAll.BackColor = Color.Orange;
        }

        private void btn_ViewAll_MouseLeave(object sender, EventArgs e)
        {
            btn_ViewAll.BackColor = Color.Gray;
        }

        private void btn_Delete_MouseHover(object sender, EventArgs e)
        {
            btn_Delete.BackColor = Color.Orange;
        }

        private void btn_Delete_MouseLeave(object sender, EventArgs e)
        {
            btn_Delete.BackColor = Color.Gray;
        }

        private void btn_Summary_MouseHover(object sender, EventArgs e)
        {
            btn_Summary.BackColor = Color.Orange;
        }

        private void btn_Summary_MouseLeave(object sender, EventArgs e)
        {
            btn_Summary.BackColor = Color.Gray;
        }

        private void btn_Update_MouseHover(object sender, EventArgs e)
        {
            btn_Update.BackColor = Color.Orange;
        }

        private void btn_Update_MouseLeave(object sender, EventArgs e)
        {
            btn_Update.BackColor = Color.Gray;
        }

        private void btn_Search_MouseHover_1(object sender, EventArgs e)
        {

        }

        private void  btn_CSV_Click(object sender, EventArgs e)
        {
            string txtFilePath = @"Resources\Students.txt";
            string csvFilePath = @"Resources\Imported Students.csv"; 

            // Load data from Students.txt to DataTable
            if (File.Exists(txtFilePath))
            {
                tableCSV.Rows.Clear();
                try
                {
                    using (StreamReader reader = new StreamReader(txtFilePath))
                    {
                        string line;
                        while ((line = reader.ReadLine()) != null)
                        {
                            line = line.Trim();
                            if (string.IsNullOrWhiteSpace(line))
                                continue;

                            string[] allValues = line.Split(',').Select(value => value.Trim()).ToArray();
                            if (allValues.Length == tableCSV.Columns.Count)
                            {
                                tableCSV.Rows.Add(allValues);
                            }
                            else
                            {
                                MessageBox.Show($"Text file error: Expected {tableCSV.Columns.Count} values but found {allValues.Length} in line {line}");
                            }
                        }
                    }

                    using (StreamWriter writer = new StreamWriter(csvFilePath, false, Encoding.UTF8))
                    {
                        // Write CSV header
                        string[] columnNames = tableCSV.Columns.Cast<DataColumn>().Select(column => column.ColumnName).ToArray();
                        writer.WriteLine(string.Join(",", columnNames));

                        // Write data rows
                        foreach (DataRow row in tableCSV.Rows)
                        {
                            string[] fields = row.ItemArray.Select(field => field.ToString()).ToArray();
                            writer.WriteLine(string.Join(",", fields));
                        }
                    }

                    MessageBox.Show("CSV file created successfully at " + csvFilePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                    throw;
                }
            }
            else
            {
                MessageBox.Show("Text file does not exist");
            }
        }

        private void getIni()
        {
            Settings get = new Settings();
            get.readIni();

            if (get.theme == "dark")
            {
                btn_toggle.Text = "LIGHT MODE";
                this.BackColor = Color.FromArgb(44, 44, 44);
                this.ForeColor = Color.White;

                dataGridView1.BackgroundColor = Color.FromArgb(45, 45, 48);
                dataGridView1.DefaultCellStyle.BackColor = Color.FromArgb(45, 45, 48);
                dataGridView1.DefaultCellStyle.ForeColor = Color.White;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(30, 30, 30);
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            }
            else
            {
                btn_toggle.Text = "DARK MODE";
                this.BackColor = Color.White;
                this.ForeColor = Color.FromArgb(44, 44, 44);

                dataGridView1.BackgroundColor = Color.White;
                dataGridView1.DefaultCellStyle.BackColor = Color.White;
                dataGridView1.DefaultCellStyle.ForeColor = Color.Black;
                dataGridView1.ColumnHeadersDefaultCellStyle.BackColor = Color.LightGray;
                dataGridView1.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void btn_toggle_Click(object sender, EventArgs e)
        {
            Settings set = new Settings();
            if (btn_toggle.Text == "DARK MODE")
            {
                set.writeIni("SECTION", "key", "dark");
            }
            else
            {
                set.writeIni("SECTION", "key", "light"); 
            }
            getIni();

        }
    }
    
}

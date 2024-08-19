using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace GradeManagerWin
{
    public partial class GradeManagerUI : Form
    {
        internal List<Student> students = null;
        public GradeManagerUI()
        {
            InitializeComponent();
        }

        private void LoadStudentFileButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog loadStudentFileDialog = new OpenFileDialog
            {
                InitialDirectory = @"C:\",
                Title = "Load Student File",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "json",
                Filter = "JSON files (*.json)|*.json",
                FilterIndex = 2,
                RestoreDirectory = true,

                ReadOnlyChecked = true,
                ShowReadOnly = true
            };

            if (loadStudentFileDialog.ShowDialog() == DialogResult.OK)
            {
                var jsonFile = loadStudentFileDialog.FileName;
                var json = File.ReadAllText(jsonFile);
                students = JsonConvert.DeserializeObject<List<Student>>(json);

                if (students != null)
                {
                    var message = $"Students loaded successfully. There are {students.Count} students currently.";
                    var caption = "Students Loaded Successfully";
                    MessageBox.Show(message, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                }

                else
                {
                    var message = "Loading of students failed!";
                    var caption = "Student Load Failed";
                    MessageBox.Show(message, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }

            else
            {
                var message = "Loading of students failed!";
                var caption = "Student Load Failed";
                MessageBox.Show(message, caption, MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
        }

        private void AddStudentButton_Click(object sender, EventArgs e)
        {
            var addStudentControl = new AddStudent(this);
            addStudentControl.Show();
            addStudentControl.Focus();
           
        }

        private void ShowStudentsButton_Click(object sender, EventArgs e)
        {
            var studentList = "Current Students: \r\n\r\n";

            if (students != null && students.Count > 0)
            {
                foreach (var student in students)
                {
                    studentList += $"{student.FirstName} {student.LastName}\r\n";
                }

                MessageBox.Show(studentList, "Current Students", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("There are no students loaded currently", "No Students Loaded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            
        }

        private void ShowStudentGradesButton_Click(object sender, EventArgs e)
        {
            var studentGradeControl = new StudentGradeReport(this);
            studentGradeControl.Show();
        }

        private void CalculateClassAverageButton_Click(object sender, EventArgs e)
        {
            // Take each student grade and average them all out.

            // For each student, we want to add all the grades to one value and keep track of the total grade count
            // as well as the sum, as the class average would be total grade count / sum.

            double average = 0;
            double gradeSum = 0;
            int gradeCount = 0;

            // Loop through all the students

            if (students != null && students.Count > 0)
            {
                foreach (var student in students)
                {
                    //Compute individual averages to save to file. Since individual grades will be saved to file,
                    // Class average can be computed when loading from file.

                    student.ComputeAverage(); // Compute the individual average for each student

                    // For each student, get each grade, add it to the gradeSum, and increment the gradeCount each time.

                    foreach (var grade in student.Grades)
                    {
                        gradeSum += grade; // Adding the grade to the gradeSum
                        gradeCount++; // Increasing the grade count by 1.
                    }

                    if (gradeCount == 0) // No need for explicit student check here, as if there are no students, then gradeCount will remain 0.
                    {
                        average = 0;
                    }

                    else
                    {
                        average = gradeSum / gradeCount;
                    }

                    
                }

                MessageBox.Show($"The current class average is {average}", "Class Average", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }

            else
            {
                MessageBox.Show("There are no students in the system", "No students", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            }
        }

        private void HighestGradeButton_Click(object sender, EventArgs e)
        {
            double maxGrade = 0; //Create a variable called maxGrade to hold the current maxGrade as we loop through all the grades.
            int count = 0; //Master grade count. If 0, then we are starting from the beginning.

            if (students != null && students.Count > 0)
            {
                foreach (var student in students)
                {
                    foreach (var grade in student.Grades)
                    {
                        if (count == 0 || grade > maxGrade) // If we are starting OR the next grade is greater than maxGrade, then assign the new highest grade to maxGrade.
                        {
                            maxGrade = grade;
                        }

                        count++; // Increment count outside of if because we want to increment this regardless of the case.
                    }
                }

                MessageBox.Show($"The highest grade is {maxGrade}", "Highest Grade", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                MessageBox.Show("There are no students in the system", "No Students", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void LowestGradeButton_Click(object sender, EventArgs e)
        {
            if (students != null && students.Count > 0)
            {
                double minGrade = 0; //Create a variable called minGrade to hold the current minGrade as we loop through all the grades.
                int count = 0; //Master grade count. If 0, then we are starting from the beginning.
                foreach (var student in students)
                {
                    foreach (var grade in student.Grades)
                    {
                        if (count == 0 || grade < minGrade) // If we are starting OR the next grade is lesser than minGrade, then assign the new lowest grade to minGrade.
                        {
                            minGrade = grade;
                        }

                        count++; // Increment count outside of if because we want to increment this regardless of the case.
                    }
                }

                MessageBox.Show($"The lowest grade is {minGrade}", "Lowest Grade", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            else
            {
                MessageBox.Show("There are no students in the system", "No Students", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void DeleteStudentButton_Click(object sender, EventArgs e)
        {
            var deleteStudentControl = new DeleteStudent(this); // Pass main UI data to control without copying, referencing same in memory.
                                                                // We need to do this, so the new data on the pop-up is updated back in the main UI
            deleteStudentControl.Show();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GradeManagerWin
{
    public partial class StudentGradeReport : Form
    {
        GradeManagerUI ui;
        public StudentGradeReport(GradeManagerUI ui)
        {
            InitializeComponent();
            this.ui = ui;
        }

        private void StudentGradeReport_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            var report = string.Empty; // String to hold report contents
            report += "Student Grade Report\r\n";
            report += "--------------------\r\n\r\n"; // Print header

            if (ui.students != null && ui.students.Count > 0)
            {
                foreach (var student in ui.students) // Loop through students 
                {
                    report += $"{student.FirstName} {student.LastName} "; // Print student name before printing grades, add space where grades will start

                    foreach (var grade in student.Grades)
                    {
                        report += $"{grade} "; // Print grades next to student name
                    }

                    report += "\r\n"; // Line break before next student
                }
            }

            else
            {
                report += "No students loaded.";
            }

            GradeReportTextBox.Text = report; // Populate the textbox with the report
        }
    }
}

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
    public partial class AddStudent : Form
    {
        private GradeManagerUI ui;
        public AddStudent(GradeManagerUI ui)
        {
            InitializeComponent();
            this.ui = ui;
        }

        private void SaveStudentButton_Click(object sender, EventArgs e)
        {
            var newStudentFirstName = FirstNameTextBox.Text;
            var newStudentLastName = LastNameTextBox.Text;
            var student = new Student(newStudentFirstName, newStudentLastName);
            ui.students.Add(student);
            var messageBoxMessage = $"New Student {newStudentFirstName} {newStudentLastName} has been added";
            var messageBoxCaption = "New Student Added";
            MessageBox.Show(messageBoxMessage, messageBoxCaption, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
            Close();
        }

        public string ReturnFirstName()
        {
            return FirstNameTextBox.Text;
        }

        public string ReturnLastName()
        {
            return LastNameTextBox.Text;
        }
    }
}

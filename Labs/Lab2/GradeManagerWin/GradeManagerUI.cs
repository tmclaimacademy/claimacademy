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
        List<Student> students;
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
            var addStudentControl = new AddStudent();
            addStudentControl.Show();
            addStudentControl.Focus();
            var newStudentFirstName = addStudentControl.ReturnFirstName();
            var newStudentLastName = addStudentControl.ReturnLastName();
            var student = new Student(newStudentFirstName, newStudentLastName);
            students.Add(student);
            var messageBoxMessage = $"New Student {newStudentFirstName} {newStudentLastName} has been added";
            var messageBoxCaption = "New Student Added";
            MessageBox.Show(messageBoxMessage, messageBoxCaption, MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
        }
    }
}

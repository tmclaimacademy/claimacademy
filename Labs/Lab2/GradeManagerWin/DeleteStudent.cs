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
    public partial class DeleteStudent : Form
    {
        private GradeManagerUI ui;

        public DeleteStudent(GradeManagerUI ui)
        {
            InitializeComponent();
            this.ui = ui;
        }

        private void DeleteStudent_Load(object sender, EventArgs e)
        {
            //StudentComboBox.
            // Add student list top dropdown box. Student list needs to be an array to use AddRange to add all the student names at once.
            if (ui.students != null &&  ui.students.Count > 0)
            {
                var studentNameList = new List<string>();

                foreach (var student in ui.students)
                {
                    studentNameList.Add($"{student.FirstName} {student.LastName}");
                }

                StudentComboBox.Items.AddRange(studentNameList.ToArray());
            }
            
        }
    }
}

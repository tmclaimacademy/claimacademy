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
        public AddStudent()
        {
            InitializeComponent();
        }

        private void SaveStudentButton_Click(object sender, EventArgs e)
        {
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

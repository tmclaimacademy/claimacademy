namespace GradeManagerWin
{
    partial class GradeManagerUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GradeManagerLabel = new System.Windows.Forms.Label();
            this.LoadStudentFileButton = new System.Windows.Forms.Button();
            this.AddStudentButton = new System.Windows.Forms.Button();
            this.ShowStudentsButton = new System.Windows.Forms.Button();
            this.ShowStudentGradesButton = new System.Windows.Forms.Button();
            this.CalculateClassAverageButton = new System.Windows.Forms.Button();
            this.HighestGradeButton = new System.Windows.Forms.Button();
            this.LowestGradeButton = new System.Windows.Forms.Button();
            this.DeleteStudentButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // GradeManagerLabel
            // 
            this.GradeManagerLabel.AutoSize = true;
            this.GradeManagerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GradeManagerLabel.Location = new System.Drawing.Point(271, 9);
            this.GradeManagerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.GradeManagerLabel.Name = "GradeManagerLabel";
            this.GradeManagerLabel.Size = new System.Drawing.Size(407, 61);
            this.GradeManagerLabel.TabIndex = 0;
            this.GradeManagerLabel.Text = "Grade Manager";
            // 
            // LoadStudentFileButton
            // 
            this.LoadStudentFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadStudentFileButton.Location = new System.Drawing.Point(27, 72);
            this.LoadStudentFileButton.Margin = new System.Windows.Forms.Padding(2);
            this.LoadStudentFileButton.Name = "LoadStudentFileButton";
            this.LoadStudentFileButton.Size = new System.Drawing.Size(242, 121);
            this.LoadStudentFileButton.TabIndex = 1;
            this.LoadStudentFileButton.Text = "Load Student File";
            this.LoadStudentFileButton.UseVisualStyleBackColor = true;
            this.LoadStudentFileButton.Click += new System.EventHandler(this.LoadStudentFileButton_Click);
            // 
            // AddStudentButton
            // 
            this.AddStudentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddStudentButton.Location = new System.Drawing.Point(53, 211);
            this.AddStudentButton.Margin = new System.Windows.Forms.Padding(2);
            this.AddStudentButton.Name = "AddStudentButton";
            this.AddStudentButton.Size = new System.Drawing.Size(187, 131);
            this.AddStudentButton.TabIndex = 2;
            this.AddStudentButton.Text = "Add Student";
            this.AddStudentButton.UseVisualStyleBackColor = true;
            this.AddStudentButton.Click += new System.EventHandler(this.AddStudentButton_Click);
            // 
            // ShowStudentsButton
            // 
            this.ShowStudentsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowStudentsButton.Location = new System.Drawing.Point(62, 373);
            this.ShowStudentsButton.Name = "ShowStudentsButton";
            this.ShowStudentsButton.Size = new System.Drawing.Size(207, 107);
            this.ShowStudentsButton.TabIndex = 3;
            this.ShowStudentsButton.Text = "Show Students";
            this.ShowStudentsButton.UseVisualStyleBackColor = true;
            this.ShowStudentsButton.Click += new System.EventHandler(this.ShowStudentsButton_Click);
            // 
            // ShowStudentGradesButton
            // 
            this.ShowStudentGradesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowStudentGradesButton.Location = new System.Drawing.Point(62, 511);
            this.ShowStudentGradesButton.Name = "ShowStudentGradesButton";
            this.ShowStudentGradesButton.Size = new System.Drawing.Size(192, 139);
            this.ShowStudentGradesButton.TabIndex = 4;
            this.ShowStudentGradesButton.Text = "Show Student Grades";
            this.ShowStudentGradesButton.UseVisualStyleBackColor = true;
            this.ShowStudentGradesButton.Click += new System.EventHandler(this.ShowStudentGradesButton_Click);
            // 
            // CalculateClassAverageButton
            // 
            this.CalculateClassAverageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CalculateClassAverageButton.Location = new System.Drawing.Point(540, 73);
            this.CalculateClassAverageButton.Name = "CalculateClassAverageButton";
            this.CalculateClassAverageButton.Size = new System.Drawing.Size(206, 147);
            this.CalculateClassAverageButton.TabIndex = 5;
            this.CalculateClassAverageButton.Text = "Calculate Class Average";
            this.CalculateClassAverageButton.UseVisualStyleBackColor = true;
            this.CalculateClassAverageButton.Click += new System.EventHandler(this.CalculateClassAverageButton_Click);
            // 
            // HighestGradeButton
            // 
            this.HighestGradeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HighestGradeButton.Location = new System.Drawing.Point(540, 246);
            this.HighestGradeButton.Name = "HighestGradeButton";
            this.HighestGradeButton.Size = new System.Drawing.Size(186, 96);
            this.HighestGradeButton.TabIndex = 6;
            this.HighestGradeButton.Text = "Highest Grade";
            this.HighestGradeButton.UseVisualStyleBackColor = true;
            this.HighestGradeButton.Click += new System.EventHandler(this.HighestGradeButton_Click);
            // 
            // LowestGradeButton
            // 
            this.LowestGradeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LowestGradeButton.Location = new System.Drawing.Point(553, 373);
            this.LowestGradeButton.Name = "LowestGradeButton";
            this.LowestGradeButton.Size = new System.Drawing.Size(153, 107);
            this.LowestGradeButton.TabIndex = 7;
            this.LowestGradeButton.Text = "Lowest Grade";
            this.LowestGradeButton.UseVisualStyleBackColor = true;
            this.LowestGradeButton.Click += new System.EventHandler(this.LowestGradeButton_Click);
            // 
            // DeleteStudentButton
            // 
            this.DeleteStudentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteStudentButton.Location = new System.Drawing.Point(553, 511);
            this.DeleteStudentButton.Name = "DeleteStudentButton";
            this.DeleteStudentButton.Size = new System.Drawing.Size(173, 104);
            this.DeleteStudentButton.TabIndex = 8;
            this.DeleteStudentButton.Text = "Delete Student";
            this.DeleteStudentButton.UseVisualStyleBackColor = true;
            this.DeleteStudentButton.Click += new System.EventHandler(this.DeleteStudentButton_Click);
            // 
            // GradeManagerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 690);
            this.Controls.Add(this.DeleteStudentButton);
            this.Controls.Add(this.LowestGradeButton);
            this.Controls.Add(this.HighestGradeButton);
            this.Controls.Add(this.CalculateClassAverageButton);
            this.Controls.Add(this.ShowStudentGradesButton);
            this.Controls.Add(this.ShowStudentsButton);
            this.Controls.Add(this.AddStudentButton);
            this.Controls.Add(this.LoadStudentFileButton);
            this.Controls.Add(this.GradeManagerLabel);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "GradeManagerUI";
            this.Text = "GradeManagerUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GradeManagerLabel;
        private System.Windows.Forms.Button LoadStudentFileButton;
        private System.Windows.Forms.Button AddStudentButton;
        private System.Windows.Forms.Button ShowStudentsButton;
        private System.Windows.Forms.Button ShowStudentGradesButton;
        private System.Windows.Forms.Button CalculateClassAverageButton;
        private System.Windows.Forms.Button HighestGradeButton;
        private System.Windows.Forms.Button LowestGradeButton;
        private System.Windows.Forms.Button DeleteStudentButton;
    }
}


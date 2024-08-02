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
            this.SuspendLayout();
            // 
            // GradeManagerLabel
            // 
            this.GradeManagerLabel.AutoSize = true;
            this.GradeManagerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GradeManagerLabel.Location = new System.Drawing.Point(124, 5);
            this.GradeManagerLabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.GradeManagerLabel.Name = "GradeManagerLabel";
            this.GradeManagerLabel.Size = new System.Drawing.Size(215, 31);
            this.GradeManagerLabel.TabIndex = 0;
            this.GradeManagerLabel.Text = "Grade Manager";
            // 
            // LoadStudentFileButton
            // 
            this.LoadStudentFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadStudentFileButton.Location = new System.Drawing.Point(168, 60);
            this.LoadStudentFileButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.LoadStudentFileButton.Name = "LoadStudentFileButton";
            this.LoadStudentFileButton.Size = new System.Drawing.Size(101, 121);
            this.LoadStudentFileButton.TabIndex = 1;
            this.LoadStudentFileButton.Text = "Load Student File";
            this.LoadStudentFileButton.UseVisualStyleBackColor = true;
            this.LoadStudentFileButton.Click += new System.EventHandler(this.LoadStudentFileButton_Click);
            // 
            // AddStudentButton
            // 
            this.AddStudentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddStudentButton.Location = new System.Drawing.Point(168, 202);
            this.AddStudentButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddStudentButton.Name = "AddStudentButton";
            this.AddStudentButton.Size = new System.Drawing.Size(89, 89);
            this.AddStudentButton.TabIndex = 2;
            this.AddStudentButton.Text = "Add Student";
            this.AddStudentButton.UseVisualStyleBackColor = true;
            this.AddStudentButton.Click += new System.EventHandler(this.AddStudentButton_Click);
            // 
            // ShowStudentsButton
            // 
            this.ShowStudentsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowStudentsButton.Location = new System.Drawing.Point(168, 316);
            this.ShowStudentsButton.Name = "ShowStudentsButton";
            this.ShowStudentsButton.Size = new System.Drawing.Size(101, 64);
            this.ShowStudentsButton.TabIndex = 3;
            this.ShowStudentsButton.Text = "Show Students";
            this.ShowStudentsButton.UseVisualStyleBackColor = true;
            this.ShowStudentsButton.Click += new System.EventHandler(this.ShowStudentsButton_Click);
            // 
            // GradeManagerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 392);
            this.Controls.Add(this.ShowStudentsButton);
            this.Controls.Add(this.AddStudentButton);
            this.Controls.Add(this.LoadStudentFileButton);
            this.Controls.Add(this.GradeManagerLabel);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
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
    }
}


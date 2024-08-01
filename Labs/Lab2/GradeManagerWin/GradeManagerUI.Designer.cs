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
            this.SuspendLayout();
            // 
            // GradeManagerLabel
            // 
            this.GradeManagerLabel.AutoSize = true;
            this.GradeManagerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GradeManagerLabel.Location = new System.Drawing.Point(248, 9);
            this.GradeManagerLabel.Name = "GradeManagerLabel";
            this.GradeManagerLabel.Size = new System.Drawing.Size(407, 61);
            this.GradeManagerLabel.TabIndex = 0;
            this.GradeManagerLabel.Text = "Grade Manager";
            // 
            // LoadStudentFileButton
            // 
            this.LoadStudentFileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LoadStudentFileButton.Location = new System.Drawing.Point(335, 115);
            this.LoadStudentFileButton.Name = "LoadStudentFileButton";
            this.LoadStudentFileButton.Size = new System.Drawing.Size(202, 233);
            this.LoadStudentFileButton.TabIndex = 1;
            this.LoadStudentFileButton.Text = "Load Student File";
            this.LoadStudentFileButton.UseVisualStyleBackColor = true;
            this.LoadStudentFileButton.Click += new System.EventHandler(this.LoadStudentFileButton_Click);
            // 
            // AddStudentButton
            // 
            this.AddStudentButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddStudentButton.Location = new System.Drawing.Point(335, 389);
            this.AddStudentButton.Name = "AddStudentButton";
            this.AddStudentButton.Size = new System.Drawing.Size(178, 171);
            this.AddStudentButton.TabIndex = 2;
            this.AddStudentButton.Text = "Add Student";
            this.AddStudentButton.UseVisualStyleBackColor = true;
            this.AddStudentButton.Click += new System.EventHandler(this.AddStudentButton_Click);
            // 
            // GradeManagerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(941, 753);
            this.Controls.Add(this.AddStudentButton);
            this.Controls.Add(this.LoadStudentFileButton);
            this.Controls.Add(this.GradeManagerLabel);
            this.Name = "GradeManagerUI";
            this.Text = "GradeManagerUI";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label GradeManagerLabel;
        private System.Windows.Forms.Button LoadStudentFileButton;
        private System.Windows.Forms.Button AddStudentButton;
    }
}


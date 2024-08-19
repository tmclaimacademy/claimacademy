namespace GradeManagerWin
{
    partial class StudentGradeReport
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
            this.label1 = new System.Windows.Forms.Label();
            this.GradeReportTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(702, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(540, 61);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student Grade Report";
            // 
            // GradeReportTextBox
            // 
            this.GradeReportTextBox.Font = new System.Drawing.Font("Courier New", 16.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GradeReportTextBox.Location = new System.Drawing.Point(77, 89);
            this.GradeReportTextBox.Multiline = true;
            this.GradeReportTextBox.Name = "GradeReportTextBox";
            this.GradeReportTextBox.ReadOnly = true;
            this.GradeReportTextBox.Size = new System.Drawing.Size(1852, 1150);
            this.GradeReportTextBox.TabIndex = 1;
            // 
            // StudentGradeReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2057, 1321);
            this.Controls.Add(this.GradeReportTextBox);
            this.Controls.Add(this.label1);
            this.Name = "StudentGradeReport";
            this.Text = "StudentGradeReport";
            this.Load += new System.EventHandler(this.StudentGradeReport_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox GradeReportTextBox;
    }
}
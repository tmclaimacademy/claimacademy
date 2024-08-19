namespace GradeManagerWin
{
    partial class DeleteStudent
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
            this.DeleteStudentLabel = new System.Windows.Forms.Label();
            this.StudentComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // DeleteStudentLabel
            // 
            this.DeleteStudentLabel.AutoSize = true;
            this.DeleteStudentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DeleteStudentLabel.Location = new System.Drawing.Point(167, 9);
            this.DeleteStudentLabel.Name = "DeleteStudentLabel";
            this.DeleteStudentLabel.Size = new System.Drawing.Size(375, 61);
            this.DeleteStudentLabel.TabIndex = 0;
            this.DeleteStudentLabel.Text = "Delete Student";
            // 
            // StudentComboBox
            // 
            this.StudentComboBox.FormattingEnabled = true;
            this.StudentComboBox.Location = new System.Drawing.Point(195, 85);
            this.StudentComboBox.Name = "StudentComboBox";
            this.StudentComboBox.Size = new System.Drawing.Size(324, 21);
            this.StudentComboBox.TabIndex = 1;
            // 
            // DeleteStudent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.StudentComboBox);
            this.Controls.Add(this.DeleteStudentLabel);
            this.Name = "DeleteStudent";
            this.Text = "DeleteStudent";
            this.Load += new System.EventHandler(this.DeleteStudent_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label DeleteStudentLabel;
        private System.Windows.Forms.ComboBox StudentComboBox;
    }
}
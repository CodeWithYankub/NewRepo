
namespace ControlsLibrary.Grades
{
    partial class Add
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panSubjects = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.tbStudentId = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbStatus = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.nupTerm = new System.Windows.Forms.NumericUpDown();
            this.nupExam = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.nupTerm)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupExam)).BeginInit();
            this.SuspendLayout();
            // 
            // panSubjects
            // 
            this.panSubjects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panSubjects.Location = new System.Drawing.Point(24, 120);
            this.panSubjects.Name = "panSubjects";
            this.panSubjects.Size = new System.Drawing.Size(557, 392);
            this.panSubjects.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Student ID";
            // 
            // tbStudentId
            // 
            this.tbStudentId.Location = new System.Drawing.Point(24, 46);
            this.tbStudentId.Name = "tbStudentId";
            this.tbStudentId.Size = new System.Drawing.Size(132, 30);
            this.tbStudentId.TabIndex = 0;
            this.tbStudentId.Tag = "*";
            this.tbStudentId.TextChanged += new System.EventHandler(this.Field_Changed);
            this.tbStudentId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_Only);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(158, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(121, 23);
            this.label2.TabIndex = 3;
            this.label2.Text = "Academic Year";
            // 
            // cbYear
            // 
            this.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Location = new System.Drawing.Point(162, 46);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(185, 31);
            this.cbYear.TabIndex = 1;
            this.cbYear.Tag = "*";
            this.cbYear.SelectedIndexChanged += new System.EventHandler(this.Field_Changed);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(349, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Term";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(466, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 23);
            this.label4.TabIndex = 8;
            this.label4.Text = "Exam";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 94);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 23);
            this.label5.TabIndex = 9;
            this.label5.Text = "Subjects";
            // 
            // lbStatus
            // 
            this.lbStatus.AutoSize = true;
            this.lbStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStatus.Location = new System.Drawing.Point(20, 534);
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(0, 23);
            this.lbStatus.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.Location = new System.Drawing.Point(440, 528);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(141, 34);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save Records";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // nupTerm
            // 
            this.nupTerm.Location = new System.Drawing.Point(353, 46);
            this.nupTerm.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.nupTerm.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupTerm.Name = "nupTerm";
            this.nupTerm.Size = new System.Drawing.Size(111, 30);
            this.nupTerm.TabIndex = 11;
            this.nupTerm.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupTerm.ValueChanged += new System.EventHandler(this.nupTerm_ValueChanged);
            // 
            // nupExam
            // 
            this.nupExam.Location = new System.Drawing.Point(470, 46);
            this.nupExam.Maximum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.nupExam.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupExam.Name = "nupExam";
            this.nupExam.Size = new System.Drawing.Size(111, 30);
            this.nupExam.TabIndex = 12;
            this.nupExam.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nupExam.ValueChanged += new System.EventHandler(this.nupExam_ValueChanged);
            // 
            // Add
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.nupExam);
            this.Controls.Add(this.nupTerm);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lbStatus);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbYear);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbStudentId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panSubjects);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Add";
            this.Size = new System.Drawing.Size(603, 585);
            this.Load += new System.EventHandler(this.Add_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nupTerm)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupExam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panSubjects;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbStudentId;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lbStatus;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown nupTerm;
        private System.Windows.Forms.NumericUpDown nupExam;
    }
}

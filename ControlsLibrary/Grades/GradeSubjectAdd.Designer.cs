
namespace ControlsLibrary.Grades
{
    partial class GradeSubjectAdd
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
            this.lbSubject = new System.Windows.Forms.Label();
            this.tbScore = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbSubject
            // 
            this.lbSubject.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbSubject.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSubject.Location = new System.Drawing.Point(4, 4);
            this.lbSubject.Name = "lbSubject";
            this.lbSubject.Size = new System.Drawing.Size(578, 31);
            this.lbSubject.TabIndex = 0;
            this.lbSubject.Text = "Subject Name";
            this.lbSubject.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbScore
            // 
            this.tbScore.Dock = System.Windows.Forms.DockStyle.Right;
            this.tbScore.Location = new System.Drawing.Point(582, 4);
            this.tbScore.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tbScore.MaxLength = 2;
            this.tbScore.Name = "tbScore";
            this.tbScore.Size = new System.Drawing.Size(80, 30);
            this.tbScore.TabIndex = 1;
            this.tbScore.Tag = "*";
            this.tbScore.Text = "0";
            this.tbScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbScore.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbScore_KeyPress);
            // 
            // GradeSubjectAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lbSubject);
            this.Controls.Add(this.tbScore);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "GradeSubjectAdd";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.Size = new System.Drawing.Size(666, 39);
            this.Load += new System.EventHandler(this.GradeSubject_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbSubject;
        private System.Windows.Forms.TextBox tbScore;
    }
}

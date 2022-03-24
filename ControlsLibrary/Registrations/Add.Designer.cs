
namespace ControlsLibrary.Registrations
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbError = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.cbForm = new System.Windows.Forms.ComboBox();
            this.tbStudentID = new System.Windows.Forms.TextBox();
            this.tbReceiptNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.ttTitle = new System.Windows.Forms.ToolTip(this.components);
            this.flpSubjects = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Student ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Year";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.Location = new System.Drawing.Point(271, 458);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(135, 34);
            this.btnSave.TabIndex = 4;
            this.btnSave.Text = "Save Record";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbError
            // 
            this.lbError.AutoSize = true;
            this.lbError.ForeColor = System.Drawing.Color.Red;
            this.lbError.Location = new System.Drawing.Point(10, 464);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(0, 23);
            this.lbError.TabIndex = 5;
            this.lbError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(194, 71);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Form";
            // 
            // cbYear
            // 
            this.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Location = new System.Drawing.Point(14, 97);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(178, 31);
            this.cbYear.TabIndex = 2;
            this.cbYear.Tag = "*";
            // 
            // cbForm
            // 
            this.cbForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbForm.FormattingEnabled = true;
            this.cbForm.Location = new System.Drawing.Point(198, 97);
            this.cbForm.Name = "cbForm";
            this.cbForm.Size = new System.Drawing.Size(208, 31);
            this.cbForm.TabIndex = 3;
            this.cbForm.Tag = "*";
            this.cbForm.SelectedIndexChanged += new System.EventHandler(this.cbForm_SelectedIndexChanged);
            // 
            // tbStudentID
            // 
            this.tbStudentID.Location = new System.Drawing.Point(14, 36);
            this.tbStudentID.Name = "tbStudentID";
            this.tbStudentID.Size = new System.Drawing.Size(178, 30);
            this.tbStudentID.TabIndex = 0;
            this.tbStudentID.Tag = "*";
            this.tbStudentID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            // 
            // tbReceiptNo
            // 
            this.tbReceiptNo.Location = new System.Drawing.Point(198, 36);
            this.tbReceiptNo.Name = "tbReceiptNo";
            this.tbReceiptNo.Size = new System.Drawing.Size(208, 30);
            this.tbReceiptNo.TabIndex = 1;
            this.tbReceiptNo.Tag = "*";
            this.tbReceiptNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(194, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 23);
            this.label5.TabIndex = 12;
            this.label5.Text = "Receipt No.";
            // 
            // flpSubjects
            // 
            this.flpSubjects.AutoScroll = true;
            this.flpSubjects.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpSubjects.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpSubjects.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flpSubjects.Location = new System.Drawing.Point(14, 160);
            this.flpSubjects.Name = "flpSubjects";
            this.flpSubjects.Size = new System.Drawing.Size(392, 281);
            this.flpSubjects.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(10, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 23);
            this.label4.TabIndex = 14;
            this.label4.Text = "Subjects";
            // 
            // Add
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.flpSubjects);
            this.Controls.Add(this.tbReceiptNo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbStudentID);
            this.Controls.Add(this.cbForm);
            this.Controls.Add(this.cbYear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbError);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Add";
            this.Size = new System.Drawing.Size(421, 507);
            this.Load += new System.EventHandler(this.Add_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbError;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbYear;
        private System.Windows.Forms.ComboBox cbForm;
        private System.Windows.Forms.TextBox tbStudentID;
        private System.Windows.Forms.TextBox tbReceiptNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ToolTip ttTitle;
        private System.Windows.Forms.FlowLayoutPanel flpSubjects;
        private System.Windows.Forms.Label label4;
    }
}

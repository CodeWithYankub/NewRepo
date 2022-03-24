
namespace ControlsLibrary.Fees
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbError = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbYear = new System.Windows.Forms.ComboBox();
            this.tbStudentID = new System.Windows.Forms.TextBox();
            this.tbReceiptNo = new System.Windows.Forms.TextBox();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbTerm = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.chbPaidFull = new System.Windows.Forms.CheckBox();
            this.lbBalance = new System.Windows.Forms.Label();
            this.cbSector = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Receipt No.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(167, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Student ID";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.Location = new System.Drawing.Point(366, 201);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(135, 34);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save Record";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbError
            // 
            this.lbError.AutoSize = true;
            this.lbError.ForeColor = System.Drawing.Color.Red;
            this.lbError.Location = new System.Drawing.Point(10, 207);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(0, 23);
            this.lbError.TabIndex = 5;
            this.lbError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(351, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 23);
            this.label3.TabIndex = 7;
            this.label3.Text = "Year";
            // 
            // cbYear
            // 
            this.cbYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYear.FormattingEnabled = true;
            this.cbYear.Location = new System.Drawing.Point(355, 36);
            this.cbYear.Name = "cbYear";
            this.cbYear.Size = new System.Drawing.Size(146, 31);
            this.cbYear.TabIndex = 2;
            this.cbYear.Tag = "*";
            this.cbYear.SelectedIndexChanged += new System.EventHandler(this.cbYear_SelectedIndexChanged);
            // 
            // tbStudentID
            // 
            this.tbStudentID.Location = new System.Drawing.Point(171, 36);
            this.tbStudentID.Name = "tbStudentID";
            this.tbStudentID.Size = new System.Drawing.Size(178, 30);
            this.tbStudentID.TabIndex = 1;
            this.tbStudentID.Tag = "*";
            this.tbStudentID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            // 
            // tbReceiptNo
            // 
            this.tbReceiptNo.Location = new System.Drawing.Point(14, 36);
            this.tbReceiptNo.Name = "tbReceiptNo";
            this.tbReceiptNo.Size = new System.Drawing.Size(151, 30);
            this.tbReceiptNo.TabIndex = 0;
            this.tbReceiptNo.Tag = "*";
            this.tbReceiptNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(134, 97);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(250, 30);
            this.tbAmount.TabIndex = 3;
            this.tbAmount.Tag = "*";
            this.tbAmount.TextChanged += new System.EventHandler(this.tbAmount_TextChanged);
            this.tbAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Number_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(130, 71);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 23);
            this.label4.TabIndex = 12;
            this.label4.Text = "Amount";
            // 
            // tbTerm
            // 
            this.tbTerm.Location = new System.Drawing.Point(390, 97);
            this.tbTerm.Name = "tbTerm";
            this.tbTerm.Size = new System.Drawing.Size(111, 30);
            this.tbTerm.TabIndex = 4;
            this.tbTerm.Tag = "*";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(386, 71);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 23);
            this.label5.TabIndex = 14;
            this.label5.Text = "Term";
            // 
            // chbPaidFull
            // 
            this.chbPaidFull.AutoSize = true;
            this.chbPaidFull.Location = new System.Drawing.Point(14, 165);
            this.chbPaidFull.Name = "chbPaidFull";
            this.chbPaidFull.Size = new System.Drawing.Size(92, 27);
            this.chbPaidFull.TabIndex = 5;
            this.chbPaidFull.Text = "Paid full";
            this.chbPaidFull.UseVisualStyleBackColor = true;
            // 
            // lbBalance
            // 
            this.lbBalance.AutoSize = true;
            this.lbBalance.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbBalance.Location = new System.Drawing.Point(10, 130);
            this.lbBalance.Name = "lbBalance";
            this.lbBalance.Size = new System.Drawing.Size(73, 23);
            this.lbBalance.TabIndex = 15;
            this.lbBalance.Text = "Balance:";
            // 
            // cbSector
            // 
            this.cbSector.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSector.FormattingEnabled = true;
            this.cbSector.Items.AddRange(new object[] {
            "Select",
            "J. S. S",
            "S. S. S"});
            this.cbSector.Location = new System.Drawing.Point(14, 96);
            this.cbSector.Name = "cbSector";
            this.cbSector.Size = new System.Drawing.Size(114, 31);
            this.cbSector.TabIndex = 16;
            this.cbSector.Tag = "";
            this.cbSector.SelectedIndexChanged += new System.EventHandler(this.cbSector_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(10, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 23);
            this.label6.TabIndex = 17;
            this.label6.Text = "Sector";
            // 
            // Add
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.cbSector);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.lbBalance);
            this.Controls.Add(this.chbPaidFull);
            this.Controls.Add(this.tbTerm);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tbAmount);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tbReceiptNo);
            this.Controls.Add(this.tbStudentID);
            this.Controls.Add(this.cbYear);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbError);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Add";
            this.Size = new System.Drawing.Size(519, 252);
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
        private System.Windows.Forms.TextBox tbStudentID;
        private System.Windows.Forms.TextBox tbReceiptNo;
        private System.Windows.Forms.TextBox tbAmount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbTerm;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox chbPaidFull;
        private System.Windows.Forms.Label lbBalance;
        private System.Windows.Forms.ComboBox cbSector;
        private System.Windows.Forms.Label label6;
    }
}

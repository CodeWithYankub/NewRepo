
namespace ControlsLibrary.Years
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
            this.tbStart = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lbError = new System.Windows.Forms.Label();
            this.tbEnd = new System.Windows.Forms.TextBox();
            this.tbPeriod = new System.Windows.Forms.TextBox();
            this.chkIsFree = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkIsOpened = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(10, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Starts";
            // 
            // tbStart
            // 
            this.tbStart.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbStart.Location = new System.Drawing.Point(14, 36);
            this.tbStart.Name = "tbStart";
            this.tbStart.Size = new System.Drawing.Size(112, 30);
            this.tbStart.TabIndex = 0;
            this.tbStart.Tag = "*";
            this.tbStart.TextChanged += new System.EventHandler(this.tbStart_TextChanged);
            this.tbStart.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Fields_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(132, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ends";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.ForeColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.Location = new System.Drawing.Point(303, 117);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(135, 34);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Save Record";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbError
            // 
            this.lbError.AutoSize = true;
            this.lbError.ForeColor = System.Drawing.Color.Red;
            this.lbError.Location = new System.Drawing.Point(10, 128);
            this.lbError.Name = "lbError";
            this.lbError.Size = new System.Drawing.Size(0, 23);
            this.lbError.TabIndex = 5;
            this.lbError.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tbEnd
            // 
            this.tbEnd.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEnd.Location = new System.Drawing.Point(132, 36);
            this.tbEnd.Name = "tbEnd";
            this.tbEnd.ReadOnly = true;
            this.tbEnd.Size = new System.Drawing.Size(112, 30);
            this.tbEnd.TabIndex = 1;
            this.tbEnd.Tag = "*";
            // 
            // tbPeriod
            // 
            this.tbPeriod.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPeriod.Location = new System.Drawing.Point(250, 36);
            this.tbPeriod.Name = "tbPeriod";
            this.tbPeriod.ReadOnly = true;
            this.tbPeriod.Size = new System.Drawing.Size(188, 30);
            this.tbPeriod.TabIndex = 2;
            this.tbPeriod.Tag = "*";
            // 
            // chkIsFree
            // 
            this.chkIsFree.AutoSize = true;
            this.chkIsFree.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkIsFree.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsFree.Location = new System.Drawing.Point(132, 79);
            this.chkIsFree.Name = "chkIsFree";
            this.chkIsFree.Size = new System.Drawing.Size(81, 27);
            this.chkIsFree.TabIndex = 4;
            this.chkIsFree.Text = "Is Free";
            this.chkIsFree.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(246, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Period";
            // 
            // chkIsOpened
            // 
            this.chkIsOpened.AutoSize = true;
            this.chkIsOpened.Checked = true;
            this.chkIsOpened.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkIsOpened.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chkIsOpened.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkIsOpened.Location = new System.Drawing.Point(14, 79);
            this.chkIsOpened.Name = "chkIsOpened";
            this.chkIsOpened.Size = new System.Drawing.Size(110, 27);
            this.chkIsOpened.TabIndex = 3;
            this.chkIsOpened.Text = "Is Opened";
            this.chkIsOpened.UseVisualStyleBackColor = true;
            // 
            // Add
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.chkIsOpened);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chkIsFree);
            this.Controls.Add(this.tbPeriod);
            this.Controls.Add(this.tbEnd);
            this.Controls.Add(this.lbError);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbStart);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Add";
            this.Size = new System.Drawing.Size(450, 176);
            this.Load += new System.EventHandler(this.Add_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbError;
        private System.Windows.Forms.TextBox tbEnd;
        private System.Windows.Forms.TextBox tbPeriod;
        private System.Windows.Forms.CheckBox chkIsFree;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkIsOpened;
    }
}

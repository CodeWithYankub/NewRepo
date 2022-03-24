
namespace SLMB_SMS.Views.Students
{
    partial class Admit
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
            this.tbSurname = new System.Windows.Forms.TextBox();
            this.dtpDOB = new System.Windows.Forms.DateTimePicker();
            this.cbGender = new System.Windows.Forms.ComboBox();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpStudentDetails = new System.Windows.Forms.GroupBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbEmail = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.tbOtherName = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbGivenName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.picImgPath = new System.Windows.Forms.PictureBox();
            this.grpParent = new System.Windows.Forms.GroupBox();
            this.tbOccupation = new System.Windows.Forms.TextBox();
            this.chkCloneAdress = new System.Windows.Forms.CheckBox();
            this.tbPAddress = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbPEmail = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbRelation = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tbPName = new System.Windows.Forms.TextBox();
            this.tbPPhone = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.grpAdmission = new System.Windows.Forms.GroupBox();
            this.dtpAdmitted = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbColor = new System.Windows.Forms.ComboBox();
            this.tbID = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.grpStudentDetails.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImgPath)).BeginInit();
            this.grpParent.SuspendLayout();
            this.grpAdmission.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbSurname
            // 
            this.tbSurname.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbSurname.Location = new System.Drawing.Point(152, 66);
            this.tbSurname.Name = "tbSurname";
            this.tbSurname.Size = new System.Drawing.Size(220, 30);
            this.tbSurname.TabIndex = 1;
            // 
            // dtpDOB
            // 
            this.dtpDOB.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDOB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDOB.Location = new System.Drawing.Point(12, 225);
            this.dtpDOB.Name = "dtpDOB";
            this.dtpDOB.Size = new System.Drawing.Size(140, 30);
            this.dtpDOB.TabIndex = 5;
            // 
            // cbGender
            // 
            this.cbGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGender.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbGender.FormattingEnabled = true;
            this.cbGender.Items.AddRange(new object[] {
            "--- Select ---",
            "Female",
            "Male"});
            this.cbGender.Location = new System.Drawing.Point(378, 139);
            this.cbGender.Name = "cbGender";
            this.cbGender.Size = new System.Drawing.Size(220, 31);
            this.cbGender.TabIndex = 4;
            // 
            // tbPhone
            // 
            this.tbPhone.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPhone.Location = new System.Drawing.Point(158, 225);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(440, 30);
            this.tbPhone.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(154, 199);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(127, 23);
            this.label8.TabIndex = 38;
            this.label8.Text = "Phone Number";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(8, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 23);
            this.label6.TabIndex = 35;
            this.label6.Text = "Date Of Birth";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(148, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 23);
            this.label1.TabIndex = 28;
            this.label1.Text = "Surname";
            // 
            // grpStudentDetails
            // 
            this.grpStudentDetails.Controls.Add(this.tbAddress);
            this.grpStudentDetails.Controls.Add(this.label3);
            this.grpStudentDetails.Controls.Add(this.tbEmail);
            this.grpStudentDetails.Controls.Add(this.label2);
            this.grpStudentDetails.Controls.Add(this.label13);
            this.grpStudentDetails.Controls.Add(this.tbOtherName);
            this.grpStudentDetails.Controls.Add(this.label14);
            this.grpStudentDetails.Controls.Add(this.dtpDOB);
            this.grpStudentDetails.Controls.Add(this.tbGivenName);
            this.grpStudentDetails.Controls.Add(this.cbGender);
            this.grpStudentDetails.Controls.Add(this.label10);
            this.grpStudentDetails.Controls.Add(this.tbSurname);
            this.grpStudentDetails.Controls.Add(this.tbPhone);
            this.grpStudentDetails.Controls.Add(this.label8);
            this.grpStudentDetails.Controls.Add(this.btnUpload);
            this.grpStudentDetails.Controls.Add(this.picImgPath);
            this.grpStudentDetails.Controls.Add(this.label1);
            this.grpStudentDetails.Controls.Add(this.label6);
            this.grpStudentDetails.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpStudentDetails.Location = new System.Drawing.Point(10, 10);
            this.grpStudentDetails.Name = "grpStudentDetails";
            this.grpStudentDetails.Size = new System.Drawing.Size(611, 472);
            this.grpStudentDetails.TabIndex = 0;
            this.grpStudentDetails.TabStop = false;
            this.grpStudentDetails.Text = "Student Details";
            // 
            // tbAddress
            // 
            this.tbAddress.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAddress.Location = new System.Drawing.Point(12, 373);
            this.tbAddress.Multiline = true;
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(586, 75);
            this.tbAddress.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 347);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 23);
            this.label3.TabIndex = 57;
            this.label3.Text = "Address";
            // 
            // tbEmail
            // 
            this.tbEmail.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbEmail.Location = new System.Drawing.Point(12, 299);
            this.tbEmail.Name = "tbEmail";
            this.tbEmail.Size = new System.Drawing.Size(586, 30);
            this.tbEmail.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 23);
            this.label2.TabIndex = 55;
            this.label2.Text = "Email";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(374, 113);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(66, 23);
            this.label13.TabIndex = 54;
            this.label13.Text = "Gender";
            // 
            // tbOtherName
            // 
            this.tbOtherName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOtherName.Location = new System.Drawing.Point(152, 139);
            this.tbOtherName.Name = "tbOtherName";
            this.tbOtherName.Size = new System.Drawing.Size(220, 30);
            this.tbOtherName.TabIndex = 3;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(148, 113);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(124, 23);
            this.label14.TabIndex = 52;
            this.label14.Text = "Other Name(s)";
            // 
            // tbGivenName
            // 
            this.tbGivenName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbGivenName.Location = new System.Drawing.Point(378, 66);
            this.tbGivenName.Name = "tbGivenName";
            this.tbGivenName.Size = new System.Drawing.Size(220, 30);
            this.tbGivenName.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(374, 40);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(105, 23);
            this.label10.TabIndex = 50;
            this.label10.Text = "Given Name";
            // 
            // btnUpload
            // 
            this.btnUpload.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnUpload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Font = new System.Drawing.Font("Segoe UI Semibold", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUpload.Location = new System.Drawing.Point(12, 139);
            this.btnUpload.Margin = new System.Windows.Forms.Padding(0);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(118, 29);
            this.btnUpload.TabIndex = 30;
            this.btnUpload.TabStop = false;
            this.btnUpload.Text = "UPLOAD";
            this.btnUpload.UseVisualStyleBackColor = false;
            this.btnUpload.Click += new System.EventHandler(this.btnUpload_Click);
            // 
            // picImgPath
            // 
            this.picImgPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picImgPath.Location = new System.Drawing.Point(12, 40);
            this.picImgPath.Name = "picImgPath";
            this.picImgPath.Size = new System.Drawing.Size(118, 100);
            this.picImgPath.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picImgPath.TabIndex = 29;
            this.picImgPath.TabStop = false;
            this.picImgPath.DoubleClick += new System.EventHandler(this.picImgPath_DoubleClick);
            // 
            // grpParent
            // 
            this.grpParent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpParent.Controls.Add(this.tbOccupation);
            this.grpParent.Controls.Add(this.chkCloneAdress);
            this.grpParent.Controls.Add(this.tbPAddress);
            this.grpParent.Controls.Add(this.label4);
            this.grpParent.Controls.Add(this.tbPEmail);
            this.grpParent.Controls.Add(this.label5);
            this.grpParent.Controls.Add(this.tbRelation);
            this.grpParent.Controls.Add(this.label11);
            this.grpParent.Controls.Add(this.tbPName);
            this.grpParent.Controls.Add(this.tbPPhone);
            this.grpParent.Controls.Add(this.label12);
            this.grpParent.Controls.Add(this.label15);
            this.grpParent.Controls.Add(this.label16);
            this.grpParent.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpParent.Location = new System.Drawing.Point(637, 10);
            this.grpParent.Name = "grpParent";
            this.grpParent.Size = new System.Drawing.Size(611, 353);
            this.grpParent.TabIndex = 9;
            this.grpParent.TabStop = false;
            this.grpParent.Text = "Parent Details";
            // 
            // tbOccupation
            // 
            this.tbOccupation.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbOccupation.Location = new System.Drawing.Point(12, 140);
            this.tbOccupation.Name = "tbOccupation";
            this.tbOccupation.Size = new System.Drawing.Size(290, 30);
            this.tbOccupation.TabIndex = 12;
            // 
            // chkCloneAdress
            // 
            this.chkCloneAdress.AutoSize = true;
            this.chkCloneAdress.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkCloneAdress.ForeColor = System.Drawing.Color.Gray;
            this.chkCloneAdress.Location = new System.Drawing.Point(471, 244);
            this.chkCloneAdress.Name = "chkCloneAdress";
            this.chkCloneAdress.Size = new System.Drawing.Size(127, 23);
            this.chkCloneAdress.TabIndex = 59;
            this.chkCloneAdress.TabStop = false;
            this.chkCloneAdress.Text = "Just as student";
            this.chkCloneAdress.UseVisualStyleBackColor = true;
            this.chkCloneAdress.CheckedChanged += new System.EventHandler(this.chkCloneAdress_CheckedChanged);
            // 
            // tbPAddress
            // 
            this.tbPAddress.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPAddress.Location = new System.Drawing.Point(12, 270);
            this.tbPAddress.Multiline = true;
            this.tbPAddress.Name = "tbPAddress";
            this.tbPAddress.Size = new System.Drawing.Size(586, 65);
            this.tbPAddress.TabIndex = 15;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(8, 244);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 23);
            this.label4.TabIndex = 57;
            this.label4.Text = "Address";
            // 
            // tbPEmail
            // 
            this.tbPEmail.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPEmail.Location = new System.Drawing.Point(12, 208);
            this.tbPEmail.Name = "tbPEmail";
            this.tbPEmail.Size = new System.Drawing.Size(586, 30);
            this.tbPEmail.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 182);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 23);
            this.label5.TabIndex = 55;
            this.label5.Text = "Email";
            // 
            // tbRelation
            // 
            this.tbRelation.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbRelation.Location = new System.Drawing.Point(378, 66);
            this.tbRelation.Name = "tbRelation";
            this.tbRelation.Size = new System.Drawing.Size(220, 30);
            this.tbRelation.TabIndex = 11;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(374, 40);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 23);
            this.label11.TabIndex = 50;
            this.label11.Text = "Relationship";
            // 
            // tbPName
            // 
            this.tbPName.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPName.Location = new System.Drawing.Point(12, 66);
            this.tbPName.Name = "tbPName";
            this.tbPName.Size = new System.Drawing.Size(360, 30);
            this.tbPName.TabIndex = 10;
            // 
            // tbPPhone
            // 
            this.tbPPhone.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbPPhone.Location = new System.Drawing.Point(308, 140);
            this.tbPPhone.Name = "tbPPhone";
            this.tbPPhone.Size = new System.Drawing.Size(290, 30);
            this.tbPPhone.TabIndex = 13;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(304, 114);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(127, 23);
            this.label12.TabIndex = 38;
            this.label12.Text = "Phone Number";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(8, 40);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 23);
            this.label15.TabIndex = 28;
            this.label15.Text = "Full Name";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(8, 114);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(98, 23);
            this.label16.TabIndex = 35;
            this.label16.Text = "Occupation";
            // 
            // grpAdmission
            // 
            this.grpAdmission.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.grpAdmission.Controls.Add(this.dtpAdmitted);
            this.grpAdmission.Controls.Add(this.label7);
            this.grpAdmission.Controls.Add(this.label9);
            this.grpAdmission.Controls.Add(this.cbColor);
            this.grpAdmission.Controls.Add(this.tbID);
            this.grpAdmission.Controls.Add(this.label19);
            this.grpAdmission.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAdmission.Location = new System.Drawing.Point(637, 369);
            this.grpAdmission.Name = "grpAdmission";
            this.grpAdmission.Size = new System.Drawing.Size(611, 113);
            this.grpAdmission.TabIndex = 16;
            this.grpAdmission.TabStop = false;
            this.grpAdmission.Text = "Admission Details";
            // 
            // dtpAdmitted
            // 
            this.dtpAdmitted.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpAdmitted.Location = new System.Drawing.Point(346, 60);
            this.dtpAdmitted.Name = "dtpAdmitted";
            this.dtpAdmitted.Size = new System.Drawing.Size(252, 30);
            this.dtpAdmitted.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(116, 34);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 23);
            this.label7.TabIndex = 62;
            this.label7.Text = "Colour";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(342, 34);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(122, 23);
            this.label9.TabIndex = 61;
            this.label9.Text = "Date Admitted";
            // 
            // cbColor
            // 
            this.cbColor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbColor.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbColor.FormattingEnabled = true;
            this.cbColor.Items.AddRange(new object[] {
            "--- select ---",
            "Blue",
            "Green",
            "Red",
            "Yellow"});
            this.cbColor.Location = new System.Drawing.Point(120, 60);
            this.cbColor.Name = "cbColor";
            this.cbColor.Size = new System.Drawing.Size(220, 31);
            this.cbColor.TabIndex = 18;
            // 
            // tbID
            // 
            this.tbID.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbID.Location = new System.Drawing.Point(12, 61);
            this.tbID.Name = "tbID";
            this.tbID.Size = new System.Drawing.Size(102, 30);
            this.tbID.TabIndex = 17;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(8, 35);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(42, 23);
            this.label19.TabIndex = 28;
            this.label19.Text = "# ID";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btnSave.Location = new System.Drawing.Point(1114, 502);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(134, 34);
            this.btnSave.TabIndex = 20;
            this.btnSave.Text = "&Save Record";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(6, 508);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(31, 23);
            this.lblStatus.TabIndex = 21;
            this.lblStatus.Text = "Err";
            // 
            // Admit
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.grpAdmission);
            this.Controls.Add(this.grpParent);
            this.Controls.Add(this.grpStudentDetails);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Admit";
            this.Size = new System.Drawing.Size(1265, 557);
            this.Load += new System.EventHandler(this.Admit_Load);
            this.grpStudentDetails.ResumeLayout(false);
            this.grpStudentDetails.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picImgPath)).EndInit();
            this.grpParent.ResumeLayout(false);
            this.grpParent.PerformLayout();
            this.grpAdmission.ResumeLayout(false);
            this.grpAdmission.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox tbSurname;
        private System.Windows.Forms.DateTimePicker dtpDOB;
        private System.Windows.Forms.ComboBox cbGender;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpStudentDetails;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.PictureBox picImgPath;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbOtherName;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbGivenName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbEmail;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox grpParent;
        private System.Windows.Forms.TextBox tbPAddress;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbPEmail;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tbRelation;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbPName;
        private System.Windows.Forms.TextBox tbPPhone;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.CheckBox chkCloneAdress;
        private System.Windows.Forms.GroupBox grpAdmission;
        private System.Windows.Forms.TextBox tbID;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.DateTimePicker dtpAdmitted;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbColor;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tbOccupation;
        private System.Windows.Forms.Label lblStatus;
    }
}

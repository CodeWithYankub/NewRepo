
namespace ControlsLibrary
{
    partial class Dashboard
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chRegistered = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.lvAdmitted = new System.Windows.Forms.ListView();
            this.colYear = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colMale = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colFemale = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lvRegistered = new System.Windows.Forms.ListView();
            this.colRegYear = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label5 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tblFees = new System.Windows.Forms.TableLayoutPanel();
            this.label8 = new System.Windows.Forms.Label();
            this.lbFees = new System.Windows.Forms.Label();
            this.lstYears = new System.Windows.Forms.ListBox();
            this.tblTeachers = new System.Windows.Forms.TableLayoutPanel();
            this.label14 = new System.Windows.Forms.Label();
            this.lbTeachers = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbTeacherFemale = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lbTeacherMale = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tblStudents = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.lbStudents = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbStudentFemale = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.lbStudentsMale = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel4.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chRegistered)).BeginInit();
            this.panel5.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tblFees.SuspendLayout();
            this.tblTeachers.SuspendLayout();
            this.panel3.SuspendLayout();
            this.tblStudents.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel4.ColumnCount = 2;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 68.02426F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 31.97574F));
            this.tableLayoutPanel4.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.panel5, 1, 0);
            this.tableLayoutPanel4.Location = new System.Drawing.Point(17, 174);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 1;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(1154, 366);
            this.tableLayoutPanel4.TabIndex = 5;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.chRegistered);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(778, 360);
            this.panel2.TabIndex = 2;
            // 
            // chRegistered
            // 
            chartArea1.AxisX.MajorGrid.LineColor = System.Drawing.Color.Gray;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.Color.Gray;
            chartArea1.BackColor = System.Drawing.Color.AliceBlue;
            chartArea1.BorderWidth = 0;
            chartArea1.Name = "ChartArea1";
            this.chRegistered.ChartAreas.Add(chartArea1);
            this.chRegistered.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            legend1.TitleFont = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chRegistered.Legends.Add(legend1);
            this.chRegistered.Location = new System.Drawing.Point(0, 23);
            this.chRegistered.Name = "chRegistered";
            this.chRegistered.Size = new System.Drawing.Size(778, 337);
            this.chRegistered.TabIndex = 1;
            this.chRegistered.Text = "chart1";
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(778, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Registered per sector per year";
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.lvAdmitted);
            this.panel5.Controls.Add(this.label2);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel5.Location = new System.Drawing.Point(787, 3);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(364, 360);
            this.panel5.TabIndex = 3;
            // 
            // lvAdmitted
            // 
            this.lvAdmitted.BackColor = System.Drawing.SystemColors.Control;
            this.lvAdmitted.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colYear,
            this.colMale,
            this.colFemale,
            this.colTotal});
            this.lvAdmitted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAdmitted.FullRowSelect = true;
            this.lvAdmitted.HideSelection = false;
            this.lvAdmitted.Location = new System.Drawing.Point(0, 23);
            this.lvAdmitted.Name = "lvAdmitted";
            this.lvAdmitted.Size = new System.Drawing.Size(364, 337);
            this.lvAdmitted.TabIndex = 2;
            this.lvAdmitted.UseCompatibleStateImageBehavior = false;
            this.lvAdmitted.View = System.Windows.Forms.View.Details;
            // 
            // colYear
            // 
            this.colYear.Text = "Year";
            this.colYear.Width = 129;
            // 
            // colMale
            // 
            this.colMale.Text = "Male";
            this.colMale.Width = 86;
            // 
            // colFemale
            // 
            this.colFemale.Text = "Female";
            this.colFemale.Width = 88;
            // 
            // colTotal
            // 
            this.colTotal.Text = "Total";
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(364, 23);
            this.label2.TabIndex = 0;
            this.label2.Text = "Admitted per year";
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.lvRegistered);
            this.panel4.Controls.Add(this.label5);
            this.panel4.Location = new System.Drawing.Point(17, 561);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1154, 215);
            this.panel4.TabIndex = 6;
            // 
            // lvRegistered
            // 
            this.lvRegistered.BackColor = System.Drawing.SystemColors.Control;
            this.lvRegistered.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colRegYear});
            this.lvRegistered.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvRegistered.FullRowSelect = true;
            this.lvRegistered.GridLines = true;
            this.lvRegistered.HideSelection = false;
            this.lvRegistered.Location = new System.Drawing.Point(0, 24);
            this.lvRegistered.Name = "lvRegistered";
            this.lvRegistered.Size = new System.Drawing.Size(1154, 191);
            this.lvRegistered.TabIndex = 3;
            this.lvRegistered.UseCompatibleStateImageBehavior = false;
            this.lvRegistered.View = System.Windows.Forms.View.Details;
            // 
            // colRegYear
            // 
            this.colRegYear.Text = "Year";
            // 
            // label5
            // 
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.RoyalBlue;
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(1154, 24);
            this.label5.TabIndex = 0;
            this.label5.Text = "Registered per class per year";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.58232F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 24.17678F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 43.32756F));
            this.tableLayoutPanel1.Controls.Add(this.tblFees, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tblTeachers, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tblStudents, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(17, 21);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1154, 135);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // tblFees
            // 
            this.tblFees.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblFees.ColumnCount = 2;
            this.tblFees.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.71682F));
            this.tblFees.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 87F));
            this.tblFees.Controls.Add(this.label8, 0, 1);
            this.tblFees.Controls.Add(this.lbFees, 0, 0);
            this.tblFees.Controls.Add(this.lstYears, 1, 0);
            this.tblFees.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblFees.Location = new System.Drawing.Point(656, 3);
            this.tblFees.Name = "tblFees";
            this.tblFees.RowCount = 2;
            this.tblFees.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.59091F));
            this.tblFees.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.40909F));
            this.tblFees.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblFees.Size = new System.Drawing.Size(495, 129);
            this.tblFees.TabIndex = 9;
            // 
            // label8
            // 
            this.label8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(4, 92);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(399, 36);
            this.label8.TabIndex = 2;
            this.label8.Text = "FEES";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbFees
            // 
            this.lbFees.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbFees.Font = new System.Drawing.Font("Segoe UI Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbFees.ForeColor = System.Drawing.Color.Black;
            this.lbFees.Location = new System.Drawing.Point(4, 1);
            this.lbFees.Name = "lbFees";
            this.lbFees.Size = new System.Drawing.Size(399, 90);
            this.lbFees.TabIndex = 1;
            this.lbFees.Text = "Le250000000";
            this.lbFees.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lstYears
            // 
            this.lstYears.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstYears.FormattingEnabled = true;
            this.lstYears.ItemHeight = 23;
            this.lstYears.Location = new System.Drawing.Point(410, 4);
            this.lstYears.Name = "lstYears";
            this.tblFees.SetRowSpan(this.lstYears, 2);
            this.lstYears.Size = new System.Drawing.Size(81, 121);
            this.lstYears.TabIndex = 3;
            this.lstYears.SelectedIndexChanged += new System.EventHandler(this.lstYears_SelectedIndexChanged);
            // 
            // tblTeachers
            // 
            this.tblTeachers.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblTeachers.ColumnCount = 2;
            this.tblTeachers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.71682F));
            this.tblTeachers.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.28318F));
            this.tblTeachers.Controls.Add(this.label14, 0, 1);
            this.tblTeachers.Controls.Add(this.lbTeachers, 0, 0);
            this.tblTeachers.Controls.Add(this.panel3, 1, 0);
            this.tblTeachers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblTeachers.Location = new System.Drawing.Point(378, 3);
            this.tblTeachers.Name = "tblTeachers";
            this.tblTeachers.RowCount = 2;
            this.tblTeachers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.59091F));
            this.tblTeachers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.40909F));
            this.tblTeachers.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblTeachers.Size = new System.Drawing.Size(272, 129);
            this.tblTeachers.TabIndex = 10;
            // 
            // label14
            // 
            this.tblTeachers.SetColumnSpan(this.label14, 2);
            this.label14.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DimGray;
            this.label14.Location = new System.Drawing.Point(4, 92);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(264, 36);
            this.label14.TabIndex = 2;
            this.label14.Text = "TEACHERS";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbTeachers
            // 
            this.lbTeachers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbTeachers.Font = new System.Drawing.Font("Segoe UI Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTeachers.ForeColor = System.Drawing.Color.Black;
            this.lbTeachers.Location = new System.Drawing.Point(4, 1);
            this.lbTeachers.Name = "lbTeachers";
            this.lbTeachers.Size = new System.Drawing.Size(165, 90);
            this.lbTeachers.TabIndex = 1;
            this.lbTeachers.Text = "2000";
            this.lbTeachers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lbTeacherFemale);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.lbTeacherMale);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(173, 1);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(98, 90);
            this.panel3.TabIndex = 3;
            // 
            // lbTeacherFemale
            // 
            this.lbTeacherFemale.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTeacherFemale.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTeacherFemale.Location = new System.Drawing.Point(0, 65);
            this.lbTeacherFemale.Name = "lbTeacherFemale";
            this.lbTeacherFemale.Size = new System.Drawing.Size(98, 27);
            this.lbTeacherFemale.TabIndex = 3;
            this.lbTeacherFemale.Text = "MALE";
            // 
            // label17
            // 
            this.label17.Dock = System.Windows.Forms.DockStyle.Top;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label17.Location = new System.Drawing.Point(0, 46);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(98, 19);
            this.label17.TabIndex = 2;
            this.label17.Text = "FEMALE";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbTeacherMale
            // 
            this.lbTeacherMale.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbTeacherMale.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTeacherMale.Location = new System.Drawing.Point(0, 19);
            this.lbTeacherMale.Name = "lbTeacherMale";
            this.lbTeacherMale.Size = new System.Drawing.Size(98, 27);
            this.lbTeacherMale.TabIndex = 1;
            this.lbTeacherMale.Text = "MALE";
            // 
            // label19
            // 
            this.label19.Dock = System.Windows.Forms.DockStyle.Top;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label19.Location = new System.Drawing.Point(0, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(98, 19);
            this.label19.TabIndex = 0;
            this.label19.Text = "MALE";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tblStudents
            // 
            this.tblStudents.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.tblStudents.ColumnCount = 2;
            this.tblStudents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 63.71682F));
            this.tblStudents.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 36.28318F));
            this.tblStudents.Controls.Add(this.label3, 0, 1);
            this.tblStudents.Controls.Add(this.lbStudents, 0, 0);
            this.tblStudents.Controls.Add(this.panel1, 1, 0);
            this.tblStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblStudents.Location = new System.Drawing.Point(3, 3);
            this.tblStudents.Name = "tblStudents";
            this.tblStudents.RowCount = 2;
            this.tblStudents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 71.59091F));
            this.tblStudents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 28.40909F));
            this.tblStudents.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblStudents.Size = new System.Drawing.Size(369, 129);
            this.tblStudents.TabIndex = 8;
            // 
            // label3
            // 
            this.tblStudents.SetColumnSpan(this.label3, 2);
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.DimGray;
            this.label3.Location = new System.Drawing.Point(4, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(361, 36);
            this.label3.TabIndex = 2;
            this.label3.Text = "STUDENTS";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbStudents
            // 
            this.lbStudents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbStudents.Font = new System.Drawing.Font("Segoe UI Black", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStudents.ForeColor = System.Drawing.Color.Black;
            this.lbStudents.Location = new System.Drawing.Point(4, 1);
            this.lbStudents.Name = "lbStudents";
            this.lbStudents.Size = new System.Drawing.Size(227, 90);
            this.lbStudents.TabIndex = 1;
            this.lbStudents.Text = "2000";
            this.lbStudents.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbStudentFemale);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.lbStudentsMale);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(235, 1);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(133, 90);
            this.panel1.TabIndex = 3;
            // 
            // lbStudentFemale
            // 
            this.lbStudentFemale.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbStudentFemale.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStudentFemale.Location = new System.Drawing.Point(0, 65);
            this.lbStudentFemale.Name = "lbStudentFemale";
            this.lbStudentFemale.Size = new System.Drawing.Size(133, 27);
            this.lbStudentFemale.TabIndex = 3;
            this.lbStudentFemale.Text = "MALE";
            // 
            // label6
            // 
            this.label6.Dock = System.Windows.Forms.DockStyle.Top;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label6.Location = new System.Drawing.Point(0, 46);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 19);
            this.label6.TabIndex = 2;
            this.label6.Text = "FEMALE";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbStudentsMale
            // 
            this.lbStudentsMale.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbStudentsMale.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbStudentsMale.Location = new System.Drawing.Point(0, 19);
            this.lbStudentsMale.Name = "lbStudentsMale";
            this.lbStudentsMale.Size = new System.Drawing.Size(133, 27);
            this.lbStudentsMale.TabIndex = 1;
            this.lbStudentsMale.Text = "MALE";
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Dock = System.Windows.Forms.DockStyle.Top;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.DodgerBlue;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(133, 19);
            this.label4.TabIndex = 0;
            this.label4.Text = "MALE";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Dashboard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.tableLayoutPanel4);
            this.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Dashboard";
            this.Size = new System.Drawing.Size(1188, 795);
            this.Load += new System.EventHandler(this.Dashboard_Load);
            this.SizeChanged += new System.EventHandler(this.Dashboard_SizeChanged);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.chRegistered)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tblFees.ResumeLayout(false);
            this.tblTeachers.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.tblStudents.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tblFees;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TableLayoutPanel tblTeachers;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label lbTeachers;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbTeacherFemale;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbTeacherMale;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TableLayoutPanel tblStudents;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbStudents;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbStudentFemale;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbStudentsMale;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbFees;
        private System.Windows.Forms.ListBox lstYears;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chRegistered;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.ListView lvAdmitted;
        private System.Windows.Forms.ColumnHeader colYear;
        private System.Windows.Forms.ColumnHeader colMale;
        private System.Windows.Forms.ColumnHeader colFemale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvRegistered;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ColumnHeader colRegYear;
        private System.Windows.Forms.ColumnHeader colTotal;
    }
}

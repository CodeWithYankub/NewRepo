using ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlsLibrary.Grades
{
    public partial class ReportCard : UserControl
    {
        private Registration Registration { get; set; }
        public ReportCard(int id)
        {
            InitializeComponent();

            Registration = new Registration().Read(id);
        }

        #region Custom Functions
        private Label GetLabel(string text, bool left = false)
        {
            var align = left ? ContentAlignment.MiddleLeft : ContentAlignment.MiddleCenter;

            Label lbl = new Label()
            {
                Text = text,
                Dock = DockStyle.Fill,
                AutoSize = false,
                TextAlign = align
            };

            try
            {
                double val = Math.Round(Convert.ToDouble(text));
                lbl.ForeColor = val >= 50.00 ? Color.Blue : Color.Red;
                lbl.Font = new Font("Segoe Script", 10);
            }
            catch
            {

            }

            return lbl;
        }

        private int AddRows(TableLayoutPanel tbl=null)
        {
            tbl = tbl == null ? tblResult : tbl;

            var rowCounts = tbl.RowCount;
            var lastRow = tbl.RowStyles[rowCounts - 1];

            tbl.RowCount++;
            tbl.RowStyles.Add(new RowStyle(lastRow.SizeType, lastRow.Height));

            panResult.Height += 8;
            ParentForm.Height += 8;

            return tbl.RowCount - 1;
        }

        private void AddControl(Label lbl, int col, int row, TableLayoutPanel tbl)
        {
            tbl = tbl == null ? tblResult : tbl;
            tbl.Controls.Add(lbl, col, row);
        }

        private Dictionary<int, string> AddToSubjects(Dictionary<int, string> values, int key, string value)
        {
            if (values.ContainsKey(key))
                values[key] += string.Format(",{0}", value);
            else
                values.Add(key, value);

            return values;
        }

        private Dictionary<int, string> PopulateScore(List<Grade> grades, List<StudentSubject> subs)
        {
            var subjectScores = new Dictionary<int, string>();

            for (int exam = 0; exam < 2; exam++)
            {
                var examGrade = grades.Find(g => g.Exam.Equals(exam + 1));
                var scores = new List<GradeSubject>();

                if (examGrade != null)
                {
                    scores = new GradeSubject().Read(examGrade);

                    foreach (GradeSubject score in scores)
                    {
                        AddToSubjects(subjectScores, score.SubjectId, score.Score.ToString());
                    }
                }
                else
                {
                    foreach (var sub in subs)
                    {
                        AddToSubjects(subjectScores, sub.SubjectId, "0");
                    }
                }
            }

            return subjectScores;
        }

        private Dictionary<int, Dictionary<int,string>> GetScores(List<StudentSubject> subs)
        {
            var termSubjects = new Dictionary<int, Dictionary<int, string>>();
            var grades = new Grade().Read().FindAll(g => g.RegistrationId.Equals(Registration.ID));

            for (int term = 0; term < 3; term++)
            {
                var termGrades = grades.FindAll(g => g.Term.Equals(term + 1));
                var subjectScores = PopulateScore(termGrades, subs);

                termSubjects.Add(term + 1, subjectScores);
            }

            return termSubjects;
        }

        private void AddColumn(string text, int col, int row, TableLayoutPanel tbl = null)
        {
            AddControl(GetLabel(text, col < 1), col, row, tbl);
        }

        private void SetAffectPsycho(int count)
        {
            for (int row = 0; row < count + 2; row++)
            {
                int r = AddRows(tblAffect);
                int s = AddRows(tblPsycho);
                for (int col = 0; col < 10; col++)
                {
                    AddColumn(string.Empty, col, r, tblAffect);
                    AddColumn(string.Empty, col, s, tblPsycho);
                }
            }
        }

        private void FetchData()
        {
            int col = 0;
            var subjects = new StudentSubject().Read(Registration.ID);
            Dictionary<int, Dictionary<int, string>> scores = GetScores(subjects);

            // add rows
            foreach (StudentSubject sub in subjects)
            {
                int row = AddRows();
                Subject subject = new Subject().Read(sub.SubjectId);

                AddColumn(subject.Name, 0, row);
            }

            // add scores by term
            foreach(int key in scores.Keys)
            {
                int row = 2;
                var subs = scores[key];

                foreach (string value in subs.Values)
                {
                    var arr = value.Split(',');
                    int t1 = Convert.ToInt32(arr[0]);
                    int t2 = Convert.ToInt32(arr[1]);
                    double mn = Math.Ceiling((double)(t1 + t2) / 2);
                    AddColumn(t1.ToString(), col + 1, row);
                    AddColumn(t2.ToString(), col + 2, row);
                    AddColumn(mn.ToString(), col + 3, row);

                    row += 1;
                }
                col += 3;
            }

            // add annuals
            for (int i = 0; i < subjects.Count; i++)
            {
                Control ctrl1 = tblResult.GetControlFromPosition(3, i + 2);
                Control ctrl2 = tblResult.GetControlFromPosition(6, i + 2);
                Control ctrl3 = tblResult.GetControlFromPosition(9, i + 2);

                int t1 = Convert.ToInt32(ctrl1.Text);
                int t2 = Convert.ToInt32(ctrl2.Text);
                int t3 = Convert.ToInt32(ctrl3.Text);
                double mn = Math.Round((double)(t1 + t2 + t3) / 3);
                AddColumn(mn.ToString(), 10, i + 2);
            }

            // add total and average
            for (int i= 0; i < 2; i++)
            {
                int row = AddRows();

                if (i < 1)
                {
                    int c = 3;
                    AddColumn("Total", 0, row);

                    for(int j = 0; j < 4; j++)
                    {
                        int total = 0;

                        for (int x = 0; x < subjects.Count; x++)
                        {
                            var c1 = tblResult.GetControlFromPosition(c, x + 2);
                            total += Convert.ToInt32(c1.Text);
                        }

                        AddColumn(total.ToString(), c, row);
                        c += j < 2 ? 3 : 1;
                    }
                }
                else
                {
                    int c = 3;
                    AddColumn("Average", 0, row);

                    for (int j = 0; j < 4; j++)
                    {
                        var c1 = tblResult.GetControlFromPosition(c, row - 1);
                        double average = (Convert.ToDouble(c1.Text) / subjects.Count);

                        AddColumn(average.ToString("N1"), c, row);
                        c += j < 2 ? 3 : 1;
                    }
                }
            }

            SetAffectPsycho(subjects.Count);
        }
        #endregion

        private void panFrame_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ReportCard_Load(object sender, EventArgs e)
        {
            FetchData();

            Student student = new Student().Read(Registration.StudentId);
            string year = new Year().Read(Registration.YearId).Period;
            string age = (DateTime.Now.Year - student.DateOfBirth.Year).ToString();
            string name = string.Format("{0} {1} {2}", student.LastName, student.FirstName, student.OtherName);
            string total = new Registration().Read().FindAll(reg => reg.StreamId.Equals(Registration.StreamId) && reg.YearId.Equals(Registration.YearId)).Count.ToString();

            lblName.Text = string.Format("Pupil's Name: {0}", name);
            lblYear.Text = string.Format("Academic Year: {0}", year);
            lblNoForm.Text = string.Format("No. in Form: {0}", total);
            lblAge.Text = string.Format("Pupil's Age: {0} years", age);
        }

        private void panCognitive_Paint(object sender, PaintEventArgs e)
        {

        }

        private void contxBtnPrint_Click(object sender, EventArgs e)
        {
            Printer.Print(this);
        }

        private void contxBtnClose_Click(object sender, EventArgs e)
        {
            ParentForm.Close();
        }
    }
}

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
    public partial class Add : UserControl
    {
        private Grade Grade { get; set; }
        private App.Action Action { get; set; }
        private Registration Registration { get; set; }
        private Dictionary<string, int> Years { get; set; }

        public Add(int id = 0)
        {
            InitializeComponent();

            panSubjects.AutoScroll = true;
            Registration = new Registration();
            Years = new Dictionary<string, int>();

            if (id > 0)
            {
                Action = App.Action.Edit;
                Grade = new Grade().Read(id);
            }
        }

        #region Custom Functions
        private void FetchAcademics()
        {
            List<Year> years = new Year().Read();

            if (cbYear.Items.Count > 0)
                cbYear.Items.Clear();
            cbYear.Items.Add("--- select ---");

            foreach (Year year in years)
            {
                cbYear.Items.Add(year.Period);
                Years.Add(year.Period, year.ID);
            }
            cbYear.SelectedIndex = 0;
        }

        private void Number_Only(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar));
        }

        private void FetchSubjects(int id, Dictionary<int, int> scores = null)
        {
            var subjects = new StudentSubject().Read(id);
            int index = subjects.Count;

            if (panSubjects.Controls.Count > 0)
                panSubjects.Controls.Clear();

            foreach (StudentSubject subject in subjects)
            {
                int score = scores != null ? scores[subject.SubjectId] : 0;
                GradeSubjectAdd grade = new GradeSubjectAdd(subject.SubjectId, score)
                {
                    Dock = DockStyle.Top,
                    TabIndex = index - 1
                };
                panSubjects.Controls.Add(grade);

                if (index.Equals(0))
                    grade.Focus();

                index -= 1;
            }
        }

        private void PopulateSubjects(int studentId, int year)
        {
            var regs = new Registration().Read();

            foreach (Registration reg in regs)
            {
                if (reg.StudentId.Equals(studentId) && reg.YearId.Equals(year))
                {
                    Registration = reg;
                    FetchSubjects(Registration.ID);
                    break;
                }
            }
        }

        private void Field_Changed(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbStudentId.Text) && cbYear.SelectedIndex > 0)
            {
                PopulateSubjects(Convert.ToInt32(tbStudentId.Text), Years[cbYear.Text]);
            }
        }

        private void SaveSubjects(int id, bool update = false)
        {
            var subjectsAdded = true;

            foreach (Control ctrl in panSubjects.Controls)
            {
                GradeSubjectAdd gradeSubjectAdd = (GradeSubjectAdd)ctrl;

                var saved = gradeSubjectAdd.Save(id);
                if (!saved)
                {
                    subjectsAdded = false;
                    break;
                }
            }

            if (!subjectsAdded && !update)
            {
                var deleted = new Grade().Delete(id);
                Helper.ShowMessage(lbStatus, App.Error);
            }
            else
            {
                ParentForm.DialogResult = DialogResult.OK;
            }
        }

        private void GetGrades(decimal term, decimal exam)
        {
            int t = Convert.ToInt32(term);
            int e = Convert.ToInt32(exam);
            Dictionary<int, int> scores = new Dictionary<int, int>();
            var grades = new Grade().Read().Where(g => g.RegistrationId.Equals(Registration.ID) && g.Term.Equals(t) && g.Exam.Equals(e)).ToList();

            if (grades.Count > 0)
            {
                foreach (Grade grade in grades)
                {
                    var gs = new GradeSubject().Read(grade);

                    foreach (var g in gs)
                    {
                        scores.Add(g.SubjectId, g.Score);
                    }

                }
            }
            else
                scores = null;

            FetchSubjects(Registration.ID, scores);
        }

        #endregion

        private void Add_Load(object sender, EventArgs e)
        {
            FetchAcademics();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            var isValid = Helper.FieldsCompleted(this);

            if (isValid)
            {
                Grade grade = new Grade()
                {
                    RegistrationId = Registration.ID,
                    Term = Convert.ToInt32(nupTerm.Value),
                    Exam = Convert.ToInt32(nupExam.Value),
                };

                if (!grade.Exists())
                {
                    var created = grade.Create();

                    if (created > 0)
                        SaveSubjects(created);
                    else
                        Helper.ShowMessage(lbStatus, App.Error);
                }
                else
                {
                    var updated = grade.Update(grade.ID);

                    if (updated)
                        SaveSubjects(grade.ID, true);
                    else
                        Helper.ShowMessage(lbStatus, App.Error);
                }
            }
            else
            {
                Helper.ShowMessage(lbStatus, "Required fields not cupplied");
            }
        }

        private void nupTerm_ValueChanged(object sender, EventArgs e)
        {
            GetGrades(nupTerm.Value, nupExam.Value);
        }

        private void nupExam_ValueChanged(object sender, EventArgs e)
        {
            GetGrades(nupTerm.Value, nupExam.Value);
        }
    }
}

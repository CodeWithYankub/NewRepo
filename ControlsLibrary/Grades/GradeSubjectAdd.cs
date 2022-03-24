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
    public partial class GradeSubjectAdd : UserControl
    {
        private int Score { get; set; }
        private Subject subject { get; set; }
        public GradeSubjectAdd()
        {
            InitializeComponent();
        }

        public GradeSubjectAdd(int subjectId, int score)
        {
            InitializeComponent();

            subject = new Subject().Read(subjectId);
            Score = score;
        }

        private void tbScore_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar));
        }

        private void GradeSubject_Load(object sender, EventArgs e)
        {
            if (subject != null)
                lbSubject.Text = subject.Name;

            tbScore.Text = Score.ToString();
        }

        public bool Save(int gradeId)
        {
            var isValid = Helper.FieldsCompleted(this);

            if (isValid)
            {
                GradeSubject gradeSubject = new GradeSubject()
                {
                    GradeId = gradeId,
                    SubjectId = subject.ID,
                    Score = Convert.ToInt32(tbScore.Text)
                };

                if (gradeSubject.Exists())
                {
                    return gradeSubject.Update(gradeSubject.ID);
                }
                else
                {
                     return gradeSubject.Create();
                }
            }
            else
            {
                App.Error = "Subject score required";
            }

            return isValid;
        }
    }
}

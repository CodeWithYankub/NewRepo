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
    public partial class Index : UserControl
    {
        private int Selected { get; set; }
        private Dictionary<int, int> Virtual { get; set; }
        public Index()
        {
            InitializeComponent();

            Virtual = new Dictionary<int, int>();
        }

        #region Custom Functions

        private double GetAverage(Dictionary<int, Dictionary<int,int>> scores)
        {
            double mean = 0.00;

            foreach (int key in scores.Keys)
            {
                var score = scores[key];
                double total = 0;

                foreach(int value in score.Values)
                {
                    double min = value > 0 ? (value / 2.00) : value;
                    total += Math.Ceiling(min);
                }

                mean += total > 0 ? (total / score.Count) : total;
            }
            return (mean / scores.Count);
        }
        
        private void FetchData()
        {
            int index = 1;
            var regs = new Registration().Read();

            if (lstData.Items.Count > 0)
            {
                Virtual.Clear();
                lstData.Items.Clear();
            }

            foreach(Registration reg in regs)
            {
                Dictionary<int, Dictionary<int, int>> Scores = new Dictionary<int, Dictionary<int, int>>();
                var student = new Student().Read(reg.StudentId);
                var stream = new Stream().Read(reg.StreamId);
                var clas = new Class().Read(stream.ClassId);
                var faculty = new Faculty().Read(clas.FacultyId);
                var level = new Level().Read(clas.LevelId);
                var sector = new Sector().Read(clas.SectorId);
                var year = new Year().Read(reg.YearId);
                var grades = new Grade().Read().FindAll(g => g.RegistrationId.Equals(reg.ID));

                if (grades.Count > 0)
                {
                    for (int term = 0; term < 3; term++)
                    {
                        var termly = grades.FindAll(g => g.Term.Equals(term + 1));
                        //int[] scores = new int[15];
                        Dictionary<int, int> scores = new Dictionary<int, int>();


                        if (termly.Count > 0)
                        {
                            for (int exam = 0; exam < 2; exam++)
                            {
                                var grade = termly.Find(g => g.Exam.Equals(exam + 1));
                                var subs = new List<GradeSubject>();

                                if (grade != null)
                                    subs = new GradeSubject().Read(grade);

                                for (int i = 0; i < subs.Count; i++)
                                {
                                    var got = subs[i];

                                    if (!scores.ContainsKey(got.SubjectId))
                                    {
                                        scores.Add(got.SubjectId, got.Score);
                                    }
                                    else
                                    {
                                        scores[got.SubjectId] += got.Score;
                                    }
                                }
                            }
                            
                            Scores.Add(term + 1, scores);
                        }
                    }
                }

                var average = GetAverage(Scores);

                string[] arr = new string[]
                {
                    index.ToString(),
                    student.ID.ToString(),
                    string.Format("{0} {1} {2}",student.LastName,student.FirstName,student.OtherName),
                    string.Format("{0} {1}{2}{3}",sector.Acronym,level.Class,sector.Acronym.StartsWith("S") ? faculty.Acronym : "",stream.Description),
                    year.Period,
                    average.ToString("N2"),
                    average>=50.00 ? "Promoted" : "Repeated"
                };

                if (grades.Count > 0)
                {
                    lstData.Items.Add(new ListViewItem(arr));
                    Virtual.Add(index, reg.ID);

                    index += 1;
                }
            }
        }
        
        private void AddNew_Clicked(object sender, EventArgs e)
        {
            Common common = new Common();
            if (sender is Button)
                common.AddControl("Admit Student", new Add());
            else
                common.AddControl("Edit Student", new Add(Selected));

            var completed = common.ShowDialog().Equals(DialogResult.OK);

            if (completed)
                FetchData();
        }
        #endregion

        private void Index_Load(object sender, EventArgs e)
        {
            FetchData();
        }

        private void Index_SizeChanged(object sender, EventArgs e)
        {
            Helper.Resize(lstData);
        }

        private void btnContxGenRes_Click(object sender, EventArgs e)
        {
            Common common = new Common();
            common.AddControl("Student Result", new ReportCard(Selected));
            common.ShowDialog();
        }

        private void lstData_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
                Selected = Virtual[Convert.ToInt32(e.Item.Text)];
            else
                Selected = 0;
        }

        private void btnContxDelete_Click(object sender, EventArgs e)
        {
            var grades = new Grade().Read().Where(g => g.RegistrationId.Equals(Selected)).ToList();

            if (grades.Count > 0)
            {
                DialogResult question = MessageBox.Show("Are you sure to delete this data?", "Delete Grading", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (question.Equals(DialogResult.Yes))
                {
                    foreach(var grade in grades)
                    {
                        grade.Delete(grade.ID);
                    }
                }
            }

            FetchData();
        }

        private void btnContxRefresh_Click(object sender, EventArgs e)
        {
            FetchData();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            bool printed = Printer.Print(lstData, "Students");

            if (printed)
            {
                MessageBox.Show("Document Exported Successfully", "Exported", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

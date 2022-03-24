using ClassLibrary;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ControlsLibrary
{
    public partial class Dashboard : UserControl
    {

        Dictionary<string, Series> seriess { get; set; }
        public Dashboard()
        {
            InitializeComponent();

            seriess = new Dictionary<string, Series>();
        }

        #region Custom Function
        private void FetchStudents()
        {
            List<Student> students = new Student().Read();
            int total = 0, male = 0, female = 0;

            /* Assign values */
            {
                total = students.Count;
                male = students.FindAll(student => student.Gender.Equals(App.Gender.Male)).Count;
                female = students.FindAll(student => student.Gender.Equals(App.Gender.Female)).Count;
            }

            lbStudents.Text = total.ToString("#,##0");
            lbStudentsMale.Text = male.ToString("#,##0");
            lbStudentFemale.Text = female.ToString("#,##0");
        }
        //fetch teacher
        private void FetchTeachers()
        {
            List<Teacher> teachers = new Teacher().Read();
            int total = 0, male = 0, female = 0;

            /* Assign values */
            {
                total = teachers.Count;
                male = teachers.FindAll(teacher => teacher.Gender.Equals(App.Gender.Male)).Count;
                female = teachers.FindAll(teacher => teacher.Gender.Equals(App.Gender.Female)).Count;
            }

            lbTeachers.Text = total.ToString("#,##0");
            lbTeacherMale.Text = male.ToString("#,##0");
            lbTeacherFemale.Text = female.ToString("#,##0");
        }
        // fetch fees
        private void FetchFees(List<Fee> fees = null)
        {
            fees = fees != null ? fees : new Fee().Read();
            decimal total = 0;

            foreach(Fee fee in fees)
            {
                total += fee.Amount;
            }

            lbFees.Text = total > 0 ? string.Format("Le{0:#,##0}", total) : "Free Education";
        }
        //fetch Adimited student
        private void FetchAdmitted()
        {
            List<Year> years = new Year().Read();
            List<Student> students = new Student().Read();

            if (lvAdmitted.Items.Count > 0)
                lvAdmitted.Items.Clear();

            foreach(Year year in years)
            {
                int male = 0, female = 0, total = 0;
                var studs = students.FindAll(stud => stud.YearId.Equals(year.ID));

                foreach(Student student in studs)
                {
                    if (student.Gender.Equals(App.Gender.Male))
                        male += 1;
                    else
                        female += 1;
                    total = male + female;
                }

                string[] arr = new string[]
                {
                    string.Format("{0}/{1}",year.Start,year.End),
                    male.ToString("#,##0"),
                    female.ToString("#,##0"),
                    total.ToString("#,##0")
                };

                lvAdmitted.Items.Add(new ListViewItem(arr));
            }
        }
        //Adding information to chartype
        private Series AddSeries(string title)
        {
            Series series = new Series()
            {
                Name = title,
                ChartType = SeriesChartType.Spline,
                ChartArea = chRegistered.ChartAreas[0].Name,
                BorderWidth = 2
            };

            try
            {
                if (!seriess.ContainsKey(title))
                {
                    seriess.Add(series.Name, series);
                    chRegistered.Series.Add(series);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return series;
        }
        // populating a chart
        private void PopulateChart()
        {
            var years = new Year().Read();
            var classes = new Class().Read();
            var sectors = new Sector().Read();

            if (chRegistered.Series.Count > 0)
            { 
                seriess.Clear();
                chRegistered.Series.Clear();
            }

            foreach(Sector sector in sectors)
            {
                var series = AddSeries(sector.Acronym);
                var classs = classes.FindAll(cls => cls.SectorId.Equals(sector.ID));


                foreach (Year year in years)
                {
                    int registered = 0;

                    foreach (Class clas in classs)
                    {
                        var streams = new Stream().Read().FindAll(stream => stream.ClassId.Equals(clas.ID));

                        foreach (Stream stream in streams)
                        {
                            registered += new Registration().Read().FindAll(reg => reg.YearId.Equals(year.ID) && reg.StreamId.Equals(stream.ID)).Count;
                        }
                    }
                    DataPoint dp = new DataPoint();
                    dp.SetValueXY(year.Period, registered);
                    dp.ToolTip = string.Format("{0}: {1:#,##0}", sector.Acronym, registered);
                    series.Points.Add(dp);
                }
            }

            chRegistered.Invalidate();
        }
        // fetch years
        private void FetchYears()
        {
            var years = new Year().Read();

            if (lstYears.Items.Count > 0)
                lstYears.Items.Clear();

            lstYears.Items.Add("All");

            foreach(Year year in years)
            {
                lstYears.Items.Add(year.Period);
            }

            lstYears.SelectedIndex = 0;
        }
        // 
        private void AddTableCols(List<Level> levels)
        {
            foreach (Level level in levels)
            {
                var sector = new Sector().Read(level.SectorId);
                var name = string.Format("{0} {1}", sector.Acronym, level.Class);

                lvRegistered.Columns.Add(name);
            }
        }

        private void FetchClassRegistered()
        {
            var years = new Year().Read();
            var levels = new Level().Read();
            string[] arr = new string[levels.Count + 1];

            AddTableCols(levels);

            foreach (Year year in years)
            {
                int index = 0;
                arr[index] = year.Period;

                foreach(Level level in levels)
                {
                    int registered = 0;
                    var classes = new Class().Read().FindAll(clas => clas.LevelId.Equals(level.ID));

                    foreach(Class clas in classes)
                    {
                        
                        var streams = new Stream().Read().FindAll(strm => strm.ClassId.Equals(clas.ID));

                        foreach(Stream stream in streams)
                        {
                            registered += new Registration().Read().FindAll(reg => reg.YearId.Equals(year.ID) && reg.StreamId.Equals(stream.ID)).Count;
                        }
                    }

                    index += 1;
                    arr[index] = registered.ToString();
                }

                lvRegistered.Items.Add(new ListViewItem(arr));
            }
        }

        #endregion

        private void Dashboard_Load(object sender, EventArgs e)
        {
            /* Get counts */
            {
                FetchStudents();
                FetchTeachers();
                FetchFees();
                FetchYears();
                FetchAdmitted();
                FetchClassRegistered();
                PopulateChart();
            }

            chRegistered.ChartAreas[0].AxisY.Minimum = 0;
            chRegistered.ChartAreas[0].AxisY.Interval = 1;

        }

        private void Dashboard_SizeChanged(object sender, EventArgs e)
        {
            Helper.Resize(lvAdmitted);
            Helper.Resize(lvRegistered);
        }

        private void lstYears_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(lstYears.Text))
            {
                var year = new Year().Read().Find(yr => yr.Period.Equals(lstYears.Text));
                var fees = new Fee().Read();

                if (!lstYears.Text.Equals("All"))
                    fees = fees.FindAll(fee => fee.YearId.Equals(year.ID));

                FetchFees(fees);
            }
        }

    }
}

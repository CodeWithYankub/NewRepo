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

namespace ControlsLibrary.Registrations
{
    public partial class Add : UserControl
    {
        private App.Action Action { get; set; }
        private Registration Registration { get; set; }
        private Dictionary<string,int> Years { get; set; }
        private Dictionary<string,int> Forms { get; set; }
        private Dictionary<string, int> Subjects { get; set; }

        public Add(App.Action action = App.Action.Create,int id=0)
        {
            InitializeComponent();

            Action = action;
            Years = new Dictionary<string, int>();
            Forms = new Dictionary<string, int>();
            Subjects = new Dictionary<string, int>();

            if (id > 0)
                Registration = new Registration().Read(id);
        }

        #region Functions
        private void FetchYears()
        {
            List<Year> years = new Year().Read();

            if (cbYear.Items.Count > 0)
                cbYear.Items.Clear();

            cbYear.Items.Add("--- select ---");
            Years.Clear();

            foreach(Year year in years)
            {
                cbYear.Items.Add(year.Period);
                Years.Add(year.Period, year.ID);
            }

            cbYear.SelectedIndex = 0;
        }

        private void FetchForms()
        {
            List<Stream> streams = new Stream().Read();

            if (cbYear.Items.Count > 0)
                cbForm.Items.Clear();

            cbForm.Items.Add("--- select ---");
            Forms.Clear();

            foreach (Stream stream in streams)
            {
                Class classe = new Class().Read(stream.ClassId);
                Sector sector = new Sector().Read(classe.SectorId);
                Faculty faculty = new Faculty().Read(classe.FacultyId);
                Level level = new Level().Read(classe.LevelId);

                string form = string.Format("{0} {1}{2}{3}", sector.Acronym, level.Class, sector.Acronym.Contains("J") ? "" : faculty.Acronym + " ", stream.Description);

                cbForm.Items.Add(form);
                Forms.Add(form, stream.ID);
            }

            cbForm.SelectedIndex = 0;
        }
        private CheckBox GetCheckBox(Subject subject, FacultySubject facultySubject)
        {
            StudentSubject studentSubject = null;

            if (Registration != null)
            {
                studentSubject = new StudentSubject().Read(Registration.ID).Find(ss => ss.SubjectId.Equals(subject.ID));
            }

            CheckBox chb = new CheckBox()
            {
                Text = subject.Name,
                Cursor = Cursors.Hand,
                Checked = facultySubject.Core || studentSubject != null,
                Enabled = !facultySubject.Core,
                AutoSize = true
            };

            return chb;
        }
        private void FetchSubjects(int id)
        {
            Stream stream = new Stream().Read(id);
            Class clas = new Class().Read(stream.ClassId);
            List<FacultySubject> facultySubjects = new FacultySubject().Read(clas.FacultyId);

            if (flpSubjects.Controls.Count > 0)
            {
                flpSubjects.Controls.Clear();
                Subjects.Clear();
            }

            foreach (FacultySubject facultySubject in facultySubjects)
            {
                Subject subject = new Subject().Read(facultySubject.SubjectId);
                CheckBox chb = GetCheckBox(subject, facultySubject);

                flpSubjects.Controls.Add(chb);
                ttTitle.SetToolTip(cbForm, subject.Name);
                Subjects.Add(subject.Name, subject.ID);

            }
        }

        void Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar));
        }

        private bool SaveSubjects(int id)
        {
            var completed = true;
            var subjects = new StudentSubject().Read(id);
            List<CheckBox> checkedBoxes = flpSubjects.Controls.Cast<CheckBox>().ToList().FindAll(chb => chb.Checked.Equals(true));

            // check for existing subjects
            if (subjects.Count > 0)
            {
                // loop through subjects and delete
                foreach (StudentSubject subject in subjects)
                {
                    subject.Delete(subject.ID);
                }
            }

            completed = checkedBoxes.Count > 7;

            if (completed)
            {
                foreach (CheckBox cb in checkedBoxes)
                {
                    StudentSubject studentSubject = new StudentSubject()
                    {
                        RegistrationId = id,
                        SubjectId = Subjects[cb.Text]
                    };

                    if (studentSubject.Exists())
                    {
                        var updated = studentSubject.Update(studentSubject.ID);

                        if(!updated)
                        {
                            completed = false;
                            break;
                        }
                    }
                    else
                    {
                        var created = studentSubject.Create();

                        if (!created)
                        {
                            MessageBox.Show(App.Error);
                            completed = false;
                            break;
                        }
                    }
                }
            }

            return completed;
        }
        #endregion

        private void btnSave_Click(object sender, EventArgs e)
        {
            var completed = Helper.FieldsCompleted(this);

            if (completed)
            {
                Registration registration = new Registration()
                {
                    FeeId = Convert.ToInt32(tbReceiptNo.Text),
                    StudentId = Convert.ToInt32(tbStudentID.Text),
                    StreamId = Forms[cbForm.Text],
                    YearId = Years[cbYear.Text]
                };

                if(new Student().Exists(registration.StudentId))
                {
                    var isValidFee = new Fee().Read(registration.FeeId) != null;

                    if (isValidFee)
                    {
                        var feeMatchStudent = new Fee().Read(registration.FeeId).StudentId.Equals(registration.StudentId);

                        if (feeMatchStudent)
                        {
                            var feeMatchYear = new Fee().Read(registration.FeeId).YearId.Equals(Years[cbYear.Text]);

                            if (feeMatchYear)
                            {
                                if (Action.Equals(App.Action.Create))
                                    Create(registration);
                                else
                                    Update(registration);
                            }
                            else
                            {
                                Helper.ShowMessage(lbError, "Fee year not valid for registration");
                            }

                        }
                        else
                        {
                            Helper.ShowMessage(lbError, "Fee does not match this student");
                        }
                    }
                    else
                    {
                        Helper.ShowMessage(lbError, "Invalid receipt number");
                    }
                }
                else
                {
                    Helper.ShowMessage(lbError, "Invalid student Id");
                }
            }
            else
            {
                Helper.ShowMessage(lbError, "Required fields cannot be empty");
            }
        }

        void doUpdates(Registration registration)
        {
            var updated = registration.Update(Registration.ID);

            if (updated)
                ParentForm.DialogResult = DialogResult.OK;
            else
                Helper.ShowMessage(lbError, App.Error);
        }

        private void Update(Registration registration)
        {
            if (!registration.Exists())
            {
                var updated = registration.Update(Registration.ID);

                if (updated)
                {
                    var updateSubjects = SaveSubjects(Registration.ID);

                    if (updateSubjects)
                    {
                        Helper.ClearFields(this);
                        Helper.ShowMessage(lbError, "Student Registered Updated successfully", true);
                    }
                    else
                    {
                        Helper.ShowMessage(lbError, "Select at least 8 subjects.");
                    }
                }
                else
                {
                    Helper.ShowMessage(lbError, App.Error);
                }
            }
            else
            {
                Helper.ShowMessage(lbError, "Student already registered");
            }
        }

        private void Create(Registration registration)
        {
            if (!registration.Exists())
            {
                var created = registration.Create();

                if (created > 0)
                {
                    var subjectsSaved = SaveSubjects(created);

                    if(subjectsSaved)
                    {
                        Helper.ClearFields(this);
                        Helper.ShowMessage(lbError, "Student Registered successfully", true);
                    }
                    else
                    {
                        registration.Delete(created);
                        Helper.ShowMessage(lbError, "Select at least 8 subjects.");
                    }
                }
                else
                {
                    Helper.ShowMessage(lbError, App.Error);
                }
            }
            else
            {
                Helper.ShowMessage(lbError, "Registration already created");
            }
        }

        private void Add_Load(object sender, EventArgs e)
        {
            FetchYears();
            FetchForms();

            if (Action.Equals(App.Action.Edit))
            {
                Year year = new Year().Read(Registration.YearId);
                Stream stream = new Stream().Read(Registration.StreamId);
                Class classe = new Class().Read(stream.ClassId);
                Sector sector = new Sector().Read(classe.SectorId);
                Faculty faculty = new Faculty().Read(classe.FacultyId);
                Level level = new Level().Read(classe.LevelId);
                string form = string.Format("{0} {1}{2}{3}", sector.Acronym, level.Class, sector.Acronym.Contains("J") ? "" : faculty.Acronym + " ", stream.Description);

                btnSave.Text = "Update Record";
                cbForm.Text = form;
                cbYear.Text = year.Period;
                tbStudentID.Text = Registration.StudentId.ToString();
                tbReceiptNo.Text = Registration.FeeId.ToString();
            }
        }

        private void cbForm_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbForm.SelectedIndex > 0)
            {
                FetchSubjects(Forms[cbForm.Text]);
            }
        }
    }
}

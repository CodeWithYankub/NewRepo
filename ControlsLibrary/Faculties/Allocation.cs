using ClassLibrary;
using ControlsLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ControlsLibrary.Faculties
{
    public partial class Allocation : UserControl
    {
        private Faculty Faculty { get; set; }
        private Dictionary<int, bool> Cores { get; set; }
        private List<CheckBox> SubjectControls { get; set; }
        private Dictionary<string, int> Subjects { get; set; }
        private Dictionary<string, FacultySubject> Allocations { get; set; }

        public Allocation(int id)
        {
            InitializeComponent();

            Faculty = new Faculty().Read(id);

            Cores = new Dictionary<int, bool>();
            SubjectControls = new List<CheckBox>();
            Subjects = new Dictionary<string, int>();
            Allocations = new Dictionary<string, FacultySubject>();
        }

        #region Functions

        void fetchAllocations()
        {
            List<FacultySubject> allocations = new FacultySubject().Read(Faculty.ID);

            foreach(FacultySubject allocation in allocations)
            {
                Subject subject = new Subject().Read(allocation.SubjectId);
                Allocations.Add(subject.Name, allocation);
            }
        }

        CheckBox GetCheckBox(Subject subject, FacultySubject facultySubject)
        {
            CheckBox chb = new CheckBox()
            {
                AutoSize = true,
                Text = subject.Name,
                Cursor = Cursors.Hand,
                Checked = subject.ID.Equals(facultySubject.SubjectId),
                Font = new Font(Font, facultySubject.Core ? FontStyle.Bold : FontStyle.Regular)
            };

            chb.CheckedChanged += (object sender, EventArgs e) =>
            {
                bool isCore = false;

                if (chb.Checked)
                {
                    isCore = MessageBox.Show("Is this subject core?", "Set Core", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes);
                }

                chb.Font = new Font(Font, isCore ? FontStyle.Bold : FontStyle.Regular);
                chb.TextAlign = ContentAlignment.MiddleLeft;

                Cores[subject.ID] = isCore;
            };

            return chb;
        }

        void updateUI()
        {
            List<Subject> subjects = new Subject().Read();

            foreach(Subject subject in subjects)
            {
                if (subject.SectorId.Equals(Faculty.SectorId))
                {
                    FacultySubject facultySubject = new FacultySubject();

                    if (Allocations.ContainsKey(subject.Name))
                        facultySubject = Allocations[subject.Name];

                    var chb = GetCheckBox(subject, facultySubject);

                    Cores.Add(subject.ID, facultySubject.Core);
                    ttTitle.SetToolTip(chb, subject.Name);
                    Subjects.Add(subject.Name, subject.ID);

                    SubjectControls.Add(chb);
                    flpSubjects.Controls.Add(chb);
                }
            }
        }
        #endregion

        private void Allocation_Load(object sender, EventArgs e)
        {
            fetchAllocations();
            updateUI();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach(CheckBox check in flpSubjects.Controls)
            {
                Subject selected = new Subject().Read(Subjects[check.Text]);
                bool core = Cores[selected.ID];

                FacultySubject facultySubject = new FacultySubject()
                {
                    FacultyId = Faculty.ID,
                    SubjectId = selected.ID,
                    Core = core
                };

                if (check.Checked)
                {
                    if (!Allocations.ContainsKey(selected.Name))
                    {
                        if (!facultySubject.Exists())
                        {
                            var created = facultySubject.Create();
                            if (created)
                                ParentForm.DialogResult = DialogResult.OK;
                            else
                                Helper.ShowMessage(lblStatus, App.Error);
                        }
                        else
                        {
                            Helper.ShowMessage(lblStatus, "Subject already added");
                        }
                    }
                    else
                    {
                        var updated = facultySubject.Update(facultySubject.ID);

                        if (updated)
                            ParentForm.DialogResult = DialogResult.OK;
                        else
                            Helper.ShowMessage(lblStatus, App.Error);
                    }
                }
                else
                {
                    if (Allocations.ContainsKey(selected.Name))
                    {
                        var alloc = Allocations[selected.Name];
                        bool deleted = new FacultySubject().Delete(alloc.ID);
                        if (deleted)
                            ParentForm.DialogResult = DialogResult.OK;
                        else
                            Helper.ShowMessage(lblStatus, App.Error);
                    }

                }
            }
        }

        private void tbSearch_Enter(object sender, EventArgs e)
        {
            if (tbSearch.Text.EndsWith("."))
            {
                tbSearch.ResetText();
                tbSearch.ForeColor = Color.Black;
            }
        }

        private void tbSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearch.Text))
            {
                tbSearch.Text = "Search....";
                tbSearch.ForeColor = Color.Gray;
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            var isContained = !string.IsNullOrEmpty(tbSearch.Text) && !tbSearch.Text.Contains(".");

            if (isContained)
            {
                var checkBoxes = SubjectControls.FindAll(cb => cb.Text.ToLower().Contains(tbSearch.Text.ToLower())).ToList();

                flpSubjects.Controls.Clear();
                foreach(CheckBox checkBox in checkBoxes)
                {
                    flpSubjects.Controls.Add(checkBox);
                }
            }
            else
            {
                foreach (CheckBox checkBox in SubjectControls)
                {
                    flpSubjects.Controls.Add(checkBox);
                }
            }
        }
    }
}

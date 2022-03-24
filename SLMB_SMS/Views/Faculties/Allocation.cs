using SLMB_SMS.Models;
using SLMB_SMS.Models.SLMB_SMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLMB_SMS.Views.Faculties
{
    public partial class Allocation : UserControl
    {
        private Faculty Faculty { get; set; }
        private Dictionary<int, bool> Cores { get; set; }
        private Dictionary<string, int> Subjects { get; set; }
        private Dictionary<string, FacultyAllocation> Allocations { get; set; }
        public Allocation(int id)
        {
            InitializeComponent();

            Faculty = new Faculty().Read(id);

            Cores = new Dictionary<int, bool>();
            Subjects = new Dictionary<string, int>();
            Allocations = new Dictionary<string, FacultyAllocation>();
        }


        #region Custom Functions

        void fetchAllocations()
        {
            List<FacultyAllocation> allocations = new FacultyAllocation().Read(Faculty.ID);

            foreach (FacultyAllocation allocation in allocations)
            {
                Sub subject = new Sub().Read(allocation.Subject);
                Allocations.Add(subject.Name, allocation);
            }
        }

        void updateUI()
        {
            List<Sub> subjects = new Sub().Read();

            foreach (Sub subject in subjects)
            {
                FacultyAllocation alloc = new FacultyAllocation();

                if (Allocations.ContainsKey(subject.Name))
                    alloc = Allocations[subject.Name];

                CheckBox chb = new CheckBox();
                chb.Text = subject.Name;
                chb.Cursor = Cursors.Hand;

                Cores.Add(subject.ID, alloc.Core);
                ttTitle.SetToolTip(chb, subject.Name);
                Subjects.Add(subject.Name, subject.ID);

                chb.Checked = subject.ID.Equals(alloc.Subject);
                chb.Font = new Font(Font, alloc.Core ? FontStyle.Bold : FontStyle.Regular);
                chb.CheckedChanged += (object sender, EventArgs e) =>
                {
                    bool isCore = false;

                    if (chb.Checked)
                    {
                        isCore = MessageBox.Show("Is this subject core?", "Set Core", MessageBoxButtons.YesNo, MessageBoxIcon.Question).Equals(DialogResult.Yes);
                    }

                    chb.Font = new Font(Font, isCore ? FontStyle.Bold : FontStyle.Regular);

                    Cores[subject.ID] = isCore;
                };

                flpSubjects.Controls.Add(chb);
            }
        }
        #endregion

    }
}

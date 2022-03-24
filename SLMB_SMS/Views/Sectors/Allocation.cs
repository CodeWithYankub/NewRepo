using SLMB_SMS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SLMB_SMS.Views.Sectors
{
    public partial class Allocation : UserControl
    {
        private Sector Sector { get; set; }
        private Dictionary<int, bool> Cores { get; set; }
        private Dictionary<string, int> Subjects { get; set; }
        private Dictionary<string, SectorAllocation> Allocations { get; set; }
        public Allocation(int id)
        {
            InitializeComponent();

            Sector = new Sector().Read(id);

            Cores = new Dictionary<int, bool>();
            Subjects = new Dictionary<string, int>();
            Allocations = new Dictionary<string, SectorAllocation>();
        }

        #region Custom Functions

        void fetchAllocations()
        {
            List<SectorAllocation> allocations = new SectorAllocation().Read(Sector.ID);

            foreach(SectorAllocation allocation in allocations)
            {
                Sub subject = new Sub().Read(allocation.Subject);
                Allocations.Add(subject.Name, allocation);
            }
        }

        void updateUI()
        {
            List<Sub> subjects = new Sub().Read();

            foreach(Sub subject in subjects)
            {
                SectorAllocation alloc = new SectorAllocation();

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

        private void Allocation_Load(object sender, EventArgs e)
        {
            ParentForm.Text = string.Format("{0} Allocations", Sector.Name);
            fetchAllocations();
            updateUI();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            foreach(CheckBox check in flpSubjects.Controls)
            {
                Sub selected = new Sub().Read(Subjects[check.Text]);
                bool core = Cores[selected.ID];

                SectorAllocation sectorAllocation = new SectorAllocation()
                {
                    Sector = Sector.ID,
                    Subject = selected.ID,
                    Core = core
                };

                if (check.Checked)
                {
                    if (!Allocations.ContainsKey(selected.Name))
                    {
                        if (!sectorAllocation.Exist())
                        {
                            sectorAllocation.Create();
                        }
                        else
                        {
                            MessageBox.Show("Allocation already placed", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        sectorAllocation.Update(sectorAllocation);
                    }
                }
                else
                {
                    if (Allocations.ContainsKey(selected.Name))
                    {
                        var alloc = Allocations[selected.Name];
                        bool deleted = new SectorAllocation().Delete(alloc.ID);
                        if (!deleted)
                            MessageBox.Show("Error processing an allocation", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
        }
    }
}

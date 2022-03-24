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
    public partial class Index : UserControl
    {
        private int Selected { get; set; }
        private Dictionary<int,int> Registrations { get; set; }
        public Index()
        {
            InitializeComponent();

            Registrations = new Dictionary<int, int>();
        }

        #region Functions

        List<Registration> FilterRegistrations(List<Registration> registrations, string key)
        {
            var filtered = registrations.FindAll(reg => reg.StudentId.ToString().Contains(key));

            return filtered;
        }

        void FetchData(string key = null)
        {
            List<Registration> registrations = new Registration().Read();

            if (!string.IsNullOrEmpty(key))
            {
                registrations = FilterRegistrations(registrations, key);
            }

            ShowData(registrations);

            Selected = 0;
        }

        void ShowData(List<Registration> registrations)
        {
            int Index = 1;
            if (lstData.Items.Count > 0)
            {
                Registrations.Clear();
                lstData.Items.Clear();
            }

            Registrations.Clear();

            foreach (Registration registration in registrations)
            {
                Student student = new Student().Read(registration.StudentId);
                Year year = new Year().Read(registration.YearId);
                User user = new User().Read(registration.RegisteredBy);
                Stream stream = new Stream().Read(registration.StreamId);
                Class classe = new Class().Read(stream.ClassId);
                Sector sector = new Sector().Read(classe.SectorId);
                Faculty faculty = new Faculty().Read(classe.FacultyId);
                Level level = new Level().Read(classe.LevelId);
                string form = string.Format("{0} {1}{2}{3}", sector.Acronym, level.Class, sector.Acronym.Contains("J") ? "" : faculty.Acronym + " ", stream.Description);

                string[] arr = new string[]
                {
                    Index.ToString(),
                    registration.RegisteredOn.ToShortDateString(),
                    student.ID.ToString(),
                    string.Format("{0} {1} {2}", student.LastName,student.FirstName, student.OtherName),
                    form,
                    year.Period,
                    user.Username
                };

                ListViewItem li = new ListViewItem(arr);
                lstData.Items.Add(li);
                Registrations.Add(Index, registration.ID);

                Index += 1;
            }
        }
        private void AddNew_Clicked(object sender, EventArgs e)
        {
            Common common = new Common();
            if (sender is Button)
                common.AddControl("Register Student", new Add());
            else
                common.AddControl("Edit Registration", new Add(App.Action.Edit, Selected));

            var completed = common.ShowDialog().Equals(DialogResult.OK);

            if (completed)
                FetchData();
        }
        #endregion

        private void Index_Load(object sender, EventArgs e)
        {
            Helper.Resize(lstData);
            FetchData();
        }

        private void Index_Paint(object sender, PaintEventArgs e)
        {
            Helper.Resize(lstData);
        }

        private void lstData_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
                Selected = Registrations[Convert.ToInt32(e.Item.Text)];
            else
                Selected = 0;
        }

        private void contxMain_Opening(object sender, CancelEventArgs e)
        {
            btnContxEdit.Enabled = Selected > 0;
        }

        private void btnContxRefresh_Click(object sender, EventArgs e)
        {
            FetchData();

            if (!tbSearch.Text.Contains("."))
                tbSearch.Text = "Search student...";
        }

        private void btnContxNew_Click(object sender, EventArgs e)
        {
            btnAddNew.PerformClick();
        }

        private void tbSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearch.Text))
            {
                tbSearch.Text = "Search student...";
                tbSearch.ForeColor = Color.FromArgb(200, 200, 200);
            }
        }

        private void tbSearch_Enter(object sender, EventArgs e)
        {
            if (tbSearch.Text.Contains("."))
            {
                tbSearch.ResetText();
                tbSearch.ForeColor = Color.Black;
            }
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(tbSearch.Text) && !tbSearch.Text.Contains("."))
                FetchData(tbSearch.Text);
            else
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

        private void lstData_DoubleClick(object sender, EventArgs e)
        {
            if (Selected > 0)
                btnContxEdit.PerformClick();
        }
    }
}

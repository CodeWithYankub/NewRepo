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

namespace ControlsLibrary.Students
{

    public partial class Index : UserControl
    {
        private Dictionary<int, int> Virtual { get; set; }
        private int Selected { get; set; }
        public Index()
        {
            InitializeComponent();
        }

        #region Custom Functions

        List<Student> FilterStudents(List<Student> students, string key)
        {
            var filtered = students.FindAll(student => student.ID.ToString().Contains(key));

            return filtered;
        }

        void FetchData(string key = null)
        {
            List<Student> students = new Student().Read();

            if (!string.IsNullOrEmpty(key))
            {
                students = FilterStudents(students, key);
            }

            ShowData(students);

            Selected = 0;
        }

        void ShowData(List<Student> students)
        {
            if (lstData.Items.Count > 0)
                lstData.Items.Clear();

            foreach (Student student in students)
            {
                string[] arr = new string[]
                {
                    student.ID.ToString(),
                    string.Format("{0} {1} {2}", student.LastName, student.FirstName, student.OtherName),
                    student.Gender.ToString(),
                    student.DateOfBirth.ToShortDateString(),
                    student.ParentDetails.Name,
                    student.ParentDetails.Phone,
                    student.ParentDetails.Address,
                    student.Color.ToString(),
                    student.Active ? "Yes" : "No"
                };

                ListViewItem li = new ListViewItem(arr);
                lstData.Items.Add(li);
            }
        }
        private void AddNew_Clicked(object sender, EventArgs e)
        {
            Common common = new Common();
            if (sender is Button)
                common.AddControl("Admit Student", new Admit());
            else
                common.AddControl("Edit Student", new Admit(Selected));
            common.ShowDialog();
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
           Selected = Convert.ToInt32(e.Item.Text);
            else
                Selected = 0;
        }

        private void contxMain_Opening(object sender, CancelEventArgs e)
        {
            btnContxEdit.Enabled = Selected > 0;
            btnContxView.Enabled = Selected > 0;
            btnContxLeft.Enabled = Selected > 0;

            if (Selected > 0)
            {
                Student student = new Student().Read(Selected);
                btnContxLeft.Text = student.Active ? "Deactive" : "Activate";
                btnContxLeft.Checked = student.Active;
            }
        }

        private void btnContxRefresh_Click(object sender, EventArgs e)
        {
            FetchData();
        }

        private void btnContxNew_Click(object sender, EventArgs e)
        {
            btnAddNew.PerformClick();
        }

        private void tbSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearch.Text))
            {
                tbSearch.Text = "Search id...";
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

        private void btnContxLeft_Click(object sender, EventArgs e)
        {
            Student student = new Student().Read(Selected);

            var updated = student.Delete();

            if (updated)
            {
                var isContained = !string.IsNullOrEmpty(tbSearch.Text) && !tbSearch.Text.Contains(".");
                FetchData(isContained ? tbSearch.Text : null);
            }
        }

        private void lbClear_Click(object sender, EventArgs e)
        {
            tbSearch.ResetText();
            tbSearch.Focus();
        }

        private void btnContxView_Click(object sender, EventArgs e)
        {
            Common common = new Common();
            common.AddControl("View Student", new View(Selected), 45);
            common.ShowDialog();
        }

        private void lstData_DoubleClick(object sender, EventArgs e)
        {
            if (Selected > 0)
            {
                btnContxView.PerformClick();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            bool printed = Printer.Print(lstData, "Students");

            if (printed)
            {
                MessageBox.Show("Document Exported Successfully", "Exported", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}

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

namespace SLMB_SMS.Views.Students
{
    public partial class Index : UserControl
    {
        private int Selected { get; set; }
        private bool isSelected { get; set; }
        public Index()
        {
            InitializeComponent();
        }

        #region Custom Functions
        void FetchData(string key = null)
        {
            List<Student> students = string.IsNullOrEmpty(key) ? new Student().Read() : new Student().Search(key);

            ShowData(students);

            isSelected = false;
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
                    student.ParentName,
                    student.ParentPhone,
                    student.ParentAddress,
                    student.Color.ToString(),
                    student.IsActive ? "No" : "Yes"
                };
                ListViewItem li = new ListViewItem(arr);
                lstData.Items.Add(li);
            }
        }
        private void AddNew_Clicked(object sender, EventArgs e)
        {
            Universal universal = new Universal();
            if (sender.GetType().Equals(new Button().GetType()))
                universal.AddControl("Admit Student", new Admit());
            else
                universal.AddControl("Edit Student", new Admit(Selected));

            universal.ShowDialog();

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
            isSelected = e.IsSelected;

            if (isSelected)
                Selected = Convert.ToInt32(e.Item.Text);
            else
                Selected = 0;
        }

        private void contxMain_Opening(object sender, CancelEventArgs e)
        {
            btnContxEdit.Enabled = isSelected;
            btnContxView.Enabled = isSelected;
            btnContxLeft.Enabled = isSelected;

            if (isSelected)
            {
                Student student = new Student().Read(Selected);
                btnContxLeft.Checked = !student.IsActive;
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
            {
                lbClear.Visible = true;
                FetchData(tbSearch.Text);
            }
            else
            {
                lbClear.Visible = false;
                FetchData();
            }
        }

        private void btnContxLeft_Click(object sender, EventArgs e)
        {
            Student student = new Student().Read(Selected);

            student.IsActive = !student.IsActive;

            var updated = new Student().Update(student);

            if (updated)
                FetchData(!string.IsNullOrEmpty(tbSearch.Text) ? tbSearch.Text : null);
        }

        private void lbClear_Click(object sender, EventArgs e)
        {
            tbSearch.ResetText();
            tbSearch.Focus();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            bool printed = Helper.DoPrint(Helper.ToDataTable(lstData), "Students");

            if (!printed)
            {
                MessageBox.Show("Error printing report", "Print Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnContxView_Click(object sender, EventArgs e)
        {
            Universal universal = new Universal();
            universal.AddControl("View Student", new View(Selected));
            universal.ShowDialog();
        }

        private void lstData_DoubleClick(object sender, EventArgs e)
        {
            if (isSelected)
            {
                btnContxView.PerformClick();
            }
        }
    }
}

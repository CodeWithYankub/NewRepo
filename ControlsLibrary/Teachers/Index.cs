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

namespace ControlsLibrary.Teachers
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
        List<Teacher> FilterTeachers(List<Teacher> teachers, string key)
        {
            var filtered = teachers.FindAll(teacher => teacher.ID.ToString().Contains(key));

            return filtered;
        }
        void FetchData(string key = null)
        {
            List<Teacher> teachers = new Teacher().Read();

            if (!string.IsNullOrEmpty(key))
            {
                teachers = FilterTeachers(teachers, key);
            }

            ShowData(teachers);

            Selected = 0;
        }


        void ShowData(List<Teacher> teachers)
        {
            int index = 1;

            if (lstData.Items.Count > 0)
            {
                lstData.Items.Clear();
                Virtual.Clear();
            }

            foreach (Teacher teacher in teachers)
            {
                string[] arr = new string[]
                {
                    index.ToString(),
                    teacher.Name,
                    teacher.Gender.ToString(),
                    teacher.Phone,
                    teacher.Address,
                    teacher.Email,
                    new Sector().Read(teacher.SectorId).Name,
                    teacher.PinCode.ToString(),
                    teacher.Approved? "Yes" : "No",
                    teacher.NextOfKin.Name,
                    teacher.Active ? "Yes" : "No"
                };

                ListViewItem li = new ListViewItem(arr);
                lstData.Items.Add(li);
                Virtual.Add(index, teacher.ID);
                index += 1;
            }
        }

        private void AddEdit_Clicked(object sender, EventArgs e)
        {
            Common common = new Common();
            if (sender is Button)
                common.AddControl("Add Teacher", new Adds());
            else
                common.AddControl("Edit teacher", new Adds(Selected));
            common.ShowDialog();
            FetchData();
        }
        #endregion

        private void Index_Load(object sender, EventArgs e)
        {
            Helper.Resize(lstData);

            FetchData();
        }

        private void contxMain_Opening(object sender, CancelEventArgs e)
        {
            //btnContxEdit.Enabled = isSelected;
            btnContxEdit.Enabled = Selected > 0;
            btnContxLeft.Enabled = Selected > 0;

            if (Selected > 0)
            {
                Teacher teacher = new Teacher().Read(Selected);
                btnContxLeft.Text = teacher.Active ? "Deactive" : "Activate";
                btnContxLeft.Checked = teacher.Active;
            }
        }

        private void btnContxRefresh_Click(object sender, EventArgs e)
        {
            FetchData();
        }

        private void lstData_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
                Selected = Virtual[Convert.ToInt32(e.Item.Text)];
            else
                Selected = 0;
        }

        private void btnContxNew_Click(object sender, EventArgs e)
        {
            btnAddNew.PerformClick();
        }

        private void lstData_DoubleClick(object sender, EventArgs e)
        {
            if (Selected > 0)
                btnContxEdit.PerformClick();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbSearch.Text) && !tbSearch.Text.Contains("."))
            {
                FetchData(tbSearch.Text);
                lbClear.Visible = true;
            }
            else
            {
                FetchData();
                lbClear.Visible = false;
            }
        }

        private void lbClear_Click(object sender, EventArgs e)
        {
            tbSearch.ResetText();
        }

        private void tbSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearch.Text))
            {
                tbSearch.Text = "Search...";
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

        private void Index_Paint(object sender, PaintEventArgs e)
        {
            Helper.Resize(lstData);
        }

        private void btnContxLeft_Click_1(object sender, EventArgs e)
        {
            Teacher teacher = new Teacher().Read(Selected);

            var updated = teacher.Delete();

            if (updated)
            {
                var isContained = !string.IsNullOrEmpty(tbSearch.Text) && !tbSearch.Text.Contains(".");
                FetchData(isContained ? tbSearch.Text : null);
            }
        }

        private void Index_DoubleClick(object sender, EventArgs e)
        {
            if (Selected > 0)
                btnContxEdit.PerformClick();
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

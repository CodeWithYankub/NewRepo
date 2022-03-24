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

namespace SLMB_SMS.Views.Teachers
{
    public partial class index : UserControl
    {
        private int Selected { get; set; }
        private bool isSelected { get; set; }
        Dictionary<int,int> Teachers { get; set; }
        public index()
        {
            InitializeComponent();

            Teachers = new Dictionary<int, int>();
        }
        #region Custom Functions
        void FetchData(string search = null)
        {
            List<Teacher> teachers = string.IsNullOrEmpty(search) ? new Teacher().Read() : new Teacher().Search(search);

            if (Teachers.Count > 0)
                Teachers.Clear();

            ShowData(teachers);

            isSelected = false;
        }

        void ShowData(List<Teacher> teachers)
        {

            if (lstData.Items.Count > 0)
                lstData.Items.Clear();

            for (int i = 0; i < teachers.Count; i++)
            {
                int index = i + 1;
                Teacher teacher = teachers[i];
                Sector sector = new Sector().Read(teacher.Sector);

                string[] arr = new string[]
                {
                    index.ToString(),
                    teacher.PinCode,
                    teacher.Name,
                    teacher.Gender.ToString(),
                    teacher.Email,
                    teacher.Address,
                    sector.Name,
                    teacher.IsApproved ? "Yes" : "No",
                    teacher.KinName,
                      teacher.PhoneNo

                };
                Teachers.Add(index, teacher.ID);
                ListViewItem li = new ListViewItem(arr);
                lstData.Items.Add(li);
            }
        }

        private void AddEdit_Clicked(object sender, EventArgs e)
        {
            Universal universal = new Universal();

            if (sender.GetType().Equals(new Button().GetType()))
                universal.AddControl("New teacher", new Add());
            else
                universal.AddControl("Edit teacher", new Add(Selected));

            universal.ShowDialog();

            FetchData();
        }
        #endregion

        private void index_Load(object sender, EventArgs e)
        {
            Helper.Resize(lstData);
            FetchData();
        }

        private void btnAddNew_Click(object sender, EventArgs e)
        {
            Universal universal = new Universal();
            universal.AddControl("Add Teacher", new Add());
            universal.ShowDialog();

            FetchData();
        }

        private void contxMain_Opening(object sender, CancelEventArgs e)
        {
            btnContxEdit.Enabled = isSelected;
        }
       

        private void btnContxRefresh_Click(object sender, EventArgs e)
        {
            FetchData();
        }

        private void lstData_ItemSelectionChanged_1(object sender, ListViewItemSelectionChangedEventArgs e)
        {

            isSelected = e.IsSelected;

            if (isSelected)
                Selected = Teachers[int.Parse(e.Item.Text)];
            else
                Selected = 0;
        }

        private void btnContexView_Click(object sender, EventArgs e)
        {
           
        }

        private void btnContxNew_Click(object sender, EventArgs e)
        {
            btnAddNew.PerformClick();
        }

        private void index_Paint(object sender, PaintEventArgs e)
        {
            Helper.Resize(lstData);
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

        private void lbClear_Click(object sender, EventArgs e)
        {
            tbSearch.ResetText();
        }

        private void lstData_DoubleClick(object sender, EventArgs e)
        {
            if (isSelected)
            {
                btnContxEdit.PerformClick();
            }
        }
    }
}

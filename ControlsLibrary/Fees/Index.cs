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

namespace ControlsLibrary.Fees
{
    public partial class Index : UserControl
    {
        private int Selected { get; set; }
        public Index()
        {
            InitializeComponent();
        }

        #region Custom Functions

        private List<Fee> FilterStudents(List<Fee> fees, string key)
        {
            var filtered = fees.FindAll(fee => fee.StudentId.ToString().Contains(key));

            return filtered;
        }

        private void FetchData(string key = null)
        {
            List<Fee> fees = new Fee().Read();

            if (!string.IsNullOrEmpty(key))
            {
                fees = FilterStudents(fees, key);
            }

            ShowData(fees);

            Selected = 0;
        }

        private void ShowData(List<Fee> fees)
        {
            if (lstData.Items.Count > 0)
                lstData.Items.Clear();

            foreach (Fee fee in fees)
            {
                Student student = new Student().Read(fee.StudentId);
                Year year = new Year().Read(fee.YearId);
                User user = new User().Read(fee.PaidTo);
                string[] arr = new string[]
                {
                    fee.ID.ToString(),
                    fee.PaidOn.ToShortDateString(),
                    student.ID.ToString(),
                    string.Format("{0} {1} {2}", student.LastName,student.FirstName, student.OtherName),
                    fee.Amount.ToString(),
                    year.Period,
                    fee.Terms,
                    fee.Completed ? "Yes" : "No",
                    user.Username
                };

                ListViewItem li = new ListViewItem(arr);
                lstData.Items.Add(li);
            }
        }
        private void AddNew_Clicked(object sender, EventArgs e)
        {
            Common common = new Common();
            if (sender is Button)
                common.AddControl("Admit Student", new Add());
            else
                common.AddControl("Edit Student", new Add(App.Action.Edit, Selected));

            var completed = common.ShowDialog().Equals(DialogResult.OK);

            if (completed)
                FetchData();
        }
        #endregion

        private void Index_Load(object sender, EventArgs e)
        {
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

        private void btnPrint_Click(object sender, EventArgs e)
        {
            bool printed = Printer.Print(lstData, "Students");

            if (printed)
            {
                MessageBox.Show("Document Exported Successfully", "Exported", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Index_SizeChanged(object sender, EventArgs e)
        {
            Helper.Resize(lstData);
        }

        private void lstData_DoubleClick(object sender, EventArgs e)
        {
            if (Selected > 0)
                btnContxEdit.PerformClick();
        }
    }
}

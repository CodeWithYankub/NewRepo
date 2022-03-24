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

namespace SLMB_SMS.Views.Fees
{
    public partial class index : UserControl
    {
        private int Selected { get; set; }
        private bool isSelected { get; set; }
        public index()
        {
            InitializeComponent();

            isSelected = false;
        }


        #region Custom Functions
        void FetchData(string key = null)
        {
            List<Fee> fees = !string.IsNullOrEmpty(key) ? new Fee().Search(key) : new Fee().Read();

            ShowData(fees);
            isSelected = false;
        }

        void ShowData(List<Fee> fees)
        {
            if (lstData.Items.Count > 0)
                lstData.Items.Clear();

            foreach (Fee fee in fees)
            {
                Year year = new Year().Read(fee.Year);

                ListViewItem li = new ListViewItem(new string[] {
                    fee.ID.ToString(),
                    year.Period,
                    fee.Student.ToString(),
                    string.Format("{0, 0:N0}",fee.Amount),
                    fee.Terms,
                    fee.IsFull ? "Yes" : "No",
                    fee.DatePaid.ToShortDateString()
                });

                lstData.Items.Add(li);
            }
        }

        private void AddEdit_Clicked(object sender, EventArgs e)
        {
            Universal universal = new Universal();

            if (sender.GetType().Equals(new Button().GetType()))
                universal.AddControl("New Sector", new Add());
            else
                universal.AddControl("Edit Sector", new Add(Selected));

            universal.ShowDialog();

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
            isSelected = e.IsSelected;

            if (isSelected)
                Selected = Convert.ToInt32(e.Item.Text);
            else
                Selected = 0;
        }

        private void contxMain_Opening(object sender, CancelEventArgs e)
        {
            btnContxEdit.Enabled = isSelected;
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
                tbSearch.Text = "Search student...";
                tbSearch.ForeColor = Color.FromArgb(200, 200, 200);
            }
        }

        private void tbSearch_Enter(object sender, EventArgs e)
        {
            tbSearch.ResetText();
            tbSearch.ForeColor = Color.Black;
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            if(!string.IsNullOrEmpty(tbSearch.Text) && !tbSearch.Text.Contains("."))
            {
                FetchData(tbSearch.Text);
            }
            else
            {
                FetchData();
            }
        }
    }
}

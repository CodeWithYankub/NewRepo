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

namespace SLMB_SMS.Views.Registrations
{
    public partial class Index : UserControl
    {
        private int Selected { get; set; }
        private bool isSelected { get; set; }
        private Dictionary<int, int> Registrations { get; set; }
        public Index()
        {
            InitializeComponent();

            isSelected = false;
            Registrations = new Dictionary<int, int>();
        }

        #region Custom Functions
        void FetchData(string key = null)
        {
            List<Registration> registrations = string.IsNullOrEmpty(key) ? new Registration().Read() : new Registration().Search(key);

            if (registrations.Count > 0)
                Registrations.Clear();

            ShowData(registrations);
            isSelected = false;
        }

        void ShowData(List<Registration> registrations)
        {
            if (lstData.Items.Count > 0)
                lstData.Items.Clear();

            for (int x = 0;x<registrations.Count;x++)
            {
                int index = x + 1;
                Registration registration = registrations[x];

                Models.Form form = new Models.Form().Read(registration.Form);
                Classes clas = new Classes().Read(form.Class);
                ListViewItem li = new ListViewItem(new string[] {
                    index.ToString(),
                    registration.Student.ToString(),
                    new Year().Read(registration.Year).Period,
                    string.Format("{0} {1}{2} ({3})", new Sector().Read(clas.Sector).Acronym, new Models.Level().Read(clas.Level).Class, new Faculty().Read(clas.Faculty).Acronym, form.Name),
                    registration.Receipt.ToString(),
                    registration.DateRegisterd.ToShortDateString()
                });
                Registrations.Add(index, registration.ID);
                lstData.Items.Add(li);
            }
        }

        private void AddEdit_Clicked(object sender, EventArgs e)
        {
            Universal universal = new Universal();

            if (sender.GetType().Equals(new Button().GetType()))
                universal.AddControl("New Registration", new Add());
            else
                universal.AddControl("Edit Registration", new Add(Selected));

            universal.ShowDialog();

            if (!tbSearch.Text.Contains("."))
                FetchData(tbSearch.Text);
            else
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
                Selected = Registrations[int.Parse(e.Item.Text)];
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
            tbSearch.ResetText();
        }

        private void btnContxNew_Click(object sender, EventArgs e)
        {
            btnAddNew.PerformClick();
        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            lbClear.Visible = !string.IsNullOrEmpty(tbSearch.Text) && !tbSearch.Text.Contains(".");

            if (lbClear.Visible)
            {
                FetchData(tbSearch.Text);
            }
            else
            {
                FetchData();
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
            tbSearch.Focus();
            tbSearch.ResetText();
        }

        private void lstData_DoubleClick(object sender, EventArgs e)
        {
            if(isSelected)
            {
                btnContxEdit.PerformClick();
            }
        }
    }
}

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

namespace SLMB_SMS.Views.Years
{
    public partial class Index : UserControl
    {
        private int Selected { get; set; }
        private bool isSelected { get; set; }
        private Dictionary<string, int> Years { get; set; }
        public Index()
        {
            InitializeComponent();

            isSelected = false;
            Years = new Dictionary<string, int>();
        }

        #region Custom Functions
        void FetchData()
        {
            List<Year> years = new Year().Read();
            Years.Clear();

            ShowData(years);
            isSelected = false;
        }

        void ShowData(List<Year> years)
        {
            if (lstData.Items.Count > 0)
                lstData.Items.Clear();
            
            foreach (Year year in years)
            {
                string paid = year.IsPayble ? "Yes" : "No";
                ListViewItem li = new ListViewItem(new string[] { year.Period, year.Status.ToString(), paid });
                Years.Add(year.Period, year.ID);
                lstData.Items.Add(li);
            }
        }

        private void AddEdit_Clicked(object sender, EventArgs e)
        {
            Universal universal = new Universal();

            if (sender.GetType().Equals(new Button().GetType()))
                universal.AddControl("New Year", new Add());
            else
                universal.AddControl("Edit Year", new Add(Selected));

            universal.ShowDialog();

            FetchData();
        }
        #endregion

        private void btnContxRefresh_Click(object sender, EventArgs e)
        {
            FetchData();
        }

        private void btnContxEnableDisable_Click(object sender, EventArgs e)
        {
            Year year = new Year().Read(Selected);
            year.Status = year.Status.Equals(Helper.Status.Enabled) ? Helper.Status.Disabled : Helper.Status.Enabled;

            bool updated = new Year().Update(year);

            if (updated)
                FetchData();
        }

        private void lstData_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            isSelected = e.IsSelected;

            if (isSelected)
                Selected = Years[e.Item.Text];
            else
                Selected = 0;
        }

        private void contxMain_Opening(object sender, CancelEventArgs e)
        {
            if (isSelected)
            {
                Year year = new Year().Read(Selected);
                btnContxEnableDisable.Text = year.Status.Equals(Helper.Status.Enabled) ? "Disable" : "Enable";
            }
            btnContxEdit.Enabled = isSelected;
            btnContxEnableDisable.Enabled = isSelected;
        }

        private void Index_Paint(object sender, PaintEventArgs e)
        {
            Helper.Resize(lstData);
        }

        private void Index_Load(object sender, EventArgs e)
        {
            FetchData();
        }
    }
}

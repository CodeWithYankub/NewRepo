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
    public partial class Index : UserControl
    {
        private int Selected { get; set; }
        private bool isSelected { get; set; }
        private Dictionary<string, int> Sectors { get; set; }
        public Index()
        {
            InitializeComponent();

            isSelected = false;
            Sectors = new Dictionary<string, int>();
        }

        #region Custom Functions
        void FetchData()
        {
            List<Sector> sectors = new Sector().Read();
            Sectors.Clear();

            ShowData(sectors);
            isSelected = false;
        }

        void ShowData(List<Sector> sectors)
        {
            if (lstData.Items.Count > 0)
                lstData.Items.Clear();

            foreach(Sector sector in sectors)
            {
                ListViewItem li = new ListViewItem(new string[] { sector.Name, sector.Acronym });
                Sectors.Add(sector.Name, sector.ID);
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
                Selected = Sectors[e.Item.Text];
            else
                Selected = 0;
        }

        private void contxMain_Opening(object sender, CancelEventArgs e)
        {
            btnContxEdit.Enabled = isSelected;
            btnContxAllocate.Enabled = isSelected;
        }

        private void btnContxRefresh_Click(object sender, EventArgs e)
        {
            FetchData();
        }

        private void btnContxAllocate_Click(object sender, EventArgs e)
        {
            Universal universal = new Universal();
            universal.AddControl("Allocations", new Allocation(Selected));
            universal.ShowDialog();

            FetchData();
        }
    }
}

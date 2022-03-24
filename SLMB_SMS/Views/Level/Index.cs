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

namespace SLMB_SMS.Views.Level
{
    public partial class Index : UserControl
    {
        private int Selected { get; set; }
        private bool isSelected { get; set; }
        private Dictionary<int, int> Levels { get; set; }
        public Index()
        {
            InitializeComponent();

            isSelected = false;
            Levels = new Dictionary<int, int>();
        }

        #region Custom Functions
        void FetchData()
        {
            List<Models.Level> levels = new Models.Level().Read();
            Levels.Clear();

            ShowData(levels);
            isSelected = false;
        }

        void ShowData(List<Models.Level> levels)
        {
            if (lstData.Items.Count > 0)
                lstData.Items.Clear();

            for(int i = 0; i < levels.Count; i++)
            {
                int index = i + 1;
                var level = levels[i];
                var sector = new Sector().Read(level.Sector);
                ListViewItem li = new ListViewItem(new string[] {
                    index.ToString(),
                    string.Format("{0} ({1})",sector.Name, sector.Acronym),
                    level.Class.ToString()
                });
                lstData.Items.Add(li);
                Levels.Add(index, level.ID);
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
                Selected = Levels[Convert.ToInt32(e.Item.Text)];
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
    }
}

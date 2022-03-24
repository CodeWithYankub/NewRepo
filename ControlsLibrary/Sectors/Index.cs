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

namespace ControlsLibrary.Sectors
{
    public partial class Index : UserControl
    {
        private int selected { get; set; }
        private Dictionary<int,int> virSectors { get; set; }
        public Index()
        {
            InitializeComponent();
            virSectors = new Dictionary<int, int>();
        }
        #region Functions
        void GetData()
        {
            int index = 0;
            var sectors = new Sector().Read();

            if (virSectors.Count > 0)
            {
                lstData.Items.Clear();
                virSectors.Clear();
            }

            foreach(Sector sector in sectors)
            {
                index += 1;
                string[] data = new string[]
                {
                    index.ToString(),
                    sector.Name,
                    sector.Acronym
                };
                lstData.Items.Add(new ListViewItem(data));

                virSectors.Add(index, sector.ID);
            }

            selected = 0;
        }
        DialogResult Result(string action, Control ctrl)
        {
            Common common = new Common();
            common.AddControl(string.Format("{0} Sector", action), ctrl);
            return common.ShowDialog();
        }
        #endregion

        private void Fetch_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void Index_Paint(object sender, PaintEventArgs e)
        {
            Helper.Resize(lstData);
        }

        private void btnContxNew_Click(object sender, EventArgs e)
        {
            btnAdd.PerformClick();
        }

        private void btnContxRefresh_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void AddEdit_Click(object sender, EventArgs e)
        {
            var shown = true;

            if (sender is Button)
                shown = Result("Add", new Add()).Equals(DialogResult.OK);
            else
                shown = Result("Edit", new Add(App.Action.Edit, selected)).Equals(DialogResult.OK);

            if (shown)
                GetData();
        }

        private void lstData_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
                selected = virSectors[Convert.ToInt32(e.Item.Text)];
            else
                selected = 0;
        }

        private void contxMain_Opening(object sender, CancelEventArgs e)
        {
            btnContxEdit.Enabled = selected > 0;
        }

        private void Index_SizeChanged(object sender, EventArgs e)
        {
            Helper.Resize(lstData);
        }

        private void lstData_DoubleClick(object sender, EventArgs e)
        {
            if (selected > 0)
                btnContxEdit.PerformClick();
        }
    }
}

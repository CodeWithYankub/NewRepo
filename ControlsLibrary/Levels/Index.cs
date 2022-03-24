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

namespace ControlsLibrary.Levels
{
    public partial class Index : UserControl
    {
        private int selected { get; set; }
        private Dictionary<int, int> virLevels { get; set; }
        public Index()
        {
            InitializeComponent();
            virLevels = new Dictionary<int, int>();
        }

        #region Functions
        void GetData()
        {
            int index = 0;
            List<Level> levels = new Level().Read();

            if (virLevels.Count > 0)
            {
                lstData.Items.Clear();
                virLevels.Clear();
            }

            foreach (Level level in levels)
            {
                index += 1;
                Sector sector = new Sector().Read(level.SectorId);
                string[] data = new string[]
                {
                    index.ToString(),
                    sector.Name,
                    Helper.ToRomans(level.Class)
                };

                lstData.Items.Add(new ListViewItem(data));

                virLevels.Add(index, level.ID);
            }

            selected = 0;
        }
        
        DialogResult Result(string action, Control ctrl)
        {
            Common common = new Common();
            common.AddControl(string.Format("{0} Level", action), ctrl);
            return common.ShowDialog();
        }
        
        #endregion

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
                selected = virLevels[Convert.ToInt32(e.Item.Text)];
            else
                selected = 0;
        }

        private void btnContxRefresh_Click(object sender, EventArgs e)
        {
            GetData();
        }

        private void btnContxNew_Click(object sender, EventArgs e)
        {
            btnAdd.PerformClick();
        }

        private void contxMain_Opening(object sender, CancelEventArgs e)
        {
            btnContxEdit.Enabled = selected > 0;
        }

        private void Index_Paint(object sender, PaintEventArgs e)
        {
            Helper.Resize(lstData);
        }

        private void Index_SizeChanged(object sender, EventArgs e)
        {
            Helper.Resize(lstData);
        }

        private void Index_Load(object sender, EventArgs e)
        {
            GetData();
        }

        private void lstData_DoubleClick(object sender, EventArgs e)
        {
            if (selected > 0)
                btnContxEdit.PerformClick();
        }
    }
}

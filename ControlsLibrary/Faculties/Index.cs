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

namespace ControlsLibrary.Faculties
{
    public partial class Index : UserControl
    {
        private int selected { get; set; }
        private Dictionary<int, int> virFaculties { get; set; }
        public Index()
        {
            InitializeComponent();
            virFaculties = new Dictionary<int, int>();
        }

        #region Functions
        void GetData()
        {
            int index = 0;
            List<Faculty> faculties = new Faculty().Read();

            if (virFaculties.Count > 0)
            {
                lstData.Items.Clear();
                virFaculties.Clear();
            }

            foreach (Faculty faculty in faculties)
            {
                index += 1;
                Sector sector = new Sector().Read(faculty.SectorId);
                string[] data = new string[]
                {
                    index.ToString(),
                    faculty.Name,
                    faculty.Acronym,
                    sector.Name
                };

                lstData.Items.Add(new ListViewItem(data));

                virFaculties.Add(index, faculty.ID);
            }

            selected = 0;
        }
        
        DialogResult Result(string action, Control ctrl)
        {
            Common common = new Common();
            common.AddControl(string.Format("{0} Faculty", action), ctrl);
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
                selected = virFaculties[Convert.ToInt32(e.Item.Text)];
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

        private void btnContxSubjects_Click(object sender, EventArgs e)
        {
            Common common = new Common();
            Faculty faculty = new Faculty().Read(selected);
            Sector sector = new Sector().Read(faculty.SectorId);
            common.AddControl(string.Format("{0}-{1} ({2}) Subjects", sector.Acronym, faculty.Name, faculty.Acronym), new Allocation(faculty.ID));
            var result = common.ShowDialog().Equals(DialogResult.OK);

            if (result)
                GetData();
        }

        private void lstData_DoubleClick(object sender, EventArgs e)
        {
            if (selected > 0)
                btnContxEdit.PerformClick();
        }
    }
}

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

namespace ControlsLibrary.Streams
{
    public partial class Index : UserControl
    {
        private int selected { get; set; }
        private Dictionary<int, int> virStreams { get; set; }
        public Index()
        {
            InitializeComponent();
            virStreams = new Dictionary<int, int>();
        }

        #region Functions
        void GetData()
        {
            int index = 0;
            List<Stream> streams = new Stream().Read();

            if (virStreams.Count > 0)
            {
                lstData.Items.Clear();
                virStreams.Clear();
            }

            foreach (Stream stream in streams)
            {
                index += 1;
                Class classe = new Class().Read(stream.ClassId);
                Sector sector = new Sector().Read(classe.SectorId);
                Faculty faculty = new Faculty().Read(classe.FacultyId);
                Level level = new Level().Read(classe.LevelId);
                string[] data = new string[]
                {
                    index.ToString(),
                    sector.Name,
                    faculty.Name,
                    Helper.ToRomans(level.Class),
                    stream.Description
                };

                lstData.Items.Add(new ListViewItem(data));

                virStreams.Add(index, stream.ID);
            }

            selected = 0;
        }
        
        DialogResult Result(string action, Control ctrl)
        {
            Common common = new Common();
            common.AddControl(string.Format("{0} Stream", action), ctrl);
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
                selected = virStreams[Convert.ToInt32(e.Item.Text)];
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

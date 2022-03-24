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

namespace ControlsLibrary.Subjects
{
    public partial class Index : UserControl
    {
        private int selected { get; set; }
        private Dictionary<int, int> virSubjects { get; set; }
        public Index()
        {
            InitializeComponent();
            virSubjects = new Dictionary<int, int>();
        }

        #region Functions
        void GetData()
        {
            int index = 0;
            List<Subject> subjects = new Subject().Read();

            if (virSubjects.Count > 0)
            {
                lstData.Items.Clear();
                virSubjects.Clear();
            }

            foreach (Subject subject in subjects)
            {
                index += 1;
                Sector sector = new Sector().Read(subject.SectorId);
                string[] data = new string[]
                {
                    index.ToString(),
                    subject.Name,
                    subject.Code.ToString(),
                    sector.Name
                };

                lstData.Items.Add(new ListViewItem(data));

                virSubjects.Add(index, subject.ID);
            }

            selected = 0;
        }
        
        DialogResult Result(string action, Control ctrl)
        {
            Common common = new Common();
            common.AddControl(string.Format("{0} Subject", action), ctrl);
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
                selected = virSubjects[Convert.ToInt32(e.Item.Text)];
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

        private void btnContxImport_Click(object sender, EventArgs e)
        {
            OpenFileDialog brw = new OpenFileDialog()
            {
                Title = "Select File",
                Filter = "*.CSV (Only)|*.csv"
            };

            if (brw.ShowDialog().Equals(DialogResult.OK))
            {
                int added = 0;
                var file = new System.IO.FileInfo(brw.FileName);
                string[] lines = System.IO.File.ReadAllLines(file.FullName);

                for(int i = 1; i < lines.Length; i++)
                {
                    var line = lines[i].Split(',');

                    string name = line[1];
                    int code = Convert.ToInt32(line[0]);
                    int sector = Convert.ToInt32(line[2]);

                    Subject sub = new Subject()
                    {
                        Code = code,
                        Name = name,
                        SectorId = sector
                    };

                    if (sub.Create())
                    {
                        added += 1;
                    }
                }

                if (added > 0)
                    GetData();
            }
        }
    }
}

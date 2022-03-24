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

namespace SLMB_SMS.Views.classes
{
    public partial class Index : UserControl
    {
        private int Selected { get; set; }
        private bool isSelected { get; set; }
        private Dictionary<int, int> Classes { get; set; }
        public Index()
        {
            InitializeComponent();

            isSelected = false;
            Classes = new Dictionary<int, int>();
        }

        #region Custom Functions
        void FetchData()
        {
            List<Classes> classes = new Classes().Read();
            Classes.Clear();

            ShowData(classes);
            isSelected = false;
        }

        void ShowData(List<Classes> classes)
        {
            if (lstData.Items.Count > 0)
                lstData.Items.Clear();

            for (int i = 0; i < classes.Count; i++)
            {
                int index = i + 1;
                Classes clas = classes[i];
                Sector sector = new Sector().Read(clas.Sector);
                Faculty faculty = new Faculty().Read(clas.Faculty);
                Models.Level level = new Models.Level().Read(clas.Level);
                ListViewItem li = new ListViewItem(new string[] {
                    index.ToString(),
                    sector.Acronym,
                    level.Class.ToString(),
                    faculty.Name
                });
                Classes.Add(index, clas.ID);
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
                Selected = Classes[Convert.ToInt32(e.Item.Text)];
            else
                Selected = 0;
        }

        private void contxMain_Opening(object sender, CancelEventArgs e)
        {
            btnContxEdit.Enabled = isSelected;
        }

       
        private void btnContxNew_Click(object sender, EventArgs e)
        {
            btnAddNew.PerformClick();
        }

        private void btnContxRefresh_Click_1(object sender, EventArgs e)
        {
            FetchData();
        }
    }
}
